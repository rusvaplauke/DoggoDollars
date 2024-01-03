CREATE TABLE "Users" (
	"Id" SERIAL PRIMARY KEY NOT NULL,
	"Name" VARCHAR(80) NOT NULL,
	"Address" VARCHAR(200) NOT NULL,
	"IsDeleted" BOOLEAN DEFAULT FALSE
);

CREATE TABLE "AccountTypes" (
	"Id" INT PRIMARY KEY NOT NULL,
	"Name" VARCHAR(20) NOT NULL
);

CREATE TABLE "Accounts" (
	"Id" CHAR(8) PRIMARY KEY NOT NULL,
	"UserId" INT NOT NULL,
	"TypeId" INT NOT NULL,
	"Balance" DECIMAL DEFAULT 0.0,
	"IsDeleted" BOOLEAN DEFAULT FALSE,
	FOREIGN KEY ("UserId") REFERENCES "Users"("Id"),
	FOREIGN KEY ("TypeId") REFERENCES "AccountTypes"("Id")
);

CREATE TABLE "TransactionTypes" (
	"Id" INT PRIMARY KEY NOT NULL,
	"Name" VARCHAR(20) NOT NULL
);

CREATE TABLE "Transactions" (
	"Id" SERIAL PRIMARY KEY NOT NULL,
	"Timestamp" TIMESTAMP NOT NULL,
	"TypeId" INT NOT NULL,
	"FromAccount" CHAR(8) DEFAULT NULL,
	"ToAccount" CHAR(8) NOT NULL,
	"Amount" DECIMAL CONSTRAINT positive_amount CHECK ("Amount" > 0),
	"Fees" DECIMAL,
	FOREIGN KEY ("FromAccount") REFERENCES "Accounts"("Id"),
	FOREIGN KEY ("ToAccount") REFERENCES "Accounts"("Id"),
	FOREIGN KEY ("TypeId") REFERENCES "TransactionTypes"("Id")
);