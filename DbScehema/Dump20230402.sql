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
-- Table structure for table `basket`
--

DROP TABLE IF EXISTS `basket`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `basket` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `userid` varchar(50) NOT NULL,
  `productdetailid` int NOT NULL,
  `quantity` int NOT NULL,
  `flag` tinyint NOT NULL DEFAULT '1',
  `createdby` varchar(150) DEFAULT NULL,
  `createddate` datetime DEFAULT NULL,
  `lastmodifiedby` varchar(150) DEFAULT NULL,
  `lastmodifieddate` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=92 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `basket`
--

LOCK TABLES `basket` WRITE;
/*!40000 ALTER TABLE `basket` DISABLE KEYS */;
INSERT INTO `basket` VALUES (81,'bbe9f375-33db-4c26-b070-c387400f79e0',42,2,1,'self','2023-03-31 10:17:48','self','2023-03-31 10:18:10'),(82,'bbe9f375-33db-4c26-b070-c387400f79e0',42,1,1,'self','2023-03-31 10:17:49',NULL,NULL),(87,'6',41,1,1,'self','2023-03-31 21:03:27',NULL,NULL),(88,'6',45,1,1,'self','2023-03-31 21:03:29',NULL,NULL),(89,'6',46,1,1,'self','2023-03-31 21:03:30',NULL,NULL),(91,'6',43,1,1,'self','2023-03-31 21:03:35',NULL,NULL);
/*!40000 ALTER TABLE `basket` ENABLE KEYS */;
UNLOCK TABLES;

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
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `basketcheckout`
--

LOCK TABLES `basketcheckout` WRITE;
/*!40000 ALTER TABLE `basketcheckout` DISABLE KEYS */;
INSERT INTO `basketcheckout` VALUES (10,'88cba0c8-3b31-4169-8fd9-cb71b3c58671','Jayanth','K.C','jayanth.kc@gmail.com','JAYANTH KC, A-101, RAINBOW WATERFRONT, OPP UTTARAHALLI LAKE, UTTARHALLI, BANGALORE - 560061','India',NULL,'A-101',NULL,NULL,NULL,NULL,'0','self','2023-03-30 17:33:55',NULL,NULL,250.00),(11,'88cba0c8-3b31-4169-8fd9-cb71b3c58671','Jayanth','K.C','jayanth.kc@gmail.com','JAYANTH KC, A-101, RAINBOW WATERFRONT, OPP UTTARAHALLI LAKE, UTTARHALLI, BANGALORE - 560061','India',NULL,'A-101',NULL,NULL,NULL,NULL,'0','self','2023-03-30 17:35:24',NULL,NULL,250.00),(12,'88cba0c8-3b31-4169-8fd9-cb71b3c58671','Jayanth','K.C','jayanth.kc@gmail.com','JAYANTH KC, A-101, RAINBOW WATERFRONT, OPP UTTARAHALLI LAKE, UTTARHALLI, BANGALORE - 560061','India',NULL,'A-101',NULL,NULL,NULL,NULL,'0','self','2023-03-30 17:36:08',NULL,NULL,250.00),(13,'6','Jayanth','K.C','jayanth.kc@gmail.com','JAYANTH KC, A-101, RAINBOW WATERFRONT, OPP UTTARAHALLI LAKE, UTTARHALLI, BANGALORE - 560061','India',NULL,'A-101',NULL,NULL,NULL,NULL,'0','self','2023-03-30 17:39:14',NULL,NULL,250.00),(14,'6','Jayanth','K.C','jayanth.kc@gmail.com','JAYANTH KC, A-101, RAINBOW WATERFRONT, OPP UTTARAHALLI LAKE, UTTARHALLI, BANGALORE - 560061','India',NULL,'A-101',NULL,NULL,NULL,NULL,'0','self','2023-03-31 21:04:09',NULL,NULL,1175.00);
/*!40000 ALTER TABLE `basketcheckout` ENABLE KEYS */;
UNLOCK TABLES;

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
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `bookinghistory`
--

