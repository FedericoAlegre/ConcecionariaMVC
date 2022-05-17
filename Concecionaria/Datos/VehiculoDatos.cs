using Concecionaria.Models;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System;

namespace Concecionaria.Datos
{
    public class VehiculoDatos
    {
        public List<VehiculoModel> listar()
        {
            var oLista = new List<VehiculoModel>();

            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSql()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Listar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new VehiculoModel()
                        {
                            Id = Convert.ToInt32(dr["Id"]),
                            Marca = dr["Marca"].ToString(),
                            Modelo = dr["Modelo"].ToString(),
                            Año = Convert.ToInt32(dr["Año"]),
                            Kilometros = float.Parse(dr["Kilometros"].ToString()),
                            Precio = float.Parse(dr["Precio"].ToString()),
                        });
                    }
                } 
            }
            return oLista;
        }
        public VehiculoModel obtener(int id)
        {
            var oVehiculo = new VehiculoModel();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSql()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Obtener", conexion);
                cmd.Parameters.AddWithValue("Id", id);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oVehiculo.Id = Convert.ToInt32(dr["Id"]);
                        oVehiculo.Marca = dr["Marca"].ToString();
                        oVehiculo.Modelo = dr["Modelo"].ToString();
                        oVehiculo.Año = Convert.ToInt32(dr["Año"]);
                        oVehiculo.Kilometros = float.Parse(dr["Kilometros"].ToString());
                        oVehiculo.Precio = float.Parse(dr["Precio"].ToString());
                    }
                }
            }
            return oVehiculo;
        }

        public bool guardar(VehiculoModel oVehiculo)
        {
            bool rpt;
            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Guardar", conexion);
                    cmd.Parameters.AddWithValue("Marca", oVehiculo.Marca);                    
                    cmd.Parameters.AddWithValue("Modelo", oVehiculo.Modelo);
                    cmd.Parameters.AddWithValue("Año", oVehiculo.Año);
                    cmd.Parameters.AddWithValue("Kilometros", oVehiculo.Kilometros);
                    cmd.Parameters.AddWithValue("Precio", oVehiculo.Precio);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpt = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpt = false;                
            }
            
            return rpt;
        }

        public bool editar(VehiculoModel oVehiculo)
        {
            bool rpt;
            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Editar", conexion);
                    cmd.Parameters.AddWithValue("Id", oVehiculo.Id);
                    cmd.Parameters.AddWithValue("Marca", oVehiculo.Marca);
                    cmd.Parameters.AddWithValue("Modelo", oVehiculo.Modelo);
                    cmd.Parameters.AddWithValue("Año", oVehiculo.Año);
                    cmd.Parameters.AddWithValue("Kilometros", oVehiculo.Kilometros);
                    cmd.Parameters.AddWithValue("Precio", oVehiculo.Precio);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpt = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpt = false;
            }

            return rpt;
        }

        public bool eliminar(int id)
        {
            bool rpt;
            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Eliminar", conexion);
                    cmd.Parameters.AddWithValue("Id", id);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpt = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpt = false;
            }

            return rpt;
        }
    }
}
