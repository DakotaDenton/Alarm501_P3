using System;
using System.Collections.Generic;
using System.Timers;

namespace Alarm501
{
    public class AlarmController
    {
        private System.Timers.Timer timer;
        private Model model;
        private List<Alarm> alarms;

        public AlarmController(Model model)
        {
            this.model = model ?? throw new ArgumentNullException(nameof(model));
            this.alarms = model.LoadAlarms(); // Load alarms from the model
            this.timer = new System.Timers.Timer(1000); // 1 second interval
            this.timer.Elapsed += AlarmTimer_Tick;
            this.timer.AutoReset = true; // Ensure the timer keeps running
            this.timer.Start();

            foreach (var alarm in alarms)
            {
                alarm.SnoozeTriggered += OnSnoozeTriggered;
                alarm.AlarmTriggered += OnAlarmTriggered;
            }
        }

        public List<Alarm> GetAlarms()
        {
            return alarms;
        }

        public void AddAlarm(Alarm newAlarm)
        {
            newAlarm.SnoozeTriggered += OnSnoozeTriggered;
            newAlarm.AlarmTriggered += OnAlarmTriggered;
            alarms.Add(newAlarm);
            model.SaveAlarms();
        }

        public void UpdateAlarm(Alarm updatedAlarm, int index)
        {
            alarms[index] = updatedAlarm;
            model.SaveAlarms();
        }

        public void RemoveAlarm(int index)
        {
            alarms.RemoveAt(index);
            model.SaveAlarms();
        }

        private void AlarmTimer_Tick(object sender, ElapsedEventArgs e)
        {
            DateTime currentTime = DateTime.Now;

            foreach (var alarm in alarms)
            {
                if (alarm.IsOn && alarm.Time.Hour == currentTime.Hour && alarm.Time.Minute == currentTime.Minute)
                {
                    TriggerAlarm(alarm);
                }
            }
        }

        private void TriggerAlarm(Alarm alarm)
        {
            alarm.IsOn = false; // Deactivate the alarm after triggering
           // Console.WriteLine($"Playing sound: {alarm.SelectedSound}");
        }

        private void PlaySound(AlarmSound alarmSound)
        {
            // Implement logic to play the selected sound

        }

        private void OnSnoozeTriggered(Alarm alarm)
        {
            alarm.Time = alarm.Time.AddMinutes(alarm.SnoozeTime); // Add snooze time
            alarm.IsOn = true; // Re-enable the alarm
            model.SaveAlarms();
        }

        private void OnAlarmTriggered(Alarm alarm)
        {
            TriggerAlarm(alarm);
        }
    }
}