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
            Square availablePos;

            if (Player == Player.White)
            {
                if (currentPos.Row > 0 && board.GetPiece(Square.At(currentPos.Row - 1, currentPos.Col)) == null )
                {
                    if (this.moveCounter == 0 && currentPos.Row > 1 && board.GetPiece(Square.At(currentPos.Row - 2, currentPos.Col)) == null)
                    {
                        System.Console.WriteLine("add 1");
                        moves.Add(availablePos = Square.At(currentPos.Row - 2, currentPos.Col));
                    }
                    
                    System.Console.WriteLine("add 2");
                    moves.Add(availablePos = Square.At(currentPos.Row - 1, currentPos.Col));
                    
                }
            }
            else 
            {
                if (currentPos.Row < 7 && board.GetPiece(Square.At(currentPos.Row + 1, currentPos.Col)) == null )
                {
                    if (this.moveCounter == 0 && currentPos.Row < 6 && board.GetPiece(Square.At(currentPos.Row + 2, currentPos.Col)) == null)
                    {
                        System.Console.WriteLine("add 3");
                        moves.Add(availablePos = Square.At(currentPos.Row + 2, currentPos.Col));
                    }

                    System.Console.WriteLine("add 4");
                    moves.Add(availablePos = Square.At(currentPos.Row + 1, currentPos.Col));
                    
                }
            }

            foreach (Square move in moves)
            {
                System.Console.WriteLine(" MOVES : " + move);
            }

            return moves;
        }

        
    }
}
