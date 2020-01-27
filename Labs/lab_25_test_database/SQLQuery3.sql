-- Shift focus to built in database
use master
go       -- confirms and executes immediately

drop database if exists testdatabase
go

create database testdatabase
go

use testdatabase  
go

-- NULL means entry can be empty
-- NOT NULL means value is required
-- IDENTITY means AUTO CREATE ID WITH NEXT AVAILABLE ID AUTOMATICALLY
-- PRIMARY KEY means unique values required

create table testtable
(
	TestTableId INT NOT NULL IDENTITY PRIMARY KEY,
	TestName VARCHAR(50) NULL,
	TestAge INT NULL
)

insert into testtable values ('name0001',22)
insert into testtable values ('name002',33)
insert into testtable values ('name03',44)

select * from testtable