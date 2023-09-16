using System;
using System.Collections.Generic;
using App.Scripts.Scenes.SceneChess.Features.GridNavigation.Navigator.MoveCalculators.Abstract;
using UnityEngine;

namespace App.Scripts.Scenes.SceneChess.Features.GridNavigation.Navigator.MoveCalculators
{
    public class LMoveCalculator : MoveCalculatorBase
    {
        public override List<Vector2Int> GetPossibleMoves(Vector2Int from)
        {
            var moves = new List<Vector2Int>();

            for (int x = -2; x <= 2; x++)
            {
                for (int y = -2; y <= 2; y++)
                {
                    if (Math.Abs(x) + Math.Abs(y) == 3)
                    {
                        Vector2Int move = new Vector2Int(from.x + x, from.y + y);
                        if (IsValidMove(move))
                        {
                            moves.Add(move);
                        }
                    }
                }
            }

            return moves;
        }
    }
}