--. Basic Subquery Questions
select * from product where price > (select avg(price) from product);
select * from product where stockquantity < (select avg(stockquantity) from product);
select * from Customer where customerId in (select customerId from orders);
select * from Customer where customerId not in (select customerId from orders);
select * from product where productid in (select productid from orderitem);
select * from product where productid not in (select productid from orderitem);
select * from seller where sellerid in (select sellerid from product);
select * from seller where sellerid not in (select sellerid from product);
select * from orders where customerid in (select customerid from customer where city='chennai');
select * from product where sellerid in (select sellerid from seller where city='bangalore');

--Subquery with IN / NOT IN
select * from Customer where customerId in (select customerId from orders);
select * from Customer where customerId not in (select customerId from orders);
select * from product where productid in (select productid from orderitem);
select * from product where productid not in (select productid from orderitem);
select * from seller where sellerid in (select sellerid from product);
select * from seller where sellerid not in (select sellerid from product);
select * from orders where orderid in (select orderid from orderitem where productid in (select productid from product where category='Mobile'));
select * from orders where orderid in (select orderid from orderitem where productid in (select productid from product where category!='Laptop'));

--Subquery with Aggregate Functions
select * from product where price = (select max(price) from product);
select * from product where price = (select min(price) from product);
select * from product where price > (select avg(price) from product);
select * from product where price < (select avg(price) from product);

select * from customer 
where customerid in (select customerid from orders 
where orderid in (
select orderid from orderitem 
group by orderid 
having sum(quantity * unitprice) > (
select avg(totalamount) from (
select sum(quantity * unitprice) as totalamount from orderitem 
group by orderid) as temp)));

select * from seller where sellerid in (select sellerid from product
where productid in (select productid from orderitem where quantity*unitprice > 50000));

select * from product where productid in 
(select productid from orderitem group by productid having sum(quantity) > 
(select avg(total) from (select sum(quantity) as total from orderitem group by productid) as temp
));

select * from customer where customerid in (
select customerid from orders where orderid in (
select orderid from orderitem 
group by orderid having sum(quantity * unitprice) = (
select max(totalamount) from (select sum(quantity * unitprice) as totalamount 
from orderitem group by orderid) as temp)));

select * from product where productid in (
(select productid from orderitem 
group by productid having sum(quantity * unitprice) = (
select max(totalamount) from (select sum(quantity * unitprice) as totalamount 
from orderitem group by productid) as temp)));

select * from seller where sellerid in (select sellerid from product
where productid in (select productid from orderitem group by productid
having sum(quantity*unitprice)=
(select max(totalamount) from (select sum(quantity * unitprice) as totalamount 
from orderitem group by productid) as temp))
);

--Correlated Subquery Questions
select * from product p
where price > (select avg(price)
from product where category=p.category);

select * from product p
where price < (select avg(price)
from product where category=p.category);

select * from seller 
where sellerid in (select sellerid from product
group by sellerid having count(productid)>=2);

select * from customer where customerid
in (select customerid from orders group by 
customerid having count(orderid)>1);

select * from orders where orderid in
(select orderid from orderitem group by orderid
having sum(quantity*unitprice) > (select avg(total) 
from (select sum(quantity*unitprice) as total from orderitem group by orderid
)as temp));

select * from product p
where stockquantity > (select avg(stockquantity)
from product where category=p.category);

select * from seller
where sellerid in (select sellerid from product
group by sellerid having avg(price) > (select avg(price) 
from product));

--EXISTS / NOT EXISTS Questions
select * from customer c where
exists (select 1 from orders o where c.customerid=o.customerid);

select * from customer c where
not exists (select 1 from orders o where c.customerid=o.customerid);

select * from product p where
exists (select 1 from orderitem o where p.productid=o.productid);

select * from product p where
not exists (select 1 from orderitem o where p.productid=o.productid);

select * from seller s where
exists (select 1 from product p where p.sellerid=s.sellerid);

select * from seller s where
not exists (select 1 from product p where p.sellerid=s.sellerid);

