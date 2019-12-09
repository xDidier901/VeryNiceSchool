using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    public class Select2ItemDTO
    {
        public int id { get; set; }
        public string text { get; set; }
        public bool selected { get; set; }
        public bool disabled { get; set; }
    }
}
