using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trainmate.Repositories.Entities
{
    public partial class User : EntityBase
    {
        public String UserName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? address { get; set; }
        

    }
}
