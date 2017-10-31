﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace Memory
{
    public partial class Manager : Form
    {
        public static Manager ManagerInstance;

        public Manager()
        {
            ManagerInstance = this;

            WindowState = FormWindowState.Minimized;
            ShowInTaskbar = false;
            Visible = false;

            InitializeComponent();

            var HomePage = new HomePage();
            HomePage.Show();

            axWindowsMediaPlayer1.URL = "chiper.wav";
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }
    }
}
