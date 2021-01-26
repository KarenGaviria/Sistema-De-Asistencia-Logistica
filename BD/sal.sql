-- phpMyAdmin SQL Dump
-- version 5.0.3
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 03-12-2020 a las 21:34:55
-- Versión del servidor: 10.4.14-MariaDB
-- Versión de PHP: 7.4.11

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `sal`
--
CREATE DATABASE IF NOT EXISTS `sal` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `sal`;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `aspnetroleclaims`
--

CREATE TABLE IF NOT EXISTS `aspnetroleclaims` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `RoleId` varchar(127) NOT NULL,
  `ClaimType` text DEFAULT NULL,
  `ClaimValue` text DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  KEY `IX_AspNetRoleClaims_RoleId` (`RoleId`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 ROW_FORMAT=DYNAMIC;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `aspnetroles`
--

CREATE TABLE IF NOT EXISTS `aspnetroles` (
  `Id` varchar(127) NOT NULL,
  `Name` varchar(256) DEFAULT NULL,
  `NormalizedName` varchar(256) DEFAULT NULL,
  `ConcurrencyStamp` varchar(256) DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  UNIQUE KEY `RoleNameIndex` (`NormalizedName`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 ROW_FORMAT=DYNAMIC;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `aspnetuserclaims`
--

CREATE TABLE IF NOT EXISTS `aspnetuserclaims` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `UserId` varchar(767) NOT NULL,
  `ClaimType` text DEFAULT NULL,
  `ClaimValue` text DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  KEY `IX_AspNetUserClaims_UserId` (`UserId`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 ROW_FORMAT=DYNAMIC;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `aspnetuserlogins`
--

CREATE TABLE IF NOT EXISTS `aspnetuserlogins` (
  `LoginProvider` varchar(127) NOT NULL,
  `ProviderKey` varchar(127) NOT NULL,
  `ProviderDisplayName` text DEFAULT NULL,
  `UserId` varchar(767) NOT NULL,
  PRIMARY KEY (`LoginProvider`,`ProviderKey`) USING BTREE,
  KEY `IX_AspNetUserLogins_UserId` (`UserId`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 ROW_FORMAT=DYNAMIC;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `aspnetuserroles`
--

CREATE TABLE IF NOT EXISTS `aspnetuserroles` (
  `UserId` varchar(127) NOT NULL,
  `RoleId` varchar(127) NOT NULL,
  PRIMARY KEY (`UserId`,`RoleId`) USING BTREE,
  KEY `IX_AspNetUserRoles_RoleId` (`RoleId`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 ROW_FORMAT=DYNAMIC;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `aspnetusers`
--

CREATE TABLE IF NOT EXISTS `aspnetusers` (
  `Id` varchar(767) NOT NULL,
  `UserName` varchar(256) DEFAULT NULL,
  `NormalizedUserName` varchar(256) DEFAULT NULL,
  `Email` varchar(256) DEFAULT NULL,
  `NormalizedEmail` varchar(256) DEFAULT NULL,
  `EmailConfirmed` tinyint(1) NOT NULL,
  `PasswordHash` text DEFAULT NULL,
  `SecurityStamp` text DEFAULT NULL,
  `ConcurrencyStamp` text DEFAULT NULL,
  `PhoneNumber` text DEFAULT NULL,
  `PhoneNumberConfirmed` tinyint(1) NOT NULL,
  `TwoFactorEnabled` tinyint(1) NOT NULL,
  `LockoutEnd` timestamp NULL DEFAULT NULL,
  `LockoutEnabled` tinyint(1) NOT NULL,
  `AccessFailedCount` int(11) NOT NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  UNIQUE KEY `UserNameIndex` (`NormalizedUserName`) USING BTREE,
  KEY `EmailIndex` (`NormalizedEmail`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 ROW_FORMAT=DYNAMIC;

--
-- Volcado de datos para la tabla `aspnetusers`
--

INSERT INTO `aspnetusers` (`Id`, `UserName`, `NormalizedUserName`, `Email`, `NormalizedEmail`, `EmailConfirmed`, `PasswordHash`, `SecurityStamp`, `ConcurrencyStamp`, `PhoneNumber`, `PhoneNumberConfirmed`, `TwoFactorEnabled`, `LockoutEnd`, `LockoutEnabled`, `AccessFailedCount`) VALUES
('0332d052-79c7-4091-8a21-506b1442a274', 'jdcespedes085@misena.edu.co', 'JDCESPEDES085@MISENA.EDU.CO', 'jdcespedes085@misena.edu.co', 'JDCESPEDES085@MISENA.EDU.CO', 0, 'AQAAAAEAACcQAAAAEM6V5XdDxXVODVchLRXA8kzIx/iFBRKLBtgFZdd9vIKJNw6f6mpSXcY5TeBuA23N9g==', '6MEHYZ7PACU5JSFRE4DSSMUGQL36RKCI', 'bdc8adec-52c3-413c-b6de-627d18665d16', '3207777777', 0, 0, NULL, 1, 0);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `aspnetusertokens`
--

CREATE TABLE IF NOT EXISTS `aspnetusertokens` (
  `UserId` varchar(127) NOT NULL,
  `LoginProvider` varchar(127) NOT NULL,
  `Name` varchar(127) NOT NULL,
  `Value` text DEFAULT NULL,
  PRIMARY KEY (`UserId`,`LoginProvider`,`Name`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 ROW_FORMAT=DYNAMIC;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `barrios`
--

CREATE TABLE IF NOT EXISTS `barrios` (
  `Id_Barrio` int(11) NOT NULL AUTO_INCREMENT,
  `Nombre_Barrio` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`Id_Barrio`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 ROW_FORMAT=DYNAMIC;

--
-- Volcado de datos para la tabla `barrios`
--

INSERT INTO `barrios` (`Id_Barrio`, `Nombre_Barrio`) VALUES
(1, 'Centro'),
(2, 'San Andresito');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `colores`
--

CREATE TABLE IF NOT EXISTS `colores` (
  `Id_Color` int(11) NOT NULL AUTO_INCREMENT,
  `Color` varchar(15) DEFAULT NULL,
  PRIMARY KEY (`Id_Color`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 ROW_FORMAT=DYNAMIC;

--
-- Volcado de datos para la tabla `colores`
--

INSERT INTO `colores` (`Id_Color`, `Color`) VALUES
(1, 'Negro'),
(2, 'Cafe'),
(3, 'Miel'),
(4, 'Rosado'),
(5, 'Azul'),
(6, 'Vino Tinto'),
(7, 'Rojo'),
(8, 'Blanco'),
(9, 'Verde'),
(10, 'gris');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `cotizacion`
--

CREATE TABLE IF NOT EXISTS `cotizacion` (
  `Id_Cotizacion` int(11) NOT NULL AUTO_INCREMENT,
  `Id_Perfil` int(11) NOT NULL,
  `Id_Producto` int(11) NOT NULL,
  `Cantidad` int(11) DEFAULT NULL,
  `Valor_Total` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id_Cotizacion`) USING BTREE,
  KEY `Id_Usuarios` (`Id_Perfil`) USING BTREE,
  KEY `Id_Producto` (`Id_Producto`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 ROW_FORMAT=DYNAMIC;

--
-- Volcado de datos para la tabla `cotizacion`
--

INSERT INTO `cotizacion` (`Id_Cotizacion`, `Id_Perfil`, `Id_Producto`, `Cantidad`, `Valor_Total`) VALUES
(1, 11, 5, 72, 504000),
(2, 11, 1, 72, 648000),
(3, 13, 21, 215, 315000),
(4, 28, 1, 6, 54000),
(5, 28, 5, 6, 42000),
(6, 25, 11, 6, 45000),
(7, 22, 6, 10, 50000),
(8, 13, 18, 195, 292500),
(9, 13, 17, 103, 206000),
(10, 13, 2, 11, 110000);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `entrega_pedido`
--

CREATE TABLE IF NOT EXISTS `entrega_pedido` (
  `Id_Entrega_Pedido` int(11) NOT NULL AUTO_INCREMENT,
  `Id_Pedido` int(11) NOT NULL,
  `Id_Produccion` int(11) NOT NULL,
  `Fecha_Entrega` date DEFAULT NULL,
  PRIMARY KEY (`Id_Entrega_Pedido`) USING BTREE,
  KEY `Id_Produccion` (`Id_Produccion`) USING BTREE,
  KEY `Id_Pedido` (`Id_Pedido`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 ROW_FORMAT=DYNAMIC;

--
-- Volcado de datos para la tabla `entrega_pedido`
--

INSERT INTO `entrega_pedido` (`Id_Entrega_Pedido`, `Id_Pedido`, `Id_Produccion`, `Fecha_Entrega`) VALUES
(1, 1, 1, '2020-11-10'),
(2, 2, 2, '2020-11-10'),
(3, 3, 3, '2020-11-09'),
(4, 4, 4, '2020-11-09'),
(5, 5, 5, '2020-11-09'),
(6, 6, 6, '2020-11-11'),
(7, 7, 7, '2020-11-11'),
(8, 8, 8, '2020-11-13'),
(9, 9, 9, '2020-11-13'),
(10, 10, 10, '2020-11-13');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `entrega_pedido_relacion_tipo_producto`
--

CREATE TABLE IF NOT EXISTS `entrega_pedido_relacion_tipo_producto` (
  `Id_entrega_pedido_relacion_tipo_producto` int(11) NOT NULL AUTO_INCREMENT,
  `Id_Entrega_Pedido` int(11) NOT NULL,
  `Id_Tipo_Producto` int(11) NOT NULL,
  PRIMARY KEY (`Id_entrega_pedido_relacion_tipo_producto`) USING BTREE,
  KEY `Id_Entrega_Pedido` (`Id_Entrega_Pedido`) USING BTREE,
  KEY `Id_Tipo_Producto` (`Id_Tipo_Producto`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 ROW_FORMAT=DYNAMIC;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `estado_produccion`
--

CREATE TABLE IF NOT EXISTS `estado_produccion` (
  `Id_Estado` int(11) NOT NULL AUTO_INCREMENT,
  `Estado_Produccion` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`Id_Estado`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 ROW_FORMAT=DYNAMIC;

--
-- Volcado de datos para la tabla `estado_produccion`
--

INSERT INTO `estado_produccion` (`Id_Estado`, `Estado_Produccion`) VALUES
(1, 'Producto Defectuoso'),
(2, 'Producto Terminado');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `insumos`
--

CREATE TABLE IF NOT EXISTS `insumos` (
  `Id_Insumo` int(11) NOT NULL AUTO_INCREMENT,
  `Nombre_Insumo` varchar(30) DEFAULT NULL,
  `Id_Color` int(11) DEFAULT NULL,
  `Id_Proveedor` int(11) NOT NULL,
  PRIMARY KEY (`Id_Insumo`) USING BTREE,
  KEY `Id_Proveedor` (`Id_Proveedor`) USING BTREE,
  KEY `Id_Color` (`Id_Color`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=107 DEFAULT CHARSET=utf8mb4 ROW_FORMAT=DYNAMIC;

--
-- Volcado de datos para la tabla `insumos`
--

INSERT INTO `insumos` (`Id_Insumo`, `Nombre_Insumo`, `Id_Color`, `Id_Proveedor`) VALUES
(1, 'Sellafix', NULL, 9),
(2, 'Marroquinera', 1, 9),
(3, 'Marroquinera', 2, 9),
(4, 'Marroquinera', 3, 9),
(5, 'Marroquinera', 4, 9),
(6, 'Marroquinera', 5, 9),
(7, 'Marroquinera', 7, 9),
(8, 'Marroquinera', 8, 9),
(9, 'Atenas', 1, 10),
(10, 'Ivanna', 2, 11),
(11, 'Cuchilla', NULL, 2),
(12, 'Hilaza 500gms', 8, 1),
(13, 'Hilaza 500gms', 1, 1),
(14, 'Hilo premier40gms B-46Bondeado', 2, 1),
(15, 'Hilo premier40grm B-46Bondeado', 3, 1),
(16, 'Hilo premier40grm B-46Bondeado', 4, 1),
(17, 'Hilo premier40grm B-46Bondeado', 5, 1),
(18, 'Hilo premier40grm B-46Bondeado', 7, 1),
(19, 'Hilo premier40grm B-46Bondeado', 8, 1),
(20, 'Hilo premier40grm B-46Bondeado', 9, 1),
(21, 'Hilo premier40grm B-46Bondeado', 10, 1),
(22, 'Cataluña', 5, 3),
(23, 'Cataluña', 7, 3),
(24, 'Napoles', 5, 5),
(25, 'Napoles', 3, 5),
(26, 'Napoles', 2, 5),
(27, 'Napoles', 7, 5),
(28, 'Napoles', 4, 5),
(29, 'Salpa Italiana', NULL, 7),
(30, 'Napapiel', 1, 5),
(31, 'Napapiel', 2, 5),
(32, 'Napapiel', 3, 5),
(33, 'Napapiel', 8, 5),
(34, 'Napapiel', 5, 5),
(35, 'Palo Rosa', 4, 3),
(36, 'Odena', 9, 5),
(37, 'Carnaza', NULL, 10),
(38, 'One way', NULL, 12),
(39, 'Tornillos', NULL, 13),
(40, 'Hebilla Gucci 2.5', NULL, 6),
(41, 'Hebilla Ferragamo 2.5', NULL, 6),
(42, 'Hebilla L.V 2.5', NULL, 6),
(43, 'Hebilla L.V 3.5', NULL, 13),
(44, 'Hebilla L.V 4,0', NULL, 13),
(45, 'Hebilla Gucci 3.5', NULL, 6),
(46, 'Hebilla Gucci 4.0', NULL, 6),
(47, 'Hebilla Gucci Grande', NULL, 6),
(48, 'Hebilla Importada 4.0', NULL, 8),
(49, 'Hebilla Importada 3.5', NULL, 4),
(50, 'Hebilla Reversible', NULL, 8),
(51, 'Hebilla Dama 4.0', NULL, 4),
(52, 'Neolite', 1, 5),
(53, 'Hilo premier40gms B-46Bondeado', 1, 1),
(54, 'Omega', 2, 3),
(55, 'Jonas shell', 3, 3);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `inventario`
--

CREATE TABLE IF NOT EXISTS `inventario` (
  `Id_Inventario` int(11) NOT NULL AUTO_INCREMENT,
  `Id_Insumo` int(11) NOT NULL,
  `Fecha_Ingreso` date DEFAULT NULL,
  `Cantidad` varchar(10) DEFAULT NULL,
  `Valor_Unidad/Valor_Metro` int(11) NOT NULL,
  `Valor_Total` int(11) NOT NULL,
  `Id_Perfil` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id_Inventario`) USING BTREE,
  KEY `Id_Insumo` (`Id_Insumo`) USING BTREE,
  KEY `inventario_ibfk_2` (`Id_Perfil`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=27 DEFAULT CHARSET=utf8mb4 ROW_FORMAT=DYNAMIC;

--
-- Volcado de datos para la tabla `inventario`
--

INSERT INTO `inventario` (`Id_Inventario`, `Id_Insumo`, `Fecha_Ingreso`, `Cantidad`, `Valor_Unidad/Valor_Metro`, `Valor_Total`, `Id_Perfil`) VALUES
(1, 11, '2020-10-29', '10', 1250, 12500, NULL),
(2, 13, '2020-10-31', '1', 8800, 8800, NULL),
(3, 14, '2020-10-31', '1', 4000, 4000, NULL),
(4, 22, '2020-10-31', '0.50 cm', 14500, 7250, NULL),
(5, 23, '2020-10-31', '0.50cm', 14500, 7250, NULL),
(6, 54, '2020-10-31', '0.50cm', 14500, 7250, NULL),
(7, 55, '0202-10-31', '0.50cm', 13500, 6750, NULL),
(8, 47, '2020-11-02', '12', 6500, 78000, NULL),
(9, 24, '2020-11-02', '1.10', 12000, 13200, NULL),
(10, 25, '2020-11-02', '1.10', 7000, 7700, NULL),
(11, 26, '2020-11-02', '1.10', 7000, 7700, NULL),
(12, 27, '2020-11-02', '0.50cm', 14000, 7000, NULL),
(13, 28, '2020-11-02', '0.50cm', 14000, 7000, NULL),
(14, 53, '2020-11-10', '1', 4000, 4000, NULL),
(15, 14, '2020-11-10', '1', 4000, 4000, NULL),
(16, 22, '2020-11-11', '0.50 cm', 14500, 7250, NULL),
(17, 23, '2020-11-11', '0.50cm', 14500, 7250, NULL),
(18, 22, '2020-11-14', '0.50 cm', 14500, 7250, NULL),
(19, 23, '2020-11-14', '0.50cm', 14500, 7250, NULL),
(20, 29, '2020-11-14', '3.4cm', 13500, 46575, NULL),
(21, 29, '2020-11-17', '4.6cm', 13500, 62100, NULL),
(22, 10, '2020-11-17', '1.15cm', 6600, 7590, NULL),
(23, 29, '2020-11-20', '2.3cm', 13500, 31050, NULL),
(24, 1, '2020-11-20', '1', 9000, 9000, NULL),
(25, 2, '2020-11-20', '1', 15800, 15800, NULL),
(26, 9, '2020-11-20', '2.30', 18000, 41400, NULL);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `material`
--

CREATE TABLE IF NOT EXISTS `material` (
  `Id_Material` int(11) NOT NULL AUTO_INCREMENT,
  `Nombre_Material` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`Id_Material`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 ROW_FORMAT=DYNAMIC;

--
-- Volcado de datos para la tabla `material`
--

INSERT INTO `material` (`Id_Material`, `Nombre_Material`) VALUES
(1, 'Cuero'),
(2, 'sintético'),
(3, 'Neolite');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `pedido`
--

CREATE TABLE IF NOT EXISTS `pedido` (
  `Id_Pedido` int(11) NOT NULL AUTO_INCREMENT,
  `Id_Cotizacion` int(11) NOT NULL,
  `Fecha_Pedido` date DEFAULT NULL,
  `Lugar_Entrega` varchar(30) DEFAULT NULL,
  `Id_Barrio` int(11) NOT NULL,
  PRIMARY KEY (`Id_Pedido`) USING BTREE,
  KEY `Id_Cotizacion` (`Id_Cotizacion`) USING BTREE,
  KEY `Id_Barrio` (`Id_Barrio`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 ROW_FORMAT=DYNAMIC;

--
-- Volcado de datos para la tabla `pedido`
--

INSERT INTO `pedido` (`Id_Pedido`, `Id_Cotizacion`, `Fecha_Pedido`, `Lugar_Entrega`, `Id_Barrio`) VALUES
(1, 1, '2020-11-06', 'Cra. 7 #11-76', 1),
(2, 2, '2020-11-06', 'Cra. 7 #11-76', 1),
(3, 3, '2020-11-06', 'carrera 10 #10-53', 1),
(4, 4, '2020-11-07', 'Cll 13#21-61', 2),
(5, 5, '2020-11-07', 'Cll 13#21-61', 2),
(6, 6, '2020-11-09', 'Cra. 21 #9-31', 2),
(7, 7, '2020-11-09', 'Cra. 19a #8a-63', 2),
(8, 8, '2020-11-11', 'carrera 10 #10-53', 1),
(9, 9, '2020-11-11', 'carrera 10 #10-53', 1),
(10, 10, '2020-11-11', 'carrera 10 #10-53', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `pedido_relacion_produccion`
--

CREATE TABLE IF NOT EXISTS `pedido_relacion_produccion` (
  `Id_Pedido_Relacion_Produccion` int(11) NOT NULL AUTO_INCREMENT,
  `Id_Pedido` int(11) NOT NULL,
  `Id_Produccion` int(11) NOT NULL,
  PRIMARY KEY (`Id_Pedido_Relacion_Produccion`) USING BTREE,
  KEY `Id_Pedido` (`Id_Pedido`) USING BTREE,
  KEY `Id_Produccion` (`Id_Produccion`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 ROW_FORMAT=DYNAMIC;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `perfil`
--

CREATE TABLE IF NOT EXISTS `perfil` (
  `Id_Usuarios` int(11) NOT NULL AUTO_INCREMENT,
  `Primer_Nombre` varchar(15) NOT NULL,
  `Primer_Apellido` varchar(15) NOT NULL,
  `Direccion` varchar(25) DEFAULT NULL,
  `aspnetusers_Id` varchar(767) DEFAULT NULL,
  PRIMARY KEY (`Id_Usuarios`) USING BTREE,
  KEY `perfil_ibfk_1` (`aspnetusers_Id`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=33 DEFAULT CHARSET=utf8mb4 ROW_FORMAT=DYNAMIC;

--
-- Volcado de datos para la tabla `perfil`
--

INSERT INTO `perfil` (`Id_Usuarios`, `Primer_Nombre`, `Primer_Apellido`, `Direccion`, `aspnetusers_Id`) VALUES
(1, 'Alexander', 'Triviño', 'Cll 25Sur No.24-23', NULL),
(2, 'Jhon', 'Triviño', 'Cll25Sur No.24-23', NULL),
(3, 'Lucelly', 'Gaviria', 'Cll25Sur No.24-23', NULL),
(4, 'Karen', 'Triviño', 'Cll25Sur No.24-23', NULL),
(5, 'Adrián', 'Ramirez', 'Cra.10#87', NULL),
(6, 'Alvaro', 'Gonzalez', 'CALLE 9 BIS 19 A 60', NULL),
(7, 'Andrés', 'Preciado', 'Cra. 10 #12-64', NULL),
(8, 'Camilo', 'España', 'Calle 9 Bis # 19A-65', NULL),
(9, 'Bladimir', 'España', 'Calle 9 Bis # 20A-64', NULL),
(10, 'Daniel', 'Rodriguez', 'Calle 9 Bis # 19A-60', NULL),
(11, 'Mirian', 'Sanchez', 'Cra. 7 #11-76', NULL),
(12, 'Fausto', 'More', 'Cl. 91 ##20-90', NULL),
(13, 'Fabian', 'Ramirez', 'carrera 10 #10-53', NULL),
(14, 'Fernando', 'Cordoba', 'Cl. 91 ##20-90', NULL),
(15, 'Javier', 'Lopez', 'Av.Kra10-Cll20', NULL),
(16, 'José', 'Cotes', 'Cra. 10 #87', NULL),
(17, 'José', 'Florez', 'Cl. 91 ##20-90', NULL),
(18, 'Karen', 'Torres', 'Av.Kra10-Cll14', NULL),
(19, 'Leonardo', 'Perez', 'Cra. 20a ## 8 - 65', NULL),
(20, 'Leonardo', 'Vanegas', 'Cra. 21 #127', NULL),
(21, 'Mary', 'Jimenez', 'Cl. 9 Bis #1969', NULL),
(22, 'Miguel', 'Plaza', 'Cra. 19a #8a-63', NULL),
(23, 'Ismael', 'Peña', 'Cl. 9 Bis ##2023', NULL),
(24, 'Samir', 'Velasquez', 'Cra. 21 #12731', NULL),
(25, 'Sandra', 'Rojas', 'Cra. 21 #9-31', NULL),
(26, 'Sebastian', 'Ulloa', 'Cra. 13 #61-65', NULL),
(27, 'Toto', 'Robles', 'Av.Caracas Calles 11 y 13', NULL),
(28, 'Victor', 'Vanegas', 'Cll 13#21-61', NULL),
(29, 'Viviana', 'Tovar', 'Cra.100#20-59', NULL),
(30, 'Will', 'Perdomo', 'av.Jimenez', NULL),
(31, 'William', 'Gutierrez', 'Calle 13', NULL),
(32, 'Wilmar', 'Zapata', 'Cra. 10 #87', NULL);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `produccion`
--

CREATE TABLE IF NOT EXISTS `produccion` (
  `Id_Produccion` int(11) NOT NULL AUTO_INCREMENT,
  `Id_Producto` int(11) NOT NULL,
  `Fecha_Produccion` date DEFAULT NULL,
  `Detalle_Producto` varchar(50) DEFAULT NULL,
  `Id_Estado` int(11) NOT NULL,
  `Cantidad` int(11) NOT NULL,
  `Id_Perfil` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id_Produccion`) USING BTREE,
  KEY `Id_Producto` (`Id_Producto`) USING BTREE,
  KEY `Id_Estado` (`Id_Estado`) USING BTREE,
  KEY `produccion_ibfk_3` (`Id_Perfil`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 ROW_FORMAT=DYNAMIC;

--
-- Volcado de datos para la tabla `produccion`
--

INSERT INTO `produccion` (`Id_Produccion`, `Id_Producto`, `Fecha_Produccion`, `Detalle_Producto`, `Id_Estado`, `Cantidad`, `Id_Perfil`) VALUES
(1, 5, '2020-11-09', 'Cinturón para Dama Louis Viutton', 2, 72, NULL),
(2, 1, '2020-11-09', 'Cinturón para Caballero Louis Viutton', 2, 72, NULL),
(3, 21, '2020-11-08', 'Tira para Dama doble faz de 1.5', 2, 215, NULL),
(4, 1, '2020-11-08', 'Cinturón para Caballero Louis Viutton', 2, 6, NULL),
(5, 5, '2020-11-08', 'Cinturón para Dama Louis Viutton', 2, 6, NULL),
(6, 11, '2020-11-10', 'Cinturón para Caballero doble faz', 2, 6, NULL),
(7, 6, '2020-11-10', 'Cinturón para Dama Gucci doble faz', 2, 10, NULL),
(8, 18, '2020-11-12', 'Tira de 2.5 doble faz', 2, 195, NULL),
(9, 17, '2020-11-12', 'Tira de 3.0 doble faz', 2, 103, NULL),
(10, 2, '2020-11-12', 'Cinturón para dama Gucci 4.0, hebilla grande', 2, 11, NULL);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `producto`
--

CREATE TABLE IF NOT EXISTS `producto` (
  `Id_Producto` int(11) NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(30) DEFAULT NULL,
  `Id_Material` int(11) NOT NULL,
  `Id_Tipo_Producto` int(11) NOT NULL,
  `Precio_Unidad` int(11) NOT NULL,
  PRIMARY KEY (`Id_Producto`) USING BTREE,
  KEY `Id_Tipo_Producto` (`Id_Tipo_Producto`) USING BTREE,
  KEY `Id_Material` (`Id_Material`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=31 DEFAULT CHARSET=utf8mb4 ROW_FORMAT=DYNAMIC;

--
-- Volcado de datos para la tabla `producto`
--

INSERT INTO `producto` (`Id_Producto`, `Nombre`, `Id_Material`, `Id_Tipo_Producto`, `Precio_Unidad`) VALUES
(1, 'Citurón de L.V 4.0cm', 2, 2, 9000),
(2, 'Citurón de GG 4.0cm', 2, 1, 10000),
(3, 'Citurón de GG 3.5cm', 2, 1, 8000),
(4, 'Citurón de GG 3.5cm', 2, 1, 7000),
(5, 'Cinturón L.V de 3.0cm', 2, 1, 7000),
(6, 'Citurón de 2.5cm', 2, 1, 5000),
(7, 'Citurón de 2.0cm', 2, 1, 4500),
(8, 'Citurón de 1.8cm', 2, 1, 4000),
(9, 'Citurón de 4.0cm', 2, 2, 9000),
(10, 'Citurón de 3.5cm', 2, 2, 8000),
(11, 'Cinturón reversible', 2, 2, 7500),
(12, 'Cinturón de carnaza marcado', 2, 2, 6000),
(13, 'Cinturón liso', 2, 2, 6000),
(14, 'Cinturón de carnaza tejido', 2, 1, 6000),
(15, 'Tira de 4.0cm', 2, 1, 2300),
(16, 'Tira de 3.5cm', 2, 1, 2000),
(17, 'Tira de 3.0cm', 2, 1, 2000),
(18, 'Tira de 2.5cm', 2, 1, 1500),
(19, 'Tira de 2.0cm', 2, 1, 1500),
(20, 'Tira de 1.8cm', 2, 1, 1500),
(21, 'Tira de 1.5cm', 2, 1, 1500),
(22, 'Tira de 4.0cm', 3, 1, 1600),
(23, 'Tira de 3.5cm', 3, 1, 1500),
(24, 'Tira de 3.0cm', 3, 1, 1500),
(25, 'Tira de 2.5cm', 3, 1, 1300),
(26, 'Tira de 2.0cm', 3, 1, 1300),
(27, 'Tira de 1.8cm', 3, 1, 1300),
(28, 'Tira de 1.5cm', 3, 1, 1300),
(29, 'Correa doble hebilla', 2, 1, 8000),
(30, 'Correa de cuero', 1, 2, 15000);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `proveedor`
--

CREATE TABLE IF NOT EXISTS `proveedor` (
  `Id_Proveedor` int(11) NOT NULL AUTO_INCREMENT,
  `Distribuidora` varchar(40) DEFAULT NULL,
  `Direccion` varchar(25) DEFAULT NULL,
  `Telefono` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`Id_Proveedor`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8mb4 ROW_FORMAT=DYNAMIC;

--
-- Volcado de datos para la tabla `proveedor`
--

INSERT INTO `proveedor` (`Id_Proveedor`, `Distribuidora`, `Direccion`, `Telefono`) VALUES
(1, 'HILOS & SUMINISTROS LTDA', 'CRA 24D # 19-32 ZAFIRO', '2985750'),
(2, 'COMERCIALIZADORA MAF S.A.S.', 'CALLE 11 # 12A-08', '3361296'),
(3, 'PELETERIA LA 10', 'CALLE 17 SUR # 24D-68', '3660130'),
(4, 'HERRAJES HL (DIMAEX)', 'CALLE 18 SUR # 24D-59', '3004016057'),
(5, 'Napoles Peletería S.A.S', 'CALLE 19 SUR # 24C-30', '7583266'),
(6, 'HERRAJES ELYON S.A.S', 'CALLE 18 SUR #24D-27', '4326237'),
(7, 'ORIÓN Peletería', 'CALLE 18 SUR # 24C-11', '3148884384'),
(8, 'INVERSIONES IGAM', 'CALLE 19 SUR # 24A-48', '4696890'),
(9, 'MONTAÑO', 'CRA 24D # 18-90 SUR', '6540982'),
(10, 'MEGAPIELES', 'CALLE 19 SUR #24A-25', '3726778'),
(11, 'COMERCIAL NOVAPEL LTDA', 'CRA 24F # 18-42 SUR', '4098032'),
(12, 'CONTINENTAL DE PEGANTES Y SOLUCIONES S.A', 'CALLE 20 SUR #23B-34', '4098784'),
(13, 'INSUMOS Y HERRAJES', 'CRA 26G #20-23 SUR', '432098');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `recibo_pago`
--

CREATE TABLE IF NOT EXISTS `recibo_pago` (
  `Id_Recibo_Pago` int(11) NOT NULL AUTO_INCREMENT,
  `Id_Pedido` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id_Recibo_Pago`) USING BTREE,
  KEY `Id_Pedido` (`Id_Pedido`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 ROW_FORMAT=DYNAMIC;

--
-- Volcado de datos para la tabla `recibo_pago`
--

INSERT INTO `recibo_pago` (`Id_Recibo_Pago`, `Id_Pedido`) VALUES
(1, 1),
(2, 2),
(3, 3),
(4, 4),
(5, 5),
(6, 6),
(7, 7),
(8, 8),
(9, 9),
(10, 10);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tipo_producto`
--

CREATE TABLE IF NOT EXISTS `tipo_producto` (
  `Id_Tipo_Producto` int(11) NOT NULL AUTO_INCREMENT,
  `Nombre_producto` varchar(12) DEFAULT NULL,
  PRIMARY KEY (`Id_Tipo_Producto`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 ROW_FORMAT=DYNAMIC;

--
-- Volcado de datos para la tabla `tipo_producto`
--

INSERT INTO `tipo_producto` (`Id_Tipo_Producto`, `Nombre_producto`) VALUES
(1, 'Dama'),
(2, 'Caballero');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `__efmigrationshistory`
--

CREATE TABLE IF NOT EXISTS `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 ROW_FORMAT=DYNAMIC;

--
-- Volcado de datos para la tabla `__efmigrationshistory`
--

INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
('20201125212459_CreateIdentitySchema', '3.1.10');

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `aspnetroleclaims`
--
ALTER TABLE `aspnetroleclaims`
  ADD CONSTRAINT `FK_AspNetRoleClaims_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE;

--
-- Filtros para la tabla `aspnetuserclaims`
--
ALTER TABLE `aspnetuserclaims`
  ADD CONSTRAINT `FK_AspNetUserClaims_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE;

--
-- Filtros para la tabla `aspnetuserlogins`
--
ALTER TABLE `aspnetuserlogins`
  ADD CONSTRAINT `FK_AspNetUserLogins_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE;

--
-- Filtros para la tabla `aspnetuserroles`
--
ALTER TABLE `aspnetuserroles`
  ADD CONSTRAINT `FK_AspNetUserRoles_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_AspNetUserRoles_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE;

--
-- Filtros para la tabla `aspnetusertokens`
--
ALTER TABLE `aspnetusertokens`
  ADD CONSTRAINT `FK_AspNetUserTokens_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE;

--
-- Filtros para la tabla `cotizacion`
--
ALTER TABLE `cotizacion`
  ADD CONSTRAINT `cotizacion_ibfk_1` FOREIGN KEY (`Id_Perfil`) REFERENCES `perfil` (`Id_Usuarios`),
  ADD CONSTRAINT `cotizacion_ibfk_2` FOREIGN KEY (`Id_Producto`) REFERENCES `producto` (`Id_Producto`);

--
-- Filtros para la tabla `entrega_pedido`
--
ALTER TABLE `entrega_pedido`
  ADD CONSTRAINT `entrega_pedido_ibfk_1` FOREIGN KEY (`Id_Produccion`) REFERENCES `produccion` (`Id_Produccion`),
  ADD CONSTRAINT `entrega_pedido_ibfk_2` FOREIGN KEY (`Id_Pedido`) REFERENCES `pedido` (`Id_Pedido`);

--
-- Filtros para la tabla `entrega_pedido_relacion_tipo_producto`
--
ALTER TABLE `entrega_pedido_relacion_tipo_producto`
  ADD CONSTRAINT `entrega_pedido_relacion_tipo_producto_ibfk_1` FOREIGN KEY (`Id_Entrega_Pedido`) REFERENCES `entrega_pedido` (`Id_Entrega_Pedido`),
  ADD CONSTRAINT `entrega_pedido_relacion_tipo_producto_ibfk_2` FOREIGN KEY (`Id_Tipo_Producto`) REFERENCES `tipo_producto` (`Id_Tipo_Producto`);

--
-- Filtros para la tabla `insumos`
--
ALTER TABLE `insumos`
  ADD CONSTRAINT `insumos_ibfk_2` FOREIGN KEY (`Id_Proveedor`) REFERENCES `proveedor` (`Id_Proveedor`),
  ADD CONSTRAINT `insumos_ibfk_3` FOREIGN KEY (`Id_Color`) REFERENCES `colores` (`Id_Color`);

--
-- Filtros para la tabla `inventario`
--
ALTER TABLE `inventario`
  ADD CONSTRAINT `inventario_ibfk_1` FOREIGN KEY (`Id_Insumo`) REFERENCES `insumos` (`Id_Insumo`),
  ADD CONSTRAINT `inventario_ibfk_2` FOREIGN KEY (`Id_Perfil`) REFERENCES `perfil` (`Id_Usuarios`);

--
-- Filtros para la tabla `pedido`
--
ALTER TABLE `pedido`
  ADD CONSTRAINT `pedido_ibfk_2` FOREIGN KEY (`Id_Cotizacion`) REFERENCES `cotizacion` (`Id_Cotizacion`),
  ADD CONSTRAINT `pedido_ibfk_3` FOREIGN KEY (`Id_Barrio`) REFERENCES `barrios` (`Id_Barrio`);

--
-- Filtros para la tabla `pedido_relacion_produccion`
--
ALTER TABLE `pedido_relacion_produccion`
  ADD CONSTRAINT `pedido_relacion_produccion_ibfk_1` FOREIGN KEY (`Id_Pedido`) REFERENCES `pedido` (`Id_Pedido`),
  ADD CONSTRAINT `pedido_relacion_produccion_ibfk_2` FOREIGN KEY (`Id_Produccion`) REFERENCES `produccion` (`Id_Produccion`);

--
-- Filtros para la tabla `perfil`
--
ALTER TABLE `perfil`
  ADD CONSTRAINT `perfil_ibfk_1` FOREIGN KEY (`aspnetusers_Id`) REFERENCES `aspnetusers` (`Id`);

--
-- Filtros para la tabla `produccion`
--
ALTER TABLE `produccion`
  ADD CONSTRAINT `produccion_ibfk_1` FOREIGN KEY (`Id_Producto`) REFERENCES `producto` (`Id_Producto`),
  ADD CONSTRAINT `produccion_ibfk_2` FOREIGN KEY (`Id_Estado`) REFERENCES `estado_produccion` (`Id_Estado`),
  ADD CONSTRAINT `produccion_ibfk_3` FOREIGN KEY (`Id_Perfil`) REFERENCES `perfil` (`Id_Usuarios`);

--
-- Filtros para la tabla `producto`
--
ALTER TABLE `producto`
  ADD CONSTRAINT `producto_ibfk_1` FOREIGN KEY (`Id_Tipo_Producto`) REFERENCES `tipo_producto` (`Id_Tipo_Producto`),
  ADD CONSTRAINT `producto_ibfk_2` FOREIGN KEY (`Id_Material`) REFERENCES `material` (`Id_Material`);

--
-- Filtros para la tabla `recibo_pago`
--
ALTER TABLE `recibo_pago`
  ADD CONSTRAINT `recibo_pago_ibfk_1` FOREIGN KEY (`Id_Pedido`) REFERENCES `pedido` (`Id_Pedido`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
