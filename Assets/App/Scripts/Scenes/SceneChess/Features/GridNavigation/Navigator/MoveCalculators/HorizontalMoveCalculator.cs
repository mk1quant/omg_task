using System.Collections.Generic;
using App.Scripts.Scenes.SceneChess.Features.GridNavigation.Navigator.MoveCalculators.Abstract;
using UnityEngine;

namespace App.Scripts.Scenes.SceneChess.Features.GridNavigation.Navigator.MoveCalculators
{
    public class HorizontalMoveCalculator : MoveCalculatorBase
    {
        private readonly int _stepDistance;

        public HorizontalMoveCalculator(int stepDistance)
        {
            _stepDistance = stepDistance;
        }
        
        public override List<Vector2Int> GetPossibleMoves(Vector2Int from)
        {
            var moves = new List<Vector2Int>();

            for (int x = -1; x <= 1; x++)
            {
                if (x != 0)
                {
                    var stepsCount = 0;
                    Vector2Int move = new Vector2Int(from.x + x, from.y);
                    while (IsValidMove(move) && (_stepDistance == MoveCalculatorConst.InfinityStep || stepsCount < _stepDistance))
                    {
                        moves.Add(move);
                        move.x += x;
                        
                        stepsCount++;
                    }
                }
            }

            return moves;
        }
    }
}