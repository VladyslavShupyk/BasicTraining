
namespace NET03._1
{
    partial class CreateSensor
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
            this.Interval = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.TypeComboBox = new System.Windows.Forms.ComboBox();
            this.OperationComboBox = new System.Windows.Forms.ComboBox();
            this.IntervalComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // Interval
            // 
            this.Interval.AutoSize = true;
            this.Interval.Font = new System.Drawing.Font("Stencil", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Interval.Location = new System.Drawing.Point(12, 65);
            this.Interval.Name = "Interval";
            this.Interval.Size = new System.Drawing.Size(120, 24);
            this.Interval.TabIndex = 0;
            this.Interval.Text = "Interval : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Stencil", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "Type : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Stencil", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(12, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "Operation : ";
            // 
            // SaveButton
            // 
            this.SaveButton.Font = new System.Drawing.Font("Stencil", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SaveButton.Location = new System.Drawing.Point(124, 163);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(177, 41);
            this.SaveButton.TabIndex = 6;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // TypeComboBox
            // 
            this.TypeComboBox.FormattingEnabled = true;
            this.TypeComboBox.Location = new System.Drawing.Point(154, 19);
            this.TypeComboBox.Name = "TypeComboBox";
            this.TypeComboBox.Size = new System.Drawing.Size(232, 28);
            this.TypeComboBox.TabIndex = 7;
            // 
            // OperationComboBox
            // 
            this.OperationComboBox.FormattingEnabled = true;
            this.OperationComboBox.Location = new System.Drawing.Point(154, 112);
            this.OperationComboBox.Name = "OperationComboBox";
            this.OperationComboBox.Size = new System.Drawing.Size(232, 28);
            this.OperationComboBox.TabIndex = 8;
            // 
            // IntervalComboBox
            // 
            this.IntervalComboBox.FormattingEnabled = true;
            this.IntervalComboBox.Location = new System.Drawing.Point(154, 65);
            this.IntervalComboBox.Name = "IntervalComboBox";
            this.IntervalComboBox.Size = new System.Drawing.Size(232, 28);
            this.IntervalComboBox.TabIndex = 9;
            // 
            // CreateSensor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 216);
            this.Controls.Add(this.IntervalComboBox);
            this.Controls.Add(this.OperationComboBox);
            this.Controls.Add(this.TypeComboBox);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Interval);
            this.Name = "CreateSensor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CreateSensor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Interval;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.ComboBox TypeComboBox;
        private System.Windows.Forms.ComboBox OperationComboBox;
        private System.Windows.Forms.ComboBox IntervalComboBox;
    }
}