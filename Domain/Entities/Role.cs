using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("Role")]
    public class Role
    {
        [Key]
        public int RoleID { get; set; }
        [StringLength(256)]
        public string? RoleName { get; set; }
        public int? UserId { get; set; }
        public virtual User? Userentity { get; set; }
    }
}
