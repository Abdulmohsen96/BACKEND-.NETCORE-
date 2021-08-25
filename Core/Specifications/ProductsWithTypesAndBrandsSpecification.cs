using Core.Entities;

namespace Core.Specifications {
    public class ProductsWithTypesAndBrandsSpecification : BaseSpecification<Product> {
        public ProductsWithTypesAndBrandsSpecification(ProductSpecParams productParams) :  base(x => 
            (string.IsNullOrEmpty(productParams.Search) || x.Name.ToLower().Contains(productParams.Search)) &&
            (!productParams.BrandID.HasValue || x.ProductBrandId == productParams.BrandID) && 
            (!productParams.TypeID.HasValue || x.ProductTypeId == productParams.TypeID)) {
                          
            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductType);
            AddOrderBy(x => x.Name);
            ApplyPaging(productParams.PageSize, productParams.PageSize * (productParams.PageIndex - 1));

            if(!string.IsNullOrEmpty(productParams.Sort)) {
                switch(productParams.Sort) {
                    case "priceAsc": AddOrderBy(p => p.Price);
                        break;
                    case "priceDesc": AddOrderByDescending(p => p.Price);
                        break;
                    default: AddOrderBy(n => n.Name);
                        break;
                }
            }
        }

        public ProductsWithTypesAndBrandsSpecification(int id) : base(x => x.Id == id) {
            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductType);
        }
    }
}