LOCK TABLES `bookinghistory` WRITE;
/*!40000 ALTER TABLE `bookinghistory` DISABLE KEYS */;
INSERT INTO `bookinghistory` VALUES (7,11,'88cba0c8-3b31-4169-8fd9-cb71b3c58671',42,1,200,22,0,'2190-07-03 07:01:00','2190-07-03 07:01:00','5KG','self','2023-03-30 17:35:33',NULL,NULL,'Basamti Rice - 5KG'),(8,11,'88cba0c8-3b31-4169-8fd9-cb71b3c58671',43,1,50,45,0,'2190-07-02 14:31:00','2190-07-02 14:31:00','1 KG','self','2023-03-30 17:35:38',NULL,NULL,'Basamti Rice - 1KG'),(9,12,'88cba0c8-3b31-4169-8fd9-cb71b3c58671',42,1,200,22,0,'2190-07-03 07:01:00','2190-07-03 07:01:00','5KG','self','2023-03-30 17:36:08',NULL,NULL,'Basamti Rice - 5KG'),(10,12,'88cba0c8-3b31-4169-8fd9-cb71b3c58671',43,1,50,45,0,'2190-07-02 14:31:00','2190-07-02 14:31:00','1 KG','self','2023-03-30 17:36:08',NULL,NULL,'Basamti Rice - 1KG'),(11,13,'6',42,1,200,22,0,'2190-07-03 07:01:00','2190-07-03 07:01:00','5KG','self','2023-03-30 17:39:14',NULL,NULL,'Basamti Rice - 5KG'),(12,13,'6',43,1,50,45,0,'2190-07-02 14:31:00','2190-07-02 14:31:00','1 KG','self','2023-03-30 17:39:14',NULL,NULL,'Basamti Rice - 1KG'),(13,14,'6',42,2,200,22,0,'2190-07-03 07:01:00','2190-07-03 07:01:00','5KG','self','2023-03-31 21:04:09',NULL,NULL,'Basamti Rice - 5KG'),(14,14,'6',42,1,200,22,0,'2190-07-03 07:01:00','2190-07-03 07:01:00','5KG','self','2023-03-31 21:04:09',NULL,NULL,'Basamti Rice - 5KG'),(15,14,'6',50,1,50,40,0,'2197-07-03 11:17:00','2197-07-03 11:17:00','5 KG','self','2023-03-31 21:04:09',NULL,NULL,'Rava');
/*!40000 ALTER TABLE `bookinghistory` ENABLE KEYS */;
UNLOCK TABLES;

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
INSERT INTO `bookitemsforcheckout` VALUES (11,'bbe9f375-33db-4c26-b070-c387400f79e0',42,2,200,22,0,'2190-07-03 07:01:00','2190-07-03 07:01:00','5KG','self','2023-03-31 10:19:33',NULL,NULL,'Basamti Rice - 5KG'),(12,'bbe9f375-33db-4c26-b070-c387400f79e0',42,1,200,22,0,'2190-07-03 07:01:00','2190-07-03 07:01:00','5KG','self','2023-03-31 10:19:33',NULL,NULL,'Basamti Rice - 5KG');
/*!40000 ALTER TABLE `bookitemsforcheckout` ENABLE KEYS */;
UNLOCK TABLES;

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

--
-- Table structure for table `delivery`
--

DROP TABLE IF EXISTS `delivery`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `delivery` (
  `id` int NOT NULL AUTO_INCREMENT,
  `deliverycode` varchar(45) NOT NULL,
  `deliveryname` varchar(50) NOT NULL,
  `description` varchar(250) DEFAULT NULL,
  `address` varchar(500) NOT NULL,
  `email` varchar(45) DEFAULT NULL,
  `phone` varchar(15) NOT NULL,
  `flag` tinyint DEFAULT '1',
  `createdby` varchar(45) NOT NULL,
  `createddate` datetime NOT NULL,
  `lastmodifiedby` varchar(45) DEFAULT NULL,
  `lastmodifieddate` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `delivery`
--

LOCK TABLES `delivery` WRITE;
/*!40000 ALTER TABLE `delivery` DISABLE KEYS */;
/*!40000 ALTER TABLE `delivery` ENABLE KEYS */;
UNLOCK TABLES;

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
) ENGINE=InnoDB AUTO_INCREMENT=53 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `productdetail`
--

