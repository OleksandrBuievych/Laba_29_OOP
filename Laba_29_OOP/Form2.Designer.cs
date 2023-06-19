
namespace Laba_29_OOP
{
    partial class SettingsForm
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
            this.saveButton = new System.Windows.Forms.Button();
            this.selectFontButton = new System.Windows.Forms.Button();
            this.groupadress = new System.Windows.Forms.Label();
            this.remotePortTextBox = new System.Windows.Forms.TextBox();
            this.groupAddressTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.fontLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.userNameTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.saveButton.Location = new System.Drawing.Point(233, 327);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(271, 125);
            this.saveButton.TabIndex = 0;
            this.saveButton.Text = "Зберегти зміни";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // selectFontButton
            // 
            this.selectFontButton.Location = new System.Drawing.Point(150, 210);
            this.selectFontButton.Name = "selectFontButton";
            this.selectFontButton.Size = new System.Drawing.Size(146, 40);
            this.selectFontButton.TabIndex = 1;
            this.selectFontButton.Text = "Обрати шрифт";
            this.selectFontButton.UseVisualStyleBackColor = true;
            this.selectFontButton.Click += new System.EventHandler(this.selectFontButton_Click);
            // 
            // groupadress
            // 
            this.groupadress.AutoSize = true;
            this.groupadress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupadress.Location = new System.Drawing.Point(116, 25);
            this.groupadress.Name = "groupadress";
            this.groupadress.Size = new System.Drawing.Size(151, 25);
            this.groupadress.TabIndex = 2;
            this.groupadress.Text = "Введіть адресу";
            // 
            // remotePortTextBox
            // 
            this.remotePortTextBox.Location = new System.Drawing.Point(302, 75);
            this.remotePortTextBox.Name = "remotePortTextBox";
            this.remotePortTextBox.Size = new System.Drawing.Size(301, 22);
            this.remotePortTextBox.TabIndex = 3;
            // 
            // groupAddressTextBox
            // 
            this.groupAddressTextBox.Location = new System.Drawing.Point(302, 28);
            this.groupAddressTextBox.Name = "groupAddressTextBox";
            this.groupAddressTextBox.Size = new System.Drawing.Size(301, 22);
            this.groupAddressTextBox.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(134, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Введіть порт";
            // 
            // fontLabel
            // 
            this.fontLabel.AutoSize = true;
            this.fontLabel.Location = new System.Drawing.Point(355, 222);
            this.fontLabel.Name = "fontLabel";
            this.fontLabel.Size = new System.Drawing.Size(190, 17);
            this.fontLabel.TabIndex = 6;
            this.fontLabel.Text = "Текст буде таким шрифтом";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(95, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "Введіть нове ім\'я";
            // 
            // userNameTextBox
            // 
            this.userNameTextBox.Location = new System.Drawing.Point(302, 119);
            this.userNameTextBox.Name = "userNameTextBox";
            this.userNameTextBox.Size = new System.Drawing.Size(301, 22);
            this.userNameTextBox.TabIndex = 8;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.userNameTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fontLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupAddressTextBox);
            this.Controls.Add(this.remotePortTextBox);
            this.Controls.Add(this.groupadress);
            this.Controls.Add(this.selectFontButton);
            this.Controls.Add(this.saveButton);
            this.Name = "SettingsForm";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button selectFontButton;
        private System.Windows.Forms.Label groupadress;
        private System.Windows.Forms.TextBox remotePortTextBox;
        private System.Windows.Forms.TextBox groupAddressTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label fontLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox userNameTextBox;
    }
}