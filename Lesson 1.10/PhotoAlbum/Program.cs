using System;
using System.Linq;
using PhotoAlbum.Abstract;
using PhotoAlbum.Logger;

namespace PhotoAlbum
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the program.");
            Album _album = new Album();
            while (ControlMenu.Run(_album));
        }

    }
}
