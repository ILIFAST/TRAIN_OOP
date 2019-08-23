namespace WindowsForms
{
    partial class SearchForm
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
			this.matchCheckBox = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.ConsumptionBox1 = new System.Windows.Forms.TextBox();
			this.authorsLabel = new System.Windows.Forms.Label();
			this.NameTextBox = new System.Windows.Forms.TextBox();
			this.titleLabel = new System.Windows.Forms.Label();
			this.TypeTextBox = new System.Windows.Forms.TextBox();
			this.searchButton = new System.Windows.Forms.Button();
			this.SpeedTextBox = new System.Windows.Forms.TextBox();
			this.cityLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// matchCheckBox
			// 
			this.matchCheckBox.AutoSize = true;
			this.matchCheckBox.Location = new System.Drawing.Point(12, 120);
			this.matchCheckBox.Name = "matchCheckBox";
			this.matchCheckBox.Size = new System.Drawing.Size(74, 17);
			this.matchCheckBox.TabIndex = 24;
			this.matchCheckBox.Text = "Full match";
			this.matchCheckBox.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 64);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 13);
			this.label1.TabIndex = 23;
			this.label1.Text = "OilConsumption";
			// 
			// ConsumptionBox1
			// 
			this.ConsumptionBox1.Location = new System.Drawing.Point(97, 61);
			this.ConsumptionBox1.Name = "ConsumptionBox1";
			this.ConsumptionBox1.Size = new System.Drawing.Size(100, 20);
			this.ConsumptionBox1.TabIndex = 22;
			// 
			// authorsLabel
			// 
			this.authorsLabel.AutoSize = true;
			this.authorsLabel.Location = new System.Drawing.Point(12, 38);
			this.authorsLabel.Name = "authorsLabel";
			this.authorsLabel.Size = new System.Drawing.Size(35, 13);
			this.authorsLabel.TabIndex = 21;
			this.authorsLabel.Text = "Name";
			// 
			// NameTextBox
			// 
			this.NameTextBox.Location = new System.Drawing.Point(97, 35);
			this.NameTextBox.Name = "NameTextBox";
			this.NameTextBox.Size = new System.Drawing.Size(100, 20);
			this.NameTextBox.TabIndex = 20;
			// 
			// titleLabel
			// 
			this.titleLabel.AutoSize = true;
			this.titleLabel.Location = new System.Drawing.Point(12, 12);
			this.titleLabel.Name = "titleLabel";
			this.titleLabel.Size = new System.Drawing.Size(31, 13);
			this.titleLabel.TabIndex = 19;
			this.titleLabel.Text = "Type";
			// 
			// TypeTextBox
			// 
			this.TypeTextBox.Location = new System.Drawing.Point(97, 9);
			this.TypeTextBox.Name = "TypeTextBox";
			this.TypeTextBox.Size = new System.Drawing.Size(100, 20);
			this.TypeTextBox.TabIndex = 18;
			// 
			// searchButton
			// 
			this.searchButton.Location = new System.Drawing.Point(122, 116);
			this.searchButton.Name = "searchButton";
			this.searchButton.Size = new System.Drawing.Size(75, 23);
			this.searchButton.TabIndex = 17;
			this.searchButton.Text = "Search";
			this.searchButton.UseVisualStyleBackColor = true;
			this.searchButton.Click += new System.EventHandler(this.SearchVehicle);
			// 
			// SpeedTextBox
			// 
			this.SpeedTextBox.Location = new System.Drawing.Point(97, 87);
			this.SpeedTextBox.Name = "SpeedTextBox";
			this.SpeedTextBox.Size = new System.Drawing.Size(100, 20);
			this.SpeedTextBox.TabIndex = 15;
			// 
			// cityLabel
			// 
			this.cityLabel.AutoSize = true;
			this.cityLabel.Location = new System.Drawing.Point(12, 90);
			this.cityLabel.Name = "cityLabel";
			this.cityLabel.Size = new System.Drawing.Size(38, 13);
			this.cityLabel.TabIndex = 16;
			this.cityLabel.Text = "Speed";
			// 
			// SearchForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(206, 148);
			this.Controls.Add(this.matchCheckBox);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.ConsumptionBox1);
			this.Controls.Add(this.authorsLabel);
			this.Controls.Add(this.NameTextBox);
			this.Controls.Add(this.titleLabel);
			this.Controls.Add(this.TypeTextBox);
			this.Controls.Add(this.searchButton);
			this.Controls.Add(this.cityLabel);
			this.Controls.Add(this.SpeedTextBox);
			this.Name = "SearchForm";
			this.Text = "SearchForm";
			this.Load += new System.EventHandler(this.SearchForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox matchCheckBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ConsumptionBox1;
        private System.Windows.Forms.Label authorsLabel;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.TextBox TypeTextBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.TextBox SpeedTextBox;
        private System.Windows.Forms.Label cityLabel;
    }
}