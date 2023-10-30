namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private readonly decimal precoInicial = 0;
        private readonly decimal precoPorHora = 0;
        private readonly List<string> veiculos = new();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.Write("Digite a placa do veículo para estacionar: ");
            this.veiculos.Add(ReadLine());

        }

        public void RemoverVeiculo()
        {
            Console.Write("Digite a placa do veículo para remover: ");
            string placa = ReadLine();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.Write("Digite a quantidade de horas que o veículo permaneceu estacionado: ");
                int horas = int.Parse(ReadLine());

                decimal valorTotal = this.precoInicial + (this.precoPorHora * horas);

                this.veiculos.Remove(placa);

                Console.WriteLine($"O veículo \"{placa}\" foi removido e o preço total foi de R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");

                for(int i = 0; i < this.veiculos.Count; i++){
                    Console.WriteLine(i+1 + ". " + this.veiculos[i]);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }

        private static String ReadLine(){
            return Console.ReadLine();
        }
    }
}
