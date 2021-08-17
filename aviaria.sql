-- phpMyAdmin SQL Dump
-- version 5.0.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Aug 17, 2021 at 04:21 PM
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
  `privilege` varchar(10) NOT NULL,
  `recovery` varchar(255) NOT NULL,
  `firstname` varchar(255) NOT NULL,
  `lastname` varchar(255) NOT NULL,
  `address` varchar(255) NOT NULL,
  `contactnumber` double NOT NULL,
  `emailaddress` varchar(255) NOT NULL,
  `q1` varchar(255) DEFAULT NULL,
  `a1` varchar(255) DEFAULT NULL,
  `q2` varchar(255) DEFAULT NULL,
  `a2` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `account`
--

INSERT INTO `account` (`id`, `username`, `password`, `privilege`, `recovery`, `firstname`, `lastname`, `address`, `contactnumber`, `emailaddress`, `q1`, `a1`, `q2`, `a2`) VALUES
(15, 'admin', 'EF797C8118F02DFB649607DD5D3F8C7623048C9C063D532CC95C5ED7A898A64F', '0', '', '', '', '', 0, '', 'ADFB666598FAECE78F6293EB1595A2FCE64BE0C58940F5AAF865A9FB15F346E2', '404CDD7BC109C432F8CC2443B45BCFE95980F5107215C645236E577929AC3E52', 'DCD1D5223F73B3A965C07E3FF5DBEE3EEDCFEDB806686A05B9B3868A2C3D6D50', '2C42AD73A99866DC98B883881A43E4E0609DCA5DEC26984804E103497481BEBC'),
(16, 'kian', 'E15E93D5CFF0534F98E683142A51B6189ADB07870AF61B085ED383603DDB8AE0', '1', '', 'Kian', 'Palo', 'pagsanjan', 912345678, 'kian@palo.com', NULL, NULL, NULL, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `inventory`
--

CREATE TABLE `inventory` (
  `stockID` int(5) NOT NULL,
  `stockName` varchar(255) NOT NULL,
  `stockPrice` double NOT NULL,
  `stockQty` int(5) NOT NULL,
  `stockManufactureDate` date DEFAULT NULL,
  `stockExpirationDate` date DEFAULT NULL,
  `stockInBy` varchar(255) NOT NULL,
  `stockInDate` date NOT NULL,
  `stockSupplier` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `inventory`
--

INSERT INTO `inventory` (`stockID`, `stockName`, `stockPrice`, `stockQty`, `stockManufactureDate`, `stockExpirationDate`, `stockInBy`, `stockInDate`, `stockSupplier`) VALUES
(1, 'Bird Catcher', 270, 15, NULL, NULL, '123', '2021-07-15', '23'),
(3, 'Justine', 123, 250, '2021-07-15', '2021-07-15', '123', '2021-07-15', '23'),
(2, 'Cage Lock Plastic', 25, 250, NULL, NULL, '123', '2021-07-15', '23');

-- --------------------------------------------------------

--
-- Table structure for table `products`
--

CREATE TABLE `products` (
  `prodID` int(5) NOT NULL,
  `prodName` varchar(255) NOT NULL,
  `prodPrice` double NOT NULL,
  `prodManufactureName` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `products`
--

INSERT INTO `products` (`prodID`, `prodName`, `prodPrice`, `prodManufactureName`) VALUES
(1, 'Bird Catcher', 270, 'N/A'),
(2, 'Cage Lock Plastic', 25, 'N/A'),
(3, 'Cage Lock Metal', 30, 'N/A'),
(4, 'Ceramic', 35, 'N/A'),
(5, 'Carrier', 190, 'N/A'),
(6, 'Carrier', 250, 'N/A'),
(7, 'Cage 15x24', 880, 'N/A'),
(8, 'Cage 17x30', 980, 'N/A'),
(9, 'Dextrose Powder', 50, 'Arvet-Chem Laboratory Inc.'),
(10, 'Egg Food', 180, 'N/A'),
(11, 'Essential 1kl', 370, 'Essential Vet Laboratory'),
(12, 'Essential Sulit Pack', 50, 'Essential Vet Laboratory'),
(13, 'Habal', 290, 'Essential Vet Laboratory'),
(14, 'Happy Chick', 170, 'N/A'),
(15, 'Leash With Ring', 120, 'N/A');

-- --------------------------------------------------------

--
-- Table structure for table `sales`
--

CREATE TABLE `sales` (
  `salesID` double NOT NULL,
  `salesName` varchar(255) DEFAULT NULL,
  `salesPrice` double DEFAULT NULL,
  `salesQty` int(5) DEFAULT NULL,
  `salesTotalAmount` double DEFAULT NULL,
  `salesCashier` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `sales`
--

INSERT INTO `sales` (`salesID`, `salesName`, `salesPrice`, `salesQty`, `salesTotalAmount`, `salesCashier`) VALUES
(1000000, NULL, NULL, NULL, NULL, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `supplier`
--

CREATE TABLE `supplier` (
  `supplierID` int(5) NOT NULL,
  `supplierName` varchar(255) NOT NULL,
  `supplierAddress` varchar(255) NOT NULL,
  `supplierContactPerson` varchar(255) NOT NULL,
  `supplierContactNumber` varchar(20) NOT NULL,
  `supplierEmail` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `supplier`
--

INSERT INTO `supplier` (`supplierID`, `supplierName`, `supplierAddress`, `supplierContactPerson`, `supplierContactNumber`, `supplierEmail`) VALUES
(3, 'Justinejay', 'Pagsanjan', 'Justine Jay', '0912345678', 'N/A');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `account`
--
ALTER TABLE `account`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `sales`
--
ALTER TABLE `sales`
  ADD PRIMARY KEY (`salesID`);

--
-- Indexes for table `supplier`
--
ALTER TABLE `supplier`
  ADD PRIMARY KEY (`supplierID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `account`
--
ALTER TABLE `account`
  MODIFY `id` int(3) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=17;

--
-- AUTO_INCREMENT for table `sales`
--
ALTER TABLE `sales`
  MODIFY `salesID` double NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=1000003;

--
-- AUTO_INCREMENT for table `supplier`
--
ALTER TABLE `supplier`
  MODIFY `supplierID` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
