using System;
using System.Threading;

namespace cscProgressBar
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            ProgressBar pb = new ProgressBar();
            pb.Value = 50;
            pb.WriteLine();
            ProgressBar pb2 = new ProgressBarInnerPercent();
            pb2.WriteLine();
            ProgressBar pb3 = new ProgressBar() { LineChar = '#' };         
            pb3.WriteLine();

            Console.WriteLine("As an unperfect actor on the stage,");
            Console.WriteLine("Who with his fear is put besides his part,");
            Console.WriteLine("Or some fierce thing replete with too much rage,");
            Console.WriteLine("Whose strength's abundance weakens his own heart;");
            Console.WriteLine("So I, for fear of trust, forget to say");
            Console.WriteLine("The perfect ceremony of love's rite,");
            Console.WriteLine("And in mine own love's strength seem to decay,");
            Console.WriteLine("O'ercharged with burden of mine own love's might:");
            Console.WriteLine("O let my books be then the eloquence");
            Console.WriteLine("And dumb presagers of my speaking breast,");
            Console.WriteLine("Who plead for love, and look for recompense,");
            Console.WriteLine("More than that tongue that more hath more expressed.");
            Console.WriteLine("O learn to read what silent love hath writ:");
            Console.WriteLine("To hear with eyes belongs to love's fine wit.");

            for (; pb.Value <= pb.Maximum; pb.Value++)
            {
                pb3.Value = pb.Value;
                if (pb2.Value <= pb2.Maximum) pb2.Value += 3;
                Thread.Sleep(150);
                if (pb.Value == pb.Maximum) break;
            }
        }
    }
}
