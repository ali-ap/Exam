using Exam.Contract.Binding;
using Exam.Contract.Resource;
using Exam.Domain.Model;

namespace Exam.Mapper.Map
{
    public static class ProductMapper
    {
        public static ProductResourceModel GetProductResourceModel(this Product product)
        {
            return AutoMapper.Mapper.Map<Product, ProductResourceModel>(product);
        }
        public static Product GetProduct(this ProductBindingModel productBindingModel)
        {
            return AutoMapper.Mapper.Map<ProductBindingModel, Product>(productBindingModel);
        }
    }
}
