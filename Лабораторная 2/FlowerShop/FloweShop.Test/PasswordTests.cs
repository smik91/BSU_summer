using Moq;
using FloweShop.App.Data;
using Microsoft.EntityFrameworkCore;
using FloweShop.App;

namespace FloweShop.Test
{
    [TestFixture]
    public class PasswordTests
    {
        private Mock<AppDbContext> mockContext;
        private Form1 form;

        [SetUp]
        public void Setup()
        {
            mockContext = new Mock<AppDbContext>();
            form = new Form1(mockContext.Object);
        }

        [Test]
        public void ValidatePassword_ShouldReturnFalse_ForShortPassword()
        {
            var result = form.ValidatePassword("Abc12");
            Assert.IsFalse(result);
        }

        [Test]
        public void ValidatePassword_ShouldReturnTrue_ForValidPassword()
        {
            var result = form.ValidatePassword("Abcdef123");
            Assert.IsTrue(result);
        }

        private Mock<DbSet<T>> MockDbSet<T>(List<T> data) where T : class
        {
            var queryable = data.AsQueryable();
            var mockSet = new Mock<DbSet<T>>();
            mockSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
            mockSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
            mockSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            mockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(queryable.GetEnumerator());
            return mockSet;
        }
    }
}