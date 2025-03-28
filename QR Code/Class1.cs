using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace QR_Code
{
    public class Class1
    {
        private int[] polyalpha =
        {
            0, 1, 25, 2, 50, 26, 198, 3, 223,
            51, 238, 27, 104, 199, 75, 4, 100, 224, 14,
            52, 141, 239, 129, 28, 193, 105, 248, 200, 8,
            76, 113, 5, 138, 101, 47, 225, 36, 15, 33,
            53, 147, 142, 218, 240, 18, 130, 69, 29, 181,
            194, 125, 106, 39, 249, 185, 201, 154, 9, 120,
            77, 228, 114, 166, 6, 191, 139, 98, 102, 221,
            48, 253, 226, 152, 37, 179, 16, 145, 34, 136,
            54, 208, 148, 206, 143, 150, 219, 189, 241, 210,
            19, 92, 131, 56, 70, 64, 30, 66, 182, 163,
            195, 72, 126, 110, 107, 58, 40, 84, 250, 133,
            186, 61, 202, 94, 155, 159, 10, 21, 121, 43,
            78, 212, 229, 172, 115, 243, 167, 87, 7, 112,
            192, 247, 140, 128, 99, 13, 103, 74, 222, 237,
            49, 197, 254, 24, 227, 165, 153, 119, 38, 184,
            180, 124, 17, 68, 146, 217, 35, 32, 137, 46,
            55, 63, 209, 91, 149, 188, 207, 205, 144, 135,
            151, 178, 220, 252, 190, 97, 242, 86, 211, 171,
            20, 42, 93, 158, 132, 60, 57, 83, 71, 109,
            65, 162, 31, 45, 67, 216, 183, 123, 164, 118,
            196, 23, 73, 236, 127, 12, 111, 246, 108, 161,
            59, 82, 41, 157, 85, 170, 251, 96, 134, 177,
            187, 204, 62, 90, 203, 89, 95, 176, 156, 169,
            160, 81, 11, 245, 22, 235, 122, 117, 44, 215,
            79, 174, 213, 233, 230, 231, 173, 232, 116, 214,
            244, 234, 168, 80, 88, 175
        };

        private byte[] mask0 =
        {
            153, 153, 153, 102, 102, 102, 153, 153, 153,
            102, 102, 102, 153, 153, 153, 150, 102, 153,
            150, 102, 102, 102, 153, 153, 102, 153
        };

        private int[] positions =
        {
            -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2,
            -2, -1, -1, -1, -1, -1, -1, -1, -2, -2, (17*8)+6, (17*8)+7, (16*8)+0, (16*8)+1, -2, -1, -1, -1, -1, -1, -1, -1, -2,
            -2, -1, -2, -2, -2, -2, -2, -1, -2, -2, (17*8)+4, (17*8)+5, (16*8)+2, (16*8)+3, -2, -1, -2, -2, -2, -2, -2, -1, -2,
            -2, -1, -2, -1, -1, -1, -2, -1, -2, -1, (17*8)+2, (17*8)+3, (16*8)+4, (16*8)+5, -2, -1, -2, -1, -1, -1, -2, -1, -2,
            -2, -1, -2, -1, -1, -1, -2, -1, -2, -2, (17*8)+0, (17*8)+1, (16*8)+6, (16*8)+7, -2, -1, -2, -1, -1, -1, -2, -1, -2,
            -2, -1, -2, -1, -1, -1, -2, -1, -2, -2, (18*8)+6, (18*8)+7, (15*8)+0, (15*8)+1, -2, -1, -2, -1, -1, -1, -2, -1, -2,
            -2, -1, -2, -2, -2, -2, -2, -1, -2, -2, (18*8)+4, (18*8)+5, (15*8)+2, (15*8)+3, -2, -1, -2, -2, -2, -2, -2, -1, -2,
            -2, -1, -1, -1, -1, -1, -1, -1, -2, -1, -2, -1, -2, -1, -2, -1, -1, -1, -1, -1, -1, -1, -2,
            -2, -2, -2, -2, -2, -2, -2, -2, -2, -1, (18*8)+2, (18*8)+3, (15*8)+4, (15*8)+1, -2, -2, -2, -2, -2, -2, -2, -2, -2,
            -2, -1, -1, -1, -2, -1, -1, -1, -1, -1, (18*8)+0, (18*8)+1, (15*8)+6, (15*8)+7, -1, -1, -2, -2, -2, -1, -2, -2, -2,
            -2, (25*8)+6, (25*8)+7, (24*8)+0, (24*8)+1, (23*8)+6, (23*8)+7, -2, (22*8)+0, (22*8)+1, (19*8)+6, (19*8)+7, (14*8)+0, (14*8)+1, (9*8)+6, (9*8)+7, (8*8)+0, (8*8)+1, (3*8)+6, (3*8)+7, (2*8)+0, (2*8)+1, -2,
            -2, (25*8)+4, (25*8)+5, (24*8)+2, (24*8)+3, (23*8)+4, (23*8)+5, -1, (22*8)+2, (22*8)+3, (19*8)+4, (19*8)+5, (14*8)+2, (14*8)+3, (9*8)+4, (9*8)+5, (8*8)+2, (8*8)+3, (3*8)+4, (3*8)+5, (2*8)+2, (2*8)+3, -2,
            -2, (25*8)+2, (25*8)+3, (24*8)+4, (24*8)+5, (23*8)+2, (23*8)+3, -2, (22*8)+4, (22*8)+5, (19*8)+2, (19*8)+3, (14*8)+4, (14*8)+5, (9*8)+2, (9*8)+3, (8*8)+4, (8*8)+5, (3*8)+2, (3*8)+3, (2*8)+4, (2*8)+5, -2,
            -2, (25*8)+0, (25*8)+1, (24*8)+6, (24*8)+7, (23*8)+0, (23*8)+1, -1, (22*8)+6, (22*8)+7, (19*8)+0, (19*8)+1, (14*8)+6, (14*8)+7, (9*8)+0, (9*8)+1, (8*8)+6, (8*8)+7, (3*8)+0, (3*8)+1, (2*8)+6, (2*8)+7, -2,
            -2, -2, -2, -2, -2, -2, -2, -2, -2, -1, (21*8)+6, (21*8)+7, (13*8)+0, (13*8)+1, (10*8)+6, (10*8)+7, (7*8)+0, (7*8)+1, (4*8)+6, (4*8)+7, (1*8)+0, (1*8)+1, -2,
            -2, -1, -1, -1, -1, -1, -1, -1, -2, -1, (21*8)+4, (21*8)+5, (13*8)+2, (13*8)+3, (10*8)+4, (10*8)+5, (7*8)+2, (7*8)+3, (4*8)+4, (4*8)+5, (1*8)+2, (1*8)+3, -2,
            -2, -1, -2, -2, -2, -2, -2, -1, -2, -1, (21*8)+2, (21*8)+3, (13*8)+4, (13*8)+5, (10*8)+2, (10*8)+3, (7*8)+4, (7*8)+5, (4*8)+2, (4*8)+3, (1*8)+4, (1*8)+5, -2,
            -2, -1, -2, -1, -1, -1, -2, -1, -2, -1, (21*8)+0, (21*8)+1, (13*8)+6, (13*8)+7, (10*8)+0, (10*8)+1, (7*8)+6, (7*8)+7, (4*8)+0, (4*8)+1, (1*8)+6, (1*8)+7, -2,
            -2, -1, -2, -1, -1, -1, -2, -1, -2, -2, (20*8)+6, (20*8)+7, (12*8)+0, (12*8)+1, (11*8)+6, (11*8)+7, (6*8)+0, (6*8)+1, (5*8)+6, (5*8)+7, (0*8)+0, (0*8)+1, -2,
            -2, -1, -2, -1, -1, -1, -2, -1, -2, -1, (20*8)+4, (20*8)+5, (12*8)+2, (12*8)+3, (11*8)+4, (11*8)+5, (6*8)+2, (6*8)+3, (5*8)+4, (5*8)+5, (0*8)+2, (0*8)+3, -2,
            -2, -1, -2, -2, -2, -2, -2, -1, -2, -1, (20*8)+2, (20*8)+3, (12*8)+4, (12*8)+5, (11*8)+2, (11*8)+3, (6*8)+4, (6*8)+5, (5*8)+2, (5*8)+3, (0*8)+4, (0*8)+5, -2,
            -2, -1, -1, -1, -1, -1, -1, -1, -2, -1, (20*8)+0, (20*8)+1, (12*8)+6, (12*8)+7, (11*8)+0, (11*8)+1, (6*8)+6, (6*8)+7, (5*8)+0, (5*8)+1, (0*8)+6, (0*8)+7, -2,
            -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2,
        };

        public MemoryStream MemoryStreamImage(string data, int faktor, int size)
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                throw new Exception("Only on Windows");

#pragma warning disable CA1416 // Plattformkompatibilität überprüfen
            byte[] values = GenQRCode(data);
            Bitmap bitmap = new Bitmap(size * faktor, size * faktor);
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.Clear(Color.White);
                for (int y = 0; y < size; y++)
                {
                    for (int x = 0; x < size; x++)
                    {
                        if (values[(y * size) + x] == 1)
                        {
                            for (int yfak = 0; yfak < faktor; yfak++)
                            {
                                for (int xfak = 0; xfak < faktor; xfak++)
                                {
                                    bitmap.SetPixel(x * faktor + xfak, y * faktor + yfak, Color.Black);
                                }
                            }
                        }
                    }
                }
            }
            MemoryStream ms = new MemoryStream();
            bitmap.Save(ms, ImageFormat.Png);
            return ms;
#pragma warning restore CA1416 // Plattformkompatibilität überprüfen
        }

        public byte[] GenQRCode(string data)
        {
            if (data.Length != 25)
                throw new Exception("Invalid data length");

            char[] characters =
            {
                '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
                'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J',
                'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T',
                'U', 'V', 'W', 'X', 'Y', 'Z', ' ', '$', '%', '*',
                '+', '-', '.', '/', ':'
            };

            int[] charvalues =
            {
                0, 0, 0, 0, 0,
                0, 0, 0, 0, 0,
                0, 0, 0, 0, 0,
                0, 0, 0, 0, 0,
                0, 0, 0, 0, 0
            };

            for (int i = 0; i < 25; i++)
            {
                if (!characters.Contains(data[i]))
                    throw new Exception("Invalid data character");
                int index = Array.IndexOf(characters, data[i]);
                if ((i % 2) == 0)
                    charvalues[i / 2] = index;
                else
                    charvalues[(i - 1) / 2] = charvalues[(i - 1) / 2] * 45 + index;
            }

            byte[] bytesvalues = genbytes(charvalues);
            byte[] maske0_check = new byte[26];
            for (int i = 0; i < 26; i++)
                maske0_check[i] = (byte)(bytesvalues[i] ^ mask0[i]);

            byte[] outputval = new byte[positions.Length];
            for (int i = 0; i < positions.Length; i++)
            {
                if (positions[i] < 0)
                    outputval[i] = (byte)(positions[i] + 2);
                else
                {
                    int index = positions[i] / 8;
                    int bit = positions[i] % 8;
                    outputval[i] = (byte)((maske0_check[index] >> bit) & 1);
                }
            }

            return outputval;
        }

        private byte[] genbytes(int[] charvalues)
        {
            string[] bitstrings = new string[13];
            for (int i = 0; i < 13; i++)
                bitstrings[i] = Convert.ToString(charvalues[i], 2).PadLeft(11, '0');

            bitstrings[12] = getString(bitstrings[12], 5, 4) + "000";
            string bits = "0010000011001" + string.Join("", bitstrings) + "";

            byte[] bitstring = new byte[26];
            byte[] originalbitstring = new byte[26];
            for (int i = 0; i < 19; i++)
                bitstring[i] = Convert.ToByte(getString(bits, i * 8, 8), 2);
            Array.Copy(bitstring, 0, originalbitstring, 0, 19);
            
            for (int i = 0; i < 19; i++)
            {
                byte[] new_bitstring = RoundValues(bitstring, i, polyalpha[bitstring[i] - 1]);
                for (int j = 0; j < 8; j++)
                    bitstring[i + j] = new_bitstring[j];
            }
            Array.Copy(bitstring, 19, originalbitstring, 19, 7);

            return originalbitstring;
        }

        private byte[] RoundValues(byte[] values, int indexvalueStart, int incrementer)
        {
            byte[] defaultValues =
            {
                0, 87, 229, 146, 149, 238, 102, 21
            };

            byte[] step1Values = new byte[8];
            for (int i = 0; i < 8; i++)
                step1Values[i] = (byte)((incrementer + defaultValues[i]) % 255);

            byte[] step2Values = new byte[8];
            for (int i = 0; i < 8; i++)
                step2Values[i] = (byte)(Array.IndexOf(polyalpha, step1Values[i]) + 1);

            byte[] step3Values = new byte[8];
            for (int i = 0; i < 8; i++)
                step3Values[i] = (byte)(values[i + indexvalueStart] ^ step2Values[i]);

            return step3Values;
        }

        private string getString(string data, int start, int length)
        {
            string result = "";
            for (int i = start; i < start + length; i++)
            {
                result += data[i];
            }
            return result;
        }
    }
}
