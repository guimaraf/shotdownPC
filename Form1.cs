using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desliga_PC_2021
{
    public partial class Form1 : Form
    {
        Repository repository = default;

        //creating an instance of repository
        //updating time, collecting bar value
        public Form1()
        {
            InitializeComponent();
            repository = new Repository();
            UpdateTrackBar();
            txtVersion.Text = "Version: " + repository.GetDevVersion();
        }

        //initialize the clock
        private void ClockStart()
        {
            timer1.Interval = 1000;
            timer1.Start();
        }

        //updating the clock
        //showing on screen the time being updated
        private void timer1_Tick(object sender, EventArgs e)
        {
            repository.TimeRunning();
            txtTime.Text = repository.UpdateTimeDisplay();
        }

        //start countdown to shutdown pc
        private void btnShutdown_Click(object sender, EventArgs e)
        {
            if (!repository.GetClickActive())
            {
                UpdateTrackBar();
                repository.ControlClock(true);
                ClockStart();
                btnShutdown.Text = "Cancelar";
                trackBar1.Enabled = false;
            }
            else
            {
                repository.ControlClock(false);
                btnShutdown.Text = "Desligar o PC";
                trackBar1.Enabled = true;
                UpdateTrackBar();
            }
        }

        //updating the clock based on the bar
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            UpdateTrackBar();
        }

        //updating count text
        private void UpdateTrackBar()
        {
            repository.TimeTotal(trackBar1.Value * 600);
            txtTime.Text = repository.UpdateTimeDisplay();
        }
    }
}
