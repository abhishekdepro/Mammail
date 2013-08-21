using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net.Mime;

namespace mail_client
{
    public partial class Form1 : Form
    {
        String path;
        //string str1, str2;
        MailMessage mail = new MailMessage();
        public Form1()
        {
            InitializeComponent();
        }
        
        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("Please enter proper credentials\n");
            }
            else
            {
                MessageBox.Show("Successfully logged in");
            }
           
        }
        private void button3_Click(object sender, EventArgs e)
        {
            SmtpClient SmtpServer = new SmtpClient();
            SmtpServer.Credentials = new System.Net.NetworkCredential(textBox4.Text, textBox5.Text);
            SmtpServer.Port = 587;
            SmtpServer.Host = "smtp.gmail.com";
            SmtpServer.EnableSsl = true;
            mail = new MailMessage();
            String[] send_from = textBox1.Text.Split(',');
            try
            {
                mail.From = new MailAddress(textBox4.Text, textBox4.Text, System.Text.Encoding.UTF8);
                Byte i;
                for (i = 0; i < send_from.Length; i++)
                    mail.To.Add(send_from[i]);
                mail.Subject = textBox3.Text;
                mail.Body = richTextBox1.Text;
                if (listBox1.Items.Count != 0)
                {
                    for (i = 0; i < listBox1.Items.Count; i++)
                        mail.Attachments.Add(new Attachment(listBox1.Items[i].ToString()));
                }
                string page;
                page = "<html><body><table border=2><tr width=100%><td></body></html>";
                AlternateView aview1 = AlternateView.CreateAlternateViewFromString(page + richTextBox1.Text, null, MediaTypeNames.Text.RichText);
                mail.AlternateViews.Add(aview1);
                mail.IsBodyHtml = true;
                //mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnSuccess;
                if (mail.DeliveryNotificationOptions == DeliveryNotificationOptions.OnSuccess)
                {
                    MessageBox.Show("Mail has been sent to: {0}",textBox1.Text);
                }
                mail.ReplyTo = new MailAddress(textBox1.Text);
                SmtpServer.Send(mail);
            }
            catch (Exception x)
            {
                MessageBox.Show(x.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialogue1=new OpenFileDialog();
            
            Form1.DefaultFont.Style.CompareTo(System.Drawing.FontStyle.Strikeout);// = Color.BlueViolet;
            if (dialogue1.ShowDialog() == DialogResult.OK)
            {
                listBox1.Items.Add(dialogue1.FileName);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox3_MouseEnter(object sender, EventArgs e)
        {
            //textBox3.Focus();
            
            //richTextBox1.Focus();
        }
        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.Aqua;
        }
        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Control.DefaultBackColor;
        }
        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.BackColor = Color.Aqua;
        }
        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Control.DefaultBackColor;
        }
        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.BackColor = Color.Aqua;
        }
        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Control.DefaultBackColor;
        }
        private void button4_MouseEnter(object sender, EventArgs e)
        {
            button4.BackColor = Color.Aqua;
        }
        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.BackColor = Control.DefaultBackColor;
        }
        private void button5_MouseEnter(object sender, EventArgs e)
        {
            button5.BackColor = Color.Aqua;
        }
        private void button5_MouseLeave(object sender, EventArgs e)
        {
            button5.BackColor = Control.DefaultBackColor;
        }

        private void button1_MouseClick(object sender, EventArgs e)
        {
            button1.BackColor = Color.Gold;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            textBox2.Text = textBox4.Text;
        }

       

        
    }
}
