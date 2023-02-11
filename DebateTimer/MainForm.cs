/*
 * 由SharpDevelop创建。
 * 用户： 53548
 * 日期: 2023/2/11
 * 时间: 12:42
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace DebateTimer
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public bool isLeft=true;
		public ulong time;
		public Stopwatch leftwatch=new Stopwatch();
		public Stopwatch rightwatch=new Stopwatch();
		
		#region 控件缩放
		public volatile bool isInitialized;
		public volatile bool isChanging;
		public volatile Dictionary<string,string> origin;
        public double formWidth;//窗体原始宽度
        public double formHeight;//窗体原始高度
        public double scaleX;//水平缩放比例
        public double scaleY;//垂直缩放比例
        //控件中心Left,Top,控件Width,控件Height,控件字体Size
        /// <summary>
        /// 获取所有原始数据
        /// </summary>
        protected Dictionary<string,string> GetAllInitInfo(Control crlContainer)
        {
        	Dictionary<string,string> ret=new Dictionary<string, string>();
            foreach (Control item in crlContainer.Controls)
            {
                if (item.Name.Trim() != "")
                    ret.Add(item.Name, (item.Left + item.Width / 2) + "," + (item.Top + item.Height / 2) + "," + item.Width + "," + item.Height + "," + item.Font.Size);
                if ((item as UserControl) == null && item.Controls.Count > 0)
                    GetAllInitInfo(item);
            }
            return ret;
        }
        private void ControlsChangeInit(Control crlContainer)
        {
            scaleX = (Convert.ToDouble(crlContainer.Width) / formWidth);
            scaleY = (Convert.ToDouble(crlContainer.Height) / formHeight);
        }
        private void ControlsChange(Control crlContainer,Dictionary<string,string> info)
        {
            double[] pos = new double[5];//pos数组保存当前控件中心Left,Top,控件Width,控件Height,控件字体Size
            foreach (Control item in crlContainer.Controls)
            {
                if (item.Name.Trim() != "")
                {
                    if ((item as UserControl) == null && item.Controls.Count > 0)
                        ControlsChange(item,info);
                    string[] strs = info[item.Name].Split(',');
                    for (int j = 0; j < 5; j++)
                    {
                        pos[j] = Convert.ToDouble(strs[j]);
                    }
                    double itemWidth = pos[2] * scaleX;
                    double itemHeight = pos[3] * scaleY;
                    item.Left = Convert.ToInt32(pos[0] * scaleX - itemWidth / 2);
                    item.Top = Convert.ToInt32(pos[1] * scaleY - itemHeight / 2);
                    item.Width = Convert.ToInt32(itemWidth);
                    item.Height = Convert.ToInt32(itemHeight);
                    try
                    {
                        item.Font = new Font(item.Font.Name, float.Parse((pos[4] * Math.Min(scaleX, scaleY)).ToString()));
                    }
                    catch
                    {
                    	;
                    }
                }
            }
        }

        #endregion
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			this.formWidth = Convert.ToDouble(this.Width);
            this.formHeight = Convert.ToDouble(this.Height);
            this.isInitialized=true;
            MainFormLoad(this,null);
            MainFormResize(this,null);
            this.timer1.Enabled=true;
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void MainFormResize(object sender, EventArgs e)
		{
			if(!this.isInitialized)
				return;
			if (!isChanging && this.origin.Count > 0)
            {
				this.isChanging=true;
                ControlsChangeInit(this);
                ControlsChange(this,this.origin);
                this.isChanging=false;
            }
			if(!isChanging){
			this.formWidth = Convert.ToDouble(this.Width);
            this.formHeight = Convert.ToDouble(this.Height);
			}
		}
		void MainFormLoad(object sender, EventArgs e)
		{
			this.origin=GetAllInitInfo(this);
			this.reset();
			this.StartPosition=FormStartPosition.CenterParent;
			this.WindowState=FormWindowState.Maximized;
		}
		public void reset()
		{
			timer2.Enabled=false;
			resetWatch();
			textBox1.Enabled=true;
			label1.Text=millisToText(0);
			label2.Text=millisToText(0);
			button1.Text="开始";
			button2.Enabled=false;
			button2.Text="暂停";
			button3.Enabled=false;
			isLeft=true;
			label7.Text="";
		}
		public void resetWatch()
		{
			this.leftwatch.Stop();
			this.leftwatch.Reset();
			this.rightwatch.Stop();
			this.rightwatch.Reset();
		}
		void MainFormControlAdded(object sender, ControlEventArgs e)
		{
			this.origin=GetAllInitInfo(this);
		}
		void MainFormControlRemoved(object sender, ControlEventArgs e)
		{
			this.origin=GetAllInitInfo(this);
		}
		void Timer1Tick(object sender, EventArgs e)
		{
			MainFormResize(this,null);
		}
		public static string millisToText(long millis)
		{
			if(millis>=0) return millisToText((ulong)millis);
			return "-"+millisToText((ulong)(-millis));
		}
		public static string millisToText(ulong millis)
		{
			ulong ms=millis%1000;
			ulong h=millis/1000/60/60;
			ulong min=millis/1000/60-h*60;
			ulong s=millis/1000-min*60-h*60*60;
			return h.ToString("00")+":"+min.ToString("00")+":"+s.ToString("00")+"."+ms.ToString("000");
		}
		void Button1Click(object sender, EventArgs e)
		{
			if(button1.Text=="开始")
			{
				try{
			time=ulong.Parse(textBox1.Text.Trim());
			}catch{
				MessageBox.Show("开始时间必须是非负整数!");
				return;
			}
			textBox1.Enabled=false;
			button1.Text="重置";
			label1.Text=millisToText(time*1000);
			label2.Text=millisToText(time*1000);
			updateLabel();
			this.isLeft=true;
			button2.Enabled=true;
			button3.Enabled=true;
			timer2.Enabled=true;
			leftwatch.Start();
			}else{
				reset();
			}
		}
		void Timer2Tick(object sender, EventArgs e)
		{
			long left=(long)time*1000-leftwatch.ElapsedMilliseconds;
			label1.Text=millisToText(left);
			if(left<=0)
			{
				reset();
				MessageBox.Show("左方时间到!","时间到",MessageBoxButtons.OK,MessageBoxIcon.Information,MessageBoxDefaultButton.Button1);
				return;
			}
			long right=(long)time*1000-rightwatch.ElapsedMilliseconds;
			label2.Text=millisToText(right);
			if(right<=0)
			{
				reset();
				MessageBox.Show("右方时间到!","时间到",MessageBoxButtons.OK,MessageBoxIcon.Information,MessageBoxDefaultButton.Button1);
				return;
			}
		}
		public void updateLabel()
		{
			label7.Text="当前作答："+(isLeft?"左":"右")+"方";
		}
		void Button2Click(object sender, EventArgs e)
		{
			if(button2.Text=="暂停")
			{
				if(isLeft)
				  leftwatch.Stop();
			    else rightwatch.Stop();
			    button3.Enabled=false;
			    button2.Text="继续";
			}else{
				if(isLeft)
				  leftwatch.Start();
			    else rightwatch.Start();
			    button3.Enabled=true;
			    button2.Text="暂停";
			}
		}
		public void switchTurn()
		{
			isLeft=!isLeft;
			if(!isLeft)
			{
				leftwatch.Stop();
				updateLabel();
				rightwatch.Start();
			}else{
				rightwatch.Stop();
				updateLabel();
				leftwatch.Start();
			}
		}
		void Button3Click(object sender, EventArgs e)
		{
			switchTurn();
		}
	}
}
