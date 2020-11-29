using System;
using Lists;


namespace dogs
{
    class Program
    {
        static void Main(string[] args)
        {
            Dog sharik = new Dog("Shar"); //объект класса - сложная переменная
            Dog gleb = new Dog("Glebbb");   //тоже объект

            //sharik.name = "Sharik";
            //gleb.name = "Gleb";

            Console.WriteLine(sharik.name);
            Console.WriteLine(gleb.name);
            Console.WriteLine();
            Console.WriteLine(sharik.health);
            Console.WriteLine(gleb.health);
            Console.WriteLine();

            gleb.Run(10, 2);
            sharik.Eat(10);

            Console.WriteLine(sharik.name);
            Console.WriteLine(sharik.health);
            Console.WriteLine(sharik.weight);
           // gleb.weight = 1000; 

            Console.WriteLine(gleb.name);
            Console.WriteLine(gleb.health);
            Console.WriteLine(gleb.weight);

            ShowDogInfo(gleb);
            ShowDogInfo(sharik); //передали в метод ShowDogInfo шарика и глеба

            //Dog[] a = new Dog[] { new Dog(), new Dog() };// массив собак

            gleb.health = 50;

            Console.ReadLine();

        }

        static public void ShowDogInfo(Dog dog)//когда на вход получаем класс (Dog) мы имеем в виду что получаем обЪект класса
        {
            Console.WriteLine(dog.name);
            Console.WriteLine(dog.weight);
            Console.WriteLine(dog.age);
            Console.WriteLine(dog.health);
            Console.WriteLine();

            
        }
    }
}
