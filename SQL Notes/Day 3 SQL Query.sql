CREATE DATABASE TransactionDemoDB;

use TransactionDemoDB;

CREATE TABLE Customers(
CustomerId INT PRIMARY KEY IDENTITY(1,1),
CustomerName VARCHAR(100) NOT NULL,
Email VARCHAR(100) NOT NULL
);

CREATE TABLE Products(
ProductId INT PRIMARY KEY IDENTITY(1,1),
ProductName VARCHAR(100) NOT NULL,
Price DECIMAL(10,2) NOT NULL,
StockQuantity INT NOT NULL
);

CREATE TABLE ORDERS(
OrderId INT PRIMARY KEY IDENTITY(1,1),
CustomerId INT NOT NULL,
OrderDate DATETIME DEFAULT GETDATE(),
TotalAmount DECIMAL(10,2) NOT NULL,
OrderStatus varchar(50) NOT NULL,

CONSTRAINT FK_Orders_Customers
FOREIGN KEY (CustomerId) REFERENCES Customers(CustomerId)
);


CREATE TABLE OrderItems(
OrderItemId INT PRIMARY KEY IDENTITY(1,1),
OrderId INT NOT NULL,
ProductId INT NOT NULL,
Qunatity INT NOT NULL,
UnitPrice DECIMAL(10,2) NOT NULL,

CONSTRAINT FK_OrderItems_Orders
FOREIGN KEY (ProductId) REFERENCES Products(ProductId)
);

CREATE TABLE Payments
(
PaymentId INT PRIMARY KEY identity(1,1),
OrderId INT NOT NULL,
PaymentAmount DECIMAL(10,2) NOT NULL,
PaymentStatus VARCHAR(50) NOT NULL,
PaymentDate DATETIME DEFAULT GETDATE(),
CONSTRAINT FK_Payments_Orders
FOREIGN KEY (OrderId) REFERENCES Orders(OrderId)
);


INSERT INTO Customers (CustomerName,Email)
VALUES
('Arun Kumar','arun@mail.com'),
('Priya Sharma','priya@mail.com')

INSERT INTO Products (ProductName, Price, StockQuantity)
VALUES
('Laptop', 55000, 10),
('Mouse', 700, 50),
('Keyboard', 1500, 30);


SELECT * FROM Customers

SELECT * FROM Products;


BEGIN TRANSACTION

DECLARE @CustomerId INT=1;
DECLARE @ProductId INT=1;
DECLARE @Quantity INT =2;
DECLARE @UnitPrice DECIMAL(10,2);
DECLARE @TotalAmount DECIMAL(10,2);
DECLARE @OrderId INT;

SELECT @UnitPrice=Price FROM Products WHERE ProductId=@ProductId

SET @TotalAmount=@UnitPrice*@Quantity;

INSERT INTO ORDERS (CustomerId,TotalAmount,OrderStatus)
VALUES (@CustomerId,@TotalAmount,'Confirmed');


SET @OrderId=SCOPE_IDENTITY();

INSERT INTO OrderItems (OrderId,ProductId,Qunatity,UnitPrice)
values (@OrderId,@ProductId,@Quantity,@UnitPrice);

UPDATE Products set StockQuantity=StockQuantity-@Quantity 
WHERE ProductId=@ProductId;

INSERT INTO Payments (OrderId,PaymentAmount,PaymentStatus)
VALUES (@OrderId,@TotalAmount,'Paid');

COMMIT TRANSACTION;



SELECT * FROM ORDERS;

SELECT * FROM OrderItems;

SELECT * FROM Payments;

SELECT * FROM Products;



--exmaple for Rollback Transaction using try catch
BEGIN TRY
	BEGIN TRANSACTION
		
	DECLARE @CustomerId INT=2;
	DECLARE @ProductId INT=1;
	DECLARE @Quantity INT =3;
	DECLARE @AvailableStock INT;
	DECLARE @UnitPrice DECIMAL(10,2);
	DECLARE @TotalAmount DECIMAL(10,2);
	DECLARE @OrderId INT;

	SELECT
	@AvailableStock=StockQuantity ,@UnitPrice=Price FROM Products 
	WHERE ProductId=@ProductId;

	IF @AvailableStock<@Quantity
	BEGIN
		RAISERROR('Insufficient Stock. Order Cannot be placed.',16,1);
	END

	SET @TotalAmount=@UnitPrice*@Quantity;

	INSERT INTO Orders (CustomerId,TotalAmount,OrderStatus)
	VALUES (@CustomerId,@TotalAmount,'Confirmed');

	SET @OrderId=SCOPE_IDENTITY();

	INSERT INTO OrderItems (OrderId,ProductId,Qunatity,UnitPrice)
	VALUES (@OrderId,@ProductId,@Quantity,@UnitPrice);

	UPDATE Products SET StockQuantity=StockQuantity-@Quantity
	WHERE ProductId=@ProductId;

	INSERT INTO Payments (OrderId,PaymentAmount,PaymentStatus)
	VALUES (@OrderId,@TotalAmount,'Paid');

	COMMIT TRANSACTION;
	
	PRINT 'Order placed Successfully.';
END TRY
BEGIN CATCH
	ROLLBACK TRANSACTION;

	PRINT 'Transaction failed. All Changes reverted.';
	PRINT ERROR_MESSAGE();
END CATCH;