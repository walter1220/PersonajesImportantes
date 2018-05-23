namespace PersonajesImportantes
{
    partial class Principal
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
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
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.rEGISTROSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tIPOSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pERSONAJESToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bUSQUEDAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pERSONAJESToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rEGISTROSToolStripMenuItem,
            this.bUSQUEDAToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1153, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // rEGISTROSToolStripMenuItem
            // 
            this.rEGISTROSToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tIPOSToolStripMenuItem,
            this.pERSONAJESToolStripMenuItem});
            this.rEGISTROSToolStripMenuItem.Name = "rEGISTROSToolStripMenuItem";
            this.rEGISTROSToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.rEGISTROSToolStripMenuItem.Text = "REGISTROS";
            // 
            // tIPOSToolStripMenuItem
            // 
            this.tIPOSToolStripMenuItem.Name = "tIPOSToolStripMenuItem";
            this.tIPOSToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.tIPOSToolStripMenuItem.Text = "TIPOS";
            // 
            // pERSONAJESToolStripMenuItem
            // 
            this.pERSONAJESToolStripMenuItem.Name = "pERSONAJESToolStripMenuItem";
            this.pERSONAJESToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.pERSONAJESToolStripMenuItem.Text = "PERSONAJES";
            this.pERSONAJESToolStripMenuItem.Click += new System.EventHandler(this.pERSONAJESToolStripMenuItem_Click);
            // 
            // bUSQUEDAToolStripMenuItem
            // 
            this.bUSQUEDAToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pERSONAJESToolStripMenuItem1});
            this.bUSQUEDAToolStripMenuItem.Name = "bUSQUEDAToolStripMenuItem";
            this.bUSQUEDAToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.bUSQUEDAToolStripMenuItem.Text = "HISTORIA";
            this.bUSQUEDAToolStripMenuItem.Click += new System.EventHandler(this.bUSQUEDAToolStripMenuItem_Click);
            // 
            // pERSONAJESToolStripMenuItem1
            // 
            this.pERSONAJESToolStripMenuItem1.Name = "pERSONAJESToolStripMenuItem1";
            this.pERSONAJESToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.pERSONAJESToolStripMenuItem1.Text = "PERSONAJES";
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1153, 609);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "::: HISTORIA DE PERSONAJES :::";
            this.Load += new System.EventHandler(this.Principal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem rEGISTROSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tIPOSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pERSONAJESToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bUSQUEDAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pERSONAJESToolStripMenuItem1;
    }
}

