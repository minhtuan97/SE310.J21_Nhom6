/*file script chay du lieu*/

/*Báng Học sinh sinh viên */
insert into HOCSINHSINHVIEN values('HS0000001','123456789013','Đại học Công Nghệ Thông Tin','Tân Lập, Đông Hòa, Dĩ An, Bình Dương','2018-01-01','2018-06-01','');
insert into HOCSINHSINHVIEN values('HS0000002','123456789019','THCS Lê Văn Tám','Khu Phố 6, Phường Linh Trung, Quận Thủ Đức, TP Hồ Chí Minh','2018-01-01','2018-06-01','Trộm cướp');
insert into HOCSINHSINHVIEN values('HS0000003','123456789018','Đại học Khoa Học Tự Nhiên','Tân Lập, Đông Hòa, Dĩ An, Bình Dương','2018-01-01','2018-06-01','');

/*Báng Nhân khẩu */
insert into NHANKHAU values('123456789011','Phan Văn Tùng','','1980-01-01','Nam','Tân Lập, Đông Hòa, Dĩ An, Bình Dương','Tân Lập, Đông Hòa, Dĩ An, Bình Dương','Kinh','Không','Việt Nam','','Tân Lập, Đông Hòa, Dĩ An, Bình Dương','Tân Lập, Đông Hòa, Dĩ An, Bình Dương','0123456789','12/12','Bác sĩ','','A','Công chức nhà nước');
insert into NHANKHAU values('123456789012','Lê Thùy Trang','Moon','1982-01-01','Nữ','Tân Lập, Đông Hòa, Dĩ An, Bình Dương','Tân Lập, Đông Hòa, Dĩ An, Bình Dương','Kinh','Không','Việt Nam','','Tân Lập, Đông Hòa, Dĩ An, Bình Dương','Tân Lập, Đông Hòa, Dĩ An, Bình Dương','0123456788','12/12','','','Pháp','Công chức nhà nước');
insert into NHANKHAU values('123456789013','Phan Thùy Nhi','','2000-01-01','Nữ','Tân Lập, Đông Hòa, Dĩ An, Bình Dương','Tân Lập, Đông Hòa, Dĩ An, Bình Dương','Kinh','Phật giáo','Việt Nam','','Tân Lập, Đông Hòa, Dĩ An, Bình Dương','Tân Lập, Đông Hòa, Dĩ An, Bình Dương','0123456787','12/12','','','A','Sinh viên');
insert into NHANKHAU values('123456789014','Hà Tùng Mậu','','1990-01-01','Nam','Tân Lập, Đông Hòa, Dĩ An, Bình Dương','Tân Lập, Đông Hòa, Dĩ An, Bình Dương','Kinh','Không','Việt Nam','','Tân Lập, Đông Hòa, Dĩ An, Bình Dương','Tân Lập, Đông Hòa, Dĩ An, Bình Dương','0123456786','12/12','','','','Tài xế');
insert into NHANKHAU values('123456789015','Hà Thanh Nhân','','1997-01-01','Nam','Tân Lập, Đông Hòa, Dĩ An, Bình Dương','Tân Lập, Đông Hòa, Dĩ An, Bình Dương','Ê Đê','Không','Việt Nam','','Tân Lập, Đông Hòa, Dĩ An, Bình Dương','Tân Lập, Đông Hòa, Dĩ An, Bình Dương','0123456785','12/12','Giáo sư','','Nhật','Nông dân');
insert into NHANKHAU values('123456789016','Đặng Minh Tiến','','1997-01-01','Nam','Khu Phố 6, Phường Linh Trung, Quận Thủ Đức, TP Hồ Chí Minh','Khu Phố 6, Phường Linh Trung, Quận Thủ Đức, TP Hồ Chí Minh','Kinh','Không','Việt Nam','','Khu Phố 6, Phường Linh Trung, Quận Thủ Đức, TP Hồ Chí Minh','Tân Lập, Đông Hòa, Dĩ An, Bình Dương','0123456784','12/12','Kỹ sư','','A','Bác sĩ');
insert into NHANKHAU values('123456789017','Nguyễn Thu Hồng','','1987-01-01','Nữ','Khu Phố 6, Phường Linh Trung, Quận Thủ Đức, TP Hồ Chí Minh','Khu Phố 6, Phường Linh Trung, Quận Thủ Đức, TP Hồ Chí Minh','Kinh','Phật giáo','Việt Nam','','Khu Phố 6, Phường Linh Trung, Quận Thủ Đức, TP Hồ Chí Minh','Tân Lập, Đông Hòa, Dĩ An, Bình Dương','0123456783','9/12','','','Nga','Nghề tự do');
insert into NHANKHAU values('123456789018','Đào Quang Nhật','','1977-01-01','Nam','Khu Phố 6, Phường Linh Trung, Quận Thủ Đức, TP Hồ Chí Minh','Khu Phố 6, Phường Linh Trung, Quận Thủ Đức, TP Hồ Chí Minh','Kinh','Không','Việt Nam','','Khu Phố 6, Phường Linh Trung, Quận Thủ Đức, TP Hồ Chí Minh','Tân Lập, Đông Hòa, Dĩ An, Bình Dương','0123456782','12/12','','','','Sinh viên');

/*Báng Nhân khẩu tạm vắng */
insert into NHANKHAUTAMVANG values('TV0000001','123456789015','2018-01-01','2019-12-01','Đi nghĩa vụ quân sự','Quân Khu 7');
insert into NHANKHAUTAMVANG values('TV0000002','123456789017','2018-01-01','2019-12-01','Đi tù','Nhà tù Côn Đảo');

