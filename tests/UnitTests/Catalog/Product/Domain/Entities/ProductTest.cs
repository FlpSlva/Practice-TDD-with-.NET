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
}
