-- phpMyAdmin SQL Dump
-- version 4.7.7
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Waktu pembuatan: 16 Feb 2019 pada 11.44
-- Versi server: 10.1.30-MariaDB
-- Versi PHP: 7.2.2

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `unbk`
--

-- --------------------------------------------------------

--
-- Struktur dari tabel `guru`
--

CREATE TABLE `guru` (
  `idGuru` int(11) NOT NULL,
  `nip` varchar(18) NOT NULL,
  `nama` text NOT NULL,
  `password` text NOT NULL,
  `namaMapel` text NOT NULL,
  `kodeMapel` varchar(8) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `guru`
--

INSERT INTO `guru` (`idGuru`, `nip`, `nama`, `password`, `namaMapel`, `kodeMapel`) VALUES
(1, '123456789012345678', 'Danar Hikmah', 'akuanaksehat', 'Bahasa Indonesia', 'INDO0001'),
(2, '123', 'Admin', '123', 'Mapel Admin', '666'),
(3, '181818181818181818', 'Nama Baru', 'passwordbaru', 'Matematika', 'MTK12018');

-- --------------------------------------------------------

--
-- Struktur dari tabel `nilai`
--

CREATE TABLE `nilai` (
  `idNilai` int(11) NOT NULL,
  `nis` varchar(8) NOT NULL,
  `kodeUjian` varchar(8) NOT NULL,
  `nilai` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `nilai`
--

INSERT INTO `nilai` (`idNilai`, `nis`, `kodeUjian`, `nilai`) VALUES
(1, '11', 'SOAL21', 80),
(2, '10101010', 'SOAL21', 40),
(3, '11', 'SOAL21', 30),
(4, '11', 'SOAL21', 0);

-- --------------------------------------------------------

--
-- Struktur dari tabel `siswa`
--

CREATE TABLE `siswa` (
  `idSiswa` int(11) NOT NULL,
  `nis` varchar(8) NOT NULL,
  `namaSiswa` text NOT NULL,
  `password` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `siswa`
--

INSERT INTO `siswa` (`idSiswa`, `nis`, `namaSiswa`, `password`) VALUES
(1, '12345678', 'Abdul Ghoniy', 'akuanaksehat'),
(2, '11', 'Abdul2', '11');

-- --------------------------------------------------------

--
-- Struktur dari tabel `soal`
--

CREATE TABLE `soal` (
  `idSoal` int(11) NOT NULL,
  `soal` text NOT NULL,
  `pilihanA` text NOT NULL,
  `pilihanB` text NOT NULL,
  `pilihanC` text NOT NULL,
  `pilihanD` text NOT NULL,
  `jawaban` text NOT NULL,
  `kodeUjian` varchar(8) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `soal`
--

INSERT INTO `soal` (`idSoal`, `soal`, `pilihanA`, `pilihanB`, `pilihanC`, `pilihanD`, `jawaban`, `kodeUjian`) VALUES
(10, 'ini budi?', 'asd', 'kok tau?', 'diganti', 'apa hak anda menanyakan itu?', 'apa hak anda menanyakan itu?', '123'),
(18, 'ini budi?', 'bukan', 'kok tau?', 'diganti', 'apa hak anda menanyakan itu?', 'apa hak anda menanyakan itu?', '123'),
(19, 'kak main yuk?', 'ayuk', 'Disini saya akan menyanyikan Abdullah', 'aas', 'apa hak anda menanyakan itu?', 'apa hak anda menanyakan itu?', '123'),
(20, 'apa?', 'A', 'B', 'C', 'D', 'gaada', '1'),
(21, 'Candi Borobudur terdapat di pulau ...', 'Jawa', 'Sumatera', 'Kalimantan', 'Bali', 'Jawa', 'SOAL21'),
(22, 'Kitab karangan Mpu Prapancan yang didalamnya termuat istilah Pancasila adalah kitab ...', 'Sutasoma', 'Negarakertagama', 'Pararaton', 'Jayabaya', 'Negarakertagama', 'SOAL21'),
(23, 'Cerita tentang Sangkuriang dan Dayang Sumbi adalah cerita yang mengisahkan legenda ...', 'Danau Toba', 'Gunung Tangkuban Perahu', 'Rawa Pening', 'Bengawan Solo', 'Gunung Tangkuban Perahu', 'SOAL21'),
(24, 'Monumen Nasional, Tugu Proklamasi, dan Monumen Pancasila Sakti terdapat di kota ...', 'Bekasi', 'Semarang', 'Surabaya', 'Jakarta', 'Jakarta', 'SOAL21'),
(25, 'Candi Borobudur dan Candi Mendut dibangun pada masa Dinasti ...', 'Sanjaya', 'Ajisaka', 'Syailendra', 'Gajah Mada', 'Syailendra', 'SOAL21'),
(26, 'Candi Muara Takus terdapat di ...', 'Jawa Tengah', 'Riau', 'Bengkulu', 'Bengkulu', 'Riau', 'SOAL21'),
(27, 'Raja Yogyakarta yang mempunyai peran besar dalam perjuangan mempertahankan Indonesia, yaitu ...', 'Sri Sultan HB XI', 'Sri Sultan HB VIII', 'Sri Sultan HB VII', 'Sri Sultan HB IX', 'Sri Sultan HB IX', 'SOAL21'),
(28, 'Pihak sekutu yang ada dalam perang Pasifik dipimpin oleh ...', 'Portugis', 'Belanda', 'Amerika Serikat', 'Inggris', 'Amerika Serikat', 'SOAL21'),
(29, 'K.H. Ahmad Dahlan merupakan pendiri organisasi ...', 'Partai Nasional Indonesia', 'Muhammadiyah', 'Nahdatul Ulama', 'Sarikat Dagang Islam', 'Muhammadiyah', 'SOAL21'),
(30, 'Gubernur Jendral Belanda yang membuat kebijakan sistem Kerja Paksa yaitu ...', 'Jansen', 'Van Der Cepellen', 'Daendels', 'Van de Bosh', 'Daendels', 'SOAL21');

-- --------------------------------------------------------

--
-- Struktur dari tabel `ujian`
--

CREATE TABLE `ujian` (
  `idUjian` int(11) NOT NULL,
  `kodeUjian` varchar(8) NOT NULL,
  `kodeMapel` varchar(8) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `ujian`
--

INSERT INTO `ujian` (`idUjian`, `kodeUjian`, `kodeMapel`) VALUES
(1, '123', '666'),
(3, '1234', '666'),
(5, '122', '666'),
(6, '12345', '666'),
(8, '123456', '666'),
(9, '1', '666'),
(10, 'SOAL21', '666'),
(11, 'soalbaru', '666');

--
-- Indexes for dumped tables
--

--
-- Indeks untuk tabel `guru`
--
ALTER TABLE `guru`
  ADD PRIMARY KEY (`idGuru`),
  ADD UNIQUE KEY `nip` (`nip`);

--
-- Indeks untuk tabel `nilai`
--
ALTER TABLE `nilai`
  ADD PRIMARY KEY (`idNilai`);

--
-- Indeks untuk tabel `siswa`
--
ALTER TABLE `siswa`
  ADD PRIMARY KEY (`idSiswa`),
  ADD UNIQUE KEY `nis` (`nis`);

--
-- Indeks untuk tabel `soal`
--
ALTER TABLE `soal`
  ADD PRIMARY KEY (`idSoal`);

--
-- Indeks untuk tabel `ujian`
--
ALTER TABLE `ujian`
  ADD PRIMARY KEY (`idUjian`),
  ADD UNIQUE KEY `kodeUjian` (`kodeUjian`);

--
-- AUTO_INCREMENT untuk tabel yang dibuang
--

--
-- AUTO_INCREMENT untuk tabel `guru`
--
ALTER TABLE `guru`
  MODIFY `idGuru` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT untuk tabel `nilai`
--
ALTER TABLE `nilai`
  MODIFY `idNilai` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT untuk tabel `siswa`
--
ALTER TABLE `siswa`
  MODIFY `idSiswa` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT untuk tabel `soal`
--
ALTER TABLE `soal`
  MODIFY `idSoal` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=31;

--
-- AUTO_INCREMENT untuk tabel `ujian`
--
ALTER TABLE `ujian`
  MODIFY `idUjian` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
