# nmcnpm
# sql query 
use NMCNPM
go
create proc sp_getHDBH
as
select * from HoaDonBanHang inner join CTHoaDonBan on HoaDonBanHang.MaHD = CTHoaDonBan.MaHD
go
alter proc sp_insertHDBH
@MaHD int,
@MaNV nvarchar(50),
@MaKH nvarchar(50),
@Soban nvarchar(50),
@Thoigian datetime,
@Giamgia float,
@MaMon int,
@Soluong int
as 
insert into HoaDonBanHang
values(@MaHD,@MaNV,@MaKH,@Soban,@Thoigian,@Giamgia)
insert into CTHoaDonBan
values(@MaHD,@MaMon,@Soluong)
go
create proc sp_updateHDBH
@MaHD int,
@MaNV nvarchar(50),
@MaKH nvarchar(50),
@Soban nvarchar(50),
@Giamgia float,
@MaMon int,
@Soluong int
as
update HoaDonBanHang
set MaHD = @MaHD,
MaNV = @MaNV,
MaKH = @MaKH,
Soban = @Soban,
Giamgia = @Giamgia
where MaHD = @MaHD
update CTHoaDonBan
set MaHD = @MaHD,
MaMon = @MaMon,
Soluong = @Soluong
where MaHD = @MaHD
go



