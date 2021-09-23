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

            moves.AddRange(GetDiagMoves(board));
            moves.AddRange(GetLatMoves(board));

            return moves;
        }
    }
}