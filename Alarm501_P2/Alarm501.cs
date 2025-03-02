using System;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Alarm501
{
    public partial class Alarm501 : Form
    {
        private AlarmController controller;
        public Alarm poppinalarm = null;  // This holds the active alarm that triggered

        public Alarm501()
        {
            InitializeComponent();
            controller = new AlarmController(this);
            controller.LoadAlarms();
            UpdateUI();  // Ensure the UI is updated on form load
            label2.Visible = false;
            label1.Text = "";
            button1.Enabled = false;
            button2.Enabled = false;

            // Subscribe to alarm events to handle triggers and snooze actions
            // controller.AlarmTriggered += Controller_AlarmTriggered;
            //  controller.SnoozeTriggered += Controller_SnoozeTriggered;
        }

        // Event handler when an alarm is triggered
        private void Controller_AlarmTriggered(Alarm alarm)
        {
            poppinalarm = alarm;  // Set the active alarm
            label1.Text = $"Alarm Triggered! {alarm.SelectedSound}";  // Update UI to show alarm triggered
            label2.Visible = true;
            button1.Enabled = true;  // Enable Stop button
            button2.Enabled = true;  // Enable Snooze button
        }

        // Event handler when an alarm snooze is triggered
        private void Controller_SnoozeTriggered(Alarm alarm)
        {
            label2.Visible = false;
            label1.Visible = false;
            button2.Enabled = false;
            button1.Enabled = false;

            // After snoozing, update the alarm's time and show the updated status
            UpdateUI();
        }

        // Method to update the UI based on the current alarms in the list
        public void UpdateUI()
        {
            UxAlarmList.Items.Clear();  // Clear current list items

            foreach (var alarm in controller.GetAlarms())  // Iterate over the list of alarms
            {
                if (alarm.label.Length > 0)
                {
                    UxAlarmList.Items.Add(alarm.label.ToString());
                }
                else
                {
                    UxAlarmList.Items.Add($"{alarm.Time:hh:mm tt} - {alarm.SelectedSound} - {(alarm.IsOn ? "On" : "Off")}");
                }
            }

            // Enable/Disable Add button based on the number of alarms
            UxAddBtn.Enabled = controller.GetAlarms().Count < 5;
        }

        // Method to handle the "Add Alarm" button click
        private void UxAddBtn_Click(object sender, EventArgs e)
        {
            AddEditAlarm addEditAlarmForm = new AddEditAlarm();
            if (addEditAlarmForm.ShowDialog() == DialogResult.OK)
            {
                var newAlarm = addEditAlarmForm.NewAlarm;
                controller.AddAlarm(newAlarm);  // Pass the new alarm to the controller
            }
        }

        // Method to handle the "Edit Alarm" button click
        private void UxEditBtn_Click(object sender, EventArgs e)
        {
            int selectedIndex = UxAlarmList.SelectedIndex;
            if (selectedIndex >= 0)
            {
                var selectedAlarm = controller.GetAlarms()[selectedIndex];
                AddEditAlarm addEditAlarmForm = new AddEditAlarm(selectedAlarm);

                if (addEditAlarmForm.ShowDialog() == DialogResult.OK)
                {
                    controller.UpdateAlarm(addEditAlarmForm.NewAlarm, selectedIndex);
                }

            }

        }

        // Method to handle the "Snooze" button click
        private void UxSnoozeBtn_Click(object sender, EventArgs e)
        {
            label2.Visible = false;
            label1.Visible = false;
            button2.Enabled = false;
            button1.Enabled = false;
            if (poppinalarm != null)
            {
                poppinalarm.TriggerSnooze();  // Trigger the snooze event

            }
        }

        // Method to handle the "Stop" button click
        private void UxStopBtn_Click(object sender, EventArgs e)
        {
            if (poppinalarm != null)
            {
                // Stop the alarm sound and reset the UI
                label2.Visible = false;
                label1.Visible = false;
                button2.Enabled = false;
                button1.Enabled = false;
                poppinalarm.IsOn = false;  // Turn off the alarm
                UpdateUI();
            }
        }

        // Handle the selection of an alarm from the list
        private void UxAlarmList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Logic for handling alarm list item selection (if needed)
        }
        private void UxDeleteBtn_Click(object sender, EventArgs e)
        {
            // Get the indices of selected items
            var selectedIndices = UxAlarmList.SelectedIndices.Cast<int>().ToList();

            // Remove items starting from the highest index to avoid shifting issues
            for (int i = selectedIndices.Count - 1; i >= 0; i--)
            {
                controller.RemoveAlarm(selectedIndices[i]);
            }

            // Update the UI
            UpdateUI();
        }
    }
}
