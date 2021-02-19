drop table Rentals;
drop table Customers;
drop table Users;
drop table Cars;
drop table Brands;
drop table Colors;



INSERT INTO Brands(BrandId,BrandName )
VALUES (1,'Mercedes');
INSERT INTO Brands(BrandId,BrandName )
VALUES (2,'Skoda');
INSERT INTO Brands(BrandId,BrandName )
VALUES (3,'Audi');

SELECT * FROM Brands;

INSERT INTO Colors(ColorId,ColorName )
VALUES (1,'Beyaz');
INSERT INTO Colors(ColorId,ColorName )
VALUES (2,'Gümüş');
INSERT INTO Colors(ColorId,ColorName )
VALUES (3,'Siyah');

SELECT * FROM Colors;

INSERT INTO Cars(CarId, BrandId, ColorId,DailyPrice,ModelYear,Description )
VALUES (1,1,1,20000,2021,'Arac1');

INSERT INTO Cars(CarId, BrandId, ColorId,DailyPrice,ModelYear,Description )
VALUES (2,2,1,16000,2020,'Arac2');

INSERT INTO Cars(CarId, BrandId, ColorId,DailyPrice,ModelYear,Description )
VALUES (3,3,1,12000,2019,'Arac3');

INSERT INTO Cars(CarId, BrandId, ColorId,DailyPrice,ModelYear,Description )
VALUES (4,1,3,18000,2018,'Arac4');

INSERT INTO Cars(CarId, BrandId, ColorId,DailyPrice,ModelYear,Description )
VALUES (5,2,2,14000,2017,'Arac5');

INSERT INTO Cars(CarId, BrandId, ColorId,DailyPrice,ModelYear,Description )
VALUES (6,3,1,10000,2016,'Arac6');

SELECT * FROM Cars;