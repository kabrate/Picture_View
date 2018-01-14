using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp2
{

    
    public partial class MainForm : Form
    {
        private int ImageCount=0;//选中图片的数量
        private List<string> ImagePaths = new List<string>();//list用于保存图片路径
        public int nowCount = 0;//当前选择图片的序号
        public MainForm()
        {
            InitializeComponent();
        }
            private void toolStripButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;    
            ofd.Filter = "图片(*.bmp;*.jpg;*.gif)|*.bmp;*.jpg;*.gif";  //过滤文件类型  只显示bmp jpg gif文件
            //if (ofd.ShowDialog()==DialogResult.OK)
            //{

            //    pictureBox.Image = Image.FromFile(ofd.FileName); 
            //    foreach (string path in Directory.GetFiles(Path.GetDirectoryName(ofd.FileName),"*.bmp;*.jpg;*.gif")) //遍历已选择文件的当前文件夹中所有指定类型的文件
            //    {   
            //        ImagePaths.Add(path);
            //        ImageCount++;
            //    }
            //    nowCount = ImagePaths.IndexOf(ofd.FileName);
            //}
            if (ofd.ShowDialog() == DialogResult.OK)//如果正常打开图片的话
            {

                pictureBox.Image = Image.FromFile(ofd.FileName);    //显示一张选中的图片
                foreach (string path in ofd.FileNames)//遍历所有选中的图片
                {
                    ImagePaths.Add(path);//将得到的路径添加到ImagePaths中
                    ImageCount++;
                }
                nowCount = ImagePaths.IndexOf(ofd.FileName);//保存选中图片的序号
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)//下一张图片
        {
            if(nowCount<ImageCount-1)
            {
                nowCount++;
                pictureBox.Image = Image.FromFile(ImagePaths[nowCount]);
            }
            else
            {
                nowCount = 0;
                pictureBox.Image = Image.FromFile(ImagePaths[nowCount]);
            }
            
            
        }

        private void toolStripButton2_Click(object sender, EventArgs e)//上一张图片
        {
            if (nowCount > 0)
            {
                nowCount--;
                pictureBox.Image = Image.FromFile(ImagePaths[nowCount]);
            }
            else
            {
                nowCount = ImageCount-1;
                pictureBox.Image = Image.FromFile(ImagePaths[nowCount]);
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)//自动播放图片
        {
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripButton3_Click(sender, e);
        }

        private void toolStripButton5_Click(object sender, EventArgs e)//停止自动播放
        {
            timer1.Enabled = false;
        }

        private void toolStripButton6_Click(object sender, EventArgs e)//放大
        {
            pictureBox.Width = pictureBox.Width + 10;
            pictureBox.Height = pictureBox.Height + 10;
        }

        private void toolStripButton7_Click(object sender, EventArgs e)//缩写
        {
            pictureBox.Width = pictureBox.Width - 10;
            pictureBox.Height = pictureBox.Height - 10;
        }
    }
}
