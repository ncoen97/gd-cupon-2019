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
    public partial class RegistroDeCliente : Form
    {
        public RegistroDeCliente()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //validar todos los campos
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AbmCliente abmc = new AbmCliente();
            abmc.Show();
            this.Hide();
        }
    }
}