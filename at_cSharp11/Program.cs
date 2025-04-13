using System;
using System.IO;

class Program
{
    static string arquivo = "contatos.txt";
    
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n=== Gerenciador de Contatos ===");
            Console.WriteLine("1 - Adicionar novo contato");
            Console.WriteLine("2 - Listar contatos cadastrados");
            Console.WriteLine("3 - Sair");
            Console.Write("Escolha uma opção: ");
            
            string opcao = Console.ReadLine();
            
            switch (opcao)
            {
                case "1":
                    Adicionar();
                    break;
                case "2":
                    ListaContato();
                    break;
                case "3":
                    Console.WriteLine("Encerrado");
                    return;
                default:
                    Console.WriteLine("Opção inválida! Tente novamente");
                    break;
            }
        }
    }

    static void Adicionar()
    {
        Console.Write("Nome: ");
        string nome = Console.ReadLine();

        Console.Write("Tel: ");
        string telefone = Console.ReadLine();

        Console.Write("Email: ");
        string email = Console.ReadLine();
        
        StreamWriter writer = new StreamWriter(arquivo, true);
        writer.WriteLine($"{nome}, {telefone}, {email}");
        writer.Close();
        
        Console.WriteLine("Contato cadastrado com sucesso!!");
    }

    static void ListaContato()
    {
        if (!File.Exists(arquivo) || new FileInfo(arquivo).Length == 0)
        {
            Console.WriteLine("Nenhum contato cadastrado");
            return;
        }
        
        StreamReader reader = new StreamReader(arquivo);
        Console.WriteLine("\nContatos cadastrados:");
        
        string linha;

        while ((linha = reader.ReadLine()) != null)
        {
            string[] dados = linha.Split(',');
            if (dados.Length == 3)
            {
                Console.WriteLine($"Nome: {dados[0]} | Tel: {dados[1]} | Email: {dados[2]}");
            }
            else
            {
                Console.WriteLine("Erro ao ler um contato. Formato invalido");
            }
        }
        
        reader.Close();
    }
}
