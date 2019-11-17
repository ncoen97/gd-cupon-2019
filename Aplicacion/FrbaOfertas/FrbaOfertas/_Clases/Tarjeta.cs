using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas
{
    public class Tarjeta
    {
        public int id { get; set; }
        public string numero { get; set; }
        public string titular { get; set; }
        public DateTime fecha_vencimiento { get; set; }

        public Tarjeta(int _id, string _numero, string _titular,DateTime _fechaVenc)
        {
            this.id = _id;
            this.numero = _numero;
            this.titular = _titular;
            this.fecha_vencimiento= _fechaVenc;
           
        }
        public Tarjeta(int _id, string _numero)
        {
            this.id = _id;
            this.numero = _numero;
        }

    }

}
