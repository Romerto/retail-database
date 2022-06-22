-- phpMyAdmin SQL Dump
-- version 5.1.2
-- https://www.phpmyadmin.net/
--
-- Host: localhost:8889
-- Generation Time: Jun 22, 2022 at 03:42 PM
-- Server version: 5.7.24
-- PHP Version: 8.0.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `retail`
--

-- --------------------------------------------------------

--
-- Table structure for table `retail`
--

CREATE TABLE `retail` (
  `id` int(11) UNSIGNED NOT NULL,
  `name` varchar(100) NOT NULL,
  `type` varchar(100) NOT NULL,
  `price` int(11) NOT NULL,
  `quantity` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `retail`
--

INSERT INTO `retail` (`id`, `name`, `type`, `price`, `quantity`) VALUES
(3, 'DR.WEB SECURITY SPACE', 'АНТИВИРУС', 16, 10),
(6, 'WINDOWS 10 PRO', 'ОПЕРАЦИОННАЯ СИС-МА', 100, 10),
(7, 'KASPERSKY', 'АНТИВИРУС', 120, 0),
(10, 'AYE', 'ФАЙЛ МЕНЕДЖЕР', 120, 0),
(11, 'KASPERSKY VIRUS REMOVAL TOOL', 'УТИЛИТА', 9, 10),
(14, '7ZIP', 'АРХИВАТОР', 123, 100),
(15, 'WINRAR', 'АРХИВАТОР', 100, 61),
(16, 'ODIN', 'УТИЛИТА', 10, 30),
(17, 'DVA', 'ФАЙЛ МЕНЕДЖЕР', 60, 10),
(18, 'TRI', 'АРХИВАТОР', 60, 17),
(19, 'MAC OS', 'ОПЕРАЦИОННАЯ СИС-МА', 500, 10),
(20, 'IOS', 'ОПЕРАЦИОННАЯ СИС-МА', 300, 10),
(21, 'ANDROID', 'ОПЕРАЦИОННАЯ СИС-МА', 150, 10),
(22, 'LINUX', 'ОПЕРАЦИОННАЯ СИС-МА', 10, 10);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `retail`
--
ALTER TABLE `retail`
  ADD UNIQUE KEY `id` (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `retail`
--
ALTER TABLE `retail`
  MODIFY `id` int(11) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=23;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
