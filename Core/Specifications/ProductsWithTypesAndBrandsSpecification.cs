using DotnetEcommerce.Core.Entities;

namespace DotnetEcommerce.Core.Specifications
{
    public class ProductsWithTypesAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductsWithTypesAndBrandsSpecification(ProductSpecParams prodParams) 
        : base(x => 
            (string.IsNullOrEmpty(prodParams.Search) || x.Name.ToLower().Contains(prodParams.Search))&&
            (!prodParams.BrandId.HasValue || x.ProductBrandId == prodParams.BrandId) &&
            (!prodParams.TypeId.HasValue || x.ProductTypeId == prodParams.TypeId))
        
        {
            AddIncludes(x => x.ProductType);
            AddIncludes(x => x.ProductBrand);
            AddOrderBy(x => x.Name);
            ApplyPagination(prodParams.PageSize * (prodParams.PageNumber -1), prodParams.PageSize);

            if (!string.IsNullOrEmpty(prodParams.Sort))
            {
                switch (prodParams.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(p=> p.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(p=>p.Price);
                        break;
                    default:
                        AddOrderBy(x => x.Name);
                        break;
                }
            }
        }

        public ProductsWithTypesAndBrandsSpecification(int id): base(x => x.Id==id)
        {
            AddIncludes(x => x.ProductType);
            AddIncludes(x => x.ProductBrand);
        }
    }
}
