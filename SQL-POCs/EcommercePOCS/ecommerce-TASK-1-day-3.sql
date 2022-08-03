use Employeedb

select * from product where price=599 and email like 'd%'

select * from  AccountDetails_View where total >1198

select *from customer where name like '%[uresh]'

select * from customer where  name like '%sh'

select *from customer where email like '%[@gmail]'

select * from customer where  name like '%s%'

select * from customer where address is null

select * from AccountDetails_View order by total , price desc

select top(2) * from AccountDetails_View  where	total>1000
	
select *From customer where address in ('hyd','agra','wgl')

select * from customer where email in(select email from product)

select * from product where price between 700 and 1500

select name,email from customer where exists(select pname from product where product.email=customer.email and price >800 )

select * from AccountDetails_View

select * from product where   pid= any (select pid from order_tb where quantity=2); 