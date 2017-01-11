using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace UnitTestProductService
{
    public class ProductService
    {
        private IProduct[] _product;

        public ProductService(IProduct[] products)
        {
            this._product = products;
        }

        public List<int> CalculatePropertySum(string nameOfProperty, int numberPerGroup)
        {
            // TODO:計算每X一組的數字總和

            return new List<int>();
        }
    }

    public interface IProduct
    {
        long ID { get; set; }

        int Cost { get; set; }

        int Revenue { get; set; }

        int SellPrice { get; set; }
    }

    public class Product : IProduct
    {
        public long ID { get; set; }

        public int Cost { get; set; }

        public int Revenue { get; set; }

        public int SellPrice { get; set; }

        public Product()
        {

        }

        public Product(long ID, int Cost, int Revenue, int SellPrice)
        {
            this.ID = ID;
            this.Cost = Cost;
            this.Revenue = Revenue;
            this.SellPrice = SellPrice;
        }
    }

    [TestClass]
    public class UnitTestProductService
    {
        [TestMethod]
        public void 驗證COST屬性三筆一組的總和()
        {
            //Arrange 
            var products = SampleDataGet();
            var service = new ProductService(products);
            var expected = new List<int>() { 6, 15, 24, 21 };

            //Act
            var actual = service.CalculatePropertySum("Cost", 3);

            //Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void 驗證REVENUE屬性四筆一組的總和()
        {
            //Arrange 
            var products = SampleDataGet();
            var service = new ProductService(products);
            var expected = new List<int>() { 50, 66, 60 };

            //Act
            var actual = service.CalculatePropertySum("Revenue", 3);

            //Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void 驗證傳入不存在的屬性時的Exception()
        {
            //Arrange 
            var products = SampleDataGet();
            var service = new ProductService(products);

            //Act
            Action act = () => service.CalculatePropertySum("ThereIsNoSuchProperty", 3);

            //Assert
            act.ShouldThrow<ArgumentException>();
        }

        internal Product[] SampleDataGet()
        {
            var result = new Product[11];

            result[0] = new Product(1, 1, 11, 21);
            result[1] = new Product(2, 2, 12, 22);
            result[2] = new Product(3, 3, 13, 23);
            result[3] = new Product(4, 4, 14, 24);
            result[4] = new Product(5, 5, 15, 25);
            result[5] = new Product(6, 6, 16, 26);
            result[6] = new Product(7, 7, 17, 27);
            result[7] = new Product(8, 8, 18, 28);
            result[8] = new Product(9, 9, 19, 29);
            result[9] = new Product(10, 10, 20, 30);
            result[10] = new Product(11, 11, 21, 31);

            return result;
        }
    }
}
