﻿using NUnit.Framework;
using System;
using System.IO;
using System.Net.Mail;

namespace MailJet.Client.Tests
{
    [TestFixture]
    public class SendMail
    {
        private MailJetClient _client;

        [SetUp]
        public void Setup()
        {
            _client = new MailJetClient("xxx", "xxx");
        }

        [Test]
        public void MailMessage_Text_NoAttachements()
        {
            var message = new MailMessage();
            message.From = new MailAddress("myemail@mydomain.com");
            message.To.Add(new MailAddress("anotheremail@mydomain.com"));
            message.Subject = "test";
            message.Body = "test";
            var result = _client.SendMessage(message);
            Assert.IsTrue(result);
        }

        [Test]
        public void MailMessage_Text_WithAttachements()
        {
            var message = new MailMessage();
            message.From = new MailAddress("myemail@mydomain.com");
            message.To.Add(new MailAddress("anotheremail@mydomain.com"));
            message.Subject = "test";
            message.Body = "test";
            var path = Path.Combine(Environment.CurrentDirectory, "TestData", "TextFile.txt");
            message.Attachments.Add(new Attachment(path));
            var result = _client.SendMessage(message);
            Assert.IsTrue(result);
        }

        [Test]
        public void MailMessage_Html_NoAttachements()
        {
            var message = new MailMessage();
            message.From = new MailAddress("myemail@mydomain.com");
            message.To.Add(new MailAddress("anotheremail@mydomain.com"));
            message.Subject = "test";
            message.Body = "<b>TEST</b>";
            message.IsBodyHtml = true;
            var result = _client.SendMessage(message);
            Assert.IsTrue(result);
        }
    }
}
