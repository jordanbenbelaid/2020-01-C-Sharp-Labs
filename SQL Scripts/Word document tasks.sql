-- 1.1	Write a query that lists all Customers in either Paris or London. 
-- Include Customer ID, Company Name and all address fields.

SELECT CustomerId, CompanyName, Address FROM Customers WHERE City = 'London' OR  City = 'Paris'

-- 1.2	List all products stored in bottle.

SELECT * FROM Products WHERE QuantityPerUnit LIKE '%bottle%'

-- 1.3	Repeat question above, but add in the Supplier Name and Country.

SELECT Suppliers.SupplierID, Country,* FROM Products 
JOIN Suppliers on Products.SupplierID = Suppliers.SupplierID
WHERE QuantityPerUnit LIKE '%bottle%'

-- 1.4	Write an SQL Statement that shows how many products there are in each category. 
-- Include Category Name in result set and list the highest number first.

SELECT CategoryName, COUNT(CATEGORIES.CategoryID) AS 'HOW MANY PRODUCTS IN EACH CATEGORY'
FROM Products
JOIN CATEGORIES ON Categories.CategoryID = Products.CategoryID
GROUP BY CATEGORIES.CategoryName
ORDER BY 'HOW MANY PRODUCTS IN EACH CATEGORY' DESC

-- 1.5	List all UK employees using concatenation to join their title of 
-- courtesy, first name and last name together. Also include their city of residence.

SELECT City, CONCAT(EMPLOYEES.TitleOfCourtesy,',',EMPLOYEES.FirstName,',',
EMPLOYEES.LastName) AS fullname from Employees
where Country LIKE '%UK%'

-- 1.6	List Sales Totals for all Sales Regions (via the Territories table using 4 joins) with a Sales Total greater than 1,000,000.
-- Use rounding or FORMAT to present the numbers. 


--1.7	Count how many Orders have a Freight amount greater than 100.00 and either USA or UK as Ship Country.
SELECT COUNT(*) FROM Orders
WHERE Freight > 99.99
AND ShipCountry = 'UK' OR ShipCountry = 'USA'

--1.8	Write an SQL Statement to identify the Order Number of the Order with the highest amount of discount applied to that order.
-- INCORRECT
SELECT OrderID FROM [Order Details]
WHERE Discount = Max(Discount)

-- Correct
select Top 1 * from [Order Details]
order by Discount * UnitPrice *	Quantity desc

--Practice for friday exam
-- Select distinct city from customers
SELECT DISTINCT CITY FROM CUSTOMERS

-- Select product name where unit price is the max/min value
SELECT MIN(UnitPrice) FROM Products
SELECT MAX(UnitPrice) FROM Products

-- Print categoryname, count(productid) of products grouped by category.  Add a having to exclude category if the product count is zero
SELECT Categories.CategoryName, COUNT(ProductID) from Products
JOIN Categories ON Categories.CategoryID = Products.CategoryID
WHERE UnitsInStock > 0
GROUP BY Categories.CategoryName

-- Select all customers and all their orders, even if customer has no orders. (left outer join)
SELECT Orders.CustomerID, Orders.OrderID AS 'orders' FROM Customers
LEFT JOIN Orders ON Customers.CustomerID = Orders.CustomerID
ORDER BY 'orders' ASC

-- Select all employees where region is null
SELECT * FROM Employees
WHERE Region IS NULL

-- Select all employees where region is not null
SELECT * FROM Employees
WHERE Region IS NOT NULL

-- Select all products starting with 'p'
SELECT * FROM Products
WHERE ProductName LIKE 'p%'
