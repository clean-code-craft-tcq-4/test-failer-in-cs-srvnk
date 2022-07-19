using System;

namespace misaligned
{
    class testMisaligned
    {
        public void printColorCodeMisalignementTest()
        {
            string longestColorCodePairValue = string.Empty;

            for (int i = 1; i < colorCodePairArray.Length; i++)
            {
                longestColorCodePairValue = colorCodePairArray[i - 1].Length > colorCodePairArray[i].Length ? colorCodePairArray[i - 1] : colorCodePairArray[i];
            }

            foreach (string colorCode in colorCodePairArray)
            {
                Debug.Assert(colorCode.Length.Equals(longestColorCodePairValue.Length));
            }

        }

        public void falseColorPairTest()
        {
            for (int i = 0; i < actualColorCodePairArray.Length; i++)
            {
                Debug.Assert(colorCodePairArray.Equals(actualColorCodePairArray));
            }

        }
    }
}
