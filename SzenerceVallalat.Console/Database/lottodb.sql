-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2025. Ápr 09. 10:50
-- Kiszolgáló verziója: 10.4.28-MariaDB
-- PHP verzió: 8.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `lottodb`
--

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `players`
--

CREATE TABLE `players` (
  `id` int(2) DEFAULT NULL,
  `name` varchar(35) DEFAULT NULL,
  `email` varchar(26) DEFAULT NULL,
  `amount` int(5) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- A tábla adatainak kiíratása `players`
--

INSERT INTO `players` (`id`, `name`, `email`, `amount`) VALUES
(1, 'Farkas Veres Imre', 'xtith@kovacs.biz', 8000),
(2, 'Varga M. Károly', 'peterimre@hotmail.com', 19200),
(3, 'Gulyás Klára Erzsébet', 'julianna62@sarkozi.hu', 15900),
(4, 'Dr. Kiss Simon Rudolf', 'dsimon@faragi.org', 17000),
(5, 'Dr. Balogh J. Krisztián', 'sorosz@hotmail.com', 8600),
(6, 'Soós Molnár Mária', 'fnemeth@gmail.com', 10600),
(7, 'Budai J. Dávid', 'zsanettpinter@torok.net', 19700),
(8, 'Horváthné Dr. Horváth Teréz Katalin', 'szekelyminika@horvath.biz', 11300),
(9, 'Dr. Tamás Lakatos Gréta', 'kiralyzoltan@gmail.com', 17800),
(10, 'Dr. Tóth Lászlóné', 'vszabi@hotmail.com', 8700),
(11, 'Dr. Fehér Gábor', 'kisskristif@kovacs.com', 19000),
(12, 'Varga Nagy Mária', 'alex31@hegedus.org', 13900),
(13, 'Dr. Kelemen József Sándor', 'mariatamas@gmail.com', 11300),
(14, 'Némethné Dr. Molnár Terézia Zsófia', 'kszabi@kiss.com.hu', 9800),
(15, 'L. Kerekes László', 'tamashajdu@hotmail.com', 10500),
(16, 'J. Szücs Norbert', 'katalin72@hotmail.com', 9200),
(17, 'Szabó Krisztián', 'nagyagnes@yahoo.com', 18400),
(18, 'Dr. Farkas Annamária', 'farkasjulianna@hotmail.com', 8700),
(19, 'Dr. Tóth E. Erzsébet', 'annaorban@szabi.hu', 11300),
(20, 'Dr. Lakatos Diána', 'dantal@kovacs.com', 16200);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
