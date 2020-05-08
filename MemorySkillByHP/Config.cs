using MemorySkillByHP.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Windows.Forms;

namespace MemorySkillByHP
{
    public partial class Config : Form
    {
        public Config()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
       
           
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                Settings.Default.showNum = true;
            }
            else
            { Settings.Default.showNum = false; }
            if (checkBox1.Checked)
            {
                Settings.Default.music = true;
            }
            else
            { Settings.Default.music = false; }
            Settings.Default.speed = trackBar1.Value;
            Settings.Default.Save();
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }

        private void Config_Load(object sender, EventArgs e)
        {

        }
    }
}
