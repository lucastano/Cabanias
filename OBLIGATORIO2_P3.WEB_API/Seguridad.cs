using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Validations;
using OBLIGATORIO1_P3.LOGICANEGOCIO.Entidades;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace OBLIGATORIO2_P3.WEB_API
{
    public static class Seguridad
    {
        //responsabilidad de manejar el cifrado de los datos
        //passwordhash

        public static void CrearPasswordHash(string password,out byte[] passwordHash,out byte[] passwordSalt)
        {
            //usamos algoritmo de cifrado hmacsha512
            using (var hmac=new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                //recibe el password y lo computa en bytes
            }

        }

        //debe ser internal
        internal static string CrearToken(Usuario usuarioActual, IConfiguration configuration)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Email,usuarioActual.Mail.Mail),
                new Claim(ClaimTypes.Role,"Funcionario")
            };

            //generar clave secreta
            var claveSecreta = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(configuration.GetSection("AppSettings:SecretTokenKey").Value!));
            //generar credenciales 
            var credenciales = new SigningCredentials(claveSecreta,SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(claims: claims, expires: DateTime.Now.AddDays(1), signingCredentials: credenciales);
            var jwt= new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        internal static bool VerificarPasswordHash(string contrasena, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                
               var passwordHashCalculado = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(contrasena));
                return passwordHashCalculado.SequenceEqual(passwordHash);
                //recibe el password y lo computa en bytes
            }
        }
    }
}
