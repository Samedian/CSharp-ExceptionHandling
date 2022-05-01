using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Question1
{
    public class InvalidUserId : Exception
    {
        public InvalidUserId(String msg) :base(msg)
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
                user = CreateUser(user);

                showUser(user);

                Console.WriteLine("Do you want to continue ");
                ch = Convert.ToChar(Console.ReadLine());
            } while (ch =='y'||ch=='Y');

            Console.ReadKey();
        }

        private static void showUser(User user)
        {
            Console.WriteLine("User Id       :"+user.UserId);
            Console.WriteLine("Name          :"+user.Name);
            Console.WriteLine("Gender        :"+user.Gender);
            Console.WriteLine("Date of Birth :"+user.DateOfBirth);
            Console.WriteLine("E-Mail Id     :"+user.EMailId);
            Console.WriteLine("Password      :"+user.Password);
        }

        private static User CreateUser(User user)
        {
            long userId=0;
            string dateOfBirth, name,gender,eMailId,password;

            Console.WriteLine("Enter User Id(should be min 5 len)");

            try
            {
                userId = Convert.ToInt64(Console.ReadLine());
                if(userId.ToString().Length < 5)
                    throw new InvalidUserId("Sorry,Id Should be min 5 length");
            }
            catch(InvalidUserId exception)
            {
                Console.WriteLine(exception);
            }catch(System.FormatException exception)
            {
                Console.WriteLine(exception);
            }catch(Exception exception)
            {
                Console.WriteLine(exception);
            }

            Console.WriteLine("Enter Name :");
            name = Console.ReadLine();

            try
            {
                name = ConvertTitlecase(name);

                if (name == null)
                    throw new StringContainDigit("Name Contain Digits");
            }catch(StringContainDigit exception)
            {
                Console.WriteLine(exception);
            }

            Console.WriteLine("Enter Gender ");
            gender = Console.ReadLine();

            try
            {
                gender = ConvertTitlecase(gender);
                if (!(gender.Equals("Male") || gender.Equals("Females")))
                    throw new StringContainDigit("InValid Gender ");
            }catch(StringContainDigit exception)
            {
                Console.WriteLine(exception);
            }


            Console.WriteLine("Enter Date of Birth ");
            dateOfBirth = Console.ReadLine();
            try
            {
                if (!ValidateDate(dateOfBirth))
                    throw new InvalidDate("Sorry ,Invalid date");
            }catch(InvalidDate exception)
            {
                Console.WriteLine(exception);
            }

            Console.WriteLine("Enter Email id");
            eMailId = Console.ReadLine();

            try
            {
                if (!ValidateEMailId(eMailId))
                    throw new InvalidEMailId("Id Doesn't follow norms");
            }
            catch (InvalidEMailId exception)
            {
                Console.WriteLine(exception);
            }

            Console.WriteLine("Enter Password ");
            password = Console.ReadLine();

            try
            {
                if (!ValidatePassword(password))
                    throw new InvalidPassword("Password Doesn't meet criteria");
            }catch(InvalidPassword exception)
            {
                Console.WriteLine(exception);
            }

            user = new User(userId,dateOfBirth,name,gender,eMailId,password);

            return user;
        }

        private static bool ValidatePassword(string password)
        {
            Regex regex = new Regex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$");
            if (regex.IsMatch(password))
                return true;
            return false;
        }
        
        private static bool ValidateDate(string date)
        {
            Regex regex = new Regex("^(0[1-9]|[12][0-9]|3[0-1])[-/.](0[1-9]1[0-2])[-/.](19|20)$");

            if (regex.IsMatch(date))
                return true;

            return false;

        }

        private static bool ValidateEMailId(string emailId)
        {
            Regex regex = new Regex(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z");

            if (regex.IsMatch(emailId))
                return true;
            return false;
        }
        private static string ConvertTitlecase(string name)
        {
            if (name.Any(char.IsDigit))
                return null;

            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            name = textInfo.ToTitleCase(name);
            return name;
        }
    }
}
