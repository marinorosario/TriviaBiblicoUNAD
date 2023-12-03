using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNashENGINE.Share.DTOs
{
    public class UserInfoDTO
    {
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        public string Pass { get; set; } = string.Empty;

        [Compare(nameof(Pass))]
        public string PassRetype { get; set; } = string.Empty;
    }
}
