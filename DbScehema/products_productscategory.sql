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
-- Table structure for table `productscategory`
--

DROP TABLE IF EXISTS `productscategory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `productscategory` (
  `id` int NOT NULL AUTO_INCREMENT,
  `categoryid` int NOT NULL,
  `productid` int NOT NULL,
  `createdby` varchar(50) NOT NULL,
  `createddate` datetime NOT NULL,
  `lastmodifiedby` varchar(50) DEFAULT NULL,
  `lastmodifieddate` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=20 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `productscategory`
--

LOCK TABLES `productscategory` WRITE;
/*!40000 ALTER TABLE `productscategory` DISABLE KEYS */;
INSERT INTO `productscategory` VALUES (1,1,1,'self','2023-03-12 00:00:00',NULL,NULL),(2,1,2,'self','2023-03-12 00:00:00',NULL,NULL),(3,1,3,'self','2023-03-12 00:00:00',NULL,NULL),(4,2,1,'self','2023-03-16 09:39:48',NULL,NULL),(5,2,3,'self','2023-03-16 09:39:48',NULL,NULL),(6,2,4,'self','2023-03-16 09:39:48',NULL,NULL),(7,2,6,'self','2023-03-16 09:39:48',NULL,NULL),(10,5,1,'self','2023-03-16 10:38:28',NULL,NULL),(11,5,4,'self','2023-03-16 10:38:28',NULL,NULL),(12,18,4,'self','2023-03-16 10:41:32',NULL,NULL),(13,18,16,'self','2023-03-16 10:41:32',NULL,NULL),(14,18,18,'self','2023-03-16 10:41:32',NULL,NULL),(15,8,3,'self','2023-03-16 10:43:12',NULL,NULL),(16,4,1,'self','2023-03-16 10:43:27',NULL,NULL),(17,13,2,'self','2023-03-16 10:44:21',NULL,NULL),(18,13,3,'self','2023-03-16 10:44:21',NULL,NULL),(19,6,3,'self','2023-03-16 10:45:32',NULL,NULL);
/*!40000 ALTER TABLE `productscategory` ENABLE KEYS */;
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
