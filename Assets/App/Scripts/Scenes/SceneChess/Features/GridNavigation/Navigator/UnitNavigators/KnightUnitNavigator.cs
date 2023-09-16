using App.Scripts.Scenes.SceneChess.Features.ChessField.Types;
using App.Scripts.Scenes.SceneChess.Features.GridNavigation.Navigator.MoveCalculators;

namespace App.Scripts.Scenes.SceneChess.Features.GridNavigation.Navigator
{
    public class KnightUnitNavigator : ChessUnitNavigatorBase
    {
        public override ChessUnitType GetUnitType => ChessUnitType.Knight;

        protected override IMoveCalculator[] InitMoveCalculators()
        {
            return new IMoveCalculator[]
            {
                new LMoveCalculator()
            };
        }
    }
}