//using System;
//using Xunit;
//using HookahNet.Model.Entities;

//namespace HookahNet.Tests
//{
//    public class CurrencyTests
//    {
//        [Fact]
//        public void DefaultCurrencyIsNotNull()
//        {
//            //Arrange
//            var Currency = new Currency();
//            //Assert
//            Assert.NotNull(Currency.CurrencyName);
//        }

//        [Fact]
//        public void SetAndValidateCurrency()
//        {
//            //Arrange
//            var Currency = new Currency();
//            //Act
//            Currency.SetCurrency(Currency.Currencies.EUR);
//            //Assert
//            Assert.Equal("EUR", Currency.CurrencyName);
//            Assert.Equal(1, Currency.CurrencyValue);
//        }
//    }
//}
