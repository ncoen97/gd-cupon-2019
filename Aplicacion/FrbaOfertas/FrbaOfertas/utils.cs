using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Windows.Forms;
using System.Drawing;

namespace FrbaOfertas
{
    class utils
    {
        public static DateTime obtenerFecha()
        {
            string sFecha = ConfigurationSettings.AppSettings["fecha"].ToString();
            DateTime fecha = DateTime.Now;
            try
            {
                fecha = DateTime.Parse(sFecha);
            }
            catch
            {
                MessageBox.Show("Error leyendo config, paso la fecha actual");
            }
            return fecha;
        }

        public static bool validarEntradaSoloTexto(TextBox txb)
        {
            int parsedValue;
            if (int.TryParse(txb.Text, out parsedValue))
            {
                txb.Text = "";
                txb.BackColor = Color.WhiteSmoke;
                return false;
            }
            txb.BackColor = Color.White;
            return true;
        }

        public static bool validarEntradaMail(TextBox txb)
        {
            if(!txb.Text.Contains("@") || !(txb.Text.Length >5)){
                txb.BackColor = Color.WhiteSmoke;
            return false;
            }
            txb.BackColor = Color.White;
            return true;
        }

        public static bool validarEntradaSoloNumeros(TextBox txb)
        {
            try
            {
                Convert.ToInt64(txb.Text);
            }
            catch (Exception ex)
            {
                
                return false;
            }
            return true;
        }

        public static bool validarEntradaComboBoxNoNull(ComboBox cbx)
        {
            
            if (cbx.SelectedValue==null)
            {
                cbx.BackColor = Color.WhiteSmoke;
                return false;
            }
            cbx.BackColor = Color.White;
            return true;
        }

        public static bool validarNoVacio(TextBox txb)
        {

            if (txb.Text == "")
            {
                txb.BackColor = Color.WhiteSmoke;
                return false;
            }
            txb.BackColor = Color.White;
            return true;
        }

    }
}
