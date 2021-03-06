﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas
{
    public partial class ConsumoOferta : Form
    {
        Usuario usuario;
        public ConsumoOferta(Usuario _usuario)
        {
            InitializeComponent();
            usuario = _usuario;
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            MenuFuncionalidades o = new MenuFuncionalidades(usuario);
            o.Show();
            this.Hide();
        }

        private void ConsumoOferta_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = utils.obtenerFecha();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!utils.validarEntradaSoloNumeros(textBox1) ||
            !utils.validarNoVacio(textBox1) ||
            !utils.validarNoVacio(textBox2))
            {
                MessageBox.Show("Campos vacios o tipo incorrecto: solo ingresar numeros");
                return;
            }

            if (!ClienteDAO.verificarExistenciaCliente(Convert.ToInt16(textBox1.Text)))
            {
                MessageBox.Show("No se encontro cliente");
                return;
            }
            
            if (!DBConnection.encontrar_cupon_para_canjear(int.Parse(textBox3.Text),textBox2.Text))
            {
                MessageBox.Show("No esta disponible el cupon");
                return;

            }
            
            DBConnection.canjear_cupon(int.Parse(textBox3.Text),textBox2.Text, Convert.ToInt16(textBox1.Text), dateTimePicker1.Value);

            MessageBox.Show("Cupon canjeado!");
            textBox1.Text = ""; textBox2.Text = ""; textBox3.Text = "";


        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