select * from customer c
where exists (select 1 from orders o 
where o.customerid = c.customerid and exists (
select 1 from orderitem oi 
where oi.orderid = o.orderid
and exists (select 1 from product p 
where p.productid = oi.productid 
and p.category = 'Mobile')));

select * from customer c where not exists
(select 1 from orders o where o.customerid=c.customerid
and exists (select 1 from orderitem i where o.orderid=i.orderid
and exists (select 1 from product p where i.productid=p.productid and category='Laptop')));

--Stored Procedure Assignment Questions
--Basic Stored Procedure Questions

create procedure sp_getCustomer
as
begin
select * from customer;
end;

create procedure sp_getProduct
as
begin
select * from product;
end;

create procedure sp_getSeller
as
begin
select * from seller;
end;

create procedure sp_getOrders
as
begin
select * from orders;
end;

create procedure sp_getOrderItem
as
begin
select * from orderitem;
end;

--Stored Procedure with Input Parameter
create procedure sp_getCustomerwithId
@customerid int
as
begin
select * from customer where customerid=@customerid;
end;

create procedure sp_getProductwithId
@productid int
as
begin
select * from product where productid=@productid;
end;

create procedure sp_getSellerWithId
@sellerid int
as
begin
select * from seller where sellerid=@sellerid;
end;

create procedure sp_getOrderWithId
@orderid int
as
begin
select * from orders where orderid=@orderid;
end;

create procedure sp_getCustomerWithCity
@city varchar(30)
as
begin
select * from customer where city=@city;
end;

create procedure sp_getProductWithCategory
@category varchar(50)
as
begin
select * from product where category=@category;
end;

create procedure sp_getProductWithSid
@sellerid int
as
begin
select * from product where sellerid=@sellerid;
end;

create procedure sp_getOrdersWithCid
@customerid int
as
begin
select * from orders where customerid=@customerid;
end;

create procedure sp_getOrderItemWithId
@orderid int
as
begin
select * from orderitem where orderid=@orderid;
end;

create procedure sp_getProductGrtPrice
@price decimal(10,2)
as
begin
select * from product where price>@price;
end;

--Insert Stored Procedure Questions
create procedure sp_insertCustomer
@customername varchar(50),
@email varchar(50),
@mobileno bigint,
@city varchar(30),
@address varchar(50),
@isactive bit
as
begin
insert into customer(customername,email,mobileno,city,address,isactive)
values(@customername,@email,@mobileno,@city,@address,@isactive);
end;

create procedure sp_insertSeller
@sellername varchar(50),
@email varchar(50),
@mobileno bigint,
@city varchar(30),
@rating decimal(10,2),
@isactive bit
as
begin
insert into seller(sellername, email, mobileno, city, rating, isactive)
values(@sellername,@email,@mobileno,@city,@rating,@isactive);
end;

create procedure sp_insertProduct
@productid int,
@productname varchar(50),
@category varchar(50),
@price decimal(10,2),
@stockquantity int,
@sellerid int
as
begin
insert into product(productid, productname, category, price, stockquantity, sellerid)
values(@productid, @productname, @category, @price, @stockquantity, @sellerid);
end;

create procedure sp_insertOrder
@orderid int,
@customerid int,
@orderdate date,
@orderstatus varchar(10),
@paymentmode varchar(10),
@deliverycity varchar(30)
as
begin
insert into orders(orderid, customerid, orderdate, orderstatus, paymentmode, deliverycity)
values(@orderid, @customerid, @orderdate, @orderstatus, @paymentmode, @deliverycity);
end;

create procedure sp_insertOrderItem
@orderitemid int,
@orderid int,
@productid int,
@quantity int,
@unitprice decimal(10,2)
as
begin
insert into orderitem(orderitemid, orderid, productid, quantity, unitprice)
values(@orderitemid, @orderid, @productid, @quantity, @unitprice);
end;

--Update Stored Procedure Questions
create procedure sp_updateCustWithId
@customerid int,
@city varchar(30)
as
begin
update customer set city=@city where customerid=@customerid;
end;

create procedure sp_updateCustWithPh
@customerid int,
@mobileno bigint
as
begin
update customer set mobileno=@mobileno where customerid=@customerid;
end;

