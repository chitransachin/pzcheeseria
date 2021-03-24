using AutoMapper;
using Cheeseria.Api.Database.Models;
using Cheeseria.Api.Database.Repositories;
using Cheeseria.Api.Dto;
using Cheeseria.Api.Handlers;
using Cheeseria.Api.Tests.Helpers;
using Moq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Cheeseria.Api.Tests
{
	public class CheeseApiGetHandlerTests
	{
		//Test 1: Get all cheese in the store

		//Test 2: Get top cheese based on quality rating

		//Test 3: Get cheese by Id

		//Test 4: Try getting a Cheese by Id that does not exist

		private Mock<ICheeseRepository> mockRepository;
		private Mock<IMapper> mockMapper;
		public CheeseApiGetHandlerTests()
		{
			mockRepository = new Mock<ICheeseRepository>();
			mockMapper = new Mock<IMapper>();
		}

		private GetCheeseHandler _sut;

		[Fact]
		public async Task GetCheeseHandler_FindACheeseById()
		{
			//Arrange
			var cheeseRequest = GetCheeseHandlerHelper.CreateGetRequest("first cheese", 101);
			var expectedEntity = GetCheeseHandlerHelper.GetCheeseEntity(100, 4);

			mockRepository.Setup(r => r.GetCheese(It.IsAny<int>(), It.IsAny<CancellationToken>())).ReturnsAsync(expectedEntity);
			mockMapper.Setup(m => m.Map<GetCheeseResponse>(It.IsAny<CheeseEntity>())).Returns(new GetCheeseResponse
			{
				AnimalSource = expectedEntity.AnimalSource,
				Aroma = expectedEntity.Aroma,
				Id = expectedEntity.Id,
				PricePerKilo = expectedEntity.PricePerKilo,
				QualityScore = expectedEntity.QualityScore

			});

			_sut = new GetCheeseHandler(mockRepository.Object, mockMapper.Object);

			//Act
			var actual = await _sut.ProcessAsync(cheeseRequest, new CancellationToken());
			
			//Assert
			Assert.IsAssignableFrom<IEnumerable<GetCheeseResponse>>(actual);
			mockRepository.Verify(r => r.GetCheese(It.IsAny<int>(), It.IsAny<CancellationToken>()), Times.Once);
			mockMapper.Verify(m => m.Map<GetCheeseResponse>(It.IsAny<CheeseEntity>()), Times.Once);

			Assert.Equal(actual.First().Id, expectedEntity.Id);
		}

		[Fact]
		public async Task GetCheeseHandler_FindAllCheese()
		{
			//Arrange
			var cheeseRequest = GetCheeseHandlerHelper.CreateGetRequest("all cheese", 0);
			var expectedCheeseCollection = GetCheeseHandlerHelper.GetCheeseCollection();
			var expectedCheeseResponseCollection = GetCheeseHandlerHelper.GetCheeseResponseCollection();

			mockRepository.Setup(r => r.GetCheeseCollection(It.IsAny<CancellationToken>())).ReturnsAsync(expectedCheeseCollection);
			mockMapper.Setup(m => m.Map<IEnumerable<GetCheeseResponse>>(It.IsAny<IEnumerable<CheeseEntity>>())).Returns(expectedCheeseResponseCollection);

			_sut = new GetCheeseHandler(mockRepository.Object, mockMapper.Object);

			//Act
			var actual = await _sut.ProcessAsync(cheeseRequest, new CancellationToken());

			//Assert
			Assert.IsAssignableFrom<IEnumerable<GetCheeseResponse>>(actual);
			mockRepository.Verify(r => r.GetCheeseCollection(It.IsAny<CancellationToken>()), Times.Once);
			mockMapper.Verify(m => m.Map<IEnumerable<GetCheeseResponse>>(It.IsAny<IEnumerable<CheeseEntity>>()), Times.Once);
			Assert.Equal(expectedCheeseResponseCollection, actual);
		}

		[Fact]
		public async Task GetCheeseHandler_TryFindingACheeseThatDoesNotExist()
		{
			//Arrange
			var cheeseRequest = GetCheeseHandlerHelper.CreateGetRequest("invalid cheese", 700);

			mockRepository.Setup(r => r.GetCheese(It.IsAny<int>(), It.IsAny<CancellationToken>())).ReturnsAsync(new CheeseEntity());
			mockMapper.Setup(m => m.Map<GetCheeseResponse>(It.IsAny<CheeseEntity>())).Returns(new GetCheeseResponse());

			_sut = new GetCheeseHandler(mockRepository.Object, mockMapper.Object);

			//Act
			var actual = await _sut.ProcessAsync(cheeseRequest, new CancellationToken());

			//Assert
			Assert.IsAssignableFrom<IEnumerable<GetCheeseResponse>>(actual);
			mockRepository.Verify(r => r.GetCheeseCollection(It.IsAny<CancellationToken>()), Times.Never);
			mockMapper.Verify(m => m.Map<IEnumerable<GetCheeseResponse>>(It.IsAny<IEnumerable<CheeseEntity>>()), Times.Never);

			mockRepository.Verify(r => r.GetCheese(It.IsAny<int>(), It.IsAny<CancellationToken>()), Times.Once);
			mockRepository.Verify(r => r.GetCheese(It.IsAny<int>(), It.IsAny<CancellationToken>()), Times.Once);

			Assert.True(actual.First().Id == 0, "Expected empty item in collection which is not the case");
		}

	}
}
