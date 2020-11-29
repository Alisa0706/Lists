using System;
using System.Linq;

namespace Lists
{
    public class ListArray
    {

        public int Length { get; private set; } //свойство ->публичное
        private int[] _array;                   //поле -> приватное


        public ListArray()                      //конструктор как метод но без ретёна
        {
            _array = new int[9];                // все значения лучше описывать в конструкторах
            Length = 0;
        }

        public ListArray(int[] array)
        {
            _array = new int[array.Length];
            Array.Copy(array, _array, array.Length);
            Length = array.Length;
        }


        //Метод удаления эллемента

        public void Delete()
        {
            if (Length == 0)
            {
                throw new Exception("Length = 0");

            }

            Length--;

            if (_array.Length / 2 >= Length)
            {
                DecreaseLength();
            }
        }

        // Уменьшение длинны массива

        private void DecreaseLength(int number = 1)
        {
            int newLength = (int)(_array.Length * 0.66d + 1);

            int[] newArray = new int[newLength];

            Array.Copy(_array, newArray, newLength);

            _array = newArray;

            //while (newLength <= Length + number)
            //{
            //    newLength = (int)(newLength * 1.33 + 1);
            //}
            //int[] newArray = new int[newLength];
            //Array.Copy(_array, newArray, _TrueLength);

            //_array = newArray;
        }

        // Увеличение длинны массива
        private void IncreaseLength(int number = 1)
        {
            int newLength = _array.Length;
            while (newLength <= Length + number)
            {
                newLength = (int)(newLength * 1.33 + 1);
            }
            int[] newArray = new int[newLength];
            Array.Copy(_array, newArray, _array.Length);

            _array = newArray;
        }






        //1.метод добавления эллемента в конец

        public void Add(int value)          // войдовые методы ни чего не возвращают, просто добавляет(делает что-то)
        {
            if (_array.Length <= Length)
            {
                IncreaseLength();
            }
            _array[Length] = value;         // array length - является нулевым индексом массива,т.к мы задали в конструкторе длинну 0
            Length++;
        }


        //2.добавление значения в начало

        public void AddToFirstPlace(int value)
        {
            if (_array.Length <= Length)
            {
                IncreaseLength();
            }

            for (int i = Length; i >= 1; i--)
            {
                _array[i] = _array[i - 1];
            }
            _array[0] = value;
            Length++;
        }



        //3. добавление значения по индексу

        public void AddByIndex(int index, int value)
        {
            if (index < 0 && index >= Length)
            {
                throw new IndexOutOfRangeException();
            }

            if (_array.Length <= Length)            // проверяем нужно ли добавить длиинны
            {
                IncreaseLength();
            }
            for (int i = Length; i > index; i--)    // последнее значение двигаем на клетку вправо
            {
                _array[i] = _array[i - 1];
            }
            _array[index] = value;
            Length++;
        }

        //4.удаление из конца одного элемента
        public void DeleteLastElement()
        {
            if (Length == 0)
            {
                throw new Exception("Length = 0");
            }
            Length--;

        }

        //5.удаление из начала одного элемента
        public void DeleteFirstElement()
        {
            if (Length == 0)
            {
                throw new Exception("Length = 0");
            }

            for (int i = 0; i < Length - 1; i++)
            {
                _array[i] = _array[i + 1];
            }

            Length--;

        }

        //6. удаление по индексу одного элемента

        public void DeleteByIndex(int index)
        {
            if (index < 0 || index >= Length)
            {
                throw new IndexOutOfRangeException();
            }
            for (int i = index; i < Length - 1; i++)    // последнее значение двигаем на клетку вправо
            {
                _array[i] = _array[i + 1];
            }
            _array[Length - 1] = 0;
            if (_array.Length / 2 >= Length)            // проверяем нужно ли убавить длиинны
            {
                DecreaseLength();
            }
            Length--;
        }

        //7.вернуть длину/ public int Length { get; private set; } 

        //8.Доступ по индексу

