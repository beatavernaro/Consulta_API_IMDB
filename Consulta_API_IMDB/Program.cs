namespace Consulta_API_IMDB
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("TOP 10 FILMES IMDB");
            APICall.Teste().GetAwaiter().GetResult();
            
		}

        
            
     }
            
}
    
