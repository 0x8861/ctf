using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

namespace bmpunhide
{
    /// <summary>
    /// Usage: 
    /// * To hide: bmpunhide.exe [bmp_image] [hidden_file] [output_filename]
    /// * To unhide: bmpunhide.exe [encrypted_bmp_image] [output_filename]
    /// </summary>
    class Program
    {
        public static byte a(byte b, int r)
        {
            for (int i = 0; i < r; i++)
            {
                byte b2 = (byte)((b & 0x80) / 128);
                b = (byte)(((b * 2) & 0xFF) + b2);
            }
            return b;
        }

        public static byte da(byte eb, int r)
        {
            for (int i = 0; i < r; i++)
            {
                eb = (byte)(((eb & 1) == 0) ? (eb >> 1) : ((eb >> 1) | 0x80));
            }
            return eb;
        }

        public static byte b(byte b, int r)
        {
            for (int i = 0; i < r; i++)
            {
                byte b2 = (byte)((b & 0x80) / 128);
                b = (byte)(((b * 2) & 0xFF) + b2);
            }
            return b;
        }


        public static byte c(byte b, int r)
        {
            for (int i = 0; i < r; i++)
            {
                byte b2 = (byte)((b & 1) * 128);
                b = (byte)((((int)b / 2) & 0xFF) + b2);
            }
            return b;
        }

        public static byte dc(byte eb, int r)
        {
            for (int i = 0; i < r; i++)
            {
                if (eb >= 128)
                {
                    eb = (byte)((eb - 128) * 2 + 1);
                }
                else
                {
                    eb = (byte)((eb << 1) & 0xFF);
                }
            }
            return eb;
        }

        public static byte d(byte b, int r)
        {
            for (int i = 0; i < r; i++)
            {
                byte b2 = (byte)((b & 1) * 128);
                b = (byte)((((int)b / 2) & 0xFF) + b2);
            }
            return b;
        }


        public static byte e(byte b, byte k)
        {
            for (int i = 0; i < 8; i++)
            {
                b = ((((b >> i) & 1) != ((k >> i) & 1)) ? ((byte)(b | ((1 << i) & 0xFF))) : ((byte)(b & ~(1 << i) & 0xFF)));
            }
            return b;
        }

        public static byte de(byte eb, byte k)
        {
            return (byte)(eb ^ k);
        }

        public static byte f(int idx)
        {
            int num = 0;
            int num2 = 0;
            byte result = 0;
            int num3 = 0;
            int[] array = new int[256]
            {
        121,
        255,
        214,
        60,
        106,
        216,
        149,
        89,
        96,
        29,
        81,
        123,
        182,
        24,
        167,
        252,
        88,
        212,
        43,
        85,
        181,
        86,
        108,
        213,
        50,
        78,
        247,
        83,
        193,
        35,
        135,
        217,
        0,
        64,
        45,
        236,
        134,
        102,
        76,
        74,
        153,
        34,
        39,
        10,
        192,
        202,
        71,
        183,
        185,
        175,
        84,
        118,
        9,
        158,
        66,
        128,
        116,
        117,
        4,
        13,
        46,
        227,
        132,
        240,
        122,
        11,
        18,
        186,
        30,
        157,
        1,
        154,
        144,
        124,
        152,
        187,
        32,
        87,
        141,
        103,
        189,
        12,
        53,
        222,
        206,
        91,
        20,
        174,
        49,
        223,
        155,
        250,
        95,
        31,
        98,
        151,
        179,
        101,
        47,
        17,
        207,
        142,
        199,
        3,
        205,
        163,
        146,
        48,
        165,
        225,
        62,
        33,
        119,
        52,
        241,
        228,
        162,
        90,
        140,
        232,
        129,
        114,
        75,
        82,
        190,
        65,
        2,
        21,
        14,
        111,
        115,
        36,
        107,
        67,
        126,
        80,
        110,
        23,
        44,
        226,
        56,
        7,
        172,
        221,
        239,
        161,
        61,
        93,
        94,
        99,
        171,
        97,
        38,
        40,
        28,
        166,
        209,
        229,
        136,
        130,
        164,
        194,
        243,
        220,
        25,
        169,
        105,
        238,
        245,
        215,
        195,
        203,
        170,
        16,
        109,
        176,
        27,
        184,
        148,
        131,
        210,
        231,
        125,
        177,
        26,
        246,
        127,
        198,
        254,
        6,
        69,
        237,
        197,
        54,
        59,
        137,
        79,
        178,
        139,
        235,
        249,
        230,
        233,
        204,
        196,
        113,
        120,
        173,
        224,
        55,
        92,
        211,
        112,
        219,
        208,
        77,
        191,
        242,
        133,
        244,
        168,
        188,
        138,
        251,
        70,
        150,
        145,
        248,
        180,
        218,
        42,
        15,
        159,
        104,
        22,
        37,
        72,
        63,
        234,
        147,
        200,
        253,
        100,
        19,
        73,
        5,
        57,
        201,
        51,
        156,
        41,
        143,
        68,
        8,
        160,
        58
            };
            for (int i = 0; i <= idx; i++)
            {
                num++;
                num %= 256;
                num2 += array[num];
                num2 %= 256;
                num3 = array[num];
                array[num] = array[num2];
                array[num2] = num3;
                result = (byte)array[(array[num] + array[num2]) % 256];
            }
            return result;
        }

