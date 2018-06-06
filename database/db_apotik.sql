/*
SQLyog Ultimate v12.4.1 (64 bit)
MySQL - 10.1.13-MariaDB : Database - apotik
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`apotik` /*!40100 DEFAULT CHARACTER SET latin1 */;

USE `apotik`;

/*Table structure for table `det_pembelian` */

DROP TABLE IF EXISTS `det_pembelian`;

CREATE TABLE `det_pembelian` (
  `kd_trx` varchar(20) DEFAULT NULL,
  `resep` char(1) DEFAULT NULL,
  `nama_dokter` varchar(30) DEFAULT NULL,
  `kd_obat` varchar(10) DEFAULT NULL,
  `qty` int(11) DEFAULT NULL,
  `subtotal` int(11) DEFAULT NULL,
  KEY `fk_kd_trx` (`kd_trx`),
  KEY `fk_kd_obat` (`kd_obat`),
  CONSTRAINT `fk_kd_obat` FOREIGN KEY (`kd_obat`) REFERENCES `obat` (`kd_obat`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_kd_trx` FOREIGN KEY (`kd_trx`) REFERENCES `pembelian` (`kd_trx`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `det_pembelian` */

/*Table structure for table `login` */

DROP TABLE IF EXISTS `login`;

CREATE TABLE `login` (
  `user` varchar(50) DEFAULT NULL,
  `pass` varchar(50) DEFAULT NULL,
  `nama` varchar(25) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `login` */

insert  into `login`(`user`,`pass`,`nama`) values 
('admin','admin','Arivatun Hidayah');

/*Table structure for table `obat` */

DROP TABLE IF EXISTS `obat`;

CREATE TABLE `obat` (
  `kd_obat` varchar(10) NOT NULL,
  `nama_obat` varchar(50) DEFAULT NULL,
  `j_obat` varchar(20) DEFAULT NULL,
  `harga` int(11) DEFAULT NULL,
  `stok` int(11) DEFAULT NULL,
  PRIMARY KEY (`kd_obat`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `obat` */

insert  into `obat`(`kd_obat`,`nama_obat`,`j_obat`,`harga`,`stok`) values 
('OBAT-0001','Cap Kaki Tiga','Larutan',10000,30);

/*Table structure for table `pelanggan` */

DROP TABLE IF EXISTS `pelanggan`;

CREATE TABLE `pelanggan` (
  `id_pembeli` varchar(25) NOT NULL,
  `nama` varchar(50) DEFAULT NULL,
  `alamat` varchar(200) DEFAULT NULL,
  `kota` varchar(30) DEFAULT NULL,
  `no_hp` varchar(15) DEFAULT NULL,
  PRIMARY KEY (`id_pembeli`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `pelanggan` */

insert  into `pelanggan`(`id_pembeli`,`nama`,`alamat`,`kota`,`no_hp`) values 
('1','Apotik Anugrah Sejahtera','Jl. Pramuka No.8','Yogyakarta','027400010');

/*Table structure for table `pembelian` */

DROP TABLE IF EXISTS `pembelian`;

CREATE TABLE `pembelian` (
  `kd_trx` varchar(30) NOT NULL,
  `id_pembeli` varchar(25) DEFAULT NULL,
  `tgl_trx` date DEFAULT NULL,
  `total` int(11) DEFAULT NULL,
  `bayar` int(11) DEFAULT NULL,
  `kembali` int(11) DEFAULT NULL,
  PRIMARY KEY (`kd_trx`),
  KEY `fk_id` (`id_pembeli`),
  CONSTRAINT `fk_id` FOREIGN KEY (`id_pembeli`) REFERENCES `pelanggan` (`id_pembeli`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `pembelian` */

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
