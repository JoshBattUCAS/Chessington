using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Queen : Piece
    {
        public Queen(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            Square currentPos = board.FindPiece(this);
            List<Square> moves = new List<Square>();

            //Rook Movement

            for (int i = 0; i < 8; i++)
            {
                if (currentPos.Col != i)
                {
                    moves.Add(Square.At(currentPos.Row, i));
                }
                if (currentPos.Row != i)
                {
                    moves.Add(Square.At(i, currentPos.Col));
                }
                    
            }

            //Bishop Movement

            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    if ((Square.At(x, y).Row - currentPos.Row == Square.At(x, y).Col - currentPos.Col || currentPos.Row - Square.At(x, y).Row == Square.At(x, y).Col - currentPos.Col) && currentPos != Square.At(x, y))
                    {
                        moves.Add(Square.At(x, y));
                    }
                }
            }
            return moves;
        }
    }
}