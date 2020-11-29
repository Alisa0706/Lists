using System;
using System.Collections.Generic;
using System.Text;

namespace Lists.DL
{
    public class DoubleLinkedList
    {
        public int Length { get; private set; }

        private Node _root;
        private Node _tail;

        public int this[int index]
        {
            get
            {
                Node tmp = _root;

                if (index < Length / 2)
                {
                    for (int i = 0; i < index; i++)
                    {
                        tmp = tmp.Next;
                    }
                }
                else
                {
                    tmp = _tail;

                    for (int i = Length - 1; i > 0; i--)
                    {
                        tmp = tmp.Previous;
                    }
                }

                return tmp.Value;
            }
            set
            {
                Node tmp = _root;

                if (index < Length / 2)
                {
                    for (int i = 1; i <= index; i++)
                    {
                        tmp = tmp.Next;
                    }
                }
                else
                {
                    tmp = _tail;

                    for (int i = Length - 1; i > 0; i++)
                    {
                        tmp = tmp.Previous;
                    }
                }
            }
        }

        public DoubleLinkedList() //пустой конструктор
        {
            Length = 0;
            _root = null;
            _tail = null;
        }

        public DoubleLinkedList(int value) // конструктор на основе значения
        {
            _root = new Node(value);
            _tail = _root;
            Length = 1;
        }

        public DoubleLinkedList(int[] array) //конструктор на основе массива
        {
            if (array.Length != 0)
            {
                _root = new Node(array[0]);
                Node tmp = _root;

                for (int i = 1; i < array.Length; i++)
                {
                    tmp.Next = new Node(array[i]);
                    tmp.Next.Previous = tmp;
                    tmp = tmp.Next;
                }
                _tail = tmp;
                Length = array.Length;
            }
            else
            {
                Length = 0;
                _root = null;
            }
        }

        private Node GetNodeByIndex(int index)
        {
            {
                Node tmp = _root;

                if (index < Length / 2)
                {
                    for (int i = 0; i < index; i++)
                    {
                        tmp = tmp.Next;
                    }
                }
                else
                {
                    tmp = _tail;

                    for (int i = Length - 1; i > index; i--)
                    {
                        tmp = tmp.Previous;
                    }
                }
                return tmp;
            }
        }

        // 1. добавление значения в конец
        public Node AddToTheEnd(int value)

        {

            if (_root == null)
            {
                _root = new Node(value);
                _tail = _root;
            }
            else
            {
                Node tmp = _tail;
                _tail = new Node(value);
                _tail.Previous = tmp;
                _tail.Previous.Next = _tail;
            }
            Length++;
            return _tail;
        }

        //2. добавление значения в начало
        public void AddToTheFirstPlace(int value)
        {

            if (_root == null)
            {
                _root = new Node(value);
                _tail = _root;
            }
            else
            {
                Node tmp = _root;
                _root = new Node(value);
                _root.Next = tmp;
                tmp.Previous = _root;
            }
            Length++;
        }

        // 3.добавление по индексу
        public void AddByIndex(int index, int value)
        {

            if (_root == null)
            {
              _root = new Node(value);
              _tail = _root;
              Length++;
            }

            else if (index == 0)
            {
                Node tmp = _root;
                _root = new Node(value);
                _root.Next = tmp;
                _root.Next.Previous = _root;
                Length++;
            }
            else if(index == Length-1)
            {
                Node end = AddToTheEnd(value);
            }
            else
            {
                Node a = GetNodeByIndex(index);
                a = a.Previous;
                Node b = new Node(value);
                Node c = a.Next;

                b.Previous = a;
                a.Next = b;
                b.Next = c;
                c.Previous = b;
                Length++;

            }

        }

        //4.удаление из конца одного элемента
        public void DeleteLastElement()
        {
            if (_root == null)
            {
                throw new Exception("Length of list = 0");
            }
            if (Length == 1)
            {
                _root = null;
                _tail = null;
                Length = 0;
            }
                _tail = _tail.Previous;
                _tail.Next = null;
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

            if (_root != null) // если после удаления одного эл-та рут окажется нулем, то обращение рут превиос -
            {                  //  обращение в налл, без этого условия программа ломается,  а с ним - нет.
                _root.Previous = null;
            }
            Length--;
        }