LOCK TABLES `productdetail` WRITE;
/*!40000 ALTER TABLE `productdetail` DISABLE KEYS */;
INSERT INTO `productdetail` VALUES (40,1,1,1,2,4,'PVC001','PVN-1',25,20,20,20,0,'2190-07-03 07:01:00','2190-07-03 07:01:00','2189-07-03 07:01:00','test.jpg',1,'self','0001-01-01 00:00:00','self','2023-03-29 15:46:56','Test','1 KG'),(41,1,1,1,1,1,'PVC0002','PVN-2',25,25,19,19,0,'2190-07-03 07:03:00','2190-07-03 07:03:00','2189-07-03 07:03:00','test.jpg',1,'self','0001-01-01 00:00:00','self','2023-03-30 22:43:20','Test','1 KG'),(42,1,1,1,1,2,'PVC001','PVN-1',200,22,20,10,0,'2190-07-03 07:01:00','2190-07-03 07:01:00','2189-07-03 07:01:00','test.jpg',1,'self','0001-01-01 00:00:00','self','2023-03-31 11:20:23','Basamti Rice - 5KG','5KG'),(43,1,1,1,1,1,'PVC001','PVN-1',50,45,25,24,0,'2190-07-02 14:31:00','2190-07-02 14:31:00','2189-07-02 14:31:00','test.jpg',1,'self','0001-01-01 00:00:00','self','2023-03-30 17:30:08','Basamti Rice - 1KG','1 KG'),(44,6,1,1,1,1,'PVC4','PVN 4',250,225,25,24,0,'2190-07-03 07:17:00','2190-07-03 07:17:00','2189-07-03 07:17:00','test.jpg',1,'self','0001-01-01 00:00:00','self','2023-03-30 15:45:01','Test','1 KG'),(45,5,1,1,1,1,'PVC7','PVN7',25,20,10,10,0,'2190-07-03 13:22:00','2190-07-03 13:22:00','2189-07-03 13:22:00','test.jpg',1,'self','2023-03-22 18:52:38',NULL,NULL,'Test','1 KG'),(46,2,1,1,1,1,'PVC8','PVN8',25,25,10,10,0,'2190-07-03 13:24:00','2190-07-03 13:24:00','2189-07-03 13:24:00','test.jpg',1,'self','2023-03-22 18:55:09',NULL,NULL,'Test','1 KG'),(47,3,1,1,1,1,'PVC10','PVN10',20,20,20,20,0,'2190-07-03 14:02:00','2190-07-03 14:02:00','2189-07-03 14:02:00','test.jpg',1,'self','2023-03-22 19:32:19',NULL,NULL,'Test','1 KG'),(48,4,1,1,1,1,'PVC11','PVN11',25,25,10,10,0,'2190-07-03 14:05:00','2190-07-03 14:05:00','2189-07-03 14:05:00','test.jpg',1,'self','2023-03-22 19:35:51',NULL,NULL,'Test','1 KG'),(49,1,1,1,2,3,'PVC0101','PVN0101',80,75,25,25,1,'2197-07-02 19:34:00','2191-07-02 19:34:00','2189-07-02 19:34:00','test.jpg',1,'self','0001-01-01 00:00:00','self','2023-03-29 15:45:59','Test','1 KG'),(50,1,1,1,1,2,'PVC2011','PVN2011',50,40,25,44,1,'2197-07-03 11:17:00','2197-07-03 11:17:00','2196-07-03 11:17:00','test.jpg',1,'self','2023-03-29 16:47:44','self','2023-03-31 11:20:23','Rava','5 KG'),(51,1,1,1,1,2,'PVC0020','PVN0021',200,190,25,25,1,'2197-07-03 16:48:00','2197-07-03 16:48:00','2196-07-03 16:48:00','test.jpg',1,'self','2023-03-29 22:18:39',NULL,NULL,'Basamti Rice - 5 KG','5 KG'),(52,1,1,1,1,2,'PVC333','PVN333',200,190,25,25,1,'2023-03-31 16:48:00','2023-04-05 16:48:00','2023-03-03 16:48:00','test.jpg',1,'self','2023-03-31 16:48:00',NULL,NULL,'Basamti Rice','5 KG');
/*!40000 ALTER TABLE `productdetail` ENABLE KEYS */;
UNLOCK TABLES;

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

--
-- Table structure for table `productstockdetail`
--

