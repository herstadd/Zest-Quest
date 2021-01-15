using System;
using NUnit.Framework;

using Newtonsoft;
using Newtonsoft.Json.Linq;

using Game.Helpers;
using System.Linq;
using Game.Models;

namespace UnitTests.Helpers
{
    [TestFixture]
    public class ItemModelJsonHelperTests
    {
        readonly string ExampleJson = @"
            {
                'ItemList':
                [
                    {'Value':10,'Attribute':14,'Location':20,'Name':'Strong Shield','Guid':'3a138793-7411-7c60-6b03-aee9423d3684','Description':'Enough to hide behind','ImageURI':'http://www.clipartbest.com/cliparts/4T9/LaR/4T9LaReTE.png','Range':0,'Damage':0,'Count':-1,'IsConsumable':false,'Category':10},
                    {'Value':10,'Attribute':14,'Location':20,'Name':'Bow','Guid':'2e0ac680-1913-0854-de5e-294bb0e4d23a','Description':'Fast shooting bow','ImageURI':'http://cliparts.co/cliparts/di4/oAB/di4oABdbT.png','Range':10,'Damage':6,'Count':-1,'IsConsumable':false,'Category':10},
                    {'Value':10,'Attribute':12,'Location':30,'Name':'Blue Ring of Power','Guid':'c3f4cece-b1d8-bb02-38c0-32c7a4e87160','Description':'The one to control them all','ImageURI':'http://www.clker.com/cliparts/A/E/4/t/L/1/diamond-ring-teal-hi.png','Range':0,'Damage':0,'Count':-1,'IsConsumable':false,'Category':10},
                    {'Value':10,'Attribute':10,'Location':10,'Name':'Bunny Hat','Guid':'0e9f41b4-4be2-adc3-d39d-1c70ae814913','Description':'Pink hat with fluffy ears','ImageURI':'http://www.clipartbest.com/cliparts/yik/e9k/yike9kMyT.png','Range':0,'Damage':0,'Count':-1,'IsConsumable':false,'Category':10}
                ]
            }";
        readonly string ExampleJsonItemListEmpty = @"
            {
                'msg':'Ok',
                'errorCode':1,
                'version':'1.1.1.1',
                'data':
                {
                    'ItemList':
                        [
                            {}
                        ]
                }
            }";

        [Test]
        public void ItemModelJsonHelper_ParseJson_Valid_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemModelJsonHelper.ParseJson(ExampleJson);

            // Reset

            // Assert
            Assert.AreEqual(4, result.Count());
        }

        [Test]
        public void ItemModelJsonHelper_ParseJson_InValid_Field_Null_Should_Fail()
        {
            // Arrange

            // Act
            var result = ItemModelJsonHelper.ParseJson(null);

            // Reset

            // Assert
            Assert.AreEqual(null, result);
        }

        [Test]
        public void ItemModelJsonHelper_ParseJson_InValid_Field_Bogus_Should_Fail()
        {
            // Arrange

            // Act
            var result = ItemModelJsonHelper.ParseJson("bogus");

            // Reset

            // Assert
            Assert.AreEqual(null, result);
        }

        [Test]
        public void ItemModelJsonHelper_ParseJson_InValid_ItemList_Empty_Should_Fail()
        {
            // Arrange

            // Act
            var result = ItemModelJsonHelper.ParseJson(ExampleJsonItemListEmpty);

            // Reset

            // Assert
            Assert.AreEqual(null, result);
        }

        readonly String ItemJson = @"{
                            'Value':10,
                            'Attribute':14,
                            'Location':22,
                            'Name':'Strong Shield',
                            'Guid':'3a138793-7411-7c60-6b03-aee9423d3684',
                            'Description':'Enough to hide behind',
                            'ImageURI':'http://www.clipartbest.com/cliparts/4T9/LaR/4T9LaReTE.png',
                            'Range':0,
                            'Damage':0,
                            'Count':-1,
                            'IsConsumable':false,
                            'Category':10}";

        [Test]
        public void ItemModelJsonHelper_ConvertFromJson_Valid_Should_Pass()
        {
            // Arrange

            JObject json = JObject.Parse(ItemJson);

            // Act
            var result = ItemModelJsonHelper.ConvertFromJson(json);

            // Reset

            // Assert
            Assert.AreEqual(10, result.Value);
            Assert.AreEqual(AttributeEnum.Attack, result.Attribute);
            Assert.AreEqual(ItemLocationEnum.OffHand, result.Location);
            Assert.AreEqual("Strong Shield", result.Name);
            Assert.AreEqual("3a138793-7411-7c60-6b03-aee9423d3684", result.Guid);
            Assert.AreEqual("Enough to hide behind", result.Description);
            Assert.AreEqual("http://www.clipartbest.com/cliparts/4T9/LaR/4T9LaReTE.png", result.ImageURI);
            Assert.AreEqual(0, result.Range);
            Assert.AreEqual(0, result.Damage);
            //Assert.AreEqual(-1, result.Count);
            //Assert.AreEqual(false, result.IsConsumable);
            //Assert.AreEqual(10, result.Category);
        }

        [Test]
        public void ItemModelJsonHelper_ConvertFromJson_InValid_Null_Should_Fail()
        {
            // Passing in null will get defaults for everything

            // Arrange

            // Act
            var result = ItemModelJsonHelper.ConvertFromJson(null); 
            
            // Reset

            // Assert
            Assert.IsNotNull(result);
        }
    }
}