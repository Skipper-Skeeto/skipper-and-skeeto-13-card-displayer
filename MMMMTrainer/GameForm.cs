using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MMMMTrainer
{
    public partial class GameForm : Form
    {
        IntPtr windowId;

        string currentRoom;
        public GameForm(IntPtr windowId)
        {
            this.windowId = windowId;
            InitializeComponent();
        }

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        [DllImport("user32.dll")]
        private static extern int GetWindowRect(IntPtr hwnd, out Rectangle rect);

        const uint SWP_NOSIZE = 0x0001;
        const uint SWP_NOZORDER = 0x0004;

        private ColorRoomPair[] pairs = new ColorRoomPair[] {
            new ColorRoomPair(Color.FromArgb(166,147,73),"StartRoom"),
            new ColorRoomPair(Color.FromArgb(190,169,110),"100Room"),
            new ColorRoomPair(Color.FromArgb(197,153,96),"TreasureRoom"),
            new ColorRoomPair(Color.FromArgb(211,169,113),"RopeRoom"),
            new ColorRoomPair(Color.FromArgb(45,103,64),"Library"),
            new ColorRoomPair(Color.FromArgb(195,137,37),"ChessRoom"),
            new ColorRoomPair(Color.FromArgb(211,169,113),"RopeRoom"),
            new ColorRoomPair(Color.FromArgb(54,130,87),"BedRoom"),
            new ColorRoomPair(Color.FromArgb(196,194,189),"Workshop"),
            new ColorRoomPair(Color.FromArgb(80,116,152),"LivingRoom"),
            new ColorRoomPair(Color.FromArgb(129,89,46),"Closet"),
            new ColorRoomPair(Color.FromArgb(150,132,72),"Kitchen"),
            new ColorRoomPair(Color.FromArgb(127,117,82),"BasementStairs"),
            new ColorRoomPair(Color.FromArgb(179,155,72),"WaterBarrel"),
            new ColorRoomPair(Color.FromArgb(178,154,72),"CoalRoom"),
            new ColorRoomPair(Color.FromArgb(66,68,65),"SpiderRoom"),
            new ColorRoomPair(Color.FromArgb(173,164,108),"Pantry"),
            new ColorRoomPair(Color.FromArgb(67,69,103),"Pool"),
            new ColorRoomPair(Color.FromArgb(63,69,119),"Garden"),
            new ColorRoomPair(Color.FromArgb(38,75,135),"Well"),
            new ColorRoomPair(Color.FromArgb(79,86,139),"Tree"),
            new ColorRoomPair(Color.FromArgb(48,61,105),"DarkHole"),
            new ColorRoomPair(Color.FromArgb(153,139,94),"GoldRoom")
        };

        private void GameForm_Load(object sender, EventArgs e)
        {
            MoveGameForm();
            BackColor = Color.Magenta;
            TransparencyKey = Color.Magenta;
            sstest.Image = new Bitmap(Width, Height);
        }

        private void formTimer_Tick(object sender, EventArgs e)
        {
            MoveGameForm();
            Screenshot();
        }

        private void MoveGameForm()
        {
            IntPtr hWnd = windowId;

            if (hWnd != IntPtr.Zero)
            {
                GetWindowRect(hWnd, out Rectangle rect);

                SetWindowPos(this.Handle, new IntPtr(-1), rect.X, rect.Y+25, rect.Width - rect.X, rect.Height - rect.Y-25, 0x0040);
            }
            byte[] arr = new byte[4];

        }

        private void screenShot_Click(object sender, EventArgs e)
        {
            Screenshot(true);
        }

        private void Screenshot(bool debug = false)
        {
            Image newImage = new Bitmap(Width, Height);

            using (var graphics = Graphics.FromImage(newImage))
            {
                graphics.CopyFromScreen(Bounds.X, Bounds.Y, 0, 0, new Size(Width, Height));
            }

            foreach (var v in pairs)
            {
                if (v.color == ((Bitmap)newImage).GetPixel(100, 250))
                {
                    roomName.Text = v.roomName;

                    if(currentRoom != roomName.Text)
                    {
                        currentRoom = roomName.Text;
                        if (File.Exists("pics/" + v.roomName + ".png"))
                        {
                            sstest.Image.Dispose();
                            Bitmap newPic = (Bitmap)Image.FromFile("pics/" + v.roomName + ".png");
                            newPic.SetResolution(sstest.Width, sstest.Height);
                            sstest.Image = newPic;
                            sstest.Refresh();
                            GC.Collect();
                            sstest.Visible = true;
                            return;
                        }
                    }
                    break;
                }
                else
                {
                    roomName.Text = "Not Found";
                }
            }

            if(debug)
            {
                Console.WriteLine(((Bitmap)newImage).GetPixel(100, 250));
            }

            newImage.Dispose();
        }

        private void sstest_Click(object sender, EventArgs e)
        {

        }
    }

    public struct ColorRoomPair
    {
        public Color color;
        public string roomName;

        public ColorRoomPair(Color color, string roomName)
        {
            this.color = color;
            this.roomName = roomName;
        }
    }
}
