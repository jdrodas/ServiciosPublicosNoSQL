using System;
using System.Windows.Forms;

namespace ServiciosPublicosNoSQL
{
    public partial class Form1 : Form
    {
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
        /// Encapsula los llamados para inicializar los controles de la UI
        /// </summary>
        private void InicializaInterfaz()
        {
            InicializaListaPeriodoFacturas();
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

            //Actualizamos el dataGridView con el detalle de los consumos para la factura
            dataGridViewDetalleServicios.DataSource = null;
            dataGridViewDetalleServicios.DataSource = AccesoDatos.ObtieneDetalleConsumosFactura(periodoFactura);
        }
    }
}
