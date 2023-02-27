using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //TODO: Print the Sum of numbers
            var sumNumbers = numbers.Sum();
            Console.WriteLine("This is the Sum of all the numbers");
            Console.WriteLine(sumNumbers.ToString());

            //TODO: Print the Average of numbers
            var averageNumbers = numbers.Average();
            Console.WriteLine("This is the Average of all the numbers");
            Console.WriteLine(averageNumbers.ToString());

            //TODO: Order numbers in ascending order and print to the console
            var ascendingNumbers = numbers.OrderBy(x => x == 0 ? 0 : x);
            Console.WriteLine("This is the numbers placed in ascending order");
            foreach (int number in ascendingNumbers)
            {
                Console.WriteLine(number);
            }


            //TODO: Order numbers in decsending order and print to the console
            var descendingNumbers = numbers.OrderByDescending(x => x);
            Console.WriteLine("This is the numbers placed in descending order");
            foreach (int number in descendingNumbers)
            {
                Console.WriteLine(number);
            }

            //TODO: Print to the console only the numbers greater than 6
            var overSix = numbers.Where(x => x > 6);
            Console.WriteLine("This is the numbers greater than 6");
            foreach (int number  in overSix)
            {
                Console.WriteLine(number);
            }


            //TODO: Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            var fourNumbers = numbers.Take(4);
            Console.WriteLine("This is the first four numbers");
            foreach (int number in fourNumbers)
            {
                Console.WriteLine(number);
            }

            //TODO: Change the value at index 4 to your age, then print the numbers in decsending order
            var numberAge = numbers.Select((i, x) => x == 3 ? 29 : x).ToArray();
            Console.WriteLine("This is numbers where my age replaces the 4th value");
            foreach(int number in numberAge)
            {
                Console.WriteLine(number);
            }

            // List of employees ****Do not remove this****
            var employees = CreateEmployees();

            //TODO: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in ascending order by FirstName.
            var fullNames = employees.Where(person => person.FirstName.StartsWith('C') || person.FirstName.StartsWith ('S')).OrderBy (person => person.FirstName);
           Console.WriteLine("Employees whose names starts with S or C");
            foreach (var employee in fullNames)
            {
                Console.WriteLine(employee.FullName);
            }


            //TODO: Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result.
            var overtwentySix = employees.Where(person => person.Age > 26)
                .OrderBy(person => person.Age).ThenBy(person => person.FirstName);
            Console.WriteLine("Employees Fullname and age who are over 26 ordered by Age then First name");
            foreach (var employee in overtwentySix)
            {
                Console.WriteLine($"Age:{employee.Age} Full Name:{employee.FullName}");
            }

            //TODO: Print the Sum and then the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
            var experience = employees.Where(person => person.YearsOfExperience <= 10 || person.Age > 35);
            var sumYears = experience.Sum( person => person.YearsOfExperience);
            var averageYears = experience.Average( person => person.YearsOfExperience);

            Console.WriteLine($"Sum {sumYears} Average {averageYears}");



            //TODO: Add an employee to the end of the list without using employees.Add()
            employees = employees.Append(new Employee("first" , "last" , 100, 100)).ToList();
            foreach ( var person in employees)
            {
                Console.WriteLine($"{person.FirstName} {person.Age}");
            }


            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
