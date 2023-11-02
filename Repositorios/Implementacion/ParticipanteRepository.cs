using AppCrud.Models;
using AppCrud.Repositorios.Contrato;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace AppCrud.Repositorios.Implementacion
{
    public class ParticipanteRepository : IGenericRepository<Participante>
    {
        private readonly string _cadenaSQL = "";
        public ParticipanteRepository(IConfiguration configuracion)
        {
            _cadenaSQL = configuracion.GetConnectionString("cadenaSQL");
        }

        public async Task<List<Participante>> Lista()
        {
            List<Participante> _lista = new List<Participante>();

            using (var conexion = new SqlConnection(_cadenaSQL))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ListaParticipantes", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = await cmd.ExecuteReaderAsync())
                {
                    while (await dr.ReadAsync())
                    {
                        _lista.Add(new Participante
                        {
                            idParticipante = Convert.ToInt32(dr["idParticipante"]),
                            nombreCompleto = dr["nombreCompleto"].ToString(),
                            refFormacion = new Formacion() {
                                idFormacion = Convert.ToInt32(dr["idFormacion"]),
                                nombre = dr["nombre"].ToString()
                            },
                            pesoyaltura = Convert.ToInt32(dr["pesoyaltura"]),
                            fechaContrato = dr["fechaContrato"].ToString(),
                        });
                    }

                }

            }

            return _lista;
        }
        public async Task<bool> Guardar(Participante modelo)
        {
            using (var conexion = new SqlConnection(_cadenaSQL)) {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_GuardarParticipante", conexion);
                cmd.Parameters.AddWithValue("nombreCompleto", modelo.nombreCompleto);
                cmd.Parameters.AddWithValue("idDepartamento", modelo.refFormacion.idFormacion);
                cmd.Parameters.AddWithValue("sueldo", modelo.pesoyaltura);
                cmd.Parameters.AddWithValue("fechaContrato", modelo.fechaContrato);
                cmd.CommandType = CommandType.StoredProcedure;

                int filas_afectadas = await cmd.ExecuteNonQueryAsync();

                if (filas_afectadas > 0)
                    return true;
                else
                    return false;
            }
        }

        public async Task<bool> Editar(Participante modelo)
        {
            using (var conexion = new SqlConnection(_cadenaSQL))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_EditarEmpleado", conexion);
                cmd.Parameters.AddWithValue("idEmpleado", modelo.idParticipante);
                cmd.Parameters.AddWithValue("nombreCompleto", modelo.nombreCompleto);
                cmd.Parameters.AddWithValue("idDepartamento", modelo.refFormacion.idFormacion);
                cmd.Parameters.AddWithValue("sueldo", modelo.pesoyaltura);
                cmd.Parameters.AddWithValue("fechaContrato", modelo.fechaContrato);
                cmd.CommandType = CommandType.StoredProcedure;

                int filas_afectadas = await cmd.ExecuteNonQueryAsync();

                if (filas_afectadas > 0)
                    return true;
                else
                    return false;
            }
        }

        public async Task<bool> Eliminar(int id)
        {
            using (var conexion = new SqlConnection(_cadenaSQL))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_EliminarParticipante", conexion);
                cmd.Parameters.AddWithValue("idParticipante", id);
                cmd.CommandType = CommandType.StoredProcedure;

                int filas_afectadas = await cmd.ExecuteNonQueryAsync();

                if (filas_afectadas > 0)
                    return true;
                else
                    return false;
            }
        }

     
    }
}
