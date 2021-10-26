
namespace NET03._1
{
    partial class SensorsMain
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
            this.SensorsList = new System.Windows.Forms.ListBox();
            this.LableList = new System.Windows.Forms.Label();
            this.CreateButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.ModeButton = new System.Windows.Forms.Button();
            this.SensorsStatusText = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.StratButton = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.SaveToXMLButton = new System.Windows.Forms.Button();
            this.SaveToJsonButton = new System.Windows.Forms.Button();
            this.LoadConfigurationButton = new System.Windows.Forms.Button();
            this.SwitchingModeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SensorsList
            // 
            this.SensorsList.FormattingEnabled = true;
            this.SensorsList.ItemHeight = 20;
            this.SensorsList.Location = new System.Drawing.Point(267, 49);
            this.SensorsList.Name = "SensorsList";
            this.SensorsList.Size = new System.Drawing.Size(450, 204);
            this.SensorsList.TabIndex = 0;
            // 
            // LableList
            // 
            this.LableList.AutoSize = true;
            this.LableList.Font = new System.Drawing.Font("Stencil", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LableList.Location = new System.Drawing.Point(391, 9);
            this.LableList.Name = "LableList";
            this.LableList.Size = new System.Drawing.Size(211, 27);
            this.LableList.TabIndex = 1;
            this.LableList.Text = "List of sensors :";
            // 
            // CreateButton
            // 
            this.CreateButton.Font = new System.Drawing.Font("Stencil", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CreateButton.Location = new System.Drawing.Point(11, 353);
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(209, 56);
            this.CreateButton.TabIndex = 2;
            this.CreateButton.Text = "Create sensor";
            this.CreateButton.UseVisualStyleBackColor = true;
            this.CreateButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Font = new System.Drawing.Font("Stencil", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DeleteButton.Location = new System.Drawing.Point(11, 446);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(209, 56);
            this.DeleteButton.TabIndex = 3;
            this.DeleteButton.Text = "Delete sensor";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // ModeButton
            // 
            this.ModeButton.Font = new System.Drawing.Font("Stencil", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ModeButton.Location = new System.Drawing.Point(738, 49);
            this.ModeButton.Name = "ModeButton";
            this.ModeButton.Size = new System.Drawing.Size(209, 56);
            this.ModeButton.TabIndex = 5;
            this.ModeButton.Text = "Change mode";
            this.ModeButton.UseVisualStyleBackColor = true;
            this.ModeButton.Click += new System.EventHandler(this.ModeButton_Click);
            // 
            // SensorsStatusText
            // 
            this.SensorsStatusText.Location = new System.Drawing.Point(267, 339);
            this.SensorsStatusText.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SensorsStatusText.Name = "SensorsStatusText";
            this.SensorsStatusText.ReadOnly = true;
            this.SensorsStatusText.Size = new System.Drawing.Size(450, 183);
            this.SensorsStatusText.TabIndex = 6;
            this.SensorsStatusText.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Stencil", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(389, 290);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(213, 27);
            this.label1.TabIndex = 7;
            this.label1.Text = "Sensors Status :";
            // 
            // StratButton
            // 
            this.StratButton.Font = new System.Drawing.Font("Stencil", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.StratButton.Location = new System.Drawing.Point(11, 122);
            this.StratButton.Name = "StratButton";
            this.StratButton.Size = new System.Drawing.Size(209, 56);
            this.StratButton.TabIndex = 8;
            this.StratButton.Text = "Start";
            this.StratButton.UseVisualStyleBackColor = true;
            this.StratButton.Click += new System.EventHandler(this.StratButton_Click);
            // 
            // StopButton
            // 
            this.StopButton.Font = new System.Drawing.Font("Stencil", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.StopButton.Location = new System.Drawing.Point(11, 197);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(209, 56);
            this.StopButton.TabIndex = 9;
            this.StopButton.Text = "Stop";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // SaveToXMLButton
            // 
            this.SaveToXMLButton.Font = new System.Drawing.Font("Stencil", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SaveToXMLButton.Location = new System.Drawing.Point(738, 353);
            this.SaveToXMLButton.Name = "SaveToXMLButton";
            this.SaveToXMLButton.Size = new System.Drawing.Size(209, 56);
            this.SaveToXMLButton.TabIndex = 10;
            this.SaveToXMLButton.Text = "Save to XML";
            this.SaveToXMLButton.UseVisualStyleBackColor = true;
            this.SaveToXMLButton.Click += new System.EventHandler(this.SaveToXMLButton_Click);
            // 
            // SaveToJsonButton
            // 
            this.SaveToJsonButton.Font = new System.Drawing.Font("Stencil", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SaveToJsonButton.Location = new System.Drawing.Point(738, 446);
            this.SaveToJsonButton.Name = "SaveToJsonButton";
            this.SaveToJsonButton.Size = new System.Drawing.Size(209, 56);
            this.SaveToJsonButton.TabIndex = 11;
            this.SaveToJsonButton.Text = "Save to JSON";
            this.SaveToJsonButton.UseVisualStyleBackColor = true;
            this.SaveToJsonButton.Click += new System.EventHandler(this.SaveToJsonButton_Click);
            // 
            // LoadConfigurationButton
            // 
            this.LoadConfigurationButton.Font = new System.Drawing.Font("Stencil", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LoadConfigurationButton.Location = new System.Drawing.Point(11, 49);
            this.LoadConfigurationButton.Name = "LoadConfigurationButton";
            this.LoadConfigurationButton.Size = new System.Drawing.Size(210, 56);
            this.LoadConfigurationButton.TabIndex = 12;
            this.LoadConfigurationButton.Text = "Load Config";
            this.LoadConfigurationButton.UseVisualStyleBackColor = true;
            this.LoadConfigurationButton.Click += new System.EventHandler(this.LoadConfigurationButton_Click);
            // 
            // SwitchingModeButton
            // 
            this.SwitchingModeButton.Font = new System.Drawing.Font("Stencil", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SwitchingModeButton.Location = new System.Drawing.Point(738, 122);
            this.SwitchingModeButton.Name = "SwitchingModeButton";
            this.SwitchingModeButton.Size = new System.Drawing.Size(209, 56);
            this.SwitchingModeButton.TabIndex = 13;
            this.SwitchingModeButton.Text = "Switching mode CYcle";
            this.SwitchingModeButton.UseVisualStyleBackColor = true;
            this.SwitchingModeButton.Click += new System.EventHandler(this.SwitchingModeButton_Click);
            // 
            // SensorsMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 537);
            this.Controls.Add(this.SwitchingModeButton);
            this.Controls.Add(this.LoadConfigurationButton);
            this.Controls.Add(this.SaveToJsonButton);
            this.Controls.Add(this.SaveToXMLButton);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.StratButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SensorsStatusText);
            this.Controls.Add(this.ModeButton);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.CreateButton);
            this.Controls.Add(this.LableList);
            this.Controls.Add(this.SensorsList);
            this.Name = "SensorsMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sensors";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox SensorsList;
        private System.Windows.Forms.Label LableList;
        private System.Windows.Forms.Button CreateButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button ModeButton;
        private System.Windows.Forms.RichTextBox SensorsStatusText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button StratButton;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.Button SaveToXMLButton;
        private System.Windows.Forms.Button SaveToJsonButton;
        private System.Windows.Forms.Button LoadConfigurationButton;
        private System.Windows.Forms.Button SwitchingModeButton;
    }
}

