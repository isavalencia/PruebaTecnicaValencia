using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppCuenta.Models
{
    public class Tarjeta
    {
            public int id_tarjeta { get; set; }
            public string num_tarjeta { get; set; }
            public string nombre_cliente { get; set; }
            public string apellido_cliente { get; set; }
            public Decimal saldo_inicial { get; set; }
            public Decimal limite_credito { get; set; }
        
    }
}