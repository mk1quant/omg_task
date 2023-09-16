using App.Scripts.Scenes.SceneChess.Features.ChessField.Types;
using App.Scripts.Scenes.SceneChess.Features.GridNavigation.Navigator.MoveCalculators;

namespace App.Scripts.Scenes.SceneChess.Features.GridNavigation.Navigator
{
    public class BishopUnitNavigator : ChessUnitNavigatorBase
    {
        public override ChessUnitType GetUnitType => ChessUnitType.Bishop;

        protected override IMoveCalculator[] InitMoveCalculators()
        {
            return new IMoveCalculator[]
            {
                new DiagonalMoveCalculator(MoveCalculatorConst.InfinityStep)
            };
        }
    }
}