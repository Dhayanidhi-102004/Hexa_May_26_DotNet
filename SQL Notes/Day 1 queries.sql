create database Hexa_May_26_Dotnet;


use Hexa_May_26_Dotnet;

create table Department
(
DepartmentId int ,
DepartmentName varchar(100),
Location varchar(100)
);

ALTER TABLE Department alter Column DepartmentId int not null;
ALTER TABLE Department Add constraint pk_deptid Primary Key(DepartmentId);
Drop table Employee;
create table Employee
(
EmployeeId int Primary key identity,
Name varchar(100),
Gender varchar(10),
City Varchar(50),
Salary money,
Email varchar(50) unique,
MobileNo bigint
)


select * from Employee;

 insert into Employee (Name,Gender,City,salary,Email,MobileNo) values 
 ('LohanRaj','Male','Arakonam',35000,'lohanraj@mail.com',9876543210)


 -- partial insertion
 insert into Employee (Name,Gender,City) Values
 ('Sashi Kishor','Gender','Bhavani');


 alter table Employee alter COLUMN  Email varchar(50) NOT NULL ;

 SELECT 
tc.Constraint_name,tc.constraint_type,kcu.column_name 
FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE kcu
inner join INFORMATION_SCHEMA.TABLE_CONSTRAINTS tc
on tc.CONSTRAINT_NAME=kcu.CONSTRAINT_NAME
where tc.TABLE_NAME='Employee'
and kcu.COLUMN_NAME='Email';


alter table Employee drop constraint UQ__Employee__A9D10534DDA72405

update Employee  set Email='SashiiKishore@mail.com' where EmployeeId=2;

Alter Table Employee alter COLUMN Email varchar(50) NOT NULL;

ALter table Employee Add Constraint uq_Email UNIQUE(Email);

ALTER TABLE Employee Add  DepartmentId int;

Select * from Employee;
ALTER TABLE Employee Add Constraint fk_dept_emp
FOREIGN KEY(DepartmentId)
References Department(DepartmentId);

insert into Department 
VALUES
(4,'Transport','Mumbai'),
(2,'IT','Bangalore'),
(3,'Finance','Hyderabad')


insert into Employees
(Name,Gender,City,Salary,Email,MobileNo)
VALUES
('VijayGanesh','Male','Pune',38000,'vijayganesh@mail.com',87545432109),
('Yokith','Male','Mumbai',36000,'Yokith@mail.com',9765432109,2),
('Harini','Female','Hyderabad',38000,'harini@mail.com',8765432109,3)

select * from Employees;

-- Where Clause  

select * from Employee where City='Chennai' 

select * from Employee where City in ('Chennai' ,'Bangalore')
select * from Employee where City  not in ('Chennai' ,'Bangalore')

select * from Employee where EmployeeId between 3 and 5
select * from Employee where EmployeeId not between 3 and 5

select * from Employee where Name like 'H%'

select * from Employee where Name like 's%'

select * from Employee where Name like 's_s%'

SELECT Name,Salary,
salary -1000 as DecreasedSalary,
Salary*2 as DoubledSalary
FROM Employee

select * from Employee where City != 'Chennai';

select * from Employee where City <> 'Chennai';


select * from Employee where Salary is NULL;

SELECT Name +' - '+City as EmployeeDetails FROM Employee;


EXEC sp_rename 'Employee' ,'Employees';


select * from Employees;
Select * from Department;

--inner JOIN
SELECT	e.EmployeeId, e.Name,e.Gender,e.City,e.Salary , d.DepartmentName,d.Location
FROM Employees e
INNER JOIN Department d
ON d.DepartmentId=e.DepartmentId

---LEFT JOIN /LEFT OUTER JOIN
SELECT	e.EmployeeId, e.Name,e.Gender,e.City,e.Salary , d.DepartmentName,d.Location
FROM Employees e
LEFT JOIN Department d
ON d.DepartmentId=e.DepartmentId


-- Right Outer Join
SELECT e.EmployeeId,e.Name,d.DepartmentName, d.Location
FROM Employees e
RIGHT JOIN Department d
ON e.DepartmentId=d.DepartmentId;


-- FULL OUTER JOIN
SELECT 
e.EmployeeId,
e.Name,
d.DepartmentName,
d.DepartmentId,
d.location
FROM Employees e
FULL JOIN Department d
ON e.departmentId=d.departmentId


-- CROSS Join 

SELECT e.Name,d.DepartmentName 
FROM Employees e
CROSS JOIN Department d;

-- Find the employees working on IT department

SELECT e.EmployeeId,e.Name,e.City, e.Salary,d.DepartmentName FROM
Employees e
INNER JOIN 
Department d
ON e.DepartmentId=d.DepartmentId
WHERE d.DepartmentName='IT';


-- Find Department-wise EmployeeCount
SELECT d.DepartmentName,COUNT(e.EmployeeId) as TotalEmployees
FROM Department d
LEFT JOIN
Employees e
ON e.DepartmentId=d.DepartmentId
GROUP BY d.DepartmentName;