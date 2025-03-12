using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alarm501
{
    public class Model
    {
        public List<Alarm> alarms = new List<Alarm>();
        public Model() 
        {
            alarms = new List<Alarm>(); 
        }

        public void AddAlarm(Alarm alarm)
        {
            alarms.Add(alarm);
        }
        public void RemoveAlarm(Alarm alarm)
        {
            alarms.Remove(alarm);
        }
        public Alarm GetAlarm(int index)
        {
            return alarms[index];
        }
        public int GetCount()
        {
            return alarms.Count;
        }
        public void EditAlarm(int index, Alarm a) 
        {
            alarms[index] = a; 
        }
        public void TriggerAlarm(Alarm a, AlarmHandler handler) 
        {
            handler.TriggerAlarm(); 
        }
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

    }
}
