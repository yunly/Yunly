using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yunly.WinForm
{
    public partial class Form1 : Form
    {
        System.Timers.Timer timer = new System.Timers.Timer(1000);


        public Form1()
        {
            InitializeComponent();

            timer.Elapsed += Timer_Elapsed;

            this.label1.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            this.button1.Text = "Start";
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            //   this.label1.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            this.label1.Invoke(new Action(() => label1.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer.Enabled = !timer.Enabled;

            this.button1.Text = timer.Enabled ? "Stop" : "Start";
        }
    }
}
