using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Lists.DL;

namespace ListsTests
{
    public class DoubleLinkedListTest
    {
        // проверка equals
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { 1 }, new int[] { 1 })]
        public void test(int[] a, int[] b)
        {
            DoubleLinkedList DoubleLinkedListA = new DoubleLinkedList();
            DoubleLinkedList DoubleLinkedListB = new DoubleLinkedList();

            Assert.AreEqual(DoubleLinkedListA, DoubleLinkedListB);
        }

        ////получение ноды по индексу 
        //[TestCase(new int[] { 1, 2, 3, 4, 5 }, 2, new int[] { 1, 2, 3, 4, 5 })]

        //public void GetNodeByIndexTest(int[] array,int index,  int[] expArray)
        //{
        //    DoubleLinkedList expected = new DoubleLinkedList(expArray);
        //    DoubleLinkedList actual = new DoubleLinkedList(array);

        //    actual.GetNodeByIndex(index);

        //    Assert.AreEqual(expected, actual);
        //}

        // 1. добавление значения в конец
        [TestCase(new int[] { }, 4, new int[] { 4 })]
        [TestCase(new int[] { 1 }, 4, new int[] { 1,4  })]
        [TestCase(new int[] { 0,0,0 }, 4, new int[] { 0,0,0,4  })]
        [TestCase(new int[] { 1,2,3,4 }, 4, new int[] { 1,2,3,4,4  })]
        public void AddToTheEnd(int[] array, int value, int[] expArray)
        {
            DoubleLinkedList expected = new DoubleLinkedList(expArray);
            DoubleLinkedList actual = new DoubleLinkedList(array);

            actual.AddToTheEnd(value);

            Assert.AreEqual(expected, actual);

        }
        //2.добавление значения в начало
        [TestCase(new int[] { 1, 2, 3, 4 }, 4, new int[] { 4,1, 2, 3, 4 })]
        [TestCase(new int[] { }, 4, new int[] { 4})]
        [TestCase(new int[] { 1}, 4, new int[] { 4,1 })]
        [TestCase(new int[] {0,0,0}, 4, new int[] { 4,0,0,0 })]
        public void AddToTheFirstPlace(int[] array, int value, int[] expArray)
        {
            DoubleLinkedList expected = new DoubleLinkedList(expArray);
            DoubleLinkedList actual = new DoubleLinkedList(array);

            actual.AddToTheFirstPlace(value);

            Assert.AreEqual(expected, actual);
        }

        //3.добавление по индексу AddByIndex

        [TestCase(new int[] { 1, 2, 3 }, 1, 4, new int[] { 1, 4, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3 }, 0, 4, new int[] { 4, 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3 }, 2, 4, new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { }, 0, 4, new int[] { 4 })]
        [TestCase(new int[] { 1 }, 0, 4, new int[] { 4, 1 })]
        public void AddByIndexTest(int[] array, int index, int value, int[] expArray)
        {
            DoubleLinkedList expected = new DoubleLinkedList(expArray);
            DoubleLinkedList actual = new DoubleLinkedList(array);

            actual.AddByIndex(index, value);

            Assert.AreEqual(expected, actual);

        }

        //4.удаление из конца одного элемента

        [TestCase(new int[] { 1, 4 }, new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1 }, new int[] { })]
        public void DeleteLastElement(int[] array, int[] expArray)
        {
            DoubleLinkedList expected = new DoubleLinkedList(expArray);
            DoubleLinkedList actual = new DoubleLinkedList(array);

            actual.DeleteLastElement();
            Assert.AreEqual(expected, actual);
        }

        //5. удаление из начала одного элемента
        [TestCase(new int[] { 1, 2 }, new int[] { 2 })]
        [TestCase(new int[] { 1 }, new int[] { })]
        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 2, 3, 4 })]
        public void DeleteFirstElement(int[] array, int[] expArray)
        {
            DoubleLinkedList expected = new DoubleLinkedList(expArray);
            DoubleLinkedList actual = new DoubleLinkedList(array);

            actual.DeleteFirstElement();

            Assert.AreEqual(expected, actual);
        }


        //6.удаление по индексу одного элемента

        [TestCase(new int[] { 1, 2, 3, 4 }, 0, new int[] { 2, 3, 4 })]
        [TestCase(new int[] { 1, 2, 3, 4 }, 3, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4,5,6 }, 3, new int[] { 1, 2, 3,5,6 })]
        [TestCase(new int[] { 1, 2 }, 1, new int[] { 1 })]
        [TestCase(new int[] { 1 }, 0, new int[] { })]
        public void DeleteByIndex(int[] array, int index, int[] expArray)
        {
            DoubleLinkedList expected = new DoubleLinkedList(expArray);
            DoubleLinkedList actual = new DoubleLinkedList(array);

            actual.DeleteByIndex(index);

            Assert.AreEqual(expected, actual);

        }

        //8.доступ по индексу
        [TestCase(new int[] { 1, 2, 3, 4 }, 3, 4)]
        [TestCase(new int[] { 1, 2, 3, 4 }, 0, 1)]
        [TestCase(new int[] { 1, 2, 3, 4 }, 1, 2)]
        [TestCase(new int[] { 1, 1, 1, 1 }, 1, 1)]
        [TestCase(new int[] {1}, 0, 1)]
        public void GetValue(int[] array, int index, int expected)
        {
            DoubleLinkedList list = new DoubleLinkedList(array);

            var actual = list.GetValue(index);
            Assert.AreEqual(expected, actual);
        }

        //9.индекс по значению 


        [TestCase(new int[] { 1, 2, 3, 4 }, 2, 1)]
        [TestCase(new int[] { 1, 2, 3, 4 }, 1, 0)]
        [TestCase(new int[] { 1 }, 1, 0)]
        [TestCase(new int[] { 1,2,3,4 }, 4, 3)]
        public void GetIndex(int[] array, int value, int expected)
        {
            DoubleLinkedList dl = new DoubleLinkedList(array);

            int actual = dl.GetIndex(value);
            Assert.AreEqual(expected, actual);
        }

        //10.изменение по индексу

        [TestCase(new int[] { 1, 2, 3, 4 }, 1, 7, new int[] { 1, 7, 3, 4 })]
        [TestCase(new int[] { 1 }, 0, 7, new int[] { 7 })]
        [TestCase(new int[] { 1, 2, 3, 4 }, 3, 7, new int[] { 1, 2, 3, 7 })]
        [TestCase(new int[] { 1, 2, 3, 4,6,5 }, 3, 7, new int[] { 1, 2, 3, 7,6,5 })]
        public void ChangeByIndex(int[] array, int index, int value, int[] expArray)
        {
            DoubleLinkedList expected = new DoubleLinkedList(expArray);
            DoubleLinkedList actual = new DoubleLinkedList(array);

            actual.ChangeByIndex(index, value);

            Assert.AreEqual(expected, actual);

        }


        //18. удаление по значению первого
        [TestCase(new int[] { 1, 2, 3, 4 }, 3, new int[] { 1, 2, 4 })]
        [TestCase(new int[] { 1, 2, 3, 4 }, 1, new int[] { 2, 3, 4 })]
        [TestCase(new int[] { 1, 2, 3, 4, 3, 5 }, 3, new int[] { 1, 2, 4, 3, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 3, 5 }, 5, new int[] { 1, 2,3, 4, 3 })]
        public void DeleteFirstElementByValue(int[] array, int value, int[] expArray)
        {
            DoubleLinkedList expected = new DoubleLinkedList(expArray);
            DoubleLinkedList actual = new DoubleLinkedList(array);

            actual.DeleteFirstElementByValue(value);

            Assert.AreEqual(expected, actual);
        }


        //21. добавление массива в конец
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3, 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { }, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { }, new int[] { 1, 5 }, new int[] { 1, 5 })]
        [TestCase(new int[] { 0,0}, new int[] { 1, 5 }, new int[] { 0,0,1, 5 })]
        [TestCase(new int[] { }, new int[] { 1, 5,4,5,6 }, new int[] { 1, 5,4,5,6 })]
        public void AddArrayToTheEnd(int[] array, int[] array2, int[] expArray)
        {

            DoubleLinkedList expected = new DoubleLinkedList(expArray);
            DoubleLinkedList actual = new DoubleLinkedList(array);

            actual.AddArrayToTheEnd(array2);
            Assert.AreEqual(expected, actual);

        }

        //22. добавление массива в начало
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 4, 4, 4 }, new int[] { 4, 4, 4, 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { }, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { }, new int[] {7,6,5 }, new int[] { 7,6,5 })]
        [TestCase(new int[] { 0,0}, new int[] {4,4 }, new int[] {4,4,0,0})]
        public void AddArrayToFirstPlace(int[] array, int[] array2, int[] expArray)
        {

            DoubleLinkedList expected = new DoubleLinkedList(expArray);
            DoubleLinkedList actual = new DoubleLinkedList(array);

            actual.AddArrayToFirstPlace(array2);
            Assert.AreEqual(expected, actual);

        }


        //23.добавление массива по индексу
        [TestCase(new int[] { 1, 2, 3 }, new int[] {7,7 },0, new int[] {7,7, 1, 2, 3 })]
        [TestCase(new int[] { }, new int[] {7,7 },0, new int[] {7,7})]
        [TestCase(new int[] { 1, 2, 3,5,6 }, new int[] {7,7 },1, new int[] {1,7,7, 2, 3,5,6 })]
        [TestCase(new int[] { 1, 2, 3,5,6 }, new int[] {7,7 },3, new int[] {1,2,3,7,7,5,6 })]
        [TestCase(new int[] { 1, 2, 3,5,6 }, new int[] {7,7 },4, new int[] {1,2,3,5,6,7,7 })]
        public void AddArrayByIndex(int[] array, int[] array2, int index, int[] expArray)
        {
            DoubleLinkedList expected = new DoubleLinkedList(expArray);
            DoubleLinkedList actual = new DoubleLinkedList(array);

            actual.AddArrayByIndex(array2, index);
            Assert.AreEqual(expected, actual);

        }

        //24.удаление из конца N элементов
        [TestCase(new int[] { 1, 2, 3, 5, 6 },  3, new int[] { 1, 2 })]
        [TestCase(new int[] { 1, 2, 3 },  3, new int[] { })]
        [TestCase(new int[] { 1, 2, 3, 4 },  3, new int[] {1 })]
        public void DeleteLastN(int[] array,  int n, int[] expArray)
        {
            DoubleLinkedList expected = new DoubleLinkedList(expArray);
            DoubleLinkedList actual = new DoubleLinkedList(array);

            actual.DeleteLastN(n);
            Assert.AreEqual(expected, actual);

        }

        //25.удаление из начала N элементов
        [TestCase(new int[] { 1, 2, 3, 5, 6 }, 3, new int[] { 5,6 })]
        [TestCase(new int[] { 1, 2, 3 }, 3, new int[] { })]
        [TestCase(new int[] { 1, 2, 3, 4 }, 3, new int[] { 4 })]
        public void DeleteFirstN(int[] array, int n, int[] expArray)
        {
            DoubleLinkedList expected = new DoubleLinkedList(expArray);
            DoubleLinkedList actual = new DoubleLinkedList(array);

            actual.DeleteFirstN(n);
            Assert.AreEqual(expected, actual);
        }

        //26.удаление по индексу N элементов
        [TestCase(new int[] { 1, 2, 3, 5, 6 }, 2,2, new int[] { 1,2, 6 })]
        //[TestCase(new int[] { 1, 2, 3 }, 3, new int[] { })]
        [TestCase(new int[] { 1, 2, 3, 4 }, 3,2, new int[] {})]
        public void DeleteFromIndexN(int[] array,int index, int n, int[] expArray)
        {
            DoubleLinkedList expected = new DoubleLinkedList(expArray);
            DoubleLinkedList actual = new DoubleLinkedList(array);

            actual.DeleteFromIndexN(index,n);
            Assert.AreEqual(expected, actual);
        }



    }
}
