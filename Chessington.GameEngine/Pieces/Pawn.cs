﻿using System.Collections.Generic;
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
                if (board.GetPiece(Square.At(currentPos.Row - 1, currentPos.Col)) == null)
                {
                    if (this.moveCounter == 0 && board.GetPiece(Square.At(currentPos.Row - 2, currentPos.Col)) == null)
                    {
                        moves.Add(availablePos = Square.At(currentPos.Row - 2, currentPos.Col));
                    }

                    moves.Add(availablePos = Square.At(currentPos.Row - 1, currentPos.Col));
                }
            }
            else 
            {
                if (board.GetPiece(Square.At(currentPos.Row + 1, currentPos.Col)) == null)
                {
                    if (this.moveCounter == 0 && board.GetPiece(Square.At(currentPos.Row + 2, currentPos.Col)) == null)
                    {
                        moves.Add(availablePos = Square.At(currentPos.Row + 2, currentPos.Col));
                    }

                    moves.Add(availablePos = Square.At(currentPos.Row + 1, currentPos.Col));
                }
            }

            return moves;
        }

        
    }
}
