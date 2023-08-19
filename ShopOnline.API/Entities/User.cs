using System.ComponentModel.DataAnnotations.Schema;

namespace ShopOnline.API.Entities;

[Table("Users")]
public class User
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public Cart Cart { get; set; }
}
