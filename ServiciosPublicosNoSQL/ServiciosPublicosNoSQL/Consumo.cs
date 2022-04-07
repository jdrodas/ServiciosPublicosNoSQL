using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ServiciosPublicosNoSQL
{
    public class Consumo
    {
        [BsonElement("servicio")]
        public string Servicio { get; set; }

        [BsonElement("unidadesConsumidas")]
        public double UnidadesConsumidas { get; set; }

        [BsonElement("tarifa")]
        public double Tarifa { get; set; }

        [BsonElement("valorConsumo")]
        public double ValorConsumo { get; set; }
    }
}
