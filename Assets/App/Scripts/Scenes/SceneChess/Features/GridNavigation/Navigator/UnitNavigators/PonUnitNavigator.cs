using App.Scripts.Scenes.SceneChess.Features.ChessField.Types;
using App.Scripts.Scenes.SceneChess.Features.GridNavigation.Navigator.MoveCalculators;

namespace App.Scripts.Scenes.SceneChess.Features.GridNavigation.Navigator
{
    public class PonUnitNavigator : ChessUnitNavigatorBase
    {
        private const int PON_STEP_DISTANCE = 1;

        public override ChessUnitType GetUnitType => ChessUnitType.Pon;

        protected override IMoveCalculator[] InitMoveCalculators()
        {
            return  new IMoveCalculator[]
            {
                new VerticalMoveCalculator(PON_STEP_DISTANCE),
            };
        }
    }
}