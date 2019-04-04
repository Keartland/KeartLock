
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Keartlock
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            highPriority();
        }

        private System.Windows.Forms.Timer timer1;
        public void highPriority()
        {
            timer1 = new System.Windows.Forms.Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 2000; // in miliseconds
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int height = SystemInformation.PrimaryMonitorSize.Height;
            int width = SystemInformation.PrimaryMonitorSize.Width;
            Cursor.Clip = new Rectangle(new Point(0, 0), new Size(width, height));
            foreach (System.Diagnostics.Process p in System.Diagnostics.Process.GetProcesses().Where(x => x.ProcessName == "Discord"))
            {
                p.PriorityClass = System.Diagnostics.ProcessPriorityClass.High;
            }
            foreach (System.Diagnostics.Process p in System.Diagnostics.Process.GetProcesses().Where(x => x.ProcessName == "csgo"))
            {
                p.PriorityClass = System.Diagnostics.ProcessPriorityClass.High;
            }
        }
    }
}
