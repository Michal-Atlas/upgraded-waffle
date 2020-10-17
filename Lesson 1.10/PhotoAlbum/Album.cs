using System.Collections.Generic;
using System.Linq;
<<<<<<< HEAD
=======
using System.Text;
using PhotoAlbum.Logger;
>>>>>>> master

namespace PhotoAlbum
{
    public class Album : IAlbum
    {
<<<<<<< HEAD
        private Dictionary<int,Photo> data = new Dictionary<int, Photo>();
=======
        private readonly ILogger _logger;

        public Album(ILogger logger)
        {
            _logger = logger;
        }

        private readonly List<Photo> _storage = new List<Photo>();
>>>>>>> master

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
<<<<<<< HEAD
            else
            {
                return Result.FAULT_DB;
=======
            catch (ArgumentNullException e)
            {
                _logger.Log(e.Message);
                return new Result(e.Message);
>>>>>>> master
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
