namespace KeepScreenOn
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
            this.cmdEnable = new System.Windows.Forms.Button();
            this.cmdDisable = new System.Windows.Forms.Button();
            this.cmdDisableKeys = new System.Windows.Forms.Button();
            this.cmdEnableKeys = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdEnable
            // 
            this.cmdEnable.BackColor = System.Drawing.Color.Green;
            this.cmdEnable.Location = new System.Drawing.Point(12, 12);
            this.cmdEnable.Name = "cmdEnable";
            this.cmdEnable.Size = new System.Drawing.Size(213, 91);
            this.cmdEnable.TabIndex = 0;
            this.cmdEnable.Text = "Enable Screen";
            this.cmdEnable.UseVisualStyleBackColor = false;
            this.cmdEnable.Click += new System.EventHandler(this.cmdEnable_Click);
            // 
            // cmdDisable
            // 
            this.cmdDisable.BackColor = System.Drawing.Color.Red;
            this.cmdDisable.Location = new System.Drawing.Point(12, 12);
            this.cmdDisable.Name = "cmdDisable";
            this.cmdDisable.Size = new System.Drawing.Size(213, 91);
            this.cmdDisable.TabIndex = 1;
            this.cmdDisable.Text = "Disable Screen";
            this.cmdDisable.UseVisualStyleBackColor = false;
            this.cmdDisable.Click += new System.EventHandler(this.cmdDisable_Click);
            // 
            // cmdDisableKeys
            // 
            this.cmdDisableKeys.BackColor = System.Drawing.Color.Red;
            this.cmdDisableKeys.Location = new System.Drawing.Point(12, 121);
            this.cmdDisableKeys.Name = "cmdDisableKeys";
            this.cmdDisableKeys.Size = new System.Drawing.Size(213, 91);
            this.cmdDisableKeys.TabIndex = 2;
            this.cmdDisableKeys.Text = "Jiggle Off";
            this.cmdDisableKeys.UseVisualStyleBackColor = false;
            this.cmdDisableKeys.Click += new System.EventHandler(this.cmdDisableKeys_Click);
            // 
            // cmdEnableKeys
            // 
            this.cmdEnableKeys.BackColor = System.Drawing.Color.Green;
            this.cmdEnableKeys.Location = new System.Drawing.Point(14, 121);
            this.cmdEnableKeys.Name = "cmdEnableKeys";
            this.cmdEnableKeys.Size = new System.Drawing.Size(213, 91);
            this.cmdEnableKeys.TabIndex = 3;
            this.cmdEnableKeys.Text = "Jiggle ON";
            this.cmdEnableKeys.UseVisualStyleBackColor = false;
            this.cmdEnableKeys.Click += new System.EventHandler(this.cmdEnableKeys_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(239, 237);
            this.Icon = new System.Drawing.Icon(@".\notepad_icon.ico");
            this.Controls.Add(this.cmdEnableKeys);
            this.Controls.Add(this.cmdDisableKeys);
            this.Controls.Add(this.cmdDisable);
            this.Controls.Add(this.cmdEnable);
            this.Name = "Form1";
            this.Text = "KeepScreenOn";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdEnable;
        private System.Windows.Forms.Button cmdDisable;
        private System.Windows.Forms.Button cmdDisableKeys;
        private System.Windows.Forms.Button cmdEnableKeys;
    }
}

