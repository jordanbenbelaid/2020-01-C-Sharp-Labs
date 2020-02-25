select top 5 * from customers
select top 5 * from customers order by customerid desc


select count(*) as Cities from customers where city = 'London'

select distinct count(TitleOfCourtesy) as TitlesofCourtesy from Employees  

select count(TitleOfCourtesy) as JobTitle from employees where TitleOfCourtesy = 'Dr.'

select count(Discontinued) as DiscontinuedProduct from Products where Discontinued = 1 


--offset = skip
--first 5 customers
select top 5 * from customers
--next 5
select *from customers order by customerid
offset 5 rows
fetch next 5 rows only
--next 5
select *from customers order by customerid
offset 10 rows
fetch next 5 rows only

--how many products with category 1 and discontinued?
select count(*) as CategoryIdAndDiscontinued from products where CategoryId = 1 and Discontinued = 1

--how many products with items in stock and unitprice > 29.99
select count(*) from Products where UnitsInStock >= 1 and UnitPrice > 29.99

--order the above list to show products ordered by unit price descending
select * from Products where UnitsInStock >= 1 and UnitPrice > 29.99
order by unitprice desc

--how many distinct countries exist in the customers table
select distinct count(Country) from customers 

--how many distinct cities exist in the customers table
select distinct count(City) from customers 


--LIKE
-- % is a wildcard for anything %a% contains a
--								a%  starts with a
--								%a ends with a
-- _ is a wildcard for one character
-- how many products contain 'ch'
select * from products where productname LIKE '%ch%'
select count(*) from products where productname LIKE '%ch%'

--how many regions contain the letter 'a' in customers
select count(*) from customers where region LIKE '%a%'

-- how many regions start with a
select count(*) from customers where region LIKE '%a'

--how many regions end with a
select count(*) from customers where region LIKE 'a%'

--NOT LIKE reverses query

--how many products do not contain ch
select count(*) from products where productname NOT LIKE '%ch%'

--using underscore to represent single character wildcard

--how many regions have 'a' as second letter (first letter wildcard)
select region, * from customers where region LIKE '_a%'

--OR but for long lists can use IN for a shorter version
select region, * from customers where region IN ('wa','ca')

--between for numeric ranges

--how many products which are not discontinued have price between 10.00 and 40.00
select count(*) from products where Discontinued = 0 and UnitPrice BETWEEN 10.00 and 40.00

--how many products start with b, s, t
select count(*) from products where productname like ('b%') or productname like ('s%') or productname like ('t%')

--how many product categoryname start with c or s
select count(*) from products 
join categories
on products.categoryid = categories.CategoryId
where categoryname like 'c%' or categoryname like 's%'

--concatenation
--select customers but join 'city and country' into one column ie 'lives in'
select *, concat (city,',',country) as LivesIn from Customers

--customer => order => details of order (order_details)
--select orders for ALFKI customer
select * from orders where customerid = 'ALFKI'

--have a look at order details as well
select * from orders 
join [Order Details] on orders.OrderID = [Order Details].OrderID
where customerid = 'ALFKI'

--create a query to have orderid, productname and quantity
select orderid, productname, quantity,* from products
join [Order Details] on [Order Details].ProductID = products.ProductID

--filter orders by customer ALFKI     (DOUBLE JOIN)
select customerid, orders.orderid, productname, quantity, [Order Details].unitprice from orders 
join [Order Details] on orders.OrderID = [Order Details].OrderID
join products on [Order Details].ProductID = products.ProductID
where customerid = 'ALFKI'

--goal is to list, for any given customer, the order details
--remember to get to the orrder details we have to go first through orders table
--customer => order => order details
--productid bought, quantity, price and discount
--customerid is already in orders table

--get customer name and all orders for customerid = alfki
select customers.customerId, contactname, OrderID from customers
join orders on customers.customerid = orders.customerid
where customers.customerid = 'alfki'

--develop this to show productid as well (include order details table)
select customers.customerId, contactname, [Order Details].OrderID, ProductID, UnitPrice from customers
join orders on customers.customerid = orders.customerid
join [Order Details] on orders.OrderID = [Order Details].OrderID
where customers.customerid = 'alfki'

