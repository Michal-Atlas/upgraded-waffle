using System;

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
