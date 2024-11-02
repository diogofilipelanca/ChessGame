using System.Text.Json;

namespace ChessGame
{
    class Player
    {

        #region Variables

        public string? name { get; set;}
        public int? vitorias {get; set;} = 0;
        public int? derrotas { get; set;} = 0;
        public int? jogos {get; set;} = 0;

        #endregion

        #region Static Variables

        protected static string file = "players.json";

        public static List<Player> listplayers = new List<Player>();

        #endregion

        #region Functions

        public static void RegisterPlayer(string name)
        {
            Player player = new Player();
            player.name = name;

            listplayers.Add(player);

            
            JsonSerializerOptions options = new JsonSerializerOptions();
            options.WriteIndented = true;
            string jsonBody = JsonSerializer.Serialize(listplayers, options);
            File.WriteAllText(file, jsonBody);
        }

        public static void ShowAllPlayers(){
            if (listplayers.Count == 0) {
                Console.WriteLine("\nNenhum Jogador registado.\n");
            }
            else { 
                Console.WriteLine("\n");
                listplayers.ForEach(x => Console.WriteLine($"Nome: {x.name} | Vitórias: {x.vitorias} | Derrotas: {x.derrotas} | Jogos: {x.jogos} \n"));
            }
        }

        public static void LoadPlayersList() {
            if (listplayers.Count == 0){
                string json = File.ReadAllText(file);
                if (json != string.Empty){
                    var jsonBody = JsonSerializer.Deserialize<List<Player>>(json);
                    listplayers.AddRange(jsonBody);
                }
            }
        }

        #endregion
    }
}
