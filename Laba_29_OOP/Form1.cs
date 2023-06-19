using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.IO;

namespace Laba_29_OOP
{
    public partial class Form1 : Form
    {
        bool alive = false; // чи буде працювати потік для приймання
        UdpClient client;
        private int LOCALPORT = 8001; // порт для приймання повідомлень
        private int REMOTEPORT = 8001; // порт для передавання повідомлень
        const int TTL = 20;
        const string HOST = "235.5.5.1"; // хост для групового розсилання
        IPAddress groupAddress; // адреса для групового розсилання
        string userName; // ім’я користувача в чаті
        private string previousUserName; // попереднє ім'я користувача

        public Form1()
        {
            InitializeComponent();
            loginButton.Enabled = true;
            logoutButton.Enabled = false;
            sendButton.Enabled = false;
            chatTextBox.ReadOnly = true;
            groupAddress = IPAddress.Parse(HOST);
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            previousUserName = userName;
            userName = userNameTextBox.Text;
            userNameTextBox.ReadOnly = true;
            try
            {
                client = new UdpClient(LOCALPORT);
                //підєднання до групового розсилання
                client.JoinMulticastGroup(groupAddress, TTL);

                // задача на приймання повідомлень
                Task receiveTask = new Task(ReceiveMessages);
                receiveTask.Start();
                // перше повідомлення про вхід нового користувача
                string message = userName + " вошел в чат";
                byte[] data = Encoding.Unicode.GetBytes(message);
                client.Send(data, data.Length, HOST, REMOTEPORT);
                loginButton.Enabled = false;
                logoutButton.Enabled = true;
                sendButton.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // метод приймання повідомлення
        private void ReceiveMessages()
        {
            alive = true;
            try
            {
                while (alive)
                {
                    IPEndPoint remoteIp = null;
                    byte[] data = client.Receive(ref remoteIp);
                    string message = Encoding.Unicode.GetString(data);
                    // добавляем полученное сообщение в текстовое поле
                    this.Invoke(new MethodInvoker(() =>
                    {
                        string time = DateTime.Now.ToShortTimeString();
                        chatTextBox.Text = time + " " + message + "\r\n"  + chatTextBox.Text;
                    }));
                }
            }
            catch (ObjectDisposedException)
            {
                if (!alive)
                    return;
                throw;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        // обробник натискання кнопки sendButton
        private void sendButton_Click(object sender, EventArgs e)
        {
            try
            {
                string message = String.Format("{0}: {1}", userName, messageTextBox.Text);
                byte[] data = Encoding.Unicode.GetBytes(message);
                client.Send(data, data.Length, HOST, REMOTEPORT);
                messageTextBox.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        // обробник натискання кнопки logoutButton
        private void logoutButton_Click(object sender, EventArgs e)
        {
            ExitChat();
        }
        // вихід з чату
        private void ExitChat()
        {
            string message = userName + " покидает чат";
            byte[] data = Encoding.Unicode.GetBytes(message);
            client.Send(data, data.Length, HOST, REMOTEPORT);
            client.DropMulticastGroup(groupAddress);
            alive = false;
            client.Close();
            loginButton.Enabled = true;
            logoutButton.Enabled = false;
            sendButton.Enabled = false;
        }
        // обработчик события закрытия формы
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (alive)
                ExitChat();
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            // Відкриваємо діалогове вікно для налаштування
            SettingsForm settingsForm = new SettingsForm(groupAddress.ToString(), REMOTEPORT, Font, userName);
            if (settingsForm.ShowDialog() == DialogResult.OK)
            {
                if (settingsForm.UserName != userName)
                {
                    UpdateUserName(settingsForm.UserName);
                    string message = String.Format("Користувач змінив ім'я на {0}", userName);
                    byte[] data = Encoding.Unicode.GetBytes(message);
                    client.Send(data, data.Length, HOST, REMOTEPORT);
                }

                groupAddress = IPAddress.Parse(settingsForm.GroupAddress);
                REMOTEPORT = settingsForm.RemotePort;
                Font = settingsForm.SelectedFont;
            }
        }

        private void UpdateUserName(string newUserName)
        {
            if (!string.IsNullOrEmpty(newUserName))
            {
                userName = newUserName;
                userNameTextBox.Text = userName;
                previousUserName = userName;
            }
        }

        private void SaveChatLog(string fileName)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    writer.WriteLine(chatTextBox.Text);
                }

                MessageBox.Show("Лог чату збережено до файлу.", "Успішно", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка при збереженні логу чату: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void saveLogButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files|*.txt";
            saveFileDialog.Title = "Зберегти лог чату";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                SaveChatLog(saveFileDialog.FileName);
            }
        }

    }
}


