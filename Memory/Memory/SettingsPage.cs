﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;


//In deze pagina is het mogelijk het volume en thema's aan te passen.
namespace Memory
{
	public partial class SettingsPage : Form
	{
        // Commands voor het aanpassen van systeemgeluid
        private const int APPCOMMAND_VOLUME_MUTE = 0x80000;
        private const int APPCOMMAND_VOLUME_UP = 0xA0000;
		private const int APPCOMMAND_VOLUME_DOWN = 0x90000;
		private const int APPCOMMAND_MEDIA_PLAY_PAUSE = 0x14000;
		private const int WM_APPCOMMAND = 0x319;

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessageW(IntPtr hWnd, int Msg,
            IntPtr wParam, IntPtr lParam);

        public static string SetValueForComboBox = "";
		System.Media.SoundPlayer player = new System.Media.SoundPlayer();
		public SettingsPage()
		{
			InitializeComponent();

            this.ShowInTaskbar = true;

            ChangeCursor();
			ThemaBox.SelectedIndex = 0;
		}
        
        // Veranderen van de Mousecursor
        void ChangeCursor()
        {
            Bitmap bmp = new Bitmap(Properties.Resources.cur1031);
            Cursor c = new Cursor(bmp.GetHicon());
            this.Cursor = c;
        }

        // Toepassen van het gekozen thema uit de combobox
		public async void Apply_Click(object sender, EventArgs e)
		{
			player.SoundLocation = "click.wav";
			player.Play();
			string thema = ThemaBox.SelectedItem.ToString();
			Memory.SettingsPage_Save.SaveData(thema);
            MessageBox.Show("Thema is succesvol toegepast");
            await Task.Delay(300);
            player.Stop();
		}

		// Magische code die de flikkering in de form fixt
		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams cp = base.CreateParams;
				cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
				return cp;
			}
		}

        // Event die de HomePage herstart bij het afluiten van de Settingspage
		private void SettingsPage_FormClosed(object sender, FormClosedEventArgs e)
		{
            Memory.HomePage f2 = new Memory.HomePage();
            f2.Show();
            GC.Collect();
        }

        // Volume verlagen
		private void VolumeDown_Click(object sender, EventArgs e)
		{
            SendMessageW(this.Handle, WM_APPCOMMAND, this.Handle,
                (IntPtr)APPCOMMAND_VOLUME_DOWN);

        }

        // Volume verhogen
        private void VolumeUp_Click(object sender, EventArgs e)
		{
            SendMessageW(this.Handle, WM_APPCOMMAND, this.Handle,
                (IntPtr)APPCOMMAND_VOLUME_UP);
        }

        // Het terugkeren naar het Hoofdmenu
        private async void Home_Click(object sender, EventArgs e)
        {
            player.SoundLocation = "click.wav";
            player.Play();
            await Task.Delay(300);
            player.Stop();
            this.Close();
            this.Dispose();
        }

        // Volume dempen
        private void MuteButton_Click(object sender, EventArgs e)
        {
            SendMessageW(this.Handle, WM_APPCOMMAND, this.Handle,
                (IntPtr)APPCOMMAND_VOLUME_MUTE);
        }
	}
}
