using System;
using System.Collections.Generic;
using System.IO;
using System.Media;
using System.Security.Claims;
using System.Timers;
using System.Windows.Forms;

namespace Alarm501
{
    public class AlarmController
    {
        private Alarm501 view;  
        private List<Alarm> alarms = new List<Alarm>();
        private System.Windows.Forms.Timer timer;

        public AlarmController(Alarm501 view)
        {
            this.view = view;
            this.alarms = new List<Alarm>();
            this.timer = new System.Windows.Forms.Timer();
            this.timer.Interval = 1000; 
            this.timer.Tick += AlarmTimer_Tick;
            this.timer.Start();
            LoadAlarms();
            foreach (var alarm in alarms)
            {
                alarm.SnoozeTriggered += OnSnoozeTriggered;
                alarm.AlarmTriggered += OnAlarmTriggered;

            }
        }

        // Method to load alarms from file
        public void LoadAlarms()
        {
            alarms.Clear();
            if (File.Exists("alarms.txt"))
            {
                string[] lines = File.ReadAllLines("alarms.txt");
                foreach (var line in lines)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 5 && DateTime.TryParse(parts[0], out DateTime time))
                    {
                        bool isOn = bool.Parse(parts[1].Trim());
                        int snoozeTime = int.Parse(parts[2].Trim());
                        AlarmSound selectedSound = (AlarmSound)Enum.Parse(typeof(AlarmSound), parts[3].Trim());
                        DayOfWeek[] repeatDays = (DayOfWeek[])Enum.GetValues(typeof(DayOfWeek));

                        var alarm = new Alarm(time, isOn, selectedSound, snoozeTime, repeatDays);
                        alarms.Add(alarm);

                        // Subscribe to events here

                    }
                }
            }
            foreach (var alarm in alarms)
            {
                alarm.SnoozeTriggered += OnSnoozeTriggered;
                alarm.AlarmTriggered += OnAlarmTriggered;
            }
        }

        // Method to save alarms to file
        public void SaveAlarms()
        {
            using (StreamWriter writer = new StreamWriter("alarms.txt"))
            {
                foreach (var alarm in alarms)
                {
                    writer.WriteLine($"{alarm.Time:hh:mm tt},{alarm.IsOn},{alarm.SnoozeTime},{alarm.SelectedSound},{string.Join(",", alarm.RepeatDays)}");
                }
            }
        }

        // Method to add a new alarm
        public void AddAlarm(Alarm newAlarm)
        {
            newAlarm.SnoozeTriggered += OnSnoozeTriggered;
            newAlarm.AlarmTriggered += OnAlarmTriggered;
            alarms.Add(newAlarm);
            SaveAlarms();
            view.UpdateUI();  // Update the UI after adding the alarm
        }

        // Method to update an existing alarm
        public void UpdateAlarm(Alarm updatedAlarm, int index)
        {
            alarms[index] = updatedAlarm;
            SaveAlarms();
            view.UpdateUI();
        }

        // Method to remove an alarm
        public void RemoveAlarm(int index)
        {
            alarms.RemoveAt(index);
            SaveAlarms();
            view.UpdateUI();
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
                    // Play a default sound if no match is found
                    SystemSounds.Beep.Play();
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
            view.UpdateUI();

        }
        private void OnAlarmTriggered(Alarm alarm)
        {

            // Logic for handling alarm triggered
            TriggerAlarm(alarm); 
        }
    }
}