--add product name
select customers.customerId, contactname, [Order Details].OrderID, ProductID,ProductName UnitPrice from customers
join orders on customers.customerid = orders.customerid
join [Order Details] on orders.OrderID = [Order Details].OrderID
join products on [Order Details].productid = products.productid
where customers.customerid = 'alfki'

--add quantity, price and discount
select customers.customerId, contactname, [Order Details].OrderID, ProductID, ProductName, UnitPrice, [Order Details].Quantity,
[Order Details].UnitPrice, [Order Details].Discount
from customers
join orders on customers.customerid = orders.customerid
join [Order Details] on orders.OrderID = [Order Details].OrderID
join products on [Order Details].productid = products.productid
where customers.customerid = 'alfki'

-- now can add some calculated columns eg order before discount
select customers.customerId, contactname, [Order Details].OrderID, Products.ProductID, ProductName, [Order Details].UnitPrice, [Order Details].Quantity,
[Order Details].Discount * 100 as 'PercentageDiscount',
[Order Details].UnitPrice * [Order Details].Quantity as 'OrderBeforeDiscount',
[Order Details].UnitPrice * [Order Details].Quantity * [Order Details].Discount as 'Discount',
([Order Details].UnitPrice * [Order Details].Quantity) - ([Order Details].Discount * [Order Details].Quantity * [Order Details].UnitPrice) as 'OrderAfterDiscount'
-- second way to do it 
--[Order Details].UnitPrice * [Order Details].Quantity (1 - [Order Details].Discount) as 'OrderAfterDiscount'
from customers
join orders on customers.customerid = orders.customerid
join [Order Details] on orders.OrderID = [Order Details].OrderID
join products on [Order Details].productid = products.productid
where customers.customerid = 'alfki'

-- get totals 
select 
sum([Order Details].Quantity) as 'QuantityTotal',
sum([Order Details].UnitPrice * [Order Details].Quantity) as 'OrderBeforeDiscount',
sum([Order Details].UnitPrice * [Order Details].Quantity * [Order Details].Discount) as 'Discount',
sum(([Order Details].UnitPrice * [Order Details].Quantity) - ([Order Details].Discount * [Order Details].Quantity * [Order Details].UnitPrice)) as 'OrderAfterDiscount'
from customers
join orders on customers.customerid = orders.customerid
join [Order Details] on orders.OrderID = [Order Details].OrderID
join products on [Order Details].productid = products.productid
where customers.customerid = 'alfki'

-- Now for all customers
-- Can use a group by condition which groups results by a column
-- can repeat these totals and group by customerID
select 
customers.customerId,
sum([Order Details].Quantity) as 'QuantityTotal',
sum([Order Details].UnitPrice * [Order Details].Quantity) as 'OrderBeforeDiscount',
sum([Order Details].UnitPrice * [Order Details].Quantity * [Order Details].Discount) as 'Discount',
sum(([Order Details].UnitPrice * [Order Details].Quantity) - ([Order Details].Discount * [Order Details].Quantity * [Order Details].UnitPrice)) as 'OrderAfterDiscount'
from customers
join orders on customers.customerid = orders.customerid
join [Order Details] on orders.OrderID = [Order Details].OrderID
join products on [Order Details].productid = products.productid
where [Discount] > 0
--
group by Customers.CustomerID
having sum(([Order Details].UnitPrice * [Order Details].Quantity) - ([Order Details].Discount * [Order Details].Quantity * [Order Details].UnitPrice)) > 10000
-- sort the results
order by [OrderAfterDiscount] desc


-- String Manipulation

-- SUBSTRING from first given index (1-based counting) and specify number or letters to return
SELECT SUBSTRING('VERYLONGSTRING',3,6)    -- from index 3 (3rd character) for 6 letters (3,6)

-- CHARINDEX get the index where it is placed inside our long string 
-- index is not 0 based counting so returns 6 = 6th character
SELECT CHARINDEX('a','VERYLANGSTRANG')
SELECT CHARINDEX(' ','TM44 5AZ')  -- can be used to split postcode 

-- LEFT/RIGHT		return first/last characters
SELECT LEFT('VERYLONGSTRING',4)    --returns very (...,4) returns 4 characters from left
SELECT LEFT('TM44 5AZ', CHARINDEX(' ','TM44 5AZ')-1)     -- should select tm44
SELECT RIGHT('TM44 5AZ', 3)     -- should select 5az

