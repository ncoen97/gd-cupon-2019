using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaOfertas.DAOs;

namespace FrbaOfertas
{
    public partial class MenuFuncionalidades : Form
    {
        private Usuario usuario;
        public MenuFuncionalidades(Usuario _usuario)
        {
            InitializeComponent();
            usuario = _usuario;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AbmCliente abmc = new AbmCliente(usuario);
            abmc.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AbmProveedor abmp = new AbmProveedor(usuario);
            abmp.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AbmRol abmr = new AbmRol(usuario);
            abmr.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            RegistroDeUsuario ru = new RegistroDeUsuario(0,usuario);
            ru.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            CrearOferta co = new CrearOferta(usuario);
            co.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Facturar f = new Facturar(usuario);
            f.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ListadoEstadistico le = new ListadoEstadistico(usuario);
            le.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            usuario = null;
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void MenuAdministrador_Load(object sender, EventArgs e)
        {
            UsuarioDAO.cargarRolesUsuario(usuario);
            foreach (Button button in this.Controls.OfType<Button>())
            { //Si hay alguna funcionalidad que coincide con un buton
                button.Visible = false;
            }
            label_credito.Visible = false;
            

            var texto_roles = new System.Text.StringBuilder();
            if (usuario.roles.Count == 1)
            {
                texto_roles.AppendLine("Tiene activado el rol: ");
            }
            else
            {
                texto_roles.AppendLine("Tiene activado los roles: ");
            }



            foreach (Rol rol in usuario.roles)
            {
                texto_roles.AppendLine(" " + rol.nombre);
                DBConnection.asociar_roles_x_funciones(rol);
                if (rol.funcionalidades.Exists(f => f.nombre.Contains("Comprar")))
                {
                    label_credito.Visible = true;
                    buttonCupones.Visible = true;

                }

                if (DBConnection.isAdmin(rol))
                {
                    button4.Visible = true;
                    button12.Visible = true;
                }


                if (DBConnection.isCliente(rol) && !ClienteDAO.esClienteHabilitado(usuario))
                {
                    button9.Enabled = false;
                    button10.Enabled = false;
                    MessageBox.Show("Tus funcionalidades como cliente estan restringidas. Si es un error, ponerse en contacto con un administrador");
                    
                }     

                if (DBConnection.isProveedor(rol) && !ProveedorDAO.esProveedorHabilitado(usuario))
                {
                    button5.Enabled = false;
                    MessageBox.Show("Tus funcionalidades como proveedor estan restringidas. Si es un error, ponerse en contacto con un administrador");
                    
                }     

                foreach (Funcionalidad f in rol.funcionalidades)
                {
                  
                    foreach (Button button in this.Controls.OfType<Button>())
                    { //Si hay alguna funcionalidad que coincide con un buton
                        button.Name = button.Text;
                        if (button.Name == f.nombre)
                        {
                            button.Visible = true;

                        }
                                
                    }
                }
            }
            btn_cerrarsesion.Visible = true;
            label3.Text = "Su usuario es: \n" + usuario.username;
            //get cliente de usuario
            label_credito.Text ="Su crédito es: \n" + ClienteDAO.montoUsuario(usuario).ToString();
            labelroles.Text = texto_roles.ToString();
            button8.Visible = true;
            button13.Visible = true;

        }

        private void button11_Click(object sender, EventArgs e)
        {
            ConsumoOferta co = new ConsumoOferta(usuario);
            co.Show();
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            CargarCredito cc = new CargarCredito(usuario);
            cc.Show();
            this.Hide();
           
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ComprarOferta co = new ComprarOferta(usuario);
            co.Show();
            this.Hide();
        }

        private void buttonCupones_Click(object sender, EventArgs e)
        {
            MisCupones mc = new MisCupones(usuario);
            mc.Show(); this.Hide();
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            CambiarContrasenia cc = new CambiarContrasenia(usuario);
            cc.Show();
            this.Hide();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            EstadoUsuarios eu = new EstadoUsuarios(usuario);
            eu.Show();
            this.Hide();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            RegistroDeUsuario ru = new RegistroDeUsuario(4, usuario);
            ru.Show();
            this.Hide();
        }

    }
}