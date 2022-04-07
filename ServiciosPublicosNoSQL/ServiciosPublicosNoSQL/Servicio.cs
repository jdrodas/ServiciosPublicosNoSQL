using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ServiciosPublicosNoSQL
{
    public class Servicio
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("nombre")]
        public string Nombre { get; set; }

        [BsonElement("unidadMedida")]
        public string UnidadMedida { get; set; }
    }
}