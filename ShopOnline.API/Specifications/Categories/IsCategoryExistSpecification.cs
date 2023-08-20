namespace ShopOnline.API.Specifications.Categories;

public sealed class IsCategoryExistSpecification<TEntity> : Specification<TEntity> where TEntity : Category
{
    public IsCategoryExistSpecification(int categoryId)
        : base(c => c.Id == categoryId)
    {

    }
}
