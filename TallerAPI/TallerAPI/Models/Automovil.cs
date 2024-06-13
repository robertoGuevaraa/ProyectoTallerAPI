using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace TallerAPI.Models
{
    public class Automovil
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? id { get; set; }
        public string? fechaIngreso { get; set; }
        public string? nombrePropietario { get; set; }
        public string? marca { get; set; }
        public string? modelo { get; set; }
        public string? color { get; set; }
        public int? anio { get; set; }
        public string? numPlaca { get; set; }
        public string? numVIN { get; set; }
        public string? descripcionReparacion { get; set; }
    }
}

