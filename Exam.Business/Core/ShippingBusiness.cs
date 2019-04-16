using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Exam.Contract.Binding;
using Exam.Contract.Resource;
using Exam.Domain.Model;
using Exam.Exception.Core;
using Exam.Facet.Behavior;
using Exam.Mapper.Map;
using Exam.Repository.Aggregate;

namespace Exam.Business.Core
{
    public interface IShippingBusiness
    {
        IEnumerable<ProductResourceModel> GetAllProductByPredicate(Expression<Func<Product, bool>> predicate, int skip, int take);
        ProductResourceModel InsertProduct(ProductBindingModel productBindingModel);

       void UpdateProduct(ProductBindingModel productBindingModel);

       void DeleteProduct(Guid id);
    }
    public class ShippingBusiness:IShippingBusiness
    {
        private readonly ProductRepository _productRepository;

        public ShippingBusiness(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<ProductResourceModel> GetAllProductByPredicate(Expression<Func<Product, bool>> predicate, int skip, int take)
        {
            return _productRepository.GetAll(predicate).Skip(skip).Take(take).ToList().Select(x=>x.GetProductResourceModel());
        }
        [BindingModelValidation]
        public ProductResourceModel InsertProduct(ProductBindingModel productBindingModel)
        {
           return _productRepository.Insert(productBindingModel.GetProduct()).GetProductResourceModel();
        }
        [BindingModelValidation]
        public void UpdateProduct(ProductBindingModel productBindingModel)
        {
            _productRepository.Update(productBindingModel.GetProduct());
        }

        public void DeleteProduct(Guid id)
        {
            var product = _productRepository.Get(id);
            if (product is null )
                throw new ObjectNotFoundException("Item Not Found");
            _productRepository.Delete(product);
        }
    }
}
