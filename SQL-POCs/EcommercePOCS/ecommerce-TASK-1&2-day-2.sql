USE [Employeedb]
use Employeedb

CREATE TABLE Personal_Details1(
	id int IDENTITY(1,1) NOT NULL,
	name varchar(60) NULL,
	email varchar(70) NULL,
	phone bigint NULL,
	dob date NULL,
        Primary key(id ))

CREATE TABLE official_details(
	email varchar(70) NULL,
        name varchar(80) NULL,
	password varchar(50) NULL)

CREATE TABLE salary_details(
	email varchar(80) NULL,
	salary floatNULL)

insert into Personal_Details into values ('ramu','ramu@gmail.com',98765432210,1998-09-12);
insert into Personal_Details into values ('dhanu','dhanu@gmail.com',67812345098,1998-06-18);
insert into Personal_Details into values ('thanvi','thanvi@gmail.com',87654321911,1999-09-12);


insert into official_details into values ('uma@bhavna.com','uma',uma);
insert into official_details into values ('raju@bhavna.com','raju',raju);

insert into salary_details into values ('manish',20000);
insert into salary_details into values ('uma',15000);
insert into salary_details into values ('raju',12000);
insert into salary_details into values ('sony',25000);
insert into salary_details into values ('rakesh',30000);

select *from Personal_Details 
select *from official_details
select *from salary_details 

select * from salary_details where salary<20000 
select avg(salary) from salary_details 
select * from salary_details where salary between 15000 and 30000

update official_details set name='Uma',email='uma@bhavna.com',password='uma'

update official_details set name='raju' ,email='raju@bhavna.com', password='raju' where id=102

select  o.*,s.salary from salary_details s inner join official_details o on  o.name=s.name	

---* ASSIGNEMENT-2 *---

--ecommerce--

CREATE TABLE customer(
	id  int IDENTITY(1,1) NOT NULL,
	name varchar(70) NULL,
	email varchar(80) NULL,
	address varchar(70) NULL
	primary key(id )
       ) 
CREATE TABLE product(
   pid int IDENTITY(101,1) NOT NULL,
   email varchar(80) NULL,
   pname varchar(60) NULL,
   price float NULL,
   primary key( pid )
  );
CREATE TABLE order_tb(
	order_id int IDENTITY(201,1) NOT NULL,
	quantity int NULL,
        primary key(order_id))

CREATE TABLE order_tb(
	accountID int IDENTITY(201,1) NOT NULL,
	orderID int NULL,
 	date date NULL,
	total float NULL,
        primary key(accountID ))


insert into customer values('dhanu','dhanu@gmail.com','hyd');
insert into customer values('rakesh','raki@gmail.com','wgl');
insert into customer values('sony','sony@gmail.com','vizag');
insert into customer values('mani','mani@gmail.com','kerala');


insert into product values('dhanu@gmail.com','shirt',599);
insert into product values('raki@gmail.com','pant',699);
insert into product values('sony@gmail.com','furniture',1299);
insert into product values('mani@gmail.com','bag',999);


insert into order_tb values(104,1,999);
insert into order_tb values(101,2,998);
insert into order_tb values(102,2,1398);
insert into order_tb values(103,1,1299);


select * from product
select * from order_tb
select * from customer
select * from account

select pro.*,C.name from pro 
inner join customer C on C.email=pro.email


--views

create view Ecommerce_View
as
select C.name,pro.pname,pro.price,C.address from customer C
inner join pro on pro.email=C.email

select *from customer_View


create view orderlist_View
as 
select pro.pname,pro.price,or_dtls .quantity,or_dtls .total
from product pro
inner join order_tb or_dtls  on pro.pid=or_dtls .pid


select * from AccountDetails_View
select * from orderlist_View

create view AccountDetails_View
as
select C.name, pro.pname,pro.price,or_dtls.quantity,Acc.date,Acc.total,C.address
from product pro
inner join customer C on C.email=pro.email
inner join order_tb or_dtls on pro.pid=or_dtls.pid
inner join account Acc on or_dtls.order_id=Acc.orderID



create view Num_Orders_View
 as
select sum(order_id) as NumberOfOrders from order_tb 

