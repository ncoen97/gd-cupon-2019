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

        public ComprarOferta()
        {
            InitializeComponent();
        }

        public ComprarOferta(Usuario _usuario)
        {
            InitializeComponent();
      
            usuario = _usuario;
        }

        private void ComprarOferta_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlConnection conexion = DBConnection.getConnection();
            DateTime hoy = utils.obtenerFecha();
            SqlCommand command = new SqlCommand("Select ofer_id, ofer_descripcion,ofer_fecha_vencimiento,ofer_precio_oferta,p.prov_razon_social from SOCORRO.Oferta o join SOCORRO.Proveedor p on o.ofer_prov_id = p.prov_id  where p.prov_habilitado=1 and o.ofer_fecha_vencimiento>@fecha", conexion);
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("@fecha", hoy);

            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;

            label2.Text = "su monto disponible es " + ClienteDAO.montoUsuario(usuario);
            this.dataGridView1.Columns["ofer_id"].Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MenuFuncionalidades reg = new MenuFuncionalidades(usuario);
            reg.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (selectedRow == null)
                return;
           int monto = (int)ClienteDAO.montoUsuario(usuario);
            if ( monto >= Convert.ToInt16(selectedRow.Cells["ofer_precio_oferta"].Value))
            {
            //ejecutar compra
            //entrada en cupon carpeta
            Cliente cliente = ClienteDAO.cliente_from_usuario(usuario);
            int id_prov = ProveedorDAO.obtenerProveedorIdConNombre(selectedRow.Cells["prov_razon_social"].Value.ToString());
            Proveedor prov = ProveedorDAO.obtenerProveedorConId(id_prov);
            Oferta oferta = DBConnection.oferta_por_id(selectedRow.Cells["ofer_id"].Value.ToString(),prov);
            Cupon cupon_comprado = new Cupon(DateTime.Today, oferta, cliente);
            //Cuando un cliente adquiere
            //   una oferta, se le deberá informar el código de compra  y se deberá validar 
            //   que la adquisición no supere la cantidad máxima de ofertas permitida por usuario.

            // Los datos mínimos a registrar son los siguientes:
            // Fecha de compra  Oferta  
            //   Nro de Oferta  Cliente que realizó la compra 
            DBConnection.agregar_cupon(cupon_comprado);
            MessageBox.Show("Cupon comprado. Ya podes encontrarlo en tus cupones");
             }
            else {

                MessageBox.Show("No tiene suficiente credito para comprar esta oferta");
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
    }
}
