using System;
using System.Linq;
using System.Xml;
using Exam.Context.Base;
using Exam.Context.Boundary;
using Exam.Domain.Model;
using Exam.Exception.Core;
using Exam.Repository.Aggregate;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Exam.UnitTest.Repository
{
    public class ProductRepositoryShould
    {
        public ProductRepository ProductRepository { get; set; }
        [SetUp]
        public void Setup()
        {
            ProductRepository = new ProductRepository(new ShippingBoundedContext());
        }

        [Test]
        public void Product_Insert_Successfully()
        {
            Assert.DoesNotThrow(() =>
            {
                var affectedRows = ProductRepository.Insert(new Product()
                {
                    Id = Guid.NewGuid(),
                    StockKeepingUnit = $"sku_{Guid.NewGuid()}",
                    Name = "Product1",
                    Description = "Product one",
                    Quantity = 10
                });
            });
        }

        [Test]
        public void Product_GetAll_Successfully()
        {
            Assert.DoesNotThrow(() =>
            {
                var affectedRows = ProductRepository.GetAll(x => true).ToList();
            });
        }

        [Test]
        public void Product_Delete_Successfully()
        {
            var fetchForDeleteObject = ProductRepository.GetAll(x=>true).FirstOrDefault();
            if (fetchForDeleteObject != null)
            {
                Assert.DoesNotThrow(() =>
                {
                    ProductRepository.Delete(fetchForDeleteObject);
                });
            }

        }

        [Test]
        public void Product_Update_Successfully()
        {
            var fetchForUpdateObject = ProductRepository.GetAll().FirstOrDefault();
            if (fetchForUpdateObject != null)
            {
                Assert.DoesNotThrow(() =>
                {
                    fetchForUpdateObject.Name = $"{fetchForUpdateObject.Name} - test";
                    ProductRepository.Update(fetchForUpdateObject);
                });
            }

        }

        [Test]
        public void Product_Update_Throw_Update_Lost_Exception_If_RowVersion_Mismatch()
        {
            var fetchForUpdateObject = ProductRepository.GetAll(x=>true).AsNoTracking().FirstOrDefault();
            if (fetchForUpdateObject != null)
            {

                fetchForUpdateObject.Name = $"{fetchForUpdateObject.Name} - test";
                ProductRepository.Update(fetchForUpdateObject);

                Assert.Throws<UpdateLostException>(() =>
                {
                    fetchForUpdateObject.Name = $"{fetchForUpdateObject.Name} - test";
                    ProductRepository.Update(fetchForUpdateObject);
                });
            }

        }
    }
}