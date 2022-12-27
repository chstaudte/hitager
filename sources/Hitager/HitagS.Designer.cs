namespace Hitager
{
	partial class HitagS
	{
		/// <summary> 
		/// Erforderliche Designervariable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Verwendete Ressourcen bereinigen.
		/// </summary>
		/// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Vom Komponenten-Designer generierter Code

		/// <summary> 
		/// Erforderliche Methode für die Designerunterstützung. 
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent()
		{
			this.hexBox = new Be.Windows.Forms.HexBox();
			this.buttonRead = new System.Windows.Forms.Button();
			this.buttonWrite = new System.Windows.Forms.Button();
			this.textBoxKey = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.textBoxUID = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textBoxCON = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// hexBox
			// 
			this.hexBox.ColumnInfoVisible = true;
			this.hexBox.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.hexBox.GroupSeparatorVisible = true;
			this.hexBox.LineInfoVisible = true;
			this.hexBox.Location = new System.Drawing.Point(3, 3);
			this.hexBox.Name = "hexBox";
			this.hexBox.ShadowSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(60)))), ((int)(((byte)(188)))), ((int)(((byte)(255)))));
			this.hexBox.Size = new System.Drawing.Size(480, 377);
			this.hexBox.TabIndex = 0;
			this.hexBox.UseFixedBytesPerLine = true;
			// 
			// buttonRead
			// 
			this.buttonRead.Location = new System.Drawing.Point(492, 45);
			this.buttonRead.Name = "buttonRead";
			this.buttonRead.Size = new System.Drawing.Size(100, 23);
			this.buttonRead.TabIndex = 1;
			this.buttonRead.Text = "Read Tag";
			this.buttonRead.UseVisualStyleBackColor = true;
			this.buttonRead.Click += new System.EventHandler(this.buttonRead_Click);
			// 
			// buttonWrite
			// 
			this.buttonWrite.Enabled = false;
			this.buttonWrite.Location = new System.Drawing.Point(492, 74);
			this.buttonWrite.Name = "buttonWrite";
			this.buttonWrite.Size = new System.Drawing.Size(100, 23);
			this.buttonWrite.TabIndex = 2;
			this.buttonWrite.Text = "Write Tag";
			this.buttonWrite.UseVisualStyleBackColor = true;
			this.buttonWrite.Click += new System.EventHandler(this.buttonWrite_Click);
			// 
			// textBoxKey
			// 
			this.textBoxKey.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.textBoxKey.Enabled = false;
			this.textBoxKey.Location = new System.Drawing.Point(492, 19);
			this.textBoxKey.MaxLength = 12;
			this.textBoxKey.Name = "textBoxKey";
			this.textBoxKey.Size = new System.Drawing.Size(100, 20);
			this.textBoxKey.TabIndex = 3;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(489, 3);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(98, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "Authentication key:";
			// 
			// textBoxUID
			// 
			this.textBoxUID.Location = new System.Drawing.Point(492, 116);
			this.textBoxUID.Name = "textBoxUID";
			this.textBoxUID.ReadOnly = true;
			this.textBoxUID.Size = new System.Drawing.Size(100, 20);
			this.textBoxUID.TabIndex = 5;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(489, 100);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(29, 13);
			this.label2.TabIndex = 6;
			this.label2.Text = "UID:";
			// 
			// textBoxCON
			// 
			this.textBoxCON.Location = new System.Drawing.Point(492, 155);
			this.textBoxCON.Name = "textBoxCON";
			this.textBoxCON.ReadOnly = true;
			this.textBoxCON.Size = new System.Drawing.Size(100, 20);
			this.textBoxCON.TabIndex = 7;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(489, 139);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(32, 13);
			this.label3.TabIndex = 8;
			this.label3.Text = "Conf:";
			// 
			// HitagS
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.label3);
			this.Controls.Add(this.textBoxCON);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.textBoxUID);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBoxKey);
			this.Controls.Add(this.buttonWrite);
			this.Controls.Add(this.buttonRead);
			this.Controls.Add(this.hexBox);
			this.Name = "HitagS";
			this.Size = new System.Drawing.Size(688, 383);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Be.Windows.Forms.HexBox hexBox;
		private System.Windows.Forms.Button buttonRead;
		private System.Windows.Forms.Button buttonWrite;
		private System.Windows.Forms.TextBox textBoxKey;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBoxUID;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBoxCON;
		private System.Windows.Forms.Label label3;
	}
}
