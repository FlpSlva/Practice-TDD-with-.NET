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

        var product = new DomainEntities.Product(exampleProduct.Name, exampleProduct.Description);

        Assert.NotNull(product);
        Assert.Equal(exampleProduct.Name, product.Name);
        Assert.Equal(exampleProduct.Description, product.Description);
    }
}
