using AppCrud.Models;
using AppCrud.Repositorios.Contrato;
using System.Data;
using System.Data.SqlClient;

namespace AppCrud.Repositorios.Implementacion
{
    public class DepartamentoRepository : IGenericRepository<Formacion>
    {
        private readonly string _cadenaSQL = "";
        public DepartamentoRepository(IConfiguration configuracion)
        {
            _cadenaSQL = configuracion.GetConnectionString("cadenaSQL");
        }

        public async Task<List<Formacion>> Lista()
        {
            List<Formacion> _lista = new List<Formacion>();

            using (var conexion = new SqlConnection(_cadenaSQL)) { 
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ListaFormacion", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = await cmd.ExecuteReaderAsync()) {
                    while (await dr.ReadAsync()) {
                        _lista.Add(new Formacion
                        {
                            idFormacion = Convert.ToInt32(dr["idFormacion"]),
                            nombre = dr["nombre"].ToString()
                        });
                    }

                }

            }

            return _lista;
        }

        public Task<bool> Editar(Formacion modelo)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Guardar(Formacion modelo)
        {
            throw new NotImplementedException();
        }

     
    }
}
