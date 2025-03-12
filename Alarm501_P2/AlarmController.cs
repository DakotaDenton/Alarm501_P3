using System;
using System.Collections.Generic;
using System.IO;
using System.Media;
using System.Reflection;
using System.Security.Claims;
using System.Timers;
using System.Windows.Forms;

namespace Alarm501
{
    public class AlarmController
    {
        private Model _model;
        private ViewUpdateDisplay _updateDisplay;

        public AlarmController(Model model)
        {
            _model = model;
        }

        public void CheckAlarms()
        {
            DateTime currentTime = DateTime.Now;

            // Loop through all alarms in the Model
            for (int i = 0; i < _model.GetCount(); i++)
            {
                Alarm alarm = _model.GetAlarm(i);

                // Check if the alarm should trigger
                if (alarm.ShouldTrigger(currentTime))
                {
                    // Trigger the alarm
                    alarm.TriggerAlarm();
                }
            }
        }

        // Method to load alarms from file


        // Method to add a new alarm
        public void AddAlarm(Alarm newAlarm)
        {
            newAlarm.SnoozeTriggered += OnSnoozeTriggered;
            newAlarm.AlarmTriggered += OnAlarmTriggered;
            _model.alarms.Add(newAlarm);
            SaveAlarms();
            view.UpdateUI();  // Update the UI after adding the alarm
        }

        // Method to update an existing alarm
        public void UpdateAlarm(Alarm updatedAlarm, int index)
        {
            _model.alarms[index] = updatedAlarm;
            SaveAlarms();
            view.UpdateUI();
        }

        // Method to remove an alarm
        public void RemoveAlarm(int index)
        {
            _model.alarms.RemoveAt(index);
            SaveAlarms();
            Alarm501.
        }

        // Method to get all alarms
        public List<Alarm> GetAlarms()
        {
            return alarms;
        }

        private void AlarmTimer_Tick(object sender, EventArgs e)
        {
            DateTime currentTime = DateTime.Now;

            foreach (var alarm in alarms)
            {
                // If the current time matches the alarm time (minute and hour and second), trigger it
                if (alarm.Time.Hour == currentTime.Hour && alarm.Time.Minute == currentTime.Minute && alarm.Time.Second == currentTime.Second && alarm.RepeatDays.Contains(currentTime.DayOfWeek)) { 
                    TriggerAlarm(alarm);
                }
            }
        }

        public void TriggerAlarm(Alarm alarm)
        {
            // Deactivate the alarm after it has triggered
            alarm.IsOn = false;

            MessageBox.Show(alarm.SelectedSound.ToString());

            // Play the appropriate sound based on the alarm's selected sound
            PlaySound(alarm.SelectedSound);

            // Notify view that the alarm went off
            view.label2.Visible = true;
            view.button1.Enabled = true;
            view.button2.Enabled = true;
            view.poppinalarm = alarm;
        }

        // Method to play sound based on alarm type
        private void PlaySound(AlarmSound alarmSound)
        {
            switch (alarmSound)
            {
                case AlarmSound.Radar:
                    view.label1.Text = "using radar";
                    break;

                case AlarmSound.Beacon:
                    view.label1.Text = "using beacon";
                    break;

                case AlarmSound.Chimes:
                    view.label1.Text = "using chimes";
                    break;

                case AlarmSound.Circuit:
                    view.label1.Text = "using circuit";
                    break;

                case AlarmSound.Reflection:
                    view.label1.Text = "using reflection";
                    break;

                default:
                    view.label1.Text = "using radar";
                    break;
            }
        }

        private void OnSnoozeTriggered(Alarm alarm)
        {
            // Logic for handling snooze when triggered
            alarm.Time = alarm.Time.AddMinutes(alarm.SnoozeTime); // Add snooze time

            // Re-enable the alarm
            alarm.IsOn = true;
            // Save and update the alarms
            SaveAlarms();
            Alarm501.UpdateUI();

        }
        private void OnAlarmTriggered(Alarm alarm)
        {

            // Logic for handling alarm triggered
            TriggerAlarm(alarm); 
        }
    }
}
