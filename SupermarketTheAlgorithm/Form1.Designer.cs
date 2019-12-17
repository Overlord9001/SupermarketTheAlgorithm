namespace SupermarketTheAlgorithm
{
    partial class Form1
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
            this.supermarketPictureBox = new System.Windows.Forms.PictureBox();
            this.wallButton = new System.Windows.Forms.Button();
            this.walkableButton = new System.Windows.Forms.Button();
            this.selectedTextBox = new System.Windows.Forms.TextBox();
            this.selectedLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.supermarketPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // supermarketPictureBox
            // 
            this.supermarketPictureBox.Location = new System.Drawing.Point(0, 0);
            this.supermarketPictureBox.Name = "supermarketPictureBox";
            this.supermarketPictureBox.Size = new System.Drawing.Size(268, 247);
            this.supermarketPictureBox.TabIndex = 0;
            this.supermarketPictureBox.TabStop = false;
            this.supermarketPictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.supermarketPictureBox_MouseClick);
            // 
            // wallButton
            // 
            this.wallButton.Location = new System.Drawing.Point(713, 49);
            this.wallButton.Name = "wallButton";
            this.wallButton.Size = new System.Drawing.Size(75, 25);
            this.wallButton.TabIndex = 1;
            this.wallButton.Text = "Wall";
            this.wallButton.UseVisualStyleBackColor = true;
            this.wallButton.Click += new System.EventHandler(this.wallButton_Click);
            // 
            // walkableButton
            // 
            this.walkableButton.Location = new System.Drawing.Point(713, 78);
            this.walkableButton.Name = "walkableButton";
            this.walkableButton.Size = new System.Drawing.Size(75, 25);
            this.walkableButton.TabIndex = 3;
            this.walkableButton.Text = "Walkable";
            this.walkableButton.UseVisualStyleBackColor = true;
            this.walkableButton.Click += new System.EventHandler(this.walkableButton_Click);
            // 
            // selectedTextBox
            // 
            this.selectedTextBox.Location = new System.Drawing.Point(713, 21);
            this.selectedTextBox.Name = "selectedTextBox";
            this.selectedTextBox.ReadOnly = true;
            this.selectedTextBox.Size = new System.Drawing.Size(75, 22);
            this.selectedTextBox.TabIndex = 4;
            this.selectedTextBox.Text = "Wall";
            // 
            // selectedLabel
            // 
            this.selectedLabel.AutoSize = true;
            this.selectedLabel.Location = new System.Drawing.Point(710, 1);
            this.selectedLabel.Name = "selectedLabel";
            this.selectedLabel.Size = new System.Drawing.Size(63, 17);
            this.selectedLabel.TabIndex = 5;
            this.selectedLabel.Text = "Selected";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 501);
            this.Controls.Add(this.selectedLabel);
            this.Controls.Add(this.selectedTextBox);
            this.Controls.Add(this.walkableButton);
            this.Controls.Add(this.wallButton);
            this.Controls.Add(this.supermarketPictureBox);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.supermarketPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox supermarketPictureBox;
        private System.Windows.Forms.Button wallButton;
        private System.Windows.Forms.Button walkableButton;
        private System.Windows.Forms.TextBox selectedTextBox;
        private System.Windows.Forms.Label selectedLabel;
    }
}

