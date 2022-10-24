using Library.Infastructure.Persistence.Repositories.Command.Interface;
using Moq;

namespace Library.Core.Tests
{
    public class BookServiceTests
    {
        //unit test name patterns
        //MethodName_Conditions_Result
        [Fact]
        public void Create_ShouldCreate()
        {
            // arrange
            var bookRepository = new Mock<IBookRepositoryCommand>();

            // act


            // assert

        }
    }
}