using System;
using System.Collections.Generic;
using App.Scripts.Scenes.SceneChess.Features.ChessField.GridMatrix;
using App.Scripts.Scenes.SceneChess.Features.ChessField.Types;
using UnityEngine;

namespace App.Scripts.Scenes.SceneChess.Features.GridNavigation.Navigator
{
    public class ChessGridNavigator : IChessGridNavigator
    {
        private ChessGrid grid;

        public List<Vector2Int> FindPath(ChessUnitType unit, Vector2Int from, Vector2Int to, ChessGrid grid)
        {
            this.grid = grid;

            Queue<Vector2Int> queue = new Queue<Vector2Int>();
            Dictionary<Vector2Int, Vector2Int> previous = new Dictionary<Vector2Int, Vector2Int>();
            queue.Enqueue(from);

            while (queue.Count > 0)
            {
                Vector2Int current = queue.Dequeue();

                if (current == to)
                {
                    return BuildPath(from, to, previous);
                }

                List<Vector2Int> possibleMoves = GetPossibleMoves(unit, current);

                foreach (var move in possibleMoves)
                {
                    if (IsEmpty(move) && !previous.ContainsKey(move))
                    {
                        queue.Enqueue(move);
                        previous[move] = current;
                    }
                }
            }

            return null;

            //напиши реализацию не меняя сигнатуру функции
            //throw new NotImplementedException();
        }

        private List<Vector2Int> GetPossibleMoves(ChessUnitType unit, Vector2Int position)
        {
            var possibleMoves = new List<Vector2Int>();

            switch(unit)
            {
                case ChessUnitType.Pon:
                    possibleMoves = GetPonMoves(position);
                    break;
                case ChessUnitType.King:
                    possibleMoves = GetKingMoves(position);
                    break;
                case ChessUnitType.Queen:
                    possibleMoves = GetQueenMoves(position);
                    break;
                case ChessUnitType.Rook:
                    possibleMoves = GetRookMoves(position);
                    break;
                case ChessUnitType.Knight:
                    possibleMoves = GetKnightMoves(position);
                    break;
                case ChessUnitType.Bishop:
                    possibleMoves = GetBishopMoves(position);
                    break;
            }

            return possibleMoves;
        }

        private List<Vector2Int> GetPonMoves(Vector2Int position)
        {
            var ponMoves = new List<Vector2Int>();

            Vector2Int forwardMove = new Vector2Int(position.x, position.y + 1);
            if (IsValidMove(forwardMove))
            {
                ponMoves.Add(forwardMove);
            }
            forwardMove = new Vector2Int(position.x, position.y - 1);
            if (IsValidMove(forwardMove))
            {
                ponMoves.Add(forwardMove);
            }

            return ponMoves;
        }

        private List<Vector2Int> GetKingMoves(Vector2Int position)
        {
            var kingMoves = new List<Vector2Int>();

            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    Vector2Int move = new Vector2Int(position.x + x, position.y + y);
                    if (IsValidMove(move))
                    {
                        kingMoves.Add(move);
                    }
                }
            }

            return kingMoves;
        }

        private List<Vector2Int> GetQueenMoves(Vector2Int position)
        {
            var queenMoves = GetRookMoves(position);
            queenMoves.AddRange(GetBishopMoves(position));

            return queenMoves;
        }

        private List<Vector2Int> GetRookMoves(Vector2Int position)
        {
            var rookMoves = new List<Vector2Int>();

            for (int y = -1; y <= 1; y++)
            {
                if (y != 0)
                {
                    Vector2Int move = new Vector2Int(position.x, position.y + y);
                    while (IsValidMove(move))
                    {
                        rookMoves.Add(move);
                        move.y += y;
                    }
                }
            }

            for (int x = -1; x <= 1; x++)
            {
                if (x != 0)
                {
                    Vector2Int move = new Vector2Int(position.x + x, position.y);
                    while (IsValidMove(move))
                    {
                        rookMoves.Add(move);
                        move.x += x;
                    }
                }
            }

            return rookMoves;
        }

        private List<Vector2Int> GetKnightMoves(Vector2Int position)
        {
            var knightMoves = new List<Vector2Int>();

            for (int x = -2; x <= 2; x++)
            {
                for (int y = -2; y <= 2; y++)
                {
                    if (Math.Abs(x) + Math.Abs(y) == 3)
                    {
                        Vector2Int move = new Vector2Int(position.x + x, position.y + y);
                        if (IsValidMove(move))
                        {
                            knightMoves.Add(move);
                        }
                    }
                }
            }

            return knightMoves;
        }

        private List<Vector2Int> GetBishopMoves(Vector2Int position)
        {
            var bishopMoves = new List<Vector2Int>();

            for (int x = -1; x <= 1; x += 2)
            {
                for (int y = -1; y <= 1; y += 2)
                {
                    Vector2Int move = new Vector2Int(position.x + x, position.y + y);
                    while (IsValidMove(move))
                    {
                        bishopMoves.Add(move);
                        move.x += x;
                        move.y += y;
                    }
                }
            }

            return bishopMoves;
        }

        private bool IsValidMove(Vector2Int move)
        {
            return move.x >= 0 && move.x < 8 && move.y >= 0 && move.y < 8 && IsEmpty(move);
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

        private bool IsEmpty(Vector2Int position)
        {
            if (grid.Get(position) == null)
                return true;
            else return false;
        }
    }
}