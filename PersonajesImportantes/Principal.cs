using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaEntidades;
using CapaNegocio;
using System.Linq;
//using System.Threading;
using System.Globalization;
//using Microsoft.VisualBasic.Devices;
using System.Drawing;
using System.IO;
using System.Net;


namespace PersonajesImportantes
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void Principal_Load(object sender, EventArgs e)
        {

        }

        private void bUSQUEDAToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pERSONAJESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRegistroPersonajes newMDIChild = new frmRegistroPersonajes();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
      
        }
    }
}
