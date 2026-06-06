

-- Basic Syntax Procedure

CREATE PROCEDURE usp_GetAllEmployees
AS
BEGIN
SELECT * FROM Employees;
END

EXEC usp_GetAllEmployees;

-- CAN WE create stored procedure using join
CREATE PROC sp_GetEmplyeeWithDepartment
AS
BEGIN
SELECT 
e.EmployeeId,
e.Name,
e.Gender,e.City,e.Salary,e.MobileNo,d.DepartmentName,d.Location
FROM Employees e
INNER JOIN Department d
on e.DepartmentId=d.DepartmentId
END


EXECUTE sp_GetEmplyeeWithDepartment

-- stored Procedure


create table Emp
(id int,
name varchar(20));


select * from Emp;delete from emp;

-- stored procedure with input (IN) parameter

CREATE PROCEDURE sp_GetEmployeeByCity
@City varchar(50)
AS
BEGIN
SELECT * FROM Employees WHERE CITY=@City
END;

EXEC sp_GetEmployeeByCity 'Bangalore';
EXEC sp_GetEmployeeByCity 'Chennai';

EXEC sp_GetEmployeeByCity @City='Hyderabad';


CREATE PROC sp_InsertEmployee
@Name varchar(50),
@Gender varchar(10),
@City Varchar(50),
@Salary decimal,
@Email varchar(50),
@MobileNo Bigint,
@DepartmentId int
AS
BEGIN
INSERT INTO Employees (Name,Gender,City,Salary,Email,MobileNo,DepartmentId)
VALUES
(@Name,@Gender,@City,@Salary,@Email,@MobileNo,@DepartmentId)
END


EXEC sp_InsertEmployee 'Janani','Female','Coimbatore',32000,'janani@mail.com',874356465,2

exec usp_GetAllEmployees

-- Stored Procedure With IF ELSE
CREATE PROC sp_CheckSalaryCategory
@EmployeeId int
AS
BEGIN
	DECLARE @Salary MONEY;
	SELECT @Salary =Salary from Employees Where EmployeeId=@EmployeeId;
	IF @Salary>=60000
	BEGIN
	SELECT 'High Salary Employee ' AS SalaryCategory;
	END
	ELSE
	BEGIN
	SELECT 'Normal Salary Employee' As  SalaryCategory;
	END
END;


EXEC sp_CheckSalaryCategory 2;

-- stored procedure with output parameter

CREATE PROC sp_GetEmployeeCountByDepartment
@DepartmentId int,
@TotalEmployees int OUT
AS
BEGIN
SELECT @TotalEmployees=COUNT(*) FROM Employees where DepartmentId=@DepartmentId;
END;



DECLARE @Count int

EXEC sp_GetEmployeeCountByDepartment @DepartmentId=2, @TotalEmployees=@Count OUTPUT;

SELECT @Count as TotalEmployee
GO