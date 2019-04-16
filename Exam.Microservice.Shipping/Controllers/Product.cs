using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exam.Business.Core;
using Exam.Contract.Binding;
using Exam.Contract.Resource;
using Exam.Microservice.Shipping.Infrastructure.Base;
using Microsoft.AspNetCore.Mvc;

namespace Exam.Microservice.Shipping.Controllers
{
    public class Product : FrameworkController
    {
        private readonly IShippingBusiness _shippingBusiness;

        public Product(IShippingBusiness shippingBusiness)
        {
            _shippingBusiness = shippingBusiness;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProductResourceModel>> Get(int skip = 0, int take = 10)
        {
            return Ok(_shippingBusiness.GetAllProductByPredicate((x => true), skip, take));
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var result = _shippingBusiness.GetAllProductByPredicate((x => x.Id == id), 0, 1);
            if (!result.Any())
                return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ProductBindingModel productBindingModel)
        {
            var result = _shippingBusiness.InsertProduct(productBindingModel);
            return CreatedAtRoute("/Product", result);
        }

        [HttpPut()]
        public IActionResult Put([FromBody] ProductBindingModel productBindingModel)
        {
            _shippingBusiness.UpdateProduct(productBindingModel);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _shippingBusiness.DeleteProduct(id);
            return NoContent();
        }
    }
}
