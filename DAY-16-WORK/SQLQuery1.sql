create table tblEmployee
(Id int identity(101,1) primary key,
Name varchar(20) not null,
Password varchar(20) not null,
Location varchar(20),
Phone varchar(20),
Vechicle_Id char(8))

create table tblDriver1
(ID int identity(1000,1) primary key,
Name varchar(20),
Phone varchar(20),
status varchar(50) check(status in ('active','not active')))


create table tblVehicle
(Vechicle_number char(8) primary key,
Type varchar(10),
Capacity int,
Driver_ID int references tblDriver1(id),
Filled_Status int ,
status varchar(50) check(status in ('running','discard')))

alter table tblEmployee
add constraint fk_VID foreign key(Vechicle_Id) 
references tblVehicle(Vechicle_number)

create proc proc_InsertEmployee(@eName varchar(20),
@ePassword varchar(20),
@eLocation varchar(20),
@ePhone varchar(20)
) 
as
  Insert into tblEmployee(Name,Password,Location,Phone)values(@eName,@ePassword,@eLocation,
  @ePhone)
  
  exec proc_InsertEmployee 'Balkrishna', '1234','Uttar', '9450201977'
  create proc proc_UpdatePassword(@eid int,@ePassword varchar(20))
  as 
  update tblEmployee set Password=@ePassword where id=@eid


  create proc proc_GetAllEmployees
  as
  select * from tblEmployee
  exec proc_GetAllEmployees


  create proc proc_InsertDrivers(@eName varchar(20),
@ePhone varchar(20),
@eStatus varchar(50),
@eArea varchar(20))
as
	Insert into tblDriver1(Name,Phone,status,Area) values(@eName,@ePhone,@eStatus,@eArea)

create proc proc_UpdateDriversPhone(@ePhone varchar(20),@eId int)
as
update tblDriver1 set Phone = @ePhone where Id = @eId

create proc proc_UpdateDriversStatus(@eStatus varchar(20),@eId int)
as
update tblDriver1 set status = @eStatus where Id = @eId

create proc proc_GetAllDrivers
as
select * from tblDriver1

alter table tbldriver1 add Area varchar(20)
select * from tblMovie