use bhavnadb


create table customer_test
(
CID int primary key identity,
customer_id INT ,
operation varchar(30),
updatedDate datetime ,
) 
CREATE TRIGGER TrgUpdateCustomers
ON customer
after UPDATE 
AS
BEGIN
insert into customer_test
  select customer_id,'updated',GETDATE() from deleted 
    END

	update customer set email='raki123' where customer_id=1001

	select * from customer_test