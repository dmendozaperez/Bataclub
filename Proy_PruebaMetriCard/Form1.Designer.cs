﻿namespace Proy_PruebaMetriCard
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
            this.button1 = new System.Windows.Forms.Button();
            this.btnEnvioVenta = new System.Windows.Forms.Button();
            this.btnenviometri = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(101, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnEnvioVenta
            // 
            this.btnEnvioVenta.Location = new System.Drawing.Point(101, 59);
            this.btnEnvioVenta.Name = "btnEnvioVenta";
            this.btnEnvioVenta.Size = new System.Drawing.Size(75, 23);
            this.btnEnvioVenta.TabIndex = 1;
            this.btnEnvioVenta.Text = "EnvioVentas";
            this.btnEnvioVenta.UseVisualStyleBackColor = true;
            this.btnEnvioVenta.Click += new System.EventHandler(this.btnEnvioVenta_Click);
            // 
            // btnenviometri
            // 
            this.btnenviometri.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnenviometri.Location = new System.Drawing.Point(32, 138);
            this.btnenviometri.Name = "btnenviometri";
            this.btnenviometri.Size = new System.Drawing.Size(222, 28);
            this.btnenviometri.TabIndex = 2;
            this.btnenviometri.Text = "envio de cliente a metricard";
            this.btnenviometri.UseVisualStyleBackColor = true;
            this.btnenviometri.Click += new System.EventHandler(this.btnenviometri_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.btnenviometri);
            this.Controls.Add(this.btnEnvioVenta);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnEnvioVenta;
        private System.Windows.Forms.Button btnenviometri;
    }
}

