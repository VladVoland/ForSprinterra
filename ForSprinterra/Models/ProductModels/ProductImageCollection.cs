using System.Runtime.Serialization;
using System.Collections.Generic;

namespace ForSprinterra.Models.ProductModels
{
    [DataContract]
    public class ProductImageCollection
    {
        [DataMember(Name = "data")]
        public List<ProductImage> images { get; set; }
    }
}