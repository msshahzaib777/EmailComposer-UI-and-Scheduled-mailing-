using System;
using System.Windows.Forms;
using System.ServiceProcess;
using System.Timers;
using System.Net.Mail;
using System.Configuration;
using System.Xml.Serialization;
using System.IO;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace k163810_Q3
{
    public partial class EmailSender : ServiceBase
    {

        private SmtpClient SmtpServer;
        private EmailMessage Emailmsg;
        private string LocationOfSavedEmail;
        private string LocationOfSentEmailCount;
        private string myEmail;
        private int SentEmailCount;
        private XmlSerializer mySerializer;

        public EmailSender()
        {
            InitializeComponent();
            InitializeVariables();
        }

        protected override void OnStart(string[] args)
        {
            System.Timers.Timer t = new System.Timers.Timer(15*60*1000);
            t.Elapsed += new ElapsedEventHandler(Email_Sender);
            t.Start();
        }

        protected override void OnStop()
        {
            File.WriteAllText(LocationOfSentEmailCount, SentEmailCount.ToString());
        }

        public void OnDebug()
        {
            OnStart(null);
        }

        protected void Email_Sender(object sender, System.Timers.ElapsedEventArgs e)
        {
            Debug.WriteLine("Sending Email");
            string path = LocationOfSavedEmail;
            int MaxCount = 0;
            string[] files = Directory.GetFiles(LocationOfSavedEmail.Substring(0, LocationOfSavedEmail.Length - 1));
            string[] spearator = { "\\" }; 
            foreach (string file in files)
            {
                string [] str_arr = file.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                string str = str_arr[str_arr.Length - 1];
                Debug.WriteLine("Email no: " + int.Parse(Regex.Match(str, @"\d+").Value));
                if (MaxCount <= int.Parse(Regex.Match(str, @"\d+").Value))
                {
                    MaxCount = int.Parse(Regex.Match(str, @"\d+").Value);
                }
                    
            }

            Debug.WriteLine("MaxCount: " + MaxCount);
            Debug.WriteLine("SentEmailCount: " + SentEmailCount);

            while ( MaxCount >= SentEmailCount)
            {
                if (File.Exists(path + "Email" + SentEmailCount + ".xml"))
                {
                    //reads Email from the path provided to the private EmailMessage Emailmsg
                    //using the serializer sent along the path

                    Email_Reader(path + "Email" + SentEmailCount + ".xml", mySerializer);
                    
                    //Creating Mail to be sent over smpt

                    MailAddress to = new MailAddress(Emailmsg.To);
                    MailAddress from = new MailAddress(myEmail);

                    MailMessage message = new MailMessage(from, to)
                    {
                        Subject = Emailmsg.Subject,
                        Body = Emailmsg.MessageBody
                    };
                    
                    try
                    {
                        SmtpServer.Send(message);
                        Debug.WriteLine("Email" + SentEmailCount + " Sent.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Error Sending Email");
                    }
                }
                SentEmailCount++;
            }
            File.WriteAllText(LocationOfSentEmailCount, SentEmailCount.ToString());
            Debug.WriteLine("Intervel Ends");

        }

        protected void Email_Reader(string path, XmlSerializer Xs)
        {
            FileStream myFileStream = new FileStream(path, FileMode.Open);

            Emailmsg = (EmailMessage)Xs.Deserialize(myFileStream);
        }

        protected void InitializeVariables()
        {
            SmtpServer = new SmtpClient(ConfigurationManager.AppSettings["SmtpServer"])
            {
                Port = int.Parse(ConfigurationManager.AppSettings["Port"]),
                EnableSsl = Boolean.Parse(ConfigurationManager.AppSettings["EnableSsl"]),
                UseDefaultCredentials = false,
                Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["MyEmail"]
                                                                        , ConfigurationManager.AppSettings["Password"]),
                DeliveryMethod = SmtpDeliveryMethod.Network
            };

            myEmail = ConfigurationManager.AppSettings["MyEmail"];
            LocationOfSentEmailCount = ConfigurationManager.AppSettings["LocationToSaveSentEmailCount"];
            LocationOfSavedEmail = ConfigurationManager.AppSettings["LocationOfSavedEmail"];
            SentEmailCount = ReadSentEmailCount();
            if (!Directory.Exists(LocationOfSavedEmail))
            {
                throw new DirectoryNotFoundException();
            }

            mySerializer = new XmlSerializer(typeof(EmailMessage));
            Emailmsg = new EmailMessage("to", "sub", "msg");


        }

        private int ReadSentEmailCount()
        {
            if (File.Exists(LocationOfSentEmailCount))
            {
                string str_EmailCount = File.ReadAllText(LocationOfSentEmailCount);
                int check = 0;
                if (str_EmailCount != "")
                {
                    check = int.Parse(str_EmailCount);
                }

                return check;
            }
            else
            {
                using (var tw = new StreamWriter(LocationOfSentEmailCount, false))
                {
                    tw.WriteLine("0");
                }
                return 0;
            }
        }
    }
}
