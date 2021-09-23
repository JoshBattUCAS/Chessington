using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public abstract class Piece
    {
        protected Piece(Player player)
        {
            Player = player;
        }
        public int moveCounter { get; set; }

        public Player Player { get; private set; }

        public abstract IEnumerable<Square> GetAvailableMoves(Board board);

        public void MoveTo(Board board, Square newSquare)
        {
            var currentSquare = board.FindPiece(this);
            board.MovePiece(currentSquare, newSquare);
        }
        public List<Square> GetDiagMoves(Board board)
        {
            Square currentPos = board.FindPiece(this);
            List<Square> diagMoves = new List<Square>();

            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    if ((Square.At(x, y).Row - currentPos.Row == Square.At(x, y).Col - currentPos.Col || currentPos.Row - Square.At(x, y).Row == Square.At(x, y).Col - currentPos.Col) && currentPos != Square.At(x, y))
                    {
                        diagMoves.Add(Square.At(x, y));
                    }
                }
            }
            return diagMoves;
        }
        public List<Square> GetLatMoves(Board board)
        {
            Square currentPos = board.FindPiece(this);
            List<Square> latMoves = new List<Square>();

            for (int i = 0; i < 8; i++)
            {
                if (currentPos.Col != i)
                {
                    latMoves.Add(Square.At(currentPos.Row, i));
                }
                if (currentPos.Row != i)
                {
                    latMoves.Add(Square.At(i, currentPos.Col));
                }
            }
            return latMoves;
        }
    }
}