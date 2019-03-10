using FluentAssertions;
using Xunit;

namespace ShoppingCart.Tests
{
    public class ProductTest
    {
        [Fact]
        public void Ctor_ShouldCreate()
        {
            var arrange = new Product("product", 10.0, new Category("category"));
            var act = new Product("product", 10.0, new Category("category"));
            arrange.Title.Should().BeEquivalentTo(act.Title, "Not Expected");
            arrange.Price.Should().Be(act.Price, "Not Expected");
            arrange.Category.Title.Should().BeEquivalentTo(act.Category.Title,"NotExpected");
        }
    }
}