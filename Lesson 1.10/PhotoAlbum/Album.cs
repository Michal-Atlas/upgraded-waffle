using System.Collections.Generic;
using System.Linq;

namespace PhotoAlbum
{
    public class Album : IAlbum
    {
        private Dictionary<int,Photo> data = new Dictionary<int, Photo>();

        public Result Add(Photo photo)
        {
            if (!data.ContainsKey(photo.Id))
            {
                data.Add(photo.Id, photo);
                return Result.OK;
            }
            else
            {
                return Result.FAULT_DB;
            }
        }

        public Result Remove(int id)
        {
            if (data.ContainsKey(id))
            {
                data.Remove(id);
                return Result.OK;
            }
            else
            {
                return Result.FAULT_DB;
            }
        }

        public List<Photo> GetAllPhotos()
        {
            return data.Values.ToList();
            
        }

        public void Show(int id)
        {
            ControlMenu.Show(data[id]);
        }
    }
}
