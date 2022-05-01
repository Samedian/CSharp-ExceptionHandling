using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Question2
{

    public class InvalidUserId : Exception
    {
        public InvalidUserId(String msg) : base(msg)
        {

        }
    }

    public class InvalidPassword : Exception
    {
        public InvalidPassword(String msg) : base(msg)
        {

        }
    }

    public class InvalidEMailId : Exception
    {
        public InvalidEMailId(String msg) : base(msg)
        {

        }
    }
    public class InvalidDate : Exception
    {
        public InvalidDate(String msg) : base(msg)
        {

        }
    }
    public class NonNegativeInteger : Exception
    {
        public NonNegativeInteger(String msg) : base(msg)
        {

        }
    }

    public class StringContainDigit : Exception
    {
        public StringContainDigit(String msg) : base(msg)
        {

        }
    }

    class UserManager
    {

        static void Main(string[] args)
        { 
            User user = null;
            char ch;
            do
            {
                user = UserConsole.CreateUser(user);

                UserConsole.ShowUser(user);

                Console.WriteLine("Do you want to continue ");
                ch = Convert.ToChar(Console.ReadLine());
            } while (ch == 'y' || ch == 'Y');

            Console.ReadKey();
        }


        public static bool ValidatePassword(string password)
        {
            Regex regex = new Regex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$");
            if (regex.IsMatch(password))
                return true;
            return false;
        }

        public static bool ValidateDate(string date)
        {
            Regex regex = new Regex("^(0[1-9]|[12][0-9]|3[0-1])[-/.](0[1-9]1[0-2])[-/.](19|20)$");

            if (regex.IsMatch(date))
                return true;

            return false;

        }

        public static bool ValidateEMailId(string emailId)
        {
            Regex regex = new Regex(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z");

            if (regex.IsMatch(emailId))
                return true;
            return false;
        }
        public static string ConvertTitlecase(string name)
        {
            if (name.Any(char.IsDigit))
                return null;

            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            name = textInfo.ToTitleCase(name);
            return name;
        }
    }
}
