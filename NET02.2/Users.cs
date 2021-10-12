using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace NET02._2
{
    class Users
    {
        public List<User> users;
        public Users()
        {
            users = new List<User>();
        }
        public List<User> GetUsers(XmlDocument document)
        {
            XmlElement rootNode = document.DocumentElement;
            List<User> users = new List<User>();
            foreach (XmlNode node in rootNode)
            {
                User user = new User(node.Attributes.GetNamedItem("name").Value);
                foreach (XmlNode nodeChild1 in node)
                {
                    string top = String.Empty;
                    string left = String.Empty;
                    string width = String.Empty;
                    string height = String.Empty;
                    foreach (XmlNode nodeChild2 in nodeChild1)
                    {
                        if (nodeChild2.Name == "top")
                        {
                            top = nodeChild2.InnerText;
                        }
                        if (nodeChild2.Name == "left")
                        {
                            left = nodeChild2.InnerText;
                        }
                        if (nodeChild2.Name == "width")
                        {
                            width = nodeChild2.InnerText;
                        }
                        if (nodeChild2.Name == "height")
                        {
                            height = nodeChild2.InnerText;
                        }
                    }
                    if (String.IsNullOrEmpty(top))
                    {
                        top = null;
                    }
                    if (String.IsNullOrEmpty(left))
                    {
                        left = null;
                    }
                    if (String.IsNullOrEmpty(width))
                    {
                        width = null;
                    }
                    if (String.IsNullOrEmpty(height))
                    {
                        height = null;
                    }
                    Window window = new Window(nodeChild1.Attributes.GetNamedItem("title").Value, top, left, width, height);
                    user.AddWindow(window);
                }
                users.Add(user);
            }
            this.users = users;
            return this.users;
        }
        public List<User> GetUsersWithIncorrectConfiguration()
        {
            List<User> tempUsersList = new List<User>();
            foreach(User user in this.users)
            {
                if(user.windows.Count == 1 && user.windows[0].Title == "main" && user.windows[0].Top != null && user.windows[0].Left != null && user.windows[0].Width != null && user.windows[0].Height != null)
                {
                    tempUsersList.Add(user);
                }
                if(user.windows.Count != 0 && user.windows[0].Top == null && user.windows[0].Left == null && user.windows[0].Width == null && user.windows[0].Height == null)
                {
                    tempUsersList.Add(user);
                }
                if(user.windows.Count == 1 && user.windows[0].Title == "main" && user.windows[0].Top == null && user.windows[0].Left == null && user.windows[0].Width == null && user.windows[0].Height == null)
                {
                    tempUsersList.Add(user);
                }
            }
            var result = this.users.Except(tempUsersList);
            List<User> usersList = new List<User>();
            foreach(User user in result)
            {
                usersList.Add(user);
            }
            return usersList;
        }
    }
}
