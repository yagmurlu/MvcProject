using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Dto
{
    public class AdminLoginDto
    {
        public string AdminUsername { get; set; }
        public string AdminPassword { get; set; }
        public string AdminRoleId { get; set; }
    }
}
