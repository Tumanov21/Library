using AutoFixture;
using AutoMapper;
using Library.Core.Categories.Commands.Remove;
using Library.Infastructure.Persistence.Repositories.Command.Interface;
using Library.Infrastructure.Persistence.Mapping;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Tests.CategoryTest
{
    public class DeleteCategoryTest
    {
        private readonly Mock<ICategoryRepositoryCommand> _mockBookRepositoryCommand = new();
        private readonly RemoveCategoryCommandHandler _handler;
        private readonly Fixture _fixture = new();
        private readonly IMapper _mapper;

        public DeleteCategoryTest()
        {
            var mapperConfig = new MapperConfiguration(_ => _.AddProfile<CategoryProfile>());
            _mapper = mapperConfig.CreateMapper();

            _mockBookRepositoryCommand = new Mock<ICategoryRepositoryCommand>();
            _handler = new RemoveCategoryCommandHandler(_mockBookRepositoryCommand.Object);
            _fixture = new Fixture();
        }

        [Fact]
        public async Task GetById_Id_ReturnGetBookDto()
        {
            var id = 1;
            _mockBookRepositoryCommand.Setup(_ => _.Remove(It.IsAny<int>())).ReturnsAsync(true);

            var result = await _handler.Handle(new RemoveCategoryCommand.Request() { Id = id }, CancellationToken.None);

            Assert.True(result.Success);
            _mockBookRepositoryCommand.Verify(_ => _.Remove(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public async Task GeById_IdEqual0OrNegativeNumber_ReturnException()
        {
            var id = -1;
            _mockBookRepositoryCommand.Setup(_ => _.Remove(It.IsAny<int>())).ReturnsAsync(true);

            var result = await _handler.Handle(new RemoveCategoryCommand.Request() { Id = id }, CancellationToken.None);

            Assert.False(result.Success);
            _mockBookRepositoryCommand.Verify(_ => _.Remove(It.IsAny<int>()), Times.Never);
        }
    }
}
