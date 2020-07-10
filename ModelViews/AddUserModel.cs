using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestionFacturation.Api.ModelViews
{
    public class AddUserModel
    {

        [StringLength(120), Required ]
        public string Email { get; set; }

        [StringLength(120), Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        public string PhoneNumber { get; set; }

    }
}
