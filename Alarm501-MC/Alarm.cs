using System;

namespace Alarm501
{
    public class Alarm
    {
        // Delegate for alarm triggering event
        public delegate void AlarmTriggeredEventHandler(Alarm alarm);

        // Event triggered when the alarm goes off
        public event AlarmTriggeredEventHandler AlarmTriggered;

        // Delegate for snooze event
        public delegate void SnoozeEventHandler(Alarm alarm);

        // Event triggered when the snooze button is pressed
        public event SnoozeEventHandler SnoozeTriggered;
        public string label = "";

        public DateTime Time { get; set; }
        public bool IsOn { get; set; }
        public int SnoozeTime { get; set; }  // Snooze duration in minutes
        public AlarmSound SelectedSound { get; set; }
        public DayOfWeek[] RepeatDays { get; set; }

        // Constructor to initialize the alarm
        public Alarm(DateTime time, bool isOn, AlarmSound selectedSound, int snoozeTime, DayOfWeek[] repeatDays)
        {
            Time = time;
            IsOn = isOn;
            SelectedSound = selectedSound;
            SnoozeTime = snoozeTime;
            RepeatDays = repeatDays;
        }

        // Method to check if the alarm should trigger
        public bool ShouldTrigger(DateTime currentDateTime)
        {
            // Check if the current day is in the repeat days
            return RepeatDays.Length == 0 || Array.Exists(RepeatDays, day => day == currentDateTime.DayOfWeek);
        }

        // Method to trigger the alarm (raise the AlarmTriggered event)
        public void TriggerAlarm()
        {
            // Notify any subscribers that the alarm has triggered
            AlarmTriggered?.Invoke(this);
        }

        // Method to trigger the snooze (raise the SnoozeTriggered event)
        public void TriggerSnooze()
        {
            if (SnoozeTriggered != null)
            {
                SnoozeTriggered(this);
            }
        }

        // Method to update the alarm time after snooze is triggered
        public void Snooze()
        {
            Time = Time.AddMinutes(SnoozeTime); // Adjust alarm time based on snooze time
        }
    }
}
