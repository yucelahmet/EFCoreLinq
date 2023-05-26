using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualBasic;
using Northwind.Data;
using Northwind.Models;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Numerics;
using System.Runtime.CompilerServices;

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

			//1.Select CategoryName and Description from the Categories table sorted by CategoryName.
			//1.soru cevabı=select CategoryName,Description from Categories order by CategoryName
			//var result = db.Categories.Select(c => new {c.CategoryName,c.Description}).OrderBy(c=>c.CategoryName).ToList();
			//yada böyle
			//var result = db.Categories.Select(c => new Category { CategoryName=c.CategoryName, Description=c.Description }).OrderBy(c => c.CategoryName).ToList();
			//foreach (var category in result)
			//{
			//	Console.WriteLine(category.CategoryName+" : "+category.Description);
			//}

			//2.Select ContactName, CompanyName, ContactTitle, and Phone from the Customers table sorted by Phone.
			//2.soru cevabı=SELECT ContactName,ContactTitle,CompanyName,Phone FROM Customers ORDER BY Phone
			//var result = db.Customers.Select(c => new Customer { ContactName = c.ContactName, ContactTitle = c.ContactTitle, CompanyName=c.CompanyName, Phone=c.Phone }).OrderBy(c => c.Phone).ToList();
			//foreach (var customer in result)
			//{
			//	Console.WriteLine(customer.ContactName+" : "+ customer.ContactTitle + " : " + customer.CompanyName + " : " + customer.Phone);
			//}


			//3.	Create a report showing employees' first and last names and hire dates sorted from newest to oldest employee.
			//3.soru cevabı=SELECT FirstName,LastName,HireDate FROM Employees ORDER BY HireDate DESC
			//var result = db.Employees.Select(e => new Employee { FirstName = e.FirstName, LastName = e.LastName, HireDate = e.HireDate }).OrderByDescending(e => e.HireDate).ToList();
			//foreach (var employee in result)
			//{
			//	Console.WriteLine(employee.FirstName + " : " + employee.LastName + " : " + employee.HireDate);
			//}



			//4.	Create a report showing Northwind's orders sorted by Freight from most expensive to cheapest. Show OrderID, OrderDate, ShippedDate, CustomerID, and Freight.
			//4.soru cevabı=SELECT OrderID, OrderDate, ShippedDate, CustomerID, Freight FROM Orders ORDER BY Freight DESC
			//var result = db.Orders.Select(o => new Order { OrderId = o.OrderId, OrderDate = o.OrderDate, ShippedDate = o.ShippedDate, CustomerId = o.CustomerId, Freight = o.Freight }).OrderByDescending(o => o.Freight).ToList();
			//foreach (var order in result)
			//{
			//	Console.WriteLine(order.OrderId + " : " + order.OrderDate + " : " + order.ShippedDate + " : " + order.CustomerId + " : " + order.Freight);
			//}


			//5.	Select CompanyName, Fax, Phone, HomePage and Country from the Suppliers table sorted by Country in descending order and then by CompanyName in ascending order.
			//5.soru cevabı=SELECT CompanyName, Fax, Phone, HomePage, Country FROM Suppliers ORDER BY Country DESC, CompanyName ASC;
			//var result = db.Suppliers.Select(s => new Supplier { CompanyName = s.CompanyName, Fax = s.Fax, Phone = s.Phone, HomePage = s.HomePage, Country = s.Country }).OrderByDescending(s => s.Country).ThenBy(s => s.CompanyName).ToList();
			//foreach (var supplier in result)
			//{
			//	Console.WriteLine(supplier.CompanyName + " : " + supplier.Fax + " : " + supplier.Phone + " : " + supplier.HomePage + " : " + supplier.Country);
			//}

			// YA DA BU ŞEKİLDE
			//var result = db.Suppliers.Select(s => new Supplier
			//{
			//    CompanyName=s.CompanyName,
			//    Fax=s.Fax,
			//    Phone=s.Phone,
			//    HomePage=s.HomePage,
			//    Country=s.Country
			//}).OrderByDescending(s=>s.Country).ThenBy(s => s.CompanyName).ToList<Supplier>();



			//foreach (var supplier in result)
			//{
			//    Console.WriteLine(supplier.CompanyName + "\t " +supplier.Country);
			//}


			//6.	Create a report showing all the company names and contact names of Northwind's customers in Buenos Aires.
			//6.soru cevabı=SELECT CompanyName, ContactName FROM Customers WHERE City='Buenos Aires';
			//var result = db.Customers.Where(c => c.City == "Buenos Aires").Select(c => new Customer { CompanyName = c.CompanyName, ContactName = c.ContactName }).ToList();
			//foreach (var customer in result)
			//{
			//	Console.WriteLine(customer.CompanyName + " : " + customer.ContactName);
			//}



			//7.	Create a report showing the product name, unit price and quantity per unit of all products that are out of stock.
			//7.soru cevabı=SELECT ProductName, UnitPrice,QuantityPerUnit FROM Products WHERE UnitsInStock=0;
			//var result = db.Products.Where(p => p.UnitsInStock == 0).Select(p => new Product { ProductName = p.ProductName, UnitPrice = p.UnitPrice, QuantityPerUnit = p.QuantityPerUnit }).ToList();
			//foreach (var product in result)
			//{
			//	Console.WriteLine(product.ProductName + " : " + product.UnitPrice + " : " + product.QuantityPerUnit);
			//}




			//8.	Create a report showing the order date, shipped date, customer id, and freight of all orders placed on May 19, 1997.
			//8.soru cevabı=SELECT OrderDate, ShippedDate, CustomerID, Freight FROM Orders WHERE OrderDate='1997.05.19';
			//ya da bu şekilde daha iyi cevabı=SELECT OrderDate, ShippedDate, CustomerID, Freight FROM Orders WHERE OrderDate=DATEFROMPARTS(1997,05,19);
			//var result = db.Orders.Where(o => o.OrderDate == new DateTime(1997, 5, 19)).Select(o => new Order { OrderDate = o.OrderDate, ShippedDate = o.ShippedDate, CustomerId = o.CustomerId, Freight = o.Freight }).ToList();
			//foreach (var order in result)
			//{
			//	Console.WriteLine(order.OrderDate + " : " + order.ShippedDate + " : " + order.CustomerId + " : " + order.Freight);
			//}



			//9.	Create a report showing the first name, last name, and country of all employees not in the United States.
			//8.soru cevabı=SELECT FirstName, LastName, Country FROM Employees WHERE Country!= 'USA';
			// Yada SELECT FirstName, LastName, Country FROM Employees WHERE Country<> 'USA';
			// yada SELECT FirstName, LastName, Country FROM Employees WHERE Country NOT IN ('USA');
			//var result = db.Employees.Where(e => e.Country!= "USA").Select(e => new Employee { FirstName = e.FirstName, LastName = e.LastName, Country = e.Country }).ToList();
			//// Projection
			//// Süslü parantezle herhangi bir parametreye assing etmeden nesne oluşturmaya Object Initialization deniyor.

			//foreach (var employee in result)
			//{
			//	Console.WriteLine(employee.FirstName + " : " + employee.LastName + " : " + employee.Country);
			//}



			//10.	Create a report that shows the employee id, order id, customer id, required date, and shipped date of all orders that were shipped later than they were required.
			//10.soru cevabı=SELECT EmployeeID, OrderID, CustomerID,RequiredDate,ShippedDate FROM Orders WHERE ShippedDate > RequiredDate;
			//var result = db.Orders.Where(o => o.ShippedDate> o.RequiredDate).Select(o => new Order { EmployeeId = o.EmployeeId, OrderId = o.OrderId, CustomerId = o.CustomerId, RequiredDate = o.RequiredDate, ShippedDate = o.ShippedDate }).ToList();
			//foreach (var order in result)
			//{
			//	Console.WriteLine(order.EmployeeId + " : " + order.OrderId + " : " + order.CustomerId + " : " + order.RequiredDate + " : " + order.ShippedDate);
			//}


			//11.	Create a report that shows the city, company name, and contact name of all customers who are in cities that begin with "A" or "B."
			//11.soru cevabı=SELECT City, CompanyName, ContactName FROM Customers WHERE City like 'A%' or City like 'B%';
			//var result = db.Customers.Where(c => c.City.StartsWith("A") || c.City.StartsWith("B")).ToList();
			//foreach (var customer in result)
			//{
			//	Console.WriteLine(customer.City + " : "+customer.CompanyName + " : " +customer.ContactName);
			//}



			//12.	Create a report that shows all orders that have a freight cost of more than $500.00.
			//12.soru cevabı=SELECT * FROM Orders WHERE Freight>500
			//var result = db.Orders.Where(o => o.Freight>500).ToList();
			//foreach (var order in result)
			//{
			//	Console.WriteLine(order.CustomerId + " : " + order.ShipName);
			//}


			//13.	Create a report that shows the product name, units in stock, units on order, and reorder level of all products that are up for reorder
			//13.soru cevabı=SELECT ProductName,UnitsInStock, UnitsOnOrder,ReorderLevel FROM Products WHERE UnitsInStock <= ReorderLevel;
			//var result = db.Products.Where(p => p.UnitsInStock <= p.ReorderLevel);
			//foreach (var order in result)
			//{
			//	Console.WriteLine(order.ProductName + " : " + order.UnitsInStock + " : " + order.UnitsOnOrder + " : " + order.ReorderLevel);
			//}



			//14.	Create a report that shows the company name, contact name and fax number of all customers that have a fax number.
			//14.soru cevabı=SELECT CompanyName,ContactName,Fax FROM Customers WHERE Fax is not null ;
			//var result = db.Customers.Where(c => c.Fax != null);
			//foreach (var customer in result)
			//{
			//	Console.WriteLine(customer.CompanyName + " : " + customer.ContactName + " : " + customer.Fax);
			//}


			//15.	Create a report that shows the first and last name of all employees who do not report to anybody
			//15.soru cevabı=SELECT * FROM Employees WHERE ReportsTo is null ;
			//var result = db.Employees.Where(e => e.ReportsTo == null);
			//foreach (var employee in result)
			//{
			//	Console.WriteLine(employee.FirstName + " : " + employee.LastName);
			//}



			//16.	Create a report that shows the company name, contact name and fax number of all customers that have a fax number. Sort by company name.
			//16.soru cevabı=SELECT CompanyName,ContactName,Fax FROM Customers WHERE Fax is not null order by CompanyName
			//var result = db.Customers.Where(c => c.Fax != null).OrderBy(c=>c.CompanyName).Select(c=> new Customer
			//{
			//	CompanyName= c.CompanyName,
			//	ContactName= c.ContactName,
			//	Fax= c.Fax
			//});
			//foreach (var customer in result)
			//{
			//	Console.WriteLine(customer.CompanyName + " : " + customer.ContactName + " : " + customer.Fax);
			//}



			//17.	Create a report that shows the city, company name, and contact name of all customers who are in cities that begin with "A" or "B." Sort by contact name in descending order
			//17.soru cevabı=SELECT City,CompanyName,ContactName FROM Customers WHERE City like 'A%'or City like 'B%'  order by ContactName DESC
			//var result = db.Customers.Where(c => c.City.StartsWith("A") || c.City.StartsWith("B")).OrderByDescending(c => c.ContactName).Select(c => new Customer
			//{
			//	City = c.City,
			//	CompanyName = c.CompanyName,
			//	ContactName = c.ContactName,
			//});
			//foreach (var customer in result)
			//{
			//	Console.WriteLine(customer.City + " : " + customer.CompanyName + " : " + customer.ContactName);
			//}



			//18.	Create a report that shows the first and last names and birth date of all employees born in the 1950s.
			//18.soru cevabı=Select * from Employees where YEAR(BirthDate)>=1950 and YEAR(BirthDate)<1960
			//var result = db.Employees.Where(e => e.BirthDate.Value.Year>=1950 && e.BirthDate.Value.Year < 1960).Select(c => new Employee
			//{
			//	FirstName = c.FirstName,
			//	LastName = c.LastName,
			//	BirthDate = c.BirthDate,
			//});
			//foreach (var employee in result)
			//{
			//	Console.WriteLine(employee.FirstName + " : " + employee.LastName + " : " + employee.BirthDate);
			//}



			//19.	Create a report that shows the product name and supplier id for all products supplied by Exotic Liquids, Grandma Kelly's Homestead, and Tokyo Traders. Hint: you will need to first do a separate SELECT on the Suppliers table to find the supplier ids of these three companies.
			//19.soru cevabı=select ProductName, SupplierID from Products where SupplierID in (select SupplierID from Suppliers where CompanyName in ('Tokyo Traders', 'Exotic Liquids', 'Grandma Kelly''s Homestead'))
			//List<string> list = new List<string>();
			//list.Add("Tokyo Traders");
			//list.Add("Exotic Liquids");
			//list.Add("Grandma Kelly's Homestead");

			////var result2=db.Suppliers.Where(s=> list.Contains(s.CompanyName)).Select(s=>s.SupplierId).ToList();
			////var result = db.Products.Where(p => result2.Contains((int)p.SupplierId)).Select(p => new Product
			////{
			////	ProductName = p.ProductName,
			////	SupplierId = p.SupplierId,
			////});

			//var result = db.Products.Where(p => db.Suppliers.Where(s => list.Contains(s.CompanyName)).Select(s => s.SupplierId).ToList().Contains((int)p.SupplierId)).Select(p => new Product
			//{
			//	ProductName = p.ProductName,
			//	SupplierId = p.SupplierId,
			//});
			//foreach (var product in result)
			//{
			//	Console.WriteLine(product.ProductName + " : " + product.SupplierId);
			//}



			//20.	Create a report that shows the shipping postal code, order id, and order date for all orders with a ship postal code beginning with "02389".
			//20.soru cevabı=

			//var result = db.Orders.Where(o => o.ShipPostalCode.StartsWith("02389")).Select(o => new Order
			//{
			//	ShipPostalCode = o.ShipPostalCode,
			//	OrderId = o.OrderId,
			//	OrderDate = o.OrderDate
			//});
			//foreach (var order in result)
			//{
			//	Console.WriteLine(order.ShipPostalCode + " : " + order.OrderId + " : " + order.OrderDate);
			//}



			//21.	Create a report that shows the contact name and title and the company name for all customers whose contact title does not contain the word "Sales".
			//21.soru cevabı=Select ContactName,ContactTitle,CompanyName from Customers where ContactTitle not like '%Sales%'

			//var result = db.Customers.Where(customer => !customer.ContactTitle.Contains("Sales")).Select(customer => new Customer
			//{
			//	ContactName = customer.ContactName,
			//	ContactTitle = customer.ContactTitle,
			//	CompanyName = customer.CompanyName
			//});
			//foreach (var order in result)
			//{
			//	Console.WriteLine(order.ContactName + " : " + order.ContactTitle + " : " + order.CompanyName);
			//}



			//22.	Create a report that shows the first and last names and cities of employees from cities other than Seattle in the state of Washington.
			//22.soru cevabı=Select FirstName,LastName,City from Employees where City!='Seattle'and Region='WA'

			//var result = db.Employees.Where(e => e.City!="Seattle" && e.Region=="WA").Select(e => new Employee
			//{
			//	FirstName = e.FirstName,
			//	LastName = e.LastName,
			//	City = e.City
			//});
			//foreach (var employee in result)
			//{
			//	Console.WriteLine(employee.FirstName + " : " + employee.LastName + " : " + employee.City);
			//}


			//23.	Create a report that shows the company name, contact title, city and country of all customers in Mexico or in any city in Spain except Madrid.
			//23.soru cevabı=Select CompanyName,ContactTitle,City, Country from Customers where (Country='Mexico' or Country='Spain') and City!='Madrid' 

			//var result = db.Customers.Where(c => c.Country == "Mexico" || ( c.Country=="Spain" && !c.City.Contains("Madrid"))).Select(c => new Customer
			//{
			//CompanyName = c.CompanyName,
			//	ContactTitle = c.ContactTitle,
			//	City = c.City,
			//	Country = c.Country
			//});
			//foreach (var customer in result)
			//{
			//	Console.WriteLine(customer.CompanyName + " : " + customer.ContactTitle + " : " + customer.City + " : " + customer.Country);
			//}



			//25.	Create a report that shows the units in stock, unit price, the total price value of all units in stock, the total price value of all units in stock rounded down, and the total price value of all units in stock rounded up. Sort by the total price value descending.
			//25.soru cevabı=Select UnitsInStock,UnitPrice,(UnitsInStock*UnitPrice) as TotalPrice, FLOOR(UnitsInStock * UnitPrice) as TotalPriceRoundedDown, CEILING(UnitsInStock * UnitPrice) as TotalPriceRoundedUp from Products

			//var result = db.Products.Select(p => new
			//{
			//	p.UnitsInStock,
			//	p.UnitPrice,
			//	TotalPrice = p.UnitsInStock* p.UnitPrice,
			//	TotalPriceRoundedDown = Math.Floor((short)p.UnitsInStock * (decimal)p.UnitPrice),
			//	TotalPriceRoundedUp = Math.Ceiling((short)p.UnitsInStock * (decimal)p.UnitPrice)
			//});
			//foreach (var product in result)
			//{
			//	Console.WriteLine(product.UnitsInStock + " : " + product.UnitPrice + " : " + product.TotalPrice + " : " + product.TotalPriceRoundedDown + " : " + product.TotalPriceRoundedUp);
			//}




			//26.	SQL SERVER AND MYSQL USERS ONLY: In an earlier demo, you saw a report that returned the age of each employee when hired. That report was not entirely accurate as it didn't account for the month and day the employee was born. Fix that report, showing both the original (inaccurate) hire age and the actual hire age. The result will look like this.
			//26.soru cevabı=Select FirstName,(YEAR(HireDate)-YEAR(BirthDate)) as HireAgeInaccurate,DATEDIFF(day, BirthDate, HireDate) / 365.4 as HireAgeAccurate from Employees

			//var result = db.Employees.Select(e => new
			//{
			//	e.FirstName,
			//	HireAgeInaccurate = e.HireDate.Value.Year-e.BirthDate.Value.Year,
			//	HireAgeAccurate = (e.HireDate - e.BirthDate).Value.Days/365.4
			//});
			//foreach (var employee in result)
			//{
			//	Console.WriteLine(employee.FirstName + " : " + employee.HireAgeInaccurate + " : " + employee.HireAgeAccurate);
			//}




			//27.	Create a report that shows the first and last names and birth month (as a string) for each employee born in the current month.
			//27.soru cevabı=Select FirstName,LastName, DATENAME(Month,BirthDate) as BirthMonth from Employees where MONTH(BirthDate)=MONTH(GETDATE())

			//var result = db.Employees.Where(e=>e.BirthDate.Value.Month==DateTime.Now.Month).Select(e => new 
			//{
			//	e.FirstName,
			//	e.LastName,
			//	BirthMonth = e.BirthDate.Value.ToString("MMMM")
			//});
			//foreach (var product in result)
			//{
			//	Console.WriteLine(product.FirstName + " : " + product.LastName + " : " + product.BirthMonth);
			//}




			//28.	Create a report that shows the contact title in all lowercase letters of each customer contact.
			//28.soru cevabı=SELECT LOWER(ContactTitle) AS LowercaseContactTitle FROM Customers

			//var result = db.Customers.Select(c => new Customer
			//{
			//	ContactTitle=c.ContactTitle.ToLower()

			//});

			// Yada Şöyle
			//var result = db.Customers.Select(c => c.ContactTitle.ToLower());

			//foreach (var customer in result)
			//{
			//	Console.WriteLine(customer );
			//}



			//31.	Create a report that shows all companies by name that sell products in CategoryID 8.
			//31.soru cevabı=SELECT * FROM Products WHERE CategoryID=8

			//var result = db.Products.Where(p => p.CategoryId == 8).Select(p => new Product
			//{
			//	ProductId = p.ProductId

			//});
			//foreach (var product in result)
			//{
			//	Console.WriteLine(product.ProductId);
			//}



			//30.	Create a report that shows all products by name that are in the Seafood category.
			//30.soru cevabı=SELECT * FROM Products where CategoryID=(Select CategoryID from Categories Where CategoryName='Seafood')

			//var result = db.Products.Include(c=>c.Category).Where(p => p.Category.CategoryName=="Seafood").Select(p => new Product
			//{
			//	ProductId = p.ProductId

			//});
			//foreach (var product in result)
			//{
			//	Console.WriteLine(product.ProductId);
			//}





			//32.	Create a report that shows all companies by name that sell products in the Seafood category.
			//32.soru cevabı=

			var result = db.Categories.Include(p => p.Products).Where(p => p.Products.P == "Seafood").Select(c => new Category
			{
				CategoryName = c.CategoryName

			});
			foreach (var product in result)
			{
				Console.WriteLine(product.CategoryName);
			}




			//33.	Create a report that shows the order ids and the associated employee names for orders that shipped after the required date. It should return the following. There should be 37 rows returned.
			//32.soru cevabı=

			//var result = db.Categories.Include(p => p.Products).Where(p => p.Products.P == "Seafood").Select(c => new Category
			//{
			//	CategoryName = c.CategoryName

			//});
			//foreach (var product in result)
			//{
			//	Console.WriteLine(product.CategoryName);
			//}




			//34.	Create a report that shows the total quantity of products (from the Order_Details table) ordered. Only show records for products for which the quantity ordered is fewer than 200. The report should return the following 5 rows.
			//32.soru cevabı=

			//var result = db.Categories.Include(p => p.Products).Where(p => p.Products.P == "Seafood").Select(c => new Category
			//{
			//	CategoryName = c.CategoryName

			//});
			//foreach (var product in result)
			//{
			//	Console.WriteLine(product.CategoryName);
			//}




			//35.	Create a report that shows the total number of orders by Customer since December 31, 1996. The report should only return rows for which the NumOrders is greater than 15. The report should return the following 5 rows.
			//32.soru cevabı=

			//var result = db.Categories.Include(p => p.Products).Where(p => p.Products.P == "Seafood").Select(c => new Category
			//{
			//	CategoryName = c.CategoryName

			//});
			//foreach (var product in result)
			//{
			//	Console.WriteLine(product.CategoryName);
			//}




			//36.	Create a report that shows the company name, order id, and total price of all products of which Northwind has sold more than $10,000 worth. There is no need for a GROUP BY clause in this report.
			//32.soru cevabı=

			//var result = db.Categories.Include(p => p.Products).Where(p => p.Products.P == "Seafood").Select(c => new Category
			//{
			//	CategoryName = c.CategoryName

			//});
			//foreach (var product in result)
			//{
			//	Console.WriteLine(product.CategoryName);
			//}
		}
	}
}