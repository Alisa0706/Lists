using System;
using System.Collections.Generic;
using System.Text;


namespace Lists.LL
{
    public class LinkedList
    {
        public int Length { get; set; }

        private Node _root;
        //private Node _tale;

        public int this[int index]
        {
            get
            {
                Node tmp = _root;

                for (int i = 1; i <= index; i++)
                {
                    tmp = tmp.Next;
                }
                return tmp.Value;
            }
            set
            {
                Node tmp = _root;

                for (int i = 1; i <= index; i++)
                {
                    tmp = tmp.Next;
                }
                tmp.Value = value;
            }
        }




        public LinkedList()
        {
            Length = 0;
            _root = null;
        }

        public LinkedList(int value) //пустой конструктор
        {

            _root = new Node(value);
            Length = 1;

        }

        public LinkedList(int[] array) //конструктор на основе массива
        {
            if (array.Length != 0)
            {
                _root = new Node(array[0]);
                Node tmp = _root;

                for (int i = 1; i < array.Length; i++)
                {
                    tmp.Next = new Node(array[i]);
                    //tmp.value - значение 
                    tmp = tmp.Next;
                }
                Length = array.Length;
            }
            else
            {
                Length = 0;
                _root = null;
            }
        }

        //метод по доходу до конца

        public Node LastPlace()
        {
            Node current = _root;
            for (int i = 1; i < Length; i++)
            {
                current = current.Next;
            }
            return current;
        }

        //1. добавление значения в конец

        public void AddToLastPlace(int value)
        {
            if (_root == null)
            {
                _root = new Node(value);
            }
            else
            {
                Node last = LastPlace();
                last.Next = new Node(value);
            }
            Length++;
        }

        //2.добавление значения в начало
        public void AddToFirstPlace(int value)
        {

            Node tmp = _root;
            _root = new Node(value);
            _root.Next = tmp;
            Length++;

        }

        // 3.добавление по индексу
        public void AddByIndex(int index, int value)
        {
            if (index == 0)
            {
                Node tmp = _root;
                _root = new Node(value);
                _root.Next = tmp;

            }
            else
            {
                Node curent = _root;

                for (int i = 1; i < index; i++)
                {

                    curent = curent.Next;
                }
                Node tmp = curent.Next;
                curent.Next = new Node(value);
                curent.Next.Next = tmp;
            }
            Length++;
        }


        //4. удаление из конца одного элемента

        public void DeleteLastElement()
        {
            Node curent = _root;
            if (_root == null)
            {
                throw new Exception("Length of list = 0");
            }
            for (int i = 1; i < Length - 1; i++)
            {
                curent = curent.Next;
            }
            curent.Next = null;
            Length--;
        }

        //5. удаление из начала одного элемента

        public void DeleteFirstElement()
        {
            if (_root == null)
            {
                throw new Exception("Length of list = 0");
            }

            _root = _root.Next;
            Length--;
        }

        //6.удаление по индексу одного элемента
        public void DeleteByIndex(int index)
        {
            if (_root == null)
            {
                throw new Exception("Length of list = 0");
            }

            if (index == 0)
            {
                _root = _root.Next;
            }
            else
            {
                Node curent = _root;

                for (int i = 0; i < index - 1; i++)
                {
                    curent = curent.Next;
                }
                curent.Next = curent.Next.Next;
            }
            Length--;
        }

        //7. вернуть длину

        public int GetLength()

        {
            return Length;
        }

        //8.доступ по индексу

        public int GetValue(int index)
        {
            Node current = _root;
            if (index < 0 || index >= Length)
            {
                throw new IndexOutOfRangeException();
            }
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            return current.Value;
        }

        //9.индекс по значению

        public int GetIndex(int value)
        {
            if (_root == null)
            {
                throw new Exception("Length of list = 0");
            }

            Node current = _root;
            int index = 0;

            for (int i = 0; i < Length; i++)
            {
                if (current.Value == value)
                {
                    index = i;
                }
                current = current.Next;
            }
            return index;
        }

        //10.изменение по индексу
        public void ChangeByIndex(int index, int value)
        {
            if (_root == null)
            {
                throw new Exception("Length of list = 0");
            }
            Node current = _root;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            current.Value = value;
        }

        //11. реверс (123 -> 321)

        public void Reverse()
        {
            if (_root == null)
            {
                throw new Exception("Length of list = 0");
            }

            Node OldRoot = _root;
            Node tmp;
            while (OldRoot.Next != null)
            {
                tmp = OldRoot.Next;
                OldRoot.Next = OldRoot.Next.Next;
                tmp.Next = _root;
                _root = tmp;

            }
        }

        //12.поиск значения максимального элемента