        public static byte g(int idx)
        {
            byte b = (byte)((idx + 1) * 309030853u);
            byte k = (byte)((idx + 2) * 209897853);
            return e(b, k);
        }


        public static byte[] h(byte[] data)
        {
            Console.WriteLine("Encrypting...");
            byte[] array = new byte[data.Length];
            int num = 0;
            for (int i = 0; i < data.Length; i++)
            {
                int num3 = g(num++);
                int num4 = data[i];
                num4 = e((byte)num4, (byte)num3);
                num4 = a((byte)num4, 7);
                int num6 = g(num++);
                num4 = e((byte)num4, (byte)num6);
                num4 = c((byte)num4, 3);
                array[i] = (byte)num4;
            }
            return array;
        }


        public static void i(Bitmap bm, byte[] data)
        {
            int num = Program.j(103);
            for (int i = Program.j(103); i < bm.Width; i++)
            {
                for (int j = Program.j(103); j < bm.Height; j++)
                {
                    if (num > data.Length - Program.j(231))
                    {
                        break;
                    }
                    Color pixel = bm.GetPixel(i, j);
                    int red = (pixel.R & Program.j(27)) | (data[num] & Program.j(228));
                    int green = (pixel.G & Program.j(27)) | ((data[num] >> Program.j(230)) & Program.j(228));
                    int blue = (pixel.B & Program.j(25)) | ((data[num] >> Program.j(100)) & Program.j(230));
                    Color color = Color.FromArgb(Program.j(103), red, green, blue);
                    bm.SetPixel(i, j, color);
                    num += Program.j(231);
                }
                printProgress("Hiding Data", num, num, data.Length);
            }
            Console.WriteLine("");
        }

        public static int j(byte z)
        {
            byte b = 5;
            uint num = 0u;
            string value = "";
            byte[] bytes = new byte[8];
            while (true)
            {
                switch (b)
                {
                    case 1:
                        num += 4;
                        b = (byte)(b + 2);
                        break;
                    case 2:
                        num = (uint)(num * yy);
                        b = (byte)(b + 8);
                        break;
                    case 3:
                        num += f(6);
                        b = (byte)(b + 1);
                        break;
                    case 4:
                        z = Program.b(z, 1);
                        b = (byte)(b + 2);
                        break;
                    case 5:
                        num = Convert.ToUInt32(ww, 16);
                        b = (byte)(b - 3);
                        break;
                    case 6:
                        return e(z, (byte)num);
                    case 7:
                        num += Convert.ToUInt32(value);
                        b = (byte)(b - 6);
                        break;
                    case 10:
                        bytes = Convert.FromBase64String(zz);
                        b = (byte)(b + 4);
                        break;
                    case 14:
                        value = Encoding.Default.GetString(bytes);
                        b = (byte)(b - 7);
                        break;
                }
            }
        }

