using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ServiciosPublicosNoSQL
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        //Eventos asociados a los controles

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
                ActualizaCamposFactura(periodoFactura);
            }
        }

        /// <summary>
        /// Evento para el botón de recálculo del valor de factura
        /// </summary>
        private void btnRecalcularFactura_Click(object sender, EventArgs e)
        {
            string periodoFactura = txtPeriodo.Text;
            AccesoDatos.RecalculaValorFactura(periodoFactura);
            ActualizaCamposFactura(periodoFactura);
        }

        /// <summary>
        /// Evento para el botón de creación de nueva factura
        /// </summary>
        private void btnNuevaFactura_Click(object sender, EventArgs e)
        {
            string periodo = dtpPeriodo.Text;

            //Vericamos si hay factura para ese periodo
            Factura unaFactura = AccesoDatos.ObtieneUnaFactura(periodo);
            if (unaFactura is null)
            {
                groupBoxDetalleServicio.Visible = true;
                lblSelectorPeriodo.Visible = false;
                dtpPeriodo.Visible = false;
                btnNuevaFactura.Visible = false;

                CrearNuevaFactura(periodo);
            }            
            else
                MessageBox.Show($"Ya existe factura para {periodo}. " +
                    $"Utiliza la opción de editar si quieres cambiar valores",
                    "Factura ya existe",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
        }

        /// <summary>
        /// Encapsula los llamados para inicializar los controles de la UI
        /// </summary>
        private void InicializaInterfaz()
        {
            InicializaListaPeriodoFacturas();

            //En la página de creación de factura, se oculta el detalle de los servicios
            groupBoxDetalleServicio.Visible = false;
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
        /// Actualiza los campos de la UI asociados a la información de la factura
        /// </summary>
        /// <param name="periodoFactura">Periodo para el cual se consulta factura</param>
        private void ActualizaCamposFactura(string periodoFactura)
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
            dataGridViewDetalleServicios.DataSource = null;
            dataGridViewDetalleServicios.DataSource = AccesoDatos.ObtieneDetalleConsumosFactura(periodoFactura);
        }

       /// <summary>
       /// Crea nueva factura para el periodo indicado
       /// </summary>
       /// <param name="periodo">El periodo para el cual se realizará la factura</param>
        private void CrearNuevaFactura(string periodo)
        {
            lblPeriodo.Text = periodo;

            //Aqui llenamos el comboBox de Servicios
            List<string> nombresServicios = AccesoDatos.ObtieneListaNombreServicios();

            lstServicios.DataSource = null;
            lstServicios.DataSource = nombresServicios;
            lstServicios.SelectedIndex = 0;

            //Aqui creamos una nueva Factura
            Factura nuevaFactura = new Factura
            {
                Periodo = periodo,
                Valor = 0,
                EstaCompleta = false,
                FechaCobro = new DateTime()
            };

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
            AccesoDatos.InsertaNuevaFactura(nuevaFactura);

            //Actualizamos el dataGridView con el detalle de los consumos para la factura
            dataGridViewDetalleConsumos.DataSource = null;
            dataGridViewDetalleConsumos.DataSource = AccesoDatos.ObtieneDetalleConsumosFactura(periodo);

            //Actualizamos campos adicionales
            lblValorFactura.Text = nuevaFactura.Valor.ToString();
        }

        /// <summary>
        /// Evento asociado al botón de cancelar la factura
        /// </summary>
        private void btnCancelarFactura_Click(object sender, EventArgs e)
        {
            //Reversamos la creación de la factura según el periodo seleccionado
            string periodo = lblPeriodo.Text;
            AccesoDatos.BorraFactura(periodo);
            
            lblSelectorPeriodo.Visible = true;

            dtpPeriodo.Value = DateTime.Now;
            dtpPeriodo.Visible = true;

            btnNuevaFactura.Visible = true;
            groupBoxDetalleServicio.Visible = false;
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
            lblSelectorPeriodo.Visible = true;
            dtpPeriodo.Visible = true;
            dtpPeriodo.Value = DateTime.Now;
            btnNuevaFactura.Visible = true;
            groupBoxDetalleServicio.Visible = false;
        }

        private void btnActualizarConsumoServicio_Click(object sender, EventArgs e)
        {
            string periodoFactura = lblPeriodo.Text;
            Consumo consumoRegistrado = new Consumo
            {
                Servicio = lstServicios.SelectedItem.ToString(),
                UnidadesConsumidas = double.Parse(txtUnidadesConsumidas.Text),
                Tarifa = double.Parse(txtTarifa.Text),
                ValorConsumo = double.Parse(txtValorConsumo.Text)
            };

            AccesoDatos.ActualizaConsumoEnFactura(periodoFactura, consumoRegistrado);

            //Actualizamos el dataGridView con el detalle de los consumos para la factura
            dataGridViewDetalleConsumos.DataSource = null;
            dataGridViewDetalleConsumos.DataSource = AccesoDatos.ObtieneDetalleConsumosFactura(periodoFactura);

            //Finalmente actualizamos los campos de la factura con este nuevo dato
            Factura facturaActual = AccesoDatos.ObtieneUnaFactura(periodoFactura);
            lblValorFactura.Text = facturaActual.Valor.ToString();
        }

        private void ActualizaInfoConsumo()
        {
            string periodoFactura = lblPeriodo.Text;
            string nombreServicio = lstServicios.SelectedItem.ToString();

            Consumo elConsumo = AccesoDatos.ObtieneConsumoServicio(periodoFactura, nombreServicio);

            txtUnidadesConsumidas.Text = elConsumo.UnidadesConsumidas.ToString();
            txtTarifa.Text = elConsumo.Tarifa.ToString();
            txtValorConsumo.Text = elConsumo.ValorConsumo.ToString();
        }

        private void txtUnidadesConsumidas_Leave(object sender, EventArgs e)
        {
            CalculaConsumoServicio();
        }

        private void txtTarifa_Leave(object sender, EventArgs e)
        {
            CalculaConsumoServicio();
        }

        private void CalculaConsumoServicio()
        {
            double unidadesConsumidas, tarifa;

            unidadesConsumidas = double.Parse(txtUnidadesConsumidas.Text);
            tarifa = double.Parse(txtTarifa.Text);

            txtValorConsumo.Text = (unidadesConsumidas * tarifa).ToString();
        }

        private void PaginaCreacion_Leave(object sender, EventArgs e)
        {
            //Se reinicia la interfaz de esta página
            lblSelectorPeriodo.Visible = true;
            dtpPeriodo.Visible = true;
            dtpPeriodo.Value = DateTime.Now;
            btnNuevaFactura.Visible = true;
            groupBoxDetalleServicio.Visible = false;
        }

        private void paginaConsulta_Enter(object sender, EventArgs e)
        {
            InicializaListaPeriodoFacturas();
        }

        private void lstServicios_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizaInfoConsumo();
        }
    }
}
