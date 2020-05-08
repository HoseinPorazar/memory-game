using MemorySkillByHP.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
//Coded by h.hosein44@yahoo.com

namespace MemorySkillByHP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        delegate void Mydel(int number);

        private int Y;
        private int n;
        Button btn;
        
         void Generate(int number)
        {
            Font f = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            Y = 0;
            n = 0;
            //ijade pazzel
            for (int noo = 0; noo < number; noo++)
            {
          

                for (int no =0 ; no < number; no++)
                {
                  
                    n++;
                    btn= new Button();
                    btn.Click += new EventHandler(btnONClick);
                    btn.Tag = n;
                    if (Settings.Default.showNum)
                    {
                        btn.Font = f;
                        btn.Text = n.ToString();//gggggg
                    }
                   
                    
                    
                    btn.BackColor = Color.Crimson; 
                    btn.Size = new System.Drawing.Size(50, 50);
                    btn.Location = new Point(no * 50, Y);
                    btn.BringToFront();
                    if (mylist.Contains((int)btn.Tag))
                    {
                        btn.BackColor = Color.DarkBlue;

                    }
                    this.Controls.Add(btn);
                  

                }
                //retefae khanehaye radife badi
                Y += 50;
                
            }


        }

        //ijade khanehaye random gheyr tekrari
         private List<int> mylist = new List<int>();
         int rand;
         List<int> from = new List<int>();
         void genrandom(int cc)
         {
             if (mylist != null)
             {
                 mylist.Clear();
             }
             if (from != null)
             { from.Clear(); }
             
             for (int x = 1; x <= cc * cc; x++)
             {
                 from.Add(x);
             }
             
             Random r = new Random();
             for (int x = 1; x <= cc; x++)
             {
                 rand = from[r.Next(from.Count)];
                 mylist.Add(rand);
                 from.Remove(rand);
              
             
             }


         }

         void ResizeForm(int no)
        {
            this.Size = new Size((no * 50)+5, (no * 50)+27);

        }
        
 

        private int trueAns = 0;
  
        void btnONClick(object sender, EventArgs e)
        {
            if (!t.Enabled)
            {
                Button btn = sender as Button;
                if (btn != null)
                {
                    if (btn.BackColor != Color.DarkBlue)
                    {

                        if (mylist.Contains((int)btn.Tag))
                        {
                            mylist.Remove((int)btn.Tag);
                            btn.BackColor = Color.DarkBlue;
                            trueAns += 1;
                            if (trueAns == difficulty)
                            {
                                difficulty += 1;
                                trueAns = 0;
                                starrt();
                            }

                        }
                        else
                        {
                            MessageBox.Show("سوختی :D","سوختی  ",MessageBoxButtons.OK, MessageBoxIcon.Stop,MessageBoxDefaultButton.Button1,MessageBoxOptions.RightAlign);
                            if (difficulty > 2)
                            {
                                difficulty -= 1;
                                starrt();
                            }
                            else
                            { 
                                starrt(); 
                            }


                        }
                    }

                    }
                }
            

        }

        private int difficulty =2;
        Timer t = new Timer();
        void starrt()
        {
            trueAns = 0;
            t.Enabled = false;

            //foreach (Button b in this.Controls)
            //{
            //    this.Controls.Remove(b);
            //}
            this.Controls.Clear();
            //ijade delegate
            Mydel del = new Mydel(genrandom);
            
            del += Generate;
            del += ResizeForm;
            //shoru ba 2
            del(difficulty);
         
       
           //bad az 2 sanie makhfi shodane pazel
            if (Settings.Default.speed != 0)
            { t.Interval = Settings.Default.speed * 1000; }
            else
            { t.Interval = 2300; }
        
            t.Enabled = true;
            t.Tick += new EventHandler(Ticked);
            this.Text = " Level " + difficulty.ToString() + "  h.hosein44@yahoo.com";
        }



        SoundPlayer play = new System.Media.SoundPlayer(Properties.Resources.sound);
        private void Form1_Load(object sender, EventArgs e)
        {
            starrt();
            if (Settings.Default.music)
            {

                

            //play.SoundLocation = Application.StartupPath.ToString() + "\\sound.wav";
            //play.SoundLocation = Properties.Resources.sound;
            play.PlayLooping();

            }

            
          
            
       
        
            
        }
        int ff = 0;
        void Ticked(object sender, EventArgs e)
        {
            ff++;
            if (ff == 1)
            {
                t.Enabled = false;
                ff = 0;
                foreach (Button b in this.Controls)
                {

                    b.BackColor = Color.Crimson;

                }
            }
            
          
           
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            play.Stop();
            play.Dispose();
            Application.Exit();
        }



        }

      
    }

