using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopOnline.API.Entities;

[Table("Carts")]
public class Cart
{
    [Key]
    public int Id { get; set; }
    public int UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public User User { get; set; }
    public IEnumerable<CartItem> CartItems { get; set; } = new HashSet<CartItem>();
}
