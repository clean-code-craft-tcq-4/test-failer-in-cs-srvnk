using System;
using Xunit;

namespace AlerterSpace {
    class Alerter {
        static float threshold = 100;
        static int actualAlertFailureCount = 0;

        public static int testAlerter(float farenheit)
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

        static void Main(string[] args)
        {
            float alertFailureCount = alertCelcius.alertInCelcius(400.5f);
            Console.WriteLine("{0} alerts failed.", alertFailureCount);
            Console.WriteLine("All is well (maybe!)\n");
            Assert.true(networkStub.networkAlertStub(250)).equals(alerterTest.testAlerter(250));
            Assert.true(alertFailureCount).equals(actualAlertFailureCount);

            alertFailureCount = alertCelcius.alertInCelcius(303.6f);
            Console.WriteLine("{0} alerts failed.", alertFailureCount);
            Console.WriteLine("All is well (maybe!)\n");
            Assert.true(networkStub.networkAlertStub(250)).equals(alerterTest.testAlerter(250));
            Assert.true(alertFailureCount).equals(actualAlertFailureCount);
        }
    }
}
