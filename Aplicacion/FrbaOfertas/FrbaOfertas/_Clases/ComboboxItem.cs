using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas._Clases
{
    class ComboboxItem
    {
        public string text { get; set; }
        public object value { get; set; }
        public ComboboxItem(string _text, object _value)
        {
            text = _text;
            value = _value;
        }
        public override string ToString()
        {
            return text;
        }
    }
}
