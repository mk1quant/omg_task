using System.Collections.Generic;
using App.Scripts.Scenes.SceneChess.Features.ChessField.GridMatrix;
using UnityEngine;

namespace App.Scripts.Scenes.SceneChess.Features.GridNavigation.Navigator.MoveCalculators.Abstract
{
    public abstract class MoveCalculatorBase : IMoveCalculator
    {
        private ChessGrid _grid;

        public void SetGrid(ChessGrid grid)
        {
            _grid = grid;
        }

        public abstract List<Vector2Int> GetPossibleMoves(Vector2Int from);
        
        private bool IsEmpty(Vector2Int position)
        {
            if (_grid.Get(position) == null)
                return true;
            else return false;
        }
        
        protected bool IsValidMove(Vector2Int move)
        {
            return move.x >= 0 && move.x < 8 && move.y >= 0 && move.y < 8 && IsEmpty(move);
        }
    }
}