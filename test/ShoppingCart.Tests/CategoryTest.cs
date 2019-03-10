using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Xunit;

namespace ShoppingCart.Tests
{

    public class CategoryTest
    {
        [Fact]
        public void Ctor_ShouldCreate()
        {
            var arrange = new Category("electronic");
            arrange.Title.Should().BeEquivalentTo("electronic");
        }
        [Fact]
        public void Ctor_when_title_null_or_empty_throw_exception()
        {
            Action action = () => new Category("");
            action.Should().Throw<Exception>().WithMessage("Category title must be fill.");
        }
    }
}
