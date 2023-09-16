using System.Collections.Generic;
using System.Linq;
using App.Scripts.Scenes.SceneChess.Features.ChessField.GridMatrix;
using App.Scripts.Scenes.SceneChess.Features.ChessField.Types;
using UnityEngine;

namespace App.Scripts.Scenes.SceneChess.Features.GridNavigation.Navigator
{
    public class ChessGridNavigator : IChessGridNavigator
    {
        private readonly Dictionary<ChessUnitType, ICHessUnitNavigator> _unitNavigators;
        
        public ChessGridNavigator()
        {
            var unitNavigators = new List<ICHessUnitNavigator>()
            {
                new PonUnitNavigator(),
                new KingUnitNavigator(),
                new QueenUnitNavigator(),
                new RookUnitNavigator(),
                new KnightUnitNavigator(),
                new BishopUnitNavigator()
            };

            foreach (var unitNavigator in unitNavigators)
            {
                unitNavigator.Initialize();
            }
            
            _unitNavigators = unitNavigators.ToDictionary(unitNavigator => unitNavigator.GetUnitType, unitNavigator => unitNavigator);
        }
        
        
        public List<Vector2Int> FindPath(ChessUnitType unit, Vector2Int from, Vector2Int to, ChessGrid grid)
        {
            Queue<Vector2Int> queue = new Queue<Vector2Int>();
            Dictionary<Vector2Int, Vector2Int> previous = new Dictionary<Vector2Int, Vector2Int>();
            queue.Enqueue(from);

            var unitNavigator = _unitNavigators[unit];
            unitNavigator.SetGrid(grid);

            while (queue.Count > 0)
            {
                Vector2Int current = queue.Dequeue();

                if (current == to)
                {
                    return BuildPath(from, to, previous);
                }

                List<Vector2Int> possibleMoves = unitNavigator.GetPossibleMoves(current);

                foreach (var move in possibleMoves)
                {
                    if (!previous.ContainsKey(move))
                    {
                        queue.Enqueue(move);
                        previous[move] = current;
                    }
                }
            }

            return null;
        }

        private List<Vector2Int> BuildPath(Vector2Int from, Vector2Int to, Dictionary<Vector2Int, Vector2Int> previous)
        {
            List<Vector2Int> path = new List<Vector2Int>();
            Vector2Int current = to;

            while (current != from)
            {
                path.Add(current);
                current = previous[current];
            }

            path.Reverse();
            return path;
        }
    }
}