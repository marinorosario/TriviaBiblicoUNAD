using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaBiblicoUNAD.Shared.DTOs.Usuario
{
    public class UserTokenDTO
    {
        public UserTokenDTO(string token, DateTime expiration)
        {
            Token = token;
            Expiration = expiration;
        }

        public string Token { get; set; } = string.Empty;
        public DateTime Expiration { get; set; }
    }
}
