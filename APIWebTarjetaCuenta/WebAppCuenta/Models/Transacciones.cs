using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppCuenta.Models
{
    public class Transacciones
    {
        public int id_transaccion { get; set; }
        public int id_tarjeta { get; set; }
        public DateTime fecha_transaccion { get; set; }
        public string descripcion { get; set; }
        public Decimal monto { get; set; }
        public tipo_transaccion tipo { get; set; }
    }
}