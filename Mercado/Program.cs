using System;
using System.Collections.Generic;
using System.Linq;

namespace Mercado
{
    class Program
    {
        static List<Cadastrar> produtos = new List<Cadastrar>();

        static void Main(string[] args)
        {
            int opcao;

            do
            {
                Console.Clear();
                Console.WriteLine(" Sistema de Cadastro de Produtos ");
                Console.WriteLine("1. Cadastrar produto");
                Console.WriteLine("2. Listar produtos");
                Console.WriteLine("3. Filtrar produtos");
                Console.WriteLine("4. Sair");
                Console.Write("Escolha uma opção: ");

                if (!int.TryParse(Console.ReadLine(), out opcao)) opcao = -1;

                switch (opcao)
                {
                    case 1:
                        CadastrarProduto();
                        break;
                    case 2:
                        ListarProdutos(produtos);
                        break;
                    case 3:
                        FiltrarProdutos();
                        break;
                    case 4:
                        Console.WriteLine("Saindo...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }

                if (opcao != 4)
                {
                    Console.WriteLine("Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                }

            } while (opcao != 4);
        }

        static void CadastrarProduto()
        {
            Console.Clear();
            Console.WriteLine(" Cadastro de Produto ");

            Console.Write("Nome: ");
            string nome = Console.ReadLine();

            Console.Write("Categoria: ");
            string categoria = Console.ReadLine();

            Console.Write("Preço: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal preco))
            {
                Console.WriteLine("Preço inválido.");
                return;
            }

            Cadastrar prod = new Cadastrar
            {
                Nome = nome,
                Categoria = categoria,
                Preco = preco
            };

            produtos.Add(prod);
            Console.WriteLine("Produto cadastrado com sucesso!");
        }

        static void ListarProdutos(List<Cadastrar> lista)
        {
            Console.Clear();
            Console.WriteLine(" Lista de Produtos ");

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhum produto cadastrado.");
                return;
            }

            foreach (var produto in lista)
            {
                Console.WriteLine(produto);
            }
        }

        static void FiltrarProdutos()
        {
            Console.Clear();
            Console.WriteLine(" Filtro de Produtos ");

            Console.Write("Digite o termo de busca (nome ou categoria): ");
            string termo = Console.ReadLine().ToLower();

            var filtrados = produtos
                .Where(prod => prod.Nome.ToLower().Contains(termo) || prod.Categoria.ToLower().Contains(termo))
                .ToList();

            if (filtrados.Count == 0)
            {
                Console.WriteLine("Nenhum produto encontrado com esse filtro.");
            }
            else
            {
                ListarProdutos(filtrados);
            }
        }
    }
}
