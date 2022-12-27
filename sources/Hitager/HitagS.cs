using Be.Windows.Forms;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace Hitager
{
	public partial class HitagS : UserControl
	{
		private const byte CRC_PRESET = 0xFF;

		#region application event handling

		public HitagS()
		{
			InitializeComponent();
		}

		public event EventHandler debugUpdated;
		private void DebugUpdateRaiseEvent(string debug)
		{
			DebugmessageEventArgs e = new DebugmessageEventArgs();
			e.Message = debug;

			if (debugUpdated != null)
				debugUpdated(this, e);
		}

		private void handleDebug(string text)
		{
			DebugUpdateRaiseEvent(text + Environment.NewLine);
		}

		private PortHandler portHandler;
		public void SetPortHandler(ref PortHandler handler)
		{
			portHandler = handler;
		}

		#endregion

		private void buttonRead_Click(object sender, EventArgs e)
		{
			buttonRead.Enabled = false;

			try
			{
				portWriteWrapper("g00");  // Gain: Set to 0
				portWriteWrapper("o");    // RF: Enable

				textBoxUID.Text = sendCmd_UIDRequest();
				textBoxCON.Text = sendCmd_SelectUID(textBoxUID.Text);

				string pages = "";
				for (int i = 0; i < 64; i++)
				{
					pages += sendCmd_ReadPage(i);
				}
				hexBox.ByteProvider = new DynamicByteProvider(Hitag2.ConvertHexStringToByteArray(pages));

				handleDebug("DONE");
			}
			catch (Exception ex)
			{
				portWriteWrapper("f"); // RF: Disable
				handleDebug(ex.Message);
			}

			buttonRead.Enabled = true;
		}

		private void buttonWrite_Click(object sender, EventArgs e)
		{
		}

		/// <summary>
		/// Send the UID REQUEST command, format advanced
		/// </summary>
		/// <returns>Bytes (UID0, UID1, UID2, UID3) as hex string</returns>
		/// <exception cref="Exception"></exception>
		private string sendCmd_UIDRequest()
		{
			const byte CMD_BYTE = 0x18; // UID REQUEST Adv
			const byte CMD_LENGTH = 5;
			const byte RET_LENGTH = 3;

			// This command needs to be sent in Anticollision Coding, switch to that mode
			portWriteWrapper("b02");

			string uid = portWriteWrapper(
				"i" + 
				CMD_LENGTH.ToString("X2") + 
				(CMD_BYTE << (8 - CMD_LENGTH)).ToString("X2"));

			// Expected return length is 5 bytes
			if (uid.Length != 10)
			{
				throw new Exception("ERROR IN ID LENGTH");
			}

			long uidBits = long.Parse(uid, NumberStyles.HexNumber);
			uidBits = (uidBits >> (8 - RET_LENGTH)) & 0xffffffff;
			return uidBits.ToString("X8");
		}

		/// <summary>
		/// Send the SELECT UID command
		/// </summary>
		/// <param name="uid">UID bytes 0,1,2,3 as hex string</param>
		/// <returns>Bytes (CON0, CON1, CON2, Reserved) as hex string</returns>
		private string sendCmd_SelectUID(string uid)
		{
			const byte CMD_BYTE = 0x00;
			const byte CMD_LENGTH = 5;
			const byte RET_LENGTH = 1;

			// Before sending any SELECT command, we must switch to Manchester Encoding mode
			portWriteWrapper("b00");

			// Calculate the CRC to send
			byte[] uidBytes = Hitag2.ConvertHexStringToByteArray(uid);
			byte crc = CRC_PRESET;
			calc_crc(ref crc, (CMD_BYTE << (8 - CMD_LENGTH)), CMD_LENGTH);
			for (int i = 0; i < 4; i++)
				calc_crc(ref crc, uidBytes[i], 8);

			long uidBits = long.Parse(uid, NumberStyles.HexNumber);
			string tagConfig = portWriteWrapper(
				"i" + 
				(40 + CMD_LENGTH).ToString("X2") + 
				(((long)CMD_BYTE << 40 | uidBits << 8 | crc) << (8 - CMD_LENGTH)).ToString("X12"));

			// Decode the config bits
			long configBits = long.Parse(tagConfig, NumberStyles.HexNumber);
			configBits = (configBits >> (8 + (8 - RET_LENGTH))) & 0xffffffff;
			return configBits.ToString("X8");
		}

		/// <summary>
		/// Send the READ PAGE command
		/// </summary>
		/// <param name="pageAddress">The page address from 0 to 63</param>
		/// <returns>Bytes (Data0, Data1, Data2, Data3) as hex string</returns>
		private string sendCmd_ReadPage(int pageAddress)
		{
			const byte CMD_BYTE = 0x0C;
			const byte CMD_LENGTH = 4;
			const byte RET_LENGTH = 1;

			// Calculate the CRC to send
			byte crc = CRC_PRESET;
			calc_crc(ref crc, (CMD_BYTE << (8 - CMD_LENGTH)), CMD_LENGTH);
			calc_crc(ref crc, Convert.ToByte(pageAddress), 8);

			string page = portWriteWrapper(
				"i" + 
				(16 + CMD_LENGTH).ToString("X2") + 
				(((long)CMD_BYTE << 16 | pageAddress << 8 | crc) << (8 - CMD_LENGTH)).ToString("X6"));

			// Decode the data bits
			long pageBits = long.Parse(page, NumberStyles.HexNumber);
			pageBits = (pageBits >> (8 + (8 - RET_LENGTH))) & 0xffffffff;
			return pageBits.ToString("X8");
		}

		/// <summary>
		/// This is a wrapper around the normal portWR function, 
		/// but it throws an exception if an error or timeout occurs.
		/// </summary>
		/// <param name="cmd"></param>
		/// <returns></returns>
		/// <exception cref="Exception"></exception>
		private string portWriteWrapper(string cmd)
		{
			string res = portHandler.portWR(cmd);

			if (res.Equals("TIMEOUT") || res.Equals("ERROR"))
			{
				throw new Exception(res);
			}

			return res;
		}

		/// <summary>
		/// CRC step function as defined in the HITAG S specification
		/// </summary>
		/// <param name="crc">Reference to the CRC byte</param>
		/// <param name="data">The data byte to incorporate into the CRC</param>
		/// <param name="bitcount">The number of bits of the data byte to take into account</param>
		private void calc_crc(ref byte crc, byte data, int bitcount)
		{
			crc ^= data;
			do
			{
				if ((crc & 0x80) != 0)
				{
					crc <<= 1;
					crc ^= 0x1D;
				}
				else
				{
					crc <<= 1;
				}
			}
			while (--bitcount > 0);
		}
	}
}
