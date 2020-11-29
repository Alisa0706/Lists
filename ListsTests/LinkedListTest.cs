using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Lists.LL;

namespace ListsTests
{
    public class LinkedListTest
    {

        // проверка equals
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { 1 }, new int[] { 1 })]
        [TestCase(new int[] { 1 }, new int[] { 1 })]
        public void test(int[] a, int[] b)
        {
            LinkedList linkedListA = new LinkedList(a);
            LinkedList linkedListB = new LinkedList(b);

            Assert.AreEqual(linkedListA, linkedListB);
        }


        //3.
        [TestCase (new int[] {1,2,3},1,4, new int[] {1,4,2,3})]
        [TestCase (new int[] {1,2,3},0,4, new int[] {4,1,2,3})]
        [TestCase (new int[] {1,2,3},3,4, new int[] {1,2,3,4})]
        [TestCase (new int[] {},0,4, new int[] {4})]
        [TestCase (new int[] {1},0,4, new int[] {4,1})]
        public void AddByIndex(int[] array, int index, int value, int[] expArray )
        {
            LinkedList expected = new LinkedList(expArray);
            LinkedList actual = new LinkedList(array);

            actual.AddByIndex(index, value);

            Assert.AreEqual(expected, actual);

        }

        //1. добавление значения в конец
        [TestCase(new int[] { 1, 2, 3 },4, new int[] { 1,2, 3,4 })]
        [TestCase(new int[] { },3, new int[] {3})]
        [TestCase(new int[] { 1},4, new int[] { 1,4 })]
        public void AddToLastPlace(int [] array, int value, int[] expArray)
        {
            LinkedList expected = new LinkedList(expArray);
            LinkedList actual = new LinkedList(array);

            actual.AddToLastPlace(value);

            Assert.AreEqual(expected, actual);
        }

        //2.добавление значения в начало

        [TestCase(new int[] { 1 }, 4, new int[] { 4,1 })]
        [TestCase(new int[] { 1,2,3 }, 4, new int[] { 4,1,2,3 })]
        [TestCase(new int[] {  }, 4, new int[] { 4 })]
        public void AddToFirstPlace(int[] array, int value, int[] expArray)
        {
            LinkedList expected = new LinkedList(expArray);
            LinkedList actual = new LinkedList(array);

            actual.AddToFirstPlace(value);

            Assert.AreEqual(expected, actual);
        }


        //4. удаление из конца одного элемента

        [TestCase(new int[] { 1,4}, new int[] { 1 })]
        [TestCase(new int[] { 1,2,3,4}, new int[] { 1,2,3 })]
        [TestCase(new int[] { 1}, new int[] { })]
        public void DeleteLastElement(int[] array, int[] expArray)
        {
            LinkedList expected = new LinkedList(expArray);
            LinkedList actual = new LinkedList(array);

            actual.DeleteLastElement();

            Assert.AreEqual(expected, actual);
        }

        //5. удаление из начала одного элемента

        [TestCase(new int[] { 1,2 }, new int[] {2 })]
        [TestCase(new int[] { 1 }, new int[] { })]
        [TestCase(new int[] { 1,2,3,4 }, new int[] {2,3,4 })]
        public void DeleteFirstElement(int[] array, int[] expArray)
        {
            LinkedList expected = new LinkedList(expArray);
            LinkedList actual = new LinkedList(array);

            actual.DeleteFirstElement();

            Assert.AreEqual(expected, actual);
        }

        //6.удаление по индексу одного элемента

        [TestCase(new int[] { 1, 2, 3, 4 },0, new int[] { 2, 3, 4 })]
        [TestCase(new int[] { 1, 2, 3, 4 },3, new int[] { 1,2, 3 })]
        [TestCase(new int[] { 1, 2},1, new int[] { 1})]
        [TestCase(new int[] { 1},0, new int[] { })]
        public void DeleteByIndex(int[] array, int index, int[] expArray)
        {
            LinkedList expected = new LinkedList(expArray);
            LinkedList actual = new LinkedList(array);

            actual.DeleteByIndex(index);

            Assert.AreEqual(expected, actual);

        }

        //7. вернуть длину
        [TestCase(new int[] { 1, 2, 3, 4 }, 4)]
        [TestCase(new int[] { 1}, 1)]
        [TestCase(new int[] { }, 0)]
        public void GetLength(int[] array, int expLength)
        {
            
            LinkedList list = new LinkedList(array);

            var actual = list.GetLength();

            Assert.AreEqual(expLength, actual);

        }
        //8.доступ по индексу
        [TestCase(new int[] { 1, 2, 3, 4 }, 3,4)]
        [TestCase(new int[] { 1, 2, 3, 4 }, 0,1)]
        [TestCase(new int[] { 1, 2, 3, 4 }, 1,2)]
        public void GetValue(int[] array, int index, int expected)
        {
            LinkedList list = new LinkedList(array);

            var actual = list.GetValue(index);
            Assert.AreEqual(expected, actual);
        }

        //9.индекс по значению


        [TestCase(new int[] { 1, 2, 3, 4 }, 2, 1)]
        public void GetIndex(int[] array, int value, int expected)
        {
            LinkedList ll = new LinkedList(array);

            int actual = ll.GetIndex(value);
            Assert.AreEqual(expected, actual);
        }


        //10.изменение по индексу

        [TestCase(new int[] { 1, 2, 3, 4 }, 1, 7, new int[] { 1, 7, 3, 4 })]
        [TestCase(new int[] { 1}, 0, 7, new int[] { 7})]
        [TestCase(new int[] { 1, 2, 3, 4 }, 3, 7, new int[] { 1, 2, 3, 7 })]
        public void ChangeByIndex(int[] array, int index, int value, int[] expArray)
        {
            LinkedList expected = new LinkedList(expArray);
            LinkedList actual = new LinkedList(array);

            actual.ChangeByIndex(index,value);

            Assert.AreEqual(expected, actual);

        }

        //11.реверс (123 -> 321)
        [TestCase(new int[] { 1, 2, 3, 4 },  new int[] {4,3,2,1 })]
        [TestCase(new int[] { 0, -2, 3, 7 },  new int[] {7,3,-2,0 })]
        [TestCase(new int[] { 1},  new int[] {1 })]
        public void ReverseTest(int[] array, int[] expArray)
        {
            LinkedList expected = new LinkedList(expArray);
            LinkedList actual = new LinkedList(array);

            actual.Reverse();

            Assert.AreEqual(expected, actual);
        }

        //12.поиск значения максимального элемента
        [TestCase(new int[] { 1, 2, 3, 4 }, 4)]
        [TestCase(new int[] { 7, 2, 3, 4 }, 7)]
        [TestCase(new int[] { -1}, -1)]

        public void SearchMaxEllement(int[] array, int expValue)
        {
            LinkedList ll = new LinkedList(array);

            int actual = ll.SearchMaxEllement();
            Assert.AreEqual(expValue, actual);

        }

        //13. поиск значения минимального элемента

        [TestCase(new int[] { 0, 2, 3, 4 }, 0)]
        [TestCase(new int[] { 7, 2, 3, 1}, 1)]
        [TestCase(new int[] { 1, 2, -3, 4 }, -3)]
        public void SearchMinEllement(int[] array, int expValue)
        {
            LinkedList ll = new LinkedList(array);

            int actual = ll.SearchMinEllement();
            Assert.AreEqual(expValue, actual);

        }

        //14.поиск индекс максимального элемента
        [TestCase(new int[] { 0, 10, 4, 3 }, 1)]
        [TestCase(new int[] { 9, 2, 4, 3 }, 0)]
        [TestCase(new int[] { 0, 2, 4, 11 }, 3)]
        public void MaxIndex(int[] array, int expIndex)
        {
            LinkedList ll = new LinkedList(array);

            int actual = ll.MaxIndex();
            Assert.AreEqual(expIndex, actual);
        }

        //15.поиск индекс минимального элемента

        [TestCase(new int[] { 0, 10, 4, -3 }, 3)]
        [TestCase(new int[] { -9, 2, 4, 3 }, 0)]
        [TestCase(new int[] { 0, 2, -14, 11 }, 2)]
        public void MinIndex(int[] array, int expIndex)
        {
            LinkedList ll = new LinkedList(array);

            int actual = ll.MinIndex();
            Assert.AreEqual(expIndex, actual);
        }

        //16.сортировка по возрастанию
        [TestCase(new int[] { 5, 2, 10, 4 }, new int[] { 2, 4,5,10 })]
        public void SortFromMinToMax(int[] array, int[] expArray)
        {

            LinkedList expected = new LinkedList(expArray);
            LinkedList actual = new LinkedList(array);

            actual.SortFromMinToMax();

            Assert.AreEqual(expected, actual);
        }

        //17.сортировка по убыванию
        [TestCase(new int[] { 5, 2, 10, 4 }, new int[] {10,5,4,2 })]
        public void SortFromMaxToMin(int[] array, int[] expArray)
        {

            LinkedList expected = new LinkedList(expArray);
            LinkedList actual = new LinkedList(array);

            actual.SortFromMinToMax();

            Assert.AreEqual(expected, actual);
        }

        //18. удаление по значению первого
        [TestCase(new int[] { 1, 2, 3, 4 }, 3, new int[] { 1, 2, 4 })]
        [TestCase(new int[] { 1, 2, 3, 4 }, 1, new int[] { 2,3, 4 })]
        [TestCase(new int[] { 1, 2, 3, 4,3,5 }, 3, new int[] { 1, 2, 4,3,5 })]
        public void DeleteFirstElementByValue(int[] array, int value, int[] expArray)
        {
            LinkedList expected = new LinkedList(expArray);
            LinkedList actual = new LinkedList(array);

            actual.DeleteFirstElementByValue(value);

            Assert.AreEqual(expected, actual);
        }

        //19. удаление по значению всех
        [TestCase(new int[] { 1, 2, 3, 4, 3 ,5 }, 3, new int[] { 1, 2, 4, 5 })]
        [TestCase(new int[] { 1, 1, 1, 4, 3 ,5 }, 1, new int[] { 4, 3, 5 })]
        [TestCase(new int[] { 1, 1}, 1, new int[] { })]
        [TestCase(new int[] { 1, 2, 3, 4, 3 ,5,5,5 }, 5, new int[] { 1, 2,3, 4,3 })]
        public void DeleteAllElementByValue(int[] array, int value, int[] expArray)
        {
            LinkedList expected = new LinkedList(expArray);
            LinkedList actual = new LinkedList(array);

            actual.DeleteAllElementByValue(value);
            Assert.AreEqual(expected, actual);
        }


        //21. добавление массива в конец
        [TestCase(new int[] { 1, 2, 3}, new int[] { 1,2,3}, new int[] { 1, 2, 3,1,2,3})]
        [TestCase(new int[] { 1, 2, 3}, new int[] { }, new int[] { 1, 2, 3})]
        [TestCase(new int[] { }, new int[] {1,5 }, new int[] { 1, 5})]
        [TestCase(new int[] {0 }, new int[] {1,5 }, new int[] {0, 1, 5})]
        [TestCase(new int[] { }, new int[] {1,5,4,7,7 }, new int[] { 1, 5,4,7,7})]
        public void AddArrayToTheEnd(int[] array, int[]array2, int[] expArray)
        {

            LinkedList expected = new LinkedList(expArray);
            LinkedList actual = new LinkedList(array);

            actual.AddArrayToTheEnd(array2);

            Assert.AreEqual(expected, actual);

        }

    }
}
