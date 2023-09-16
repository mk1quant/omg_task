using App.Scripts.Scenes.SceneChess.Features.ChessField.Types;
using App.Scripts.Scenes.SceneChess.Features.GridNavigation.Navigator.MoveCalculators;

namespace App.Scripts.Scenes.SceneChess.Features.GridNavigation.Navigator
{
    public class QueenUnitNavigator : ChessUnitNavigatorBase
    {
        public override ChessUnitType GetUnitType => ChessUnitType.Queen;

        protected override IMoveCalculator[] InitMoveCalculators()
        {
            return  new IMoveCalculator[]
            {
                new HorizontalMoveCalculator(MoveCalculatorConst.InfinityStep),  
                new VerticalMoveCalculator(MoveCalculatorConst.InfinityStep),
                new DiagonalMoveCalculator(MoveCalculatorConst.InfinityStep)
            };
        }
    }
}