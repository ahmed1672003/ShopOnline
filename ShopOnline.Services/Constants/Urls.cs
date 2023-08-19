namespace ShopOnline.Services.Constants;

public static class Urls
{
    public const string baseUrl = "https://localhost:7096/api/v1/";
    public static class Products
    {
        public const string RetrieveAllProductsUrl = "Products/get-all-products";
        public const string RetrieveProductByIdUrl = "Products/get-product-by-id?id=";
    }
    public static class CartItems
    {
        public const string AddCartItem = "CartItems/add-cart-item";
        public const string UpdateCartItemQty = "CartItems/update-cart-item-qty?id=";
        public const string GetUserItems = "CartItems/get-user-cart-items?userId=";
        public const string DeleteCartItem = "CartItems/delete-cart-item-bt-id?id=";
    }
}