create procedure sp_updateProdWithId
@productid int,
@price decimal(10,2)
as
begin
update product set price=@price where productid=@productid;
end;

create procedure sp_updateProdQWithId
@productid int,
@quantity int
as
begin
update product set stockquantity=@quantity where productid=@productid;
end;

create procedure sp_updateOrdWithId
@orderid int,
@orderstatus varchar(10)
as
begin
update orders set orderstatus=@orderstatus where orderid=@orderid;
end;

create procedure sp_updateSellWithId
@sellerid int,
@rating decimal(10,2)
as
begin
update seller set rating=@rating where sellerid=@sellerid;
end;

create procedure sp_updateCustStatus
@customerid int,
@isactive bit
as
begin
update customer set isactive=@isactive where customerid=@customerid;
end;

create procedure sp_updateSellStatus
@sellerid int,
@isactive bit
as
begin
update seller set isactive=@isactive where sellerid=@sellerid;
end;

--Delete Stored Procedure Questions
create procedure sp_deleteCustWithId
@customerid int
as
begin
delete customer where customerid=@customerid;
end;

create procedure sp_deleteSellWithId
@sellerid int
as
begin
delete from seller where sellerid=@sellerid;
end;

create procedure sp_deleteProdWithId
@productid int
as
begin
delete from product where productid=@productid;
end;

create procedure sp_deleteOrdWithId
@orderid int
as
begin
delete from orders where orderid=@orderid;
end;

create procedure sp_deleteOrdItWithId
@orderitemid int
as
begin
delete from orderitem where orderitemid=@orderitemid;
end;

--Stored Procedure with Joins
create procedure sp_getCustOrd
@customerid int
as
begin
select c.*,o.* from customer c join orders o
on c.customerid=o.customerid
where c.customerid=@customerid;
end;

create procedure sp_getSellProd
@sellerid int
as
begin
select s.*,p.* from seller s join product p
on s.sellerid=p.sellerid
where s.sellerid=@sellerid;
end;

create procedure sp_getOrdProd
@orderid int
as
begin
select o.*, p.* from orders o 
join orderitem i on o.orderid = i.orderid    
join product p on i.productid = p.productid 
where o.orderid = @orderid;
end;

create procedure sp_getOrdRep
@orderid int
as
begin
select c.customername,p.productname,s.sellername,i.quantity,i.unitprice,(i.unitprice*i.quantity) as total
from customer c join orders o on c.customerid=o.customerid
join orderitem i on o.orderid=i.orderid
join product p on i.productid=p.productid
join seller s on p.sellerid=s.sellerid
where o.orderid=@orderid;
end;

create procedure sp_getCustTotalAmount
@customerid int
as
begin
select c.customername,sum(i.unitprice*i.quantity) as total
from customer c join orders o on c.customerid=o.customerid
join orderitem i on o.orderid=i.orderid
where c.customerid=@customerid
group by c.customername;
end;

create procedure sp_getSellTotalSales
@sellerid int
as
begin
select s.sellername,sum(i.quantity*i.unitprice) as total
from seller s join product p on s.sellerid=p.sellerid
join orderitem i on i.productid=p.productid
where s.sellerid=@sellerid
group by s.sellername;
end;

create procedure sp_getProdTotalSales
as
begin
select p.productname,sum(i.quantity*i.unitprice) as total
from product p
join orderitem i on i.productid=p.productid
group by p.productname;
end;

--Stored Procedure with Output Parameter
create procedure sp_getTotalCust
as
begin
select count(customerid) from customer;
end;

create procedure sp_getTotalProd
as
begin
select count(distinct productid) as total from product;
end;

create procedure sp_getTotalOrd
as
begin
select count(distinct orderid) as total from orders;
end;

create procedure sp_getTotalSales
as
begin
select p.productname,sum(i.unitprice*i.quantity) as totalSales
from product p inner join
orderitem i on i.productid=p.productid
group by p.productname;
end;

create procedure sp_getTotalPurchase
as
begin
select c.customername,sum(i.unitprice*i.quantity) as totalPurchase
from customer c inner join orders o on c.customerid=o.customerid
inner join orderitem i on i.orderid=o.orderid
group by c.customername;
end;