        public int SearchMaxEllement()
        {
            Node current = _root;
            int MaxEl = _root.Value;

            for (int i = 0; i < Length - 1; i++)
            {
                current = current.Next;

                if (current.Value > MaxEl)
                {
                    MaxEl = current.Value;
                }
            }
            return MaxEl;
        }

        //13. поиск значения минимального элемента

        public int SearchMinEllement()
        {
            Node current = _root;
            int MinEl = _root.Value;
            for (int i = 0; i < Length - 1; i++)
            {
                current = current.Next;

                if (current.Value < MinEl)
                {
                    MinEl = current.Value;
                }
            }
            return MinEl;
        }

        //14.поиск индекс максимального элемента

        public int MaxIndex()
        {
            Node current = _root;
            int MaxIndex = 0;
            int MaxValue = current.Value;

            for (int i = 0; i < Length; i++)
            {
                if (current.Value > MaxValue)
                {
                    MaxIndex = i;
                    MaxValue = current.Value;
                }
                current = current.Next;
            }
            return MaxIndex;
        }

        //15.поиск индекс минимального элемента
        public int MinIndex()
        {
            Node current = _root;
            int MinIndex = 0;
            int MinValue = current.Value;

            for (int i = 0; i < Length; i++)
            {
                if (current.Value < MinValue)
                {
                    MinIndex = i;
                    MinValue = current.Value;
                }
                current = current.Next;
            }
            return MinIndex;
        }

        //16.сортировка по возрастанию

        public void SortFromMinToMax()
        {
            for (int i = 0; i<Length;i++)
            {
                Node curent = _root;
                for (int j=1; j<Length -1; j++)
                {
                    
                    if (curent.Value > curent.Next.Value)
                    {
                        Node tmp = curent.Next;
                        curent = tmp;
                        curent.Next = curent;
                    }
                    curent = curent.Next;
                }
            }
        }


        //17.сортировка по убыванию

        public void SortFromMaxToMin()
        {
            for (int i = 0; i < Length; i++)
            {
                Node curent = _root;
                for (int j = 1; j < Length - 1; j++)
                {

                    if (curent.Value < curent.Next.Value)
                    {
                        Node tmp = curent.Next;
                        curent = tmp;
                        curent.Next = curent;
                    }
                    curent = curent.Next;
                }
            }
        }

        //18.удаление по значению первого
        public void DeleteFirstElementByValue(int value)
        {
            Node current = _root;
            if (Length == 0 )
            {
                return;
            }

            if (_root.Value == value)
            {
                _root = _root.Next;
                Length--;
            }
            else
            {
                for (int i = 1; i < Length - 1; i++)
                {
                    if (current.Next.Value == value)
                    {
                        current.Next = current.Next.Next;
                        Length--;
                        return;
                    }
                    current = current.Next;
                }
            }
           
        }

        //19. удаление по значению всех

        public void DeleteAllElementByValue(int value)
        {
                if (Length == 0)
                {
                    return;
                }
                while (_root.Value == value)
                {
                    _root = _root.Next;
                    Length--;
                }
            Node current = _root;

            while (current != null && current.Next!=null)
            {
                if (current.Next.Value == value)
                {
                    current.Next = current.Next.Next;
                    Length--;
                }
                current = current.Next;
               
            }
        }

        //21. добавление массива в конец

        public void AddArrayToTheEnd(int[]array)
        {
            if (_root == null)
            {
                for (int i = 0; i < 1; i++)
                {
                    _root = new Node(array[i]);

                    Node last2 = LastPlace();

                    for (int j = 1; j < array.Length; j++)
                    {
                        last2.Next = new Node(array[j]);
                        last2 = last2.Next;
                    }

                }
            }
            else
            {
                Node last = LastPlace();

                for (int i = 0; i < array.Length; i++)
                {
                    last.Next = new Node(array[i]);
                    last = last.Next;
                }
            }
            Length+=array.Length;
        }






        public override bool Equals(object obj)
        {
            LinkedList linkedList = (LinkedList)obj;
            if (Length!=linkedList.Length)
            {
                return false;
            }

            Node tmp1 = _root;
            Node tmp2 = linkedList._root;

            for (int i = 1; i <= Length; i++)
            {
                if(tmp1.Value!=tmp2.Value)
                {
                    return false;
                }

                tmp1 = tmp1.Next;
                tmp2 = tmp2.Next;
            }



                //for (int i = 0; i < Length; i++)
                //{
                //    if (this[i]!=linkedList[i])
                //    {
                //        return false;
                //    }
                //}

                return true;
        }
        public override string ToString()
        {
            string s = "";

            if (_root != null)

            {
                Node tmp = _root;

                while (tmp  != null)
                {
                    s += tmp.Value + ";";
                    tmp = tmp.Next;

                }
            }
            return s;
        }

    }
}
