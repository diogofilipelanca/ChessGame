﻿using System.Text.Json;

namespace ChessGame {
    class Game
    {
        #region Variables

        protected static bool IsOn = false;

        protected string? move;

        public Player? player1 { get; set; } = new Player();
        public Player? player2 { get; set; } = new Player();

        public Board board = new Board();

        #endregion

        #region Functions

        private class SerializableGame {
            public Player? player1 { get; set; }
            public Player? player2 { get; set; }
            public List<List<SerializablePiece>>? board { get; set; }
        }
        private class SerializablePiece {
            public int x {  get; set; }
            public int y { get; set; }
            public Team Team { get; set; }
            public PieceType PieceType { get; set; }
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
        private void SaveGame() {
            List<List<SerializablePiece>> boardList = new List<List<SerializablePiece>>();

            for (int row = 0; row < board.board.GetLength(0); row++) {
                List<SerializablePiece> rowList = new List<SerializablePiece>();

                for (int col = 0; col < board.board.GetLength(1); col++) {
                    if (board.board[row, col] != null) {
                        SerializablePiece piece = new SerializablePiece {
                            x = board.board[row, col].position.x,
                            y = board.board[row, col].position.y,
                            Team = board.board[row, col].Team,
                            PieceType = board.board[row, col].PieceType
                        };
                        rowList.Add(piece);
                    } else {
                        rowList.Add(null);
                    }
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
        }
        public void LoadGame() {
            string json;
            if ((json = File.ReadAllText("game.json")) != string.Empty) {
                var jsonBody = JsonSerializer.Deserialize<SerializableGame>(json);

                var jsonboardList = jsonBody?.board;

                int rows = jsonboardList.Count;
                int cols = jsonboardList[0].Count;
                Piece[,] board = new Piece[8, 8];
                
                for (int row = 0; row < 8; row++) {
                    for (int col = 0; col < 8; col++) {
                        if (jsonboardList[row][col] != null) {
                            Piece piece = new Piece(jsonboardList[row][col].x, jsonboardList[row][col].y, jsonboardList[row][col].Team, jsonboardList[row][col].PieceType);
                            board[row, col] = piece;
                        }
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
        }
        public void GameCommand() {
            do {
                Console.WriteLine("\nDigite a jogada:");
                move = Console.ReadLine();

                var words = move.Split(' ');

                switch (words[0]) {
                    case "Move":
                        MovePiece(words[1], words[2]);
                        break;

                    case "Save":
                        SaveGame();
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

        private void MovePiece(string actualPosition, string toPosition) {
            Position piecePosition = DecodePosition(actualPosition);
            Piece piece = GetPieceFromPosition(piecePosition.x, piecePosition.y);

            switch (piece.PieceType) {
                case PieceType.Pawn:
                    break;
            }
        }

        private Piece GetPieceFromPosition(int x, int y) {
            return null;
        }

        private Position DecodePosition(string actualPosition) {
            actualPosition = actualPosition.Trim();

            return null;
        }

        #endregion
    }
}
