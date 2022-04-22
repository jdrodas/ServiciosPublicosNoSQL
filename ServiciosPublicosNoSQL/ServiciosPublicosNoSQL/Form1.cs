using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ServiciosPublicosNoSQL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region EventosControles

        /// <summary>
        /// Evento asociado al comienzo de la aplicación, cargue de la forma
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            InicializaInterfaz();
        }

        /// <summary>
        /// Evento para el cambio de elemento seleccionado en la lista de Periodos
        /// </summary>
        private void listaPeriodos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((listaPeriodos.DataSource is null) == false)
            {
                string periodoFactura = listaPeriodos.SelectedItem.ToString();
                ActualizaCamposConsultaFactura(periodoFactura);
            }
        }

        /// <summary>
        /// Evento para el cambio de elemento seleccionado en la lista de servicios
        /// </summary>
        private void listaServicios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if((listaServicios.DataSource is null) == false)            
                if (lblPeriodo.Text != "dato_periodo")
                {
                    string periodoFactura = lblPeriodo.Text;
                    string nombreServicio = listaServicios.SelectedItem.ToString();
                    ActualizaCamposConsumo(periodoFactura, nombreServicio);
                }
        }

        /// <summary>
        /// Evento asociado a la salida de foco de la página de creacion de factura
        /// </summary>
        private void paginaCreacion_Leave(object sender, EventArgs e)
        {
            //Se reinicia la interfaz de esta página
            InicializaPaginaCreacionFactura();
        }

        /// <summary>
        /// Evento asociado a la entrada de foco de la pagina de consulta de factura
        /// </summary>
        private void paginaConsulta_Enter(object sender, EventArgs e)
        {
            InicializaListaPeriodoFacturas();
        }

        /// <summary>
        /// Evento para el botón de recálculo del valor de factura
        /// </summary>
        private void btnRecalcularFactura_Click(object sender, EventArgs e)
        {
            string periodoFactura = txtPeriodo.Text;
            AccesoDatos.RecalculaValorFactura(periodoFactura);

            //Finalmente actualizamos los campos de la UI
            ActualizaCamposConsultaFactura(periodoFactura);
        }

        /// <summary>
        /// Evento para el botón de creación / edición de factura
        /// </summary>
        private void btnNuevaFactura_Click(object sender, EventArgs e)
        {
            string periodo = dtpPeriodo.Text;

            //Aqui modificamos la interfaz a la funcionalidad activa
            groupBoxDetalleServicio.Visible = true;
            lblSelectorPeriodo.Visible = false;
            dtpPeriodo.Visible = false;
            btnNuevaFactura.Visible = false;
            lblValorFactura.Text = "0";
            lblPeriodo.Text = periodo;

            //Vericamos si hay factura para ese periodo
            Factura unaFactura = AccesoDatos.ObtieneUnaFactura(periodo);
            if (unaFactura is null)
            {
                //Aqui creamos una nueva Factura
                AccesoDatos.CreaFactura(periodo);
            }
            else
                MessageBox.Show($"Ya existe factura para {periodo}. " +
                    $"Se podrán editar consumos y recalcular valores",
                    "Factura ya existe",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

            //Actualizamos la lista de servicios que se utilizarán para manipular la factura
            InicializaListaServicios();

            //Actualizamos el dataGridView con el detalle de los consumos para la factura
            ActualizaDataGridConsumosServicios(periodo, dataGridViewDetalleConsumos);
        }

        /// <summary>
        /// Evento asociado al botón de borrar la factura
        /// </summary>
        private void btnBorrarFactura_Click(object sender, EventArgs e)
        {
            string periodo = lblPeriodo.Text;

            DialogResult resultadoConfirmacion =
                MessageBox.Show($"¿Está seguro que desea borrar la factura " +
                    $"para el periodo {periodo}?",
                    "Confirmación borrado factura",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);


            // Si presionó el botón de SI, se procede a borrar la factura
            if (resultadoConfirmacion == DialogResult.Yes)
            {
                AccesoDatos.BorraFactura(periodo);

                //Reiniciamos la interfaz de usuario
                InicializaPaginaCreacionFactura();
            }
        }

        /// <summary>
        /// Evento asociado al botón de finalizar la factura
        /// </summary>
        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            //Se finaliza la factura, colocandola en completa
            string periodoFactura = lblPeriodo.Text;
            AccesoDatos.RecalculaValorFactura(periodoFactura);

            //Se reinicia la interfaz de esta página
            InicializaPaginaCreacionFactura();
        }

        /// <summary>
        /// Evento asociado al botón de actualizar consumo del servicio activo
        /// </summary>
        private void btnActualizarConsumoServicio_Click(object sender, EventArgs e)
        {
            CalculaConsumoServicio();
        }

        /// <summary>
        /// Evento asociado a la salida de foco del textbox de Unidades Consumidas
        /// </summary>
        private void txtUnidadesConsumidas_Leave(object sender, EventArgs e)
        {
            CalculaConsumoServicio();
        }

        /// <summary>
        /// Evento asociado a la salida de foco del textbox de la tarifa
        /// </summary>
        private void txtTarifa_Leave(object sender, EventArgs e)
        {
            CalculaConsumoServicio();
        }

        #endregion EventosControles

        #region MetodosInterfaz

        /// <summary>
        /// Encapsula los llamados para inicializar los controles de la UI
        /// </summary>
        private void InicializaInterfaz()
        {
            //En la página de consulta de facturas
            InicializaListaPeriodoFacturas();

            //En la página de Creacion/Edición de facturas
            InicializaPaginaCreacionFactura();
        }

        /// <summary>
        /// Inicializa los controles de la UI asociados a la página de creacion/edicion de factura
        /// </summary>
        private void InicializaPaginaCreacionFactura()
        {
            //Valor predeterminado del periodo
            lblPeriodo.Text = "dato_periodo";
            txtUnidadesConsumidas.Text = "0";
            txtTarifa.Text = "0";
            txtValorConsumo.Text = "0";

            lblSelectorPeriodo.Visible = true;
            dtpPeriodo.Visible = true;
            dtpPeriodo.Value = DateTime.Now;
            btnNuevaFactura.Visible = true;

            //En la página de creación de factura, se oculta el detalle de los servicios
            groupBoxDetalleServicio.Visible = false;

            InicializaListaServicios();
        }

        /// <summary>
        /// Inicializa la lista de Periodos con la información de facturas registradas
        /// </summary>
        private void InicializaListaPeriodoFacturas()
        {
            listaPeriodos.DataSource = null;
            listaPeriodos.DataSource = AccesoDatos.ObtieneListaPeriodosFacturacion();
            listaPeriodos.SelectedIndex = 0;
        }

        /// <summary>
        /// Inicializa la lista de Servicios para utilizar en la creación / edición de facturas
        /// </summary>
        private void InicializaListaServicios()
        {
            listaServicios.DataSource = null;
            listaServicios.DataSource = AccesoDatos.ObtieneListaNombreServicios();
            listaServicios.SelectedIndex = 0;
        }

        /// <summary>
        /// Actualiza los campos de la UI asociados a los consumos de un servicio en una factura
        /// </summary>
        /// <param name="periodoFactura">Periodo para el cual se consulta factura</param>
        /// <param name="nombreServicio">Servicio para el cual se consulta el consumo</param>
        private void ActualizaCamposConsumo(string periodoFactura, string nombreServicio)
        {
            Consumo elConsumo = AccesoDatos.ObtieneConsumoServicio(periodoFactura, nombreServicio);

            txtUnidadesConsumidas.Text = elConsumo.UnidadesConsumidas.ToString();
            txtTarifa.Text = elConsumo.Tarifa.ToString();
            txtValorConsumo.Text = elConsumo.ValorConsumo.ToString();
        }

        /// <summary>
        /// Actualiza los campos de la UI asociados a la consulta de la factura
        /// </summary>
        /// <param name="periodoFactura">Periodo para el cual se consulta factura</param>
        private void ActualizaCamposConsultaFactura(string periodoFactura)
        {
            //Aqui obtenemos la factura que cumple con el parámetro de periodo
            Factura unaFactura = AccesoDatos.ObtieneUnaFactura(periodoFactura);

            //Aqui actualizamos los campos informativos de la factura
            txtPeriodo.Text = unaFactura.Periodo;
            txtValor.Text = unaFactura.Valor.ToString("00.00");


            if (unaFactura.EstaCompleta)
                txtEstado.Text = "Completa";
            else
                txtEstado.Text = "Incompleta";

            //Aqui Validamos si la factura tiene fecha de cobro
            //Si el año es 1, debe visualizarse como incompleta
            if (unaFactura.FechaCobro.Year == 1)
            {
                txtFechaCobro.Text = "Sin fecha";
                txtEstado.Text = "Incompleta";
            }
            else
                txtFechaCobro.Text = unaFactura.FechaCobro.ToString("dd/MM/yyyy hh:mm tt");

            //Actualizamos el dataGridView con el detalle de los consumos para la factura
            ActualizaDataGridConsumosServicios(periodoFactura, dataGridViewDetalleServicios);
        }

        /// <summary>
        /// Actualiza el datagridview con la información de los consumos por servicio asociados a la factura
        /// </summary>
        /// <param name="periodoFactura"></param>
        /// <param name="gridConsumos"></param>
        private void ActualizaDataGridConsumosServicios(string periodoFactura, DataGridView gridConsumos)
        {
            gridConsumos.DataSource = null;
            gridConsumos.DataSource = AccesoDatos.ObtieneDetalleConsumosFactura(periodoFactura);
        }

        /// <summary>
        /// Calcula el valor del consumo del servicio activo
        /// </summary>
        private void CalculaConsumoServicio()
        {
            string periodoFactura = lblPeriodo.Text;
            double unidadesConsumidas, tarifa, valorConsumo;

            unidadesConsumidas = double.Parse(txtUnidadesConsumidas.Text);
            tarifa = double.Parse(txtTarifa.Text);
            valorConsumo = unidadesConsumidas * tarifa;
            txtValorConsumo.Text = valorConsumo.ToString();

            if (valorConsumo != 0)
            {
                Consumo consumoRegistrado = new Consumo
                {
                    Servicio = listaServicios.SelectedItem.ToString(),
                    UnidadesConsumidas = unidadesConsumidas,
                    Tarifa = tarifa,
                    ValorConsumo = valorConsumo
                };

                AccesoDatos.ActualizaConsumoEnFactura(periodoFactura, consumoRegistrado);

                //Actualizamos el dataGridView con el detalle de los consumos para la factura
                ActualizaDataGridConsumosServicios(periodoFactura, dataGridViewDetalleConsumos);

                //Finalmente actualizamos los campos de la factura con este nuevo dato
                Factura facturaActual = AccesoDatos.ObtieneUnaFactura(periodoFactura);
                lblValorFactura.Text = facturaActual.Valor.ToString();
            }
        }

        #endregion MetodosInterfaz
    }
}
