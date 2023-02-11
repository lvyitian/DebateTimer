/*
 * 由SharpDevelop创建。
 * 用户： 53548
 * 日期: 2023/2/11
 * 时间: 12:42
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
namespace DebateTimer
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Timer timer2;
		private System.Windows.Forms.Label label7;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.button1 = new System.Windows.Forms.Button();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.timer2 = new System.Windows.Forms.Timer(this.components);
			this.label7 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(12, 272);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(126, 57);
			this.button1.TabIndex = 0;
			this.button1.Text = "开始";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// timer1
			// 
			this.timer1.Interval = 1;
			this.timer1.Tick += new System.EventHandler(this.Timer1Tick);
			// 
			// button2
			// 
			this.button2.Enabled = false;
			this.button2.Location = new System.Drawing.Point(281, 272);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(126, 57);
			this.button2.TabIndex = 1;
			this.button2.Text = "暂停";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.Button2Click);
			// 
			// button3
			// 
			this.button3.Enabled = false;
			this.button3.Location = new System.Drawing.Point(571, 272);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(126, 57);
			this.button3.TabIndex = 2;
			this.button3.Text = "切换";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.Button3Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 95);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(269, 77);
			this.label1.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(428, 95);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(269, 77);
			this.label2.TabIndex = 4;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(186, 7);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(221, 28);
			this.textBox1.TabIndex = 5;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(12, 12);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(168, 31);
			this.label3.TabIndex = 6;
			this.label3.Text = "初始时间(单位:s):";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(428, 7);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(268, 27);
			this.label4.TabIndex = 7;
			this.label4.Text = "点击开始时从左边开始计时!";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(12, 46);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(125, 32);
			this.label5.TabIndex = 8;
			this.label5.Text = "左方:";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(428, 46);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(125, 32);
			this.label6.TabIndex = 9;
			this.label6.Text = "右方:";
			// 
			// timer2
			// 
			this.timer2.Interval = 1;
			this.timer2.Tick += new System.EventHandler(this.Timer2Tick);
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(12, 210);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(684, 50);
			this.label7.TabIndex = 10;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(709, 341);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Name = "MainForm";
			this.Text = "DebateTimer";
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.MainFormControlAdded);
			this.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.MainFormControlRemoved);
			this.Resize += new System.EventHandler(this.MainFormResize);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
