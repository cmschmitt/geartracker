using System;
using System.Collections.Generic;
using System.Text;

namespace GearTracker.Models
{
    public class Token
    {
        public int Id { get; set; }
        public string AccessToken { get; set; }
        public string ErrorDescription { get; set; }
        public DateTime ExpirationDate { get; set; }
        public Token()
        {

        }
    }
}
