using System.Collections.Generic;
using App.Scripts.Scenes.SceneChess.Features.GridNavigation.Navigator.MoveCalculators.Abstract;
using UnityEngine;

namespace App.Scripts.Scenes.SceneChess.Features.GridNavigation.Navigator.MoveCalculators
{
    public class DiagonalMoveCalculator : MoveCalculatorBase
    {
        private readonly int _stepDistance;

        public DiagonalMoveCalculator(int stepDistance)
        {
            _stepDistance = stepDistance;
        }
        
        public override List<Vector2Int> GetPossibleMoves(Vector2Int from)
        {
            var moves = new List<Vector2Int>();

            for (int x = -1; x <= 1; x += 2)
            {
                for (int y = -1; y <= 1; y += 2)
                {
                    var stepsCount = 0;
                    Vector2Int move = new Vector2Int(from.x + x, from.y + y);
                    while (IsValidMove(move) && (_stepDistance == MoveCalculatorConst.InfinityStep || stepsCount < _stepDistance))
                    {
                        moves.Add(move);
                        move.x += x;
                        move.y += y;

                        stepsCount++;
                    }
                }
            }

            return moves;
        }
    }
}