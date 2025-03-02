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

            // Initialize the main view (Alarm501)
            var alarmView = new Alarm501();

            // Initialize the controller and pass the view to it
            var alarmController = new AlarmController(alarmView);

            // Run the application, showing the main alarm window
            Application.Run(alarmView);
        }
    }
}