-- LTRIM/RTRIM remove spaces
SELECT LTRIM(RTRIM(('        SOME DATA WITH SPACE AROUND        ')))

-- REPLACE
SELECT REPLACE ('VERY LONG STRING','VERY','VERY VERY VERY EXTREMELY') --sentence first, second is what changes, third is what it changes to

-- UPPER/LOWER
SELECT UPPER('A Long String In Lower Case')

--DATES         today, tomorrow, yesterday
SELECT CONCAT('TODAY IS ', GETDATE())
SELECT CONCAT('TOMORROW IS ', DATEADD(d,1,GETDATE()))
SELECT CONCAT('YESTERDAY WAS ', DATEADD(d,-1,GETDATE()))

--DATE DIFFERENCE EG difference in days between today and a weeks time
SELECT DATEDIFF(yy, DATEADD(yy,7,GETDATE()), GETDATE())		--d for day, mm for month, yy for year


SELECT * FROM ORDERS
--WHATS THE LONGEST SHIPPING TIME    (SUBTRACT SHIPDATE FROM ORDERDATE AND GET MAX)
SELECT OrderID, DATEDIFF(D, OrderDate, ShippedDate) AS SHIPPINGTIME
FROM ORDERS
WHERE DATEDIFF(D, OrderDate, ShippedDate) > 10
ORDER BY SHIPPINGTIME DESC

--FLOOR      convert to integer
SELECT FLOOR(10.65)
SELECT CEILING(10.65)
SELECT ROUND(10.49,0)
SELECT ROUND(10.50,0)

--CASE .. WHEN .. ELSE
SELECT CASE 
WHEN (10<11)
THEN '10 IS SMALL'
ELSE 'SOME OTHER NUMBER'
END
AS 'IS 10 SMALL?'

--GROUP BY EXERCISES
--PRINT CUSTOMERS GROUPED BY COUNTRY
SELECT count(Country) as 'PeopleFromThatCountry' , Country 
FROM Customers
GROUP BY Country

-- SUM THE COUNT
SELECT COUNT(COUNTRY) FROM CUSTOMERS GROUP BY COUNTRY
--SELECT ContactName , Country 
--FROM Customers
--ORDER BY Country

--PRINT CUSTOMERS GROUPED BY CITY
SELECT CITY, CONTACTNAME FROM CUSTOMERS ORDER BY CITY

--PRINT PRODUCTS GROUPED BY CATEGORY
SELECT COUNT(PRODUCTNAME), c.CATEGORYNAME
FROM PRODUCTS p
JOIN CATEGORIES c ON P.CategoryID = C.CategoryID
GROUP BY C.CategoryName

-- LEFT, RIGHT, INNER, OUTER JOINS

-- LEFT JOIN : ALL RECORDS FROM LEFT TABLE AND MATCHING FROM RIGHT TABLE
-- ALL CUSTOMERS (BY CUSTOMERID) AND ANY MATCHING ORDERS

-- RIGHT JOIN : ALL ORDERS (BY ORDERID) AND ANY MATCHING CUSTOMERS

-- OUTER JOIN : EITHER LEFT (OUTER) JOIN OR RIGHT (OUTER) JOIN WHICH ARE DESCRIBED ABOVE

-- INNER JOIN : ONLY FROM FIRST TABLE WHEN MATCHING SECOND TABLE
-- ONLY CUSTOMERS WHO HAVE ORDERS, AND THEIR MATCHING ORDER

-- CAN WE DO AN INNER JOIN AND COMPARE WITH STANDARD LEFT JOIN? DO ALL CUSTOMERS HAVE ORDERS
SELECT COUNT(*)
FROM CUSTOMERS
JOIN ORDERS ON CUSTOMERS.CustomerID = ORDERS.CustomerID

SELECT COUNT(*)
FROM CUSTOMERS
LEFT JOIN ORDERS ON CUSTOMERS.CustomerID = ORDERS.CustomerID

SELECT COUNT(*)
FROM CUSTOMERS
FULL JOIN ORDERS ON CUSTOMERS.CustomerID = ORDERS.CustomerID