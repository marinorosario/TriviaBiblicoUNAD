using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace TriviaBiblicoUNAD.Client.Auth
{
    public class ProveedorAutenticacionPrueba : AuthenticationStateProvider
    {
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {

            var Anonimo = new ClaimsIdentity();
            var UsuarioMarino = new ClaimsIdentity(new List<Claim>
            {
                new Claim("Numero","123456789"),
                new Claim("LugarNacimiento","Salcedo"),
                new Claim(ClaimTypes.Name,"Marino"),
                new Claim(ClaimTypes.Email,"marino.rosario@mail.com"),
                new Claim(ClaimTypes.Role, "admin")
            }, authenticationType: "prueba");
                       

            return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(UsuarioMarino)));
        }
    }
}
