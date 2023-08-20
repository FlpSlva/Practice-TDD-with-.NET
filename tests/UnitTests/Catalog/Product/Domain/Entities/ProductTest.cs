using Catalog.Domain.Exceptions;
using Xunit;
using DomainEntities = Catalog.Domain.Entities;

namespace UnitTests.Catalog.Product.Domain.Entities;
public class ProductTest
{
    [Fact(DisplayName = "ShouldInstantiate")]
    [Trait("Domain", "Product - Aggregates")]
    public void ShouldInstantiate()
    {
        var exampleProduct = new
        {
            Name = "name",
            Description = "description",

        };

        var dateTimeBefore = DateTime.Now;
        var product = new DomainEntities.Product(exampleProduct.Name, exampleProduct.Description);
        var dateTimeAfter = DateTime.Now.AddSeconds(2);

        Assert.NotNull(product);
        Assert.Equal(exampleProduct.Name, product.Name);
        Assert.Equal(exampleProduct.Description, product.Description);
        Assert.NotEqual(default(Guid), product.Id);
        Assert.NotEqual(default(DateTime), product.CreatedAt);
        Assert.True(product.CreatedAt > dateTimeBefore);
        Assert.True(product.CreatedAt < dateTimeAfter);
        Assert.True(product.IsActive);
        
    }

    [Theory(DisplayName = "InstantiateWithIsActive")]
    [Trait("Domain", "Product - Aggregates")]
    [InlineData(true)]
    [InlineData(false)]
    public void InstantiateWithIsActive(bool isActive)
    {
        var exampleProduct = new
        {
            Name = "name",
            Description = "description",

        };

        var dateTimeBefore = DateTime.Now;
        var product = new DomainEntities.Product(exampleProduct.Name, exampleProduct.Description, isActive);
        var dateTimeAfter = DateTime.Now.AddSeconds(2);

        Assert.NotNull(product);
        Assert.Equal(exampleProduct.Name, product.Name);
        Assert.Equal(exampleProduct.Description, product.Description);
        Assert.NotEqual(default(Guid), product.Id);
        Assert.NotEqual(default(DateTime), product.CreatedAt);
        Assert.True(product.CreatedAt > dateTimeBefore);
        Assert.True(product.CreatedAt < dateTimeAfter);
        Assert.Equal(isActive, product.IsActive);

    }

    [Theory(DisplayName = "ThrowErrorWhenNameIsEmpty")]
    [Trait("Domain", "Product - Aggregates")]
    [InlineData("")]
    [InlineData(null)]
    [InlineData("   ")]
    public void ThrowErrorWhenNameIsEmpty(string? name)
    {
        Action action = () =>
            new DomainEntities.Product(name, "Product Description!");

        var exceptions = Assert.Throws<EntityValidationException>(action);
        Assert.Equal("Name should not be empty or null", exceptions.Message);
    }

    [Fact(DisplayName = "ThrowErroWhenDescriptionIsNull")]
    [Trait("Domain", "Product - Aggregates")]
    public void ThrowErroWhenDescriptionIsNull()
    {
        Action action = () =>
                new DomainEntities.Product("Name Product", null!);

        var exceptions = Assert.Throws<EntityValidationException>(action);
        Assert.Equal("Description should not be null", exceptions.Message);
    }

}
