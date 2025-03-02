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
            checkedListBox2.ItemCheck += checkedListBox2_ItemCheck; //makes sure only one sound is selected

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
            // Set the selected sound in checkedListBox2
            int soundIndex = checkedListBox2.Items.IndexOf(existingAlarm.SelectedSound.ToString());
            if (soundIndex >= 0)
            {
                checkedListBox2.SetItemChecked(soundIndex, true);
            }
        }

        private void UXSetAlarmBtn_Click(object sender, EventArgs e)
        {
            // Create the new alarm object with the selected values
            NewAlarm = new Alarm(dateTimePicker1.Value,checkBox1.Checked,GetSelectedSound(),(int)numericUpDown1.Value, GetSelectedRepeatDays());

            // Set the alarm label if text is provided
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                NewAlarm.label = textBox1.Text;
            }

            // Close the form with OK result
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // Helper method to get the selected sound
        private AlarmSound GetSelectedSound()
        {
            string selectedSoundName = checkedListBox2.SelectedItem?.ToString();
            return Enum.TryParse(selectedSoundName, out AlarmSound parsedSound) ? parsedSound : AlarmSound.Radar;
        }

        // Helper method to get the selected repeat days
        private DayOfWeek[] GetSelectedRepeatDays()
        {
            return checkedListBox1.CheckedItems.Cast<string>().Select(day => (DayOfWeek)Enum.Parse(typeof(DayOfWeek), day)).ToArray();
        }

        private void UxCancelEditAlarmBtn_Click(Object sender, EventArgs e)
        {
            this.Close();
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
            // If a sound is being checked, uncheck all other
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
