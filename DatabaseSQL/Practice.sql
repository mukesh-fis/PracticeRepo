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

--Check if table contains data
select * from employee order by salary desc;

--Find second highest salary
--Method#1
select max(e.salary) from employee e,
(select Max(salary) as max_sal from employee)
where e.salary < max_sal;

--Method#2
select distinct salary from employee e1
where 2 = (select count(distinct salary) from employee e2 where e1.salary <= e2.salary);

-- or -- notice that when we use < we use the expression 1=
select distinct salary from employee e1
where 1 = (select count(distinct salary) from employee e2 where e1.salary < e2.salary);

--following will give nth highest where n = 2, 3, 4 ...
select distinct salary from employee e1
where n = (select count(distinct salary) from employee e2 where e1.salary <= e2.salary);

--Method# 3:
--We can use Dense_rank() function to get a numeric rank for each row and then print highest, second highest etc. 
select e.salary,
dense_rank() over (partition by e.deptNo order by e.salary desc) dRank
from employee e
where dRank.
/*
Output:
Salary  Rank
20000	1
15000	2
15000	2
10000	3
7000	4
5000	5
*/

select e.salary 

