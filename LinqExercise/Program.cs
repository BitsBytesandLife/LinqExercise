using System;
using System.Collections.Generic;
using System.Linq;

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
             *
             * HINT: Use the List of Methods defined in the Lecture Material Google Doc ***********
             *
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //Print the Sum and Average of numbers
            Console.WriteLine($"Sum of Array: {numbers.Sum()}");
            Console.WriteLine($"Average of the Array: {numbers.Average()}");
            //Order numbers in ascending order and decsending order. Print each to console.
            var numArr = numbers.OrderBy(num => num);
            //Print to the console only the numbers greater than 6
            var numGreaterThenSix = numArr.Where(x => x > 6);
            Console.WriteLine();
            foreach (var item in numGreaterThenSix)
            {
                Console.WriteLine(item);
            }
            //Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            Console.WriteLine("Order numbers in any order(acsending or desc) but only print 4 of them");
            var numArrTake4 = numArr.Take(4);
            Array.ForEach(numArrTake4.ToArray(), n => Console.Write($"{n}"));
            Console.WriteLine();
            //Change the value at index 4 to your age, then print the numbers in decsending order
            Console.WriteLine("Change the value at index 4 to your age, then print the numbers in decsending order");
            numbers[4] = 43;
            var numArrOrderByDesc = numbers.OrderByDescending(num => num);

            Array.ForEach(numArrOrderByDesc.ToArray(), x => Console.WriteLine(x));
            // List of employees ***Do not remove this***
            var employees = CreateEmployees();

            //Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S.
            //Order this in acesnding order by FirstName.
            Console.WriteLine("Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S.\n" +
                "Order this in acesnding order by FirstName.");
            var empAcesndingOrderyBuFirstName = employees.
                                                Where(x => x.FirstName.StartsWith('C') || x.FirstName.StartsWith('S')).
                                                OrderBy(x => x.FirstName);
            foreach (var item in empAcesndingOrderyBuFirstName)
            {
                Console.WriteLine(item.FirstName);
            }

            //Print all the employees' FullName and Age who are over the age 26 to the console.
            //Order this by Age first and then by FirstName in the same result.
            Console.WriteLine("Print all the employees' FullName and Age who are over the age 26 to the console.\n " +
                               "Order this by Age first and then by FirstName in the same result.");
            
            var printAllEmpFullNameWithAgeOver26 = employees.
                                                   Where(x => x.Age > 26).
                                                   OrderBy(x => x.Age);

            //foreach (var item in printAllEmpFullNameWithAgeOver26)
            //{
            //    Console.WriteLine($"Age: {item.Age} Full Name: {item.FullName}");
            //}

            Array.ForEach(printAllEmpFullNameWithAgeOver26.ToArray(), n => Console.WriteLine($"Age: {n.Age} Full Name: {n.FullName}"));

            //Print the Sum and then the Average of the employees' YearsOfExperience
            //if their YOE is less than or equal to 10 AND Age is greater than 35
            var yoe = employees.
                       Where(x => x.Age > 35 && x.YearsOfExperience <= 10);

            Console.WriteLine(yoe.Sum(x=>x.YearsOfExperience));

            Console.WriteLine(yoe.Average(x=>x.YearsOfExperience));

            //Add an employee to the end of the list without using employees.Add()
            var AllEmp = employees.OrderBy(x => x.FullName);

            employees =   employees.Append(new Employee("Brian", "King", 43, 10)).ToList();

            foreach (var item in employees)
            {
                Console.WriteLine($"{item.FullName}, {item.Age}, {item.YearsOfExperience}");
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
