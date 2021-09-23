using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class King : Piece
    {
        public King(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            Square currentPos = board.FindPiece(this);
            List<Square> moves = new List<Square>();

            int[] rows = { 1, 1, 0, -1, -1, -1, 0, 1 };
            int[] cols = { 0, 1, 1, 1, 0, -1, -1, -1 };

            for (int i = 0; i < rows.Length; i++)
            {
                moves.Add(Square.At(currentPos.Row + rows[i], currentPos.Col + cols[i]));
            }

            moves.RemoveAll(s => (s.Row < 0 || s.Row > 7 || s.Col < 0 || s.Col > 7));

            return moves;
        }
    }
}