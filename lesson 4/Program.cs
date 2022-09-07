using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace lesson_4
{
    class Human
    {
        private int age;
        private string name;

        public int Age { 
            get { return age; }
            set { 
                if (value<0)
                    throw new Exception("Некорректный возраст");
                age = value; 
            }
        }

        public Human(string name, int age)
        {
            if (age < 0) {
                throw new Exception("Некорректный возраст");
            }else this.age = age;
            this.name = name;
        }

        public override string ToString()
        {
            return $"{name} -> {age}";
        }

    }

    class MyArray
    {
        private int[] array;        

        public int this[int index] {
            get { return array[index]; }
            set { array[index] = value; }
        }

        public int Sum()
        {
            int sum = 0;
            for (int i = 0; i < array.Length; i++) { 
                sum+=array[i];
            }
            return sum;
        }

        

        #region Конструкторы

        public MyArray(int[] array)
        {
            this.array = array;
        }

        public MyArray(int size) { 
            Random random = new Random();
            array = new int[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = random.Next(-99,100);
            }
        }

        public MyArray(string fileName)
        {
            array = LoadArrayFromFile(fileName); 
        }

        public MyArray(int count, int start, int step)
        {
            array = new int[count];
            for (int i = 0; i < count; i++)
            {
                array[i] = start;
                start += step;
            }
        }
        #endregion

        #region Методы
        public void PrintArray() {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]}\t");
            }
            Console.WriteLine();
        }

        public void Inverse()
        {
            Console.WriteLine("\nИнверсия массива:");
            int[] newArray = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                newArray[i] = array[i] * (-1);
            }
            for (int i = 0; i < newArray.Length; i++)
            {
                
                Console.Write($"{newArray[i]}\t");
            }
            Console.WriteLine();
        }
        public void Multi(int multi)
        {
            Console.WriteLine($"\nУмножение массива на число {multi}:");
            int[] newArray = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                newArray[i] = array[i] * multi;
            }
            for (int i = 0; i < newArray.Length; i++)
            {
                Console.Write($"{newArray[i]}\t");
            }
            Console.WriteLine();
        }

        public void MaxElement()
        {
            int max = array[0];
            int count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                max = max > array[i] ? max : array[i];
            }
            for (int i = 0; i < array.Length; i++)
            {
                if (max == array[i])
                {
                    count++;
                }
            }
            Console.Write($"\nМаксимальный элемент {max}, количество максимальных элементов {count};");
        }
        #endregion

        private int[] LoadArrayFromFile(string fileName) {
            if (File.Exists(fileName))
            {

                 StreamReader streamReader  = new StreamReader(fileName);
                int[] buf = new int[1000];
                int count =0;
                while (!streamReader.EndOfStream) 
                { 
                    buf[count]=int.Parse(streamReader.ReadLine());
                    count++;
                }
                int[] arr= new int[count];
                Array.Copy(buf,arr,count);
                streamReader.Close();
                return arr; 
            }
            else { 
                throw new FileNotFoundException();
            }
        }
    }





    internal class Program
    {


        private static string task(int task_1)
        {
            string indent = new string('=', System.Console.WindowWidth);
            string fio = "Латышев Никита Анатольевич";
            string task_2 = "";
            switch (task_1)
            {
                case 1:
                    task_2 = fio + "\nЗадание 1.\nа) Дописать класс для работы с одномерным массивом. Реализовать конструктор, создающий массив определенного размера и заполняющий массив числами от начального значения с заданным шагом. Создать свойство Sum, которое возвращает сумму элементов массива, метод Inverse, возвращающий новый массив с измененными знаками у всех элементов массива (старый массив, остается без изменений), метод Multi, умножающий каждый элемент массива на определённое число, свойство MaxCount, возвращающее количество максимальных элементов.\nб)**Создать библиотеку содержащую класс для работы с массивом.Продемонстрировать работу библиотеки\n";
                    Console.Write(indent);
                    Console.Write(task_2);
                    Console.Write(indent);

                    break;

                case 2:
                    task_2 = fio + "\n2. Решить задачу с логинами из урока 2, только логины и пароли считать из файла в массив. Создайте структуру Account, содержащую Login и Password.\n";
                    Console.Write(indent);
                    Console.Write(task_2);
                    Console.Write(indent);
                    break;
            }
            return task_2;
        }
        private struct Account
        {
            public string login;
            public string password;

            public bool loadFile(string fileName)
            {
                if (!File.Exists(fileName)) return false;
                StreamReader sr = new StreamReader(fileName);
                this.login = sr.ReadLine();
                this.password = sr.ReadLine();
                sr.Close();
                return true;
            }

            public void Autorization()
            {
                int i = 3;
                string login01, password01;
                do
                {
                    i--;
                    Console.WriteLine();
                    Console.Write("Введите логин:");
                    login01 = Console.ReadLine();
                    Console.Write("Введите пароль:");
                    password01 = Console.ReadLine();
                    if (getAuthorization(login01, password01))
                    {
                        Console.Clear();
                        Console.SetCursorPosition(Console.WindowWidth / 2 - 13, Console.WindowHeight / 2);
                        Console.Write("Вы успешно авторизовались!");
                        break;
                    }
                    else
                    {
                        if (i > 0) { Console.Write("Осталось попыток: " + i); }
                        else
                        {
                            Console.Clear();
                            Console.SetCursorPosition(Console.WindowWidth / 2 - 18, Console.WindowHeight / 2);
                            Console.WriteLine("Исчерпан лимит на ввод логина/пароля");
                            break;
                        }
                    }
                }
                while (i > 0);
            }

            private bool getAuthorization(string login01, string password01)
            {
                return login == login01 && password == password01 ? true : false;
            }
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.Write("Введите задание от 1 до 2: ");
                int num = int.Parse(System.Console.ReadLine());
                switch (num)
                {
                    case 1:
                        task(num);
                        Console.Write("Введите количество элементов массива:");
                        int count = int.Parse(Console.ReadLine());
                        Console.Write("Введите начальное значение массива:");
                        int start = int.Parse(Console.ReadLine());
                        Console.Write("Введите шаг:");
                        int step = int.Parse(Console.ReadLine());
                        MyArray myArray = new MyArray(count, start, step);
                        myArray.PrintArray();
                        Console.Write($"Сумма элементов массива {myArray.Sum()};");
                        myArray.Inverse();
                        Console.Write("Введите число для умножения массива:");
                        int multi = int.Parse(Console.ReadLine());
                        myArray.Multi(multi);
                        myArray.MaxElement();
                        Console.ReadKey();
                        break;
                    case 2:
                        task(num);
                        Account account = new Account();
                        account.loadFile(AppDomain.CurrentDomain.BaseDirectory + "login.txt");
                        account.Autorization();
                        System.Console.ReadLine();
                        break;
                    default:
                        return;
                }

            }






                        /*MyArray myArray = new MyArray(AppDomain.CurrentDomain.BaseDirectory+"MyArray.txt");
                        myArray[2] = 5;
                        myArray.PrintArray();

                        Console.Write("Укажите возраст:");
                        int age = int.Parse(Console.ReadLine());
                        try
                        {
                            Human human = new Human("Никита", age);
                            human.Age = -36;
                            Console.WriteLine(human.ToString());


                        }
                        catch (InvalidOperationException) { 

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            Console.WriteLine("Повторите попытку ввода.");
                        }
                        */
                        Console.ReadLine();

        }
    }
}
