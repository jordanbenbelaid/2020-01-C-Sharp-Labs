use master 
go

drop database if exists RabbitDatabase
go

create database RabbitDatabase
go

use RabbitDatabase
go

create table RabbitTable
(
	RabbitTableId INT NOT NULL IDENTITY PRIMARY KEY,
	RabbitName VARCHAR(50) NULL,
	RabbitAge INT NULL,
)

insert into RabbitTable values ('rabbit1',2)
insert into RabbitTable values ('rabbit2',4)
insert into RabbitTable values ('rabbit3',3)
insert into RabbitTable values ('rabbit4',1)
insert into RabbitTable values ('rabbit5',7)

select * from RabbitTable