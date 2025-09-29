
using System.Text.Json;
using Amazon.Data;
using Amazon.Domain;
namespace MigrationApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LoadDefaultEmployeesData();


        }

        private static void LoadDefaultEmployeesData()
        {
            // Read The Data.json File
            string contentAsString = File.ReadAllText("Data.json"); // retutn string
            // Change the String into a List<Employee>
         var employees= JsonSerializer.Deserialize<List<Employee>>(contentAsString);

           // Call context to AddRange the new employees

            using(var context = new AmazonContext())
            {
                // Add Bulk employees
                context.Employees.AddRange(employees);
                context.SaveChanges();
            }        
        }
    }
}
