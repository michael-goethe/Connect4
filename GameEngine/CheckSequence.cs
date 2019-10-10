using System;
using System.Collections.Generic;
namespace GameEngine
{
    public class CheckSequence
    {
        public int horisontalLine;
        public int pDiagonal;
        public int verticalLine;
        public int nDiagonal;
        public int X;
        public int Y;
        public string Title;
            public CheckSequence(int pY, int pX, string pTitle)
        {
            horisontalLine = 1;
            pDiagonal = 1;
            verticalLine = 1;
            nDiagonal = 1;
            Title = pTitle;
            Y = pY;
            X = pX;
        }
    }
}
