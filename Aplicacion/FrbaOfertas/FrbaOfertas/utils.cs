using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Windows.Forms;
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
    }
}