        public int GetByIndex(int index)
        {
            if (index < 0 || index >= Length)
            {
                throw new IndexOutOfRangeException();
            }
            return _array[index];
        }

        // 9. индекс по значению 
        public int GetIndexByValue(int value)
        {
            int Index = 0;
            for (int i = 0; i < Length; i++)
            {
                if (_array[i] == value)
                {
                    Index = i;
                }
            }
            return Index;
        }



        //10 изменение по индексу

        public void ChangeByIndex(int index, int value)
        {
            if (index < 0 || index >= Length)
            {
                throw new IndexOutOfRangeException();
            }
            _array[index] = value;
        }

        //11.реверс

        public void Reverse()
        {
            for (int i = 0; i < _array.Length / 2; i++)
            {
                int b = _array[i];
                _array[i] = _array[_array.Length - 1 - i];
                _array[_array.Length - 1 - i] = b;
            }

        }


        //12.поиск значения максимального элемента

        public int MaxElement()
        {
            int MaxEl = _array[0];
            for (int i = 1; i < _array.Length; i++)
            {

                if (_array[i] > MaxEl)
                {
                    MaxEl = _array[i];
                }
            }
            return MaxEl;
        }

        //13.поиск значения минимального элемента

        public int MinElement()
        {
            int MinEl = _array[0];
            for (int i = 1; i < _array.Length; i++)
            {

                if (_array[i] < MinEl)
                {
                    MinEl = _array[i];
                }
            }
            return MinEl;
        }




        //14. поиск индекс максимального элемента
        public int MaxIndex()
        {
            int Max = 0;

            for (int j = 1; j < _array.Length; j++)
            {
                if (_array[j] > _array[Max])
                {
                    Max = j;
                }
            }

            return Max;
        }

        //15. поиск индекс минимального элемента

        public int MinIndex()
        {
            int Min = 0;

            for (int j = 1; j < _array.Length; j++)
            {
                if (_array[j] < _array[Min])
                {
                    Min = j;
                }
            }

            return Min;
        }

        //16.сортировка по возрастанию

        public void SortMinToMax()
        {
            for (int i = 0; i < _array.Length - 1; i++)
            {
                int MinIndex = i;

                for (int j = i; j < _array.Length; j++)
                {
                    if (_array[j] < _array[MinIndex])
                    {
                        MinIndex = j;
                    }
                }

                int c = _array[i];
                _array[i] = _array[MinIndex];
                _array[MinIndex] = c;
            }

        }

        //17.сортировка по убыванию
        public void SortMaxToMin()
        {
            for (int i = 0; i < _array.Length - 1; i++)
            {
                for (int j = i + 1; j < _array.Length; j++)
                {
                    if (_array[i] < _array[j])
                    {
                        int c = _array[i];
                        _array[i] = _array[j];
                        _array[j] = c;
                    }
                }
            }


        }
        //18.удаление по значению первого


        public void DeleteElementByValue(int value)
        {

            for (int i = 0; i < Length-1; i++)
            {
                if (_array[i] == value)
                {
                    for (int j = i; j < Length - 1; j++)

                    {
                        _array[j] = _array[j + 1];
                    }
                }
            }
            _array[Length - 1] = 0;

            if (_array.Length / 2 >= Length)
            {
                DecreaseLength();
            }
            Length--;
        }


        //19. удаление по значению всех
        public void DeleteAllElementsByValue(int value)
        {
            for (int i = 0; i < Length; i++)
            {
                for (int j = 0; j < Length-1; j++)
                {
                    if (_array[j] == value)
                    {
                        _array[j] = _array[j + 1];
                    }
                }
                _array[Length - 1] = 0;
                Length--;
            }
            if (_array.Length / 2 >= Length)
            {
                DecreaseLength();
            }
        }

        
        //20.3 конструктора




        public override bool Equals(object obj)
        {
            ListArray listArray = (ListArray)obj;

            if (Length != listArray.Length)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < Length; i++)
                {
                    if (_array[i] != listArray._array[i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }


        public override string ToString()
        {
            return string.Join(";", _array.Take(Length));
        }
    }
}






    


