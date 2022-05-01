using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question2
{
    class User
    {
        public User(long UserId, string DateOfBirth, string Name, string Gender, string EMailId, string Password)
        {
            this.UserId = UserId;
            this.DateOfBirth = DateOfBirth;
            this.Name = Name;
            this.Gender = Gender;
            this.EMailId = EMailId;
            this.Password = Password;

        }
        public long UserId { get; set; }

        public string DateOfBirth { get; set; }

        public string Name { get; set; }

        public string Gender { get; set; }

        public string EMailId { get; set; }

        public string Password { get; set; }

    }
}
