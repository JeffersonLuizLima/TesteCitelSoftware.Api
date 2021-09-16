CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(150) CHARACTER SET utf8mb4 NOT NULL,
    `ProductVersion` varchar(32) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
) CHARACTER SET utf8mb4;

START TRANSACTION;

ALTER DATABASE CHARACTER SET utf8mb4;

CREATE TABLE `Categorias` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Descricao` varchar(80) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK_Categorias` PRIMARY KEY (`Id`)
) CHARACTER SET utf8mb4;

CREATE TABLE `Produtos` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Nome` varchar(200) CHARACTER SET utf8mb4 NOT NULL,
    `Descricao` varchar(1000) CHARACTER SET utf8mb4 NOT NULL,
    `Valor` decimal(10,2) NOT NULL,
    `CategoriaId` int NULL,
    CONSTRAINT `PK_Produtos` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Produtos_Categorias_CategoriaId` FOREIGN KEY (`CategoriaId`) REFERENCES `Categorias` (`Id`) ON DELETE RESTRICT
) CHARACTER SET utf8mb4;

CREATE INDEX `IX_Produtos_CategoriaId` ON `Produtos` (`CategoriaId`);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20210916043350_Initial', '5.0.10');

COMMIT;

