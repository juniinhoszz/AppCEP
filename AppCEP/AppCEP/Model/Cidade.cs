using System;
using System.Collections.Generic;
using System.Text;

namespace AppCEP.Model
{
    public class Cidade
    {
        public string id_cidade { get; set; }
        public string descricao { get; set; }
        public string uf { get; set; }
        public string codigo_ibge { get; set; }
        public string ddd { get; set; }
    }
}
