﻿using System;
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
    public partial class CargaTarjeta : Form
    {
        Usuario usuario;
        public CargaTarjeta(Usuario _usuario)
        {
            InitializeComponent();
            usuario = _usuario;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonCargar_Click(object sender, EventArgs e)
        {
            //faltan un monton de chequeos. de que la tarjeta que no tenga letras, que el mes y año sea futuro,
            //el nombre este lleno etc
            if (comboBoxAnio.SelectedItem == null ||comboBoxMes.SelectedItem==null)
            {
                MessageBox.Show("Faltan cargar datos");
                return;
            }
                
 
            int mes = comboBoxMes.SelectedIndex+1;
            int anio;
            Int32.TryParse(comboBoxAnio.SelectedItem.ToString(), out anio);

                
            bool resultado = ClienteDAO.cargarTarjeta(usuario,textBoxNumeroDeTarjeta.Text,mes,anio,textBoxNombreDelTitular.Text);
            if (resultado)
            {
                MessageBox.Show("Tarjeta cargada correctamente");
                CargarCredito c = new CargarCredito(usuario);
                c.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hubo un error cargando la tarjeta, chequee los datos e intente nuevamente");
            }
       }

        private void CargaTarjeta_Load(object sender, EventArgs e)
        {
            var month = System.Globalization.DateTimeFormatInfo.InvariantInfo.MonthNames;
            comboBoxMes.DataSource = month;
            for (int i = DateTime.UtcNow.Year; i <= DateTime.UtcNow.Year+10; i++)
            {
                comboBoxAnio.Items.Add(i);
            }
        }

        private void comboBoxMes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            CargarCredito c = new CargarCredito(usuario);
            c.Show();
            this.Hide();
        }
    }
}