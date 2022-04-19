using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ServiciosPublicosNoSQL
{
    public class Factura
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("periodo")]
        public string Periodo { get; set; }

        [BsonElement("valor")]
        public double Valor { get; set; }

        [BsonElement("estaCompleta")]
        public bool EstaCompleta { get; set; }

        [BsonElement("fechaCobro")]
        public string FechaCobro { get; set; }

        [BsonElement("consumos")]
        public List<Consumo> Consumos { get; set; }
    }
}