using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BethanysPieShop.Models;
using MailKit;
using MailKit.Net.Smtp;
using MimeKit;

namespace BethanysPieShop.Controllers
{
   

    public class ContactController : Controller
    {
       
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SendMail(string name, string email, string msg)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("ommaksymchuk.fitu18@kubg.edu.ua"));
            message.To.Add(new MailboxAddress("maximchuk3@gmail.com"));
            message.Subject = name;
            message.Body = new TextPart("html")
            {
                Text = "Імя :" + name + "<br> " +
                "Email: " + email + "<br>" +
                "Повідомлення :" + msg
            };

            using(var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 465);
                client.Authenticate("ommaksymchuk.fitu18@kubg.edu.ua", "maximchuk123");
                client.Send(message);
                client.Disconnect(false);
            }

            return View("Index");


        }

      

        public IActionResult Privacy()
        {
            return View();
        }

  
    }
}
