using System.Collections.Generic;
using App.Scripts.Scenes.SceneChess.Features.ChessField.GridMatrix;
using App.Scripts.Scenes.SceneChess.Features.ChessField.Types;
using UnityEngine;

namespace App.Scripts.Scenes.SceneChess.Features.GridNavigation.Navigator
{
    public abstract class ChessUnitNavigatorBase : ICHessUnitNavigator
    {
        private IMoveCalculator[] _moveCalculators;

        public void Initialize()
        {
            _moveCalculators = InitMoveCalculators();
        }
        
        public void SetGrid(ChessGrid grid)
        {
            foreach (var moveCalculator in _moveCalculators)
            {
                moveCalculator.SetGrid(grid);
            }
        }
        
        public abstract ChessUnitType GetUnitType { get; }
        
        public List<Vector2Int> GetPossibleMoves(Vector2Int from)
        {
            var queenMoves = new List<Vector2Int>();

            foreach (var moveCalculator in _moveCalculators) 
                queenMoves.AddRange(moveCalculator.GetPossibleMoves(from));

            return queenMoves;
        }

        protected abstract IMoveCalculator[] InitMoveCalculators();
    }
}