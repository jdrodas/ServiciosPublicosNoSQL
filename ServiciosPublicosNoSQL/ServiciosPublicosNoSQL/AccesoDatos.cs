using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using MongoDB.Driver;
using MongoDB.Bson;


namespace ServiciosPublicosNoSQL
{
    public class AccesoDatos
    {
        // Constantes para la cadena de conexion y nombre de Base de datos
        const string nombreDB = "SERVPUB";
        const string idStringConexion = "serviciosPublicosDB";

        private static string ObtieneCadenaConexion(string id)
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }

        /// <summary>
        /// Obtiene los registros de una colección mapeados a una lista del objeto especificado en el génerico
        /// </summary>
        /// <typeparam name="T">El objeto genérico especificado</typeparam>
        /// <param name="unaDB">la base de datos</param>
        /// <param name="nombreColeccion">La colección</param>
        /// <returns></returns>
        private static List<T> ObtenerRegistros<T>(IMongoDatabase unaDB, string nombreColeccion)
        {
            var unaColeccion = unaDB.GetCollection<T>(nombreColeccion);
            return (unaColeccion.Find(new BsonDocument()).ToList());
        }

        /// <summary>
        /// Obtiene la lista de facturas registradas en la DB
        /// </summary>
        /// <returns>La lista de facturas</returns>
        public static List<Factura> ObtieneFacturas()
        {
            string cadenaConexion = ObtieneCadenaConexion(idStringConexion);
            var clienteDB = new MongoClient(cadenaConexion);
            var miDB = clienteDB.GetDatabase(nombreDB);

            return ObtenerRegistros<Factura>(miDB, "Facturas");
        }

        /// <summary>
        /// Obtiene una factura a partir del periodo de facturación especificado
        /// </summary>
        /// <param name="periodoFactura">El periodo de facturación de la factura</param>
        /// <returns>La factura asociada al periodo de Facturacion</returns>
        public static Factura ObtieneUnaFactura(string periodoFactura)
        {
            string cadenaConexion = ObtieneCadenaConexion(idStringConexion);
            var clienteDB = new MongoClient(cadenaConexion);
            var miDB = clienteDB.GetDatabase(nombreDB);

            var unaColeccion = miDB.GetCollection<Factura>("Facturas");
            var filtroFactura = new BsonDocument { { "periodo", periodoFactura } };

            var UnaFactura = unaColeccion.Find(filtroFactura).FirstOrDefault();

            return UnaFactura;
        }

        /// <summary>
        /// Obtiene una lista con los periodos de facturación registrados en la colección
        /// </summary>
        /// <returns>La lista de los periodos</returns>
        public static List<string> ObtieneListaPeriodosFacturacion()
        {
            List<string> listaResultados = new List<string>();
            List<Factura> listaFacturas = ObtieneFacturas();

            foreach (Factura unaFactura in listaFacturas)
                listaResultados.Add(unaFactura.Periodo);

            listaResultados.Sort();

            return listaResultados;
        }

        /// <summary>
        /// Obtiene un servicio a partir de su nombre
        /// </summary>
        /// <param name="nombreServicio">El nombre del servicio</param>
        /// <returns></returns>
        public static Servicio ObtieneUnServicio(string nombreServicio)
        {
            string cadenaConexion = ObtieneCadenaConexion(idStringConexion);
            var clienteDB = new MongoClient(cadenaConexion);
            var miDB = clienteDB.GetDatabase(nombreDB);

            var unaColeccion = miDB.GetCollection<Servicio>("Servicios");
            var filtroServicio = new BsonDocument { { "nombre", nombreServicio } };

            var unServicio = unaColeccion.Find(filtroServicio).FirstOrDefault();

            return unServicio;
        }

        /// <summary>
        /// Obtiene una tabla con la información detallada de los consumos de la factura
        /// </summary>
        /// <param name="periodoFactura">Periodo de la factura</param>
        /// <returns>tabla con el detalle de los consumos</returns>
        public static DataTable ObtieneDetalleConsumosFactura(string periodoFactura)
        {
            DataTable tablaResultado = new DataTable();

            tablaResultado.Columns.Add(new DataColumn("Nombre Servicio", typeof(string)));
            tablaResultado.Columns.Add(new DataColumn("Unidad de Medida", typeof(string)));
            tablaResultado.Columns.Add(new DataColumn("Unidades consumidas", typeof(double)));
            tablaResultado.Columns.Add(new DataColumn("Tarifa", typeof(double)));
            tablaResultado.Columns.Add(new DataColumn("Valor Consumo", typeof(double)));

            Factura unaFactura = ObtieneUnaFactura(periodoFactura);
            Servicio unServicio;

            DataRow filaServicio;

            foreach (Consumo unConsumo in unaFactura.Consumos)
            {
                unServicio = ObtieneUnServicio(unConsumo.Servicio);
                filaServicio = tablaResultado.NewRow();

                filaServicio["Nombre Servicio"] = unServicio.Nombre;
                filaServicio["Unidad de Medida"] = unServicio.UnidadMedida;
                filaServicio["Unidades consumidas"] = unConsumo.UnidadesConsumidas;
                filaServicio["Tarifa"] = unConsumo.Tarifa;
                filaServicio["Valor Consumo"] = unConsumo.ValorConsumo;

                tablaResultado.Rows.Add(filaServicio);
            }

            return tablaResultado;
        }

        public static void RecalculaValorFactura(string periodoFactura)
        {
            Factura unaFactura = ObtieneUnaFactura(periodoFactura);
            double nuevoValorFactura = 0;

            //Recorremos la colección de consumos para obtener el nuevo valor de factura
            foreach (Consumo unConsumo in unaFactura.Consumos)
            {
                if (unConsumo.ValorConsumo == 0)
                    unConsumo.ValorConsumo = unConsumo.UnidadesConsumidas * unConsumo.Tarifa;
                
                nuevoValorFactura += unConsumo.ValorConsumo;                
            }

            unaFactura.Valor = nuevoValorFactura;
            unaFactura.EstaCompleta = true;
            unaFactura.FechaCobro = DateTime.Now;

            ActualizaFactura(unaFactura);
        }

        /// <summary>
        /// Actualiza una factura en la base de datos
        /// </summary>
        /// <param name="unaFactura">El objeto factura a actualizar</param>
        public static void ActualizaFactura(Factura unaFactura)
        {
            string cadenaConexion = ObtieneCadenaConexion(idStringConexion);
            var clienteDB = new MongoClient(cadenaConexion);
            var miDB = clienteDB.GetDatabase(nombreDB);

            var unaColeccion = miDB.GetCollection<Factura>("Facturas");
            unaColeccion.ReplaceOne(documento => documento.Id == unaFactura.Id, unaFactura);
        }
    }
}
