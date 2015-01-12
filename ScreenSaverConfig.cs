using System.Configuration;
using System.IO;

namespace HoneyPotScreenSaver
{
	public struct ScreenSaverConfig
	{
		private const int DefaultWaveLoopCount = 10;
		private const string DefaultWaveFile = @".\waves\Siren.wav";

		/// <summary>
		/// Gets the maximum wave loop count.
		/// </summary>
		/// <value>
		/// The maximum wave loop count.
		/// </value>
		public static int MaxWaveLoopCount
		{
			get
			{
				var max = 10;
				if(int.TryParse(ConfigurationManager.AppSettings["LoopCount"], out max))
				{
					return max;
				}

				return ScreenSaverConfig.DefaultWaveLoopCount;
			}
		}

		/// <summary>
		/// Gets the sound file.
		/// </summary>
		/// <value>
		/// The sound file.
		/// </value>
		public static string SoundFile
		{
			get
			{
				var file = ConfigurationManager.AppSettings["SoundFile"];
				return File.Exists(file) ? file : ScreenSaverConfig.DefaultWaveFile;
			}
		}

	}
}
