CREATE TABLE burgershack (
  Id int NOT NULL AUTO_INCREMENT,
BurgerName VARCHAR(255),
PRIMARY KEY (id)
);


INSERT INTO burgershack (BurgerName) VALUES ("Carissa Burger");
INSERT INTO burgershack (BurgerName) VALUES ("Sally Burger");
INSERT INTO burgershack (BurgerName) VALUES ("Joe");

--selects all tata from table
-- SELECT * FROM burgershack;

--deletes table and all data
-- DROP TABLE burgershack;