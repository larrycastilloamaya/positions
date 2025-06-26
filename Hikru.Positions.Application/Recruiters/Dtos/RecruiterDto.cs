using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hikru.Positions.Application.Recruiters.Dtos
{
    public class RecruiterDto
    {
        public string Id { get; set; } = default!;
        public string Full_Name { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Phone { get; set; } = default!;
        public DateTime? Created_At { get; set; }
    }
}
