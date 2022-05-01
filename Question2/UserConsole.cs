using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question2
{
    class UserConsole
    {

        public static void ShowUser(User user)
        {
            Console.WriteLine("User Id       :" + user.UserId);
            Console.WriteLine("Name          :" + user.Name);
            Console.WriteLine("Gender        :" + user.Gender);
            Console.WriteLine("Date of Birth :" + user.DateOfBirth);
            Console.WriteLine("E-Mail Id     :" + user.EMailId);
            Console.WriteLine("Password      :" + user.Password);
        }

        public static User CreateUser(User user)
        {
            long userId = 0;
            string dateOfBirth, name, gender, eMailId, password;

            Console.WriteLine("Enter User Id(should be min 5 len)");

            try
            {
                userId = Convert.ToInt64(Console.ReadLine());
                if (userId.ToString().Length < 5)
                    throw new InvalidUserId("Sorry,Id Should be min 5 length");
            }
            catch (InvalidUserId exception)
            {
                Console.WriteLine(exception);
            }
            catch (System.FormatException exception)
            {
                Console.WriteLine(exception);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }

            Console.WriteLine("Enter Name :");
            name = Console.ReadLine();

            try
            {
                name = UserManager.ConvertTitlecase(name);

                if (name == null)
                    throw new StringContainDigit("Name Contain Digits");
            }
            catch (StringContainDigit exception)
            {
                Console.WriteLine(exception);
            }

            Console.WriteLine("Enter Gender ");
            gender = Console.ReadLine();

            try
            {
                gender = UserManager.ConvertTitlecase(gender);
                if (!(gender.Equals("Male") || gender.Equals("Females")))
                    throw new StringContainDigit("InValid Gender ");
            }
            catch (StringContainDigit exception)
            {
                Console.WriteLine(exception);
            }


            Console.WriteLine("Enter Date of Birth ");
            dateOfBirth = Console.ReadLine();
            try
            {
                if (!UserManager.ValidateDate(dateOfBirth))
                    throw new InvalidDate("Sorry ,Invalid date");
            }
            catch (InvalidDate exception)
            {
                Console.WriteLine(exception);
            }

            Console.WriteLine("Enter Email id");
            eMailId = Console.ReadLine();

            try
            {
                if (!UserManager.ValidateEMailId(eMailId))
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
                if (!UserManager.ValidatePassword(password))
                    throw new InvalidPassword("Password Doesn't meet criteria");
            }
            catch (InvalidPassword exception)
            {
                Console.WriteLine(exception);
            }

            user = new User(userId, dateOfBirth, name, gender, eMailId, password);

            return user;
        }

    }
}
