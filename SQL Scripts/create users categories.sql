--system database

use master
go

-- create a database
drop database if exists Users
go

create database Users
go

use Users 
go

--create users and categories

create table Categories(
	CategoryId INT NOT NULL PRIMARY KEY IDENTITY,
	CategoryName VARCHAR(50) NULL,
)

create table Users(
	UserId INT NOT NULL PRIMARY KEY IDENTITY (1,1),
	UserName VARCHAR(50) NULL,
	DateOfBirth DATE NULL,
	isValid BIT NULL,
	CategoryId INT NULL FOREIGN KEY REFERENCES Categories(CategoryId)
)



INSERT INTO CATEGORIES VALUES ('Admin')
INSERT INTO CATEGORIES VALUES ('Work')
INSERT INTO CATEGORIES VALUES ('Personal')

INSERT INTO USERS VALUES ('Fred', '2020-10-10','True',1)
INSERT INTO USERS VALUES ('Bill', '2020-10-10','True',2)
INSERT INTO USERS VALUES ('Wilma', '2020-10-10','True',3)

select * from Categories
select * from Users

--SQL join similar to LINQ

select * from Users JOIN Categories
on Users.CategoryId = Categories.CategoryId

--selecting certain fields
select UserId,UserName,isValid,CategoryName from Users INNER JOIN Categories
on Users.CategoryId = Categories.CategoryId
