using AutoFixture;
using AutoMapper;
using Library.Core.Categories.Queries.GetAll;
using Library.Infastructure.Persistence.Repositories.Query.Interface;
using Library.Infrastructure.Persistence.Dtos.CategoryDtos;
using Library.Infrastructure.Persistence.Mapping;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Tests.CategoryTest
{
    public class GetAllCategoryTest
    {
        private readonly Mock<ICategoryRepositoryQuery> _mockBookRepositoryCommand = new();
        private readonly GetAllCategoryQueryHandler _handler;
        private readonly Fixture _fixture = new();
        private readonly IMapper _mapper;

        public GetAllCategoryTest()
        {
            var mapperConfig = new MapperConfiguration(_ => _.AddProfile<CategoryProfile>());
            _mapper = mapperConfig.CreateMapper();

            _mockBookRepositoryCommand = new Mock<ICategoryRepositoryQuery>();
            _handler = new GetAllCategoryQueryHandler(_mockBookRepositoryCommand.Object);
            _fixture = new Fixture();
        }

        [Fact]
        public async Task GetAll_ReturnCollectionGetBookDto()
        {
            var books = _fixture.CreateMany<GetCategoryDto>(3).ToList();
            _mockBookRepositoryCommand.Setup(_ => _.GetAll()).ReturnsAsync(books);

            var result = await _handler.Handle(new GetAllCategoryQuery.Request(), CancellationToken.None);

            Assert.NotNull(result);
            Assert.Equal(3, books.Count);
            Assert.IsType<List<GetCategoryDto>>(result.Categories);
            _mockBookRepositoryCommand.Verify(_ => _.GetAll(), Times.Once);
        }

        [Fact]
        public async Task GetAll_ReturnEmpty()
        {
            var books = _fixture.CreateMany<GetCategoryDto>(0).ToList();
            _mockBookRepositoryCommand.Setup(_ => _.GetAll()).ReturnsAsync(books);

            var result = await _handler.Handle(new GetAllCategoryQuery.Request(), CancellationToken.None);

            Assert.Empty(result.Categories);
            Assert.Equal(0, books.Count);
            _mockBookRepositoryCommand.Verify(_ => _.GetAll(), Times.Once);
        }
    }
}
