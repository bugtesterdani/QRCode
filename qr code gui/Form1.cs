using QR_Code;
using System.Drawing.Imaging;

namespace qr_code_gui
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Speichere das Bitmap-Bild in ein MemoryStream und konvertiere es in ein Byte-Array
            using (MemoryStream ms = new Class1().MemoryStreamImage("HELLOWORLDWHATSUPMOVINGYO", 10, 23))
            {
                Bitmap bmp = new Bitmap(ms);
                bmp.Save("qr2.png", ImageFormat.Png);
                pictureBox1.Image = bmp;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
    }
}
