using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Streams
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = @"c:\";
            openFileDialog1.Title = "Vyber Subor";
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;
            openFileDialog1.Filter = "Text files (TXT) | *.txt";

            //vyskoci okno kde hladame textak
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
            }
            
            //pre citanie streamu zo suboru
            //using blok pro automaticke uvolneni streamu
            //automaticky disposne stream preto sa dava using
            using(StreamReader sr = new StreamReader(openFileDialog1.FileName))
            {
                string obsahSuboru = sr.ReadToEnd();
                textBox2.Text = obsahSuboru;
            }



            using (StreamWriter writer = new StreamWriter(@"c:\temp\tento.txt", true)) //append true = takze pri novom otvoreni neprepise subor, ale ho updatne tym co tam napiseme
                                                                                       //vytvori textovy subor na tej ceste
            {
                writer.Write(textBox2.Text.ToUpper());
            }

            ZipFile.CreateFromDirectory(@"c:\temp", @"c:\temp1\kopie.zip");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WebClient webclient = new WebClient();
            using(StreamReader htmlReader = new StreamReader(webclient.OpenRead(textBox3.Text)))
            {
                textBox2.Text = htmlReader.ReadToEnd();

            }
            

        }
    }
}
