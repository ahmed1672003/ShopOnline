namespace ShopOnline.Services.Constants;

public class Urls
{
    public const string baseUrl = "https://localhost:7096/api/v1/";
    public class Product
    {
        public const string RetrieveAllProductsUrl = "Products/get-all-products";
        public const string RetrieveProductByIdUrl = "Products/get-product-by-id?id=";
    }
}
