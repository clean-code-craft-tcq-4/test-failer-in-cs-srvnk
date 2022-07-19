using System;
using System.Diagnostics;

namespace MisalignedSpace {
    class Misaligned {
        
        List<string> actualColorCodePairList = new List<string>();
        List<string> colorCodePairList = new List<string>();
        string[] colorCodePairArray = { };
        string[] actualColorCodePairArray = { };

        static int getLongestMajorColorString(string[] majorColor)
        {
            string majorColorLongString = string.Empty;
            for (int i = 1; i < majorColor.Length; i++)
            {
                if(majorColor[i].Length > majorColor[i-1].Length)
                {
                    majorColorLongString = majorColor[i];
                }
                else
                {
                    majorColorLongString = majorColor[i-1];
                }
            }

            return majorColorLongString.Length;
        }

        static int getLongestMinorColorString(string[] minorColor)
        {
            string minorColorLongString = string.Empty;
            for (int i = 1; i < minorColor.Length; i++)
            {
                if (minorColor[i].Length < minorColor[i - 1].Length)
                {
                    minorColorLongString = minorColor[i];
                }
                else
                {
                    minorColorLongString = minorColor[i - 1];
                }
            }

            return minorColorLongString.Length;
        }

        static string addBlankSpace(int blankSpace, string line)
        {
            for (int i = 0; i < blankSpace; i++)
            {
                line = line + " ";
            }
            return line;
        }

        static string[] correctMisalignedString(string[] array, int longestArrayLength)
        {
            List<string> newArray = new List<string>();
            foreach(string arr in array)
            {
                int lengthDiff = longestArrayLength - arr.Length;
                newArray.Add(addBlankSpace(lengthDiff, arr));
            }
            return newArray.ToArray();
        }

        static int printColorMap() {
            string[] majorColors = {"White", "Red", "Black", "Yellow", "Violet"};
            string[] minorColors = {"Blue", "Orange", "Green", "Brown", "Slate"};

            int longestMajorColorString = getLongestMajorColorString(majorColors);
            int longestMinorColorString = getLongestMajorColorString(minorColors);

            majorColors = correctMisalignedString(majorColors, longestMajorColorString);
            minorColors = correctMisalignedString(minorColors, longestMinorColorString);

            int i = 0, j = 0;
            for(i = 0; i < majorColors.Length; i++) {
                for(j = 0; j < minorColors.Length; j++) {
                    //Console.WriteLine("{0} | {1} | {2}", i * 5 + j, majorColors[i], minorColors[i]);
                    int longestColorPairNumber = (majorColors.Length * minorColors.Length).ToString().Length;
                    int pairNumber = ((i * (minorColors.Length)) + j + 1).ToString().Length;

                    if (longestColorPairNumber == pairNumber)
                    {
                        colorCodePairList.Add(string.Format("{0} | {1} | {2}", ((i * (minorColors.Length) + j) + 1), majorColors[i], minorColors[j]));
                    }
                    else
                    {
                        string newPairNumber = addBlankSpace(longestColorPairNumber - pairNumber, ((i * (minorColors.Length) + j) + 1).ToString());
                        colorCodePairList.Add(string.Format("{0} | {1} | {2}", newPairNumber, majorColors[i], minorColors[j]));
                    }
                }
            }
            return majorColors.Length * minorColors.Length;
        }
        
        public void getColorCodePairList()
        {
            string[] majorColors = { "White", "Red", "Black", "Yellow", "Violet" };
            string[] minorColors = { "Blue", "Orange", "Green", "Brown", "Slate" };
            int i = 0, j = 0;
            for (i = 0; i < majorColors.Length; i++)
            {
                for (j = 0; j < minorColors.Length; j++)
                {
                    colorCodePairList.Add(string.Format("{0} | {1} | {2}", i * minorColors.Length + j, majorColors[i], minorColors[j]));
                }
            }

            for (i = 0; i < majorColors.Length; i++)
            {
                for (j = 1; j <= minorColors.Length; j++)
                {
                    actualColorCodePairList.Add(string.Format("{0} | {1} | {2}", i * minorColors.Length + j, majorColors[i], minorColors[j]));
                }
            }
            colorCodePairArray = colorCodePairList.ToArray();
            actualColorCodePairArray = actualColorCodePairList.ToArray();
        }
                
        static void Main(string[] args) {
            int result = printColorMap();
            Debug.Assert(result == 25);
            testMisaligned.getColorCodePairList();
            testMisaligned.printColorCodeMisalignementTest();
            Console.WriteLine("All is well (maybe!)");
            testMisaligned.falseColorPairTest();
        }
    }
}
