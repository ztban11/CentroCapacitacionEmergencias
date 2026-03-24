USE [CapacitacionEmergenciasDB]
GO
/****** Object:  Table [dbo].[Cohortes]    Script Date: 23/03/2026 22:59:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cohortes](
	[CohorteId] [int] IDENTITY(1,1) NOT NULL,
	[sNombreCohorte] [nvarchar](max) NULL,
	[dFechaInicio] [datetime] NOT NULL,
	[dFechaFin] [datetime] NOT NULL,
	[bCohorteArchivada] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Cohortes] PRIMARY KEY CLUSTERED 
(
	[CohorteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cursoes]    Script Date: 23/03/2026 22:59:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cursoes](
	[CursoId] [int] IDENTITY(1,1) NOT NULL,
	[sNombreCurso] [nvarchar](max) NULL,
	[bCursoActivo] [bit] NOT NULL,
	[PuntajeMinimoAprobacion] [int] NOT NULL,
	[sCodigoCurso] [nvarchar](50) NOT NULL,
	[iHorasPracticas] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Cursoes] PRIMARY KEY CLUSTERED 
(
	[CursoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Destrezas]    Script Date: 23/03/2026 22:59:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Destrezas](
	[DestrezaID] [int] IDENTITY(1,1) NOT NULL,
	[NombreDestreza] [nvarchar](150) NOT NULL,
	[CursoId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[DestrezaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Evaluaciones]    Script Date: 23/03/2026 22:59:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Evaluaciones](
	[EvaluacionId] [int] IDENTITY(1,1) NOT NULL,
	[ParticipanteId] [int] NULL,
	[CursoId] [int] NULL,
	[DestrezaId] [int] NULL,
	[TiempoRespuesta] [varchar](10) NULL,
	[PuntajeFinal] [int] NULL,
	[Control1] [bit] NULL,
	[Control2] [bit] NULL,
	[Control3] [bit] NULL,
	[Instructor] [varchar](100) NULL,
	[FechaEvaluacion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[EvaluacionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HorasPracticas]    Script Date: 23/03/2026 22:59:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HorasPracticas](
	[HorasPracticaId] [int] IDENTITY(1,1) NOT NULL,
	[ParticipanteId] [int] NOT NULL,
	[CursoId] [int] NOT NULL,
	[HorasCompletadas] [int] NOT NULL,
	[HorasRequeridas] [int] NOT NULL,
	[FechaRegistro] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[HorasPracticaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ParticipanteCursoes]    Script Date: 23/03/2026 22:59:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ParticipanteCursoes](
	[ParticipanteCursoId] [int] IDENTITY(1,1) NOT NULL,
	[iParticipanteID] [int] NOT NULL,
	[iCursoID] [int] NOT NULL,
	[CCurso_CursoId] [int] NULL,
	[PParticipante_ParticipanteId] [int] NULL,
 CONSTRAINT [PK_dbo.ParticipanteCursoes] PRIMARY KEY CLUSTERED 
(
	[ParticipanteCursoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Participantes]    Script Date: 23/03/2026 22:59:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Participantes](
	[ParticipanteId] [int] IDENTITY(1,1) NOT NULL,
	[sTipoIdentificacion] [nvarchar](max) NULL,
	[sNumeroIdentificacion] [nvarchar](max) NULL,
	[sNombreCompleto] [nvarchar](max) NULL,
	[dtFechaNacimiento] [datetime] NOT NULL,
	[sProvincia] [nvarchar](max) NULL,
	[sCanton] [nvarchar](max) NULL,
	[sDistrito] [nvarchar](max) NULL,
	[sDetallesResidencia] [nvarchar](max) NULL,
	[sEstadoCivil] [nvarchar](max) NULL,
	[sEmail] [nvarchar](max) NULL,
	[sTelefono] [nvarchar](max) NULL,
	[sDireccionResidencia] [nvarchar](max) NULL,
	[sContactoEmergencia] [nvarchar](max) NULL,
	[bEstaActivo] [bit] NOT NULL,
	[iIDCohorte] [int] NOT NULL,
	[Cohorte_CohorteId] [int] NULL,
 CONSTRAINT [PK_dbo.Participantes] PRIMARY KEY CLUSTERED 
(
	[ParticipanteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 23/03/2026 22:59:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[IDUsuario] [int] IDENTITY(1,1) NOT NULL,
	[NombreUsuario] [varchar](50) NOT NULL,
	[PasswordHash] [varchar](255) NOT NULL,
	[Rol] [varchar](50) NULL,
	[IntentosFallidos] [int] NULL,
	[EstaBloqueado] [bit] NULL,
	[FechaBloqueo] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IDUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[NombreUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [IX_CCurso_CursoId]    Script Date: 23/03/2026 22:59:43 ******/
