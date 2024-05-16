using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MedLab;
using static MedLab.biomaterials;
using static MedLab.Bills_insurance_company;
using System.Linq;
using System.Windows.Controls;

namespace MedLabTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var main = new biomaterials();
            var result = main.GenerateBarcode();
            Assert.AreEqual(main.GenerateBarcode(), result);
        }
        [TestMethod]
        public void TestMethod2()
        {
            var main = new Bills_insurance_company();
            var db = new ЛабораторияEntities2();
            main._1.Text = "1"; // Присваиваем значения полям ввода
            main._2.Text = "2";
            main._3.Text = "3";
            main._4.Text = "4";
            main._5.Text = "5";
            main._6.Text = "1000";

            main.Button_Click(null, null); // Вызываем метод Button_Click для добавления данных в базу

            // Assert
            // Проверяем, что данные были успешно добавлены в базу данных
            var records = db.Счета_страховым_компаниям.ToList();
            Assert.AreEqual(1, records.Count, "Ожидается, что в базе данных будет 1 запись после добавления");
            Assert.AreEqual(1, records[0].Код_счета, "Код счета не соответствует ожидаемому значению");
            Assert.AreEqual(2, records[0].Код_заказа, "Код заказа не соответствует ожидаемому значению");
            Assert.AreEqual(3, records[0].Код_пользователя_оформившего_заказ, "Код пользователя оформившего заказ не соответствует ожидаемому значению");
            Assert.AreEqual(4, records[0].Код_пользователя_ответственного_за_заказ, "Код пользователя ответственного за заказ не соответствует ожидаемому значению");
            Assert.AreEqual(5, records[0].Код_страховой_компании, "Код страховой компании не соответствует ожидаемому значению");
            Assert.AreEqual(1000, records[0].Общая_сумма, "Общая сумма не соответствует ожидаемому значению");
        }
        public class Bills_insurance_company
        {
            public TextBox _1;
            public TextBox _2;
            public TextBox _3;
            public TextBox _4;
            public TextBox _5;
            public TextBox _6;

            internal void Button_Click(object value1, object value2)
            {
                throw new NotImplementedException();
            }
        }

    }
}

