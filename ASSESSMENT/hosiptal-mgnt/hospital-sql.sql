use hospital_Mgnt

create table admin_log (
role_id int  identity(1,1)  primary key,
role_name varchar(15) null,
)

--doctors tble

create table doctors (
doctors_id int identity primary key,
doctors_name varchar(20),
specialization varchar(20),
role int foreign key references admin_log(role_id))

--alter foreign key

ALTER TABLE patients
ADD CONSTRAINT FK_patients
FOREIGN KEY (role) REFERENCES admin_log(role_id);
--patients tble
create table patients (
patient_id int identity primary key,
patient_name varchar(20),
age int ,
gender varchar(20),
address varchar(20),
disease varchar(30),
role int ,
doctors_id int foreign key references doctors(doctors_id),
)



--laboratory tble

create table laboratory (
lab_no int identity primary key,
patient_id int foreign key references patients(patient_id) ,
doctors_id int foreign key references doctors(doctors_id),
date date,
amount float)

----room tble
create table room(
room_no int identity primary key,
room_type varchar(50),
status varchar(20)) 


---patient admission lab tble

create table patient_in(
patient_id int identity primary key,
room_no int foreign key references room(room_no),
date_of_adm date,
date_of_dis date,
lab_no int foreign key references laboratory(lab_no)) 


----patient discharge tble
create table patient_out(
patient_id int identity primary key,
date_of_dis date,
lab_no int foreign key references laboratory(lab_no)) 



----bill
create table bill(
bill_no int identity primary key,
patient_id int foreign key references patients(patient_id),
doctor_charge int,
room_charge int,
no_of_days int,
lab_charge int,
bill int) 




---inserting admin roles
insert into admin_log (role_name)values('doctors'),('patients')

---inserting doctors values
create table doctors (
doctors_id int identity primary key,
doctors_name varchar(20),
specialization varchar(20),
role int foreign key references admin_log(role_id))

create procedure sp_Doctors
(@doctors_name varchar(20),
@specialization varchar(20),
@role int
)
as
begin
insert into doctors(doctors_name,specialization,role) values(@doctors_name,@specialization,@role)
end

exec sp_Doctors
@doctors_name='Sahithi',@specialization='Dermotalogist',@role=1

select *from doctors


---insert values for patient
create procedure sp_Patients
(@patient_name varchar(20),
@age varchar(20),
@gender varchar(20),
@address varchar(50),
@disease  varchar(50),
@role int,
@doctors_id int
)
as
begin
insert into patients(patient_name,age,gender,address,disease,role,doctors_id) values(@patient_name,@age,@gender,@address,@disease,@role,@doctors_id)
end

exec sp_Patients
@patient_name='soumya',
@age=23,
@gender='female',
@address='vizag',
@disease='skin',
@role='2',
@doctors_id='4'

select * from patients


---insert lab values

insert into laboratory (patient_id,doctors_id,date,amount) values(1,1,2021-01-19 ,1500),(2,3,2022-03-09 ,1000),(3,4,2021-07-29 ,5000)
select * from laboratory

insert into room(room_type,status)values('General','active'),('OPT','inactive'),('non-general','inactive')

select * from room
insert into patient_in(room_no,date_of_adm,date_of_dis,lab_no)
values(1000,2021-01-19,2021-06-06,1),(1001,2022-03-09,2022-07-03,2),(1002,2021-07-29,2022-01-03,3)
select * from patient_in


insert into bill(patient_id,doctor_charge,room_charge,no_of_days,lab_charge,bill)
values
(1,2000,1000,35,1500,4500),
(2,300,500,40,2000,2800),
(3,500,200,30,5000,5700)
select * from bill


---triggers

create table bill_test
(
BID int primary key identity,
 bill_no INT ,
operation varchar(30),
updatedDate datetime ,
) 
CREATE TRIGGER TrgUpdateBills
ON bill
after UPDATE 
AS
BEGIN
insert into bill_test
  select bill_no,'updated',GETDATE() from deleted 
    END

update bill set   room_charge=600 where patient_id=1


----doctors values updating using triggers

CREATE TRIGGER TrgUpdateDoctors
ON doctors
after UPDATE 
AS
BEGIN
insert into bill_test
  select doctors_id,'updated',GETDATE() from deleted 
    END

	update doctors set doctors_name='suhas' where doctors_id=2
select * from bill_test
