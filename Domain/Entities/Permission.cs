using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("Permission")]
    public class Permission
    {
        [Key]
        public int PermissionID { get; set; }
        [StringLength(10)]
        public string? PermissionType { get; set; }
        public int? RoleId { get; set; }
        public virtual Role? RoleEntity { get; set; }
    }
}
