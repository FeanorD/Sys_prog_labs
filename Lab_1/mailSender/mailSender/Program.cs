using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace mailSender
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string emailAdress = "meleshkodim2000@gmail.com";
                if (args.Length != 2)
                {
                    throw new ArgumentException();
                }
                else
                {
                    SmtpClient C = new SmtpClient("smtp.gmail.com")
                    {
                        Port = 587,
                        Credentials = new NetworkCredential("meleshkodim2000@gmail.com", "nothingelse0"),
                        EnableSsl = true
                    };
                    string message = DateTime.Now.ToString() + " Мелешко Дмитро";
                    C.Send(new MailMessage("meleshkodim2000@gmail.com", args[0], args[1], message));
                    C.Dispose();
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("you should use correct syntax:<program> email theme");
            }
        }
    }
}
