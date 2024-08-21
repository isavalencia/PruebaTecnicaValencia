using APIWebTarjetaCuenta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIWebTarjetaCuenta.Controllers
{
    public class TarjetaController : ApiController
    {
        // GET api/<controller>
        public List<Tarjeta> Get()
        {
            return TarjetaData.Listar();
        }

        // GET api/<controller>/5
        //retornando una tarjeta en especifico
        public Tarjeta Get(int id)
        {
            return TarjetaData.Obtener(id);
        }

        // POST api/<controller>
        public bool Post([FromBody] Tarjeta oTarjeta)
        {
            return TarjetaData.Registrar(oTarjeta);
        }

        // PUT api/<controller>/5
        // permite editar
        public bool Put([FromBody] Tarjeta oTarjeta)
        {
            return TarjetaData.Modificar(oTarjeta);
        }

        // DELETE api/<controller>/5
        public bool Delete(int id)
        {
            return TarjetaData.Eliminar(id);
        }
    }
}