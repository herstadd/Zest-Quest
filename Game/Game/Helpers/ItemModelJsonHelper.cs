using System;
using System.Collections.Generic;
using System.Diagnostics;

using Game.Models;

using Newtonsoft.Json.Linq;

namespace Game.Helpers
{
    /// <summary>
    /// Helps Parse the Json from the Server into Items
    /// </summary>
    public static class ItemModelJsonHelper
    {

        /// <summary>
        /// ParseJson takes the raw stirng and parses it into valid ItemModel
        /// 
        /// The returned data will be a list of items.  Need to pull that list out
        /// </summary>
        /// <param name="myJsonData"></param>
        /// <returns></returns>
        public static List<ItemModel> ParseJson(string myJsonData)
        {
            var myData = new List<ItemModel>();

            try
            {
                JObject json;
                json = JObject.Parse(myJsonData);

                // Data is a List of Items, so need to pull them out one by one...

                var myTempList = json["ItemList"].ToObject<List<JObject>>();

                foreach (var myItem in myTempList)
                {
                    var myTempObject = ConvertFromJson(myItem);
                    if (myTempObject != null)
                    {
                        myData.Add(myTempObject);
                    }
                }

                return myData;
            }
            catch (Exception Ex)
            {
                Debug.WriteLine(Ex.ToString());
                return null;
            }
        }

        /// <summary>
        /// Converts a single object that is a json string into a single ItemModel
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static ItemModel ConvertFromJson(JObject json)
        {
            var myData = new ItemModel();

            myData.Name = JsonHelper.GetJsonString(json, "Name");
            myData.Guid = JsonHelper.GetJsonString(json, "Guid");
            myData.Id = myData.Guid;    // Set to be the same as Guid, does not come down from server, but needed for DB

            myData.Description = JsonHelper.GetJsonString(json, "Description");
            myData.ImageURI = JsonHelper.GetJsonString(json, "ImageURI");

            myData.Value = JsonHelper.GetJsonInteger(json, "Value");
            myData.Range = JsonHelper.GetJsonInteger(json, "Range");
            myData.Damage = JsonHelper.GetJsonInteger(json, "Damage");

            //myData.Category = JsonHelper.GetJsonInteger(json, "Category");

            myData.Location = (ItemLocationEnum)JsonHelper.GetJsonInteger(json, "Location");
            myData.Attribute = (AttributeEnum)JsonHelper.GetJsonInteger(json, "Attribute");

            return myData;
        }
    }
}
