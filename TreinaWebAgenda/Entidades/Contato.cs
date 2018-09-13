using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreinaWebAgenda.Entidades
{
    public class Contato
    {
        public Contato(string nome = "", string telefone = "", string email = "")
        {
            this.Nome = nome;
            this.Telefone = telefone;
            this.Email = email;
        }

        public string Nome { get; set; }

        public string Telefone { get; set; }

        public string Email { get; set; }

        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}", this.Nome, this.Telefone, this.Email);
        }
    }
}
