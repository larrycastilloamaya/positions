using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hikru.Positions.Domain.Entities
{
    public class Recruiter
    {
        public string Id { get; set; } = default!;
        public string Full_Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public DateTime? Created_At { get; set; }

    }
}
