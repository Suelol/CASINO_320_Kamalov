using QRCoder;
using System;
using System.IO;
using System.Windows.Media.Imaging;
using System.Linq;
using System.Windows;
using CASINO.DBModel;
using System.Windows.Controls;

namespace CASINO.Pages
{
    public partial class PersonalInfo : Page
    {
        public PersonalInfo()
        {
            InitializeComponent();
            InitData();
        }

        private void InitData()
        {
            var user = ConnectionClass.db.Users.FirstOrDefault(u => u.Id == ConnectionClass.IsOnlineUserId);
            if (user != null)
            {
                loginBarTxt.Text = loginDown.Text = user.Login;
                balanceTxt.Text = user.Balance.ToString();
                emailTxt.Text = user.Email;

                // Генерация QR-кода
                string qrContent = $"Имя: {user.Login}\nEmail: {user.Email}\nБаланс: {user.Balance} р.";
                GenerateQRCode(qrContent);
            }
            else
            {
                loginBarTxt.Text = loginDown.Text = "Unknown user";
                balanceTxt.Text = "Unknown user";
                emailTxt.Text = "Unknown user";
            }
        }

        private void GenerateQRCode(string content)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(content, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);

            using (var qrCodeImage = qrCode.GetGraphic(20))
            {
                BitmapImage bitmapImage = new BitmapImage();
                using (MemoryStream stream = new MemoryStream())
                {
                    qrCodeImage.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                    stream.Position = 0;

                    bitmapImage.BeginInit();
                    bitmapImage.StreamSource = stream;
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.EndInit();
                }

                qrCodeImageControl.Source = bitmapImage;
            }
        }
    }
}
