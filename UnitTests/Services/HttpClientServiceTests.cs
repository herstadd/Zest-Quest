using System.Threading;
using System.Net;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Collections.Generic;

using NUnit.Framework;

using Newtonsoft.Json.Linq;

using Game.Models;
using Game.Services;
using Game.Helpers;


namespace UnitTests.Services
{
    [TestFixture]
    public class HttpClientServiceTests
    {
        HttpClientService Service;

        [SetUp]
        public void Setup()
        {
            Service = HttpClientService.Instance;
        }

        [Test]
        public void HttpClientService_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = Service;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void HttpClientService_SetHttpClient_Default_Should_Pass()
        {
            // Arrange

            HttpClient httpClient = new HttpClient();

            // Act
            var result = Service.SetHttpClient(httpClient);

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public async Task HttpClientService_GetJsonGetAsync_InValid_Null_Should_Fail()
        {
            // Arrange
            var RestUrl = "";

            // Act
            var result = await Service.GetJsonGetAsync(RestUrl);

            // Reset

            // Assert
            Assert.AreEqual(null,result);
        }

        [Test]
        public async Task HttpClientService_GetJsonGetAsync_InValid_Bogus_Should_Fail()
        {
            // Arrange
            var RestUrl = "bogus";

            // Act
            var result = await Service.GetJsonGetAsync(RestUrl);

            // Reset

            // Assert
            Assert.AreEqual(null, result);
        }

        [Test]
        public async Task HttpClientService_GetJsonGetAsync_Valid_Moq_Should_Pass()
        {
            // Arrange

            var MockHttpClient = new HttpClient(new MockHttpMessageHandler());

            var RestUrl = "http://some.fake.url";

            var OldHttpClient = Service.GetHttpClient();
            Service.SetHttpClient(MockHttpClient);

            ResponseMessage.SetResponseMessageStringContent(ResponseMessage.GetStringContent);

            // Act
            var result = await Service.GetJsonGetAsync(RestUrl);

            // Parse them into ItemModels
            var resultList = ItemModelJsonHelper.ParseJson(result);

            // Reset
            Service.SetHttpClient(OldHttpClient);
            ResponseMessage.ResetResponseMessageStringContent();

            // Assert
            Assert.AreEqual(2, resultList.Count());
        }

        [Test]
        public async Task HttpClientService_GetJsonGetAsync_InValid_Moq_Bad_Response_Should_Fail()
        {
            // Arrange

            var MockHttpClient = new HttpClient(new MockHttpMessageHandler());

            var RestUrl = "http://some.fake.url";

            var OldHttpClient = Service.GetHttpClient();
            Service.SetHttpClient(MockHttpClient);

            ResponseMessage.SetResponseMessageStringContent(ResponseMessage.NullStringContent);
            ResponseMessage.SetHttpStatusCode(ResponseMessage.HttpStatusCodeBadRequest);

            // Act
            var result = await Service.GetJsonGetAsync(RestUrl);


            // Parse them
            var resultList = ItemModelJsonHelper.ParseJson(result);

            // Reset
            Service.SetHttpClient(OldHttpClient);
            ResponseMessage.ResetResponseMessageStringContent();
            ResponseMessage.ResetHttpStatusCode();

            // Assert
            Assert.AreEqual(null, resultList);
        }

        // mike
        [Test]
        public async Task HttpClientService_GetJsonPostAsync_InValid_Null_Should_Fail()
        {
            // Arrange
            var RestUrl = "";

            int number = 0;
            int level = 0;
            AttributeEnum attribute = AttributeEnum.Attack;
            ItemLocationEnum location = ItemLocationEnum.Feet;
            int category = 0;
            bool random = false;

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

            // Act
            var result = await Service.GetJsonPostAsync(RestUrl, finalContentJson);

            // Reset

            // Assert
            Assert.AreEqual(null, result);
        }

        [Test]
        public async Task HttpClientService_GetJsonPostAsync_InValid_Bogus_Should_Fail()
        {
            // Arrange
            var RestUrl = "bogus";

            int number = 0;
            int level = 0;
            AttributeEnum attribute = AttributeEnum.Attack;
            ItemLocationEnum location = ItemLocationEnum.Feet;
            int category = 0;
            bool random = false;

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

            // Act
            var result = await Service.GetJsonPostAsync(RestUrl, finalContentJson);

            // Reset

            // Assert
            Assert.AreEqual(null, result);
        }

        [Test]
        public async Task HttpClientService_GetJsonPostAsync_Valid_Moq_Should_Pass()
        {
            // Arrange

            var MockHttpClient = new HttpClient(new MockHttpMessageHandler());

            var RestUrl = "http://some.fake.url";

            var OldHttpClient = Service.GetHttpClient();
            Service.SetHttpClient(MockHttpClient);

            ResponseMessage.SetResponseMessageStringContent(ResponseMessage.GetStringContent);

            int number = 0;
            int level = 0;
            AttributeEnum attribute = AttributeEnum.Attack;
            ItemLocationEnum location = ItemLocationEnum.Feet;
            int category = 0;
            bool random = false;

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

            // Act
            var result = await Service.GetJsonPostAsync(RestUrl, finalContentJson);

            // Parse them
            var resultList = ItemModelJsonHelper.ParseJson(result);

            // Reset
            Service.SetHttpClient(OldHttpClient);
            ResponseMessage.ResetResponseMessageStringContent();

            // Assert
            Assert.AreEqual(2, resultList.Count());
        }

        [Test]
        public async Task HttpClientService_GetJsonPostAsync_InValid_Moq_Bad_Response_Should_Fail()
        {
            // Arrange

            var MockHttpClient = new HttpClient(new MockHttpMessageHandler());

            var RestUrl = "http://some.fake.url";

            var OldHttpClient = Service.GetHttpClient();
            Service.SetHttpClient(MockHttpClient);

            ResponseMessage.SetResponseMessageStringContent(ResponseMessage.NullStringContent);
            ResponseMessage.SetHttpStatusCode(ResponseMessage.HttpStatusCodeBadRequest);

            int number = 0;
            int level = 0;
            AttributeEnum attribute = AttributeEnum.Attack;
            ItemLocationEnum location = ItemLocationEnum.Feet;
            int category = 0;
            bool random = false;

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

            // Act
            var result = await Service.GetJsonPostAsync(RestUrl, finalContentJson);

            // Parse them
            var resultList = ItemModelJsonHelper.ParseJson(result);

            // Reset
            Service.SetHttpClient(OldHttpClient);
            ResponseMessage.ResetResponseMessageStringContent();
            ResponseMessage.ResetHttpStatusCode();

            // Assert
            Assert.AreEqual(null, resultList);
        }


        public static class ResponseMessage
        {

            public static StringContent ResponseMessageStringContent = new StringContent("Content as string");

            public static StringContent DefaultStringContent = new StringContent("Content as string");

            public static StringContent GetStringContent = new StringContent(@"{'msg':'Ok','errorCode':0,'version':'1.1.1.1','data':{'ItemList':[{'Value':10,'Attribute':14,'Location':20,'Name':'Strong Shield','Guid':'3a138793-7411-7c60-6b03-aee9423d3684','Description':'Enough to hide behind','ImageURI':'http://www.clipartbest.com/cliparts/4T9/LaR/4T9LaReTE.png','Range':0,'Damage':0,'Count':-1,'IsConsumable':false,'Category':10},{'Value':10,'Attribute':14,'Location':20,'Name':'Bow','Guid':'2e0ac680-1913-0854-de5e-294bb0e4d23a','Description':'Fast shooting bow','ImageURI':'http://cliparts.co/cliparts/di4/oAB/di4oABdbT.png','Range':10,'Damage':6,'Count':-1,'IsConsumable':false,'Category':10}]}}");
            public static StringContent PostStringContent = new StringContent(@"{'msg':'Ok','errorCode': 0,'version': '1.1.1.1','data':{'ItemList':[{'Value':10,'Attribute':14,'Location':20,'Name':'Strong Shield','Guid':'3a138793-7411-7c60-6b03-aee9423d3684','Description':'Enough to hide behind','ImageURI':'http://www.clipartbest.com/cliparts/4T9/LaR/4T9LaReTE.png','Range':0,'Damage':0,'Count':-1,'IsConsumable':false,'Category':10},{'Value':10,'Attribute':14,'Location':20,'Name':'Bow','Guid':'2e0ac680-1913-0854-de5e-294bb0e4d23a','Description':'Fast shooting bow','ImageURI':'http://cliparts.co/cliparts/di4/oAB/di4oABdbT.png','Range':10,'Damage':6,'Count':-1,'IsConsumable':false,'Category':10},{'Value':10,'Attribute':12,'Location':30,'Name':'Blue Ring of Power','Guid':'c3f4cece-b1d8-bb02-38c0-32c7a4e87160','Description':'The one to control them all','ImageURI':'http://www.clker.com/cliparts/A/E/4/t/L/1/diamond-ring-teal-hi.png','Range':0,'Damage':0,'Count':-1,'IsConsumable':false,'Category':10},{'Value':10,'Attribute':10,'Location':10,'Name':'Bunny Hat','Guid':'0e9f41b4-4be2-adc3-d39d-1c70ae814913','Description':'Pink hat with fluffy ears','ImageURI':'http://www.clipartbest.com/cliparts/yik/e9k/yike9kMyT.png','Range':0,'Damage':0,'Count':-1,'IsConsumable':false,'Category':10}]}}");
            public static StringContent NullStringContent = null;

            public static void SetResponseMessageStringContent(StringContent content)
            {
                ResponseMessageStringContent = content;
            }

            public static void ResetResponseMessageStringContent()
            {
                ResponseMessageStringContent = DefaultStringContent;
            }


            public static HttpStatusCode HttpStatusCode = HttpStatusCode.OK;
            public static HttpStatusCode HttpStatusCodeSuccess = HttpStatusCode.OK;
            public static HttpStatusCode HttpStatusCodeBadRequest = HttpStatusCode.BadRequest;
            public static HttpStatusCode HttpStatusCodeNotFound = HttpStatusCode.NotFound;

            public static void SetHttpStatusCode(HttpStatusCode code)
            {
                HttpStatusCode = code;
            }

            public static void ResetHttpStatusCode()
            {
                HttpStatusCode = HttpStatusCodeSuccess;
            }
        }

        public class MockHttpMessageHandler : HttpMessageHandler
        {

            protected override async Task<HttpResponseMessage> SendAsync(
                HttpRequestMessage request,
                CancellationToken cancellationToken)
            {
                var responseMessage = new HttpResponseMessage(ResponseMessage.HttpStatusCode)
                {
                    Content = ResponseMessage.ResponseMessageStringContent
                };

                return await Task.FromResult(responseMessage);
            }
        }

        readonly string ExampleJson = @"
            {
                'msg':'Ok',
                'errorCode':0,
                'version':'1.1.1.1',
                'data':
                {
                    'ItemList':
                    [
                        {'Value':10,'Attribute':14,'Location':20,'Name':'Strong Shield','Guid':'3a138793-7411-7c60-6b03-aee9423d3684','Description':'Enough to hide behind','ImageURI':'http://www.clipartbest.com/cliparts/4T9/LaR/4T9LaReTE.png','Range':0,'Damage':0,'Count':-1,'IsConsumable':false,'Category':10},
                        {'Value':10,'Attribute':14,'Location':20,'Name':'Bow','Guid':'2e0ac680-1913-0854-de5e-294bb0e4d23a','Description':'Fast shooting bow','ImageURI':'http://cliparts.co/cliparts/di4/oAB/di4oABdbT.png','Range':10,'Damage':6,'Count':-1,'IsConsumable':false,'Category':10},
                        {'Value':10,'Attribute':12,'Location':30,'Name':'Blue Ring of Power','Guid':'c3f4cece-b1d8-bb02-38c0-32c7a4e87160','Description':'The one to control them all','ImageURI':'http://www.clker.com/cliparts/A/E/4/t/L/1/diamond-ring-teal-hi.png','Range':0,'Damage':0,'Count':-1,'IsConsumable':false,'Category':10},
                        {'Value':10,'Attribute':10,'Location':10,'Name':'Bunny Hat','Guid':'0e9f41b4-4be2-adc3-d39d-1c70ae814913','Description':'Pink hat with fluffy ears','ImageURI':'http://www.clipartbest.com/cliparts/yik/e9k/yike9kMyT.png','Range':0,'Damage':0,'Count':-1,'IsConsumable':false,'Category':10}
                    ]
                }
            }";
        readonly string ExampleJsonNoVersion = @"
            {
                'msg':'Ok',
                'errorCode':0,
                'version':,
                'data':
                {
                    'ItemList':
                        [
                            {'Value':10,'Attribute':14,'Location':20,'Name':'Strong Shield','Guid':'3a138793-7411-7c60-6b03-aee9423d3684','Description':'Enough to hide behind','ImageURI':'http://www.clipartbest.com/cliparts/4T9/LaR/4T9LaReTE.png','Range':0,'Damage':0,'Count':-1,'IsConsumable':false,'Category':10},
                            {'Value':10,'Attribute':14,'Location':20,'Name':'Bow','Guid':'2e0ac680-1913-0854-de5e-294bb0e4d23a','Description':'Fast shooting bow','ImageURI':'http://cliparts.co/cliparts/di4/oAB/di4oABdbT.png','Range':10,'Damage':6,'Count':-1,'IsConsumable':false,'Category':10},
                            {'Value':10,'Attribute':12,'Location':30,'Name':'Blue Ring of Power','Guid':'c3f4cece-b1d8-bb02-38c0-32c7a4e87160','Description':'The one to control them all','ImageURI':'http://www.clker.com/cliparts/A/E/4/t/L/1/diamond-ring-teal-hi.png','Range':0,'Damage':0,'Count':-1,'IsConsumable':false,'Category':10},
                            {'Value':10,'Attribute':10,'Location':10,'Name':'Bunny Hat','Guid':'0e9f41b4-4be2-adc3-d39d-1c70ae814913','Description':'Pink hat with fluffy ears','ImageURI':'http://www.clipartbest.com/cliparts/yik/e9k/yike9kMyT.png','Range':0,'Damage':0,'Count':-1,'IsConsumable':false,'Category':10}
                        ]
                }
            }";
        readonly string ExampleJsonMessageError = @"
            {
                'msg':'Ok',
                'errorCode':1,
                'version':'1.1.1.1',
                'data':{}
            }";
        readonly string ExampleJsonBadJson = @"Bougus";

        [Test]
        public async Task HttpClientService_ParseJsonResult_Valid_Should_Pass()
        {
            // Arrange

            var messageContent = ExampleJson;

            var responseMessage = new HttpResponseMessage(ResponseMessage.HttpStatusCode)
            {
                Content = new StringContent(messageContent)
            };

            // Act
            var result = await Service.JsonParseResult(responseMessage);

            // Parse them into ItemModels
            var resultList = ItemModelJsonHelper.ParseJson(result);

            // Reset

            // Assert
            Assert.AreEqual(4, resultList.Count());
        }

        [Test]
        public async Task HttpClientService_ParseJsonResult_InValid_ErrorCode_Should_Fail()
        {
            // Arrange

            var messageContent = ExampleJsonMessageError;

            var responseMessage = new HttpResponseMessage(ResponseMessage.HttpStatusCode)
            {
                Content = new StringContent(messageContent)
            };

            // Act
            var result = await Service.JsonParseResult(responseMessage);

            // Reset

            // Assert
            Assert.AreEqual(true, result.Contains("ServerError"));
            Assert.AreEqual(true, result.Contains("MessageList"));
            Assert.AreEqual(true, result.Contains("Error"));
        }

        [Test]
        public async Task HttpClientService_ParseJsonResult_InValid_Bad_Json_Should_Fail()
        {
            // Arrange

            var messageContent = ExampleJsonBadJson;

            var responseMessage = new HttpResponseMessage(ResponseMessage.HttpStatusCode)
            {
                Content = new StringContent(messageContent)
            };

            // Act
            var result = await Service.JsonParseResult(responseMessage);

            // Reset

            // Assert
            Assert.AreEqual(null, result);
        }

        [Test]
        public async Task HttpClientService_ParseJsonResult_InValid_Version_Missing_Should_Fail()
        {
            // Arrange

            var messageContent = ExampleJsonNoVersion;

            var responseMessage = new HttpResponseMessage(ResponseMessage.HttpStatusCode)
            {
                Content = new StringContent(messageContent)
            };

            // Act
            var result = await Service.JsonParseResult(responseMessage);

            // Reset

            // Assert
            Assert.AreEqual(null, result);
        }

        [Test]
        public async Task HttpClientService_ParseJsonResult_InValid_ErrorCode_1_Should_Fail()
        {
            // Arrange

            var messageContent = ExampleJsonMessageError;

            var responseMessage = new HttpResponseMessage(ResponseMessage.HttpStatusCode)
            {
                Content = new StringContent(messageContent)
            };

            // Act
            var result = await Service.JsonParseResult(responseMessage);

            // Reset

            // Assert
            Assert.AreEqual(true, result.Contains("ServerError"));
            Assert.AreEqual(true, result.Contains("MessageList"));
            Assert.AreEqual(true, result.Contains("Error"));
        }

        [Test]
        public async Task HttpClientService_ParseJsonResult_InValid_Responce_Null_Should_Fail()
        {
            // Arrange

            // Act
            var result = await Service.JsonParseResult(null);

            // Reset

            // Assert
            Assert.AreEqual(null, result);
        }

        [Test]
        public async Task HttpClientService_ParseJsonResult_InValid_Responce_Content_Null_Should_Fail()
        {
            // Arrange

            var responseMessage = new HttpResponseMessage(ResponseMessage.HttpStatusCode)
            {
                Content = null
            };

            // Act
            var result = await Service.JsonParseResult(responseMessage);

            // Reset

            // Assert
            Assert.AreEqual(null, result);
        }
    }
}