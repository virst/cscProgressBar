using System;
using System.Collections.Generic;
using System.Text;

namespace cscProgressBar
{
    public class ProgressBar
    {
        private class Point
        {
            public int Left;
            public int Top;
        }

        private readonly Lazy<Point> Position = new Lazy<Point>();
        public int Width { get; set; } = 10;
        public int Minimum { get; set; } = 0;
        public int Maximum { get; set; } = 100;
        private int _v = 0;
        public int Value
        {
            get
            {
                if (_v < Minimum) _v = Minimum;
                if (_v > Maximum) _v = Maximum;
                return _v;
            }
            set
            {
                if (_v == value) return;
                _v = value;
                if (!Position.IsValueCreated) return;
                var tmpPos = new Point();
                tmpPos.Top = Console.CursorTop;
                tmpPos.Left = Console.CursorLeft;
                Console.CursorTop = Position.Value.Top;
                Console.CursorLeft = Position.Value.Left;
                DrawIt();
                Console.CursorTop = tmpPos.Top;
                Console.CursorLeft = tmpPos.Left;
            }
        }
        public char LineChar = (char)9608; //9632 // '#'

        private void DrawIt()
        {
            int prc = (int)((Value - (double)Minimum) / (Maximum - (double)Minimum) * 100);
            int lineWidth = Width * prc / 100;

            DrawIt(prc, lineWidth);
        }

        protected virtual void DrawIt(int prc, int lineWidth)
        {                    

            Console.Write("[");
            Console.Write(new string(LineChar, lineWidth));
            Console.Write(new string(' ', Width - lineWidth));
            Console.Write("]");
            Console.Write("{0}%", prc);
        }

        public void Write()
        {
            Position.Value.Top = Console.CursorTop;
            Position.Value.Left = Console.CursorLeft;

            DrawIt();
        }

        public void WriteLine()
        {
            Write();
            Console.WriteLine();
        }
    }
}
