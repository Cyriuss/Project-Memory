﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Memory
{
    public partial class HighscorePage : Form
    {
		System.Media.SoundPlayer player = new System.Media.SoundPlayer();
		public HighscorePage()
        {
            InitializeComponent();
            string save = Highscores_save.LoadData();
            if (save == "Er is nog geen\nsave file\naanwezig")
            { }
            else
            {
                //save string wordt gesplit op \n en in string array gezet
                string[] savearray = save.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);

                //toekennen van waarden uit array aan variabelen
                try
                {
                    if (savearray[0] != null)
                    {
                        label1.Text = savearray[0];
                    }
                }
                catch (Exception) { }
                try
                {
                    if (savearray[1] != null)
                    {
                        label2.Text = savearray[1];
                    }
                }
                catch (Exception) { }
                try
                {
                    if (savearray[2] != null)
                    {
                        label3.Text = savearray[2];
                    }
                }
                catch (Exception) { }
                try
                {
                    if (savearray[3] != null)
                    {
                        label4.Text = savearray[3];
                    }
                }
                catch (Exception) { }
                try
                {
                    if (savearray[4] != null)
                    {
                        label5.Text = savearray[4];
                    }
                }
                catch (Exception) { }
                try
                {
                    if (savearray[5] != null)
                    {
                        label6.Text = savearray[5];
                    }
                }
                catch (Exception) { }
                try
                {
                    if (savearray[6] != null)
                    {
                        label7.Text = savearray[6];
                    }
                }
                catch (Exception) { }
                try
                {
                    if (savearray[7] != null)
                    {
                        label8.Text = savearray[7];
                    }
                }
                catch (Exception) { }
                try
                {
                    if (savearray[8] != null)
                    {
                        label9.Text = savearray[8];
                    }
                }
                catch (Exception) { }
                try
                {
                    if (savearray[9] != null)
                    {
                        label10.Text = savearray[9];
                    }
                }
                catch (Exception) { }

            }
        }

        private void HighscorePage_Load(object sender, EventArgs e)
        {

        }
		private async void HomeButton_Click(object sender, EventArgs e)
		{
			player.SoundLocation = "click.wav";
			player.Play();
			Memory.Form2 f2 = new Memory.Form2();
			f2.Show();
			await Task.Delay(100);
			this.Close();
			this.ShowInTaskbar = false;
		}
	}
}
