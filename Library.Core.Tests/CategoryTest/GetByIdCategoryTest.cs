using AutoFixture;
using AutoMapper;
using Library.Core.Categories.Queries.GetById;
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
    public class GetByIdCategoryTest
    {
        private readonly Mock<ICategoryRepositoryQuery> _mockBookRepositoryCommand = new();
        private readonly GetByIdCategoryQueryHandler _handler;
        private readonly Fixture _fixture = new();
        private readonly IMapper _mapper;

        public GetByIdCategoryTest()
        {
            var mapperConfig = new MapperConfiguration(_ => _.AddProfile<CategoryProfile>());
            _mapper = mapperConfig.CreateMapper();

            _mockBookRepositoryCommand = new Mock<ICategoryRepositoryQuery>();
            _handler = new GetByIdCategoryQueryHandler(_mockBookRepositoryCommand.Object);
            _fixture = new Fixture();
        }

        [Fact]
        public async Task GetById_Id_ReturnGetBookDto()
        {
            var id = 1;
            _mockBookRepositoryCommand.Setup(_ => _.GetById(It.IsAny<int>())).ReturnsAsync(new GetCategoryDto());

            var result = await _handler.Handle(new GetByIdCategoryQuery.Request() { Id = id }, CancellationToken.None);

            Assert.NotNull(result);
            Assert.IsType<GetCategoryDto>(result.Category);
            _mockBookRepositoryCommand.Verify(_ => _.GetById(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public async Task GeById_IdEqual0OrNegativeNumber_ReturnException()
        {
            var id = -1;
            _mockBookRepositoryCommand.Setup(_ => _.GetById(It.IsAny<int>())).ReturnsAsync(new GetCategoryDto());

            var result = await _handler.Handle(new GetByIdCategoryQuery.Request() { Id = id }, CancellationToken.None);

            Assert.Null(result.Category);
            _mockBookRepositoryCommand.Verify(_ => _.GetById(It.IsAny<int>()), Times.Never);
        }
    }
}
