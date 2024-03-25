using Domain.Entities;
using Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class PermissionRequest
    {
        public int? PermissionID { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public EnumPermissionType? PermissionType { get; set; }
        public int? RoleId { get; set; }
    }
}
