using APPCRUD.Models;

namespace   APPCRUD.Data
{
    public class DA_Logica
    {
        public List<Usuario> ListaUsuario()
        {
            return new List<Usuario>
            {
                new Usuario { Nombre= "Joss", Correo="administrador@gmail.com" , Clave="123", Roles= new string[]{"Administrador" } },
                 new Usuario { Nombre= "Joshua", Correo="administrador2@gmail.com" , Clave="123", Roles= new string[]{"Administrador" } },
                  new Usuario { Nombre= "Vo", Correo="123@gmail.com" , Clave="123", Roles= new string[]{"Votante" } },
                   


            };
        }



        public Usuario ValidarUsuario(string _correo, string _clave)
        {
            return ListaUsuario().Where(item => item.Correo == _correo && item.Clave == _clave).FirstOrDefault();
        }

    }
}
