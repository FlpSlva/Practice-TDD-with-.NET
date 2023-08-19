namespace Catalog.Domain.Entities;
public class Product
{
    public Product(string name, string description)
    {
        Name = name;
        Description = description;
    }
    public string Name { get; private set; }
    public string Description { get; private set; }
}
