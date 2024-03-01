create database carisma
use carisma
create table emp(Eid int primary key, Employee_name varchar(20) not null,Employee_Email varchar(40) check(Employee_Email like '%[@/.]%'),Employee_mobile bigint unique check(len(Employee_mobile)<=10),Employee_DOB datetime not null, last_date_modified datetime default getdate())


select * from emp