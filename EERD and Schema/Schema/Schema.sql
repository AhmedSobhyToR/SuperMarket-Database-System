
CREATE TABLE project_category
(
  name VARCHAR(50) NOT NULL,
  caID INT NOT NULL,
  PRIMARY KEY (caID),
);

CREATE TABLE project_person
(
  fname VARCHAR(50) NOT NULL,
  lname VARCHAR(50) NOT NULL,
  tname VARCHAR(50) NOT NULL,
  phone VARCHAR(50) NOT NULL,
  perID INT NOT NULL,
  address VARCHAR(50) NOT NULL,
  PRIMARY KEY (perID),
  UNIQUE (phone)
);

CREATE TABLE project_customer
(
  customerID INT NOT NULL,
  PRIMARY KEY (customerID),
  FOREIGN KEY (customerID) REFERENCES project_person(perID)
);

CREATE TABLE project_admin
(
  adminID INT NOT NULL,
  PRIMARY KEY (adminID),
  FOREIGN KEY (adminID) REFERENCES project_person(perID)
);

CREATE TABLE project_cart
(
  cartID INT NOT NULL,
  totalCost FLOAT NOT NULL,
  quantity INT NOT NULL,
  PRIMARY KEY (cartID)
);

CREATE TABLE project_account
(
  username VARCHAR(50) NOT NULL,
  password VARCHAR(50) NOT NULL,
  perID INT NOT NULL,
  PRIMARY KEY (username),
  FOREIGN KEY (perID) REFERENCES project_person(perID)
);

CREATE TABLE project_product
(
  pID INT NOT NULL,
  price FLOAT NOT NULL,
  expireDate DATE NOT NULL,
  name VARCHAR(50) NOT NULL,
  quantity INT NOT NULL,
  caID INT NOT NULL,
  PRIMARY KEY (pID),
  FOREIGN KEY (caID) REFERENCES project_category(caID)
);

CREATE TABLE project_added_to
(
  pID INT NOT NULL,
  cartID INT NOT NULL,
  PRIMARY KEY (pID, cartID),
  FOREIGN KEY (pID) REFERENCES project_product(pID),
  FOREIGN KEY (cartID) REFERENCES project_cart(cartID)
);

create TABLE project_Order
(
  quantity FLOAT NOT NULL,
  price FLOAT NOT NULL,
  orderDate DATE NOT NULL,
  oID INT NOT NULL,
  customerID INT NOT NULL,
  pID INT NOT NULL,
  PRIMARY KEY (oID),
  FOREIGN KEY (customerID) REFERENCES project_customer(customerID),
  FOREIGN KEY (pID) REFERENCES project_product(pID),
  UNIQUE (customerID, pID)
);

