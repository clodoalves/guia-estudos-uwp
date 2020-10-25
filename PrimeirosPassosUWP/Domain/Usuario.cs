using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Usuario
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Sexo { get; set; }
        public DateTimeOffset DataNascimento { get; set; }
    }
}
