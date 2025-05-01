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
) ENGINE=InnoDB AUTO_INCREMENT=49 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `userrefreshtokens`
--

LOCK TABLES `userrefreshtokens` WRITE;
/*!40000 ALTER TABLE `userrefreshtokens` DISABLE KEYS */;
INSERT INTO `userrefreshtokens` VALUES (1,'6','Q2odWcgvd46MZY4yXGrmLuyVybPe4d/9Ral40MzZEvM=',0,'self','2023-03-27 16:24:37',NULL,NULL),(2,'6','p+jYxWDpxtnaqjPtT599mj4XRYtV2NmX19kEjyIIvKw=',0,'self','2023-03-27 16:33:08',NULL,NULL),(3,'6','reWxLFUzCSDkv4LEVT4zgWgCmPT2BlVW6uzerZnOrVo=',0,'self','2023-03-27 16:34:50',NULL,NULL),(4,'6','38w+uKcynAPgtvk+cGchQL7uQmmBNjGX9jDb78UDxY0=',0,'self','2023-03-27 16:37:55',NULL,NULL),(5,'6','z/m5tdT8luA9R94QdhO4+tNSOAzN22PdfP8XaaitoQs=',0,'self','2023-03-27 16:40:42',NULL,NULL),(6,'6','dkjyvWcpdYEDcsfrYYEraB9F6eGR5krjujyNI1GFCQQ=',0,'self','2023-03-27 16:58:19',NULL,NULL),(7,'6','Mnizck+9+crPzR65Dl2g6Q82F7ve8q38mD+leUw/wqw=',0,'self','2023-03-27 17:10:59',NULL,NULL),(8,'6','wfV+anh2OvJuUcUIe2NfQ7gkteU/31clUDiOtuKLGv0=',0,'self','2023-03-27 17:11:37',NULL,NULL),(9,'6','9wiJXEfDeYo+SsReO3p5hRF2QptW3DNF4OyHf0wagAU=',0,'self','2023-03-27 17:16:56',NULL,NULL),(12,'6','t1BpMnB13IENMiv8jY7MMmHt0sfZeAjEzIjNhD1/5cQ=',0,'self','2023-03-27 22:21:38',NULL,NULL),(14,'6','s54YyrKCujXd0sURQxL7Gl+n1boLvkRIj+LJVd8Wzeo=',0,'self','2023-03-28 19:34:07',NULL,NULL),(15,'6','sAS21DSbWXWlOPJFIuPyFHr2bvOPOkCeOAMQqfi9BmA=',0,'self','2023-03-28 19:41:33',NULL,NULL),(16,'6','3ALMeD2++xNfSDMU+C9uC0Ys5qcVarRtM12na582hz8=',0,'self','2023-03-28 19:44:00',NULL,NULL),(17,'6','CtL0vZXBtcOVR5FLrEzttrCvy8TFb5b3TKDOrHkGRTY=',0,'self','2023-03-28 19:54:18',NULL,NULL),(18,'6','s3A9pf3tntD6m1vGCE8X8TgDOGkMRB04THA+FFHVqrI=',0,'self','2023-03-28 20:15:23',NULL,NULL),(19,'6','iJo5L7ZsVujIdw+UyOIVb2cHlxDuYqNTy5O4g7LVaH0=',0,'self','2023-03-28 22:12:01',NULL,NULL),(20,'6','pPRM3gPuQf7qoixJrpq9RMvsg30x9XU6LRaFCeEjZJo=',0,'self','2023-03-28 22:39:12',NULL,NULL),(21,'6','RqPcKXqjlo0jVR6RjhS7zT9Qd+tlboRSZtFOFUebKiE=',0,'self','2023-03-29 07:31:07',NULL,NULL),(22,'6','HMKnJvpA86oR9gklvANFQOOv728PsKyNq6fIMcpUZRs=',0,'self','2023-03-29 09:49:10',NULL,NULL),(23,'6','DrlT9nuNJGDXOpdE8n1CG2SiG8LMjpLHrfTr4fz+yu0=',0,'self','2023-03-29 09:59:29',NULL,NULL),(24,'6','t37NrEZMDdVAYW0Ntka7lQ5j4Gje1npX1gTn3bqsY9c=',0,'self','2023-03-29 10:21:23',NULL,NULL),(25,'6','rxF3LcTR7kn3MFaR0tDRHpesteSXJngthVzD/zEZFxA=',0,'self','2023-03-29 19:10:44',NULL,NULL),(26,'6','Rc3CD7IXxG2XoGRvUVP0vn8dodiK5AaY4AtzORp6AkU=',0,'self','2023-03-29 22:17:24',NULL,NULL),(34,'6','B2gHl+UTkOq828pNMNVuzC26F9ab57R3TDoPoZb6Q9Y=',0,'self','2023-03-31 11:36:58',NULL,NULL),(44,'6','XRCnx4lNcFaAajDW7Lhi30UByMCEJGlC+TTFP0epGhY=',0,'self','2023-03-31 13:28:01',NULL,NULL),(47,'6','Q16dR/l0idKgPsE0w5K0KA4i0+rQPhas4UV8NoxWDqE=',0,'self','2023-03-31 13:40:16',NULL,NULL);
/*!40000 ALTER TABLE `userrefreshtokens` ENABLE KEYS */;
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
