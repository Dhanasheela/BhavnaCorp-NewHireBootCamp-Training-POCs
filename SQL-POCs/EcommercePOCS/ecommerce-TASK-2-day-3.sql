use Ecommerce

CREATE TABLE customer(
	customerID int IDENTITY(1,1) NOT NULL,
	name varchar(70) NULL,
	email varchar(80) NULL,
	address varchar(70) NULL
	primary key(customerID )
       ) 

CREATE TABLE product(
   productID int IDENTITY(101,1) NOT NULL,
   pname varchar(60) NULL,
   category varchar(80) NULL,
   price float NULL,
   primary key(productID )
   customerID int FOREIGN KEY REFERENCES customer(customerID)
);


CREATE TABLE Orders(
	OrderID int IDENTITY(201,1) NOT NULL,
	quantity int NULL,
	total float NULL,
        primary key(OrderID)
	productID int FOREIGN KEY REFERENCES product(productID)
)



select *from Customer
select *from product
select *from orders


--list number of having common address

select count(customerID) as No_customers_adress,address 
from customer 
group by address 
order by count(customerID) desc

--lists number of orders with common quantity

select count(orders.OrderID) as NumberOfOrders,orders.quantity
from orders
left join product on product.productID=Orders.productID
group by orders.quantity


select count(product.productID) as NumberOfProducts,product.pname
from product
left join orders on product.productID=Orders.productID
group by product.pname

--having clause
--list the customers have ordered more than 1 products

select customer.name,count(product.productID) as numberOfProducts
from (product 
inner join customer on product.customerID=customer.customerID)
group by customer.name
having count(product.productID)>1;




select product.pname,count(orders.OrderID) as numberOfOrders
from (orders
inner join product on orders.ProductID=product.productID)
group by product.pname 
having count(orders.quantity)>1

--lists number of  commom categories of products
select product.category,count(customer.customerID) as numberOfProducts
from (product 
inner join customer on product.customerID=customer.customerID)
group by product.category
having count(product.productID)>1;




SELECT TOP 2 total
FROM (SELECT DISTINCT TOP 2
	  total
      FROM orders
      ORDER BY total DESC  
      ) RESULT  
ORDER BY total 


 Select max(total) from orders 


 
 select count(*) as NumberOfOrders from orders group by quantity

 select category,count(*) as NumberOfProducts  from product group by category








