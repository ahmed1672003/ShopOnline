namespace ShopOnline.Services.Constants;

public static class Urls
{
    public const string baseUrl = "https://localhost:7096/api/v1/";
    public static class Products
    {
        public const string RetrieveAllProductsUrl = "Products/get-all-products";
        public const string RetrieveProductByIdUrl = "Products/get-product-by-id?id=";
        public const string RetrieveAllProductsByCategoryIdUrl = "Products/get-all-products-by-category-id?categoryId=";
    }
    public static class CartItems
    {
        public const string AddCartItemUrl = "CartItems/add-cart-item";
        public const string UpdateCartItemQtyUrl = "CartItems/update-cart-item-qty?id=";
        public const string GetUserItemsUrl = "CartItems/get-user-cart-items?userId=";
        public const string DeleteCartItemUrl = "CartItems/delete-cart-item-bt-id?id=";
    }

    public static class Categories
    {
        public const string RetrieveAllCategoriesUrl = "Categories/get-all-categories";
    }
}
