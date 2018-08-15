using System.Runtime.Serialization;

namespace ForSprinterra.Models.ProductModels
{
    [DataContract]
    public class ProductImage
    {
        [DataMember(Name = "url_zoom")]
        public string UrlZoom { get; set; }
        [DataMember(Name = "url_standard")]
        public string UrlStandard { get; set; }
        [DataMember(Name = "url_thumbnail")]
        public string UrlThumbnail { get; set; }
        [DataMember(Name = "url_tiny")]
        public string UrlTiny { get; set; }
    }
}