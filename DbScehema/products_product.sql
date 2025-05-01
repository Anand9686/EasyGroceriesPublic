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
-- Table structure for table `product`
--

DROP TABLE IF EXISTS `product`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `product` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(100) NOT NULL,
  `description` varchar(250) DEFAULT NULL,
  `units` varchar(100) DEFAULT '1',
  `price` double NOT NULL DEFAULT '0',
  `discount` double NOT NULL DEFAULT '0',
  `stockcount` int NOT NULL DEFAULT '0',
  `reorderlevel` int NOT NULL DEFAULT '0',
  `flag` tinyint DEFAULT '0',
  `unit` varchar(15) DEFAULT NULL,
  `discountvaliddate` datetime DEFAULT NULL,
  `imagename` varchar(100) NOT NULL DEFAULT 'test.jpg',
  `createdby` varchar(50) NOT NULL,
  `createddate` datetime NOT NULL,
  `lastmodifiedby` varchar(50) DEFAULT NULL,
  `lastmodifieddate` datetime DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `Name_UNIQUE` (`name`)
) ENGINE=InnoDB AUTO_INCREMENT=24 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `product`
--

LOCK TABLES `product` WRITE;
/*!40000 ALTER TABLE `product` DISABLE KEYS */;
INSERT INTO `product` VALUES (1,'Oil','Edible oil','1',100.5,0.2,20,5,1,'1 Liter','2023-03-03 00:00:00','grocery1.jpg','swn','2023-02-15 21:20:18',NULL,NULL),(2,'Grocery1','Grocery - 1 Descr','1',500.5,0.2,20,5,1,'25 kg','2023-03-03 00:00:00','Grocery1.jpg','manul','2023-02-15 21:20:18',NULL,NULL),(3,'Grocery2','Grocery - 2 Descr','1',500.5,0.2,20,5,1,'1 kg','2023-03-03 00:00:00','grocery2.jpg','manul','2023-02-15 21:20:18',NULL,NULL),(4,'Grocery3','Grocery - 3 Descr','1',500.5,0.2,20,5,1,'50 kg','2023-03-03 00:00:00','grocery3.jpg','manul','2023-02-15 21:20:18',NULL,NULL),(5,'Grocery4','Grocery - 4 Descr','1',500.5,0.2,20,5,1,'500 gm','2023-03-03 00:00:00','grocery4.jpg','manul','2023-02-15 21:20:18',NULL,NULL),(6,'product','product descr','2',10,0.1,20,5,1,'250 gm','2023-02-27 14:51:44','test','self','2023-02-27 20:27:26',NULL,NULL),(8,'product1','product descr','2',10,0.1,20,5,1,'200 gm','2023-02-27 14:51:44','test','self','2023-02-27 20:27:54',NULL,NULL),(9,'Product 21','product descr','17',1000,2,20,2,1,'5 Liter','2023-02-28 22:33:00','test.jpg','self','2023-02-27 22:34:14',NULL,NULL),(15,'Product 2123','product descr','3',100,2,20,2,1,'2 Liter','2023-02-28 22:35:00','test.jpg','self','2023-02-27 22:36:56',NULL,NULL),(16,'Product 2122','product descr','3',100,2,20,2,1,'3 Liter','2023-02-28 23:02:00','test.jpg','self','2023-02-27 23:02:57',NULL,NULL),(17,'Product 11','product descr','5',20,2,2,2,1,'7 Liter','2023-02-28 23:06:00','test.jpg','self','2023-02-27 23:06:20',NULL,NULL),(18,'Product 101','product descr','2',100,2,-1,2,1,'8 Liter','2023-02-28 23:09:00','test.jpg','self','2023-02-27 23:10:05',NULL,NULL),(19,'Product 210','product descr','2',100,2,1,1,1,'20 Liter','2023-02-28 23:14:00','test.jpg','self','2023-02-27 23:14:23',NULL,NULL),(20,'Rice','Sona Rice','42',52,5,25,5,1,'10 Kg','2023-03-30 17:10:00','test.jp','self','2023-03-05 17:10:57',NULL,NULL),(21,'Product 50','Product 50 descr','25 KG Rice',1250,5,100,10,1,NULL,'2023-03-16 14:58:00','test.jpg','self','2023-03-15 14:58:22',NULL,NULL),(22,'K C Jayanth','product descr','12',12,1,1,1,1,NULL,'2023-03-15 17:11:00','test.jpg','self','2023-03-20 17:12:07',NULL,NULL),(23,'9','9','9',9,9,9,9,1,NULL,'2023-03-20 17:13:00','9','self','2023-03-20 17:13:15',NULL,NULL);
/*!40000 ALTER TABLE `product` ENABLE KEYS */;
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
