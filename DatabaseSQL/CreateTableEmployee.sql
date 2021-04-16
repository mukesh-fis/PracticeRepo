--Create a table named Employee with salary as one column

CREATE SEQUENCE employeeId
    INCREMENT BY 1
    START WITH 1
    MINVALUE 1
    MAXVALUE 1000
    CYCLE
    CACHE 2;

Drop Table Employee;

Create Table Employee
(
	Id   Varchar2(5) not null,
	Name Varchar2(20),
	Salary Number(10,2),
	deptNo Varchar2(10)default 100 not null
);

--Insert a few records
insert into Employee(Id, Name, Salary) Values(employeeId.nextval, 'Aditya Kaushik', 10000);
insert into Employee(Id, Name, Salary) Values(employeeId.nextval, 'Kumar Kaushik', 20000);
insert into Employee(Id, Name, Salary) Values(employeeId.nextval, 'Kumar Birla', 15000);
insert into Employee(Id, Name, Salary) Values(employeeId.nextval, 'Rohit Kaushik', 5000);
insert into Employee(Id, Name, Salary) Values(employeeId.nextval, 'Kumar Ashok', 7000);
insert into Employee(Id, Name, Salary) Values(employeeId.nextval, 'Kumar Abhishek', 15000);
commit;