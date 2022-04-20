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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.paginaConsulta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetalleServicios)).BeginInit();
            this.tabControl1.SuspendLayout();
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
            this.btnRecalcularFactura.Location = new System.Drawing.Point(425, 82);
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
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.paginaConsulta);
            this.tabControl1.Location = new System.Drawing.Point(12, 71);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(776, 407);
            this.tabControl1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 490);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Servicios Públicos";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.paginaConsulta.ResumeLayout(false);
            this.paginaConsulta.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetalleServicios)).EndInit();
            this.tabControl1.ResumeLayout(false);
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
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtFechaCobro;
    }
}

