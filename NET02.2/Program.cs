using System.Xml;
using System;
using System.Collections.Generic;

namespace NET02._2
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(@"..\..\..\XML\Users.xml");
            Users users = new Users();
            users.GetUsers(xml);
            foreach(User user in users.users)
            {
                Console.Write(user.ToString()); 
            }
            Console.WriteLine();
            List<User> incorrect = users.GetUsersWithIncorrectConfiguration();
            if(incorrect.Count > 0)
            {
                Console.WriteLine("Users with incorrect configuration : ");
                foreach (User user in incorrect)
                {
                    Console.WriteLine(user.Name);
                }
            }
            else
            {
                Console.WriteLine("Don't have users with incorrect configuration");
            }
        }
    }
}
