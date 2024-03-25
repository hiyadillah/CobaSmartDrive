using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class UserRequest
    {
        public int? UserID { get; set; }
        [StringLength(256)]
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}
