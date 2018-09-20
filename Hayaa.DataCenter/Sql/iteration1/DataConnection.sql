CREATE TABLE `DataConnection` (
  `DataConnectionId` int(11) NOT NULL AUTO_INCREMENT,
  `DatabaseName` varchar(300) NOT NULL,
  `DatabaseUser` varchar(100) NOT NULL,
  `DatabaseToken` varchar(1024) NOT NULL,
  `Name` varchar(100) NOT NULL,
  `Title` varchar(100) NOT NULL,
  `CreateTime` timestamp NULL DEFAULT current_timestamp(),
  `UpdateTime` timestamp NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  PRIMARY KEY (`DataConnectionId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

