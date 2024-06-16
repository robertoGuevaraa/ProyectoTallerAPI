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
    /*
[Este es el JSon que cree para que ustedes lo peguen en su base de datos

    paso 1 cree la base de datos llamada "taller" y agregue una coleccion llamada "autos" luego pegan el Json y listo, psdt escriban asi como les deje la base de datos y la coleccion
{
    "id": 1,
    "fechaIngreso": "22 de enero",
    "nombrePropietario": "Stanley Rodríguez",
    "marca": "Toyota",
    "modelo": "Hilux",
    "color": "Negro",
    "anio": 2022,
    "numPlaca": "P258-365",
    "numVIN": "FA78869985S25689",
    "descripcionReparacion": "Falla en el sistema de aire acondicionado"
  },{
    "id": 2,
    "fechaIngreso": "10 de febrero",
    "nombrePropietario": "roberto Rodríguez",
    "marca": "Nissan",
    "modelo": "NP300",
    "color": "Blanco",
    "anio": 2024,
    "numPlaca": "p123-365",
    "numVIN": "Rm78869985S25689",
    "descripcionReparacion": "La llanta de atras no alcanza la de adelante"
  }
]*/
}

