using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bata.Clases
{
    public class OrderTotal
    {
        private char[] delimitador = new char[1] { '?' };

        public OrderTotal(char delimit)
        {
            this.delimitador = new char[1] { delimit };
        }

        public string GetTotalName(string totalItem)
        {
            return totalItem.Split(this.delimitador)[0];
        }

        public string GetTotalCantidad(string totalItem)
        {
            return totalItem.Split(this.delimitador)[1];
        }

        public string GenerateTotal(string totalName, string price)
        {
            return totalName + (object)this.delimitador[0] + price;
        }
    }
}