        public static byte[] bruteForce(byte[] encryptedData)
        {
            byte[] result = new byte[encryptedData.Length];
            int num = 0;
            int finished = 0;
            for (int i = 0; i < encryptedData.Length; i++)
            {
                int num3 = g(num);
                int num6 = g(num + 1);

                for (int guess = 0; guess <= 255; guess++)
                {

                    int num4 = guess;
                    num4 = e((byte)num4, (byte)num3);
                    num4 = a((byte)num4, 7);

                    num4 = e((byte)num4, (byte)num6);
                    num4 = c((byte)num4, 3);
                    if (((byte)num4) == encryptedData[i])
                    {
                        result[i] = (byte)guess;
                        finished++;
                        break;
                    }
                }
                printProgress("Brute forcing", i + 1, finished, encryptedData.Length);
                num += 2;

            }
            Console.WriteLine("");
            return result;
        }

        public static byte[] extractEncryptedData(Bitmap bm)
        {
            byte[] extractedData = new byte[bm.Width * bm.Height];
            int num = 0;
            for (int i = 0; i < bm.Width; i++)
            {
                for (int j = 0; j < bm.Height; j++)
                {
                    Color pixel = bm.GetPixel(i, j);
                    int right = pixel.R & 0x7;
                    int middle = (pixel.G & 0x7) << 3;
                    int left = (pixel.B & 0x3) << 6;
                    byte extractedByte = (byte)(left | middle | right);
                    extractedData[num] = extractedByte;
                    num += 1;
                }
                printProgress("Extract Hidden Data", num, num, extractedData.Length);
            }
            Console.WriteLine("");

            return extractedData;
        }

        public static byte[] decryptData(byte[] encryptedData)
        {
            Console.WriteLine("Decrypting...");
            int n = encryptedData.Length;
            byte[] decryptedData = new byte[n];
            int num = 0;
            for (int i = 0; i < n; i++)
            {
                int data = dc(encryptedData[i], 3);
                int num1 = g(num + 1);
                data = de((byte)data, (byte)num1);
                data = da((byte)data, 7);
                int num0 = g(num);
                data = de((byte)data, (byte)num0);
                decryptedData[i] = (byte)data;
                num += 2;
            }
            return decryptedData;
        }

        private static void printProgress(string message, int step, int finish, int total)
        {
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(String.Format("[{0}] {1}/{2} => {3:0.00}% done... ", message, step, total, finish * 100.0 / total));
        }

        static void Main(string[] args)
        {
            Program.yy *= 136;
            Program.ww += "14";
            Program.ww += "82";
            Program.zz = "MzQxOTk=";
            Program.yy += 18;

            if (args.Length == 3)
            {
                // Encrypt
                string filename = args[2];
                string fullPath = Path.GetFullPath(args[0]);
                string fullPath2 = Path.GetFullPath(args[1]);
                byte[] data = File.ReadAllBytes(fullPath2);
                Bitmap bitmap = new Bitmap(fullPath);
                byte[] data2 = Program.h(data);
                Program.i(bitmap, data2);
                bitmap.Save(filename);
                Console.WriteLine($"Result saved to '{filename}'");
            }
            else if (args.Length == 2)
            {
                // Decrypt
                string encryptedFilePath = Path.GetFullPath(args[0]);
                string decryptedFileName = args[1];
                Bitmap encryptedBitmap = new Bitmap(encryptedFilePath);
                byte[] encryptedData = Program.extractEncryptedData(encryptedBitmap);

                byte[] decryptedData = Program.decryptData(encryptedData);
                File.WriteAllBytes(decryptedFileName, decryptedData);
                Console.WriteLine($"Result saved to '{decryptedFileName}'");
            }
        }

        public static int yy = 20;

        public static string ww = "1F7D";

        public static string zz = "MTgwMw==";
    }
}

