using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace HoneyPotScreenSaver
{
	public partial class ScreenBackdropForm : Form
	{
		private System.Timers.Timer timer;
		private SoundPlayer player;
		private int loopCount = 0;
		private int maxLoopCount = 10;
		private bool _messageShown = false;

		#region | Cosntructors |
		/// <summary>
		/// Initializes a new instance of the <see cref="ScreenBackdropForm"/> class.
		/// </summary>
		public ScreenBackdropForm()
		{
			InitializeComponent();
			this.Setup();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ScreenBackdropForm"/> class.
		/// </summary>
		/// <param name="bounds">The bounds.</param>
		public ScreenBackdropForm(Rectangle bounds)
			: this()
		{
			this.Bounds = bounds;
		}
		#endregion

		#region | Private Methods |

		/// <summary>
		/// Sets up this instance of the form.
		/// </summary>
		private void Setup()
		{
			this.Opacity = .02;
			timer = new System.Timers.Timer();
			timer.Interval = 750;
			timer.Elapsed += timer_Elapsed;
			this.timer.Enabled = false;
			this.maxLoopCount = ScreenSaverConfig.MaxWaveLoopCount;
			this.Load += MyForm_Load;
		}

		/// <summary>
		/// Handles the Elapsed event of the timer control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.Timers.ElapsedEventArgs"/> instance containing the event data.</param>
		private void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			this.Invoke((MethodInvoker)delegate
			{
				if (loopCount >= this.maxLoopCount)
				{
					this.player.Stop();
				}

				loopCount++;
				this.lblWarning.Visible = !this.lblWarning.Visible;
			});
		}

		/// <summary>
		/// Handles the Load event of the MyForm control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void MyForm_Load(object sender, EventArgs e)
		{
			this.TopMost = true;
		}

		#endregion


		#region | public Methods |

		/// <summary>
		/// Updates the opacity of the form and makes sure that the label is centered. 
		/// </summary>
		public ScreenBackdropForm EnableWarning()
		{
			if (_messageShown == false)
			{
				var x = (this.Bounds.Width - this.lblWarning.Width) / 2;
				var y = this.Bounds.Height / 2;
				this.lblWarning.Left = x;
				this.lblWarning.Top = y;
				this.Opacity = 100;
				Cursor.Hide();
				this.timer.Enabled = true;
				this._messageShown = true;
			}

			return this;
		}

		/// <summary>
		/// Stops the timer.
		/// </summary>
		public void StopTimer()
		{
			this.timer.Stop();
		}

		/// <summary>
		/// Sets the player so that it can be stopped when loop count is reached.
		/// </summary>
		/// <param name="player">The player.</param>
		public void SetPlayer(SoundPlayer player)
		{
			this.player = player;
		}

		#endregion

	}
}
