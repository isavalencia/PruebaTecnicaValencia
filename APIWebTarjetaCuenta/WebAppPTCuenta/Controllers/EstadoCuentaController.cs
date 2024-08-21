using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppPTCuenta.Models;

namespace WebAppPTCuenta.Controllers
{
    public class EstadoCuentaController : Controller
    {
        private ptcuentabancoEntities3 db = new ptcuentabancoEntities3();

        private readonly ptcuentabancoEntities3 _context;

        public EstadoCuentaController()
        {
            _context = new ptcuentabancoEntities3();
        }
        // GET: EstadoCuenta
        public ActionResult Index(int id_tarjeta)
        {
            var tarjeta = _context.tarjetas.Find(id_tarjeta);
            var transacciones = _context.transacciones.Where(t => t.id_tarjeta == id_tarjeta).ToList();

            if (tarjeta == null)
            {
                return HttpNotFound(); // Maneja el caso en que no se encuentra la tarjeta
            }
            //var saldoActual = CalcularSaldoActual(transacciones, tarjeta.saldo_inicial);

            var estadoCuenta = new EstadoCuenta
            {
               
                NombreCliente = tarjeta.nombre_cliente,
                NumeroTarjeta = tarjeta.num_tarjeta,
                SaldoInicial = tarjeta.saldo_inicial,
                Limite = tarjeta.limite_credito,
                NumeroAutorizacion = GenerarNumeroAutorizacion(),
                FechaTransaccion = transacciones.fecha_transaccion,
                SaldoActual = CalcularSaldoActual(transacciones, tarjeta.saldo_inicial),
                InteresBonificable = CalcularInteresBonificable(transacciones),
                CuotaMinimaAPagar = CalcularCuotaMinima(transacciones),
                MontoTotalAPagar = CalcularMontoTotalAPagar(transacciones),
                MontoTotalContadoConIntereses = CalcularMontoTotalContado(transacciones),
                SaldoDisponible = CalcularSaldoDisponible(transacciones, tarjeta.limite_credito, tarjeta.saldo_inicial),
                Transacciones = transacciones,
                TotalComprasDiciembre = CalcularTotalCompras(transacciones, 12),
                TotalComprasEnero = CalcularTotalCompras(transacciones, 1)
            };

           
            return View(estadoCuenta);
        }

        

        private decimal CalcularSaldoActual(List<Transacciones> transacciones, decimal saldo_inicial)
        {
            decimal saldoActual = saldo_inicial;
            foreach (var transaccion in transacciones)
            {
                if (transaccion.tipo == tipo_transaccion.Cargo)
                    saldoActual -= transaccion.monto;
                else if (transaccion.tipo == tipo_transaccion.Abono)
                    saldoActual += transaccion.monto;
            }
            return saldoActual;
        }

        private decimal CalcularInteresBonificable(decimal saldoActual)
        {
            return saldoActual * 0.25m;
        }

        private decimal CalcularCuotaMinima(decimal saldoActual)
        {
            return saldoActual * 0.05m;
        }

        private decimal CalcularMontoTotalAPagar(List<Transacciones> transacciones)
        {
           
            return transacciones.Where(t => t.tipo == tipo_transaccion.Cargo).Sum(t => t.monto);
        }

        private decimal CalcularMontoTotalContado(List<Transacciones> transacciones)
        {
           
            return transacciones.Where(t => t.tipo == tipo_transaccion.Cargo).Sum(t => t.monto);
        }

        private decimal CalcularSaldoDisponible(List<Transacciones> transacciones, decimal limiteCredito, decimal saldoInicial)
        {
           
            decimal saldoActual = CalcularSaldoActual(transacciones, saldoInicial);
            return limiteCredito - saldoActual;
        }

        private decimal CalcularTotalCompras(List<Transacciones> transacciones, int mes)
        {
            return transacciones.Where(t => t.fecha_transaccion.Month == mes && t.tipo == tipo_transaccion.Cargo).Sum(t => t.monto);
        }

        private string FormatearNumeroTarjeta(string numeroTarjeta)
        {
            if (numeroTarjeta.Length < 16) return numeroTarjeta;

            string primerosCuatro = numeroTarjeta.Substring(0, 4);
            string ultimosCuatro = numeroTarjeta.Substring(numeroTarjeta.Length - 4);

            return $"{primerosCuatro} **** **** {ultimosCuatro}";
        }

        private string GenerarNumeroAutorizacion()
        {
            return new Random().Next(100000, 999999).ToString();
        }

    }
}