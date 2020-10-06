using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using PhotoAlbum;

namespace PhotoAlbum
{
    enum Command
    {
        ADD,
        REMOVE,
        SHOW,
        SHOW_ALL,
        EXIT
    }
    public static class ControlMenu
    {
        private static Dictionary<Command, (string, Action)> CommDict = new Dictionary<Command, (string, Action)>()
        {
            {Command.ADD, ("Add", SubMenu_add)},
            {Command.REMOVE, ("Remove", SubMenu_remove)},
            {Command.SHOW, ("Show", SubMenu_show)},
            {Command.SHOW_ALL, ("Show All", SubMenu_show_all)},
            {Command.EXIT, ("Exit", null)}
        };
        static public bool Run()
        {
            foreach (var i in CommDict)
            {
                Console.WriteLine($" - [{(int)i.Key}] {i.Value.Item1}");
            }

            int userComm = -1;
            while (userComm == -1)
            {
                try
                {
                    Console.Write(">> ");
                    userComm = Convert.ToInt32(Console.ReadLine());
                    if (!Enum.IsDefined(typeof(Command), userComm))
                    {
                        Console.WriteLine("Not in command List.");
                        userComm = -1;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid Input, please enter a command number from the list.");
                }
            }

            if ((Command) userComm != Command.EXIT)
            {
                CommDict[(Command) userComm].Item2();
                return true;
            }
            return false;
        }

        static void SubMenu_add()
        {
            Console.WriteLine("::Add Submenu Invoked::");
            Console.Write("[NAME] >> ");
            string name = Console.ReadLine();
            Console.Write("[PATH] >> ");
            string path = Console.ReadLine();
            
            MD5 md5Hasher = MD5.Create();
            var hashed = md5Hasher.ComputeHash(Encoding.UTF8.GetBytes(path));
            var ivalue = Math.Abs(BitConverter.ToInt32(hashed, 0));
            
            Console.WriteLine($"[Generated ID] > {ivalue}");
            Photo photo = new Photo(ivalue, name, path);
            Program._album.Add(photo);
        }
        static void SubMenu_remove()
        {
            Console.WriteLine("::Remove Submenu Invoked::");
            
            int userComm = -1;
            while (userComm == -1)
            {
                try
                {
                    Console.Write("[ID] >> ");
                    userComm = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid Input, please enter a command number from the list.");
                }
            }

        }
        static void SubMenu_show()
        {
            Console.WriteLine("::Show Submenu Invoked::");
            
            int userComm = -1;
            while (userComm == -1)
            {
                try
                {
                    Console.Write("[ID] >> ");
                    userComm = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid Input, please enter a command number from the list.");
                }
            }
            
            Program._album.Show(userComm);
        }
        static void SubMenu_show_all()
        {
            Console.WriteLine("::Show All Submenu Invoked::");
            Console.WriteLine("\n[ID]\t[Name]\t[Path]\n");
            foreach (var photo in Program._album.GetAllPhotos())
            {
                Console.WriteLine($"[{photo.Id}]\t{photo.Name}\t{photo.Path}");
            }
        }

        public static void Show(Photo photo)
        {
            System.Diagnostics.Process.Start(photo.Path);
        }
    }
}