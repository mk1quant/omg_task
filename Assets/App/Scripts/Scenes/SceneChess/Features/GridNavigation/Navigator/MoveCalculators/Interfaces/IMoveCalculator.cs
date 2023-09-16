using System.Collections.Generic;
using App.Scripts.Scenes.SceneChess.Features.ChessField.GridMatrix;
using App.Scripts.Scenes.SceneChess.Features.ChessField.Types;
using UnityEngine;

namespace App.Scripts.Scenes.SceneChess.Features.GridNavigation.Navigator
{
    public interface IMoveCalculator
    {
        void SetGrid(ChessGrid grid);
        List<Vector2Int> GetPossibleMoves(Vector2Int from);
    }
}