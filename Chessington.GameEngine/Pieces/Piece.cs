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
            List<Square> blockedMoves = new List<Square>();

            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    if ((Square.At(x, y).Row - currentPos.Row == Square.At(x, y).Col - currentPos.Col || currentPos.Row - Square.At(x, y).Row == Square.At(x, y).Col - currentPos.Col) && currentPos != Square.At(x, y))
                    {
                        if (board.GetPiece(Square.At(x, y)) == null)
                        {
                            diagMoves.Add(Square.At(x, y));
                        }
                        else
                        {
                            blockedMoves.Add(Square.At(x, y));
                        }
                    }
                }
            }
            foreach (Square blockedMove in blockedMoves)
            {
                if (blockedMove.Col > currentPos.Col)
                {
                    if (blockedMove.Row > currentPos.Row)
                    {
                        diagMoves.RemoveAll(s => (s.Col > currentPos.Col) && (s.Row > currentPos.Row));
                    }
                    else
                    {
                        diagMoves.RemoveAll(s => (s.Col > currentPos.Col) && (s.Row < currentPos.Row));
                    }
  
                }

                else if (blockedMove.Col < currentPos.Col)
                {
                    if (blockedMove.Row > currentPos.Row)
                    {
                        diagMoves.RemoveAll(s => (s.Col < currentPos.Col) && (s.Row > currentPos.Row));
                    }
                    else
                    {
                        diagMoves.RemoveAll(s => (s.Col < currentPos.Col) && (s.Row < currentPos.Row));
                    }

                }

            }

            return diagMoves;
        }
        public List<Square> GetLatMoves(Board board)
        {
            Square currentPos = board.FindPiece(this);
            List<Square> latMoves = new List<Square>();
            List<Square> blockedMoves = new List<Square>();


            for (int i = 0; i < 8; i++)
            {
                if (currentPos.Col != i)
                {
                    if (board.GetPiece(Square.At(currentPos.Row, i)) == null)
                    {
                        latMoves.Add(Square.At(currentPos.Row, i));
                    }
                    else
                    {
                        blockedMoves.Add(Square.At(currentPos.Row, i));
                    }

                    
                }
                if (currentPos.Row != i)
                {
                    if (board.GetPiece(Square.At(i, currentPos.Col)) == null)
                    {
                        latMoves.Add(Square.At(i, currentPos.Col));
                    }
                    else
                    {
                        blockedMoves.Add(Square.At(i, currentPos.Col));
                    }
                }
            }

            //Removes Blocked Moves from List

            foreach (Square blockedMove in blockedMoves)
            {
                if (blockedMove.Col == currentPos.Col)
                {
                    if (blockedMove.Row < currentPos.Row)
                    {
                        latMoves.RemoveAll(s => (s.Row < currentPos.Row));
                    }
                    else
                    {
                        latMoves.RemoveAll(s => (s.Row > currentPos.Row));
                    }
                }

                else if (blockedMove.Row == currentPos.Row)
                {
                    if (blockedMove.Col < currentPos.Col)
                    {
                        latMoves.RemoveAll(s => (s.Col < currentPos.Col));
                    }
                    else
                    {
                        latMoves.RemoveAll(s => (s.Col > currentPos.Col));
                    }
                }

            }
            return latMoves;
        }
    }
}