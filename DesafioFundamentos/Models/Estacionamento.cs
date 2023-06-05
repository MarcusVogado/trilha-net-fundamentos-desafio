namespace DesafioFundamentos.Models
{
	public class Estacionamento
	{
		private decimal precoInicial = 0;
		private decimal precoPorHora = 0;
		private List<Veiculos> veiculos = new List<Veiculos>();

		public Estacionamento(decimal precoInicial, decimal precoPorHora)
		{
			this.precoInicial = precoInicial;
			this.precoPorHora = precoPorHora;
		}

		public void AdicionarVeiculo()
		{
			Veiculos veiculo = new Veiculos();
			Console.WriteLine("Digite a placa do veículo para estacionar:");
			veiculo.Placa = Console.ReadLine().ToUpper();
			var verificaVeiculo = VerificaVeiculoCadastrado(veiculo.Placa);
			if (!verificaVeiculo)
			{
				veiculos.Add(veiculo);
			}
			else
			{
				Console.WriteLine("Este Veiculo já está cadastrado em nosso Sistema");
			}

		}

		public void RemoverVeiculo()
		{
			Console.WriteLine("Digite a placa do veículo para remover:");
			var placaInformada = Console.ReadLine();
			Veiculos veiculoResult = veiculos.FirstOrDefault(x => x.Placa == placaInformada.ToUpper());
			if (veiculoResult != null)
			{
				Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
				int horas = Convert.ToInt32(Console.ReadLine());
				decimal valorTotal = precoInicial + precoPorHora * horas;
				veiculos.Remove(veiculoResult);
				Console.WriteLine($"O veículo {placaInformada} foi removido e o preço total foi de: R$ {valorTotal}");
			}
			else
			{
				Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
			}
		}

		public void ListarVeiculos()
		{
			if (veiculos.Any())
			{
				Console.WriteLine("Os veículos estacionados são:");
				foreach (var veiculo in veiculos)
				{
					Console.WriteLine(veiculo.Placa);
				}
			}
			else
			{
				Console.WriteLine("Não há veículos estacionados.");
			}
		}

		public bool VerificaVeiculoCadastrado(string placaInformada)
		{
			Veiculos veiculoResult = veiculos.FirstOrDefault(x => x.Placa == placaInformada.ToUpper());
			if (veiculoResult != null)
			{
				return true;
			}
			return false;
		}
	}
}
