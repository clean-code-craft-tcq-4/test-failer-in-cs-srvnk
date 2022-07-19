using System;

namespace alerter
{
    public class alertCelcius
    {
        static int alertFailureCount = 0;
        public static int alertInCelcius(float farenheit)
        {
            float celcius = (farenheit - 32) * 5 / 9;
            int returnCode = networkStub.networkAlertStub(celcius);
            if (returnCode != 200)
            {
                // non-ok response is not an error! Issues happen in life!
                // let us keep a count of failures to report
                // However, this code doesn't count failures!
                // Add a test below to catch this bug. Alter the stub above, if needed.
                alertFailureCount += 1;
            }
            else
            {
                alertFailureCount = 0;
            }

            return alertFailureCount;
        }
    }
}
