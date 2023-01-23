using System;
using System.Text.Json.Nodes;


namespace Exercicio_generics{
    class Program{
        public static void Main(){
            
            Dictionary<string,string> dicio = new Dictionary<string,string>();
            int opcao =10,cont=0;
            string palavra ,definicao,busca;
           
            string fileName = "generics.txt";
            if (File.Exists(fileName))
            {
                using (StreamReader sr = new StreamReader(fileName))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] parts = line.Split(':');
                        dicio.Add(parts[0], parts[1]);
                    }
                }
            }
            
            
            do {
                

                System.Console.WriteLine("Escolha uma opcao :");
                System.Console.WriteLine("[1] - Adicionar");
                System.Console.WriteLine("[2] - Buscar");
                System.Console.WriteLine("[3] - Sair");
                opcao = LerInteiro();
                cont=0;
                switch(opcao){
                    case 1:
                        do{
                            System.Console.WriteLine("Digite a palavra: ");
                            palavra = Console.ReadLine().ToLower();
                            if(palavra.Contains('*')||palavra.Contains('?')){
                                System.Console.WriteLine("ERRO ! PALAVRA CONTEM '*' OU '?'");
                            }
                        }while(palavra.Contains('*')||palavra.Contains('?')||dicio.ContainsKey(palavra)== true);
                        
                        System.Console.WriteLine("Digite a definicao:");
                        definicao = Console.ReadLine().ToLower();
                        dicio.Add(palavra,definicao);
                        
                    break;
                    case 2:
                        do{
                            System.Console.WriteLine("Qual palavra ou trecho de palavra deseja pesquisar");
                            busca = Console.ReadLine().ToLower();
                            if(busca.Contains('*')||busca.Contains('?')){
                                System.Console.WriteLine("ERRO ! PALAVRA CONTEM '*' OU '?'");
                            }
                        }while(busca.Contains('*')||busca.Contains('?'));

                        
                      
                        foreach (var item in dicio){
                            if(item.Key.Contains(busca)){
                                System.Console.WriteLine($"{item.Key}:{item.Value}");
                                cont++;
                            }
                            
                        }
                        if(cont==0){
                            System.Console.WriteLine("Nenhum termo encontrado");
                        }

                        
                        break;
                }
                
            }while(opcao!=3);
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                foreach (KeyValuePair<string, string> entry in dicio)
                {
                    sw.WriteLine(entry.Key + ":" + entry.Value);
                }
            }
        }
        public static int LerInteiro(){
            bool verificacao = false;
            int num;
            do{
                verificacao = int.TryParse(Console.ReadLine(), out  num);
                if(verificacao==false ){
                    Console.WriteLine("Erro! digite apenas os numeros das opcoes");
                }
            }while(verificacao==false && (num>3 || num <-1));
            return num;
        }
    }
}