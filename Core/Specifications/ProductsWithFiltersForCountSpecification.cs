using Core.Entities;

namespace Core.Specifications {
    public class ProductsWithFiltersForCountSpecification : BaseSpecification<Product> {
        public ProductsWithFiltersForCountSpecification(ProductSpecParams productParams)  : base(x =>
            (string.IsNullOrEmpty(productParams.Search) || x.Name.ToLower().Contains(productParams.Search)) &&
            (!productParams.BrandID.HasValue || x.ProductBrandId == productParams.BrandID) &&
            (!productParams.TypeID.HasValue || x.ProductTypeId == productParams.TypeID)) {   
        }
    }
}