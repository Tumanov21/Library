using AutoFixture;
using AutoMapper;
using Library.Core.Books.Commands.Remove;
using Library.Core.Books.Commands.Update;
using Library.Infastructure.Persistence.Repositories.Command.Interface;
using Library.Infrastructure.Persistence.Mapping;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Tests.BookTest
{
    public class DeleteBookTest
    {
        private readonly Mock<IBookRepositoryCommand> _mockBookRepositoryCommand = new();
        private readonly RemoveBookCommandHandler _handler;
        private readonly Fixture _fixture = new();
        private readonly IMapper _mapper;

        public DeleteBookTest()
        {
            var mapperConfig = new MapperConfiguration(_ => _.AddProfile<BookProfile>());
            _mapper = mapperConfig.CreateMapper();

            _mockBookRepositoryCommand = new Mock<IBookRepositoryCommand>();
            _handler = new RemoveBookCommandHandler(_mockBookRepositoryCommand.Object);
            _fixture = new Fixture();
        }

        [Fact]
        public async Task GetById_Id_ReturnGetBookDto()
        {
            var id = 1;
            _mockBookRepositoryCommand.Setup(_ => _.Remove(It.IsAny<int>())).ReturnsAsync(true);

            var result = await _handler.Handle(new RemoveBookCommand.Request() { Id = id }, CancellationToken.None);

            Assert.True(result.Success);
            _mockBookRepositoryCommand.Verify(_ => _.Remove(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public async Task GeById_IdEqual0OrNegativeNumber_ReturnException()
        {
            var id = -1;
            _mockBookRepositoryCommand.Setup(_ => _.Remove(It.IsAny<int>())).ReturnsAsync(true);

            var result = await _handler.Handle(new RemoveBookCommand.Request() { Id = id }, CancellationToken.None);

            Assert.False(result.Success);
            _mockBookRepositoryCommand.Verify(_ => _.Remove(It.IsAny<int>()), Times.Never);
        }
    }
}
