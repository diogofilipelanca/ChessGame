namespace ChessGame 
{
    class Board
    {
        public Piece[,] board { get; set; } = new Piece[8, 8];

        public void CreateBoard() {
            // Initialize pieces for both teams
            InitializePieces(Team.White);
            InitializePieces(Team.Black);

            // Fill empty squares with null (optional, as they will default to null)
            for (int row = 0; row < 8; row++) {
                for (int col = 0; col < 8; col++) {
                    if (board[row, col] == null) {
                        board[row, col] = null; // Explicitly stating null for clarity
                    }
                }
            }
        }
        private void InitializePieces(Team team) {
            int row = (team == Team.White) ? 0 : 7;
            int pawnRow = (team == Team.White) ? 1 : 6;

            // Create Rooks
            board[row, 0] = new Piece(0, row, team, PieceType.Rook);
            board[row, 7] = new Piece(7, row, team, PieceType.Rook);

            // Create Knights
            board[row, 1] = new Piece(1, row, team, PieceType.Knight);
            board[row, 6] = new Piece(6, row, team, PieceType.Knight);

            // Create Bishops
            board[row, 2] = new Piece(2, row, team, PieceType.Bishop);
            board[row, 5] = new Piece(5, row, team, PieceType.Bishop);

            // Create Queen and King
            board[row, 3] = new Piece(3, row, team, PieceType.Queen);
            board[row, 4] = new Piece(4, row, team, PieceType.King);

            // Create Pawns
            for (int col = 0; col < 8; col++) {
                board[pawnRow, col] = new Piece(col, pawnRow, team, PieceType.Pawn);
            }
        }
        public void DrawBoard(Piece[,] board)
        {
            Console.WriteLine("  a b c d e f g h");
            Console.WriteLine(" +-----------------+");
            for (int row = 0; row < 8; row++)
            {
                Console.Write((8 - row) + "|");
                for (int col = 0; col < 8; col++)
                {
                    Console.Write((board[row, col]?.GetIcon() ?? ".") + " ");
                }
                Console.WriteLine("| " + (8 - row));
            }
            Console.WriteLine(" +-----------------+");
            Console.WriteLine("  a b c d e f g h \n\n");
        }
    }
}
