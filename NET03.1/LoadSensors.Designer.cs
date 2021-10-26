
namespace NET03._1
{
    partial class LoadSensors
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
            this.XMLButton = new System.Windows.Forms.Button();
            this.JsonButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // XMLButton
            // 
            this.XMLButton.Font = new System.Drawing.Font("Stencil", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.XMLButton.Location = new System.Drawing.Point(90, 12);
            this.XMLButton.Name = "XMLButton";
            this.XMLButton.Size = new System.Drawing.Size(183, 48);
            this.XMLButton.TabIndex = 0;
            this.XMLButton.Text = "FROM XML";
            this.XMLButton.UseVisualStyleBackColor = true;
            this.XMLButton.Click += new System.EventHandler(this.XMLButton_Click);
            // 
            // JsonButton
            // 
            this.JsonButton.Font = new System.Drawing.Font("Stencil", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.JsonButton.Location = new System.Drawing.Point(90, 81);
            this.JsonButton.Name = "JsonButton";
            this.JsonButton.Size = new System.Drawing.Size(183, 48);
            this.JsonButton.TabIndex = 1;
            this.JsonButton.Text = "FROM JSON";
            this.JsonButton.UseVisualStyleBackColor = true;
            this.JsonButton.Click += new System.EventHandler(this.JsonButton_Click);
            // 
            // LoadSensors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 149);
            this.Controls.Add(this.JsonButton);
            this.Controls.Add(this.XMLButton);
            this.Name = "LoadSensors";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "LoadSensors";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button XMLButton;
        private System.Windows.Forms.Button JsonButton;
    }
}