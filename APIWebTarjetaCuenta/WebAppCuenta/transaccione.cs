//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebAppCuenta
{
    using System;
    using System.Collections.Generic;
    
    public partial class transaccione
    {
        public int id_transaccion { get; set; }
        public int id_tarjeta { get; set; }
        public System.DateTime fecha_transaccion { get; set; }
        public string descripcion { get; set; }
        public decimal monto { get; set; }
        public int tipo_transaccion { get; set; }
        public string num_autorizacion { get; set; }
    
        public virtual tarjeta tarjeta { get; set; }
    }
}