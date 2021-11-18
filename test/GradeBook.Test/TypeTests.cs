using System;
using Xunit;

namespace GradeBook.Test
{
    public delegate string WriteLogDelegate(string logMessage);

    public class TypeTests
    {
        int count = 0;

        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
            WriteLogDelegate log = ReturnMessage;
            log += ReturnMessage;
            log += IncrementCount;

            var result = log("Hello");

            Assert.Equal("hello", result);
            Assert.Equal(3, count);
        }

        private string IncrementCount(string message)
        {
            count++;
            return message.ToLower();
        }

        private string ReturnMessage(string message)
        {
            count++;
            return message;
        }

        [Fact]
        public void StringsBehaveLikeValueTypes()
        {
            string name = "Simon";
            MakeUppercase(name);
            string upper = MakeUppercase(name);

            // This is because string methods return copies
            Assert.Equal("Simon", name);
            Assert.Equal("SIMON", upper);
        }

        private string MakeUppercase(string parameter)
        {
            return parameter.ToUpper();
        }

        [Fact]
        public void ValueTypeCanPassByRef()
        {
            var x = GetInt();
            SetInt(ref x);

            Assert.Equal(42, x);
        }
        [Fact]
        public void ValueTypesArePassByValue()
        {
            var x = GetInt();
            SetInt(x);

            Assert.Equal(3, x);
        }
        private void SetInt(ref int x)
        {
            x = 42;
        }
        private void SetInt(int x)
        {
            x = 42;
        }

        private int GetInt()
        {
            return 3;
        }

        [Fact]
        public void CSharpCanPassByRef()
        {
            var book1 = new InMemoryBook("Book 1");
            GetBookSetName(ref book1, "New Name");

            Assert.Equal("New Name", book1.Name);
        }

        private void GetBookSetName(ref InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
        }

        [Fact]
        public void CSharpIsPassByValue()
        {
            var book1 = new InMemoryBook("Book 1");
            GetBookSetName(book1, "New Name");

            Assert.Equal("Book 1", book1.Name);
        }

        private void GetBookSetName(InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
        }

        [Fact]
        public void TwoVariablesCanRefernceSameObject()
        {
            var book1 = GetBook("Book 1");
            var book2 = book1;

            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2));
        }

        InMemoryBook GetBook(string name)
        {
            return new InMemoryBook(name);
        }
    }
}