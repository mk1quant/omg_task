using App.Scripts.Scenes.SceneChess.Features.ChessField.Types;
using App.Scripts.Scenes.SceneChess.Features.GridNavigation.Navigator.MoveCalculators;

namespace App.Scripts.Scenes.SceneChess.Features.GridNavigation.Navigator
{
    public class RookUnitNavigator : ChessUnitNavigatorBase
    {
        public override ChessUnitType GetUnitType => ChessUnitType.Rook;

        protected override IMoveCalculator[] InitMoveCalculators()
        {
            return  new IMoveCalculator[]
            {
                new VerticalMoveCalculator(MoveCalculatorConst.InfinityStep),
                new HorizontalMoveCalculator(MoveCalculatorConst.InfinityStep)
            };
        }
    }
}