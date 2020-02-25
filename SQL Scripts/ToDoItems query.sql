use master
go

drop database if exists ToDoDatabase
go

create database ToDoDatabase
go

use ToDoDatabase
go

create table Users(
UserId int not null primary key identity,
UserName varchar (50) null
)

create table Categories(
CategoryId int not null primary key identity,
CategoryName varchar (50) null
)

create table ToDoItems(
ToDoItemId int not null primary key identity,
ToDoItemName varchar (50) null,
StartDate date null,
isDone bit null,
UserId int null foreign key references Users(UserId),
CategoryId int null foreign key references Categories(CategoryId)
)

insert into Users values ('Jordan')
insert into Users values ('Karim')
insert into Users values ('Ali')
insert into Categories values ('Admin')
insert into Categories values ('Users')
insert into Categories values ('Personal')
insert into ToDoItems values ('Do Work','2020-01-01','True',1,1) 
insert into ToDoItems values ('Do Hair','2020-04-02','True',2,2) 
insert into ToDoItems values ('Cook food','2020-06-07','False',3,3) 

alter table users add UserAge varchar(50) null
alter table Users alter column UserAge int null
update users set UserAge = 22 where UserId =1;
update users set UserAge = 30 where UserId =2;
update users set UserAge = 25 where UserId =3;

select ToDoItems.UserId, UserName, UserAge, ToDoItems.CategoryId, CategoryName, ToDoItemId, ToDoItemName, 
case when isDone = 1 then 'Yes' Else 'No' End as isDone, StartDate from ToDoItems
inner join categories on ToDoItems.CategoryId = Categories.CategoryId
inner join users on ToDoItems.UserId = Users.UserId



--select all databases on your computer
--select 'select all databases'
--select * from sysdatabases 

--use ToDoDatabase
--go
--select * from sys.tables

--show all columns for a table
--select * from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME = 'ToDoItems'
--select * from sys.tables