        //6.удаление по индексу одного элемента

        public void DeleteByIndex(int index)
        {
            if (_root == null)
            {
                throw new Exception("Length of list = 0");
            }
            else if (Length == 1)
            {
                _root = null;
                _tail = null;
                Length = 0;
            }
            else if (_root != null && index == 0)
            {
                _root = _root.Next;
                _root.Previous = null;
                Length--;
            }
            else if (index == Length-1 )
            {
                _tail = _tail.Previous;
                _tail.Next = null;
                Length--;
            }
            else
            {
                Node curent = GetNodeByIndex(index);
                Node tmp = curent.Previous; // сохраняем переменную curent во временную переменную tmp - чтоб curent не пропала
                curent.Next.Previous = tmp; // обращаемся к переменной следующей за той которую нужно удалить, curent.next - и обращаемся к полю previous этой переменной, что бы сделать ссылку назад
                curent.Previous.Next = curent.Next; // обращаемся к переменной предыдущей от той которую нужно удалить, curent.previos - и обращаемся к полю next этой переменной, что бы сделать ссылку вперед
                Length--; // уменьшаем длинну
            } 
        }

        //8.доступ по индексу
        public int GetValue(int index)
        {
            if (_root == null)
            {
                throw new Exception("Length of list - 0");
            }
            Node curent = GetNodeByIndex(index);
            return curent.Value;
        }

        //9.индекс по значению 
        public int GetIndex(int value)
        {
            if (_root == null)
            {
                throw new Exception("Length of list - 0");
            }

            else
            {
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
           

        
        }

        //10.изменение по индексу
        public void ChangeByIndex(int index, int value)
        {
            if (_root == null)
            {
                throw new Exception("Length of list = 0");
            }
            if (index < (Length / 2))
            {
                Node current = _root;
                for (int i = 0; i < index; i++)
                {
                    current = current.Next;
                }
                current.Value = value;
            }
            else
            {
                Node current = _tail;
                for (int i = Length -1; i > index; i--)
                {
                    current = current.Previous;
                }
                current.Value = value;
            }
        }

        //18.удаление по значению первого
        public void DeleteFirstElementByValue(int value)
        {
         Node current = _root;
            if (Length == 0)
            {
                 return;
            }
            else if (_root.Value == value)
            {
                _root = _root.Next;
                Length--;
            }
            else if (_tail.Value == value)
            {
                _tail = _tail.Previous;
                Length--;
            }
            else
            {
               for (int i = 1; i < Length - 1; i++)
               {
                  if (current.Next.Value == value)
                     {
                       Node tmp = current.Next;
                       current.Next = current.Next.Next;
                       current.Next.Previous = tmp;
                       Length--;
                       return;
                     }
                   current = current.Next;
               }
            }
        }

        //21. добавление массива в конец

        public void AddArrayToTheEnd(int[] array)
        {
            if (_root == null)
            {
                for (int i = 0; i < 1; i++)
                {
                    _root = new Node(array[i]);
                    _tail = _root;

                    for (int j = 1; j < array.Length; j++)
                    {
                        Node a = _tail;
                        _tail.Next = new Node(array[j]);
                        _tail = _tail.Next;
                        _tail.Previous = a;
                    }

                }
            }
            else
            {
                for (int i = 0; i < array.Length; i++)
                {
                    Node a = _tail;
                    _tail.Next = new Node(array[i]);
                    _tail = _tail.Next;
                    _tail.Previous = a;
                }
            }
            Length += array.Length;
        }

        //22. добавление массива в начало

        public void AddArrayToFirstPlace(int[] array)
        {
            if (_root == null)
            {
                for (int i = 0; i < 1; i++)
                {
                    _root = new Node(array[i]);
                    _tail = _root;

                    for (int j = 1; j < array.Length; j++)
                    {
                        Node a = _root;
                        _root = new Node(array[j]);
                        _root.Next = a;
                        a.Previous = _root;
                    }

                }
            }
            else
            {
                for (int i = 0; i < array.Length; i++)
                {
                    Node a = _root;
                    _root = new Node(array[i]);
                    _root.Next = a;
                    a.Previous = _root;
                }
            }
            Length += array.Length;
        }

        //23.добавление массива по индексу

        public void AddArrayByIndex(int[] array, int index)
        {
            if (_root == null)
            {
                for (int i = 0; i < array.Length; i++)

                _root = new Node(array[i]);
                _tail = _root;
              
            }
            else if (index == 0)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    Node tmp = _root;
                    _root = new Node(array[i]);
                    _root.Next = tmp;
                    _root.Next.Previous = _root;
                }
            }

