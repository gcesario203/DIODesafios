namespace fundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        private bool VeiculoJaEstaNoEstacionamento(string placa) => veiculos.Any(x => x.ToUpper() == placa.ToUpper());

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");

            var placa = Console.ReadLine();

            if (VeiculoJaEstaNoEstacionamento(placa))
            {
                System.Console.WriteLine("Veículo já se encontra estacionado");

                return;
            }

            veiculos.Add(placa);
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            var placa = Console.ReadLine();

            if (!VeiculoJaEstaNoEstacionamento(placa))
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
                return;
            }

            Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

            int horas = int.Parse(Console.ReadLine());
            decimal valorTotal = precoInicial + (precoPorHora * horas);

            veiculos.Remove(placa);

            Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");

                veiculos.ForEach(veiculo => System.Console.WriteLine(veiculo));
                return;

            }

            Console.WriteLine("Não há veículos estacionados.");
        }
    }
}