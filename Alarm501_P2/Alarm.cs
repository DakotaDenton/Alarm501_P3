using System;

namespace Alarm501
{
    public class Alarm
{
    public DateTime Time { get; set; }
    public bool IsOn { get; set; }
    public int SnoozeTime { get; set; }
    public AlarmSound SelectedSound { get; set; }
    public DayOfWeek[] RepeatedDays { get; set; }
    public string Label { get; set; }
    public event Action AlarmTriggered;
    public event Action SnoozeTriggered;

    public Alarm() { }

    public bool ShouldTrigger(DateTime currentDateTime) { /* Trigger logic */ return false; }
    public void TriggerAlarm() { AlarmTriggered?.Invoke(); }
    public void TriggerSnooze() { SnoozeTriggered?.Invoke(); }
    public void Snooze() { /* Snooze logic */ }
}
}
