

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for `CodeTemplate`
-- ----------------------------
DROP TABLE IF EXISTS `CodeTemplate`;
CREATE TABLE `CodeTemplate` (
  `CodeTemplateId` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) NOT NULL,
  `Content` longtext NOT NULL,
  `SpaceName` varchar(300) NOT NULL,
  `Language` int(11) NOT NULL,
  `GenCodeType` int(11) NOT NULL,
  `CreateTime` timestamp NULL DEFAULT current_timestamp(),
  `UpdateTime` timestamp NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  PRIMARY KEY (`CodeTemplateId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of CodeTemplate
-- ----------------------------

-- ----------------------------
-- Table structure for `Rel_Solution_CodeTemplate`
-- ----------------------------
DROP TABLE IF EXISTS `Rel_Solution_CodeTemplate`;
CREATE TABLE `Rel_Solution_CodeTemplate` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `SolutionTemplateId` int(11) NOT NULL,
  `CodeTemplateId` int(11) NOT NULL,
  `CreateTime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00' ON UPDATE current_timestamp(),
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of Rel_Solution_CodeTemplate
-- ----------------------------

-- ----------------------------
-- Table structure for `SolutionTemplate`
-- ----------------------------
DROP TABLE IF EXISTS `SolutionTemplate`;
CREATE TABLE `SolutionTemplate` (
  `SolutionTemplateId` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) NOT NULL,
  `Title` varchar(100) NOT NULL,
  `CreateTime` timestamp NULL DEFAULT current_timestamp(),
  `UpdateTime` timestamp NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  PRIMARY KEY (`SolutionTemplateId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of SolutionTemplate
-- ----------------------------
