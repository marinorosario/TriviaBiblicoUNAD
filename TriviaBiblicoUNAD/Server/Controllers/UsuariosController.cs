using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TriviaBiblicoUNAD.Shared.DTOs.Usuario;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TriviaBiblicoUNAD.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private IConfiguration _config;

        public UsuariosController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IConfiguration config)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _config = config;
        }

        // POST api/usuarios/crear
        [HttpPost("crear")]
        public async Task<ActionResult<UserTokenDTO>> Post([FromBody] UserInfoDTO usuarioInfo)
        {
            IdentityUser UsuarioIdentity = new IdentityUser
            {
                UserName = usuarioInfo.email,
                Email = usuarioInfo.email
            };

            var resultado = await _userManager.CreateAsync(UsuarioIdentity, usuarioInfo.password);
            if (resultado.Succeeded)
            {
                return CreadorDeToken(usuarioInfo);
            }
            else
            {
                return BadRequest(resultado.Errors.First());
            }
        }

        // POST api/usuarios/login
        [HttpPost("login")]
        public async Task<ActionResult<UserTokenDTO>> LoginAsync([FromBody] UserInfoDTO usuarioInfo)
        {
            var resultado = await _signInManager.PasswordSignInAsync(usuarioInfo.email, usuarioInfo.password, false, false);
            if (resultado.Succeeded)
            {
                return CreadorDeToken(usuarioInfo);
            }
            else
            {
                return BadRequest("Intento de login fallido");
            }
        }

        // GET api/usuarios/lista
        [HttpGet("lista")]
        public async Task<ActionResult<UserInfoDTO[]>> ListaUsuarios()
        {
            var resultado = await _userManager.Users.ToListAsync<IdentityUser>();

            return resultado.Select(x => new UserInfoDTO
            {
                email = x.Email ?? string.Empty,
                password = "secreto"
            }).ToArray();
        }

        private UserTokenDTO CreadorDeToken(UserInfoDTO usuarioInfo)
        {
            var claimsDelUsuario = new List<Claim>{
                new Claim(ClaimTypes.Name, usuarioInfo.email),
                new Claim(ClaimTypes.Role, "participante")
            };

            DateTime Expiracion = DateTime.UtcNow.AddHours(1); //Tiempo de vigencia del Token

            //Llave de entrada
            var llaveEntrada = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["jwtKey"] ?? string.Empty));

            //Credenciales de entrada
            var Credenciales = new SigningCredentials(llaveEntrada, SecurityAlgorithms.HmacSha256);
                      

            var JwtToken = new JwtSecurityToken(
                    issuer: null,
                    audience: null,
                    claims: claimsDelUsuario,
                    expires: Expiracion,
                    signingCredentials: Credenciales
                );
                       
            return new UserTokenDTO(new JwtSecurityTokenHandler().WriteToken(JwtToken), Expiracion);
        }
    }
}
