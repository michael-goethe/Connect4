using System;
using System.Collections.Generic;
namespace GameEngine
{
    public class Game
    {
        private static int[,] directions = new int[,] { { -1, -1 }, { 1, 1 }, { -1, 1 }, { 1, -1 }, { 0, 1 }, { 0, -1 }, { 1, 0 }, { -1, 0 } };
        private CellState[,] Board { get; set; }
        private int _posY;
        private bool _moveTurn;
        public int BoardWidth { get; }
        public int BoardHeight { get; }
        public List<CheckLine> PlayerZeroMoves;
        public List<CheckLine> PlayerOneMoves;
        public string Title { get; set; }

        public Game(int boardWidth = 3, int boardHeight = 3)
        {
            PlayerOneMoves = new List<CheckLine>();
            PlayerZeroMoves = new List<CheckLine>();
            _posY = boardHeight;
            _moveTurn = false;
            BoardHeight = boardHeight;
            BoardWidth = boardWidth;
            if (BoardHeight < 3 || BoardWidth < 3)
            {
                throw new ArgumentException(message: "Board size has to be at least 3 by 3");
            }

            Board = new CellState[BoardHeight, BoardWidth];
        }

        static bool GetSurrounding(List<CheckLine> item)
        {
            int x = 0, y = 0;

            foreach (var element in item)
            {
                for (var i = 0; i < directions.Length/2; i++)
                {
                    x = item[item.Count - 1].X + directions[i, 0];
                    y = item[item.Count - 1].Y + directions[i, 1];

                    item[item.Count - 1].surroundings[i / 2] += 
                    (element.X == x && element.Y == y) ? element.surroundings[i / 2] : 0;

                    if (item[item.Count - 1].surroundings[i / 2] > 3)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public CellState[,] GetBoard()
        {

            var result = new CellState[BoardHeight, BoardWidth];
            Array.Copy(Board, result, Board.Length);
            return result;
        }


        public bool Move(int posX)
        {
            for (var y = BoardHeight - 1; y >= 0; y--)
            {
                if (Board[y, posX] == CellState.Empty)
                {
                    _moveTurn = !_moveTurn;
                    Board[y, posX] = _moveTurn ? CellState.X : CellState.O;
                    Console.WriteLine(Title + "fasd");
                    if (_moveTurn)
                    {
                        PlayerOneMoves.Add(new CheckLine(y, posX, "1st player won!"));
                        return GetSurrounding(PlayerOneMoves);
                    }
                    else
                    {
                        PlayerZeroMoves.Add(new CheckLine(y, posX, "2nd player won!"));
                        return GetSurrounding(PlayerZeroMoves);
                    }
                }
            }
            return false;
        }
    }
}
