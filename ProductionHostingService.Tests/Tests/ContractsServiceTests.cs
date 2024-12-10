using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Moq;
using ProductionHostingService.Repository.Interfaces;
using ProductionHostingService.Repository;
using Xunit;


public class ContractsServiceTests
{
     [Fact]
        public async Task CreateContractAsync_FacilityNotFound_ThrowsInvalidOperationException()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb_FacilityNotFound")
                .Options;

            using var context = new ApplicationDbContext(options);

            // Для теста у нас нет записей о фабриках

            var uowMock = new Mock<IUnitOfWork>();
            // Настройка моков при необходимости

            var service = new ContractsService(uowMock.Object, context);

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(() =>
                service.CreateContractAsync("NON_EXISTENT_FACILITY_CODE", "PET001", 10));
        }

        [Fact]
        public async Task CreateContractAsync_EquipmentNotFound_ThrowsInvalidOperationException()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb_EquipmentNotFound")
                .Options;

            using var context = new ApplicationDbContext(options);

            // Добавляем фабрику
            context.ProductionFacilities.Add(new ProductionFacility
            {
                Code = "PF001",
                Name = "Test Facility",
                StandardArea = 1000,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            });
            await context.SaveChangesAsync();

            var uowMock = new Mock<IUnitOfWork>();

            var service = new ContractsService(uowMock.Object, context);

            await Assert.ThrowsAsync<InvalidOperationException>(() =>
                service.CreateContractAsync("PF001", "NON_EXISTENT_EQUIP", 10));
        }

        [Fact]
        public async Task CreateContractAsync_NotEnoughArea_ThrowsInvalidOperationException()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb_NotEnoughArea")
                .Options;

            using var context = new ApplicationDbContext(options);

            // Добавляем фабрику
            var facility = new ProductionFacility
            {
                Code = "PF001",
                Name = "Test Facility",
                StandardArea = 1000,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
            context.ProductionFacilities.Add(facility);

            // Добавляем тип оборудования
            var equipment = new ProcessEquipmentType
            {
                Code = "PET001",
                Name = "Equip1",
                Area = 500,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
            context.ProcessEquipmentTypes.Add(equipment);

            // Добавляем один контракт, который уже занял почти всю площадь
            context.EquipmentPlacementContracts.Add(new EquipmentPlacementContract
            {
                ProductionFacilityId = facility.Id,
                ProcessEquipmentTypeId = equipment.Id,
                EquipmentQuantity = 2, // 2 * 500 = 1000
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            });

            await context.SaveChangesAsync();

            var uowMock = new Mock<IUnitOfWork>();

            // Мокаем репозиторий контрактов
            var contractRepoMock = new Mock<IEquipmentContractRepository>();
            uowMock.Setup(u => u.Contracts).Returns(contractRepoMock.Object);

            // Настраиваем CompleteAsync
            uowMock.Setup(u => u.CompleteAsync())
                   .ReturnsAsync(1);

            var service = new ContractsService(uowMock.Object, context);

            // Попытка добавить еще оборудование (например, 1 единицу)
            await Assert.ThrowsAsync<InvalidOperationException>(() =>
                service.CreateContractAsync("PF001", "PET001", 1));
        }

        [Fact]
        public async Task CreateContractAsync_Success_CreatesContract()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb_Success")
                .Options;

            using var context = new ApplicationDbContext(options);

            // Добавляем фабрику
            var facility = new ProductionFacility
            {
                Code = "PF001",
                Name = "Test Facility",
                StandardArea = 1000,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
            context.ProductionFacilities.Add(facility);

            // Добавляем тип оборудования
            var equipment = new ProcessEquipmentType
            {
                Code = "PET001",
                Name = "Equip1",
                Area = 100,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
            context.ProcessEquipmentTypes.Add(equipment);
            await context.SaveChangesAsync();

            var uowMock = new Mock<IUnitOfWork>();
            var contractRepoMock = new Mock<IEquipmentContractRepository>();

            // Проверяем, что AddAsync будет вызван
            contractRepoMock.Setup(r => r.AddAsync(It.IsAny<EquipmentPlacementContract>()))
                .Returns(Task.CompletedTask)
                .Verifiable();

            uowMock.Setup(u => u.Contracts).Returns(contractRepoMock.Object);
            uowMock.Setup(u => u.CompleteAsync()).ReturnsAsync(1);

            var service = new ContractsService(uowMock.Object, context);

            await service.CreateContractAsync("PF001", "PET001", 5);

            // Проверяем, что AddAsync был вызван с правильными параметрами
            contractRepoMock.Verify(r => r.AddAsync(It.Is<EquipmentPlacementContract>(c => 
                c.EquipmentQuantity == 5 &&
                c.ProcessEquipmentTypeId == equipment.Id &&
                c.ProductionFacilityId == facility.Id)), Times.Once);
        }

        [Fact]
        public async Task GetContractsAsync_ReturnsExpectedData()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb_GetContracts")
                .Options;

            using var context = new ApplicationDbContext(options);

            // Создадим фабрику и оборудование
            var facility = new ProductionFacility
            {
                Code = "PF001",
                Name = "Test Facility",
                StandardArea = 1000,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
            context.ProductionFacilities.Add(facility);

            var equipment = new ProcessEquipmentType
            {
                Code = "PET001",
                Name = "Equip1",
                Area = 100,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
            context.ProcessEquipmentTypes.Add(equipment);

            var contract = new EquipmentPlacementContract
            {
                ProductionFacilityId = facility.Id,
                ProcessEquipmentTypeId = equipment.Id,
                EquipmentQuantity = 10,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
            context.EquipmentPlacementContracts.Add(contract);
            await context.SaveChangesAsync();

            // Мокаем репозиторий контрактов, чтобы вернуть один контракт
            var uowMock = new Mock<IUnitOfWork>();
            var contractRepoMock = new Mock<IEquipmentContractRepository>();

            contractRepoMock.Setup(r => r.GetContractsWithDetailsAsync())
                .ReturnsAsync(new List<EquipmentPlacementContract> { 
                    contract 
                });

            uowMock.Setup(u => u.Contracts).Returns(contractRepoMock.Object);

            var service = new ContractsService(uowMock.Object, context);

            var result = await service.GetContractsAsync();

            var list = result.ToList();
            Assert.Single(list);

            var item = list.First();

            Assert.Equal("Test Facility", item.FacilityName);
            Assert.Equal("Equip1", item.EquipmentName);
            Assert.Equal(10, item.EquipmentQuantity);
        }
}
