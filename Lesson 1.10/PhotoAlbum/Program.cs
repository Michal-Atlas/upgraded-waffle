using System;

namespace PhotoAlbum
{
    class Program
    {
        public static Album _album = new Album();
        static void Main(string[] args)
        {
            while (ControlMenu.Run());
        }
    }
}
