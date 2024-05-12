-- phpMyAdmin SQL Dump
-- version 5.1.2
-- https://www.phpmyadmin.net/
--
-- Хост: localhost:3306
-- Время создания: Май 12 2024 г., 15:26
-- Версия сервера: 5.7.24
-- Версия PHP: 8.3.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `environmental-monitoring`
--

-- --------------------------------------------------------

--
-- Структура таблицы `airdata`
--

CREATE TABLE `airdata` (
  `Id_AirData` int(11) NOT NULL,
  `Quality` varchar(32) NOT NULL,
  `Chemical_composition` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `airdata`
--

INSERT INTO `airdata` (`Id_AirData`, `Quality`, `Chemical_composition`) VALUES
(1, 'Высокое качество воздуха', '95%'),
(2, 'Среднее качество воздуха', '70%');

-- --------------------------------------------------------

--
-- Структура таблицы `employee`
--

CREATE TABLE `employee` (
  `Id_employee` int(11) NOT NULL,
  `Id_reports` int(11) NOT NULL,
  `LastName` varchar(32) NOT NULL,
  `Firstname` varchar(32) NOT NULL,
  `Surname` varchar(32) NOT NULL,
  `Phonenumber` decimal(11,0) NOT NULL,
  `Login` varchar(15) NOT NULL,
  `Password` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `employee`
--

INSERT INTO `employee` (`Id_employee`, `Id_reports`, `LastName`, `Firstname`, `Surname`, `Phonenumber`, `Login`, `Password`) VALUES
(1, 1, 'Перфилов', 'Виталий', 'Павлович', '7920643100', 'BloodyAlpha', '404'),
(2, 1, 'Красина', 'Екатерина', 'Викторовна', '79307886421', 'Morik', '405');

-- --------------------------------------------------------

--
-- Структура таблицы `radioactivedata`
--

CREATE TABLE `radioactivedata` (
  `Id_RadioactiveData` int(11) NOT NULL,
  `radioactiveLevel` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `radioactivedata`
--

INSERT INTO `radioactivedata` (`Id_RadioactiveData`, `radioactiveLevel`) VALUES
(1, '0,2'),
(2, '0,2');

-- --------------------------------------------------------

--
-- Структура таблицы `reports`
--

CREATE TABLE `reports` (
  `Id_report` int(11) NOT NULL,
  `Id_AirData` int(11) NOT NULL,
  `Id_RadioactiveData` int(11) NOT NULL,
  `Id_SoilData` int(11) NOT NULL,
  `Id_WaterData` int(11) NOT NULL,
  `Description` varchar(32) NOT NULL,
  `Date` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `reports`
--

INSERT INTO `reports` (`Id_report`, `Id_AirData`, `Id_RadioactiveData`, `Id_SoilData`, `Id_WaterData`, `Description`, `Date`) VALUES
(1, 1, 1, 2, 1, 'Отчёт от 2014-05-01', '2014-05-01'),
(2, 1, 1, 2, 1, 'Отчёт от 2022-05-01', '2022-05-01');

-- --------------------------------------------------------

--
-- Структура таблицы `soildata`
--

CREATE TABLE `soildata` (
  `Id_SoilData` int(11) NOT NULL,
  `Quality` varchar(32) NOT NULL,
  `Acidity` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `soildata`
--

INSERT INTO `soildata` (`Id_SoilData`, `Quality`, `Acidity`) VALUES
(1, 'Высокое качество', 'Средняя кислотность'),
(2, 'Высокое качество', 'Низкая кислотность');

-- --------------------------------------------------------

--
-- Структура таблицы `watterdata`
--

CREATE TABLE `watterdata` (
  `Id_WaterData` int(11) NOT NULL,
  `Quality` varchar(32) NOT NULL,
  `Density` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `watterdata`
--

INSERT INTO `watterdata` (`Id_WaterData`, `Quality`, `Density`) VALUES
(1, 'Высокое качество', '7'),
(2, 'Высокое качество', '5');

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `airdata`
--
ALTER TABLE `airdata`
  ADD PRIMARY KEY (`Id_AirData`);

--
-- Индексы таблицы `employee`
--
ALTER TABLE `employee`
  ADD PRIMARY KEY (`Id_employee`,`Id_reports`),
  ADD KEY `employee_ibfk_1` (`Id_reports`);

--
-- Индексы таблицы `radioactivedata`
--
ALTER TABLE `radioactivedata`
  ADD PRIMARY KEY (`Id_RadioactiveData`);

--
-- Индексы таблицы `reports`
--
ALTER TABLE `reports`
  ADD PRIMARY KEY (`Id_report`,`Id_AirData`,`Id_RadioactiveData`,`Id_SoilData`,`Id_WaterData`),
  ADD KEY `Id_AirData` (`Id_AirData`),
  ADD KEY `Id_RadioactiveData` (`Id_RadioactiveData`),
  ADD KEY `Id_SoilData` (`Id_SoilData`),
  ADD KEY `Id_WaterData` (`Id_WaterData`);

--
-- Индексы таблицы `soildata`
--
ALTER TABLE `soildata`
  ADD PRIMARY KEY (`Id_SoilData`);

--
-- Индексы таблицы `watterdata`
--
ALTER TABLE `watterdata`
  ADD PRIMARY KEY (`Id_WaterData`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `airdata`
--
ALTER TABLE `airdata`
  MODIFY `Id_AirData` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT для таблицы `employee`
--
ALTER TABLE `employee`
  MODIFY `Id_employee` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT для таблицы `radioactivedata`
--
ALTER TABLE `radioactivedata`
  MODIFY `Id_RadioactiveData` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT для таблицы `reports`
--
ALTER TABLE `reports`
  MODIFY `Id_report` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT для таблицы `soildata`
--
ALTER TABLE `soildata`
  MODIFY `Id_SoilData` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT для таблицы `watterdata`
--
ALTER TABLE `watterdata`
  MODIFY `Id_WaterData` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Ограничения внешнего ключа сохраненных таблиц
--

--
-- Ограничения внешнего ключа таблицы `employee`
--
ALTER TABLE `employee`
  ADD CONSTRAINT `employee_ibfk_1` FOREIGN KEY (`Id_reports`) REFERENCES `reports` (`Id_report`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Ограничения внешнего ключа таблицы `reports`
--
ALTER TABLE `reports`
  ADD CONSTRAINT `reports_ibfk_1` FOREIGN KEY (`Id_AirData`) REFERENCES `airdata` (`Id_AirData`),
  ADD CONSTRAINT `reports_ibfk_2` FOREIGN KEY (`Id_RadioactiveData`) REFERENCES `radioactivedata` (`Id_RadioactiveData`),
  ADD CONSTRAINT `reports_ibfk_3` FOREIGN KEY (`Id_SoilData`) REFERENCES `soildata` (`Id_SoilData`),
  ADD CONSTRAINT `reports_ibfk_4` FOREIGN KEY (`Id_WaterData`) REFERENCES `watterdata` (`Id_WaterData`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
