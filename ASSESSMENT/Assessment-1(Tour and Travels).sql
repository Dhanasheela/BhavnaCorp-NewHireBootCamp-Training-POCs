create database Airlines
use airlines

create table employee (
empID int primary key identity,
ename varchar(30),
email varchar(40),
mobile bigint,
address varchar(40))


select * from employee


create table flight(
flightID int primary key identity,
flightname varchar(20),
fdate date,
leave_from varchar(20),
going_to varchar(20),
)

 

create table customer (
customerID int primary key identity ,
cust_name varchar(30),
cust_mobile bigint,
)


create table booking (
bookingID int primary key identity,
flightID int foreign key references flight(flightID),
book_date date,
book_amount int,
 customerID int foreign key references customer(customerID))

 --inserting values into flight table

 insert into flight values('San Francisco', '11/14/2020','HYD','DELHI')
 insert into flight values('San Diego',' 10-18-2021','USA','HYD')
 insert into flight values('Dallas', '1/12/2022','HYD','LONDON')
 insert into flight values('San Francisco',' 07/07/2022','MYSORE','USA')


 --stored procedures

 create procedure sp_InsertCustomer
(@cust_name varchar(30),
@cust_mobile bigint
)
as
begin
insert into customer(cust_name,cust_mobile) values(@cust_name,@cust_mobile)
end

exec sp_InsertCustomer
@cust_name='Praveen',
@cust_mobile=902405300


 create procedure sp_InsertBooking
(@flightID int,
@book_date date,
@book_amount int,
 @customerID int
)
as
begin
insert into booking(flightID,book_date,book_amount,customerID ) values(@flightID,@book_date,@book_amount,@customerID )
end


exec sp_InsertBooking
@flightID=901,
@book_date='2020-11-14',
@book_amount=2999,
@customerID=2




select * from customer 
select *from flight
select * from booking

--Lists all customer who booked the flight with date

select C.*,F.flightname,B.book_amount,B.book_date from booking B
inner join  customer  C on B.customerID=C.customerID
inner join flight F on F.flightID=B.flightID

--list all values who leaves from hyd

select C.*,F.flightname,B.book_amount,B.book_date from booking B
inner join  customer  C on B.customerID=C.customerID
inner join flight F on F.flightID=B.flightID
where F.leave_from='HYD'



--triggers

create table Airlines_Test
(
ID int primary key identity,
 bookingID  INT ,
operation varchar(30),
updatedDate datetime ,
) 

CREATE TRIGGER TrgUpdateAirlines
ON booking
after UPDATE 
AS
BEGIN
insert into Airlines_Test
  select  bookingID ,'updated',GETDATE() from deleted 
    END

update booking set book_amount=3999 where bookingID=1004

select * from Airlines_Test


