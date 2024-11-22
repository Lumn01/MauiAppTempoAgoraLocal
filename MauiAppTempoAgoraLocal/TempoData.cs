using SQLite;

namespace MauiAppTempoAgoraLocal
{
    public class TempoData
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Cidade { get; set; }
        public string Temperatura { get; set; }
        public string Descricao { get; set; }
        public DateTime QueryDate { get; set; }
    }

}
