using System;
using System.Collections.Generic;
using System.Media;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace HoneyPotScreenSaver
{
	class Program
	{
		[DllImport("user32")]
		public static extern void LockWorkStation();

		static SoundPlayer soundPlayer;
		static List<ScreenBackdropForm> forms;

		static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			Program.SetupDisplayForms();

			Application.Run();
		}

		/// <summary>
		/// Sets up each of the forms for the clients monitors.
		/// </summary>
		static void SetupDisplayForms()
		{
			forms = new List<ScreenBackdropForm>();
			foreach (Screen screen in Screen.AllScreens)
			{	var myForm = new ScreenBackdropForm(screen.Bounds);
				SetupForm(myForm, forms);
				forms.Add(myForm);
			}
		}

		/// <summary>
		/// Setups the form - binding the correct keys.
		/// </summary>
		/// <param name="myForm">My form.</param>
		/// <param name="forms">The forms.</param>
		static void SetupForm(ScreenBackdropForm myForm, List<ScreenBackdropForm> forms)
		{
			myForm.KeyPress += (sender, e) =>
			{
				if (e.KeyChar == (char)Keys.Escape)
				{
					LockWorkStation();
					
					CloseForms();

					Application.Exit();
				}
				else
				{
					forms.ForEach(frm => ShowForm(frm));
				}				
			};

			myForm.MouseDown += (sender, e) =>
			{
				forms.ForEach(frm => ShowForm(frm));
			};

			myForm.Show();
		}

		/// <summary>
		/// Shows the form.
		/// </summary>
		/// <param name="frm">The FRM.</param>
		static void ShowForm(ScreenBackdropForm frm)
		{
			frm.EnableWarning();
			PlaySound(frm);
		}

		/// <summary>
		/// Starts playing the specified wave file specified in the the configuration file.
		/// </summary>
		/// <param name="frm">The FRM.</param>
		static void PlaySound(ScreenBackdropForm frm)
		{
			if (soundPlayer == null)
			{
				try
				{
					soundPlayer = new SoundPlayer(ScreenSaverConfig.SoundFile);
					soundPlayer.PlayLooping();

				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message.ToString());
					Application.Exit();
				}

			}

			frm.SetPlayer(soundPlayer);
		}

		/// <summary>
		/// Closes the all the open forms - based on the number of displays the client has avaiable.
		/// </summary>
		static void CloseForms()
		{
			if (Program.soundPlayer != null)
			{
				Program.soundPlayer.Dispose();
			}

			Program.forms.ForEach(frm =>
			{
				frm.StopTimer();
				frm.Close();
			});
		}

	}
}
