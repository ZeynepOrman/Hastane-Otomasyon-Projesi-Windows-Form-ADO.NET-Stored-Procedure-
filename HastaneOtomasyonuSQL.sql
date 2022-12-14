USE [master]
GO
/****** Object:  Database [HastaneOtomasyonuSQL]    Script Date: 15.11.2022 21:41:26 ******/
CREATE DATABASE [HastaneOtomasyonuSQL]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HastaneOtomasyonuSQL', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\HastaneOtomasyonuSQL.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'HastaneOtomasyonuSQL_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\HastaneOtomasyonuSQL_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [HastaneOtomasyonuSQL] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HastaneOtomasyonuSQL].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HastaneOtomasyonuSQL] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HastaneOtomasyonuSQL] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HastaneOtomasyonuSQL] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HastaneOtomasyonuSQL] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HastaneOtomasyonuSQL] SET ARITHABORT OFF 
GO
ALTER DATABASE [HastaneOtomasyonuSQL] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [HastaneOtomasyonuSQL] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HastaneOtomasyonuSQL] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HastaneOtomasyonuSQL] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HastaneOtomasyonuSQL] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HastaneOtomasyonuSQL] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HastaneOtomasyonuSQL] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HastaneOtomasyonuSQL] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HastaneOtomasyonuSQL] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HastaneOtomasyonuSQL] SET  DISABLE_BROKER 
GO
ALTER DATABASE [HastaneOtomasyonuSQL] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HastaneOtomasyonuSQL] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HastaneOtomasyonuSQL] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HastaneOtomasyonuSQL] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HastaneOtomasyonuSQL] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HastaneOtomasyonuSQL] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [HastaneOtomasyonuSQL] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HastaneOtomasyonuSQL] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [HastaneOtomasyonuSQL] SET  MULTI_USER 
GO
ALTER DATABASE [HastaneOtomasyonuSQL] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HastaneOtomasyonuSQL] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HastaneOtomasyonuSQL] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HastaneOtomasyonuSQL] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [HastaneOtomasyonuSQL] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [HastaneOtomasyonuSQL] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [HastaneOtomasyonuSQL] SET QUERY_STORE = OFF
GO
USE [HastaneOtomasyonuSQL]
GO
/****** Object:  Table [dbo].[Hastane_Doktorlar]    Script Date: 15.11.2022 21:41:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hastane_Doktorlar](
	[DoktorNo] [int] IDENTITY(1,1) NOT NULL,
	[DoktorAdSoyad] [varchar](50) NULL,
	[DoktorTCNo] [varchar](11) NULL,
	[UzmanlıkAlani] [varchar](50) NULL,
	[Unvani] [varchar](50) NULL,
	[TelefonNumarasi] [varchar](10) NULL,
	[Adres] [varchar](50) NULL,
	[DogumTarihi] [varchar](50) NULL,
	[PoliklinikNo] [int] NULL,
 CONSTRAINT [PK_Hastane_Doktorlar] PRIMARY KEY CLUSTERED 
(
	[DoktorNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hastane_Hastalar]    Script Date: 15.11.2022 21:41:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hastane_Hastalar](
	[HastaNo] [int] IDENTITY(1,1) NOT NULL,
	[HastaAdSoyad] [varchar](50) NULL,
	[HastaTCNo] [varchar](11) NULL,
	[DogumTarihi] [varchar](50) NULL,
	[Kilo] [int] NULL,
	[Boy] [int] NULL,
	[Yas] [int] NULL,
	[Recete] [varchar](50) NULL,
	[RaporDurumu] [varchar](50) NULL,
	[RandevuTarihi] [varchar](50) NULL,
	[DoktorNo] [int] NULL,
 CONSTRAINT [PK_Hastane_Hastalar] PRIMARY KEY CLUSTERED 
(
	[HastaNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hastane_Poliklinikler]    Script Date: 15.11.2022 21:41:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hastane_Poliklinikler](
	[PoliklinikNo] [int] IDENTITY(1,1) NOT NULL,
	[PoliklinikAdi] [varchar](50) NULL,
	[PoliklinikUzmanSayisi] [int] NULL,
	[PoliklinikBasHekimi] [varchar](50) NULL,
	[PoliklinikBasHemsire] [varchar](50) NULL,
	[YatakSayisi] [int] NULL,
 CONSTRAINT [PK_Hastane_Poliklinikler] PRIMARY KEY CLUSTERED 
(
	[PoliklinikNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KullaniciKayit]    Script Date: 15.11.2022 21:41:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KullaniciKayit](
	[KullaniciAdi] [varchar](50) NOT NULL,
	[Sifre] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Telefon] [varchar](50) NULL,
 CONSTRAINT [PK_KullaniciKayit] PRIMARY KEY CLUSTERED 
(
	[KullaniciAdi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Hastane_Doktorlar] ON 

INSERT [dbo].[Hastane_Doktorlar] ([DoktorNo], [DoktorAdSoyad], [DoktorTCNo], [UzmanlıkAlani], [Unvani], [TelefonNumarasi], [Adres], [DogumTarihi], [PoliklinikNo]) VALUES (1, N'Veli Kılı.', N'56712345689', N'İç Hastalıklar', N'Uzman', N'5346788912', N'Maltepe/İstanbul', N'10.12.1990', 1)
INSERT [dbo].[Hastane_Doktorlar] ([DoktorNo], [DoktorAdSoyad], [DoktorTCNo], [UzmanlıkAlani], [Unvani], [TelefonNumarasi], [Adres], [DogumTarihi], [PoliklinikNo]) VALUES (2, N'Hilal Buluş', N'45612356712', N'Dermotoloji', N'Uzman', N'5361234567', N'Esenler/İstanbul', N'16.08.1980', 2)
INSERT [dbo].[Hastane_Doktorlar] ([DoktorNo], [DoktorAdSoyad], [DoktorTCNo], [UzmanlıkAlani], [Unvani], [TelefonNumarasi], [Adres], [DogumTarihi], [PoliklinikNo]) VALUES (3, N'Sevinç Gülay', N'24561235678', N'Kadın Doğum ', N'Uzman', N'5371235678', N'Bağcılar/İstanbul', N'01.07.1985', 3)
SET IDENTITY_INSERT [dbo].[Hastane_Doktorlar] OFF
GO
SET IDENTITY_INSERT [dbo].[Hastane_Hastalar] ON 

INSERT [dbo].[Hastane_Hastalar] ([HastaNo], [HastaAdSoyad], [HastaTCNo], [DogumTarihi], [Kilo], [Boy], [Yas], [Recete], [RaporDurumu], [RandevuTarihi], [DoktorNo]) VALUES (1, N'Kadir Halıcı', N'34567812345', N'12.10.1980', 70, 180, 42, N'Parol', N'Var', N'12.12.2022', 1)
INSERT [dbo].[Hastane_Hastalar] ([HastaNo], [HastaAdSoyad], [HastaTCNo], [DogumTarihi], [Kilo], [Boy], [Yas], [Recete], [RaporDurumu], [RandevuTarihi], [DoktorNo]) VALUES (3, N'Makbule Lal', N'45612378912', N'14.10.1970', 70, 160, 52, N'Xanax', N'Yok', N'13.12.2022', 1)
INSERT [dbo].[Hastane_Hastalar] ([HastaNo], [HastaAdSoyad], [HastaTCNo], [DogumTarihi], [Kilo], [Boy], [Yas], [Recete], [RaporDurumu], [RandevuTarihi], [DoktorNo]) VALUES (7, N'Nergis Yayla', N'45612378912', N'09.02.1990', 60, 170, 32, N'Majezik', N'Var', N'15.12.2022', 3)
SET IDENTITY_INSERT [dbo].[Hastane_Hastalar] OFF
GO
SET IDENTITY_INSERT [dbo].[Hastane_Poliklinikler] ON 

INSERT [dbo].[Hastane_Poliklinikler] ([PoliklinikNo], [PoliklinikAdi], [PoliklinikUzmanSayisi], [PoliklinikBasHekimi], [PoliklinikBasHemsire], [YatakSayisi]) VALUES (1, N'Kalp Damar Cerrahi', 5, N'Ail Yılmaz', N'Bengü Bal', 21)
INSERT [dbo].[Hastane_Poliklinikler] ([PoliklinikNo], [PoliklinikAdi], [PoliklinikUzmanSayisi], [PoliklinikBasHekimi], [PoliklinikBasHemsire], [YatakSayisi]) VALUES (2, N'Dermotoloji', 10, N'Gizem Pala', N'Aslı Fidan', 15)
INSERT [dbo].[Hastane_Poliklinikler] ([PoliklinikNo], [PoliklinikAdi], [PoliklinikUzmanSayisi], [PoliklinikBasHekimi], [PoliklinikBasHemsire], [YatakSayisi]) VALUES (3, N'Kadın Doğum Uzmanı', 10, N'Hatice Albayrak', N'Mehmet Akça', 10)
SET IDENTITY_INSERT [dbo].[Hastane_Poliklinikler] OFF
GO
INSERT [dbo].[KullaniciKayit] ([KullaniciAdi], [Sifre], [Email], [Telefon]) VALUES (N'admin', N'1234', N'@gmail.com', N'123456789')
INSERT [dbo].[KullaniciKayit] ([KullaniciAdi], [Sifre], [Email], [Telefon]) VALUES (N'caglar', N'1234', N'ds', N'(23 )    -')
INSERT [dbo].[KullaniciKayit] ([KullaniciAdi], [Sifre], [Email], [Telefon]) VALUES (N'talha', N'1234', N'kemaltalhakoc@gmail.com', N'12345679')
INSERT [dbo].[KullaniciKayit] ([KullaniciAdi], [Sifre], [Email], [Telefon]) VALUES (N'zeynep', N'1234', N'@gmail.com', N'(534) 895-1605')
GO
ALTER TABLE [dbo].[Hastane_Doktorlar]  WITH CHECK ADD  CONSTRAINT [FK_Hastane_Doktorlar_Hastane_Poliklinikler] FOREIGN KEY([PoliklinikNo])
REFERENCES [dbo].[Hastane_Poliklinikler] ([PoliklinikNo])
GO
ALTER TABLE [dbo].[Hastane_Doktorlar] CHECK CONSTRAINT [FK_Hastane_Doktorlar_Hastane_Poliklinikler]
GO
ALTER TABLE [dbo].[Hastane_Hastalar]  WITH CHECK ADD  CONSTRAINT [FK_Hastane_Hastalar_Hastane_Doktorlar] FOREIGN KEY([DoktorNo])
REFERENCES [dbo].[Hastane_Doktorlar] ([DoktorNo])
GO
ALTER TABLE [dbo].[Hastane_Hastalar] CHECK CONSTRAINT [FK_Hastane_Hastalar_Hastane_Doktorlar]
GO
/****** Object:  StoredProcedure [dbo].[Aramayapdoktor]    Script Date: 15.11.2022 21:41:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Aramayapdoktor]
(
@DoktorNo int,
@DoktorAdSoyad varchar(50),
@DoktorTCNo varchar(11)

)
as begin 
select * from Hastane_Doktorlar where DoktorNo=@DoktorNo or DoktorAdSoyad=@DoktorAdSoyad or DoktorTCNo=@DoktorTCNo
end
GO
/****** Object:  StoredProcedure [dbo].[Aramayaphasta]    Script Date: 15.11.2022 21:41:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Aramayaphasta]
(
@HastaNo int,
@HastaAdSoyad varchar(50),
@HastaTCNo varchar(11)

)
as begin 
select * from Hastane_Hastalar where HastaNo=@HastaNo or HastaAdSoyad=@HastaAdSoyad or HastaTCNo=@HastaTCNo
end
GO
/****** Object:  StoredProcedure [dbo].[Aramayappoliklinik]    Script Date: 15.11.2022 21:41:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Aramayappoliklinik]
(
@PoliklinikNo int,
@PoliklinikAdi varchar(50)
)
as begin 
select * from Hastane_Poliklinikler where PoliklinikNo=@PoliklinikNo or PoliklinikAdi=@PoliklinikAdi
end
GO
/****** Object:  StoredProcedure [dbo].[Birlestirmegrup1Hasta]    Script Date: 15.11.2022 21:41:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Birlestirmegrup1Hasta](
@DoktorNo int
)
as begin
select d.DoktorAdSoyad, COUNT (*) as 'Doktorun baktığı hasta sayısı ve bilgileri' from 
Hastane_Hastalar h inner join Hastane_Doktorlar d on h.DoktorNo=d.DoktorNo where h.DoktorNo=@DoktorNo group by DoktorAdSoyad
end
GO
/****** Object:  StoredProcedure [dbo].[Birlestirmegrup2Poliklinik]    Script Date: 15.11.2022 21:41:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Birlestirmegrup2Poliklinik](
@PoliklinikNo int
)
as begin
select p.PoliklinikAdi, COUNT (*) as 'Poliklinikteki doktor sayısı ve bilgileri' from 
Hastane_Doktorlar d inner join Hastane_Poliklinikler p on d.PoliklinikNo=p.PoliklinikNo where d.PoliklinikNo=@PoliklinikNo group by PoliklinikAdi
end
GO
/****** Object:  StoredProcedure [dbo].[boyagoresirala]    Script Date: 15.11.2022 21:41:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[boyagoresirala]
as begin
select * from Hastane_Hastalar order by Boy asc
end
GO
/****** Object:  StoredProcedure [dbo].[DoktorHasta]    Script Date: 15.11.2022 21:41:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[DoktorHasta]
as begin select d.DoktorAdSoyad, h.HastaAdSoyad from Hastane_Doktorlar d inner join Hastane_Hastalar h on h.DoktorNo=d.DoktorNo order by DoktorAdSoyad 
end
GO
/****** Object:  StoredProcedure [dbo].[DoktorNoSec]    Script Date: 15.11.2022 21:41:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[DoktorNoSec]

as begin
select * from Hastane_Doktorlar
end
GO
/****** Object:  StoredProcedure [dbo].[DoktorTCAra]    Script Date: 15.11.2022 21:41:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[DoktorTCAra]
(
@DoktorTCNo varchar(11)
)
as begin select * from Hastane_Doktorlar
where DoktorTCNo=@DoktorTCNo
end
GO
/****** Object:  StoredProcedure [dbo].[EkleDoktorlar]    Script Date: 15.11.2022 21:41:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[EkleDoktorlar]

@DoktorAdSoyad varchar(50),
@DoktorTCNo varchar(11),
@UzmanlıkAlani varchar(50),
@Unvani varchar(50),
@TelefonNumarasi varchar(10),
@Adres varchar(50),
@DogumTarihi varchar(50),
@PoliklinikNo int
as begin
insert into Hastane_Doktorlar
(DoktorAdSoyad, DoktorTCNo, UzmanlıkAlani, Unvani, TelefonNumarasi, Adres, DogumTarihi, PoliklinikNo)
values (@DoktorAdSoyad, @DoktorTCNo, @UzmanlıkAlani, @Unvani, @TelefonNumarasi, @Adres, @DogumTarihi, @PoliklinikNo)
end
GO
/****** Object:  StoredProcedure [dbo].[EkleHastalar]    Script Date: 15.11.2022 21:41:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[EkleHastalar]
@HastaAdSoyad varchar(50),
@HastaTCNo varchar(11),
@DogumTarihi varchar(50),
@Kilo int,
@Boy int,
@Yas int,
@Recete varchar(50),
@RaporDurumu varchar(50),
@RandevuTarihi varchar(50),
@DoktorNo int
as begin
insert into Hastane_Hastalar 
(HastaAdSoyad, HastaTCNo, DogumTarihi, Kilo, Boy, Yas, Recete, RaporDurumu, RandevuTarihi, DoktorNo) values
(@HastaAdSoyad, @HastaTCNo, @DogumTarihi, @Kilo, @Boy, @Yas, @Recete, @RaporDurumu, @RandevuTarihi, @DoktorNo)
end
GO
/****** Object:  StoredProcedure [dbo].[EklePoliklinikler]    Script Date: 15.11.2022 21:41:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[EklePoliklinikler]

@PoliklinikAdi varchar(50),
@PoliklinikUzmanSayisi varchar(50),
@PoliklinikBasHekimi varchar(50),
@PoliklinikBasHemsire varchar(50),
@YatakSayisi int

as begin
insert into Hastane_Poliklinikler
( PoliklinikAdi, PoliklinikUzmanSayisi, PoliklinikBasHekimi, PoliklinikBasHemsire, YatakSayisi) values
( @PoliklinikAdi, @PoliklinikUzmanSayisi, @PoliklinikBasHekimi, @PoliklinikBasHemsire, @YatakSayisi)
end
GO
/****** Object:  StoredProcedure [dbo].[Hasta23Rapor]    Script Date: 15.11.2022 21:41:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Hasta23Rapor]
as begin select RaporDurumu,Count(*) as 'Hasta sayısı' from Hastane_Hastalar where Yas>23 group by RaporDurumu
end
GO
/****** Object:  StoredProcedure [dbo].[Hasta65Yas]    Script Date: 15.11.2022 21:41:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Hasta65Yas]
as begin select RaporDurumu,Recete from Hastane_Hastalar where Yas>65
end
GO
/****** Object:  StoredProcedure [dbo].[HastaBoyOrtalama]    Script Date: 15.11.2022 21:41:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[HastaBoyOrtalama]
as begin select DogumTarihi,avg(Boy) as 'Boy Ortalaması' from Hastane_Hastalar group by DogumTarihi having 165>avg(Boy)
end
GO
/****** Object:  StoredProcedure [dbo].[HastaDoktor]    Script Date: 15.11.2022 21:41:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[HastaDoktor]
as begin select HastaAdSoyad,HastaTCNo,TelefonNumarasi,Adres from Hastane_Hastalar h inner join Hastane_Doktorlar d on h.DoktorNo =d.DoktorNo
end
GO
/****** Object:  StoredProcedure [dbo].[HastaTcSiralama]    Script Date: 15.11.2022 21:41:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[HastaTcSiralama]
as begin select * from Hastane_Hastalar order by HastaTCNo desc
end
GO
/****** Object:  StoredProcedure [dbo].[kiloyagoresirala]    Script Date: 15.11.2022 21:41:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[kiloyagoresirala]
as begin
select * from Hastane_Hastalar order by Kilo asc
end
GO
/****** Object:  StoredProcedure [dbo].[KullanıcıGiris]    Script Date: 15.11.2022 21:41:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[KullanıcıGiris]

@KullaniciAdi varchar(50),
@Sifre varchar(50)
as begin
insert into KullanıcıGiris
(KullaniciAdi, Sifre) values (@KullaniciAdi, @Sifre)
end
GO
/****** Object:  StoredProcedure [dbo].[ListeleDoktorlar]    Script Date: 15.11.2022 21:41:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[ListeleDoktorlar]
as begin
select * from Hastane_Doktorlar
end
GO
/****** Object:  StoredProcedure [dbo].[ListelePoliklinikler]    Script Date: 15.11.2022 21:41:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[ListelePoliklinikler]
as begin
select * from Hastane_Poliklinikler
end
GO
/****** Object:  StoredProcedure [dbo].[PoliklinikNoSec]    Script Date: 15.11.2022 21:41:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[PoliklinikNoSec]

as begin
select * from Hastane_Poliklinikler
end
GO
/****** Object:  StoredProcedure [dbo].[RandevuTarihi]    Script Date: 15.11.2022 21:41:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[RandevuTarihi]
as begin select RandevuTarihi,COUNT(*) as 'Randevu Adedi' from Hastane_Hastalar group by RandevuTarihi 
end
GO
/****** Object:  StoredProcedure [dbo].[SilDoktorlar]    Script Date: 15.11.2022 21:41:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SilDoktorlar]
@DoktorNo int
as begin
delete from Hastane_Doktorlar where DoktorNo=@DoktorNo
end
GO
/****** Object:  StoredProcedure [dbo].[SilHastalar]    Script Date: 15.11.2022 21:41:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SilHastalar]
@HastaNo int
as begin
delete from Hastane_Hastalar where HastaNo=@HastaNo
end
GO
/****** Object:  StoredProcedure [dbo].[SilPoliklinikler]    Script Date: 15.11.2022 21:41:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SilPoliklinikler]
@PoliklinikNo int
as begin
delete from Hastane_Poliklinikler where PoliklinikNo=@PoliklinikNo
end
GO
/****** Object:  StoredProcedure [dbo].[yasagoresirala]    Script Date: 15.11.2022 21:41:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Proc [dbo].[yasagoresirala] 
as begin
select * from Hastane_Hastalar order by yas desc
end
GO
/****** Object:  StoredProcedure [dbo].[YenileDoktorlar]    Script Date: 15.11.2022 21:41:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[YenileDoktorlar]
@DoktorNo int,
@DoktorAdSoyad varchar(50),
@DoktorTCNo varchar(11),
@UzmanlıkAlani varchar(50),
@Unvani varchar(50),
@TelefonNumarasi varchar(10),
@Adres varchar(50),
@DogumTarihi varchar(50),
@PoliklinikNo varchar(50)

as begin
update Hastane_Doktorlar set
DoktorAdSoyad=@DoktorAdSoyad, DoktorTCNo=@DoktorTCNo, UzmanlıkAlani=@UzmanlıkAlani, Unvani=@Unvani, 
TelefonNumarasi=@TelefonNumarasi, Adres=@Adres, DogumTarihi=@DogumTarihi, PoliklinikNo=@PoliklinikNo where DoktorNo=@DoktorNo
end
GO
/****** Object:  StoredProcedure [dbo].[YenileHastalar]    Script Date: 15.11.2022 21:41:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[YenileHastalar]
@HastaNo int,
@HastaAdSoyad varchar(50),
@HastaTCNo varchar(11),
@DogumTarihi varchar(50),
@Kilo int,
@Boy int,
@Yas int,
@Recete varchar(50),
@RaporDurumu varchar(50),
@RandevuTarihi varchar(50),
@DoktorNo int
as begin
update Hastane_Hastalar set
HastaAdSoyad=@HastaAdSoyad, HastaTCNo=@HastaTCNo, DogumTarihi=@DogumTarihi, Kilo=@Kilo, Boy=@Boy, Recete=@Recete, Yas=@Yas, RaporDurumu=@RaporDurumu, RandevuTarihi=@RandevuTarihi
where HastaNo=@HastaNo
end
GO
/****** Object:  StoredProcedure [dbo].[YenilePoliklinikler]    Script Date: 15.11.2022 21:41:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[YenilePoliklinikler]
@PoliklinikNo int,
@PoliklinikAdi varchar(50),
@PoliklinikUzmanSayisi varchar(50),
@PoliklinikBasHekimi varchar(50),
@PoliklinikBasHemsire varchar(50),
@YatakSayisi int
as begin
update Hastane_Poliklinikler set
PoliklinikAdi=@PoliklinikAdi, PoliklinikUzmanSayisi=@PoliklinikUzmanSayisi, PoliklinikBasHekimi=@PoliklinikBasHekimi, 
PoliklinikBasHemsire=@PoliklinikBasHemsire, YatakSayisi=@YatakSayisi where PoliklinikNo=@PoliklinikNo
end
GO
USE [master]
GO
ALTER DATABASE [HastaneOtomasyonuSQL] SET  READ_WRITE 
GO
