using static System.Net.Mime.MediaTypeNames;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Alarm501
{

    partial class Alarm501
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
            UxEditBtn = new Button();
            UxAddBtn = new Button();
            UxAlarmList = new ListBox();
            button1 = new Button();
            button2 = new Button();
            label2 = new Label();
            label1 = new Label();
            button3 = new Button();
            SuspendLayout();
            // 
            // UxEditBtn
            // 
            UxEditBtn.Location = new Point(358, 22);
            UxEditBtn.Margin = new Padding(2);
            UxEditBtn.Name = "UxEditBtn";
            UxEditBtn.Size = new Size(84, 43);
            UxEditBtn.TabIndex = 0;
            UxEditBtn.Text = "Edit";
            UxEditBtn.UseVisualStyleBackColor = true;
            UxEditBtn.Click += UxEditBtn_Click;
            // 
            // UxAddBtn
            // 
            UxAddBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            UxAddBtn.Location = new Point(29, 20);
            UxAddBtn.Margin = new Padding(2);
            UxAddBtn.Name = "UxAddBtn";
            UxAddBtn.Size = new Size(82, 43);
            UxAddBtn.TabIndex = 1;
            UxAddBtn.Text = "+";
            UxAddBtn.UseVisualStyleBackColor = true;
            UxAddBtn.Click += UxAddBtn_Click;
            // 
            // UxAlarmList
            // 
            UxAlarmList.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            UxAlarmList.FormattingEnabled = true;
            UxAlarmList.ItemHeight = 25;
            UxAlarmList.Location = new Point(29, 100);
            UxAlarmList.Margin = new Padding(2);
            UxAlarmList.Name = "UxAlarmList";
            UxAlarmList.ScrollAlwaysVisible = true;
            UxAlarmList.SelectionMode = SelectionMode.MultiSimple;
            UxAlarmList.Size = new Size(430, 179);
            UxAlarmList.TabIndex = 2;
            UxAlarmList.SelectedIndexChanged += UxAlarmList_SelectedIndexChanged;
            // 
            // button1
            // 
            button1.Location = new Point(29, 327);
            button1.Margin = new Padding(2);
            button1.Name = "button1";
            button1.Size = new Size(84, 43);
            button1.TabIndex = 3;
            button1.Text = "Snooze";
            button1.UseVisualStyleBackColor = true;
            button1.Click += UxSnoozeBtn_Click;
            // 
            // button2
            // 
            button2.Location = new Point(358, 327);
            button2.Margin = new Padding(2);
            button2.Name = "button2";
            button2.Size = new Size(84, 43);
            button2.TabIndex = 4;
            button2.Text = "Stop";
            button2.UseVisualStyleBackColor = true;
            button2.Click += UxStopBtn_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(179, 303);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(138, 20);
            label2.TabIndex = 6;
            label2.Text = "Alarm went OFF";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(208, 350);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(64, 20);
            label1.TabIndex = 6;
            label1.Text = ".         .";
            // 
            // button3
            // 
            button3.Location = new Point(464, 256);
            button3.Name = "button3";
            button3.Size = new Size(49, 23);
            button3.TabIndex = 7;
            button3.Text = "Delete";
            button3.UseVisualStyleBackColor = true;
            button3.Click += UxDeleteBtn_Click;
            // 
            // Alarm501
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(525, 420);
            Controls.Add(button3);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(UxAlarmList);
            Controls.Add(UxAddBtn);
            Controls.Add(UxEditBtn);
            Margin = new Padding(2);
            Name = "Alarm501";
            Text = "Alarm501";
            ResumeLayout(false);
            PerformLayout();
        }

        private void UxAlarmList_SelectedIndexChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.Button UxEditBtn;
        private System.Windows.Forms.Button UxAddBtn;
        public Label label2;
        public Label label1;
        public Button button1;
        public Button button2;
        public ListBox UxAlarmList;
        private Button button3;
    }
}