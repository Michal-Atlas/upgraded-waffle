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
        private static int IDindex = 0;
        private static Stack<int> Deletes = new Stack<int>();
        private static Dictionary<Command, (string, Action<Album>)> CommDict = new Dictionary<Command, (string, Action<Album>)>()
        {
            {Command.ADD, ("Add", SubMenu_add)},
            {Command.REMOVE, ("Remove", SubMenu_remove)},
            {Command.SHOW, ("Show", SubMenu_show)},
            {Command.SHOW_ALL, ("Show All", SubMenu_show_all)},
            {Command.EXIT, ("Exit", null)}
        };
        static public bool Run(Album album)
        {
            Console.WriteLine("----------");
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
                CommDict[(Command) userComm].Item2(album);
                return true;
            }
            return false;
        }

        static void SubMenu_add(Album album)
        {
            Console.WriteLine("::Add Submenu Invoked::");
            Console.Write("[NAME] >> ");
            string name = Console.ReadLine();
            Console.Write("[PATH] >> ");
            string path = Console.ReadLine();

            int id = Deletes.Count > 0 ? Deletes.Pop() : IDindex++;
            
            Console.WriteLine($"[Generated ID] > {id}");
            var result = album.Add(new Photo(id, name, path));
            Console.WriteLine(result);
        }
        static void SubMenu_remove(Album album)
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

            var result = album.Remove(userComm);
            if (result == Result.OK)
            {
                Deletes.Push(userComm);
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("Delete Failed");
            }
            Console.WriteLine(result);
        }
        static void SubMenu_show(Album album)
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
            
            album.Show(userComm);
        }
        static void SubMenu_show_all(Album album)
        {
            Console.WriteLine("::Show All Submenu Invoked::");
            Console.WriteLine("\n[ID]\t[Name]\t[Path]\n");
            foreach (var photo in album.GetAllPhotos())
            {
                Console.WriteLine($"[{photo.Id}]\t{photo.Name}\t{photo.Path}");
            }
        }

        public static void Show(Photo photo)
        {
            Process.Start("xdg-open ", photo.Path);
        }
    }
}