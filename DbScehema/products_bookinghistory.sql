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
-- Table structure for table `bookinghistory`
--

DROP TABLE IF EXISTS `bookinghistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `bookinghistory` (
  `id` int NOT NULL AUTO_INCREMENT,
  `checkoutid` int NOT NULL,
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
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `bookinghistory`
--

LOCK TABLES `bookinghistory` WRITE;
/*!40000 ALTER TABLE `bookinghistory` DISABLE KEYS */;
INSERT INTO `bookinghistory` VALUES (7,11,'88cba0c8-3b31-4169-8fd9-cb71b3c58671',42,1,200,22,0,'2190-07-03 07:01:00','2190-07-03 07:01:00','5KG','self','2023-03-30 17:35:33',NULL,NULL,'Basamti Rice - 5KG'),(8,11,'88cba0c8-3b31-4169-8fd9-cb71b3c58671',43,1,50,45,0,'2190-07-02 14:31:00','2190-07-02 14:31:00','1 KG','self','2023-03-30 17:35:38',NULL,NULL,'Basamti Rice - 1KG'),(9,12,'88cba0c8-3b31-4169-8fd9-cb71b3c58671',42,1,200,22,0,'2190-07-03 07:01:00','2190-07-03 07:01:00','5KG','self','2023-03-30 17:36:08',NULL,NULL,'Basamti Rice - 5KG'),(10,12,'88cba0c8-3b31-4169-8fd9-cb71b3c58671',43,1,50,45,0,'2190-07-02 14:31:00','2190-07-02 14:31:00','1 KG','self','2023-03-30 17:36:08',NULL,NULL,'Basamti Rice - 1KG'),(11,13,'88cba0c8-3b31-4169-8fd9-cb71b3c58671',42,1,200,22,0,'2190-07-03 07:01:00','2190-07-03 07:01:00','5KG','self','2023-03-30 17:39:14',NULL,NULL,'Basamti Rice - 5KG'),(12,13,'88cba0c8-3b31-4169-8fd9-cb71b3c58671',43,1,50,45,0,'2190-07-02 14:31:00','2190-07-02 14:31:00','1 KG','self','2023-03-30 17:39:14',NULL,NULL,'Basamti Rice - 1KG');
/*!40000 ALTER TABLE `bookinghistory` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-03-31 14:24:27
