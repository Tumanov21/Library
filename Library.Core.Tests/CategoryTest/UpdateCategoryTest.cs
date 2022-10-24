using AutoFixture;
using AutoMapper;
using Library.Core.Categories.Commands.Update;
using Library.Infastructure.Persistence.Repositories.Command.Interface;
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
    public class UpdateCategoryTest
    {
        private readonly Mock<ICategoryRepositoryCommand> _mockBookRepositoryCommand = new();
        private readonly UpdateCategoryCommandHandler _handler;
        private readonly Fixture _fixture = new();
        private readonly IMapper _mapper;

        public UpdateCategoryTest()
        {
            var mapperConfig = new MapperConfiguration(_ => _.AddProfile<CategoryProfile>());
            _mapper = mapperConfig.CreateMapper();

            _mockBookRepositoryCommand = new Mock<ICategoryRepositoryCommand>();
            _handler = new UpdateCategoryCommandHandler(_mockBookRepositoryCommand.Object);
            _fixture = new Fixture();
        }

        [Fact]
        public async Task Create_AddBookDto_ReturnIsTrue()
        {
            var book = _fixture.Create<UpdateCategoryDto>();
            _mockBookRepositoryCommand.Setup(_ => _.Update(It.IsAny<UpdateCategoryDto>())).ReturnsAsync(true);

            var result = await _handler.Handle(new UpdateCategoryCommand.Request { UpdateCategoryDto = book }, CancellationToken.None);

            Assert.True(result.Success);
            _mockBookRepositoryCommand.Verify(_ => _.Update(It.IsAny<UpdateCategoryDto>()), Times.Once);
        }

        [Fact]
        public async Task Create_Null_ReturnArgumentNullException()
        {
            _mockBookRepositoryCommand.Setup(_ => _.Update(It.IsAny<UpdateCategoryDto>())).ReturnsAsync(true);

            var exception = await Assert.ThrowsAsync<ArgumentNullException>(() => _handler.Handle(new UpdateCategoryCommand.Request { UpdateCategoryDto = null }, CancellationToken.None));

            Assert.NotNull(exception);
            _mockBookRepositoryCommand.Verify(_ => _.Update(It.IsAny<UpdateCategoryDto>()), Times.Never);
        }
    }
}
