using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba_29_OOP
{
    public partial class SettingsForm : Form
    {
        // Змінні для збереження введених користувачем налаштувань
        public string GroupAddress { get; private set; }
        public int RemotePort { get; private set; }
        public Font SelectedFont { get; private set; }
        public string UserName { get; private set; }


        public SettingsForm(string groupAddress, int remotePort, Font selectedFont, string userName)
        {
            InitializeComponent();

            // Ініціалізуємо поля форми поточними значеннями налаштувань
            GroupAddress = groupAddress;
            RemotePort = remotePort;
            SelectedFont = selectedFont;
            UserName = userName;

            groupAddressTextBox.Text = groupAddress;
            remotePortTextBox.Text = remotePort.ToString();
            fontLabel.Font = selectedFont;
            userNameTextBox.Text = userName;
        }

        

        private void selectFontButton_Click(object sender, EventArgs e)
        {
            // Створюємо новий екземпляр діалогового вікна для вибору шрифту
            FontDialog fontDialog = new FontDialog();
            fontDialog.Font = fontLabel.Font;

            // Перевіряємо результат діалогового вікна
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                // Оновлюємо шрифт мітки та зберігаємо вибраний шрифт
                fontLabel.Font = fontDialog.Font;
                SelectedFont = fontDialog.Font;
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            // Зберегаємо нові значення налаштувань
            GroupAddress = groupAddressTextBox.Text;
            int.TryParse(remotePortTextBox.Text, out int port);
            RemotePort = port;
            SelectedFont = fontLabel.Font;
            UserName = userNameTextBox.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

    }

}