DROP TABLE IF EXISTS `productstockdetail`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `productstockdetail` (
  `id` int NOT NULL AUTO_INCREMENT,
  `proddetailhistoryid` int DEFAULT NULL,
  `productid` int NOT NULL,
  `vendorid` int NOT NULL,
  `categoryid` int NOT NULL,
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
-- Dumping data for table `productstockdetail`
--

LOCK TABLES `productstockdetail` WRITE;
/*!40000 ALTER TABLE `productstockdetail` DISABLE KEYS */;
INSERT INTO `productstockdetail` VALUES (40,40,1,1,1,1,'PVC001','PVN-1',25,20,20,20,0,'2190-07-03 12:31:00','2190-07-03 12:31:00','2189-07-03 12:31:00','test.jpg',1,'self','2023-03-22 18:01:45',NULL,NULL),(41,41,1,1,1,1,'PVC0002','PVN-2',25,25,20,20,0,'2190-07-03 12:33:00','2190-07-03 12:33:00','2189-07-03 12:33:00','test.jpg',1,'self','2023-03-22 18:05:26',NULL,NULL),(42,42,1,1,1,1,'PVC001','PVN-1',25,22,20,20,0,'2190-07-03 12:31:00','2190-07-03 12:31:00','2189-07-03 12:31:00','test.jpg',1,'self','2023-03-22 18:07:35',NULL,NULL),(43,43,1,1,1,1,'PVC001','PVN-1',25,23,20,20,0,'2190-07-03 12:31:00','2190-07-03 12:31:00','2189-07-03 12:31:00','test.jpg',1,'self','2023-03-22 18:08:38',NULL,NULL),(44,44,1,1,1,1,'PVC001','PVN-1',25,45,20,20,0,'2190-07-03 07:01:00','2190-07-03 07:01:00','2189-07-03 07:01:00','test.jpg',1,'self','2023-03-22 18:10:00','Snapshot before update. Product Stcok detail will have new  addition info','2023-03-22 12:40:00'),(45,45,1,1,1,1,'PVC001','PVN-1',50,45,20,20,0,'2190-07-03 07:01:00','2190-07-03 07:01:00','2189-07-03 07:01:00','test.jpg',1,'self','2023-03-22 18:14:34','Snapshot before update. Product Stcok detail will have new  addition info','2023-03-22 12:44:34'),(46,46,1,1,1,1,'PVC4','PVN 4',250,225,25,25,0,'2190-07-03 12:47:00','2190-07-03 12:47:00','2189-07-03 12:47:00','test.jpg',1,'self','2023-03-22 18:18:41',NULL,NULL),(47,47,1,1,1,1,'PVC7','PVN7',25,20,10,10,0,'2190-07-03 13:22:00','2190-07-03 13:22:00','2189-07-03 13:22:00','test.jpg',1,'self','2023-03-22 18:52:38',NULL,NULL),(48,48,1,1,1,1,'PVC8','PVN8',25,25,10,10,0,'2190-07-03 13:24:00','2190-07-03 13:24:00','2189-07-03 13:24:00','test.jpg',1,'self','2023-03-22 18:55:09',NULL,NULL),(49,49,1,1,1,1,'PVC10','PVN10',20,20,20,20,0,'2190-07-03 14:02:00','2190-07-03 14:02:00','2189-07-03 14:02:00','test.jpg',1,'self','2023-03-22 19:32:19',NULL,NULL),(50,50,1,1,1,1,'PVC11','PVN11',25,25,10,10,0,'2190-07-03 14:05:00','2190-07-03 14:05:00','2189-07-03 14:05:00','test.jpg',1,'self','2023-03-22 19:35:51',NULL,NULL),(51,51,1,1,1,1,'PVC0101','PVN0101',80,75,25,25,1,'2197-07-03 06:34:00','2191-07-03 06:34:00','2189-07-03 06:34:00','test.jpg',1,'self','2023-03-29 12:05:11',NULL,NULL),(52,52,1,1,1,2,'PVC0101','PVN0101',80,75,25,25,1,'2197-07-03 01:04:00','2191-07-03 01:04:00','2189-07-03 01:04:00','test.jpg',1,'self','2023-03-29 13:05:07','Snapshot before update. Product Stcok detail will have new  addition info','2023-03-29 07:35:07'),(53,53,1,1,1,2,'PVC0101','PVN0101',80,75,25,25,1,'2197-07-02 19:34:00','2191-07-02 19:34:00','2189-07-02 19:34:00','test.jpg',1,'self','2023-03-29 15:45:59','Snapshot before update. Product Stcok detail will have new  addition info','2023-03-29 10:15:59'),(54,54,1,1,1,1,'PVC001','PVN-1',50,45,20,20,0,'2190-07-03 01:31:00','2190-07-03 01:31:00','2189-07-03 01:31:00','test.jpg',1,'self','2023-03-29 15:46:23','Snapshot before update. Product Stcok detail will have new  addition info','2023-03-29 10:16:23'),(55,55,1,1,1,1,'PVC001','PVN-1',25,22,20,20,0,'2190-07-03 07:01:00','2190-07-03 07:01:00','2189-07-03 07:01:00','test.jpg',1,'self','2023-03-29 15:46:34','Snapshot before update. Product Stcok detail will have new  addition info','2023-03-29 10:16:34'),(56,56,1,1,1,1,'PVC0002','PVN-2',25,25,20,20,0,'2190-07-03 07:03:00','2190-07-03 07:03:00','2189-07-03 07:03:00','test.jpg',1,'self','2023-03-29 15:46:43','Snapshot before update. Product Stcok detail will have new  addition info','2023-03-29 10:16:43'),(57,57,1,1,1,2,'PVC001','PVN-1',25,20,20,20,0,'2190-07-03 07:01:00','2190-07-03 07:01:00','2189-07-03 07:01:00','test.jpg',1,'self','2023-03-29 15:46:56','Snapshot before update. Product Stcok detail will have new  addition info','2023-03-29 10:16:56'),(58,58,6,1,1,1,'PVC4','PVN 4',250,225,25,25,0,'2190-07-03 07:17:00','2190-07-03 07:17:00','2189-07-03 07:17:00','test.jpg',1,'self','2023-03-29 15:47:42','Snapshot before update. Product Stcok detail will have new  addition info','2023-03-29 10:17:42'),(59,59,1,1,1,1,'PVC001','PVN-1',50,45,20,20,0,'2190-07-02 20:01:00','2190-07-02 20:01:00','2189-07-02 20:01:00','test.jpg',1,'self','2023-03-29 16:02:58','Snapshot before update. Product Stcok detail will have new  addition info','2023-03-29 10:32:58'),(60,60,1,1,1,1,'PVC001','PVN-1',50,45,25,25,0,'2190-07-02 14:31:00','2190-07-02 14:31:00','2189-07-02 14:31:00','test.jpg',1,'self','2023-03-29 16:46:47','Snapshot before update. Product Stcok detail will have new  addition info','2023-03-29 11:16:47'),(61,61,1,1,1,1,'PVC2011','PVN2011',50,40,25,45,1,'2197-07-03 11:17:00','2197-07-03 11:17:00','2196-07-03 11:17:00','test.jpg',1,'self','2023-03-29 16:47:44',NULL,NULL),(62,62,1,1,1,1,'PVC0020','PVN0021',200,190,25,25,1,'2197-07-03 16:48:00','2197-07-03 16:48:00','2196-07-03 16:48:00','test.jpg',1,'self','2023-03-29 22:18:39',NULL,NULL);
/*!40000 ALTER TABLE `productstockdetail` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `productstockdetail1`
--

DROP TABLE IF EXISTS `productstockdetail1`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `productstockdetail1` (
  `id` int NOT NULL AUTO_INCREMENT,
  `productdetailid` int NOT NULL,
  `cartcost` double NOT NULL,
  `costtocomapny` double NOT NULL,
  `quantity` int NOT NULL,
  `availablequantity` int NOT NULL,
  `createdby` varchar(50) NOT NULL,
  `createddate` datetime NOT NULL,
  `lastmodifiedby` varchar(45) DEFAULT NULL,
  `lastmodifeddate` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `productstockdetail1`
--

LOCK TABLES `productstockdetail1` WRITE;
/*!40000 ALTER TABLE `productstockdetail1` DISABLE KEYS */;
/*!40000 ALTER TABLE `productstockdetail1` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `roles`
--

DROP TABLE IF EXISTS `roles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `roles` (
  `id` int NOT NULL AUTO_INCREMENT,
  `rolename` varchar(45) NOT NULL,
  `flag` tinyint NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `roles`
--

LOCK TABLES `roles` WRITE;
/*!40000 ALTER TABLE `roles` DISABLE KEYS */;
INSERT INTO `roles` VALUES (3,'Manager',1),(4,'Admin',1),(5,'Accounts',1);
/*!40000 ALTER TABLE `roles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `unit`
--

DROP TABLE IF EXISTS `unit`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `unit` (
  `id` int NOT NULL AUTO_INCREMENT,
  `unitcode` varchar(45) NOT NULL,
  `unitname` varchar(100) NOT NULL,
  `flag` tinyint NOT NULL DEFAULT '1',
  `createdby` varchar(50) NOT NULL,
  `createddate` datetime NOT NULL,
  `lastmodifiedby` varchar(50) DEFAULT NULL,
  `lastmodifieddate` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `unit`
--

LOCK TABLES `unit` WRITE;
/*!40000 ALTER TABLE `unit` DISABLE KEYS */;
INSERT INTO `unit` VALUES (1,'U001','KG',1,'self','2023-03-17 00:00:00',NULL,NULL),(2,'U003','Liter',1,'self','2023-03-17 00:00:00',NULL,NULL);
/*!40000 ALTER TABLE `unit` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `unitdetail`
--

DROP TABLE IF EXISTS `unitdetail`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `unitdetail` (
  `id` int NOT NULL AUTO_INCREMENT,
  `unitid` int NOT NULL,
  `unitDescription` varchar(100) NOT NULL,
  `unitvalue` int NOT NULL,
  `createdby` varchar(50) NOT NULL,
  `createddate` datetime NOT NULL,
  `lastmodifiedby` varchar(50) DEFAULT NULL,
  `lastmodifieddate` datetime DEFAULT NULL,
  `flag` tinyint DEFAULT '1',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `unitdetail`
--

LOCK TABLES `unitdetail` WRITE;
/*!40000 ALTER TABLE `unitdetail` DISABLE KEYS */;
INSERT INTO `unitdetail` VALUES (1,1,'1 KG',1,'self','2023-03-17 00:00:00',NULL,NULL,1),(2,1,'5 KG',5,'self','2023-03-17 00:00:00',NULL,NULL,1),(3,2,'1 Liter',1,'self','2023-03-17 00:00:00',NULL,NULL,1),(4,2,'2 Liter',2,'self','2023-03-17 00:00:00',NULL,NULL,1);
/*!40000 ALTER TABLE `unitdetail` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user` (
  `id` int NOT NULL AUTO_INCREMENT,
  `mobile` varchar(15) NOT NULL,
  `name` varchar(100) NOT NULL,
  `dob` datetime NOT NULL,
  `email` varchar(50) DEFAULT NULL,
  `createdby` varchar(45) DEFAULT NULL,
  `createddate` datetime DEFAULT NULL,
  `lastmodifiedby` varchar(45) DEFAULT NULL,
  `lastmodifieddate` datetime DEFAULT NULL,
  `flag` tinyint DEFAULT '1',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user`
--

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` VALUES (1,'9483941729-1','Suresh','2023-03-25 02:20:23','vendor@gmail.com','self','2023-03-25 07:50:23',NULL,NULL,1),(2,'9483941729-2','user1','2023-03-25 02:20:48','','self','2023-03-25 07:51:38',NULL,NULL,1),(6,'9483941729','User1','2023-03-16 00:00:00','test@te.com','self','2023-03-25 15:47:35',NULL,NULL,1);
/*!40000 ALTER TABLE `user` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `userrefreshtokens`
--

DROP TABLE IF EXISTS `userrefreshtokens`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `userrefreshtokens` (
  `id` int NOT NULL AUTO_INCREMENT,
  `UserName` varchar(100) NOT NULL,
  `refreshtoken` text NOT NULL,
  `flag` tinyint NOT NULL DEFAULT '1',
  `createdby` varchar(45) NOT NULL,
  `createddate` datetime NOT NULL,
  `lastmodifiedby` varchar(45) DEFAULT NULL,
  `lastmodifieddate` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=54 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `userrefreshtokens`
--

LOCK TABLES `userrefreshtokens` WRITE;
/*!40000 ALTER TABLE `userrefreshtokens` DISABLE KEYS */;
INSERT INTO `userrefreshtokens` VALUES (1,'6','Q2odWcgvd46MZY4yXGrmLuyVybPe4d/9Ral40MzZEvM=',0,'self','2023-03-27 16:24:37',NULL,NULL),(2,'6','p+jYxWDpxtnaqjPtT599mj4XRYtV2NmX19kEjyIIvKw=',0,'self','2023-03-27 16:33:08',NULL,NULL),(3,'6','reWxLFUzCSDkv4LEVT4zgWgCmPT2BlVW6uzerZnOrVo=',0,'self','2023-03-27 16:34:50',NULL,NULL),(4,'6','38w+uKcynAPgtvk+cGchQL7uQmmBNjGX9jDb78UDxY0=',0,'self','2023-03-27 16:37:55',NULL,NULL),(5,'6','z/m5tdT8luA9R94QdhO4+tNSOAzN22PdfP8XaaitoQs=',0,'self','2023-03-27 16:40:42',NULL,NULL),(6,'6','dkjyvWcpdYEDcsfrYYEraB9F6eGR5krjujyNI1GFCQQ=',0,'self','2023-03-27 16:58:19',NULL,NULL),(7,'6','Mnizck+9+crPzR65Dl2g6Q82F7ve8q38mD+leUw/wqw=',0,'self','2023-03-27 17:10:59',NULL,NULL),(8,'6','wfV+anh2OvJuUcUIe2NfQ7gkteU/31clUDiOtuKLGv0=',0,'self','2023-03-27 17:11:37',NULL,NULL),(9,'6','9wiJXEfDeYo+SsReO3p5hRF2QptW3DNF4OyHf0wagAU=',0,'self','2023-03-27 17:16:56',NULL,NULL),(12,'6','t1BpMnB13IENMiv8jY7MMmHt0sfZeAjEzIjNhD1/5cQ=',0,'self','2023-03-27 22:21:38',NULL,NULL),(14,'6','s54YyrKCujXd0sURQxL7Gl+n1boLvkRIj+LJVd8Wzeo=',0,'self','2023-03-28 19:34:07',NULL,NULL),(15,'6','sAS21DSbWXWlOPJFIuPyFHr2bvOPOkCeOAMQqfi9BmA=',0,'self','2023-03-28 19:41:33',NULL,NULL),(16,'6','3ALMeD2++xNfSDMU+C9uC0Ys5qcVarRtM12na582hz8=',0,'self','2023-03-28 19:44:00',NULL,NULL),(17,'6','CtL0vZXBtcOVR5FLrEzttrCvy8TFb5b3TKDOrHkGRTY=',0,'self','2023-03-28 19:54:18',NULL,NULL),(18,'6','s3A9pf3tntD6m1vGCE8X8TgDOGkMRB04THA+FFHVqrI=',0,'self','2023-03-28 20:15:23',NULL,NULL),(19,'6','iJo5L7ZsVujIdw+UyOIVb2cHlxDuYqNTy5O4g7LVaH0=',0,'self','2023-03-28 22:12:01',NULL,NULL),(20,'6','pPRM3gPuQf7qoixJrpq9RMvsg30x9XU6LRaFCeEjZJo=',0,'self','2023-03-28 22:39:12',NULL,NULL),(21,'6','RqPcKXqjlo0jVR6RjhS7zT9Qd+tlboRSZtFOFUebKiE=',0,'self','2023-03-29 07:31:07',NULL,NULL),(22,'6','HMKnJvpA86oR9gklvANFQOOv728PsKyNq6fIMcpUZRs=',0,'self','2023-03-29 09:49:10',NULL,NULL),(23,'6','DrlT9nuNJGDXOpdE8n1CG2SiG8LMjpLHrfTr4fz+yu0=',0,'self','2023-03-29 09:59:29',NULL,NULL),(24,'6','t37NrEZMDdVAYW0Ntka7lQ5j4Gje1npX1gTn3bqsY9c=',0,'self','2023-03-29 10:21:23',NULL,NULL),(25,'6','rxF3LcTR7kn3MFaR0tDRHpesteSXJngthVzD/zEZFxA=',0,'self','2023-03-29 19:10:44',NULL,NULL),(26,'6','Rc3CD7IXxG2XoGRvUVP0vn8dodiK5AaY4AtzORp6AkU=',0,'self','2023-03-29 22:17:24',NULL,NULL),(34,'6','B2gHl+UTkOq828pNMNVuzC26F9ab57R3TDoPoZb6Q9Y=',0,'self','2023-03-31 11:36:58',NULL,NULL),(44,'6','XRCnx4lNcFaAajDW7Lhi30UByMCEJGlC+TTFP0epGhY=',0,'self','2023-03-31 13:28:01',NULL,NULL),(47,'6','Q16dR/l0idKgPsE0w5K0KA4i0+rQPhas4UV8NoxWDqE=',0,'self','2023-03-31 13:40:16',NULL,NULL),(49,'6','2Y6UnnM+P24D1m1Z9X8kwmUwBAi+/g9t6cXFfvNSYks=',0,'self','2023-03-31 21:03:00',NULL,NULL),(50,'6','N/ieK8aV8600u1/+vz7bHGy4P3AAle4ZFdu2I6vHIV0=',0,'self','2023-03-31 21:13:10',NULL,NULL),(51,'6','8PEcAdsCrEm41mmCqUhjDSGlXx130u/V4CAFA+H5oa4=',0,'self','2023-03-31 21:25:59',NULL,NULL),(52,'6','a6DVlOFNWQ8ZRLC3LG1c8A6kv9zGJXEw6WvM/Wnrr4g=',0,'self','2023-03-31 21:29:13',NULL,NULL),(53,'6','GjC/mWc4Br3iKN+t/gMrj4dkGim0khuqzsp3K7KqQ+k=',0,'self','2023-03-31 21:36:00',NULL,NULL);
/*!40000 ALTER TABLE `userrefreshtokens` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `userroles`
--

DROP TABLE IF EXISTS `userroles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `userroles` (
  `id` int NOT NULL AUTO_INCREMENT,
  `userid` int NOT NULL,
  `roleid` int NOT NULL,
  `createdby` varchar(45) NOT NULL,
  `createddate` datetime NOT NULL,
  `lastmodifiedby` varchar(45) DEFAULT NULL,
  `lastmodifieddate` datetime DEFAULT NULL,
  `flag` tinyint NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `userroles`
--

LOCK TABLES `userroles` WRITE;
/*!40000 ALTER TABLE `userroles` DISABLE KEYS */;
INSERT INTO `userroles` VALUES (1,6,4,'self','2023-03-03 00:00:00',NULL,NULL,1);
/*!40000 ALTER TABLE `userroles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `vendor`
--

DROP TABLE IF EXISTS `vendor`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `vendor` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(100) NOT NULL,
  `address` varchar(500) NOT NULL,
  `email` varchar(45) NOT NULL,
  `mobile` varchar(15) NOT NULL,
  `flag` tinyint DEFAULT '1',
  `createdby` varchar(50) NOT NULL,
  `createddate` datetime NOT NULL,
  `lastmodifiedby` varchar(50) DEFAULT NULL,
  `lastmodifieddate` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `vendor`
--

LOCK TABLES `vendor` WRITE;
/*!40000 ALTER TABLE `vendor` DISABLE KEYS */;
INSERT INTO `vendor` VALUES (1,'Vendor 1','Vendor -BasavanaGudi','vendor@gmail.com','+919988776654',1,'self','2023-03-11 14:42:36',NULL,NULL),(2,'jay','blr,blr,blr','jay@gmail.com','+919988776652',1,'self','2023-03-11 15:09:20',NULL,NULL),(3,'Vendor - 3','Vendor Address','jay@gmail.com','+919988776655',1,'self','2023-03-11 17:47:47',NULL,NULL),(4,'Vendor -4','Vendor Address','jay@gmail.com','+919988776655',1,'self','2023-03-11 20:40:51',NULL,NULL),(5,'Vendor - 6','Vendor Address - 6','jay@gmail.com','9988776655',1,'self','2023-03-11 20:45:13',NULL,NULL);
/*!40000 ALTER TABLE `vendor` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `vendorproducts`
--

DROP TABLE IF EXISTS `vendorproducts`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `vendorproducts` (
  `id` int NOT NULL AUTO_INCREMENT,
  `vendorid` int NOT NULL,
  `productid` int NOT NULL,
  `categoryid` int DEFAULT NULL,
  `createdby` varchar(50) NOT NULL,
  `createddate` datetime NOT NULL,
  `lastmodifiedby` varchar(50) DEFAULT NULL,
  `lastmodifieddate` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `vendorproducts`
--

LOCK TABLES `vendorproducts` WRITE;
/*!40000 ALTER TABLE `vendorproducts` DISABLE KEYS */;
INSERT INTO `vendorproducts` VALUES (8,1,1,1,'self','2023-03-13 15:48:02',NULL,NULL),(9,1,3,1,'self','2023-03-13 15:48:02',NULL,NULL),(10,1,5,1,'self','2023-03-13 15:48:02',NULL,NULL);
/*!40000 ALTER TABLE `vendorproducts` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-04-02 21:02:43
