using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.Ranjan
{
    public class RanjanProgram
    {
        public static void MainMethod()
        {
            Console.WriteLine("Press x to exit");
            bool isContinue = true;
            {
                var selection = "4";// Console.ReadLine().Trim();
                isContinue = selection.ToLowerInvariant() != "x";
                if (!int.TryParse(selection, out int option))
                {
                    Console.WriteLine("Please try again ..");
                }

                switch (option)
                {
                    case 1:
                        TreeRemove.Tests();
                        break;
                    case 2:
                        MinHeapKClosestTests.Tests();
                        break;
                    case 3:
                        WordCombinations.Tests();
                        break;
                    case 4:
                        TreePaths.Tests();
                        break;

                }
            }

            Console.ReadLine();
        }
    }
}