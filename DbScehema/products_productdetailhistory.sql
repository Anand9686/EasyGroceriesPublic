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
-- Table structure for table `productdetailhistory`
--

DROP TABLE IF EXISTS `productdetailhistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `productdetailhistory` (
  `id` int NOT NULL AUTO_INCREMENT,
  `proddetailid` int DEFAULT NULL,
  `productid` int NOT NULL,
  `categoryid` int NOT NULL,
  `vendorid` int NOT NULL,
  `unitid` int NOT NULL,
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
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=63 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `productdetailhistory`
--

LOCK TABLES `productdetailhistory` WRITE;
/*!40000 ALTER TABLE `productdetailhistory` DISABLE KEYS */;
INSERT INTO `productdetailhistory` VALUES (40,40,1,1,1,1,'PVC001','PVN-1',25,20,20,20,0,'2190-07-03 12:31:00','2190-07-03 12:31:00','2189-07-03 12:31:00','test.jpg',1,'self','2023-03-22 18:01:45',NULL,NULL),(41,41,1,1,1,1,'PVC0002','PVN-2',25,25,20,20,0,'2190-07-03 12:33:00','2190-07-03 12:33:00','2189-07-03 12:33:00','test.jpg',1,'self','2023-03-22 18:04:25',NULL,NULL),(42,42,1,1,1,1,'PVC001','PVN-1',25,22,20,20,0,'2190-07-03 12:31:00','2190-07-03 12:31:00','2189-07-03 12:31:00','test.jpg',1,'self','2023-03-22 18:07:35',NULL,NULL),(43,43,1,1,1,1,'PVC001','PVN-1',25,23,20,20,0,'2190-07-03 12:31:00','2190-07-03 12:31:00','2189-07-03 12:31:00','test.jpg',1,'self','2023-03-22 18:08:38',NULL,NULL),(44,43,1,1,1,1,'PVC001','PVN-1',25,23,20,20,0,'2190-07-03 12:31:00','2190-07-03 12:31:00','2189-07-03 12:31:00','test.jpg',1,'self','2023-03-22 18:10:00','Snapshot before update in Product Detail History. Product Stcok detail will have new stock info after update','2023-03-22 12:40:00'),(45,43,1,1,1,1,'PVC001','PVN-1',25,45,20,20,0,'2190-07-03 07:01:00','2190-07-03 07:01:00','2189-07-03 07:01:00','test.jpg',1,'self','2023-03-22 18:14:34','Snapshot before update in Product Detail History. Product Stcok detail will have new stock info after update','2023-03-22 12:44:34'),(46,44,1,1,1,1,'PVC4','PVN 4',250,225,25,25,0,'2190-07-03 12:47:00','2190-07-03 12:47:00','2189-07-03 12:47:00','test.jpg',1,'self','2023-03-22 18:18:41',NULL,NULL),(47,45,1,1,1,1,'PVC7','PVN7',25,20,10,10,0,'2190-07-03 13:22:00','2190-07-03 13:22:00','2189-07-03 13:22:00','test.jpg',1,'self','2023-03-22 18:52:38',NULL,NULL),(48,46,1,1,1,1,'PVC8','PVN8',25,25,10,10,0,'2190-07-03 13:24:00','2190-07-03 13:24:00','2189-07-03 13:24:00','test.jpg',1,'self','2023-03-22 18:55:09',NULL,NULL),(49,47,1,1,1,1,'PVC10','PVN10',20,20,20,20,0,'2190-07-03 14:02:00','2190-07-03 14:02:00','2189-07-03 14:02:00','test.jpg',1,'self','2023-03-22 19:32:19',NULL,NULL),(50,48,1,1,1,1,'PVC11','PVN11',25,25,10,10,0,'2190-07-03 14:05:00','2190-07-03 14:05:00','2189-07-03 14:05:00','test.jpg',1,'self','2023-03-22 19:35:51',NULL,NULL),(51,49,1,1,1,1,'PVC0101','PVN0101',80,75,25,25,1,'2197-07-03 06:34:00','2191-07-03 06:34:00','2189-07-03 06:34:00','test.jpg',1,'self','2023-03-29 12:05:11',NULL,NULL),(52,49,1,1,1,1,'PVC0101','PVN0101',80,75,25,25,1,'2197-07-03 06:34:00','2191-07-03 06:34:00','2189-07-03 06:34:00','test.jpg',1,'self','2023-03-29 13:05:07','Snapshot before update in Product Detail History. Product Stcok detail will have new stock info after update','2023-03-29 07:35:07'),(53,49,1,1,1,2,'PVC0101','PVN0101',80,75,25,25,1,'2197-07-03 01:04:00','2191-07-03 01:04:00','2189-07-03 01:04:00','test.jpg',1,'self','2023-03-29 15:45:59','Snapshot before update in Product Detail History. Product Stcok detail will have new stock info after update','2023-03-29 10:15:59'),(54,43,1,1,1,1,'PVC001','PVN-1',50,45,20,20,0,'2190-07-03 07:01:00','2190-07-03 07:01:00','2189-07-03 07:01:00','test.jpg',1,'self','2023-03-29 15:46:23','Snapshot before update in Product Detail History. Product Stcok detail will have new stock info after update','2023-03-29 10:16:23'),(55,42,1,1,1,1,'PVC001','PVN-1',25,22,20,20,0,'2190-07-03 12:31:00','2190-07-03 12:31:00','2189-07-03 12:31:00','test.jpg',1,'self','2023-03-29 15:46:34','Snapshot before update in Product Detail History. Product Stcok detail will have new stock info after update','2023-03-29 10:16:34'),(56,41,1,1,1,1,'PVC0002','PVN-2',25,25,20,20,0,'2190-07-03 12:33:00','2190-07-03 12:33:00','2189-07-03 12:33:00','test.jpg',1,'self','2023-03-29 15:46:43','Snapshot before update in Product Detail History. Product Stcok detail will have new stock info after update','2023-03-29 10:16:43'),(57,40,1,1,1,1,'PVC001','PVN-1',25,20,20,20,0,'2190-07-03 12:31:00','2190-07-03 12:31:00','2189-07-03 12:31:00','test.jpg',1,'self','2023-03-29 15:46:56','Snapshot before update in Product Detail History. Product Stcok detail will have new stock info after update','2023-03-29 10:16:56'),(58,44,6,1,1,1,'PVC4','PVN 4',250,225,25,25,0,'2190-07-03 12:47:00','2190-07-03 12:47:00','2189-07-03 12:47:00','test.jpg',1,'self','2023-03-29 15:47:42','Snapshot before update in Product Detail History. Product Stcok detail will have new stock info after update','2023-03-29 10:17:42'),(59,43,1,1,1,1,'PVC001','PVN-1',50,45,20,20,0,'2190-07-03 01:31:00','2190-07-03 01:31:00','2189-07-03 01:31:00','test.jpg',1,'self','2023-03-29 16:02:58','Snapshot before update in Product Detail History. Product Stcok detail will have new stock info after update','2023-03-29 10:32:58'),(60,43,1,1,1,1,'PVC001','PVN-1',50,45,20,20,0,'2190-07-02 20:01:00','2190-07-02 20:01:00','2189-07-02 20:01:00','test.jpg',1,'self','2023-03-29 16:46:47','Snapshot before update in Product Detail History. Product Stcok detail will have new stock info after update','2023-03-29 11:16:47'),(61,50,1,1,1,1,'PVC2011','PVN2011',50,40,25,45,1,'2197-07-03 11:17:00','2197-07-03 11:17:00','2196-07-03 11:17:00','test.jpg',1,'self','2023-03-29 16:47:44',NULL,NULL),(62,51,1,1,1,1,'PVC0020','PVN0021',200,190,25,25,1,'2197-07-03 16:48:00','2197-07-03 16:48:00','2196-07-03 16:48:00','test.jpg',1,'self','2023-03-29 22:18:39',NULL,NULL);
/*!40000 ALTER TABLE `productdetailhistory` ENABLE KEYS */;
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
