namespace ChessGame {

    #region Classes

    public class Piece {

        #region Variables

        public Position position = new Position();
        public Team Team { get; set; }
        public PieceType PieceType { get; set; }

        #endregion

        #region Constructors

        public Piece(int x, int y, Team team, PieceType pieceType) {
            position.x = x;
            position.y = y;
            Team = team;
            PieceType = pieceType;
        }

        #endregion

        #region Functions

        public string GetIcon() {
            return (Team == Team.White) ? GetWhiteIcon() : GetBlackIcon();
        }

        private string GetWhiteIcon() {
            return PieceType switch {
                PieceType.Pawn => "♙",
                PieceType.Rook => "♖",
                PieceType.Knight => "♘",
                PieceType.Bishop => "♗",
                PieceType.Queen => "♕",
                PieceType.King => "♔",
                _ => "."
            };
        }

        private string GetBlackIcon() {
            return PieceType switch {
                PieceType.Pawn => "♟",
                PieceType.Rook => "♜",
                PieceType.Knight => "♞",
                PieceType.Bishop => "♝",
                PieceType.Queen => "♛",
                PieceType.King => "♚",
                _ => "."
            };
        }

        #endregion
    }

    public class Position() {
        public int x { get; set; } = 0;
        public int y { get; set; }
    }

    #endregion

    #region Enums

    public enum Team {
        White,
        Black
    }

    public enum PieceType {
        Pawn,
        Rook,
        Knight,
        Bishop,
        Queen,
        King
    }

    #endregion
}