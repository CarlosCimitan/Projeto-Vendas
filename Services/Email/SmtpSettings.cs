﻿namespace ProjetoVendas.Services.Email
{
    public class SmtpSettings
    {
        public string Server { get; set; }  
        public int Port { get; set; }  
        public string Username { get; set; }  
        public string Password { get; set; }  
        public bool EnableSSL { get; set; }  
        public string From { get; set; }  
    }
}