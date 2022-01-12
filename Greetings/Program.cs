using System.Device.Gpio;
using System.Diagnostics;
using System.Threading;

namespace Greetings
{
    public class Program
    {
        // ESP32 DevKit: 4 is a valid GPIO pin in, some boards 
        // like Xiuxin ESP32 may require GPIO Pin 2 instead.
        private const byte ledGpioPinNumber = 4;
        private static GpioController builtInLedGpio = new GpioController();
        public static void Main()
        {
            SendHelloWorldToConsole();

            GpioPin led = builtInLedGpio.OpenPin(ledGpioPinNumber, PinMode.Output);
            led.Write(PinValue.Low);
            while (true)
            {
                led.Write(PinValue.High);
                Thread.Sleep(1000);
                led.Write(PinValue.Low);
                Thread.Sleep(1000);
            }
        }

        private static void SendHelloWorldToConsole()
        {
            Debug.WriteLine("Hello from nanoFramework!");

            Thread.Sleep(Timeout.Infinite);
        }
    }
}
