using System.ComponentModel.DataAnnotations.Schema;

namespace ShopOnline.API.Entities;

[Table("CartItems")]
public class CartItem
{
    public int Id { get; set; }
    public int CartId { get; set; }
    public int ProductId { get; set; }
    public int Qty { get; set; }
}
