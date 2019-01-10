using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bata.Clases
{
    public class OrderItem
    {
        private char[] delimitador = new char[1] { '?' };

        public OrderItem(char delimit)
        {
            this.delimitador = new char[1] { delimit };
        }

        public string GetItemCantidad(string orderItem)
        {
            return orderItem.Split(this.delimitador)[0];
        }

        public string GetItemName(string orderItem)
        {
            return orderItem.Split(this.delimitador)[1];
        }

        public string GetItemPrice(string orderItem)
        {
            return orderItem.Split(this.delimitador)[2];
        }

        public string GenerateItem(string cantidad, string itemName, string price)
        {
            return cantidad + (object)this.delimitador[0] + itemName + (object)this.delimitador[0] + price;
        }
    }
}
