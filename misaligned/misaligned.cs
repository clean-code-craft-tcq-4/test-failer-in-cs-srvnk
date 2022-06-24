using System;
using System.Diagnostics;

namespace MisalignedSpace {
    class Misaligned {
        
        List<string> actualColorCodePairList = new List<string>();
        List<string> colorCodePairList = new List<string>();
        string[] colorCodePairArray = { };
        string[] actualColorCodePairArray = { };
        
        static int printColorMap() {
            string[] majorColors = {"White", "Red", "Black", "Yellow", "Violet"};
            string[] minorColors = {"Blue", "Orange", "Green", "Brown", "Slate"};
            int i = 0, j = 0;
            for(i = 0; i < 5; i++) {
                for(j = 0; j < 5; j++) {
                    Console.WriteLine("{0} | {1} | {2}", i * 5 + j, majorColors[i], minorColors[i]);
                }
            }
            return i * j;
        }
        
        public void getColorCodePairList()
        {
            string[] majorColors = { "White", "Red", "Black", "Yellow", "Violet" };
            string[] minorColors = { "Blue", "Orange", "Green", "Brown", "Slate" };
            int i = 0, j = 0;
            for (i = 0; i < 5; i++)
            {
                for (j = 0; j < 5; j++)
                {
                    colorCodePairList.Add(string.Format("{0} | {1} | {2}", i * 5 + j, majorColors[i], minorColors[i]));
                }
            }

            for (i = 0; i < 5; i++)
            {
                for (j = 1; j <= 5; j++)
                {
                    actualColorCodePairList.Add(string.Format("{0} | {1} | {2}", i * 5 + j, majorColors[i], minorColors[i]));
                }
            }
            colorCodePairArray = colorCodePairList.ToArray();
            actualColorCodePairArray = actualColorCodePairList.ToArray();
        }
        
        public void falseColorPairTest()
        {
            for (int i=0; i<actualColorCodePairArray.Length; i++)
            {
                Debug.Assert(colorCodePairArray.Equals(actualColorCodePairArray));
            }

        }

        public void printColorCodeMisalignementTest()
        {
            string longestColorCodePairValue = string.Empty;
            
            for (int i = 1; i<colorCodePairArray.Length; i++)
            {
                longestColorCodePairValue = colorCodePairArray[i - 1].Length > colorCodePairArray[i].Length ? colorCodePairArray[i-1] : colorCodePairArray[i];
            }
            
            foreach(string colorCode in colorCodePairArray)
            {
                Debug.Assert(colorCode.Length.Equals(longestColorCodePairValue.Length));
            }

        }
        
        static void Main(string[] args) {
            int result = printColorMap();
            Debug.Assert(result == 25);
            getColorCodePairList();
            printColorCodeMisalignementTest();
            Console.WriteLine("All is well (maybe!)");
            falseColorPairTest();
        }
    }
}
