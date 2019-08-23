namespace WindowsForms
{
    partial class AddVehicleForm
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Car",
            "HybridCar",
            "Helicopter"});
            this.comboBox1.Location = new System.Drawing.Point(49, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(123, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.ComboboxChecked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Type";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(142, 125);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 27);
            this.button1.TabIndex = 6;
            this.button1.Text = "Ok";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.EnterVehicle);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(254, 125);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(106, 27);
            this.button2.TabIndex = 7;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.CloseForm);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(12, 39);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(460, 81);
            this.dataGridView2.TabIndex = 8;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(366, 126);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(106, 26);
            this.button3.TabIndex = 9;
            this.button3.Text = "Random";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.GetRandomVehicle);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 10;
            // 
            // AddVehicleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 160);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "AddVehicleForm";
            this.Text = "AddVehicleForm";
            this.Load += new System.EventHandler(this.AddVehicleForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label label1;

    }
}