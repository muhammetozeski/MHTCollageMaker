namespace MHTCollageMaker
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            MergeButton = new Button();
            DropLabel = new Label();
            richTextBox1 = new RichTextBox();
            IsVerticalCheckBox = new CheckBox();
            SuspendLayout();
            // 
            // MergeButton
            // 
            MergeButton.Location = new Point(12, 12);
            MergeButton.Name = "MergeButton";
            MergeButton.Size = new Size(464, 39);
            MergeButton.TabIndex = 0;
            MergeButton.Text = "Merge İmages";
            MergeButton.UseVisualStyleBackColor = true;
            MergeButton.Click += MergeButton_Click;
            // 
            // DropLabel
            // 
            DropLabel.AllowDrop = true;
            DropLabel.AutoSize = true;
            DropLabel.BorderStyle = BorderStyle.Fixed3D;
            DropLabel.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
            DropLabel.Location = new Point(91, 54);
            DropLabel.Name = "DropLabel";
            DropLabel.Size = new Size(302, 56);
            DropLabel.TabIndex = 1;
            DropLabel.Text = "Put Folder Here";
            DropLabel.DragDrop += DropLabel_DragDrop;
            DropLabel.DragEnter += DropLabel_DragEnter;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(12, 113);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.Size = new Size(464, 330);
            richTextBox1.TabIndex = 7;
            richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // IsVerticalCheckBox
            // 
            IsVerticalCheckBox.AutoSize = true;
            IsVerticalCheckBox.Location = new Point(404, 59);
            IsVerticalCheckBox.Name = "IsVerticalCheckBox";
            IsVerticalCheckBox.Size = new Size(80, 44);
            IsVerticalCheckBox.TabIndex = 8;
            IsVerticalCheckBox.Text = "Merge\r\nVertical";
            IsVerticalCheckBox.UseVisualStyleBackColor = true;
            IsVerticalCheckBox.CheckedChanged += IsVerticalCheckBox_CheckedChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(496, 455);
            Controls.Add(IsVerticalCheckBox);
            Controls.Add(richTextBox1);
            Controls.Add(DropLabel);
            Controls.Add(MergeButton);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button MergeButton;
        private Label DropLabel;
        private RichTextBox richTextBox1;
        private CheckBox IsVerticalCheckBox;
    }
}