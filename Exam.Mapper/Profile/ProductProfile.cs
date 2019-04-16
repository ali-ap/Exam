using Exam.Contract.Binding;
using Exam.Contract.Resource;
using Exam.Domain.Model;
using Exam.Toolbox.Database;

namespace Exam.Mapper.Profile
{
    public class ProductProfile : AutoMapper.Profile
    {
        public ProductProfile()
        {
            CreateMap<Product,ProductResourceModel>()
                .ForMember(d=>d.Sku,s=>s.MapFrom(x=>x.StockKeepingUnit));
            CreateMap<ProductBindingModel, Product>()
                .ForMember(d=>d.StockKeepingUnit , s=>s.MapFrom(x=>x.Sku))
                .ForMember(o=>o.Id,d=>d.MapFrom(x=>x.Id==null? DatabaseGuidManager.GetInstance().GetGuid:x.Id));
        }
    }
}
