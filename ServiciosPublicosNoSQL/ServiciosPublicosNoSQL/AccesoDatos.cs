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

        /// <summary>
        /// Obtiene la cadena de conexión para realizar las operaciones en DB
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        #region MetodosFacturas

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

        /// <summary>
        /// Borra una factura en la base de datos
        /// </summary>
        /// <param name="periodoFactura"></param>
        public static void BorraFactura(string periodoFactura)
        {
            string cadenaConexion = ObtieneCadenaConexion(idStringConexion);
            var clienteDB = new MongoClient(cadenaConexion);
            var miDB = clienteDB.GetDatabase(nombreDB);

            var unaColeccion = miDB.GetCollection<Factura>("Facturas");
            unaColeccion.DeleteOne(documento => documento.Periodo == periodoFactura);
        }

        /// <summary>
        /// Crea una factura en la base de datos con los valores predeterminados
        /// </summary>
        /// <param name="periodoFactura">Periodo de la factura</param>
        public static void CreaFactura(string periodoFactura)
        {
            Factura nuevaFactura = new Factura
            {
                Periodo = periodoFactura,
                Valor = 0,
                EstaCompleta = false,
                FechaCobro = new DateTime()
            };

            List<string> nombresServicios = ObtieneListaNombreServicios();

            List<Consumo> losConsumos = new List<Consumo>();
            Consumo unConsumo;

            foreach (string unServicio in nombresServicios)
            {
                unConsumo = new Consumo
                {
                    Servicio = unServicio,
                    Tarifa = 0,
                    UnidadesConsumidas = 0,
                    ValorConsumo = 0
                };

                losConsumos.Add(unConsumo);
            }

            nuevaFactura.Consumos = losConsumos;

            //Finalmente la insertamos en la base de datos
            InsertaNuevaFactura(nuevaFactura);

        }

        /// <summary>
        /// Inserta una factura en la base de datos
        /// </summary>
        /// <param name="unaFactura">El objeto factura a insertar</param>
        public static void InsertaNuevaFactura(Factura factura)
        {
            string cadenaConexion = ObtieneCadenaConexion(idStringConexion);
            var clienteDB = new MongoClient(cadenaConexion);
            var miDB = clienteDB.GetDatabase(nombreDB);

            var unaColeccion = miDB.GetCollection<Factura>("Facturas");
            unaColeccion.InsertOne(factura);
        }

        /// <summary>
        /// Recalcula los valores de los consumos y valor de la factura basado en el consumo
        /// </summary>
        /// <param name="periodoFactura">Factura para recalcular</param>
        public static void RecalculaValorFactura(string periodoFactura)
        {
            Factura unaFactura = ObtieneUnaFactura(periodoFactura);
            double nuevoValorFactura = 0;
            bool tieneConsumosPendientes = false;

            //Recorremos la colección de consumos para obtener el nuevo valor de factura
            foreach (Consumo unConsumo in unaFactura.Consumos)
            {
                if (unConsumo.ValorConsumo == 0)
                {
                    unConsumo.ValorConsumo = unConsumo.UnidadesConsumidas * unConsumo.Tarifa;

                    //Si luego del calculo el consumo sigue en 0, la factura tiene 
                    //Consumos sin valor
                    if (unConsumo.ValorConsumo == 0)
                        tieneConsumosPendientes = true;
                }
                nuevoValorFactura += unConsumo.ValorConsumo;
            }

            unaFactura.Valor = nuevoValorFactura;

            //Si no tiene consumos pendientes, se puede cerrar
            if (!tieneConsumosPendientes)
            {
                if (!unaFactura.EstaCompleta)
                {
                    unaFactura.EstaCompleta = true;
                    unaFactura.FechaCobro = DateTime.Now;
                }
            }
            else
            {
                unaFactura.EstaCompleta = false;
                unaFactura.FechaCobro = new DateTime();
            }

            ActualizaFactura(unaFactura);
        }

        /// <summary>
        /// Actualiza el registro del consumo especificado para la factura especificada
        /// </summary>
        /// <param name="periodoFactura">Factura para actualizar</param>
        /// <param name="nuevoConsumo">El registro del consumo a actualizar</param>
        public static void ActualizaConsumoEnFactura(string periodoFactura, Consumo nuevoConsumo)
        {
            //Buscamos la factura asociada al periodo
            Factura unaFactura = ObtieneUnaFactura(periodoFactura);

            //Buscamos el consumo que necesitamos actualizar
            Consumo viejoConsumo = unaFactura.Consumos.Find(x => x.Servicio == nuevoConsumo.Servicio);
            unaFactura.Consumos.Remove(viejoConsumo);
            unaFactura.Consumos.Add(nuevoConsumo);

            //Aqui colocamos la factura como incompleta para que se pueda volver a recalcular
            unaFactura.EstaCompleta = false;

            //Luego, actualizamos la factura
            ActualizaFactura(unaFactura);

            //Finalmente, recalculamos los valores
            RecalculaValorFactura(unaFactura.Periodo);
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

        #endregion MetodosFacturas

        #region MetodosServicios

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
        /// Obtiene una lista con los nombres de los servicios registrados en la colección
        /// </summary>
        /// <returns>La lista de los nombres de servicios</returns>
        public static List<string> ObtieneListaNombreServicios()
        {
            List<string> listaResultados = new List<string>();
            List<Servicio> ListaServicios = ObtieneServicios();

            foreach (Servicio unServicio in ListaServicios)
                listaResultados.Add(unServicio.Nombre);

            listaResultados.Sort();

            return listaResultados;
        }

        /// <summary>
        /// Obtiene la lista de servicios registrados en la DB
        /// </summary>
        /// <returns>La lista de servicios</returns>
        public static List<Servicio> ObtieneServicios()
        {
            string cadenaConexion = ObtieneCadenaConexion(idStringConexion);
            var clienteDB = new MongoClient(cadenaConexion);
            var miDB = clienteDB.GetDatabase(nombreDB);

            return ObtenerRegistros<Servicio>(miDB, "Servicios");
        }

        /// <summary>
        /// Obtiene un registro de consumo para el servicio en la factura especificada
        /// </summary>
        /// <param name="periodoFactura">Periodo de la factura</param>
        /// <param name="nombreServicio">Nombre del servicio</param>
        /// <returns></returns>
        public static Consumo ObtieneConsumoServicio(string periodoFactura, string nombreServicio)
        {
            Factura laFactura = ObtieneUnaFactura(periodoFactura);
            Consumo elConsumo = laFactura.Consumos.Find(x => x.Servicio == nombreServicio);

            if (elConsumo is null)
            {
                elConsumo = new Consumo
                {
                    Servicio = nombreServicio,
                    UnidadesConsumidas = 0,
                    Tarifa = 0,
                    ValorConsumo = 0
                };

                laFactura.Consumos.Add(elConsumo);
                //Finalmente, actualizamos la factura
                ActualizaFactura(laFactura);
            }

            return elConsumo;
        }

        #endregion MetodosServicios
    }
}
