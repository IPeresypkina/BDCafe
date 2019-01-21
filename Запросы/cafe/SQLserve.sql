  CREATE TABLE  serve(
  idserve INT PRIMARY KEY,
  name VARCHAR(255) NOT NULL ,
  passport INT NOT NULL ,
  education VARCHAR(45) NULL ,
  experience INT NOT NULL ,
  cafe_idcafe INT NOT NULL REFERENCES cafe (idcafe)
    ON DELETE SET NULL
    ON UPDATE CASCADE
  )
  