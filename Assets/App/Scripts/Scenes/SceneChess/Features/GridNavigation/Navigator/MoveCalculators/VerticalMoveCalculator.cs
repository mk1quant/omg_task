using System.Collections.Generic;
using App.Scripts.Scenes.SceneChess.Features.GridNavigation.Navigator.MoveCalculators.Abstract;
using UnityEngine;

namespace App.Scripts.Scenes.SceneChess.Features.GridNavigation.Navigator.MoveCalculators
{
    public class VerticalMoveCalculator : MoveCalculatorBase
    {
        private readonly int _stepDistance;

        public VerticalMoveCalculator(int stepDistance)
        {
            _stepDistance = stepDistance;
        }
        
        public override List<Vector2Int> GetPossibleMoves(Vector2Int from)
        {
            var moves = new List<Vector2Int>();

            for (int y = -1; y <= 1; y++)
            {
                if (y != 0)
                {
                    var stepsCount = 0;
                    Vector2Int move = new Vector2Int(from.x, from.y + y);
                    while (IsValidMove(move) && (_stepDistance == MoveCalculatorConst.InfinityStep || stepsCount < _stepDistance))
                    {
                        moves.Add(move);
                        move.y += y;

                        stepsCount++;
                    }
                }
            }
            return moves;
        }
    }
}