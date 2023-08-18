using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopOnline.API.Entities;

[Table("Categories")]
public class Category
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string IconCSS { get; set; }
    public IEnumerable<Product> Products { get; set; } = new HashSet<Product>();
}
