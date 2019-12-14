using System;
using System.Windows.Forms;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using System.IO;

namespace k163810_Q2
{
    public partial class Email_Composer : Form
    {
        private string LocationToSaveEmail;
        private int emailCount;
        private string LocationToSaveEmailCount;

        public Email_Composer()
        {
            InitializeComponent();
        }

        private bool Email_Validation()
        {
            if (Regex.IsMatch(to_textbox.Text, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"))
            {
                return true;
            }
            else
            {
               return false;
            }
        }

        private void Send_Button_Click(object sender, EventArgs e)
        {
            string msg = "";
            string caption = "Error Found!";
            int error = 0;
            if (string.IsNullOrEmpty(to_textbox.Text))
            {
                msg = "Please Enter Reciever's Email!";
                error++;
            }
            else if (!Email_Validation())
            {
                msg = "Invalid EmailAddress";
                error++;
            }
            else if (string.IsNullOrEmpty(sub_textbox.Text)) {
                msg = "Please Enter Subject!";
                error++;
            }
            else if (string.IsNullOrEmpty(msg_textbox.Text))
            {
                msg = "Please Enter Email Body!";
                error++;
            }

            if (error > 0)
            {
                MessageBox.Show(msg, caption, MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                Write_Email();
                emailCount++;
                DialogResult result = MessageBox.Show("Email havebeen written. Do you want to write another Email", "DONE", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    to_textbox.Text = "";
                    sub_textbox.Text = "";
                    msg_textbox.Text = "";
                }
                else if(result == DialogResult.No){
                    this.Close();   
                }
            }

        }

        private void Write_Email()
        {
            string filename = LocationToSaveEmail + "Email" + emailCount.ToString() + ".xml";
            EmailMessage email = new EmailMessage(to_textbox.Text, sub_textbox.Text, msg_textbox.Text);
            XmlSerializer xs = new XmlSerializer(typeof(EmailMessage));
            System.Diagnostics.Debug.WriteLine(filename);
            TextWriter emailwriter = new StreamWriter(filename);
            
            try
            {
                xs.Serialize(emailwriter, email);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString(), "Error!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
            emailwriter.Close();
            File.WriteAllText(LocationToSaveEmailCount, emailCount.ToString());

        }

        private void Email_Composer_FormClosing(object sender, FormClosingEventArgs e)
        {
            File.WriteAllText(LocationToSaveEmailCount, emailCount.ToString());
        }

        private void Email_Composer_Load(object sender, EventArgs e)
        {
            LocationToSaveEmail = ConfigurationManager.AppSettings["LocationToSaveEmail"];
            LocationToSaveEmailCount = ConfigurationManager.AppSettings["LocationToSaveEmailCount"];
            if (!Directory.Exists(LocationToSaveEmail) )
            {
                throw new DirectoryNotFoundException();
            }
            emailCount = ReadEmailCount();
        }

        private int ReadEmailCount()
        {
            if (File.Exists(LocationToSaveEmailCount))
            {
                string str_EmailCount = File.ReadAllText(LocationToSaveEmailCount);
                int check = 0;
                if (str_EmailCount != "" )
                {
                   check = int.Parse(str_EmailCount);
                }

                return check;
            }
            else
            {
                using (var tw = new StreamWriter(LocationToSaveEmailCount, false))
                {
                    tw.WriteLine("0");
                }
                return 0;
            }
        }
    }

}