            else if (index == Length - 1)
            {

                for (int i = 0; i < array.Length; i++)
                {
                    Node a = _tail;
                    _tail.Next = new Node(array[i]);
                    _tail = _tail.Next;
                    _tail.Previous = a;
                }

            }
            else 
            {
                    for (int i = 0; i < array.Length; i++)
                    {
                        Node a = GetNodeByIndex(index);
                        a = a.Previous;
                        Node b = new Node(array[i]);
                        Node c = a.Next;

                        b.Previous = a;
                        a.Next = b;
                        b.Next = c;
                        c.Previous = b;
                    }
            }
            Length += array.Length;
        }

        //24.удаление из конца N элементов
        public void DeleteLastN(int n)
        {
          

            if (Length == n)
            {
                _root = null;
                _tail = null;
                Length = 0;
            }
            else
            {
                for (int i = Length - 1; i >= Length - n; i--)
                {
                    _tail = _tail.Previous;
                    _tail.Next = null;
                }
                Length -= n;
            }
        }

        //25.удаление из начала N элементов
        public void DeleteFirstN(int n)
        {
            if (Length == n)
            {
                _root = null;
                _tail = null;
                Length = 0;
            }
            else if (n == Length - 1)
            {
                _root = _tail;
                _root.Next = null;
                _tail.Previous = null;
                Length = 1;
            }
            else
            {
                for (int i = 0; i <= Length - n; i++)
                {
                    if (_root != null)
                    {
                        _root = _root.Next;
                        _root.Previous = null;   
                    }
                }
                Length -= n;

            }
            

        }

        //26.удаление по индексу N элементов

        public void DeleteFromIndexN(int index, int n)
        {
            if (_root != null && index == 0)
            {
                for (int i = 0; i<= Length-n; i++)
                {
                    Node curent = GetNodeByIndex(index);
                    Node tmp = curent.Previous; // сохраняем переменную curent во временную переменную tmp - чтоб curent не пропала
                    curent.Next.Previous = tmp; // обращаемся к переменной следующей за той которую нужно удалить, curent.next - и обращаемся к полю previous этой переменной, что бы сделать ссылку назад
                    curent.Previous.Next = curent.Next;
                }
                Length -=n;
            }

            if (index == Length - 1)
            {
                _root = _tail;
                _root.Next = null;
                _tail.Previous = null;
                Length = 1;
            }

        }



        public override bool Equals(object obj)
        {
            DoubleLinkedList doubleLinkedList = (DoubleLinkedList)obj;
            if (Length != doubleLinkedList.Length)
            {
                return false;
            }

            Node tmp1 = _root;
            Node tmp2 = doubleLinkedList._root;

            while (tmp1!=null)
            {
                if (tmp1.Value != tmp2.Value)
                {
                    return false;
                }
                tmp1 = tmp1.Next;
                tmp2 = tmp2.Next;
            }
            tmp1 = _tail;
            tmp2 = doubleLinkedList._tail;

            while (tmp1 != null)
            {
                if (tmp1.Value != tmp2.Value)
                {
                    return false;
                }

                tmp1 = tmp1.Previous;
                tmp2 = tmp2.Previous;
            }
            return true;
        }
        public override string ToString()
        {
            string s = "";

            if (_root != null)

            {
                Node tmp = _root;

                while (tmp != null)
                {
                    s += tmp.Value + ";";
                    tmp = tmp.Next;

                }
            }
            return s;
        }
    }
}
