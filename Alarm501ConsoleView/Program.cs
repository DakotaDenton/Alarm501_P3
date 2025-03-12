using System;

namespace Alarm501
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            Console.WriteLine("Alarm 501 Console App");

            // Initialize the model
            var model = new Model();

            // Initialize the controller and pass the model to it
            var alarmController = new AlarmController(model);

            // Initialize the view and pass the controller to it
            var consoleView = new ConsoleView(alarmController);

            // Run the console application
            consoleView.Run();
        }
    }
}