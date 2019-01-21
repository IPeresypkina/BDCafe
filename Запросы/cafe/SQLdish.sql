  CREATE TABLE dish(
  iddish INT PRIMARY KEY,
  title VARCHAR(255) NOT NULL ,
  quantily INT NOT NULL ,
  cafe_idcafe INT NOT NULL REFERENCES cafe (idcafe)
    ON DELETE SET NULL
    ON UPDATE CASCADE
	)