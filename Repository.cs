using System;

namespace Desliga_PC_2021
{
    class Repository
    {
        private string version = "1.0.0.0";

        private int timeCalculate = 0;
        private bool clockActive = false;

        public void TimeRunning()
        {
            if (clockActive)
            {
                timeCalculate -= 1;
                UpdateTimeDisplay();

                if(timeCalculate <= 0)
                {
                    clockActive = false;
                    ShotdownNow();
                }
            }
        }

        public string UpdateTimeDisplay()
        {
            return String.Format("{0:#,0#}:{1:#,0#}'{2:#,0#}", (timeCalculate / 3600), ((timeCalculate % 3600) / 60), ((timeCalculate % 3600) % 60));
        }

        public void TimeTotal(int total)
        {
            timeCalculate = total;
        }

        public void ControlClock(bool action)
        {
            clockActive = action;
            if (clockActive)
            {
                if (timeCalculate == 0)
                {
                    timeCalculate = 20;
                }
            }
        }

        public bool GetClickActive()
        {
            return clockActive;
        } 

        public string GetDevVersion()
        {
            return version;
        }

        public void ShotdownNow()
        {
            WinPower.Execute(WinPower.PowerOption.PowerOff);
        }
    }
}
