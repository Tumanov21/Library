using AutoFixture;
using AutoMapper;
using FluentValidation;
using FluentValidation.TestHelper;
using Library.Core.Books.Commands.Create;
using Library.Infastructure.Persistence.Repositories.Command.Interface;
using Library.Infrastructure.Persistence.Dto.BookDto;
using Library.Infrastructure.Persistence.Mapping;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Tests.BookTest
{
    public class CreateBookTest
    {
        private readonly Mock<IBookRepositoryCommand> _mockBookRepositoryCommand = new();
        private readonly CreateBookCommandHandler _handler;
        private readonly Fixture _fixture = new();
        private readonly IMapper _mapper;

        public CreateBookTest()
        {
            var mapperConfig = new MapperConfiguration(_ => _.AddProfile<BookProfile>());
            _mapper = mapperConfig.CreateMapper();

            _mockBookRepositoryCommand = new Mock<IBookRepositoryCommand>();
            _handler = new CreateBookCommandHandler(_mockBookRepositoryCommand.Object);
            _fixture = new Fixture();
        }

        [Fact]
        public async Task Create_AddBookDto_ReturnIsTrue()
        {
            var book = _fixture.Create<AddBookDto>();
            _mockBookRepositoryCommand.Setup(_ => _.Add(It.IsAny<AddBookDto>())).ReturnsAsync(true);

            var result = await _handler.Handle(new CreateBookCommand.Request { AddBookDto = book }, CancellationToken.None);

            Assert.True(result.Success);
            _mockBookRepositoryCommand.Verify(_ => _.Add(It.IsAny<AddBookDto>()), Times.Once);
        }

        [Fact]
        public async Task Create_Null_ReturnArgumentNullException()
        {
            _mockBookRepositoryCommand.Setup(_ => _.Add(It.IsAny<AddBookDto>())).ReturnsAsync(true);

            var exception = await Assert.ThrowsAsync<ArgumentNullException>(() => _handler.Handle(new CreateBookCommand.Request { AddBookDto = null }, CancellationToken.None));

            Assert.NotNull(exception);
            _mockBookRepositoryCommand.Verify(_ => _.Add(It.IsAny<AddBookDto>()), Times.Never);
        }

        //[Fact]
        //[Theory]
        //[InlineData("   ")]
        //[InlineData("")]
        //[InlineData(null)]
        //public async Task test(string testing)
        //{
        //    var book = new AddBookDto() { Title = testing };
        //    var validator = new CreateBookCommandValidator();

        //    var result = validator.(book);
        //}
    }
}
