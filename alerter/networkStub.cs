using System;

namespace alerter
{
    public class networkStub
    {
        static float threshold = 100;
        public static int networkAlertStub(float celcius)
        {
            Console.WriteLine("ALERT: Temperature is {0} celcius", celcius);
            // Return 200 for ok
            // Return 500 for not-ok
            // stub always succeeds and returns 200
            if (celcius <= threshold)
            {
                return 200;
            }
            else
            {

                return 500;
            }
        }
    }
}
