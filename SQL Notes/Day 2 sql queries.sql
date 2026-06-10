use Hexa_May_26_DotNet


Select * from Employees;
select * from Department

-- single row sub-query

SELECT * FROM Employees WHERE DepartmentId=
(
SELECT DepartmentId from Department Where DepartmentName='IT'
)

-- Scalar subquery
SELECT * FROM Employees
WHERE Salary >
(
select Avg(salary) from Employees
);

-- MutliRow Sub Query using in
SELECT * from Employees Where DepartmentId in
(
select DepartmentId from Department 
where Location in ('Chennai','Bangalore')
);

select * from Department;

-- MutliRow Sub Query using NOT IN

select * from Employees
Where DepartmentId NOT IN
(
Select DepartmentId from Department Where Location='Chennai'
)

-- Subquery With ANY operator
select * from Employees Where Salary>ANY(
select salary from Employees where DepartmentId=
(
select DepartmentId from Department Where DepartmentName='IT')
);

-- Subquery With ALL operator
select * from Employees Where Salary>=ALL(
select salary from Employees where DepartmentId=
(
select DepartmentId from Department Where DepartmentName='IT')
);


-- Subquery with EXISTS
SELECT * FROM Department d
where Exists
(
select * from Employees e
WHERE e.DepartmentId=d.DepartmentId
)


SELECT * FROM Department d
where NOT Exists
(
select * from Employees e
WHERE e.DepartmentId=d.DepartmentId
)

SELECT * FROM Employees;
Select * from Department;

--user defined function (UDF)

/*

Types of user defined function
1.Scalar Function -> Single value
2.Inline table-valued function -> table result
3. Multistatement table valued function ->  it allows multiple SQL statements

*/

-- Example for Scalar function


CREATE FUNCTION dbo.GetAnnualSalary
(
@Salary DECIMAL(10,2)
)
RETURNS DECIMAL(10,2)
AS
BEGIN
	DECLARE @AnnualSalary DECIMAL(10,2);

	SET @AnnualSalary=@Salary*12;

	RETURN @AnnualSalary;
END;


SELECT dbo.GetAnnualSalary(35000) as AnnualSalary;

SELECT EmployeeId,Name,Salary,dbo.GetAnnualSalary(salary)  as AnnualSalary
FROM Employees;


-- Handling NULL Salary in Function
CREATE FUNCTION dbo.GetAnnualSalaryWithNullCheck
(
@Salary DECIMAL(10,2)
)
RETURNS DECIMAL(10,2)
AS
BEGIN
	DECLARE @AnnualSalary DECIMAL(10,2);

	SET @AnnualSalary=ISNULL(@Salary,0)*12;

	RETURN @AnnualSalary;
END;


SELECT EmployeeId,Name,Salary,dbo.GetAnnualSalaryWithNullCheck(salary)  as AnnualSalary
FROM Employees

-- Scalar function to calculate the Bonus

CREATE FUNCTION dbo.GetEmployeeBonus
(
@Salary DECIMAL(10,2)
)
RETURNS DECIMAL(10,2)
AS
BEGIN
	DECLARE @Bonus DECIMAL(10,2);

	IF @Salary IS NULL
		SET @Bonus=0;
	ELSE IF @Salary>38000
		SET @Bonus=@Salary*0.10;
	ELSE IF @Salary>=35000
		SET @Bonus=@Salary*0.08;
	ELSE
		SET @Bonus=@Salary*0.05;

	RETURN @Bonus;
END;

SELECT EmployeeId,Name,Salary,dbo.GetEmployeeBonus(salary)  as AnnualSalary
FROM Employees


-- inline table  valued function
CREATE FUNCTION dbo.GetEmployeeByDepartment
(@DepartmentId INT)
RETURNS TABLE
AS
RETURN
	(
	SELECT EmployeeId,Name,Gender,City,Salary,Email,MobileNo,DepartmentId
	FROM Employees
	WHERE DepartmentId=@DepartmentId
	);


SELECT * FROM dbo.GetEmployeeByDepartment(2);


-- Write a user defined function to Get Employees with Department Details (use joins)
-- Write a user defined function to Get Employees by salary Range (use 2 paramters minsalary and max salary)


--Multi-Statement Table valued function

CREATE FUNCTION dbo.GetEmployeeSalaryReport
(@DepartmentId INT)
RETURNS @SalaryReport TABLE
(
EmployeeId INT,
Name VARCHAR(50),
DepartmentName VARCHAR(20),
Salary DECIMAL(10,2),
AnnualSalary DECIMAL(10,2),
BonusAmount DECIMAL(10,2),
SalaryGrade VARCHAR(30)
)
AS
BEGIN
	 INSERT INTO @SalaryReport
	 SELECT
	 e.EmployeeId,
	 e.Name,
	 d.DepartmentName,
	 e.Salary,
	 ISNULL(e.Salary,0)*12 AS AnnualSalary,
	 CASE
		WHEN e.Salary IS NULL THEN 0
		WHEN e.Salary>=38000 THEN e.Salary*0.10
		WHEN e.Salary>=35000 THEN e.Salary*0.08
		ELSE e.Salary*0.05
	END AS BonusAmount,
	CASE
		WHEN e.Salary IS NULL THEN 'Not Available'
		WHEN e.Salary>=38000 THEN 'High Salary'
		WHEN e.Salary>=35000 THEN 'Medium Salary'
		ELSE 'Low Salary'
	END As SalaryGrade
 FROM Employees e
 INNER JOIN Department d
 ON d.DepartmentId=e.DepartmentId
 WHERE e.DepartmentId=@DepartmentId

 RETURN;
