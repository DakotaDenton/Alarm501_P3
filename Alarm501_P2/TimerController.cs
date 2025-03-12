using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alarm501;

namespace Alarm501
{
    public class TimerController
    {
        public System.Windows.Forms.Timer _timer;
        private AlarmController AlarmController;

        public TimerController()
        {
            _timer = new System.Windows.Forms.Timer();
            _timer.Tick += AlarmTimer_Tick;
        }

        private void AlarmTimer_Tick(object sender, EventArgs e)
        {
            AlarmController.CheckAlarms();

        }
    }
}
