-- DROP TABLE burgershack;
-- CREATE TABLE Burgers (
--   Id int NOT NULL AUTO_INCREMENT,
--   name VARCHAR(255),
--   description VARCHAR(255),
--   price int,
--   PRIMARY KEY (id)
-- );
--  CREATE TABLE Customers (
--   Id int NOT NULL AUTO_INCREMENT,
--   name VARCHAR(255),
--   PRIMARY KEY (id)
-- );
--  CREATE TABLE FaveBurgers (
--   id int NOT NULL AUTO_INCREMENT,
--   customerId int NOT NULL,
--   burgerId int NOT NULL,

--   PRIMARY KEY (id),
--   INDEX ( customerId, burgerId),

--   FOREIGN KEY (customerId)
--     REFERENCES Customer(id)
--       ON DELETE CASCADE,

--   FOREIGN KEY (burgerId)
--     REFERENCES Burger(id)
--       ON DELETE CASCADE
-- );
-- CREATE TABLE Drinks (
--   Id int NOT NULL AUTO_INCREMENT,
--   name VARCHAR(255),
--   description VARCHAR(255),
--   price int,
--   PRIMARY KEY (id)
-- );

-- CREATE TABLE Sides (
--   Id int NOT NULL AUTO_INCREMENT,
--   name VARCHAR(255),
--   description VARCHAR(255),
--   price int,
--   PRIMARY KEY (id)
-- );




-- INSERT INTO burgershack (BurgerName) VALUES ("Carissa Burger");
-- INSERT INTO burgershack (BurgerName) VALUES ("Sally Burger");
-- INSERT INTO burgershack (BurgerName) VALUES ("Joe");

--selects all data from table (get all)
-- SELECT * FROM burgershack;

--deletes table and all data
-- DROP TABLE burgershack;

-- get by id 
--SELECT * FROM burgershack WHERE id = 1

-- UPDATE burgershack SET 
-- NAME = "Carissa Burger"
-- WHERE id  = 1;
-- SELECT * FROM burgershack WHERE id = 1;

--delete from burgershack
--DELETE FROM burgershack WHERE id = 1;