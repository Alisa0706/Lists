using NUnit.Framework;
using Lists;

namespace ListsTests
{

    [TestFixture]
    public class Tests

    {
        //1.добавление значения в конец

        [TestCase(new int[] { 1, 2, 3 }, 4, new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 10, -2, 3 }, -140, new int[] { 10, -2, 3, -140 })]
        [TestCase(new int[] {}, 4, new int[] {4})]
        public void AddTests(int[] array, int value, int[] expArray)

        {
            ListArray expected = new ListArray(expArray);
            ListArray actual = new ListArray(array);

            actual.Add(value);

            Assert.AreEqual(expected, actual);
        }

        //Метод удаления эллемента
        // [TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 2})]

        //// [TestCase(new int[] {}, new int[] {})]
        // public void DeleteTests(int[] array, int[] expArray)

        // {
        //     ListArray expected = new ListArray(expArray);
        //     ListArray actual = new ListArray(array);

        //     actual.Delete();

        //     Assert.AreEqual(expected, actual);
        // }

        //2. добавление значения в начало

        [TestCase(new int[] { 1, 2, 3 }, 4, new int[] {4, 1, 2, 3 })]
        [TestCase(new int[] { 10, -2, 3 }, -140, new int[] { -140, 10, -2, 3})]
        [TestCase(new int[] { }, 4, new int[] { 4 })]
        public void AddToFirstPlaceTests(int[] array, int value, int[] expArray)

        {
            ListArray expected = new ListArray(expArray);
            ListArray actual = new ListArray(array);

            actual.AddToFirstPlace(value);

            Assert.AreEqual(expected, actual);
        }




        //3. добавление значения по индексу
        // написать негативный тест  if (index < 0 && index >= Length) throw new IndexOutOfRangeException();

        [TestCase(new int[] { 1, 2, 3 }, 4, 1, new int[] { 1, 4, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3 }, 4, 2, new int[] { 1, 2, 4, 3 })]
        [TestCase(new int[] { 1, 2, 3 }, 4, 0, new int[] { 4, 1, 2, 3 })]
        public void AddByIndexTests(int[] array, int value, int index, int[] expArray)

        {
            ListArray expected = new ListArray(expArray);
            ListArray actual = new ListArray(array);

            actual.AddByIndex(index, value);

            Assert.AreEqual(expected, actual);
        }

        //4.удаление из конца одного элемента

        // написать негативный тест   if (Length == 0) throw new Exception("Length = 0");

