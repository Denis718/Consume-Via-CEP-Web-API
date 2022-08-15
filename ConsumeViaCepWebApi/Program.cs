using System.Text.Json;

namespace ConsumeViaCepWebApi
{
    class Program
    {
        static async Task Main(string[] args)
        {

            var BaseAddress = new Uri("https://viacep.com.br/ws/");
            
            HttpClient client = new HttpClient();

            client.BaseAddress = BaseAddress;

            Console.Write("Informe o CEP de consulta (somente números): ");
            var cep = Console.ReadLine();

            HttpResponseMessage response = await client.GetAsync(cep + "/json/");

            var dados = await response.Content.ReadAsStringAsync();
            var jsonDados = JsonSerializer.Deserialize<ViaCEP>(dados);

            if(jsonDados != null)
            {
                Console.WriteLine($"CEP: {jsonDados.cep}");
                Console.Write($"Logradouro: {jsonDados.logradouro}");
                Console.WriteLine($"{jsonDados.complemento}");
                Console.WriteLine($"Bairro: {jsonDados.bairro}");
                Console.WriteLine($"Localidade: {jsonDados.localidade}");
                Console.WriteLine($"UF: {jsonDados.uf}");
                Console.WriteLine($"IBGE: {jsonDados.ibge}");
                Console.WriteLine($"GIA: {jsonDados.gia}");
                Console.WriteLine($"DDD: {jsonDados.ddd}");
                Console.WriteLine($"SIAFI: {jsonDados.siafi}");
            }
        }
    }
}

// reference https://docs.microsoft.com/pt-br/dotnet/standard/serialization/system-text-json-how-to?pivots=dotnet-6-0