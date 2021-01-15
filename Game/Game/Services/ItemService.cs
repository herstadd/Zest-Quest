using System.Collections.Generic;
using System.Threading.Tasks;

using Newtonsoft.Json.Linq;

using Game.Helpers;
using Game.Models;
using Game.ViewModels;

namespace Game.Services
{

    /// <summary>
    /// Helps Manage the ItemModel Services
    /// </summary>
    public static class ItemService
    {
        // Return the Default Image URI for the Local Image for an ItemModel.
        public static string DefaultImageURI = "item.png";

        #region ServerCalls
        public static async Task<List<ItemModel>> GetItemsFromServerGetAsync(int parameter = 100)
        {
            // parameter is the ItemModel group to request.  1, 2, 3, 100

            // Needs to get items from the server
            // Parse them
            // Then update the database
            // Only update fields on existing items
            // Insert new items
            // Then notify the viewmodel of the change

            // Needs to get items from the server

            var URLComponent = "GetItemList/";

            var DataResult = await HttpClientService.Instance.GetJsonGetAsync(WebGlobalsModel.WebSiteAPIURL + URLComponent + parameter);

            // Parse them
            var myList = ItemModelJsonHelper.ParseJson(DataResult);
            if (myList == null)
            {
                // Error, no results
                return null;
            }

            // Then update the database

            // Use a foreach on myList
            foreach (var ItemModel in myList)
            {
                // Call to the View Model (that is where the datasource is set, and have it then save
                await ItemIndexViewModel.Instance.CreateUpdateAsync(ItemModel);
            }

            // When foreach is done, call to the items view model to set needs refresh to true, so it can refetch the list...
            ItemIndexViewModel.Instance.SetNeedsRefresh(true);

            return myList;
        }

        // Asks the server for items based on paramaters
        // Number is th enumber of items to return
        // Level is the Value max for the items
        // Random is to have the value random between 1 and the Level
        // Attribute is a filter to return only items for that attribute, else unknown is used for any
        // Location is a filter to return only items for that location, else unknown is used for any
        public static async Task<List<ItemModel>> GetItemsFromServerPostAsync(int number, int level, AttributeEnum attribute, ItemLocationEnum location, int category, bool random, bool updateDataBase)
        {
            // Needs to get items from the server
            // Parse them
            // Then update the database
            // Only update fields on existing items
            // Insert new items
            // Then notify the viewmodel of the change

            // Needs to get items from the server

            var URLComponent = "GetItemListPost";

            var dict = new Dictionary<string, string>
            {
                { "Number", number.ToString()},
                { "Level", level.ToString()},
                { "Attribute", ((int)attribute).ToString()},
                { "Location", ((int)location).ToString()},
                { "Random", random.ToString()},
                { "Category", category.ToString()},
            };

            // Convert parameters to a key value pairs to a json object
            JObject finalContentJson = (JObject)JToken.FromObject(dict);

            // Make a call to the helper.  URL and Parameters
            var DataResult = await HttpClientService.Instance.GetJsonPostAsync(WebGlobalsModel.WebSiteAPIURL + URLComponent, finalContentJson);

            // Parse them
            var myList = ItemModelJsonHelper.ParseJson(DataResult);
            if (myList == null)
            {
                // Error, no results, return empty list.
                return new List<ItemModel>();
            }

            // Then update the database

            // Use a foreach on myList
            if (updateDataBase)
            {
                foreach (var ItemModel in myList)
                {
                    // Call to the View Model (that is where the datasource is set, and have it then save
                    await ItemIndexViewModel.Instance.CreateUpdateAsync(ItemModel);
                }

                // When foreach is done, call to the items view model to set needs refresh to true, so it can refetch the list...
                ItemIndexViewModel.Instance.SetNeedsRefresh(true);
            }

            return myList;
        }
        #endregion ServerCalls
    }
}