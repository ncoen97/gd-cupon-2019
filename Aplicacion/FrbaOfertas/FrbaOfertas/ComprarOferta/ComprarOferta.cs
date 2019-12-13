using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using FrbaOfertas.DAOs;

namespace FrbaOfertas
{
    public partial class ComprarOferta : Form
    {
     
        Usuario usuario;
        DataGridViewRow selectedRow = null;

        public ComprarOferta(Usuario _usuario)
        {
            InitializeComponent();
            usuario = _usuario;
        }       

        private void button2_Click(object sender, EventArgs e)
        {
            MenuFuncionalidades reg = new MenuFuncionalidades(usuario);
            reg.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (selectedRow == null) return;

            int resultado = DBConnection.comprarOferta(usuario, selectedRow.Cells["ofer_id"].Value.ToString());

            switch (resultado)
            {
                case -1:
                    MessageBox.Show("El usuario no existe");
                    break;
                case -2:
                    MessageBox.Show("El usuario no tiene permisos de compra");
                    break;
                case -3:
                    MessageBox.Show("Saldo insuficiente");
                    break;
                case -4:
                    MessageBox.Show("La oferta seleccionada no tiene mas stock");
                    break;
                case -5:
                    MessageBox.Show("Se exedio la cantidad maxima de esta oferta");
                    break;
                case -6:
                    MessageBox.Show("La oferta seleccionada caducó");
                    break;
                case -7:
                    MessageBox.Show("Error generando la compra, intente mas tarde");
                    break;
                default:
                    if(resultado>=0)
                    {
                        MessageBox.Show("Oferta comprada con exito. Su codigo de cupon es: "+resultado.ToString());
                        ComprarOferta co = new ComprarOferta(usuario);
                        co.Show();
                        this.Hide();
                    }
                    break;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                this.selectedRow = dataGridView1.Rows[index];
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MisCupones mc = new MisCupones(usuario);
            mc.Show(); this.Hide();
        }

        private void ComprarOferta_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlConnection conexion = DBConnection.getConnection();
            DateTime hoy = utils.obtenerFecha();
            SqlCommand command = new SqlCommand("Select ofer_id, ofer_descripcion [Descripcion],ofer_fecha_vencimiento [Fecha de Vencimiento], ofer_precio_lista [Precio original],ofer_precio_oferta [Precio de oferta],p.prov_razon_social [Proveedor] from SOCORRO.Oferta o join SOCORRO.Proveedor p on o.ofer_prov_id = p.prov_id  where p.prov_habilitado=1 and o.ofer_fecha_vencimiento>@fecha and o.ofer_stock>0 and o.ofer_habilitada=1", conexion);
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("@fecha", hoy);

            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            SqlDataAdapter adapter = new SqlDataAdapter();

            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;

            label2.Text = "su monto disponible es " + ClienteDAO.montoUsuario(usuario);
            this.dataGridView1.Columns["ofer_id"].Visible = false;
            dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        }

    
    }
}
