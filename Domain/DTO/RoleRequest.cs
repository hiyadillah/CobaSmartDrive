using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class RoleRequest
    {
        public int? RoleID { get; set; }
        [StringLength(256)]
        public string? RoleName { get; set; }
        public int? UserId { get; set; }
    }
}