/*Báng Sổ tạm trú */
insert into SOTAMTRU values('ST0000001','TT0000001','Tân Lập, Đông Hòa, Dĩ An, Bình Dương','2018-01-01','2018-12-01');
insert into SOTAMTRU values('ST0000002','TT0000003','Tân Lập, Đông Hòa, Dĩ An, Bình Dương','2018-01-01','2018-12-01');

/*Báng Nhân khẩu tạm trú */
insert into NHANKHAUTAMTRU values('TT0000001','123456789016','Tân Lập, Đông Hòa, Dĩ An, Bình Dương','2018-01-01','2018-12-01','Đi làm','ST0000001');
insert into NHANKHAUTAMTRU values('TT0000002','123456789017','Tân Lập, Đông Hòa, Dĩ An, Bình Dương','2018-01-01','2018-12-01','Đi làm','ST0000001');
insert into NHANKHAUTAMTRU values('TT0000003','123456789018','Tân Lập, Đông Hòa, Dĩ An, Bình Dương','2018-01-01','2018-12-01','Đi học','ST0000002');

/*Báng Sổ hộ khẩu */
insert into SOHOKHAU values('SH0000001','TH0000001','Tân Lập, Đông Hòa, Dĩ An, Bình Dương','2018-01-01','1234568');
insert into SOHOKHAU values('SH0000002','TH0000004','Tân Lập, Đông Hòa, Dĩ An, Bình Dương','2018-01-01','1234567');

/*Báng Nhân khẩu thường trú */
insert into NHANKHAUTHUONGTRU values('TH0000001','123456789011','Tân Lập, Đông Hòa, Dĩ An, Bình Dương','','SH0000001');
insert into NHANKHAUTHUONGTRU values('TH0000002','123456789012','Tân Lập, Đông Hòa, Dĩ An, Bình Dương','Vợ','SH0000001');
insert into NHANKHAUTHUONGTRU values('TH0000003','123456789013','Tân Lập, Đông Hòa, Dĩ An, Bình Dương','Con','SH0000001');
insert into NHANKHAUTHUONGTRU values('TH0000004','123456789014','Tân Lập, Đông Hòa, Dĩ An, Bình Dương','','SH0000002');
insert into NHANKHAUTHUONGTRU values('TH0000005','123456789015','Tân Lập, Đông Hòa, Dĩ An, Bình Dương','Con','SH0000002');

/*Báng Tiểu sử */
insert into TIEUSU values('TS0000001','123456789011','2017-01-01','2018-01-01','Tân Lập, Đông Hòa, Dĩ An, Bình Dương','Công chức nhà nước','Tân Lập, Đông Hòa, Dĩ An, Bình Dương');
insert into TIEUSU values('TS0000002','123456789012','2017-01-01','2018-01-01','Tân Lập, Đông Hòa, Dĩ An, Bình Dương','Công chức nhà nước','Tân Lập, Đông Hòa, Dĩ An, Bình Dương');
insert into TIEUSU values('TS0000003','123456789013','2017-01-01','2018-01-01','Tân Lập, Đông Hòa, Dĩ An, Bình Dương','Sinh viên','An Hòa, Đông Hòa, Dĩ An, Bình Dương');
insert into TIEUSU values('TS0000004','123456789014','2017-01-01','2018-01-01','Tân Lập, Đông Hòa, Dĩ An, Bình Dương','Tài xế','Tân Lập, Đông Hòa, Dĩ An, Bình Dương');
insert into TIEUSU values('TS0000005','123456789015','2017-01-01','2018-01-01','Tân Lập, Đông Hòa, Dĩ An, Bình Dương','Nông dân','Tân Lập, Đông Hòa, Dĩ An, Bình Dương');
insert into TIEUSU values('TS0000006','123456789016','2017-01-01','2018-01-01','Khu Phố 6, Phường Linh Trung, Quận Thủ Đức, TP Hồ Chí Minh','Bác sĩ','Khu Phố 6, Phường Linh Trung, Quận Thủ Đức, TP Hồ Chí Minh');
insert into TIEUSU values('TS0000007','123456789017','2017-01-01','2018-01-01','Khu Phố 6, Phường Linh Trung, Quận Thủ Đức, TP Hồ Chí Minh','Nghề tự do','Khu Phố 6, Phường Linh Trung, Quận Thủ Đức, TP Hồ Chí Minh');
insert into TIEUSU values('TS0000008','123456789018','2017-01-01','2018-01-01','Khu Phố 6, Phường Linh Trung, Quận Thủ Đức, TP Hồ Chí Minh','Học sinh','Khu Phố 6, Phường Linh Trung, Quận Thủ Đức, TP Hồ Chí Minh');

/*Báng Tiền án tiền sự */
insert into TIENANTIENSU values('TA0000001','123456789011','','','','2018-01-01');
insert into TIENANTIENSU values('TA0000002','123456789012','','','','2018-11-14');
insert into TIENANTIENSU values('TA0000003','123456789013','','','','2018-11-14');
insert into TIENANTIENSU values('TA0000004','123456789014','Gây rối trật tự công cộng','Phạt hành chính','','2018-01-01');
insert into TIENANTIENSU values('TA0000005','123456789015','Vi phạm luật giao thông','phạt hành chính','','2018-01-01');
insert into TIENANTIENSU values('TA0000006','123456789016','','','','2018-11-14');
insert into TIENANTIENSU values('TA0000007','123456789017','Lừa đảo','Đi tù','BA0001','2018-01-01');
insert into TIENANTIENSU values('TA0000008','123456789018','','','','2018-11-14');

/*Báng Cán bộ */
insert into CANBO values('CB0000001','TH0000001','cbdl01','123','0');
insert into CANBO values('CB0000002','TH0000002','cbhk01','123','1');