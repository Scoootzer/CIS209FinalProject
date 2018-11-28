namespace FinalProject {
    partial class RoleSelection {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.label1 = new System.Windows.Forms.Label();
            this.radio_Owner = new System.Windows.Forms.RadioButton();
            this.radio_Rep = new System.Windows.Forms.RadioButton();
            this.radio_Customer = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(260, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Which option best fits your role at this car dealership?";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // radio_Owner
            // 
            this.radio_Owner.Checked = true;
            this.radio_Owner.Location = new System.Drawing.Point(15, 32);
            this.radio_Owner.Name = "radio_Owner";
            this.radio_Owner.Size = new System.Drawing.Size(257, 24);
            this.radio_Owner.TabIndex = 1;
            this.radio_Owner.TabStop = true;
            this.radio_Owner.Text = "Owner";
            this.radio_Owner.UseVisualStyleBackColor = true;
            // 
            // radio_Rep
            // 
            this.radio_Rep.Location = new System.Drawing.Point(15, 82);
            this.radio_Rep.Name = "radio_Rep";
            this.radio_Rep.Size = new System.Drawing.Size(257, 24);
            this.radio_Rep.TabIndex = 2;
            this.radio_Rep.TabStop = true;
            this.radio_Rep.Text = "Representative";
            this.radio_Rep.UseVisualStyleBackColor = true;
            // 
            // radio_Customer
            // 
            this.radio_Customer.Location = new System.Drawing.Point(15, 132);
            this.radio_Customer.Name = "radio_Customer";
            this.radio_Customer.Size = new System.Drawing.Size(254, 24);
            this.radio_Customer.TabIndex = 3;
            this.radio_Customer.TabStop = true;
            this.radio_Customer.Text = "Customer";
            this.radio_Customer.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.Location = new System.Drawing.Point(12, 172);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(260, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Confirm Selection";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(30, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(242, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Buy cars from the dealership\'s inventory.";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(33, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(238, 30);
            this.label3.TabIndex = 6;
            this.label3.Text = "Assist customers and keep track of sales and inventory.";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(33, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(236, 30);
            this.label4.TabIndex = 7;
            this.label4.Text = "Keep track of reps, inventory, customers, and order cars.";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // RoleSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 204);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.radio_Customer);
            this.Controls.Add(this.radio_Rep);
            this.Controls.Add(this.radio_Owner);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "RoleSelection";
            this.Text = "Select Dealership Role";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radio_Owner;
        private System.Windows.Forms.RadioButton radio_Rep;
        private System.Windows.Forms.RadioButton radio_Customer;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}