using AutoFixture;
using AutoMapper;
using Library.Core.Books.Queries.GetById;
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
    public class GetByIdBookTest
    {
        private readonly Mock<IBookRepositoryQuery> _mockBookRepositoryCommand = new();
        private readonly GetByIdBookQueryHandler _handler;
        private readonly Fixture _fixture = new();
        private readonly IMapper _mapper;

        public GetByIdBookTest()
        {
            var mapperConfig = new MapperConfiguration(_ => _.AddProfile<BookProfile>());
            _mapper = mapperConfig.CreateMapper();

            _mockBookRepositoryCommand = new Mock<IBookRepositoryQuery>();
            _handler = new GetByIdBookQueryHandler(_mockBookRepositoryCommand.Object);
            _fixture = new Fixture();
        }

        [Fact]
        public async Task GetById_Id_ReturnGetBookDto()
        {
            var id = 1;
            _mockBookRepositoryCommand.Setup(_ => _.GetById(It.IsAny<int>())).ReturnsAsync(new GetBookDto());

            var result = await _handler.Handle(new GetByIdBookQuery.Request() { Id = id }, CancellationToken.None);

            Assert.NotNull(result);
            Assert.IsType<GetBookDto>(result.Book);
            _mockBookRepositoryCommand.Verify(_ => _.GetById(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public async Task GeById_IdEqual0OrNegativeNumber_ReturnException()
        {
            var id = -1;
            _mockBookRepositoryCommand.Setup(_ => _.GetById(It.IsAny<int>())).ReturnsAsync(new GetBookDto());

            var result = await _handler.Handle(new GetByIdBookQuery.Request() { Id = id }, CancellationToken.None);

            Assert.Null(result.Book);
            _mockBookRepositoryCommand.Verify(_ => _.GetById(It.IsAny<int>()), Times.Never);
        }
    }
}
