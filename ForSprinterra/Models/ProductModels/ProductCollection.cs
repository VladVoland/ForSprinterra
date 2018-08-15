using System.Runtime.Serialization;
using System.Collections.Generic;

namespace ForSprinterra.Models.ProductModels
{
    [DataContract]
    public class ProductCollection
    {
        [DataMember(Name = "data")]
        public List<Product> products { get; set; }
    }
}