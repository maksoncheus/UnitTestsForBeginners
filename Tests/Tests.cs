using Task_01_10;

namespace Tests
{
    [TestClass]
    public class Tests
    {
        ////Data-Driven Tests - тесты, основанные на данных
        //  огда поведение нескольких тестов полностью совпадают, а отличаютс€
        // только входные и выходные данные
        //
        // 1) јтрибут DataRow (—трока данных) позвол€ет "прокинуть" данные в тест
        // ƒанный атрибут представл€ет собой одну строку данных константных значений
        // (int, string, double, char) или их массивов
        [DataTestMethod]
        //[DataRow(new object[] { new int[] {1,2,3,4}, 3d})] - если нужно передать массив как аргумент
        [DataRow(new object[] { -3d, 3d})]
        [DataRow(new object[] { 0d, 0d})]
        [DataRow(new object[] { 1.5d, 2.25d})]
        [DataRow(new object[] { 2d, 4d})]
        [DataRow(new object[] { 333d, 4d})]
        public void FirstTaskTestsWithDataRowAttribute(double x, double expectedResult)
        {
            TaskMethods methods = new TaskMethods();
            //Act
            double actualResult = methods.TaskFunction(x);
            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
        #region
        //[TestMethod]
        //public void FirstTaskArgumentLessThanZero()
        //{
        //    //Arrange
        //    double x = -3;
        //    double expectedResult = 3;
        //    TaskMethods methods = new TaskMethods();
        //    //Act
        //    double actualResult = methods.TaskFunction(x);
        //    //Assert
        //    Assert.AreEqual(expectedResult, actualResult);
        //}
        //[TestMethod]
        //public void FirstTaskArgumentEqualsZero()
        //{
        //    //Arrange
        //    double x = 0;
        //    double expectedResult = 0;
        //    TaskMethods methods = new TaskMethods();
        //    //Act
        //    double actualResult = methods.TaskFunction(x);
        //    //Assert
        //    Assert.AreEqual(expectedResult, actualResult);
        //}
        //[TestMethod]
        //public void FirstTaskArgumentGreaterThanZeroAndLessThanTwo()
        //{
        //    //Arrange
        //    double x = 1.5;
        //    double expectedResult = 2.25;
        //    TaskMethods methods = new TaskMethods();
        //    //Act
        //    double actualResult = methods.TaskFunction(x);
        //    //Assert
        //    Assert.AreEqual(expectedResult, actualResult);
        //}
        //[TestMethod]
        //public void FirstTaskArgumentEqualsTwo()
        //{
        //    //Arrange
        //    double x = 2;
        //    double expectedResult = 4;
        //    TaskMethods methods = new TaskMethods();
        //    //Act
        //    double actualResult = methods.TaskFunction(x);
        //    //Assert
        //    Assert.AreEqual(expectedResult, actualResult);
        //}
        //[TestMethod]
        //public void FirstTaskArgumentGreaterThanTwo()
        //{
        //    //Arrange
        //    double x = 333;
        //    double expectedResult = 4;
        //    TaskMethods methods = new TaskMethods();
        //    //Act
        //    double actualResult = methods.TaskFunction(x);
        //    //Assert
        //    Assert.AreEqual(expectedResult, actualResult);
        //}
        #endregion

        // 2) јтрибут DynamicData (динамические данные) - можно передавать экземпл€ры класса
        // јтрибут DynamicData позвол€ет получить данные от свойства или от метода

        private static object[][] GetData()
        {
            return new object[][] {
                new object[] { -3 },
                new object[] { 14 }
            };
        }
        [DataTestMethod]
        [DynamicData(nameof(GetData), DynamicDataSourceType.Method)]
        public void SecondTaskArgumentOutOfRange(int monthNumber)
        {
            TaskMethods methods = new TaskMethods();
            Assert.ThrowsException<ArgumentOutOfRangeException>(
                () => methods.GetSeason(monthNumber)
                );
        }

        [TestMethod]
        public void SecondTaskArgumentWithinRange()
        {
            int monthNumber = 10;
            string expectedResult = "ќсень";
            TaskMethods methods = new TaskMethods();
            string actualResult = methods.GetSeason(monthNumber);
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}