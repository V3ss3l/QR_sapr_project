using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QR_sapr_project
{
    public partial class Form1 : Form
    {
        private const int PixelPerModule = 5;

        public Form1()
        {
            InitializeComponent();
            cloudRef[000] = "https://disk.yandex.ru/d/4Z2ck911vuy1HA";
            cloudRef[001] = "https://disk.yandex.ru/d/mKeQnbIQBfvDxQ";
            cloudRef[002] = "https://disk.yandex.ru/d/mAQS6BUi8DPESA";
            cloudRef[003] = "https://disk.yandex.ru/d/-AIYOP5SEgsReQ";
            cloudRef[004] = "https://disk.yandex.ru/d/LOe04ZC15W8lvA";
            cloudRef[005] = "https://disk.yandex.ru/d/PlSvQ7dEimlsLQ";
            cloudRef[006] = "https://disk.yandex.ru/d/15iHEwBeSJYQuA";
            cloudRef[007] = "https://disk.yandex.ru/d/65tF-IXJO5eDHg";
            cloudObj[000] = "#001 П02 РД";
            cloudObj[001] = "#002 П02 ИИ";
            cloudObj[002] = "#003 П02 ПД";
            cloudObj[003] = "#004 П01 РД";
            cloudObj[004] = "#005 П01 ИИ";
            cloudObj[005] = "#006 П02 ИРД";
            cloudObj[006] = "#007 П01 ПД";
            cloudObj[007] = "#008 П01 ИРД";
            for(int i = 0; i < 8; i++)
            {
                comboBox1.Items.Add(cloudObj[i]);
            }
            comboBox1.SelectedIndex = 0;
        }

        string[] cloudRef = new string[999];
        string[] cloudObj = new string[999];

        private void showQR(int box)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            var qrData = qrGenerator.CreateQrCode(cloudRef[box], QRCodeGenerator.ECCLevel.H);
            var qrCode = new QRCode(qrData);
            var image = qrCode.GetGraphic(PixelPerModule);
            pictureBox1.Image = image;
        }

        private void button_print_Click(object sender, EventArgs e)
        {
            label1.Text = (comboBox1.SelectedIndex + 1).ToString() + "    " + cloudRef[comboBox1.SelectedIndex];
            showQR(comboBox1.SelectedIndex);
        }
    }
}
