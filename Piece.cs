using System;
using System.Collections.Generic;

namespace ChessGame {
    public class Piece {
        public int X { get; set; }
        public int Y { get; set; }
        public Team Team { get; set; }
        public PieceType PieceType { get; set; }

        public Piece(int x, int y, Team team, PieceType pieceType) {
            this.X = x;
            this.Y = y;
            this.Team = team;
            this.PieceType = pieceType;
        }

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
    }

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
}

/*private void CalculateMoves(int rookx, int rooky) {
            List<string> moves = new List<string>();

            for (char x = 'a'; x < 'i'; x++) {
                if (rookx != x) {
                    moves.Add($"{x}{rooky}");
                }
            }
            Console.WriteLine(moves);*/