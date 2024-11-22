namespace MauiAppTempoAgoraLocal
{
    public partial class MainPage : ContentPage
    {
        private readonly TempoService _TempoService;
        private readonly DatabaseService _databaseService;

        public MainPage()
        {
            InitializeComponent();
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "TempoData.db");
            var databaseService = new DatabaseService(dbPath);
            _databaseService = new DatabaseService(dbPath);
            _TempoService = new TempoService();


        }

        private async void OnSearchClicked(object sender, EventArgs e)
        {
            string cidade = CidadeEntry.Text;
            if (string.IsNullOrEmpty(cidade)) 
            {
                TempoLabel.Text = "Por favor, digite o nome de uma cidade.";
                return;
            }

            var TempoData = await _TempoService.GetWeatherAsync(cidade);

            if (TempoData != null)
            {
                TempoLabel.Text = $"Cidade: {TempoData.Cidade}\n" +
                                    $"Temperatura: {TempoData.Temperatura}°C\n" +
                                    $"Descrição: {TempoData.Descricao}";
            }
            else
            {
                TempoLabel.Text = "Erro ao obter dados.";
            }

        }
    }

}
