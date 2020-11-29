using System;

namespace Lists
{
    public class Dog //это класс (сущность). если было бы статик, означало бы одну единственную конкретную собаку 
    {                // статик классы особо в жизни не используют
        public string name; //поля внутри класса, можно задавать стартовые значения
        
        public string breed; 
        
        public string color;
        public int weight;

        
        //private int weight=10;//все поля принято называть через нижнее подчеркивание, тк поле важная настройка по сущности
        
        public int age=0; // _ - упрощает чтение программы
        
        public int health =100;
        // каждая сущность выполняет методы по отдельности

        //public int Weight { get; private set; } = 10; // своиства принято называть с большой буквы
                                                      // благодаря свойствам, можно инкапсулировать разные кусочки

        private int _health = 80;
        
        public int Health
        {
            get
            {
                return _health * 2; 
            }
            set
            {   if (value > 50)
                {
                    _health = value;
                }
                else
                {
                    throw new Exception();
                }
            }
        }

        //если параметры методов(name строкой ниже) называются так же как поля классов, приоритет всегда
        //у параметром методов или у перемнных созданных внутри этого метода 
        //чтобы обратится к полю метода - надо добавить модификатор this 
        //this - обращение к объекту класса, который вызвал этод метод

        public Dog(string name )//конструктор, у него могут быть поля. По умолчанию все конструкторы всез методов выглядят вот так
        {                       // работают области видимости, если поля  

            this.name = name;
        }


        public void Eat (int FoodSize)   //метод . этот методозначает что собака ест. 
                                         //Метод обращен к сущности собака
        {
            weight += FoodSize;
            health += FoodSize / weight;

        }

        public void Run(int distance, int time)  //Войдовые методы используются в формате методов которые влияют на поля
                                                 //Например если это методы сущности , которые изменяют характерристики сущности.
        {
            weight -= distance / time;
            health += distance / time;
        }        

        public int GetWeight()
        {
            return weight;
        }



    }
}
