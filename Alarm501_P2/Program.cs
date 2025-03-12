using System;
using System.Windows.Forms;

namespace Alarm501
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Initialize the model
            var model = new Model();

            // Initialize the controller and pass the model to it
            var alarmController = new AlarmController(model);

            // Initialize the main view (Alarm501) and pass the controller to it
            var alarmView = new Alarm501(alarmController);

            // Run the application, showing the main alarm window
            Application.Run(alarmView);
        }
    }
}