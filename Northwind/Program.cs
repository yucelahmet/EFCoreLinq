using Northwind.Data;
using Northwind.Models;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace Northwind
{
	internal class Program
	{
		static void Main(string[] args)
		{
			NorthwindContext db = new NorthwindContext();

			//db.Employees.ToList();

			//Bütün employeelerin adlarını ve soyadlarını ekrana satır satır yazdıran döngüyü yazınız.

			//var result = db.Employees.ToList();

			//foreach ( var employee in result )
			//{
			//	Console.WriteLine( employee.FirstName+" "+employee.LastName );
			//}

			//1.soru cevabı=select CategoryName,Description from Categories order by CategoryName
			//var result = db.Categories.Select(c => new {c.CategoryName,c.Description}).OrderBy(c=>c.CategoryName).ToList();
			//yada böyle
			//var result = db.Categories.Select(c => new Category { CategoryName=c.CategoryName, Description=c.Description }).OrderBy(c => c.CategoryName).ToList();
			//foreach (var category in result)
			//{
			//	Console.WriteLine(category.CategoryName+" : "+category.Description);
			//}

			//2.soru cevabı=SELECT ContactName,ContactTitle,CompanyName,Phone FROM Customers ORDER BY Phone
			//var result = db.Customers.Select(c => new Customer { ContactName = c.ContactName, ContactTitle = c.ContactTitle, CompanyName=c.CompanyName, Phone=c.Phone }).OrderBy(c => c.Phone).ToList();
			//foreach (var customer in result)
			//{
			//	Console.WriteLine(customer.ContactName+" : "+ customer.ContactTitle + " : " + customer.CompanyName + " : " + customer.Phone);
			//}

		
			//3.soru cevabı=SELECT FirstName,LastName,HireDate FROM Employees ORDER BY HireDate DESC
			//var result = db.Employees.Select(c => new Employee { FirstName = c.FirstName, LastName = c.LastName, HireDate = c.HireDate }).OrderByDescending(c => c.HireDate).ToList();
			//foreach (var employee in result)
			//{
			//	Console.WriteLine(employee.FirstName + " : " + employee.LastName + " : " + employee.HireDate);
			//}



			//4.soru cevabı=SELECT OrderID, OrderDate, ShippedDate, CustomerID, Freight FROM Orders ORDER BY Freight DESC
			var result = db.Orders.Select(c => new Order { OrderId = c.OrderId, OrderDate = c.OrderDate, ShippedDate = c.ShippedDate, CustomerId = c.CustomerId, Freight = c.Freight }).OrderByDescending(c => c.Freight).ToList();
			foreach (var order in result)
			{
				Console.WriteLine(order.OrderId + " : " + order.OrderDate + " : " + order.ShippedDate + " : " + order.CustomerId + " : " + order.Freight);
			}

		}
	}
}