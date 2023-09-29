using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotheque
{
    internal class Livre
    {
        private string id;
        private string titre;

        public string Id { get => id; set => id = value; }
        public string Titre { get => titre; set => titre = value; }

        public Livre(string id, string titre)
        {
            this.id = id;
            this.titre = titre;
        }

        public override string ToString()
        {
            return titre;
        }
    }
}
