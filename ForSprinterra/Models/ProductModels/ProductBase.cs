using System.Runtime.Serialization;

namespace ForSprinterra.Models.ProductModels
{
    [DataContract]
    public class ProductBase
    {
        [DataMember(Name = "id")]
        public long Id { get; set; }

        [DataMember(Name = "inventory_level")]
        public string Quantity { get; set; }

        [DataMember(Name = "sku")]
        public string Sku { get; set; }
    }

    public enum InventoryTrackingEnum
    {
        none,
        simple,
        sku
    }
}