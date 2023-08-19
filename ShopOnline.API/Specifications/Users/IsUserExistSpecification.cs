namespace ShopOnline.API.Specifications.Users;

public sealed class IsUserExistSpecification<TEntity> : Specification<TEntity> where TEntity : User
{
    public IsUserExistSpecification(int id) : base(u => u.Id == id) { }
}
