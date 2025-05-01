-- MySQL dump 10.13  Distrib 8.0.32, for Win64 (x86_64)
--
-- Host: localhost    Database: products
-- ------------------------------------------------------
-- Server version	8.0.32

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `basketcheckout`
--

DROP TABLE IF EXISTS `basketcheckout`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `basketcheckout` (
  `id` int NOT NULL AUTO_INCREMENT,
  `userid` varchar(50) NOT NULL,
  `firstname` varchar(50) NOT NULL,
  `lastname` varchar(50) NOT NULL,
  `emailaddress` varchar(75) NOT NULL,
  `addressline` varchar(250) NOT NULL,
  `country` varchar(50) DEFAULT NULL,
  `state` varchar(45) DEFAULT NULL,
  `zipcode` varchar(45) DEFAULT NULL,
  `cardname` varchar(50) DEFAULT NULL,
  `cardnumber` varchar(15) DEFAULT NULL,
  `expiration` varchar(10) DEFAULT NULL,
  `cvv` varchar(5) DEFAULT NULL,
  `paymentmethod` varchar(50) DEFAULT NULL,
  `createdby` varchar(45) DEFAULT NULL,
  `createddate` datetime DEFAULT NULL,
  `lastmodifiedby` varchar(45) DEFAULT NULL,
  `lastmodifieddate` datetime DEFAULT NULL,
  `totalprice` decimal(16,2) DEFAULT '0.00',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `basketcheckout`
--

LOCK TABLES `basketcheckout` WRITE;
/*!40000 ALTER TABLE `basketcheckout` DISABLE KEYS */;
INSERT INTO `basketcheckout` VALUES (10,'88cba0c8-3b31-4169-8fd9-cb71b3c58671','Jayanth','K.C','jayanth.kc@gmail.com','JAYANTH KC, A-101, RAINBOW WATERFRONT, OPP UTTARAHALLI LAKE, UTTARHALLI, BANGALORE - 560061','India',NULL,'A-101',NULL,NULL,NULL,NULL,'0','self','2023-03-30 17:33:55',NULL,NULL,250.00),(11,'88cba0c8-3b31-4169-8fd9-cb71b3c58671','Jayanth','K.C','jayanth.kc@gmail.com','JAYANTH KC, A-101, RAINBOW WATERFRONT, OPP UTTARAHALLI LAKE, UTTARHALLI, BANGALORE - 560061','India',NULL,'A-101',NULL,NULL,NULL,NULL,'0','self','2023-03-30 17:35:24',NULL,NULL,250.00),(12,'88cba0c8-3b31-4169-8fd9-cb71b3c58671','Jayanth','K.C','jayanth.kc@gmail.com','JAYANTH KC, A-101, RAINBOW WATERFRONT, OPP UTTARAHALLI LAKE, UTTARHALLI, BANGALORE - 560061','India',NULL,'A-101',NULL,NULL,NULL,NULL,'0','self','2023-03-30 17:36:08',NULL,NULL,250.00),(13,'88cba0c8-3b31-4169-8fd9-cb71b3c58671','Jayanth','K.C','jayanth.kc@gmail.com','JAYANTH KC, A-101, RAINBOW WATERFRONT, OPP UTTARAHALLI LAKE, UTTARHALLI, BANGALORE - 560061','India',NULL,'A-101',NULL,NULL,NULL,NULL,'0','self','2023-03-30 17:39:14',NULL,NULL,250.00);
/*!40000 ALTER TABLE `basketcheckout` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-03-31 14:24:28
