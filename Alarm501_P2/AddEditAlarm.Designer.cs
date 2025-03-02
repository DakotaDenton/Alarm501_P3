namespace Alarm501
{
    partial class AddEditAlarm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dateTimePicker1 = new DateTimePicker();
            UXSetAlarmBtn = new Button();
            UxCancelEditAlarmBtn = new Button();
            checkBox1 = new CheckBox();
            checkedListBox1 = new CheckedListBox();
            checkedListBox2 = new CheckedListBox();
            numericUpDown1 = new NumericUpDown();
            label1 = new Label();
            label2 = new Label();
            textBox1 = new TextBox();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CalendarFont = new Font("Microsoft Sans Serif", 22.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateTimePicker1.Format = DateTimePickerFormat.Time;
            dateTimePicker1.Location = new Point(12, 40);
            dateTimePicker1.Margin = new Padding(2);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(177, 23);
            dateTimePicker1.TabIndex = 0;
            dateTimePicker1.Value = new DateTime(2025, 3, 1, 20, 6, 35, 561);
            // 
            // UXSetAlarmBtn
            // 
            UXSetAlarmBtn.Location = new Point(219, 92);
            UXSetAlarmBtn.Margin = new Padding(2);
            UXSetAlarmBtn.Name = "UXSetAlarmBtn";
            UXSetAlarmBtn.Size = new Size(66, 35);
            UXSetAlarmBtn.TabIndex = 1;
            UXSetAlarmBtn.Text = "Set";
            UXSetAlarmBtn.UseVisualStyleBackColor = true;
            UXSetAlarmBtn.Click += UXSetAlarmBtn_Click;
            // 
            // UxCancelEditAlarmBtn
            // 
            UxCancelEditAlarmBtn.Location = new Point(219, 131);
            UxCancelEditAlarmBtn.Margin = new Padding(2);
            UxCancelEditAlarmBtn.Name = "UxCancelEditAlarmBtn";
            UxCancelEditAlarmBtn.Size = new Size(66, 35);
            UxCancelEditAlarmBtn.TabIndex = 2;
            UxCancelEditAlarmBtn.Text = "Cancel";
            UxCancelEditAlarmBtn.UseVisualStyleBackColor = true;
            UxCancelEditAlarmBtn.Click += UxCancelEditAlarmBtn_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Checked = true;
            checkBox1.CheckState = CheckState.Checked;
            checkBox1.Location = new Point(233, 72);
            checkBox1.Margin = new Padding(2);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(42, 19);
            checkBox1.TabIndex = 3;
            checkBox1.Text = "On";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkedListBox1
            // 
            checkedListBox1.CheckOnClick = true;
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Location = new Point(12, 72);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(188, 166);
            checkedListBox1.TabIndex = 4;
            checkedListBox1.SelectedIndexChanged += checkedListBox1_SelectedIndexChanged;
            // 
            // checkedListBox2
            // 
            checkedListBox2.CheckOnClick = true;
            checkedListBox2.FormattingEnabled = true;
            checkedListBox2.Location = new Point(318, 72);
            checkedListBox2.Name = "checkedListBox2";
            checkedListBox2.Size = new Size(188, 166);
            checkedListBox2.TabIndex = 5;
            checkedListBox2.SelectedIndexChanged += checkedListBox2_SelectedIndexChanged;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(222, 213);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(53, 23);
            numericUpDown1.TabIndex = 6;
            numericUpDown1.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(218, 180);
            label1.Name = "label1";
            label1.Size = new Size(82, 15);
            label1.TabIndex = 7;
            label1.Text = "Snooze Period";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(219, 195);
            label2.Name = "label2";
            label2.Size = new Size(71, 15);
            label2.TabIndex = 8;
            label2.Text = "(In Minutes)";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(318, 40);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(201, 23);
            textBox1.TabIndex = 9;

            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(318, 22);
            label3.Name = "label3";
            label3.Size = new Size(70, 15);
            label3.TabIndex = 10;
            label3.Text = "Alarm Label";
            // 
            // AddEditAlarm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(587, 265);
            Controls.Add(label3);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(numericUpDown1);
            Controls.Add(checkedListBox2);
            Controls.Add(checkedListBox1);
            Controls.Add(checkBox1);
            Controls.Add(UxCancelEditAlarmBtn);
            Controls.Add(UXSetAlarmBtn);
            Controls.Add(dateTimePicker1);
            Margin = new Padding(2);
            Name = "AddEditAlarm";
            Text = "Add/Edit Alarm";
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button UXSetAlarmBtn;
        private System.Windows.Forms.Button UxCancelEditAlarmBtn;
        private System.Windows.Forms.CheckBox checkBox1;
        private CheckedListBox checkedListBox1;
        private CheckedListBox checkedListBox2;
        private NumericUpDown numericUpDown1;
        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private Label label3;
    }
}