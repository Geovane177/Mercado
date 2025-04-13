using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercado
{
    internal class Cadastrar
    {
        public string Nome { get; set; }
        public string Categoria { get; set; }
        public decimal Preco { get; set; }

        public override string ToString()
        {
            return $"Nome: {Nome} | Categoria: {Categoria} | Preço: R$ {Preco:F2}";
        }
    }
}


    