        [TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 2 })]
        [TestCase(new int[] { 1, 2, 3,45 ,67 }, new int[] { 1, 2,3,45 })]
        [TestCase(new int[] { 1 }, new int[] { })]
        public void DeleteLastElementTest(int[] array, int[] expArray)
        {
            ListArray expected = new ListArray(expArray);
            ListArray actual = new ListArray(array);

            actual.DeleteLastElement();

            Assert.AreEqual(expected, actual);
        }

        //5.удаление из начала одного элемента
        // написать негативный тест   if (Length == 0) throw new Exception("Length = 0");


        [TestCase(new int[] { 1, 2, 3 }, new int[] { 2, 3 })]
        [TestCase(new int[] { 1 }, new int[] {})]
        [TestCase(new int[] { 0,0,0 }, new int[] { 0,0 })]
        public void DeleteFirstElementTest(int[] array, int[] expArray)
        {
            ListArray expected = new ListArray(expArray);
            ListArray actual = new ListArray(array);

            actual.DeleteFirstElement();

            Assert.AreEqual(expected, actual);
        }




        //6. удаление значения по индексу
        // if (index < 0 || index >= Length) throw new IndexOutOfRangeException();

        [TestCase(new int[] { 1, 2, 3, 4 }, 0, new int[] { 2, 3, 4 })]
        [TestCase(new int[] { 1}, 0, new int[] {})]
        [TestCase(new int[] { 1,4,6,7,89}, 3, new int[] {1,4,6,89})]

        public void DeleteByIndexTest(int[] array, int index, int[] expArray)

        {

            ListArray expected = new ListArray(expArray);
            ListArray actual = new ListArray(array);

            actual.DeleteByIndex(index);

            Assert.AreEqual(expected, actual);

        }


        //8.Доступ по индексу
        // if (index < 0 || index >= Length) throw new IndexOutOfRangeException();


        [TestCase(new int[] { 1, 2, 3, 4 }, 1, 2)]
        [TestCase(new int[] { 1}, 0, 1)]
        [TestCase(new int[] { 0,0,0 }, 1, 0)]
        public void GetByIndexTest(int[] array, int index, int exp)
        {
            ListArray a = new ListArray(array);

            int actual = a.GetByIndex(index);
            Assert.AreEqual(exp, actual);

        }

        // 9. индекс по значению 

        [TestCase(new int[] { 1, 15, 3, 4 }, 15, 1)]
        [TestCase(new int[] { 1, 15, 3,0 }, 0,3)]
        [TestCase(new int[] { 1, 15, 3, 15 }, 15, 3)]
        public void GetIndexByValueTest(int[] array, int value, int exp)
        {
            ListArray a = new ListArray(array);

            int actual = a.GetIndexByValue(value);
            Assert.AreEqual(exp, actual);

        }




        //10 изменение по индексу
        [TestCase(new int[] { 1, 2, 3, 4 }, 0, 7, new int[] { 7, 2, 3, 4 })]
        [TestCase(new int[] { 0, 0, 0, 0 }, 2, 7, new int[] { 0, 0, 7, 0 })]
        [TestCase(new int[] { 1}, 0, 7, new int[] { 7})]
        public void ChangeByIndexTest(int[] array, int index, int value, int[] expArray)
        {


            ListArray expected = new ListArray(expArray);
            ListArray actual = new ListArray(array);

            actual.ChangeByIndex(index, value);

            Assert.AreEqual(expected, actual);

        }

        //11.реверс
        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 4, 3, 2, 1 })]
        [TestCase(new int[] { 1, 1, 1, 1 }, new int[] { 1, 1, 1, 1 })]
        [TestCase(new int[] { 1}, new int[] { 1})]
        public void ReversTest(int[] array, int[] expArray)
        {
            ListArray expected = new ListArray(expArray);
            ListArray actual = new ListArray(array);

            actual.Reverse();

            Assert.AreEqual(expected, actual);

        }

        //12.поиск значения максимального элемента
        [TestCase(new int[] { 1, 2, 3, 7 }, 7)]
        [TestCase(new int[] { 1,1,1 }, 1)]
        [TestCase(new int[] { -1000, 2, 3, 100 }, 100)]
        public void MaxElementTest(int[] array, int expected)
        {
            ListArray a = new ListArray(array);

            int actual = a.MaxElement();
            Assert.AreEqual(expected, actual);
        }

        //13.поиск значения минимального элемента
        [TestCase(new int[] { 1, 2, 3, 7 }, 1)]
        [TestCase(new int[] {-7 }, -7)]
        [TestCase(new int[] { 0, 0, 0, 0 }, 0)]
        public void MinElementTest(int[] array, int expected)
        {
            ListArray a = new ListArray(array);

            int actual = a.MinElement();
            Assert.AreEqual(expected, actual);
        }


        //14. поиск индекс максимального элемента
        [TestCase(new int[] { 1, 2, 3, 7 }, 3)]
        [TestCase(new int[] { 7, 2, 3, 7 }, 0)]
        [TestCase(new int[] { 1 }, 0)]
        public void MaxIndexTest(int[] array, int expected)
        {
            ListArray a = new ListArray(array);

            int actual = a.MaxIndex();
            Assert.AreEqual(expected, actual);

        }

        //15. поиск индекс минимального элемента
        [TestCase(new int[] { 1, 2, 3, 7 }, 0)]
        [TestCase(new int[] { 1, 2, 3, 1 }, 0)]
        [TestCase(new int[] { 1 }, 0)]
        public void MinIndexTest(int[] array, int expected)
        {
            ListArray a = new ListArray(array);

            int actual = a.MinIndex();
            Assert.AreEqual(expected, actual);
        }

        //16.сортировка по возрастанию

        [TestCase(new int[] { 13, 1, 3, 4 }, new int[] { 1, 3, 4, 13 })]
        [TestCase(new int[] { 13}, new int[] { 13 })]
        [TestCase(new int[] { 1,1,1,1 }, new int[] { 1, 1,1,1 })]
        public void SortMinToMaxTest(int[] array, int[] expArray)
        {

            ListArray expected = new ListArray(expArray);
            ListArray actual = new ListArray(array);

            actual.SortMinToMax();

            Assert.AreEqual(expected, actual);
        }

        //17.сортировка по убыванию
        [TestCase(new int[] { 13, 1, 3, 4 }, new int[] { 13, 4, 3, 1 })]
        [TestCase(new int[] { 13}, new int[] { 13})]
        [TestCase(new int[] { 4,4,4, 4 }, new int[] { 4, 4, 4, 4 })]
        public void SortMaxToMinTest(int[] array, int[] expArray)
        {

            ListArray expected = new ListArray(expArray);
            ListArray actual = new ListArray(array);

            actual.SortMaxToMin();

            Assert.AreEqual(expected, actual);
        }


        //18.удаление по значению первого

        [TestCase(new int[] { 1, 2, 7, 1 }, 1, new int[] { 2, 7 ,1 })]
        [TestCase(new int[] { 1, 7, 7, 4 }, 7, new int[] { 1, 7, 4 })]
        [TestCase(new int[] { 7, 7, 7 }, 7, new int[] { 7, 7 })]
        public void DeleteElementByValueTest(int[] array, int value, int[] expArray)
        {
            ListArray expected = new ListArray(expArray);
            ListArray actual = new ListArray(array);

            actual.DeleteElementByValue(value);

            Assert.AreEqual(expected, actual);
        }

        //19. удаление по значению всех

        [TestCase(new int[] { 1, 7, 7, 4 }, 7, new int[] { 1, 4 })]
        [TestCase(new int[] { 7, 7, 7}, 7, new int[] { })]
        [TestCase(new int[] { 1, 7, 1, 7 }, 7, new int[] { 1, 1 })]
        [TestCase(new int[] { 1, 1, 1, 7 }, 1, new int[] { 7 })]
        public void DeleteAllElementsByValueTest(int[] array, int value, int[] expArray)
        {
            ListArray expected = new ListArray(expArray);
            ListArray actual = new ListArray(array);

            actual.DeleteAllElementsByValue(value);

            Assert.AreEqual(expected, actual);
        }


        //[TestCase("may")]
        //public void MayTest(string exp)
        //{
        //    Cat cat = new Cat();
        //    string act = cat.May();
        //    Assert.AreEqual(exp, act);
        //}
        //[TestCase()]
        //public void Fish1Test()
        //{
        //    Fish A = new Fish();
        //    string actual = A.FishBul();

        //    Cat cat = new Cat();
        //    string actual2 = cat.May();

        //    Assert.IsTrue(actual != actual2);
        //}

    }
}   



