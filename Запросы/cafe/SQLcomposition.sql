CREATE TABLE composition(
  idcomposition INT PRIMARY KEY,
  numingredient INT NOT NULL ,
  ingredient_idingredient INT NOT NULL REFERENCES ingredient (idingredient)
  ON DELETE SET NULL
  ON UPDATE CASCADE,
  dish_iddish INT NOT NULL REFERENCES dish (iddish)
    ON DELETE SET NULL
    ON UPDATE CASCADE,
  )