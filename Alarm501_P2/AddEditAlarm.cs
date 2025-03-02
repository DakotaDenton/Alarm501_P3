using System;
using System.Linq;
using System.Security.Claims;
using System.Windows.Forms;
using Alarm501;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Alarm501
{
    public partial class AddEditAlarm : Form
    {
        public Alarm NewAlarm { get; private set; }

        public AddEditAlarm()
        {
            InitializeComponent();
            PopulateRepeatDays();
            PopulateSoundList();
            checkedListBox2.ItemCheck += checkedListBox2_ItemCheck;
        }

        public AddEditAlarm(Alarm existingAlarm)
        {
            InitializeComponent();

            dateTimePicker1.Value = existingAlarm.Time;
            checkBox1.Checked = existingAlarm.IsOn;
            checkedListBox2.CheckedIndices.Equals(existingAlarm.SelectedSound);
            // Populate repeat days based on existing alarm settings
            PopulateRepeatDays();

            // Set the selected repeat days in the CheckedListBox
            foreach (var day in existingAlarm.RepeatDays)
            {
                int index = checkedListBox1.Items.IndexOf(day.ToString());
                if (index >= 0)
                {
                    checkedListBox1.SetItemChecked(index, true);
                }
            }

            PopulateSoundList();
            // Set the selected sound in checkedListBox2 (if any)
            int soundIndex = checkedListBox2.Items.IndexOf(existingAlarm.SelectedSound.ToString());
            if (soundIndex >= 0)
            {
                checkedListBox2.SetItemChecked(soundIndex, true);
            }
        }

        private void UXSetAlarmBtn_Click(object sender, EventArgs e)
        {
            DateTime selectedTime = dateTimePicker1.Value;
            bool isOn = checkBox1.Checked;

            // Get the selected sound from the CheckedListBox
            string selectedSoundName = checkedListBox2.SelectedItem?.ToString();
            AlarmSound selectedSound = AlarmSound.Radar; // Default sound

            // If a sound is selected, update the selectedSound variable
            if (!string.IsNullOrEmpty(selectedSoundName) && Enum.TryParse(selectedSoundName, out AlarmSound parsedSound))
            {
                selectedSound = parsedSound;
            }
            int snoozeTime = (int)numericUpDown1.Value;

            // Get the selected repeat days from checkedListBox1
            DayOfWeek[] selectedDays = checkedListBox1.CheckedItems.Cast<string>()
                .Select(day => (DayOfWeek)Enum.Parse(typeof(DayOfWeek), day))
                .ToArray();

            // Create the new alarm object
            NewAlarm = new Alarm(selectedTime, isOn, selectedSound, snoozeTime, selectedDays);

            // Close the form after setting the alarm
            this.DialogResult = DialogResult.OK;
            this.Close();
            if (textBox1.Text.Length > 0)
            {
                NewAlarm.label = textBox1.Text;
            }

        }

        private void UxCancelEditAlarmBtn_Click(Object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkedListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void PopulateRepeatDays()
        {
            checkedListBox1.Items.Clear();
            foreach (DayOfWeek day in Enum.GetValues(typeof(DayOfWeek)))
            {
                checkedListBox1.Items.Add(day.ToString());
            }
        }

        private void PopulateSoundList()
        {
            checkedListBox2.Items.Clear();
            checkedListBox2.Items.AddRange(Enum.GetNames(typeof(AlarmSound)));
        }

        private void checkedListBox2_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            // If an item is being checked, uncheck all other items
            if (e.NewValue == CheckState.Checked)
            {
                for (int i = 0; i < checkedListBox2.Items.Count; i++)
                {
                    if (i != e.Index)
                    {
                        checkedListBox2.SetItemChecked(i, false);
                    }
                }
            }
        }
    }
}
