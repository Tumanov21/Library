using AutoFixture;
using AutoMapper;
using Library.Core.Books.Commands.Update;
using Library.Infastructure.Persistence.Repositories.Command.Interface;
using Library.Infrastructure.Persistence.Dtos.BookDtos;
using Library.Infrastructure.Persistence.Mapping;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Tests.BookTest
{
    public class UpdateBookTest
    {
        private readonly Mock<IBookRepositoryCommand> _mockBookRepositoryCommand = new();
        private readonly UpdateBookCommandHandler _handler;
        private readonly Fixture _fixture = new();
        private readonly IMapper _mapper;

        public UpdateBookTest()
        {
            var mapperConfig = new MapperConfiguration(_ => _.AddProfile<BookProfile>());
            _mapper = mapperConfig.CreateMapper();

            _mockBookRepositoryCommand = new Mock<IBookRepositoryCommand>();
            _handler = new UpdateBookCommandHandler(_mockBookRepositoryCommand.Object);
            _fixture = new Fixture();
        }

        [Fact]
        public async Task Create_AddBookDto_ReturnIsTrue()
        {
            var book = _fixture.Create<UpdateBookDto>();
            _mockBookRepositoryCommand.Setup(_ => _.Update(It.IsAny<UpdateBookDto>())).ReturnsAsync(true);

            var result = await _handler.Handle(new UpdateBookCommand.Request { UpdateBookDto = book }, CancellationToken.None);

            Assert.True(result.Success);
            _mockBookRepositoryCommand.Verify(_ => _.Update(It.IsAny<UpdateBookDto>()), Times.Once);
        }

        [Fact]
        public async Task Create_Null_ReturnArgumentNullException()
        {
            _mockBookRepositoryCommand.Setup(_ => _.Update(It.IsAny<UpdateBookDto>())).ReturnsAsync(true);

            var exception = await Assert.ThrowsAsync<ArgumentNullException>(() => _handler.Handle(new UpdateBookCommand.Request { UpdateBookDto = null }, CancellationToken.None));

            Assert.NotNull(exception);
            _mockBookRepositoryCommand.Verify(_ => _.Update(It.IsAny<UpdateBookDto>()), Times.Never);
        }
    }
}
