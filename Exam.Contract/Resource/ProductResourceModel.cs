namespace Exam.Contract.Resource
{
    public class ProductResourceModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Sku { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public string RowVersion { get; set; }
    }
}
