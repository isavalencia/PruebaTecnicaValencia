using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace APIWebTarjetaCuenta.Models
{
    public class TarjetaData
    {
        public static bool Registrar(Tarjeta oTarjeta)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_addTarjeta", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@num_tarjeta", oTarjeta.num_tarjeta);
                cmd.Parameters.AddWithValue("@nombre_cliente", oTarjeta.nombre_cliente);
                cmd.Parameters.AddWithValue("@apellido_cliente", oTarjeta.apellido_cliente);
                cmd.Parameters.AddWithValue("@saldo_inicial", oTarjeta.saldo_inicial);
                cmd.Parameters.AddWithValue("@limite_credito", oTarjeta.limite_credito);


                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }

        }

        public static bool Modificar(Tarjeta oTarjeta)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_modificarTarjeta", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_tarjeta", oTarjeta.id_tarjeta);
                cmd.Parameters.AddWithValue("@num_tarjeta", oTarjeta.num_tarjeta);
                cmd.Parameters.AddWithValue("@nombre_cliente", oTarjeta.nombre_cliente);
                cmd.Parameters.AddWithValue("@apellido_cliente", oTarjeta.apellido_cliente);
                cmd.Parameters.AddWithValue("@saldo_inicial", oTarjeta.saldo_inicial);
                cmd.Parameters.AddWithValue("@limite_credito", oTarjeta.limite_credito);


                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }

            }

        }

        public static List<Tarjeta> Listar()
        {
            List<Tarjeta> oListarTarjeta = new List<Tarjeta>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_listarTarjeta", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    //cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oListarTarjeta.Add(new Tarjeta()
                            {
                                id_tarjeta = Convert.ToInt32(dr["id_tarjeta"]),
                                num_tarjeta = dr["num_tarjeta"].ToString(),
                                nombre_cliente = dr["nombre_cliente"].ToString(),
                                apellido_cliente = dr["apellido_cliente"].ToString(),
                                saldo_inicial = Convert.ToDecimal(dr["saldo_inicial"]),
                                limite_credito = Convert.ToDecimal(dr["limite_credito"])
                            });

                        }
                    }
                    return oListarTarjeta;

                }
                catch (Exception ex)
                {
                    return oListarTarjeta;
                }
            }
        }

        public static Tarjeta Obtener(int id_tarjeta)
        {
            Tarjeta oTarjeta = new Tarjeta();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_obtenerTarjeta", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_tarjeta", id_tarjeta);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oTarjeta = new Tarjeta()
                            {
                                id_tarjeta = Convert.ToInt32(dr["id_tarjeta"]),
                                num_tarjeta = dr["num_tarjeta"].ToString(),
                                nombre_cliente = dr["nombre_cliente"].ToString(),
                                apellido_cliente = dr["apellido_cliente"].ToString(),
                                saldo_inicial = Convert.ToDecimal(dr["saldo_inicial"]),
                                limite_credito = Convert.ToDecimal(dr["limite_credito"])
                            };
                        }

                    }
                    return oTarjeta;
                }
                catch (Exception ex)
                {
                    return oTarjeta;
                }
            }
        }

        public static bool Eliminar(int id)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_eliminarTarjeta", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_tarjeta", id);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }

            }
        }
    }
}