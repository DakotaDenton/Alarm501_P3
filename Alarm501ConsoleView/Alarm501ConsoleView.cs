using System;

namespace Alarm501
{
    public class ConsoleView
    {
        private AlarmController _controller;

        public ConsoleView(AlarmController controller)
        {
            _controller = controller ?? throw new ArgumentNullException(nameof(controller));
        }

        public void Run()
        {
            while (true)
            {
                DisplayAlarms();

                Console.WriteLine("1. Add Alarm");
                Console.WriteLine("2. Edit Alarm");
                Console.WriteLine("3. Exit");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddAlarm();
                        break;
                    case "2":
                        EditAlarm();
                        break;
                    case "3":
                        return; // Exit the application
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        private void DisplayAlarms()
        {
            var alarms = _controller.GetAlarms();
            if (alarms.Count == 0)
            {
                Console.WriteLine("No alarms found.");
                return;
            }

            for (int i = 0; i < alarms.Count; i++)
            {
                var alarm = alarms[i];
                Console.WriteLine($"{i + 1}) {alarm.Time.ToString("HH:mm:ss")} {(alarm.IsOn ? "on" : "off")} {alarm.label}");
            }
        }

        private void AddAlarm()
        {
            try
            {
                Console.WriteLine("Enter alarm time (HH:mm:ss):");
                DateTime time = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("Enter alarm label:");
                string label = Console.ReadLine();

                Console.WriteLine("Enable alarm? (Y/N):");
                bool isOn = Console.ReadLine().Trim().ToUpper() == "Y";

                // Create a new alarm and add it via the controller
                var alarm = new Alarm(time, isOn, AlarmSound.Radar, 5, Array.Empty<DayOfWeek>())
                {
                    label = label
                };
                _controller.AddAlarm(alarm);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid time format. Please enter time in HH:mm:ss format.");
            }
        }

        private void EditAlarm()
        {
            Console.WriteLine("Enter the index of the alarm to edit (1-5):");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int index))
            {
                // Adjust for 1-based input (convert to 0-based index)
                int zeroBasedIndex = index - 1;

                // Check if the index is within the valid range (1-5)
                if (index >= 1 && index <= 5)
                {
                    var alarms = _controller.GetAlarms();

                    // Check if the zero-based index is within the bounds of the alarms list
                    if (zeroBasedIndex >= 0 && zeroBasedIndex < alarms.Count)
                    {
                        var alarm = alarms[zeroBasedIndex];
                        Console.WriteLine($"Editing alarm: {alarm.Time.ToString("HH:mm:ss")} - {alarm.label} ({(alarm.IsOn ? "On" : "Off")})");

                        try
                        {
                            // Prompt for new values
                            Console.WriteLine("Enter new alarm time (HH:mm:ss):");
                            DateTime newTime = DateTime.Parse(Console.ReadLine());

                            Console.WriteLine("Enter new alarm label:");
                            string newLabel = Console.ReadLine();

                            Console.WriteLine("Enable alarm? (Y/N):");
                            bool newIsOn = Console.ReadLine().Trim().ToUpper() == "Y";

                            // Update the alarm via the controller
                            var updatedAlarm = new Alarm(newTime, newIsOn, AlarmSound.Radar, 5, Array.Empty<DayOfWeek>())
                            {
                                label = newLabel
                            };
                            _controller.UpdateAlarm(updatedAlarm, zeroBasedIndex);
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Invalid time format. Please enter time in HH:mm:ss format.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No alarm exists at the specified index.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid index. Please enter a number between 1 and 5.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }
    }
}