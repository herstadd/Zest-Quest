using Game.Models;

namespace Game.ViewModels
{
    public class GenericViewModel<T> : BaseViewModel<DefaultModel> where T: class
    {
        /// <summary>
        /// The Item Model
        /// </summary>
        T bindingData { get; set; }

        public T Data
        {
            get { return bindingData; }
            set {
                var data = bindingData;
                SetProperty(ref data, value);
                bindingData = data;
            }
        }

        /// <summary>
        /// Constructor takes an existing item and sets
        /// The Title for the page to match the text of data
        /// The Data to be the passed in data
        /// </summary>
        /// <param name="data"></param>
        public GenericViewModel(T data)
        {
            if (data != null)
            {
                Title = (data as BaseModel<T>).Name;
            }
            Data = data;
        }

        // Generic Constructor
        public GenericViewModel()
        {
        }
    }
}
