using System.Xml.Serialization;

namespace DbSeeder.Entities
{
    public abstract class EntityBase
    {
        [XmlIgnore]
        public int Id { get; protected set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}
