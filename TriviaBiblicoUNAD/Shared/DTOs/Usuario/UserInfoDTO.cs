using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaBiblicoUNAD.Shared.DTOs.Usuario
{
    public class UserInfoDTO
    {
        [EmailAddress] public string email { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
    }
}
