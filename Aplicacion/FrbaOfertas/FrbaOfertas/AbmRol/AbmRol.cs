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
    public partial class AbmRol : Form
    {
        Usuario usuario;
        public AbmRol(Usuario _usuario)
        {
            InitializeComponent();
            usuario = _usuario;
        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }

        private void AbmRol_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            MenuAdministrador oc = new MenuAdministrador(usuario);
            oc.Show();
            this.Hide();
        }
    }
}
