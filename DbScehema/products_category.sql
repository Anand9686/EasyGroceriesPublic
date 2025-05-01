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
-- Table structure for table `category`
--

DROP TABLE IF EXISTS `category`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `category` (
  `id` int NOT NULL AUTO_INCREMENT,
  `categoryname` varchar(50) NOT NULL,
  `categorydescr` varchar(250) DEFAULT NULL,
  `categoryparent` int NOT NULL,
  `flag` tinyint DEFAULT '0',
  `createdby` varchar(50) NOT NULL,
  `createddate` datetime NOT NULL,
  `lastmodifiedby` varchar(50) DEFAULT NULL,
  `lastmodifieddate` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=43 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `category`
--

LOCK TABLES `category` WRITE;
/*!40000 ALTER TABLE `category` DISABLE KEYS */;
INSERT INTO `category` VALUES (1,'Category-1','Category-1 Descr',0,1,'self','2023-02-24 00:00:00',NULL,NULL),(2,'Category-2','Category- 2 Descr',1,1,'self','2023-02-26 13:52:07',NULL,NULL),(3,'Category-2','Category- 2 Descr',1,1,'self','2023-02-26 13:52:44',NULL,NULL),(4,'Category-2','Category- 2 Descr',1,1,'self','2023-02-26 13:53:06',NULL,NULL),(5,'Category-2','Category- 2 Descr',1,1,'self','2023-02-26 13:56:07',NULL,NULL),(6,'Category-2','Category- 2 Descr',1,1,'self','2023-02-26 13:56:14',NULL,NULL),(7,'Category-2','Category- 2 Descr',1,1,'self','2023-02-26 13:56:24',NULL,NULL),(8,'Category-2','Category- 2 Descr',1,1,'self','2023-02-26 15:13:14',NULL,NULL),(9,'Category-2','Category- 2 Descr',1,1,'self','2023-02-26 15:13:46',NULL,NULL),(10,'Category-2','Category- 2 Descr',1,1,'self','2023-02-26 15:14:14',NULL,NULL),(11,'Category-2','Category- 2 Descr',1,1,'self','2023-02-26 15:14:33',NULL,NULL),(12,'Category-2','Category- 2 Descr',0,1,'self','2023-02-26 15:15:53',NULL,NULL),(13,'Category-2','Category- 2 Descr',1,1,'self','2023-02-26 15:18:00',NULL,NULL),(14,'Category-2','Category- 2 Descr',1,1,'self','2023-02-26 15:19:39',NULL,NULL),(15,'Category-2','Category- 2 Descr',13,1,'self','2023-02-26 15:20:19',NULL,NULL),(16,'Category-2','Category- 2 Descr',1,1,'self','2023-02-26 15:22:56',NULL,NULL),(17,'Category-21','Category- 2 Descr',1,1,'self','2023-02-26 15:24:28',NULL,NULL),(18,'Category-21','Category- 2 Descr',1,1,'self','2023-02-26 15:26:59',NULL,NULL),(19,'Category-2','Category- 2 Descr',1,1,'self','2023-02-26 15:33:41',NULL,NULL),(20,'Category-2','Category- 2 Descr',1,1,'self','2023-02-26 15:36:28',NULL,NULL),(21,'Category-2','Category- 2 Descr',20,1,'self','2023-02-26 15:37:32',NULL,NULL),(22,'Category-2','Category- 2 Descr',0,1,'self','2023-02-26 15:39:25',NULL,NULL),(23,'Category-2','Category- 2 Descr',0,1,'self','2023-02-26 15:40:16',NULL,NULL),(24,'Category-2','Category- 2 Descr',1,1,'self','2023-02-26 15:43:44',NULL,NULL),(25,'Category-21','Category- 2 Descr',19,1,'self','2023-02-26 15:46:54',NULL,NULL),(26,'Category-2','Category- 2 Descr',18,1,'self','2023-02-26 15:48:36',NULL,NULL),(27,'Category-2','Category- 2 Descr',19,1,'self','2023-02-26 15:49:56',NULL,NULL),(28,'Category-2','Category- 2 Descr',0,1,'self','2023-02-26 15:51:08',NULL,NULL),(29,'Category-2','Category- 2 Descr',9,1,'self','2023-02-26 15:52:15',NULL,NULL),(30,'Category-2','Category- 2 Descr',0,1,'self','2023-02-26 15:52:51',NULL,NULL),(31,'Category-22','Category- 2 Descr',0,1,'self','2023-02-26 15:53:51',NULL,NULL),(32,'Category-2','Category- 2 Descr',11,1,'self','2023-02-26 15:58:46',NULL,NULL),(33,'Category-2','Category- 2 Descr',18,1,'self','2023-02-26 15:58:59',NULL,NULL),(34,'Category-2','Category- 2 Descr',3,1,'self','2023-02-26 16:00:21',NULL,NULL),(35,'Category-21','Category- 2 Descr',6,1,'self','2023-02-26 16:00:40',NULL,NULL),(36,'Category-2','Category- 2 Descr',18,1,'self','2023-02-26 16:01:44',NULL,NULL),(37,'Category-2','Category- 2 Descr',0,1,'self','2023-02-26 16:01:52',NULL,NULL),(38,'Category-21','Category- 2 Descr',20,1,'self','2023-02-26 16:03:06',NULL,NULL),(39,'Category-21','Category- 2 Descr',20,1,'self','2023-02-26 16:03:48',NULL,NULL),(40,'Category-21','Category- 2 Descr',21,1,'self','2023-02-26 16:04:31',NULL,NULL),(41,'test','test',0,1,'self','2023-02-27 20:21:27',NULL,NULL),(42,'Categories-15','cat-des-15',4,1,'self','2023-03-05 17:09:04',NULL,NULL);
/*!40000 ALTER TABLE `category` ENABLE KEYS */;
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
