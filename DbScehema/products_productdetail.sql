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
-- Table structure for table `productdetail`
--

DROP TABLE IF EXISTS `productdetail`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `productdetail` (
  `id` int NOT NULL AUTO_INCREMENT,
  `productid` int NOT NULL,
  `vendorid` int NOT NULL,
  `categoryid` int NOT NULL,
  `unitid` int NOT NULL,
  `unitdetailid` int DEFAULT NULL,
  `productvendorcode` varchar(45) NOT NULL,
  `productvendorname` varchar(100) NOT NULL,
  `cartcost` double NOT NULL,
  `costtocompany` double NOT NULL,
  `quantity` int NOT NULL,
  `availablequantity` int NOT NULL,
  `discount` int DEFAULT '0',
  `discounteffectivestartdate` datetime DEFAULT NULL,
  `discounteffectiveenddate` datetime DEFAULT NULL,
  `stockarivaldate` datetime DEFAULT NULL,
  `imagename` varchar(75) NOT NULL,
  `flag` tinyint DEFAULT NULL,
  `createdby` varchar(50) NOT NULL,
  `createddate` datetime NOT NULL,
  `lastmodifiedby` varchar(150) DEFAULT NULL,
  `lastmodifieddate` datetime DEFAULT NULL,
  `productsubdescription` varchar(150) DEFAULT NULL,
  `unitdetaildesc` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=52 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `productdetail`
--

LOCK TABLES `productdetail` WRITE;
/*!40000 ALTER TABLE `productdetail` DISABLE KEYS */;
INSERT INTO `productdetail` VALUES (40,1,1,1,2,4,'PVC001','PVN-1',25,20,20,20,0,'2190-07-03 07:01:00','2190-07-03 07:01:00','2189-07-03 07:01:00','test.jpg',1,'self','0001-01-01 00:00:00','self','2023-03-29 15:46:56','Test','1 KG'),(41,1,1,1,1,1,'PVC0002','PVN-2',25,25,19,19,0,'2190-07-03 07:03:00','2190-07-03 07:03:00','2189-07-03 07:03:00','test.jpg',1,'self','0001-01-01 00:00:00','self','2023-03-30 22:43:20','Test','1 KG'),(42,1,1,1,1,2,'PVC001','PVN-1',200,22,20,10,0,'2190-07-03 07:01:00','2190-07-03 07:01:00','2189-07-03 07:01:00','test.jpg',1,'self','0001-01-01 00:00:00','self','2023-03-31 11:20:23','Basamti Rice - 5KG','5KG'),(43,1,1,1,1,1,'PVC001','PVN-1',50,45,25,24,0,'2190-07-02 14:31:00','2190-07-02 14:31:00','2189-07-02 14:31:00','test.jpg',1,'self','0001-01-01 00:00:00','self','2023-03-30 17:30:08','Basamti Rice - 1KG','1 KG'),(44,6,1,1,1,1,'PVC4','PVN 4',250,225,25,24,0,'2190-07-03 07:17:00','2190-07-03 07:17:00','2189-07-03 07:17:00','test.jpg',1,'self','0001-01-01 00:00:00','self','2023-03-30 15:45:01','Test','1 KG'),(45,5,1,1,1,1,'PVC7','PVN7',25,20,10,10,0,'2190-07-03 13:22:00','2190-07-03 13:22:00','2189-07-03 13:22:00','test.jpg',1,'self','2023-03-22 18:52:38',NULL,NULL,'Test','1 KG'),(46,2,1,1,1,1,'PVC8','PVN8',25,25,10,10,0,'2190-07-03 13:24:00','2190-07-03 13:24:00','2189-07-03 13:24:00','test.jpg',1,'self','2023-03-22 18:55:09',NULL,NULL,'Test','1 KG'),(47,3,1,1,1,1,'PVC10','PVN10',20,20,20,20,0,'2190-07-03 14:02:00','2190-07-03 14:02:00','2189-07-03 14:02:00','test.jpg',1,'self','2023-03-22 19:32:19',NULL,NULL,'Test','1 KG'),(48,4,1,1,1,1,'PVC11','PVN11',25,25,10,10,0,'2190-07-03 14:05:00','2190-07-03 14:05:00','2189-07-03 14:05:00','test.jpg',1,'self','2023-03-22 19:35:51',NULL,NULL,'Test','1 KG'),(49,1,1,1,2,3,'PVC0101','PVN0101',80,75,25,25,1,'2197-07-02 19:34:00','2191-07-02 19:34:00','2189-07-02 19:34:00','test.jpg',1,'self','0001-01-01 00:00:00','self','2023-03-29 15:45:59','Test','1 KG'),(50,1,1,1,1,2,'PVC2011','PVN2011',50,40,25,44,1,'2197-07-03 11:17:00','2197-07-03 11:17:00','2196-07-03 11:17:00','test.jpg',1,'self','2023-03-29 16:47:44','self','2023-03-31 11:20:23','Rava','5 KG'),(51,1,1,1,1,2,'PVC0020','PVN0021',200,190,25,25,1,'2197-07-03 16:48:00','2197-07-03 16:48:00','2196-07-03 16:48:00','test.jpg',1,'self','2023-03-29 22:18:39',NULL,NULL,'Basamti Rice - 5 KG','5 KG');
/*!40000 ALTER TABLE `productdetail` ENABLE KEYS */;
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
