using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Game.ViewModels;
using Game.Models;
using System.Collections.ObjectModel;

namespace UnitTests.ViewModels
{
    [TestFixture]
    public class BaseViewModelTests : BaseViewModel<ItemModel>
    {
        BaseViewModel<ItemModel> ViewModel;

        [SetUp]
        public void Setup()
        {
            ViewModel = new BaseViewModel<ItemModel>();
        }

        [Test]
        public void BaseViewModel_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = new BaseViewModel<ItemModel>();

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void BaseViewModel_Get_Title_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = new BaseViewModel<ItemModel>().Title;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void BaseViewModel_SetProperty_Changed_Should_Pass()
        {
            // Arrange

            // Act
            var result = new BaseViewModel<ItemModel>();

            var isBusy = false;
            SetProperty<bool>(ref isBusy, true);

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void BaseViewModel_SetProperty_Same_Should_Skip()
        {
            // Arrange

            // Act
            var result = new BaseViewModel<ItemModel>();

            var isBusy = false;
            SetProperty<bool>(ref isBusy, false);

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void BaseViewModel_SetProperty_OnChange_Should_Skip()
        {
            // Arrange

            var testName = new TestName();

            Action showMethod = testName.Display;

            var isBusy = true;

            // Act

            SetProperty<bool>(ref isBusy, false, "bogus", showMethod);

            // Reset

            // Assert
            Assert.IsTrue(true);
        }

        [Test]
        public void BaseViewModel_SetProperty_OnChange_Null_Should_Skip()
        {
            // Arrange

            var testName = new TestName();

            Action showMethod = null;

            var isBusy = true;

            // Act

            SetProperty<bool>(ref isBusy, false, "bogus", showMethod);

            // Reset

            // Assert
            Assert.IsTrue(true);
        }

        /// <summary>
        /// Following TestName class is used for the Action in the SetProperty test
        /// </summary>
        public class TestName
        {
            public TestName()
            {
            }

            public void Display()
            {
            }
        }

        [Test]
        public void BaseViewModel_OnPropertyChanged_Default_Should_Pass()
        {
            // Arrange

            // Act
            OnPropertyChanged();
            
            // Reset

            // Assert
            Assert.IsTrue(true);
        }

        [Test]
        public void BaseViewModel_OnPropertyChanged_Default_Name_Should_Pass()
        {
            // Arrange

            // Act
            OnPropertyChanged("Name");

            // Reset

            // Assert
            Assert.IsTrue(true);
        }

        [Test]
        public void BaseViewModel_SortDataset_Default_Should_Pass()
        {
            // Arrange
            var dataList = new List<ItemModel>();
            dataList.Add(new ItemModel { Name = "z" });
            dataList.Add(new ItemModel { Name = "m" });
            dataList.Add(new ItemModel { Name = "a" });

            // Act
            var result = ViewModel.SortDataset(dataList);

            // Reset

            // Assert
            Assert.AreEqual("z", result[0].Name);
            Assert.AreEqual("m", result[1].Name);
            Assert.AreEqual("a", result[2].Name);
        }

        [Test]
        public void BaseViewModel_SetNeedsRefresh_Valid_True_Should_Pass()
        {
            // Arrange
            var originalState = ViewModel.GetNeedsRefresh();

            // Act
            ViewModel.SetNeedsRefresh(true);
            var newState = ViewModel.GetNeedsRefresh();

            // Reset

            // Turn it back to the original state
            ViewModel.SetNeedsRefresh(originalState);

            // Assert
            Assert.AreEqual(true, newState);
        }

        [Test]
        public void BaseViewModel_NeedsRefresh_Valid_True_Should_Pass()
        {
            // Arrange
            var originalState = ViewModel.GetNeedsRefresh();

            ViewModel.SetNeedsRefresh(true);

            // Act
            var result = ViewModel.NeedsRefresh();

            // Reset

            // Turn it back to the original state
            ViewModel.SetNeedsRefresh(originalState);

            // Assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public void BaseViewModel_NeedsRefresh_Valid_False_Should_Pass()
        {
            // Arrange
            var originalState = ViewModel.GetNeedsRefresh();

            ViewModel.SetNeedsRefresh(false);

            // Act
            var result = ViewModel.NeedsRefresh();

            // Reset

            // Turn it back to the original state
            ViewModel.SetNeedsRefresh(originalState);

            // Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void BaseViewModel_GetDefaultData_Valid_Should_Pass()
        {
            // Arrange

            // Act
            var result = ViewModel.GetDefaultData();

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public async Task BaseViewModel_CheckIfItemExists_Default_Should_Pass()
        {
            // Arrange

            // Add items into the list Z ordered
            var dataTest = new ItemModel { Name = "test" };
            ViewModel.Dataset = new ObservableCollection<ItemModel>();

            await ViewModel.SetDataSource(0);

            await ViewModel.CreateAsync(dataTest);

            await ViewModel.CreateAsync(new ItemModel { Name = "z" });
            await ViewModel.CreateAsync(new ItemModel { Name = "m" });
            await ViewModel.CreateAsync(new ItemModel { Name = "a" });

            // Act
            var result = ViewModel.CheckIfExists(dataTest);

            // Reset

            // Assert
            Assert.AreEqual(dataTest.Id, result.Id);
        }
    }
}