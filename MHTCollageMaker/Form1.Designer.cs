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
            this.MergeButton = new System.Windows.Forms.Button();
            this.DropLabel = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // MergeButton
            // 
            this.MergeButton.Location = new System.Drawing.Point(12, 12);
            this.MergeButton.Name = "MergeButton";
            this.MergeButton.Size = new System.Drawing.Size(464, 39);
            this.MergeButton.TabIndex = 0;
            this.MergeButton.Text = "Merge İmages";
            this.MergeButton.UseVisualStyleBackColor = true;
            this.MergeButton.Click += new System.EventHandler(this.MergeButton_Click);
            // 
            // DropLabel
            // 
            this.DropLabel.AllowDrop = true;
            this.DropLabel.AutoSize = true;
            this.DropLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DropLabel.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DropLabel.Location = new System.Drawing.Point(91, 54);
            this.DropLabel.Name = "DropLabel";
            this.DropLabel.Size = new System.Drawing.Size(302, 56);
            this.DropLabel.TabIndex = 1;
            this.DropLabel.Text = "Put Folder Here";
            this.DropLabel.DragDrop += new System.Windows.Forms.DragEventHandler(this.DropLabel_DragDrop);
            this.DropLabel.DragEnter += new System.Windows.Forms.DragEventHandler(this.DropLabel_DragEnter);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 113);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(464, 330);
            this.richTextBox1.TabIndex = 7;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 455);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.DropLabel);
            this.Controls.Add(this.MergeButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button MergeButton;
        private Label DropLabel;
        private RichTextBox richTextBox1;
    }
}