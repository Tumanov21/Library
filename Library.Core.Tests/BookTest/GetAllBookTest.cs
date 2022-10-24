using AutoFixture;
using AutoMapper;
using Library.Core.Books.Queries.GetAll;
using Library.Infastructure.Persistence.Repositories.Query.Interface;
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
    public class GetAllBookTest
    {
        private readonly Mock<IBookRepositoryQuery> _mockBookRepositoryCommand = new();
        private readonly GetAllBookQueryHandler _handler;
        private readonly Fixture _fixture = new();
        private readonly IMapper _mapper;

        public GetAllBookTest()
        {
            var mapperConfig = new MapperConfiguration(_ => _.AddProfile<BookProfile>());
            _mapper = mapperConfig.CreateMapper();

            _mockBookRepositoryCommand = new Mock<IBookRepositoryQuery>();
            _handler = new GetAllBookQueryHandler(_mockBookRepositoryCommand.Object);
            _fixture = new Fixture();
        }

        [Fact]
        public async Task GetAll_ReturnCollectionGetBookDto()
        {
            var books = _fixture.CreateMany<GetBookDto>(3).ToList();
            _mockBookRepositoryCommand.Setup(_ => _.GetAll()).ReturnsAsync(books);

            var result = await _handler.Handle(new GetAllBookQuery.Request(), CancellationToken.None);

            Assert.NotNull(result);
            Assert.Equal(3, books.Count);
            Assert.IsType<List<GetBookDto>>(result.Books);
            _mockBookRepositoryCommand.Verify(_ => _.GetAll(), Times.Once);
        }

        [Fact]
        public async Task GetAll_ReturnEmpty()
        {
            var books = _fixture.CreateMany<GetBookDto>(0).ToList();
            _mockBookRepositoryCommand.Setup(_ => _.GetAll()).ReturnsAsync(books);

            var result = await _handler.Handle(new GetAllBookQuery.Request(), CancellationToken.None);

            Assert.Empty(result.Books);
            Assert.Equal(0, books.Count);
            _mockBookRepositoryCommand.Verify(_ => _.GetAll(), Times.Once);
        }
    }
}
