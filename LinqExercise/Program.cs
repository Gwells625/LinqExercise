using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;

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
            var sum = numbers.Sum();
            Console.WriteLine($"Sum: {sum}");

            //TODO: Print the Average of numbers
            var average = numbers.Average();
            Console.WriteLine($"Average: {average}");

            //TODO: Order numbers in ascending order and print to the console
            var ascending = numbers.OrderBy(x => x);
            Console.WriteLine("Ascending:");
            foreach (var number in ascending)
                Console.WriteLine(number);

            //TODO: Order numbers in descending order and print to the console
            var descending = numbers.OrderByDescending(x => x);
            Console.WriteLine("Descending:");
            foreach (var number in descending)
                Console.WriteLine(number);

            //TODO: Print to the console only the numbers greater than 6
            var greaterThanSix = numbers.Where(x => x > 6);
            Console.WriteLine("GreaterThanSix:");
            foreach (var number in greaterThanSix)
                Console.WriteLine(number);

            //TODO: Order numbers in any order (ascending or desc) but only print 4 of them **foreach loop only!**
            var firstFour = numbers.OrderBy(x => x).Take(4);
            Console.WriteLine("FirstFour (ascending):");
            foreach (var number in firstFour)
                Console.WriteLine(number);

            //TODO: Change the value at index 4 to your age, then print the numbers in descending order
            numbers[4] = 32;
            var updatedDescending = numbers.OrderByDescending(x => x);
            Console.WriteLine("UpdatedDescending (index 4 = 32):");
            foreach (var number in updatedDescending)
                Console.WriteLine(number);

            // List of employees ****Do not remove this****
            var employees = CreateEmployees();

            //TODO: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in ascending order by FirstName.
            var filteredByInitials = employees
                .Where(x => x.FirstName.StartsWith("C") || x.FirstName.StartsWith("S"))
                .OrderBy(x => x.FirstName);
            Console.WriteLine("Employees with FirstName starting with C or S:");
            foreach (var employee in filteredByInitials)
                Console.WriteLine(employee.FirstName);

            //TODO: Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result.
            var overTwentySix = employees
                .Where(x => x.Age > 26)
                .OrderBy(x => x.Age)
                .ThenBy(x => x.FirstName);
            Console.WriteLine("Employee over the age 26 (by Age then FirstName:");
            foreach (var employee in overTwentySix)
                Console.WriteLine($"Name: {employee.FirstName}, Age: {employee.Age}");

            //TODO: Print the Sum of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
            var filteredYOE = employees
                .Where(x => x.YearsOfExperience <= 10 && x.Age > 35)
                .Sum(x => x.YearsOfExperience);
            Console.WriteLine($"Sum of YOE (YOE <= 10 && Age <= 35): {filteredYOE}");

            //TODO: Now print the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
            var averageYOE = employees
                .Where(x => x.YearsOfExperience > 10 && x.Age > 35)
                .Average(x => x.YearsOfExperience);
            Console.WriteLine($"Average of YOE (YOE <= 10 && Age > 35): {averageYOE}");

            //TODO: Add an employee to the end of the list without using employees.Add()
            employees = employees.Append(new Employee
            {
                FirstName = "John",
                LastName = "Richardson",
                Age = 38,
                YearsOfExperience = 10
            }).ToList();
            Console.WriteLine("Added new employee:");
            foreach (var employee in employees)
                Console.WriteLine(employee.FullName);


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
