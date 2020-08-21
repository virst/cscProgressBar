using System;
using System.Collections.Generic;
using System.Text;

namespace cscProgressBar
{
    public class ProgressBarInnerPercent : ProgressBar
    {
        protected override void DrawIt(int prc, int lineWidth)
        {
            string prcString = string.Format("{0}%", prc);
            if (prcString.Length > Width) Width = prcString.Length;
            string line = (new string(' ', (Width - prcString.Length) / 2) + prcString).PadRight(Width, ' ');
            var tmpBc = Console.BackgroundColor;
            var tmpFc = Console.ForegroundColor;
            Console.Write("[");
            Console.ForegroundColor = tmpBc;
            Console.BackgroundColor = tmpFc;
            for (int i = 0; i < line.Length; i++)
            {
                if (i > lineWidth && Console.BackgroundColor != tmpBc)
                {
                    Console.BackgroundColor = tmpBc;
                    Console.ForegroundColor = tmpFc;
                }         

                Console.Write(line[i]);
            }
            Console.BackgroundColor = tmpBc;
            Console.ForegroundColor = tmpFc;
            Console.Write("]");
        }
    }
}
