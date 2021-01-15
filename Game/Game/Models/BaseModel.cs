
namespace Game.Models
{
    /// <summary>
    /// Base model for records that get saved
    /// </summary>
    public class BaseModel<T> : DefaultModel
    {
        // Location to the image for the item.  Will come from the server as a fully qualified URI example:  https://developer.android.com/images/robot-tiny.png
        public string ImageURI { get; set; } = Services.ItemService.DefaultImageURI;

        /// <summary>
        /// Update Method is virutal and changed for each class
        /// </summary>
        /// <param name="newData"></param>
        /// <returns></returns>
        public virtual bool Update(T newData)
        {
            return true;
        }
    }
}