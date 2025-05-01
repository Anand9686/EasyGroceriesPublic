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
-- Table structure for table `bookitemsforcheckout`
--

DROP TABLE IF EXISTS `bookitemsforcheckout`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `bookitemsforcheckout` (
  `id` int NOT NULL AUTO_INCREMENT,
  `userid` varchar(45) NOT NULL,
  `productdetailid` int NOT NULL,
  `quantity` int NOT NULL,
  `cartcost` double NOT NULL,
  `costtocompany` double NOT NULL,
  `discount` int NOT NULL,
  `discounteffectivestartdate` datetime DEFAULT NULL,
  `discounteffectiveenddate` datetime DEFAULT NULL,
  `unitdetaildesc` varchar(45) DEFAULT NULL,
  `createdby` varchar(45) NOT NULL,
  `createddate` datetime NOT NULL,
  `lastmodifiedby` varchar(45) DEFAULT NULL,
  `lastmodifieddate` datetime DEFAULT NULL,
  `productsubdescription` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `bookitemsforcheckout`
--

LOCK TABLES `bookitemsforcheckout` WRITE;
/*!40000 ALTER TABLE `bookitemsforcheckout` DISABLE KEYS */;
INSERT INTO `bookitemsforcheckout` VALUES (11,'bbe9f375-33db-4c26-b070-c387400f79e0',42,2,200,22,0,'2190-07-03 07:01:00','2190-07-03 07:01:00','5KG','self','2023-03-31 10:19:33',NULL,NULL,'Basamti Rice - 5KG'),(12,'bbe9f375-33db-4c26-b070-c387400f79e0',42,1,200,22,0,'2190-07-03 07:01:00','2190-07-03 07:01:00','5KG','self','2023-03-31 10:19:33',NULL,NULL,'Basamti Rice - 5KG'),(13,'6',42,2,200,22,0,'2190-07-03 07:01:00','2190-07-03 07:01:00','5KG','self','2023-03-31 11:20:22',NULL,NULL,'Basamti Rice - 5KG'),(14,'6',42,1,200,22,0,'2190-07-03 07:01:00','2190-07-03 07:01:00','5KG','self','2023-03-31 11:20:23',NULL,NULL,'Basamti Rice - 5KG'),(15,'6',50,1,50,40,0,'2197-07-03 11:17:00','2197-07-03 11:17:00','5 KG','self','2023-03-31 11:20:23',NULL,NULL,'Rava');
/*!40000 ALTER TABLE `bookitemsforcheckout` ENABLE KEYS */;
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
