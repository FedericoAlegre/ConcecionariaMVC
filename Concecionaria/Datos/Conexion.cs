using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace Concecionaria.Datos
{
    public class Conexion
    {
        private string cadenaSql = string.Empty;

        public Conexion()
        {            
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            cadenaSql = builder.GetSection("ConnectionStrings:CadenaSql").Value;
        }

        public string getCadenaSql()
        {
            return cadenaSql;
        }
    }
}
