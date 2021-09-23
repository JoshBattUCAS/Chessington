using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Rook : Piece
    {
        public Rook(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            Square currentPos = board.FindPiece(this);
            List<Square> moves = new List<Square>();

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

            return moves;
        }
    }
}