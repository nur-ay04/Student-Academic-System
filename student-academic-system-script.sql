USE [OgrenciSinav]
GO
/****** Object:  Table [dbo].[TblDersler]    Script Date: 22.04.2025 14:52:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblDersler](
	[DersID] [int] IDENTITY(1,1) NOT NULL,
	[DersAd] [nvarchar](50) NULL,
 CONSTRAINT [PK_TblDersler] PRIMARY KEY CLUSTERED 
(
	[DersID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblOgrenci]    Script Date: 22.04.2025 14:52:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblOgrenci](
	[OgrID] [int] IDENTITY(1,1) NOT NULL,
	[OgrAD] [nvarchar](50) NULL,
	[OgrSoyad] [nvarchar](50) NULL,
	[OgrNumara] [char](5) NULL,
	[OgrSifre] [nvarchar](10) NULL,
	[OgrMail] [nvarchar](50) NULL,
	[OgrResim] [nvarchar](100) NULL,
	[OgrBolum] [int] NULL,
	[OgrDurum] [bit] NULL,
 CONSTRAINT [PK_TblOgrenci] PRIMARY KEY CLUSTERED 
(
	[OgrID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblNotlar]    Script Date: 22.04.2025 14:52:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblNotlar](
	[NotID] [int] IDENTITY(1,1) NOT NULL,
	[Sinav1] [int] NULL,
	[Sinav2] [int] NULL,
	[Sinav3] [int] NULL,
	[Quiz1] [int] NULL,
	[Quiz2] [int] NULL,
	[Proje] [int] NULL,
	[Ortalama] [decimal](5, 2) NULL,
	[Ders] [int] NULL,
	[Ogrenci] [int] NULL,
 CONSTRAINT [PK_TblNotlar] PRIMARY KEY CLUSTERED 
(
	[NotID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[View_1]    Script Date: 22.04.2025 14:52:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[View_1]
AS
SELECT dbo.TblNotlar.NotID, dbo.TblOgrenci.OgrAD, dbo.TblOgrenci.OgrSoyad, dbo.TblDersler.DersAd, dbo.TblNotlar.Sinav1, dbo.TblNotlar.Sinav2, dbo.TblNotlar.Sinav3, dbo.TblNotlar.Quiz1, dbo.TblNotlar.Quiz2, dbo.TblNotlar.Proje, 
                  dbo.TblNotlar.Ortalama
FROM     dbo.TblNotlar INNER JOIN
                  dbo.TblDersler ON dbo.TblNotlar.Ders = dbo.TblDersler.DersID INNER JOIN
                  dbo.TblOgrenci ON dbo.TblNotlar.Ogrenci = dbo.TblOgrenci.OgrID
GO
/****** Object:  Table [dbo].[TblAkademisyen]    Script Date: 22.04.2025 14:52:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblAkademisyen](
	[AkademisyenID] [int] IDENTITY(1,1) NOT NULL,
	[AkademisyenAd] [nvarchar](50) NULL,
	[AkademisyenSoyad] [nvarchar](50) NULL,
	[Unvan] [nvarchar](20) NULL,
	[AkademisyenNumara] [char](5) NULL,
	[AkademisyenSifre] [nvarchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[AkademisyenID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblBolum]    Script Date: 22.04.2025 14:52:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblBolum](
	[BolumID] [int] IDENTITY(1,1) NOT NULL,
	[BolumAd] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[BolumID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[TblNotlar]  WITH CHECK ADD  CONSTRAINT [FK_TblNotlar_TblDersler] FOREIGN KEY([Ders])
REFERENCES [dbo].[TblDersler] ([DersID])
GO
ALTER TABLE [dbo].[TblNotlar] CHECK CONSTRAINT [FK_TblNotlar_TblDersler]
GO
ALTER TABLE [dbo].[TblNotlar]  WITH CHECK ADD  CONSTRAINT [FK_TblNotlar_TblOgrenci] FOREIGN KEY([Ogrenci])
REFERENCES [dbo].[TblOgrenci] ([OgrID])
GO
ALTER TABLE [dbo].[TblNotlar] CHECK CONSTRAINT [FK_TblNotlar_TblOgrenci]
GO
ALTER TABLE [dbo].[TblOgrenci]  WITH CHECK ADD  CONSTRAINT [FK_TblOgrenci_TblBolum] FOREIGN KEY([OgrBolum])
REFERENCES [dbo].[TblBolum] ([BolumID])
GO
ALTER TABLE [dbo].[TblOgrenci] CHECK CONSTRAINT [FK_TblOgrenci_TblBolum]
GO
/****** Object:  StoredProcedure [dbo].[Notlar]    Script Date: 22.04.2025 14:52:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Notlar]
as
select NotID as 'Not Id',DersAd as 'Ders Adı',OgrAD +' ' +OgrSoyad as 'Öğrenci', Sinav1, Sinav2,Sinav3,Quiz1,Quiz2, Ortalama from TblNotlar
inner join TblDersler
on TblNotlar.Ders = TblDersler.DersID
inner join TblOgrenci
on TblNotlar.Ogrenci = TblOgrenci.OgrID
GO
/****** Object:  StoredProcedure [dbo].[Notlar2]    Script Date: 22.04.2025 14:52:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Notlar2]
as
select NotID as 'Not Id',DersAd as 'Ders Adı',OgrAD +' ' +OgrSoyad as 'Öğrenci', Sinav1, Sinav2,Sinav3,Quiz1,Quiz2, Ortalama from TblNotlar
inner join TblDersler
on TblNotlar.Ders = TblDersler.DersID
inner join TblOgrenci
on TblNotlar.Ogrenci = TblOgrenci.OgrID
GO
/****** Object:  StoredProcedure [dbo].[Notlar3]    Script Date: 22.04.2025 14:52:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Notlar3] 
as
select NotID as 'Not Id',DersAd as 'Ders Adı',OgrAD +' ' +OgrSoyad as 'Öğrenci', Sinav1, Sinav2,Sinav3,Quiz1,Quiz2,Proje ,Ortalama from TblNotlar
inner join TblDersler
on TblNotlar.Ders = TblDersler.DersID
inner join TblOgrenci
on TblNotlar.Ogrenci = TblOgrenci.OgrID
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[46] 4[15] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "TblDersler"
            Begin Extent = 
               Top = 102
               Left = 104
               Bottom = 221
               Right = 298
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TblNotlar"
            Begin Extent = 
               Top = 25
               Left = 413
               Bottom = 329
               Right = 607
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TblOgrenci"
            Begin Extent = 
               Top = 33
               Left = 781
               Bottom = 196
               Right = 975
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1176
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1356
         SortOrder = 1416
         GroupBy = 1356
         Filter = 1356
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_1'
GO
