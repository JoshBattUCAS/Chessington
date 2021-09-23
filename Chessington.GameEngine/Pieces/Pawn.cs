using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Player player) 
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            Square currentPos = board.FindPiece(this);
            List<Square> moves = new List<Square>();
            Square newPos;

            if (Player == Player.White)
            {
                newPos = Square.At(currentPos.Row - 1, currentPos.Col);
            }
            else
            {
                newPos = Square.At(currentPos.Row + 1, currentPos.Col);
            }

            moves.Add(newPos);
            return moves;
        }
    }
}