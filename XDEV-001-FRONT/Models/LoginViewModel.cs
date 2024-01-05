﻿namespace XDEV_001_FRONT.Models
{
    public class LoginViewModel
    {
        public int? ID { get; set; }
        public string? FullName { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public string? Designation { get; set; }
        public string? UserMessage { get; set; }
        public string? AccessToken { get; set; }
    }
}
