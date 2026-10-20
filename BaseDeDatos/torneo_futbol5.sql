-- MariaDB dump 10.19  Distrib 10.4.32-MariaDB, for Win64 (AMD64)
--
-- Host: localhost    Database: torneo_futbol5
-- ------------------------------------------------------
-- Server version	10.4.32-MariaDB

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Current Database: `torneo_futbol5`
--

CREATE DATABASE /*!32312 IF NOT EXISTS*/ `torneo_futbol5` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci */;

USE `torneo_futbol5`;

--
-- Table structure for table `categorias`
--

DROP TABLE IF EXISTS `categorias`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `categorias` (
  `id_categoria` int(11) NOT NULL AUTO_INCREMENT,
  `nombre_categoria` varchar(50) NOT NULL,
  `edad_min` int(11) NOT NULL,
  `edad_max` int(11) NOT NULL,
  `sexo` enum('M','F') DEFAULT NULL,
  PRIMARY KEY (`id_categoria`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `categorias`
--

LOCK TABLES `categorias` WRITE;
/*!40000 ALTER TABLE `categorias` DISABLE KEYS */;
INSERT INTO `categorias` VALUES (1,'Femenino A',18,30,'F'),(2,'Femenino B',31,45,'F'),(3,'Femenino Senior',46,60,'F'),(4,'Masculino A',18,30,'M'),(5,'Masculino B',31,45,'M'),(6,'Masculino Senior',46,60,'M');
/*!40000 ALTER TABLE `categorias` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `inscripciones`
--

DROP TABLE IF EXISTS `inscripciones`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `inscripciones` (
  `num_inscripcion` int(11) NOT NULL AUTO_INCREMENT,
  `fecha_insc` date NOT NULL,
  `abono_inscrip` tinyint(1) DEFAULT 0,
  `categoria` int(11) NOT NULL,
  `participante` int(11) NOT NULL,
  PRIMARY KEY (`num_inscripcion`),
  KEY `categoria` (`categoria`),
  KEY `participante` (`participante`),
  CONSTRAINT `inscripciones_ibfk_1` FOREIGN KEY (`categoria`) REFERENCES `categorias` (`id_categoria`),
  CONSTRAINT `inscripciones_ibfk_2` FOREIGN KEY (`participante`) REFERENCES `participantes` (`id_participante`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `inscripciones`
--

LOCK TABLES `inscripciones` WRITE;
/*!40000 ALTER TABLE `inscripciones` DISABLE KEYS */;
INSERT INTO `inscripciones` VALUES (1,'2026-09-20',1,4,1),(2,'2026-09-20',1,6,2),(3,'2026-09-20',1,5,3),(4,'2026-09-20',0,5,4),(5,'2026-09-21',1,4,5),(6,'2026-09-21',0,4,6),(7,'2026-09-21',1,6,7),(8,'2026-09-21',1,4,8),(9,'2026-09-21',1,2,9),(10,'2026-09-21',0,1,10),(11,'2026-09-21',1,1,11),(12,'2026-09-21',1,3,12),(13,'2026-09-22',0,3,13),(14,'2026-09-22',0,5,14),(15,'2026-09-22',1,1,15);
/*!40000 ALTER TABLE `inscripciones` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `participantes`
--

DROP TABLE IF EXISTS `participantes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `participantes` (
  `id_participante` int(11) NOT NULL AUTO_INCREMENT,
  `apellido_part` varchar(50) NOT NULL,
  `nombre_part` varchar(50) NOT NULL,
  `dni` varchar(15) DEFAULT NULL,
  `direccion` varchar(75) NOT NULL,
  `edad` int(11) NOT NULL,
  `telefono` varchar(15) DEFAULT NULL,
  `sexo` enum('M','F') DEFAULT NULL,
  PRIMARY KEY (`id_participante`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `participantes`
--

LOCK TABLES `participantes` WRITE;
/*!40000 ALTER TABLE `participantes` DISABLE KEYS */;
INSERT INTO `participantes` VALUES (1,'Gonzalez','Mateo','45123789','Av. Rivadavia 1250',22,'1123456781','M'),(2,'Rodriguez','Lucas','43987654','Belgrano 540',52,'1123456782','M'),(3,'Fernandez','Tomas','46234567','San Martin 830',35,'1123456783','M'),(4,'Lopez','Santiago','42876543','Mitre 210',36,'1123456784','M'),(5,'Martinez','Nicolas','44765432','Sarmiento 670',23,'1123456785','M'),(6,'Perez','Benjamin','47123456','Moreno 1450',19,'1123456786','M'),(7,'Sanchez','Franco','43567891','Lavalle 320',52,'1123456787','M'),(8,'Romero','Joaquin','45891234','Alsina 780',21,'1123456788','M'),(9,'Diaz','Camila','44234567','Roca 960',35,'1123456789','F'),(10,'Torres','Valentina','46987612','Belgrano 115',20,'1123456790','F'),(11,'Acosta','Sofia','43123456','Italia 430',25,'1123456791','F'),(12,'Ruiz','Martina','45567890','Urquiza 720',58,'1123456792','F'),(13,'Alvarez','Lucia','47654321','San Juan 380',51,'1123456793','F'),(14,'Castro','Bruno','44891234','España 560',44,'1123456794','M'),(15,'Silva','Florencia','43765432','Independencia 990',24,'1123456795','F');
/*!40000 ALTER TABLE `participantes` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed
