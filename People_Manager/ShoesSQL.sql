create table Shoes
(
	IDShoes int primary key identity,
	Brand nvarchar(20) not null,
	Size int not null,
	ShoesPicture varbinary(max) null,
	PersonID int
	foreign key (PersonID) references Person(IDPerson) on delete cascade
)
go

/*All shoes*/
alter proc GetAllShoesForSinglePerson
	@personID int
as
select * from Shoes where PersonID = @personID
go

/*Add new shoes*/
alter PROC AddShoes
	@brand nvarchar,
	@size int,
	@ShoesPicture varbinary(max),
	@personID int,
	@idShoes int output
as 
begin
	insert into Shoes values (@brand, @size, @ShoesPicture, @personID)
		set @idShoes = SCOPE_IDENTITY()
end
go

/*Update shoes*/
alter PROC UpdateShoes
	@brand nvarchar,
	@size int,
	@shoesPicture varbinary(max),
	@personID int
as 
update Shoes SET 
		Brand = @brand,
		Size = @size,
		ShoesPicture = @shoesPicture,
		PersonID = @personID
	where 
		PersonID = @personID
go

/*Delete shoes*/
create proc DeleteShoes
	@personID int
as
delete from Shoes where PersonID = @personID
go

select * from Shoes as s
join Person as p on s.personid=p.idperson


delete from shoes 
where personid = 2
