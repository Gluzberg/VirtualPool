CREATE TABLE `product_category`(
    `Id` TINYINT(3) UNSIGNED NOT NULL,
    `Name` VARCHAR(100) NOT NULL,
    PRIMARY KEY(`Id`)
) COLLATE = 'utf8_general_ci' ENGINE = InnoDB; 

CREATE TABLE `client_user`(
    `Id` VARCHAR(32) NOT NULL,
	`Password` VARCHAR(100) NOT NULL,
    `Name` VARCHAR(100) NOT NULL,
	`Product_Category_Id` TINYINT(3) UNSIGNED,
    PRIMARY KEY(`Id`),
    CONSTRAINT `FK_user_product_category` FOREIGN KEY(`Product_Category_Id`) REFERENCES `product_category`(`Id`) ON UPDATE NO ACTION ON DELETE NO ACTION
) COLLATE = 'utf8_general_ci' ENGINE = InnoDB; 

CREATE TABLE `product`(
    `Id` INT(32) NOT NULL,
    `Category_Id` TINYINT(3) UNSIGNED NOT NULL,
	`Blocking_User_Id` VARCHAR(32),
    PRIMARY KEY(`Id`),
    CONSTRAINT `FK_product_product_category` FOREIGN KEY(`Category_Id`) REFERENCES `product_category`(`Id`) ON UPDATE NO ACTION ON DELETE NO ACTION,
	CONSTRAINT `FK_blocking_user_product` FOREIGN KEY(`Blocking_User_Id`) REFERENCES `client_user`(`Id`) ON UPDATE NO ACTION ON DELETE NO ACTION
) COMMENT = 'product' COLLATE = 'utf8_general_ci' ENGINE = InnoDB; 

CREATE TABLE `article`(
    `Id` VARCHAR(32) NOT NULL,
    `Product_Id` INT(32) NOT NULL,
	`Active` BIT(1) NOT NULL DEFAULT b'0',
    PRIMARY KEY(`Id`),
    CONSTRAINT `FK_article_product` FOREIGN KEY(`Product_Id`) REFERENCES `product`(`Id`) ON UPDATE NO ACTION ON DELETE NO ACTION
) COMMENT = 'represents one unique article with a reference to a specific product' COLLATE = 'utf8_general_ci' ENGINE = InnoDB; 