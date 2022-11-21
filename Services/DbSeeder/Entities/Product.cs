using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace DbSeeder.Entities
{
    [Serializable, XmlRoot("Product")]
    public class Product : EntityBase
    {
        [Required, StringLength(80)]
        public string? Name { get; set; }

        [Required, StringLength(40)]
        public string? Category { get; set; }
        public string? Description { get; set; }

        [Precision(18, 2)]
        public decimal Price { get; set; }
    }
}
