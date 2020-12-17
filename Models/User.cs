using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class User
    {
        public int UserId { get; set; }
        public int TypeId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
