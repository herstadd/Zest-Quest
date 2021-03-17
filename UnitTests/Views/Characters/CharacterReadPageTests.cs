using NUnit.Framework;
using System.Linq;

using Game;
using Game.Views;
using Game.ViewModels;
using Game.Models;

using Xamarin.Forms;
using Xamarin.Forms.Mocks;
using System.Threading.Tasks;

namespace UnitTests.Views
{
    [TestFixture]
    public class CharacterReadPageTests : CharacterReadPage
    {
        App app;
        CharacterReadPage page;

        public CharacterReadPageTests() : base(true) { }

        [SetUp]
        public void Setup()
        {
            // Initilize Xamarin Forms
            MockForms.Init();

            //This is your App.xaml and App.xaml.cs, which can have resources, etc.
            app = new App();
            Application.Current = app;

            page = new CharacterReadPage(new GenericViewModel<CharacterModel>(new CharacterModel()));
        }

        [TearDown]
        public void TearDown()
        {
            Application.Current = null;
        }

        [Test]
        public void CharacterReadPage_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = page;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void CharacterReadPage_Update_Clicked_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.Update_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterReadPage_Delete_Clicked_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.Delete_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterReadPage_OnBackButtonPressed_Valid_Should_Pass()
        {
            // Arrange

            // Act
            OnBackButtonPressed();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterReadPage_CallProperImages_Location_Unknown_Valid_Should_Pass()
        {
            // Arrange

            // Act
            var result = CallProperImages(page.ViewModel, "Unknown");

            // Reset

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void CharacterReadPage_CallProperImages_Location_Head_Valid_Should_Pass()
        {
            // Arrange
            var NewCharacterModel = new CharacterModel();
            NewCharacterModel.Head = "ChefHat";
            GenericViewModel<CharacterModel> data = new GenericViewModel<CharacterModel>(NewCharacterModel);
            CharacterReadPage ReadPage = new CharacterReadPage(data);

            // Act
            var result = ReadPage.CallProperImages(data, "Head");

            // Reset

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void CharacterReadPage_CallProperImages_Location_Necklass_Valid_Should_Pass()
        {
            // Arrange
            var NewCharacterModel = new CharacterModel();
            NewCharacterModel.Necklass = "ButcherKnifeNecklace";
            GenericViewModel<CharacterModel> data = new GenericViewModel<CharacterModel>(NewCharacterModel);
            CharacterReadPage ReadPage = new CharacterReadPage(data);

            // Act
            var result = ReadPage.CallProperImages(data, "Necklass");

            // Reset

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void CharacterReadPage_CallProperImages_Location_PrimaryHand_Valid_Should_Pass()
        {
            // Arrange
            var NewCharacterModel = new CharacterModel();
            NewCharacterModel.PrimaryHand = "Refrigerator";
            GenericViewModel<CharacterModel> data = new GenericViewModel<CharacterModel>(NewCharacterModel);
            CharacterReadPage ReadPage = new CharacterReadPage(data);

            // Act
            var result = ReadPage.CallProperImages(data, "PrimaryHand");

            // Reset

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void CharacterReadPage_CallProperImages_Location_OffHand_Valid_Should_Pass()
        {
            // Arrange
            var NewCharacterModel = new CharacterModel();
            NewCharacterModel.OffHand = "CuttingBoard";
            GenericViewModel<CharacterModel> data = new GenericViewModel<CharacterModel>(NewCharacterModel);
            CharacterReadPage ReadPage = new CharacterReadPage(data);

            // Act
            var result = ReadPage.CallProperImages(data, "OffHand");

            // Reset

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void CharacterReadPage_CallProperImages_Location_RightFinger_Valid_Should_Pass()
        {
            // Arrange
            var NewCharacterModel = new CharacterModel();
            NewCharacterModel.RightFinger = "ScreamRing";
            GenericViewModel<CharacterModel> data = new GenericViewModel<CharacterModel>(NewCharacterModel);
            CharacterReadPage ReadPage = new CharacterReadPage(data);

            // Act
            var result = ReadPage.CallProperImages(data, "RightFinger");

            // Reset

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void CharacterReadPage_CallProperImages_Location_LeftFinger_Valid_Should_Pass()
        {
            // Arrange
            var NewCharacterModel = new CharacterModel();
            NewCharacterModel.LeftFinger = "RingPop";
            GenericViewModel<CharacterModel> data = new GenericViewModel<CharacterModel>(NewCharacterModel);
            CharacterReadPage ReadPage = new CharacterReadPage(data);

            // Act
            var result = ReadPage.CallProperImages(data, "LeftFinger");

            // Reset

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void CharacterReadPage_CallProperImages_Location_Feet_Valid_Should_Pass()
        {
            // Arrange
            var NewCharacterModel = new CharacterModel();
            NewCharacterModel.Feet = "FlipFlop";
            GenericViewModel<CharacterModel> data = new GenericViewModel<CharacterModel>(NewCharacterModel);
            CharacterReadPage ReadPage = new CharacterReadPage(data);

            // Act
            var result = ReadPage.CallProperImages(data, "Feet");

            // Reset

            // Assert
            Assert.IsTrue(result);
        }
    }
}