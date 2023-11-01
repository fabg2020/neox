using System;
using System.Collections.Generic;

namespace Neox.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            //OrderDetails = new HashSet<OrderDetail>();
        }

        public long Id { get; set; }
        public string? Nombre { get; set; }
        public long? Edad { get; set; }
        public string? Direccion { get; set; }
    

    }
}
