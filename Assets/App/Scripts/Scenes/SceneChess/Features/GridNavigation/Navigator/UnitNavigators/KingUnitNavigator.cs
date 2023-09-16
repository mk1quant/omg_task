using App.Scripts.Scenes.SceneChess.Features.ChessField.Types;
using App.Scripts.Scenes.SceneChess.Features.GridNavigation.Navigator.MoveCalculators;

namespace App.Scripts.Scenes.SceneChess.Features.GridNavigation.Navigator
{
    public class KingUnitNavigator : ChessUnitNavigatorBase
    {
        private const int KING_STEP_DISTANCE = 1;
        
        public override ChessUnitType GetUnitType => ChessUnitType.King;

        protected override IMoveCalculator[] InitMoveCalculators()
        {
            return  new IMoveCalculator[]
            {
                new HorizontalMoveCalculator(KING_STEP_DISTANCE),  
                new VerticalMoveCalculator(KING_STEP_DISTANCE),
                new DiagonalMoveCalculator(KING_STEP_DISTANCE)
            };
        }
    }
}