CREATE NONCLUSTERED INDEX [IX_CCurso_CursoId] ON [dbo].[ParticipanteCursoes]
(
	[CCurso_CursoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PParticipante_ParticipanteId]    Script Date: 23/03/2026 22:59:43 ******/
CREATE NONCLUSTERED INDEX [IX_PParticipante_ParticipanteId] ON [dbo].[ParticipanteCursoes]
(
	[PParticipante_ParticipanteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Cohorte_CohorteId]    Script Date: 23/03/2026 22:59:43 ******/
CREATE NONCLUSTERED INDEX [IX_Cohorte_CohorteId] ON [dbo].[Participantes]
(
	[Cohorte_CohorteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Cohortes] ADD  DEFAULT (getdate()) FOR [dFechaInicio]
GO
ALTER TABLE [dbo].[Cohortes] ADD  DEFAULT (getdate()) FOR [dFechaFin]
GO
ALTER TABLE [dbo].[Cohortes] ADD  DEFAULT ((0)) FOR [bCohorteArchivada]
GO
ALTER TABLE [dbo].[Cursoes] ADD  DEFAULT ((70)) FOR [PuntajeMinimoAprobacion]
GO
ALTER TABLE [dbo].[Cursoes] ADD  DEFAULT ('') FOR [sCodigoCurso]
GO
ALTER TABLE [dbo].[Cursoes] ADD  DEFAULT ((0)) FOR [iHorasPracticas]
GO
ALTER TABLE [dbo].[HorasPracticas] ADD  DEFAULT (getdate()) FOR [FechaRegistro]
GO
ALTER TABLE [dbo].[Usuarios] ADD  DEFAULT ((0)) FOR [IntentosFallidos]
GO
ALTER TABLE [dbo].[Usuarios] ADD  DEFAULT ((0)) FOR [EstaBloqueado]
GO
ALTER TABLE [dbo].[Destrezas]  WITH CHECK ADD  CONSTRAINT [FK_Destreza_Curso] FOREIGN KEY([CursoId])
REFERENCES [dbo].[Cursoes] ([CursoId])
GO
ALTER TABLE [dbo].[Destrezas] CHECK CONSTRAINT [FK_Destreza_Curso]
GO
ALTER TABLE [dbo].[HorasPracticas]  WITH CHECK ADD FOREIGN KEY([CursoId])
REFERENCES [dbo].[Cursoes] ([CursoId])
GO
ALTER TABLE [dbo].[HorasPracticas]  WITH CHECK ADD FOREIGN KEY([ParticipanteId])
REFERENCES [dbo].[Participantes] ([ParticipanteId])
GO
ALTER TABLE [dbo].[ParticipanteCursoes]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ParticipanteCursoes_dbo.Cursoes_CCurso_CursoId] FOREIGN KEY([CCurso_CursoId])
REFERENCES [dbo].[Cursoes] ([CursoId])
GO
ALTER TABLE [dbo].[ParticipanteCursoes] CHECK CONSTRAINT [FK_dbo.ParticipanteCursoes_dbo.Cursoes_CCurso_CursoId]
GO
ALTER TABLE [dbo].[ParticipanteCursoes]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ParticipanteCursoes_dbo.Participantes_PParticipante_ParticipanteId] FOREIGN KEY([PParticipante_ParticipanteId])
REFERENCES [dbo].[Participantes] ([ParticipanteId])
GO
ALTER TABLE [dbo].[ParticipanteCursoes] CHECK CONSTRAINT [FK_dbo.ParticipanteCursoes_dbo.Participantes_PParticipante_ParticipanteId]
GO
ALTER TABLE [dbo].[Participantes]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Participantes_dbo.Cohortes_Cohorte_CohorteId] FOREIGN KEY([Cohorte_CohorteId])
REFERENCES [dbo].[Cohortes] ([CohorteId])
GO
ALTER TABLE [dbo].[Participantes] CHECK CONSTRAINT [FK_dbo.Participantes_dbo.Cohortes_Cohorte_CohorteId]
GO
