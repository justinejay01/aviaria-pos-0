-- phpMyAdmin SQL Dump
-- version 5.0.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jul 07, 2021 at 03:04 PM
-- Server version: 10.4.17-MariaDB
-- PHP Version: 8.0.0

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `aviaria`
--

-- --------------------------------------------------------

--
-- Table structure for table `account`
--

CREATE TABLE `account` (
  `id` int(3) NOT NULL,
  `username` varchar(50) NOT NULL,
  `password` varchar(255) NOT NULL,
  `privilege` tinyint(1) NOT NULL,
  `recovery` varchar(255) NOT NULL,
  `firstname` varchar(255) DEFAULT NULL,
  `lastname` varchar(255) DEFAULT NULL,
  `address` varchar(255) DEFAULT NULL,
  `contactnumber` double DEFAULT NULL,
  `emailaddress` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `account`
--

INSERT INTO `account` (`id`, `username`, `password`, `privilege`, `recovery`, `firstname`, `lastname`, `address`, `contactnumber`, `emailaddress`) VALUES
(0, '1234', '03AACA67A42A16AF3AE1A5CA76A1EAE1AA5AE2A55AF0A67A95A36A23AC8AB3A88AB4A45A9EA13AF9A78AD7AC8A46AF4A', 0, '', NULL, NULL, NULL, NULL, NULL),
(1, 'justinej', '30A58A00AB7A10A62AB4A9BA35A02A08A32A7AA02AECA37A81A99AB4ACFA35AE6A0EAEBA97A16A11ABEAF4A92A83A94A', 1, '', 'Justine Jay', 'Olivar', 'Pagsanjan', 9516024126, 'j@j.com'),
(1, 'hey', '87AA0AACAAEAC0A0FAA3A4AA31A66AF0AB6A2BA73A52A86A8CA16A75A2BAF7A96AA6AAFA3BAAFA03A62AC6A23A61AEDA', 1, '', 'Jjay', 'olivar', 'laguna', 123456789, 'j2@d.com'),
(1, '6', '79A02A69A9BAE4A2CA8AA8EA46AFBABBA45A01A72A65A17AE8A6BA22AC5A6AA18A9FA76A25AA6ADAA49A08A1BA24A51A', 1, '', '1', '2', '3', 4, '5');

-- --------------------------------------------------------

--
-- Table structure for table `inventory`
--

CREATE TABLE `inventory` (
  `prodID` int(5) NOT NULL,
  `prodName` varchar(255) NOT NULL,
  `prodPrice` double NOT NULL,
  `prodManufactureName` varchar(255) NOT NULL,
  `prodStocks` int(5) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `inventory`
--

INSERT INTO `inventory` (`prodID`, `prodName`, `prodPrice`, `prodManufactureName`, `prodStocks`) VALUES
(1, '123', 123, '123', 0),
(2, 'qwe', 123, 'asd', 0);

-- --------------------------------------------------------

--
-- Table structure for table `stocks`
--

CREATE TABLE `stocks` (
  `stockID` int(5) NOT NULL,
  `stockName` varchar(255) NOT NULL,
  `stockPrice` double NOT NULL,
  `stockQty` int(5) NOT NULL,
  `stockManufactureDate` date DEFAULT NULL,
  `stockExpirationDate` date DEFAULT NULL,
  `stockInBy` varchar(255) NOT NULL,
  `stockVendor` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `stocks`
--

INSERT INTO `stocks` (`stockID`, `stockName`, `stockPrice`, `stockQty`, `stockManufactureDate`, `stockExpirationDate`, `stockInBy`, `stockVendor`) VALUES
(1, '123', 123, 1, NULL, NULL, '1', '123'),
(2, 'qwe', 123, 1, NULL, '2021-07-07', '12345s', '123'),
(1, '123', 123, 2, NULL, NULL, '12345s', '123');

-- --------------------------------------------------------

--
-- Table structure for table `vendor`
--

CREATE TABLE `vendor` (
  `vendorID` int(5) NOT NULL,
  `vendorName` varchar(255) NOT NULL,
  `vendorAddress` varchar(255) NOT NULL,
  `vendorContactPerson` varchar(255) NOT NULL,
  `vendorContactNumber` varchar(20) NOT NULL,
  `vendorEmail` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `vendor`
--

INSERT INTO `vendor` (`vendorID`, `vendorName`, `vendorAddress`, `vendorContactPerson`, `vendorContactNumber`, `vendorEmail`) VALUES
(0, '123', '123', '123', '123', '123');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
