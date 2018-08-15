using System.Runtime.Serialization;

namespace ForSprinterra.Models.ProductModels
{
    public class ProductSingle
    {
        [DataMember(Name = "data")]
        public Product data { get; set; }
    }
}