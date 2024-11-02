using System.Text.Json;

namespace ChessGame {
    class Game
    {
        protected static bool IsOn = false;

        protected string? move;

        public Player? player1 { get; set; } = new Player();
        public Player? player2 { get; set; } = new Player();

        public Board board = new Board();

        private class SerializableGame {
            public Player? player1 { get; set; }
            public Player? player2 { get; set; }
            public List<List<string>>? board { get; set; }
        }
        public void StartGame(string player1name, string player2name) {
            IsOn = true;

            player1 = Player.listplayers.Find(player => player.name == player1name);
            player2 = Player.listplayers.Find(player => player.name == player2name);

            Console.Clear();

            board.CreateBoard();

            board.DrawBoard(board.board);

            GameCommand();
        }
        /*private void SaveGame() {
            List<List<string>> boardList = new List<List<string>>();

            for (int row = 0; row < board.board.GetLength(0); row++) {
                List<string> rowList = new List<string>();
                for (int col = 0; col < board.board.GetLength(1); col++) {
                    rowList.Add(board.board[row, col]);
                }
                boardList.Add(rowList);
            }

            var serializableGame = new {
                player1,
                player2,
                board = boardList
            };

            JsonSerializerOptions options = new JsonSerializerOptions();
            options.WriteIndented = true;
            string jsonBody = JsonSerializer.Serialize(serializableGame, options);
            File.WriteAllText("game.json", jsonBody);
        }*/
        /*public void LoadGame() {
            string json;
            if ((json = File.ReadAllText("game.json")) != string.Empty) {
                List<List<string>> boardList = new List<List<string>>();

                var jsonBody = JsonSerializer.Deserialize<SerializableGame>(json);

                var jsonboardList = jsonBody?.board;
                int rows = jsonboardList.Count;
                int cols = jsonboardList[0].Count;
                string[,] board = new string[8, 8];
                
                for (int row = 0; row < 8; row++) {
                    for (int col = 0; col < 8; col++) {
                        board[row, col] = jsonboardList[row][col];
                    }
                }

                player1 = jsonBody?.player1;
                player2 = jsonBody?.player2;
                this.board.board = board;

                Console.Clear();

                this.board.DrawBoard(board);

                GameCommand();

            } else {
                Console.WriteLine("Não foi possível encontrar jogo");
            }
        }*/
        public void GameCommand() {
            do {
                Console.WriteLine("\nDigite a jogada:");
                move = Console.ReadLine();

                var words = move.Split(' ');

                switch (words[0]) {
                    case "Save":
                        //SaveGame();
                        break;
                    case "Exit":
                        Console.Clear();

                        Console.WriteLine("Commands:");
                        Console.WriteLine("--> RJ <nome> (Criar Jogador)");
                        Console.WriteLine("--> LJ (Ver todos os Jogadores)");
                        Console.WriteLine("--> Start <Jogador 1> <Jogador 2>");
                        Console.WriteLine("--> Load (Load do Jogo anterior)");
                        Console.WriteLine("--> Exit (Saír do Jogo)");
                        break;
                }
            } while (move != "Exit");
        }
    }
}
