using System;
using Xunit;

namespace AlerterSpace {
    class Alerter {
        static float threshold = 100;
        static int actualAlertFailureCount = 0;
        static int alertFailureCount = 0;
        static int networkAlertStub(float celcius) {
            Console.WriteLine("ALERT: Temperature is {0} celcius", celcius);
            // Return 200 for ok
            // Return 500 for not-ok
            // stub always succeeds and returns 200
            return 200;
        }
        static void alertInCelcius(float farenheit) {
            float celcius = (farenheit - 32) * 5 / 9;
            int returnCode = networkAlertStub(celcius);
            if (returnCode != 200) {
                // non-ok response is not an error! Issues happen in life!
                // let us keep a count of failures to report
                // However, this code doesn't count failures!
                // Add a test below to catch this bug. Alter the stub above, if needed.
                alertFailureCount += 0;
            }
        }
        static int testAlerter(float farenheit)
        {
            float celcius = (farenheit - 32) * 5 / 9;
            if (celcius <= threshold)
            {
                return 200;
            }
            else
            {
                actualAlertFailureCount += 1;
                return 500;
            }

        }
        static void Main(string[] args) {
            alertInCelcius(400.5f);
            alertInCelcius(303.6f);
            Console.WriteLine("{0} alerts failed.", alertFailureCount);
            Console.WriteLine("All is well (maybe!)\n");
            
            Assert.true(networkAlertStub(250)).equals(testAlerter(250));
            Assert.true(alertFailureCount).equals(actualAlertFailureCount);
        }
    }
}
