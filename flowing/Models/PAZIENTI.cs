using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace flowing
{
    public class PAZIENTI
    {

        public int IDPazienti { get; set; }
        public string Documentodidentità { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Telefono { get; set; }
        public string Città { get; set; }
        public DateTime Datadiaccettazione { get; set; }

    }
}