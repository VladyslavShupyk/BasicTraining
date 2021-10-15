using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Text.Json;
using System.IO;

namespace NET02._2
{
    class Accounts
    {
        public List<User> users;
        public Accounts()
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
                    int? integerTop;
                    if (String.IsNullOrEmpty(top))
                    {
                        integerTop = null;
                    }
                    else
                    {
                        integerTop = int.Parse(top);
                    }
                    int? integerLeft;
                    if (String.IsNullOrEmpty(left))
                    {
                        integerLeft = null;
                    }
                    else
                    {
                        integerLeft = int.Parse(left);
                    }
                    int? integerWidth;
                    if (String.IsNullOrEmpty(width))
                    {
                        integerWidth = null;
                    }
                    else
                    {
                        integerWidth = int.Parse(width);
                    }
                    int? integerHeight;
                    if (String.IsNullOrEmpty(height))
                    {
                        integerHeight = null;
                    }
                    else
                    {
                        integerHeight = int.Parse(height);
                    }
                    Window window = new Window(nodeChild1.Attributes.GetNamedItem("title").Value, integerTop, integerLeft,integerWidth,integerHeight);
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
        public void CreateJsonFiles()
        {
            List<string> windowsSettings = new List<string>();
            foreach(User user in users)
            {
                windowsSettings.Clear();
                foreach (Window window in user.windows)
                {
                    var User = new
                    {
                        Title = window.Title,
                        Top = window.Top.HasValue ? window.Top : window.DEFAULT_TOP,
                        Left = window.Left.HasValue ? window.Left : window.DEFAULT_LEFT,
                        Width = window.Width.HasValue ? window.Width : window.DEFAULT_WIDTH,
                        Height = window.Height.HasValue ? window.Height : window.DEFAULT_HEIGHT
                    };
                    windowsSettings.Add(JsonSerializer.Serialize(User));
                }
                if (!Directory.Exists($"..\\..\\..\\Config"))
                {
                    Directory.CreateDirectory($"..\\..\\..\\Config");
                }
                File.AppendAllLines($"..\\..\\..\\Config\\{user.Name}.json", windowsSettings);
            }
        }
    }
}
