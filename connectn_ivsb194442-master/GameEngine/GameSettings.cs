using System;
using System.Collections.Generic;
namespace GameEngine
{
    public class GameSettings
    {
        public CellState[,] Board { get; set; } = new CellState[6,7];
        private bool _moveTurn = false;
        public int BoardHeight { get; set; } = 6;
        public int BoardWidth { get; set; } = 7;
        public List<CheckLine> PlayerZeroMoves = new List<CheckLine>();
        public List<CheckLine> PlayerOneMoves = new List<CheckLine>();
        public string Gamemode { get; set; } = "";
        public string FileName { get; set; } = "";

        /*public GameSettings()
        {
            Board = new CellState[7,6];
        }*/
    }
}