END;


SELECT * FROM dbo.GetEmployeeSalaryReport(2);

Select * from  Employees




-- Triggers

select * from Employees

Select * from Department


CREATE TABLE EmployeeAudit
(
AuditId int Identity(1,1) primary key,
AuditData varchar(max),
AuditDate datetime
)


CREATE TRIGGER tr_Employee_insert
ON Employees
AFTER INSERT
AS 
BEGIN
	DECLARE @Id INT
	DECLARE @Name varchar(100)
	DECLARE @AuditData varchar(100)
	SELECT @ID=EmployeeId,@Name=Name FROM INSERTED
	SET @AuditData='New Employee added with ID ='+Cast(@ID as VARCHAR(10))+
	' and Name '+@Name

	INSERT INTO EmployeeAudit(AuditData,AuditDate) VALUES (@AuditData,GETDATE())
END;

select * from Employees;

select * from EmployeeAudit;

insert into Employees (Name,Gender,Email,City,Salary,MobileNo,DepartmentId)
Values ('sample','Female','sample@mail.com','Vellore',45000,23876576334,1);


CREATE TRIGGER tr_Employee_delete
ON Employees
AFTER DELETE
AS 
BEGIN
	DECLARE @Id INT
	DECLARE @Name varchar(100)
	DECLARE @AuditData varchar(100)
	SELECT @ID=EmployeeId,@Name=Name FROM DELETED
	SET @AuditData='An Employee delete  with ID ='+Cast(@ID as VARCHAR(10))+
	' and Name '+@Name

	INSERT INTO EmployeeAudit(AuditData,AuditDate) VALUES (@AuditData,GETDATE())
END;

delete from Employees where EmployeeId=12;


ALTER TRIGGER tr_Employee_update
ON Employees
FOR UPDATE
AS 
BEGIN
	DECLARE @Id INT
	DECLARE @old_Name varchar(100),@new_Name varchar(100)
	DECLARE @old_Salary DECIMAL(10,2), @new_Salary  DECIMAL(10,2)
	DECLARE @old_Gender varchar(100),@new_Gender varchar(100)
	DECLARE @old_Email VARCHAR(100), @new_Email  VARCHAR(100)
	DECLARE @old_City varchar(100),@new_City varchar(100)
	DECLARE @AuditData varchar(max)
	
	select * INTO #UpdatedDataTempTable FROM INSERTED

	WHILE(EXISTS(SELECT EmployeeId FROM #UpdatedDataTempTable))
	BEGIN
		SET @AuditData=''

		SELECT TOP 1 @Id=EmployeeId,
		@new_Name=Name,
		@new_Gender=Gender,
		@new_City=City,
		@new_Email=Email,
		@new_Salary=Salary FROM #UpdatedDataTempTable

		SELECT 
		@old_Name=Name,
		@old_Gender=Gender,
		@old_City=City,
		@old_Email=Email,
		@old_Salary=Salary FROM DELETED where EmployeeId=@Id

		set @AuditData='Employee with id = ' +cast(@Id as varchar(10))+' Changed'

		If(@old_Name<>@new_Name)
		BEGIN
		SET @AuditData= @AuditData +' Name from ' +@old_Name +' to '+@new_Name
		END
		
		If(@old_Gender<>@new_Gender)
		BEGIN
		SET @AuditData= @AuditData +' Gender from ' +@old_Gender +' to '+@new_Gender
		END
		If(@old_City<>@new_City)
		BEGIN
		SET @AuditData= @AuditData +' City from ' +@old_City +' to '+@new_City
		END
		If(@old_Email<>@new_Email)
		BEGIN
		SET @AuditData= @AuditData +' Email from ' +@old_Email +' to '+@new_Email
		END
		
		If(@old_Salary<>@new_Salary)
		BEGIN
		SET @AuditData= @AuditData +' Salary from ' + ISNULL(CAST(@old_Salary AS VARCHAR(10)),NULL) +
		' to '+ISNULL(CAST(@new_Salary as varchar(10)),NULL)
		END
		
	INSERT INTO EmployeeAudit(AuditData,AuditDate) VALUES (@AuditData,GETDATE())

	DELETE FROM #UpdatedDataTempTable WHERE EmployeeId=@ID
	END
END;


select * from Employees;
select * from EmployeeAudit

update Employees Set Email='Yokiths@hexaware.com'  where EmployeeId=7

--INSTEAD TRIGGER

create trigger tr_InsteadOfInsert_Employees
ON Employees
INSTEAD OF INSERT
AS
BEGIN
	IF EXISTS
	(
	SELECT 1 FROM INSERTED WHERE SALARY<10000
	)
	BEGIN
		RAISERROR('Salary should not be less than 10000.',16,1);
		RETURN;
	END;
insert into Employees
(Name,Gender,City,Salary,Email,MobileNo,DepartmentId)
SELECT Name,Gender,City,Salary,Email,MobileNo,DepartmentId FROM INSERTED;
END


insert into Employees (Name,Gender,City,Email,Salary)
Values ('sample','Male','Texas','sample@mail.com',2000) -- error because of instead of triger


insert into Employees (Name,Gender,City,Email,Salary)
Values ('sample','Male','Texas','sample@mail.com',12000)