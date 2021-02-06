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

INSERT INTO Cars(CarId, BrandId, ColorId,ModelYear,DailyPrice,Description )
VALUES (1,1,1,2021,20000,'Arac1');

INSERT INTO Cars(CarId, BrandId, ColorId,ModelYear,DailyPrice,Description )
VALUES (2,2,1,2020,16000,'Arac2');

INSERT INTO Cars(CarId, BrandId, ColorId,ModelYear,DailyPrice,Description )
VALUES (3,3,1,2019,12000,'Arac3');

INSERT INTO Cars(CarId, BrandId, ColorId,ModelYear,DailyPrice,Description )
VALUES (4,1,3,2018,18000,'Arac4');

INSERT INTO Cars(CarId, BrandId, ColorId,ModelYear,DailyPrice,Description )
VALUES (5,2,2,2017,14000,'Arac5');

INSERT INTO Cars(CarId, BrandId, ColorId,ModelYear,DailyPrice,Description )
VALUES (6,3,1,2016,10000,'Arac6');



SELECT * FROM Cars;

