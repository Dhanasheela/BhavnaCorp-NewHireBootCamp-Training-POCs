use fashion
create table brand (
brandID int  identity(1,1),
brandname varchar(50) primary key,
brandprice int,
)
create table celebrity(
celebrityID int  identity,
celebrityname varchar(40) primary key,

)

create table endorse(
endorseID int primary key identity,
celebrityname varchar(40) foreign key references celebrity(celebrityname),
brandname varchar(50) foreign key references brand(brandname),
)

truncate table celebrity

create procedure sp_InsertFashion
(@brandname varchar(50) ,
@brandprice int
)
as
begin
insert into brand(brandname,brandprice) values(@brandname,@brandprice)
end

exec sp_InsertFashion
@brandname='FLIPKART',@brandprice=799

exec sp_SelectFashion

--celebrity table
create procedure sp_InsertCelebrityFashion
(@celebrityname varchar(50)
)
as
begin
insert into celebrity(celebrityname) values(@celebrityname)
end


exec sp_InsertCelebrityFashion
@celebrityname='Sharukkhan'


--endorse table
create procedure sp_InsertEndorseFashion
(@celebrityname varchar(50),
@brandname varchar(50)
)
as
begin
insert into endorse(celebrityname,brandname) values(@celebrityname,@brandname)
end

exec sp_InsertEndorseFashion
@celebrityname='Sharukkhan',
@brandname='FRUITY'

create  procedure sp_AllSelectFashion
as
begin 
select * from brand 
select * from celebrity
select * from endorse
end

exec sp_AllSelectFashion



--joins

--lists of all celebrities and brands with null values

select  E.celebrityname,B.brandname 
from endorse as E
full join brand as B on B.brandname=E.brandname


--Count common  brand

select e.brandname,count(endorseID) as NumberOfBrand
from endorse as e
inner join brand b on b.brandname=e.brandname
group by e.brandname


--Count common  celebrities
select e.celebrityname,count(endorseID) as NumberOfCelebrityEndorse
from endorse as e
inner join celebrity C on C.celebrityname=e.celebrityname
group by e.celebrityname


select e.celebrityname,e.brandname,count(e.endorseID)
from endorse as e
inner join brand b  on b.brandname=e.brandname
inner join celebrity c on c.celebrityname=e.celebrityname
group by e.brandname,e.celebrityname
having    e.brandname='boost' 


--celebrities not endorse any brand
select * from endorse where brandname is null



--triggers


CREATE TABLE Employee
(
  Id int Primary Key,
  Name nvarchar(30),
  Salary int,
  Gender nvarchar(10),
  DepartmentId int
)
GO

create table Endorse_Test
(
EID int primary key identity,
 Id  INT ,
operation varchar(30),
updatedDate datetime ,
) 
-- Insert data into Employee table
INSERT INTO Employee VALUES (1,'Pranaya', 5000, 'Male', 3)
INSERT INTO Employee VALUES (2,'Priyanka', 5400, 'Female', 2)
INSERT INTO Employee VALUES (3,'Anurag', 6500, 'male', 1)
INSERT INTO Employee VALUES (4,'sambit', 4700, 'Male', 2)
INSERT INTO Employee VALUES (9,'kumar', 6600, 'male', 2)


--inserting values using trigger

CREATE TRIGGER trInsertEmployee 
ON Employee
FOR INSERT 
AS
BEGIN
  insert into Endorse_Test
  select Id,'inserted',GETDATE() from inserted 
END

--updating values using trigger

CREATE TRIGGER TrgUpdateEmployee 
ON Employee
after UPDATE 
AS
BEGIN
insert into Endorse_Test
  select Id,'updated',GETDATE() from deleted 
    END

update Employee set Name='ARden' where Id=1



--deleting values using trigger

CREATE TRIGGER TrgDeleteEmployee 
ON Employee
after DELETE 
AS
BEGIN
insert into Endorse_Test
  select Id,'deleted',GETDATE() from deleted 
    END

delete  from Employee   where Id=2


select * from Employee
select * from Endorse_Test