using System;
using System.Linq;
using System.Windows.Forms;

namespace Alarm501
{
    public partial class Alarm501 : Form
    {
        private AlarmController controller;
        public Alarm poppinalarm = null;  // This holds the active alarm that triggered

        // Constructor that accepts an AlarmController object
        public Alarm501(AlarmController controller)
        {
            InitializeComponent();

            // Store the AlarmController object
            this.controller = controller ?? throw new ArgumentNullException(nameof(controller));

            // Load alarms and update the UI
            UpdateUI();

            // Initialize UI elements
            label2.Visible = false;
            label1.Text = "";
            button1.Enabled = false;
            button2.Enabled = false;
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

            // Disable Add button based on the number of alarms (more than 5)
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
                UpdateUI();  // Refresh the UI
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
                    UpdateUI();  // Refresh the UI
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
                UpdateUI();  // Refresh the UI
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
                UpdateUI();  // Refresh the UI
            }
        }

        // Method to handle the "Delete" button click
        private void UxDeleteBtn_Click(object sender, EventArgs e)
        {
            // Get the indices of selected items
            var selectedIndices = UxAlarmList.SelectedIndices.Cast<int>().ToList();

            for (int i = selectedIndices.Count - 1; i >= 0; i--)
            {
                controller.RemoveAlarm(selectedIndices[i]);
            }

            // Update the UI
            UpdateUI();
        }
    }
}