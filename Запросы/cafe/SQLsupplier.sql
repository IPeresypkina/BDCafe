CREATE TABLE supplier (
  idsupplier INT PRIMARY KEY,
  title VARCHAR(255) NOT NULL ,
  product VARCHAR(255) NOT NULL ,
  Frequencyofdeliveries INT NULL ,
  Volumeofdeliveries INT NULL ,
  cafe_idcafe INT NOT NULL REFERENCES cafe (idcafe)
    ON DELETE SET NULL
    ON UPDATE CASCADE
  )