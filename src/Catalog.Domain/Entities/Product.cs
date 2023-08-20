namespace Catalog.Domain.Entities;
public class Product
{
    public Product(string name, string description)
    {
        Id = Guid.NewGuid();
        IsActive = true;
        Name = name;
        Description = description;
        CreatedAt = DateTime.Now;
    }
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public bool IsActive { get; private set; }
}
