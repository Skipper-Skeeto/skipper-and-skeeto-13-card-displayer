using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace MMMMTrainer
{
    public partial class MainForm : Form
    {

        // P/Invoke declarations.

        


        public MainForm()
        {
            InitializeComponent();
            StartGameForm();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            StartGameForm();
        }

        void StartGameForm()
        {
            Process[] processes = Process.GetProcesses();
            foreach (var v in processes)
            {
                if (v.ProcessName == "mm13main")
                {
                    Form form = new GameForm(v.MainWindowHandle);
                    form.Show();
                    Hide();
                }
            }
        }
    }
}
