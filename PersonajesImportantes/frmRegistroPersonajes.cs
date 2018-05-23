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

namespace PersonajesImportantes
{
    public partial class frmRegistroPersonajes : Form
    {
        string Error = "";
        public frmRegistroPersonajes()
        {
            InitializeComponent();
        }

        private void frmRegistroPersonajes_Load(object sender, EventArgs e)
        {
            dgvPersonajes.AutoGenerateColumns = false;
            ListaPersonajes();
            CargarTipo();
        }

        public void ListaPersonajes()
        {
            brPersonajes obrPersonajes = new brPersonajes();
            List<bePersonajes> lbePersonajes = new List<bePersonajes>();
            lbePersonajes = obrPersonajes.ListarPersonajes(ref Error);
            dgvPersonajes.DataSource = lbePersonajes;
                                    
        }

        public void CargarTipo()
        {
            //msgError = "";
            try
            {
                brPersonajes obrTipo = new brPersonajes();
                List<bePersonajes> lbeTipo = new List<bePersonajes>();
                lbeTipo = obrTipo.ListarTipo(ref Error);

                if (string.IsNullOrWhiteSpace(Error))
                {
                    cboTipo.DisplayMember = "NombreTipo";
                    cboTipo.ValueMember = "IdTipo";
                    lbeTipo.Insert(0, new bePersonajes { IdTipo = 0, NombreTipo = "Seleccione" });
                    cboTipo.DataSource = lbeTipo;
                }
                else
                {
                    MessageBox.Show(Error, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        public void GuardarPersonaje()
        {
            brPersonajes obrPersonajes = new brPersonajes();
            bePersonajes obePersonajes = new bePersonajes();

            obePersonajes.IdTipo = Convert.ToInt32(cboTipo.SelectedValue.ToString());
            obePersonajes.NombrePersonaje = txtNombrePersonaje.Text.Trim();
            obePersonajes.Nacionalidad = txtNacionalidad.Text.Trim();
            obePersonajes.FechaNac = Convert.ToDateTime(txtFechaNac.Text);
            obePersonajes.BreveHistoria = txtBreveHistoria.Text.Trim();

            bool result = obrPersonajes.RegistrarPersonaje(obePersonajes, ref Error);
            if (string.IsNullOrWhiteSpace(Error) & result == true)
            {
                MessageBox.Show("Personaje se ha Registrado Correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarTipo();
                dgvPersonajes.CurrentCell = dgvPersonajes.Rows[dgvPersonajes.Rows.Count - 1].Cells[0];
                ListaPersonajes();
            }
            else
            {
                MessageBox.Show("Ocurrió un error al registrar Personaje : " + Environment.NewLine + Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ActualizarPersonaje()
        {

            brPersonajes obrPersonajes = new brPersonajes();
            bePersonajes obePersonajes = new bePersonajes();

            obePersonajes.IdPersonaje = Convert.ToInt32(dgvPersonajes.CurrentRow.Cells["IdPersonaje"].Value);  
            obePersonajes.IdTipo = Convert.ToInt32(cboTipo.SelectedValue.ToString());
            obePersonajes.NombrePersonaje = txtNombrePersonaje.Text.Trim();
            obePersonajes.Nacionalidad = txtNacionalidad.Text.Trim();
            obePersonajes.FechaNac = Convert.ToDateTime(txtFechaNac.Text);
            obePersonajes.BreveHistoria = txtBreveHistoria.Text.Trim();

            bool act = obrPersonajes.ActualizarPersonaje(obePersonajes, ref Error);
            if (string.IsNullOrWhiteSpace(Error) & act == true)
            {
                MessageBox.Show("Se Actualizó correctamente", "aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //CargarNacionalidad();
                CargarTipo();

                DataGridViewTextBoxCell oCell;
                foreach (DataGridViewRow row in dgvPersonajes.Rows)
                {
                    int i = row.Index;
                    oCell = row.Cells["IdPersonaje"] as DataGridViewTextBoxCell;
                    int id_Personaje = Convert.ToInt32(oCell.Value.ToString());
                    if (obePersonajes.IdPersonaje == id_Personaje)
                    {
                        dgvPersonajes.CurrentCell = dgvPersonajes.Rows[i].Cells[0];
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("Ocurrió un error al actualizar Personaje : " + Environment.NewLine + Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ListaPersonajes();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (string.IsNullOrWhiteSpace(txtNombrePersonaje.Text))
                {
                    if (MessageBox.Show("¿Usted está seguro de Registrar Personaje?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.No)
                    {
                        GuardarPersonaje();
                    }
                }
                else
                {
                    if (MessageBox.Show("¿Usted está seguro de Modificar Personaje?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.No)
                    {
                        ActualizarPersonaje();
                    }
                }
                LimpiarCampos();
                

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error UI : " + Environment.NewLine + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void LimpiarCampos()
        {
            cboTipo.SelectedValue = 0;
            txtNombrePersonaje.Text = "";
            txtNacionalidad.Text = "";
            txtFechaNac.Text = "";
            txtBreveHistoria.Text = "";
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvPersonajes.CurrentRow != null)
            {
                txtIdPersonajeOculto.Text = dgvPersonajes.CurrentRow.Cells["IdPersonaje"].Value.ToString();
                if (!string.IsNullOrEmpty(txtIdPersonajeOculto.Text))
                {
                    cboTipo.SelectedValue = dgvPersonajes.CurrentRow.Cells["IdTipo"].Value;
                    txtNombrePersonaje.Text = dgvPersonajes.CurrentRow.Cells["NombrePersonaje"].Value.ToString();
                    txtNacionalidad.Text = dgvPersonajes.CurrentRow.Cells["Nacionalidad"].Value.ToString();
                    txtFechaNac.Text = dgvPersonajes.CurrentRow.Cells["FechaNac"].Value.ToString();
                    txtBreveHistoria.Text = dgvPersonajes.CurrentRow.Cells["BreveHistoria"].Value.ToString();
                                        

                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvPersonajes.CurrentRow != null)
            {
                if (MessageBox.Show("¿Usted está seguro que desea Eliminar DT?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.No)
                {
                    brPersonajes obrPersonajes = new brPersonajes();
                    bePersonajes obePersonajes = new bePersonajes();
                    obePersonajes.IdPersonaje = Convert.ToInt32(dgvPersonajes.CurrentRow.Cells["IdPersonaje"].Value.ToString());
                    bool act = obrPersonajes.EliminarPersonaje(obePersonajes, ref Error);
                    if (string.IsNullOrWhiteSpace(Error) & act == true)
                    {
                        MessageBox.Show("Personaje Eliminado Correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarTipo();
                        ListaPersonajes();
                    }
                    else
                    {
                        MessageBox.Show("Ocurrió un error al Eliminar Personaje : " + Environment.NewLine + Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void dgvPersonajes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnActualizar_Click(1, null);
        }

       
    }
}
