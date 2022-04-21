namespace ServiciosPublicosNoSQL
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.paginaConsulta = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.txtFechaCobro = new System.Windows.Forms.TextBox();
            this.btnRecalcularFactura = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.dataGridViewDetalleServicios = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.txtEstado = new System.Windows.Forms.TextBox();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.txtPeriodo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.listaPeriodos = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControlCrud = new System.Windows.Forms.TabControl();
            this.PaginaCreacion = new System.Windows.Forms.TabPage();
            this.groupBoxDetalleServicio = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtValorConsumo = new System.Windows.Forms.TextBox();
            this.btnFinalizar = new System.Windows.Forms.Button();
            this.btnCancelarFactura = new System.Windows.Forms.Button();
            this.lblPeriodo = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btnActualizarConsumoServicio = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dataGridViewDetalleConsumos = new System.Windows.Forms.DataGridView();
            this.txtTarifa = new System.Windows.Forms.TextBox();
            this.txtUnidadesConsumidas = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnNuevaFactura = new System.Windows.Forms.Button();
            this.lblSelectorPeriodo = new System.Windows.Forms.Label();
            this.dtpPeriodo = new System.Windows.Forms.DateTimePicker();
            this.lblValorFactura = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lstServicios = new System.Windows.Forms.ListBox();
            this.paginaConsulta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetalleServicios)).BeginInit();
            this.tabControlCrud.SuspendLayout();
            this.PaginaCreacion.SuspendLayout();
            this.groupBoxDetalleServicio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetalleConsumos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(153, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(483, 45);
            this.label1.TabIndex = 1;
            this.label1.Text = "Facturación Servicios Públicos";
            // 
            // paginaConsulta
            // 
            this.paginaConsulta.Controls.Add(this.label7);
            this.paginaConsulta.Controls.Add(this.txtFechaCobro);
            this.paginaConsulta.Controls.Add(this.btnRecalcularFactura);
            this.paginaConsulta.Controls.Add(this.label6);
            this.paginaConsulta.Controls.Add(this.dataGridViewDetalleServicios);
            this.paginaConsulta.Controls.Add(this.label5);
            this.paginaConsulta.Controls.Add(this.txtEstado);
            this.paginaConsulta.Controls.Add(this.txtValor);
            this.paginaConsulta.Controls.Add(this.txtPeriodo);
            this.paginaConsulta.Controls.Add(this.label4);
            this.paginaConsulta.Controls.Add(this.label3);
            this.paginaConsulta.Controls.Add(this.listaPeriodos);
            this.paginaConsulta.Controls.Add(this.label2);
            this.paginaConsulta.Location = new System.Drawing.Point(4, 22);
            this.paginaConsulta.Name = "paginaConsulta";
            this.paginaConsulta.Padding = new System.Windows.Forms.Padding(3);
            this.paginaConsulta.Size = new System.Drawing.Size(768, 381);
            this.paginaConsulta.TabIndex = 0;
            this.paginaConsulta.Text = "Consulta";
            this.paginaConsulta.UseVisualStyleBackColor = true;
            this.paginaConsulta.Enter += new System.EventHandler(this.paginaConsulta_Enter);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(195, 116);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Fecha cobro:";
            // 
            // txtFechaCobro
            // 
            this.txtFechaCobro.Location = new System.Drawing.Point(269, 113);
            this.txtFechaCobro.Name = "txtFechaCobro";
            this.txtFechaCobro.Size = new System.Drawing.Size(130, 20);
            this.txtFechaCobro.TabIndex = 11;
            // 
            // btnRecalcularFactura
            // 
            this.btnRecalcularFactura.Location = new System.Drawing.Point(422, 111);
            this.btnRecalcularFactura.Name = "btnRecalcularFactura";
            this.btnRecalcularFactura.Size = new System.Drawing.Size(135, 23);
            this.btnRecalcularFactura.TabIndex = 10;
            this.btnRecalcularFactura.Text = "Recalcular Factura";
            this.btnRecalcularFactura.UseVisualStyleBackColor = true;
            this.btnRecalcularFactura.Click += new System.EventHandler(this.btnRecalcularFactura_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(176, 173);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(255, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Detalle de los consumos por servicio para el periodo:";
            // 
            // dataGridViewDetalleServicios
            // 
            this.dataGridViewDetalleServicios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDetalleServicios.Location = new System.Drawing.Point(179, 193);
            this.dataGridViewDetalleServicios.Name = "dataGridViewDetalleServicios";
            this.dataGridViewDetalleServicios.Size = new System.Drawing.Size(561, 167);
            this.dataGridViewDetalleServicios.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(179, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "¿Está completa?";
            // 
            // txtEstado
            // 
            this.txtEstado.Location = new System.Drawing.Point(269, 83);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.Size = new System.Drawing.Size(130, 20);
            this.txtEstado.TabIndex = 6;
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(269, 53);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(130, 20);
            this.txtValor.TabIndex = 4;
            this.txtValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtPeriodo
            // 
            this.txtPeriodo.Location = new System.Drawing.Point(269, 23);
            this.txtPeriodo.Name = "txtPeriodo";
            this.txtPeriodo.Size = new System.Drawing.Size(130, 20);
            this.txtPeriodo.TabIndex = 2;
            this.txtPeriodo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(231, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Valor:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(219, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Periodo:";
            // 
            // listaPeriodos
            // 
            this.listaPeriodos.FormattingEnabled = true;
            this.listaPeriodos.Location = new System.Drawing.Point(23, 52);
            this.listaPeriodos.Name = "listaPeriodos";
            this.listaPeriodos.Size = new System.Drawing.Size(120, 95);
            this.listaPeriodos.TabIndex = 1;
            this.listaPeriodos.SelectedIndexChanged += new System.EventHandler(this.listaPeriodos_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Periodos registrados:";
            // 
            // tabControlCrud
            // 
            this.tabControlCrud.Controls.Add(this.paginaConsulta);
            this.tabControlCrud.Controls.Add(this.PaginaCreacion);
            this.tabControlCrud.Location = new System.Drawing.Point(12, 71);
            this.tabControlCrud.Name = "tabControlCrud";
            this.tabControlCrud.SelectedIndex = 0;
            this.tabControlCrud.Size = new System.Drawing.Size(776, 407);
            this.tabControlCrud.TabIndex = 0;
            // 
            // PaginaCreacion
            // 
            this.PaginaCreacion.Controls.Add(this.groupBoxDetalleServicio);
            this.PaginaCreacion.Controls.Add(this.btnNuevaFactura);
            this.PaginaCreacion.Controls.Add(this.lblSelectorPeriodo);
            this.PaginaCreacion.Controls.Add(this.dtpPeriodo);
            this.PaginaCreacion.Location = new System.Drawing.Point(4, 22);
            this.PaginaCreacion.Name = "PaginaCreacion";
            this.PaginaCreacion.Padding = new System.Windows.Forms.Padding(3);
            this.PaginaCreacion.Size = new System.Drawing.Size(768, 381);
            this.PaginaCreacion.TabIndex = 1;
            this.PaginaCreacion.Text = "Agregar Factura";
            this.PaginaCreacion.UseVisualStyleBackColor = true;
            this.PaginaCreacion.Leave += new System.EventHandler(this.PaginaCreacion_Leave);
            // 
            // groupBoxDetalleServicio
            // 
            this.groupBoxDetalleServicio.Controls.Add(this.lstServicios);
            this.groupBoxDetalleServicio.Controls.Add(this.lblValorFactura);
            this.groupBoxDetalleServicio.Controls.Add(this.label14);
            this.groupBoxDetalleServicio.Controls.Add(this.label8);
            this.groupBoxDetalleServicio.Controls.Add(this.txtValorConsumo);
            this.groupBoxDetalleServicio.Controls.Add(this.btnFinalizar);
            this.groupBoxDetalleServicio.Controls.Add(this.btnCancelarFactura);
            this.groupBoxDetalleServicio.Controls.Add(this.lblPeriodo);
            this.groupBoxDetalleServicio.Controls.Add(this.label12);
            this.groupBoxDetalleServicio.Controls.Add(this.btnActualizarConsumoServicio);
            this.groupBoxDetalleServicio.Controls.Add(this.label11);
            this.groupBoxDetalleServicio.Controls.Add(this.label10);
            this.groupBoxDetalleServicio.Controls.Add(this.dataGridViewDetalleConsumos);
            this.groupBoxDetalleServicio.Controls.Add(this.txtTarifa);
            this.groupBoxDetalleServicio.Controls.Add(this.txtUnidadesConsumidas);
            this.groupBoxDetalleServicio.Controls.Add(this.label9);
            this.groupBoxDetalleServicio.Location = new System.Drawing.Point(22, 73);
            this.groupBoxDetalleServicio.Name = "groupBoxDetalleServicio";
            this.groupBoxDetalleServicio.Size = new System.Drawing.Size(723, 285);
            this.groupBoxDetalleServicio.TabIndex = 3;
            this.groupBoxDetalleServicio.TabStop = false;
            this.groupBoxDetalleServicio.Text = "Detalle de consumo por servicio:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(322, 103);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Valor Consumo:";
            // 
            // txtValorConsumo
            // 
            this.txtValorConsumo.Enabled = false;
            this.txtValorConsumo.Location = new System.Drawing.Point(408, 99);
            this.txtValorConsumo.Name = "txtValorConsumo";
            this.txtValorConsumo.Size = new System.Drawing.Size(100, 20);
            this.txtValorConsumo.TabIndex = 11;
            this.txtValorConsumo.Text = "0";
            this.txtValorConsumo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnFinalizar
            // 
            this.btnFinalizar.Location = new System.Drawing.Point(613, 240);
            this.btnFinalizar.Name = "btnFinalizar";
            this.btnFinalizar.Size = new System.Drawing.Size(75, 23);
            this.btnFinalizar.TabIndex = 10;
            this.btnFinalizar.Text = "Finalizar";
            this.btnFinalizar.UseVisualStyleBackColor = true;
            this.btnFinalizar.Click += new System.EventHandler(this.btnFinalizar_Click);
            // 
            // btnCancelarFactura
            // 
            this.btnCancelarFactura.Location = new System.Drawing.Point(532, 241);
            this.btnCancelarFactura.Name = "btnCancelarFactura";
            this.btnCancelarFactura.Size = new System.Drawing.Size(75, 23);
            this.btnCancelarFactura.TabIndex = 9;
            this.btnCancelarFactura.Text = "Cancelar";
            this.btnCancelarFactura.UseVisualStyleBackColor = true;
            this.btnCancelarFactura.Click += new System.EventHandler(this.btnCancelarFactura_Click);
            // 
            // lblPeriodo
            // 
            this.lblPeriodo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPeriodo.ForeColor = System.Drawing.Color.Teal;
            this.lblPeriodo.Location = new System.Drawing.Point(135, 26);
            this.lblPeriodo.Name = "lblPeriodo";
            this.lblPeriodo.Size = new System.Drawing.Size(90, 13);
            this.lblPeriodo.TabIndex = 8;
            this.lblPeriodo.Text = "dato_periodo";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(83, 26);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(46, 13);
            this.label12.TabIndex = 4;
            this.label12.Text = "Periodo:";
            // 
            // btnActualizarConsumoServicio
            // 
            this.btnActualizarConsumoServicio.Location = new System.Drawing.Point(560, 98);
            this.btnActualizarConsumoServicio.Name = "btnActualizarConsumoServicio";
            this.btnActualizarConsumoServicio.Size = new System.Drawing.Size(128, 23);
            this.btnActualizarConsumoServicio.TabIndex = 7;
            this.btnActualizarConsumoServicio.Text = "Actualizar Consumo";
            this.btnActualizarConsumoServicio.UseVisualStyleBackColor = true;
            this.btnActualizarConsumoServicio.Click += new System.EventHandler(this.btnActualizarConsumoServicio_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(366, 77);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(37, 13);
            this.label11.TabIndex = 6;
            this.label11.Text = "Tarifa:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(288, 49);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(115, 13);
            this.label10.TabIndex = 5;
            this.label10.Text = "Unidades Consumidas:";
            // 
            // dataGridViewDetalleConsumos
            // 
            this.dataGridViewDetalleConsumos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDetalleConsumos.Location = new System.Drawing.Point(20, 138);
            this.dataGridViewDetalleConsumos.Name = "dataGridViewDetalleConsumos";
            this.dataGridViewDetalleConsumos.Size = new System.Drawing.Size(669, 97);
            this.dataGridViewDetalleConsumos.TabIndex = 4;
            // 
            // txtTarifa
            // 
            this.txtTarifa.Location = new System.Drawing.Point(408, 73);
            this.txtTarifa.Name = "txtTarifa";
            this.txtTarifa.Size = new System.Drawing.Size(100, 20);
            this.txtTarifa.TabIndex = 3;
            this.txtTarifa.Text = "0";
            this.txtTarifa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTarifa.Leave += new System.EventHandler(this.txtTarifa_Leave);
            // 
            // txtUnidadesConsumidas
            // 
            this.txtUnidadesConsumidas.Location = new System.Drawing.Point(408, 46);
            this.txtUnidadesConsumidas.Name = "txtUnidadesConsumidas";
            this.txtUnidadesConsumidas.Size = new System.Drawing.Size(100, 20);
            this.txtUnidadesConsumidas.TabIndex = 2;
            this.txtUnidadesConsumidas.Text = "0";
            this.txtUnidadesConsumidas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtUnidadesConsumidas.Leave += new System.EventHandler(this.txtUnidadesConsumidas_Leave);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(81, 54);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Servicio:";
            // 
            // btnNuevaFactura
            // 
            this.btnNuevaFactura.Location = new System.Drawing.Point(209, 20);
            this.btnNuevaFactura.Name = "btnNuevaFactura";
            this.btnNuevaFactura.Size = new System.Drawing.Size(102, 23);
            this.btnNuevaFactura.TabIndex = 2;
            this.btnNuevaFactura.Text = "Crear Factura";
            this.btnNuevaFactura.UseVisualStyleBackColor = true;
            this.btnNuevaFactura.Click += new System.EventHandler(this.btnNuevaFactura_Click);
            // 
            // lblSelectorPeriodo
            // 
            this.lblSelectorPeriodo.AutoSize = true;
            this.lblSelectorPeriodo.Location = new System.Drawing.Point(57, 25);
            this.lblSelectorPeriodo.Name = "lblSelectorPeriodo";
            this.lblSelectorPeriodo.Size = new System.Drawing.Size(46, 13);
            this.lblSelectorPeriodo.TabIndex = 1;
            this.lblSelectorPeriodo.Text = "Periodo:";
            // 
            // dtpPeriodo
            // 
            this.dtpPeriodo.CustomFormat = "yyyy-MM";
            this.dtpPeriodo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPeriodo.Location = new System.Drawing.Point(109, 19);
            this.dtpPeriodo.Name = "dtpPeriodo";
            this.dtpPeriodo.Size = new System.Drawing.Size(85, 20);
            this.dtpPeriodo.TabIndex = 0;
            // 
            // lblValorFactura
            // 
            this.lblValorFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorFactura.ForeColor = System.Drawing.Color.Teal;
            this.lblValorFactura.Location = new System.Drawing.Point(95, 251);
            this.lblValorFactura.Name = "lblValorFactura";
            this.lblValorFactura.Size = new System.Drawing.Size(90, 13);
            this.lblValorFactura.TabIndex = 14;
            this.lblValorFactura.Text = "dato_valor";
            this.lblValorFactura.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(17, 251);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(73, 13);
            this.label14.TabIndex = 13;
            this.label14.Text = "Valor Factura:";
            // 
            // lstServicios
            // 
            this.lstServicios.FormattingEnabled = true;
            this.lstServicios.Location = new System.Drawing.Point(135, 54);
            this.lstServicios.Name = "lstServicios";
            this.lstServicios.Size = new System.Drawing.Size(116, 69);
            this.lstServicios.TabIndex = 15;
            this.lstServicios.SelectedIndexChanged += new System.EventHandler(this.lstServicios_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 490);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControlCrud);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Servicios Públicos";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.paginaConsulta.ResumeLayout(false);
            this.paginaConsulta.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetalleServicios)).EndInit();
            this.tabControlCrud.ResumeLayout(false);
            this.PaginaCreacion.ResumeLayout(false);
            this.PaginaCreacion.PerformLayout();
            this.groupBoxDetalleServicio.ResumeLayout(false);
            this.groupBoxDetalleServicio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetalleConsumos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage paginaConsulta;
        private System.Windows.Forms.Button btnRecalcularFactura;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dataGridViewDetalleServicios;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtEstado;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.TextBox txtPeriodo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listaPeriodos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabControlCrud;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtFechaCobro;
        private System.Windows.Forms.TabPage PaginaCreacion;
        private System.Windows.Forms.Label lblSelectorPeriodo;
        private System.Windows.Forms.DateTimePicker dtpPeriodo;
        private System.Windows.Forms.Button btnNuevaFactura;
        private System.Windows.Forms.GroupBox groupBoxDetalleServicio;
        private System.Windows.Forms.Button btnActualizarConsumoServicio;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dataGridViewDetalleConsumos;
        private System.Windows.Forms.TextBox txtTarifa;
        private System.Windows.Forms.TextBox txtUnidadesConsumidas;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblPeriodo;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnFinalizar;
        private System.Windows.Forms.Button btnCancelarFactura;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtValorConsumo;
        private System.Windows.Forms.Label lblValorFactura;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ListBox lstServicios;
    }
}

