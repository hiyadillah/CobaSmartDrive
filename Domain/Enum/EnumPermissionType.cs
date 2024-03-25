using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enum
{
    public enum EnumPermissionType
    {
        [EnumMember(Value ="READ")]
        READ,
        [EnumMember(Value ="READ_WRITE")]
        READ_WRITE,
    }
}
