

CREATE DATABASE dbSystem2021
go
USE dbSystem2021
go

/****** Object:  Table [dbo].[Cronograma]    Script Date: 28/10/2021 16:31:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cronograma](
	[Id_cronograma] [int] IDENTITY(1,1) NOT NULL,
	[FechaInicio] [varchar](10) NOT NULL,
	[FechaTermino] [varchar](10) NOT NULL,
	[Id_proyecto] [int] NOT NULL,
 CONSTRAINT [PK_CRONOGRAMA] PRIMARY KEY CLUSTERED 
(
	[Id_cronograma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cronograma_elemento_configuracion]    Script Date: 28/10/2021 16:31:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cronograma_elemento_configuracion](
	[Id_elemento_configuracion] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](200) NOT NULL,
	[Codigo] [varchar](200) NOT NULL,
	[Id_cronograma_fase] [int] NOT NULL,
 CONSTRAINT [PK_CRONOGRAMA_ELEMENTO_CONFIGURACION] PRIMARY KEY CLUSTERED 
(
	[Id_elemento_configuracion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cronograma_Fase]    Script Date: 28/10/2021 16:31:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cronograma_Fase](
	[Id_cronograma_fase] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](200) NOT NULL,
	[Id_cronograma] [int] NOT NULL,
 CONSTRAINT [PK_CRONOGRAMA_FASE] PRIMARY KEY CLUSTERED 
(
	[Id_cronograma_fase] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Detalle_Informe]    Script Date: 28/10/2021 16:31:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Detalle_Informe](
	[Id_detalle_informe] [int] IDENTITY(1,1) NOT NULL,
	[Id_informe_cambio] [int] NOT NULL,
	[Id_cronograma_elemento_configuracion] [int] NOT NULL,
	[Tiempo] [varchar](12) NOT NULL,
	[Costo] [varchar](12) NOT NULL,
	[Descripcion] [varchar](700) NOT NULL,
 CONSTRAINT [PK_DETALLE_INFORME] PRIMARY KEY CLUSTERED 
(
	[Id_detalle_informe] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Elemento_Configuracion]    Script Date: 28/10/2021 16:31:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Elemento_Configuracion](
	[Id_elementoconfiguracion] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [varchar](20) NOT NULL,
	[Nombre] [varchar](200) NOT NULL,
 CONSTRAINT [PK_ELEMENTO_CONFIGURACION] PRIMARY KEY CLUSTERED 
(
	[Id_elementoconfiguracion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Fase]    Script Date: 28/10/2021 16:31:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fase](
	[Id_fase] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](200) NOT NULL,
	[Id_metodologia] [int] NOT NULL,
 CONSTRAINT [PK_FASE] PRIMARY KEY CLUSTERED 
(
	[Id_fase] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Informe_Cambio]    Script Date: 28/10/2021 16:31:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Informe_Cambio](
	[Id_informe_cambio] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [varchar](20) NOT NULL,
	[Id_solicitud_cambios] [int] NOT NULL,
	[Descripcion] [varchar](400) NOT NULL,
	[Tiempo] [varchar](2000) NOT NULL,
	[CostoEconomico] [varchar](12) NOT NULL,
	[ImpactoProblema] [varchar](1000) NOT NULL,
	[Fecha] [varchar](12) NOT NULL,
	[Estado] [varchar](20) NOT NULL,
	[Id_miembro] [int] NOT NULL,
 CONSTRAINT [PK_INFORME_CAMBIO] PRIMARY KEY CLUSTERED 
(
	[Id_informe_cambio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Metodologia]    Script Date: 28/10/2021 16:31:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Metodologia](
	[Id_metodologia] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
 CONSTRAINT [PK_METODOLOGIA] PRIMARY KEY CLUSTERED 
(
	[Id_metodologia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Miembro_Proyecto]    Script Date: 28/10/2021 16:31:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Miembro_Proyecto](
	[Id_miembro] [int] IDENTITY(1,1) NOT NULL,
	[Id_usuario] [int] NOT NULL,
	[Id_rol] [int] NOT NULL,
	[Id_proyecto] [int] NOT NULL,
 CONSTRAINT [PK_MIEMBRO_PROYECTO] PRIMARY KEY CLUSTERED 
(
	[Id_miembro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orden_Cambio]    Script Date: 28/10/2021 16:31:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orden_Cambio](
	[Id_ordencambio] [int] IDENTITY(1,1) NOT NULL,
	[FechaAprobacion] [varchar](12) NOT NULL,
	[FechaInicio] [varchar](12) NOT NULL,
	[FechaTermino] [varchar](12) NOT NULL,
	[Descripción] [varchar](1000) NOT NULL,
	[PorcentajeAvance] [varchar](11) NOT NULL,
	[Estado] [varchar](20) NOT NULL,
	[Id_solicitud_cambios] [int] NOT NULL,
 CONSTRAINT [PK_ORDEN_CAMBIO] PRIMARY KEY CLUSTERED 
(
	[Id_ordencambio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orden_Cambio_Detalle]    Script Date: 28/10/2021 16:31:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orden_Cambio_Detalle](
	[Id_orden_cambio_detalle] [int] IDENTITY(1,1) NOT NULL,
	[Id_ordencambio] [int] NOT NULL,
	[Id_elemento_configuracion] [int] NOT NULL,
	[FechaInicio] [varchar](12) NOT NULL,
	[FechaTermino] [varchar](12) NOT NULL,
	[PorcentajeAvance] [varchar](11) NOT NULL,
	[Predecesora] [varchar](200) NOT NULL,
	[Descripcion] [varchar](700) NOT NULL,
 CONSTRAINT [PK_ORDEN_CAMBIO_DETALLE] PRIMARY KEY CLUSTERED 
(
	[Id_orden_cambio_detalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pantilla_elemento_configuracion]    Script Date: 28/10/2021 16:31:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pantilla_elemento_configuracion](
	[Id_plantilla] [int] IDENTITY(1,1) NOT NULL,
	[Id_fase] [int] NOT NULL,
	[Id_elementoconfiguracion] [int] NOT NULL,
 CONSTRAINT [PK_PANTILLA_ELEMENTO_CONFIGURACION] PRIMARY KEY CLUSTERED 
(
	[Id_plantilla] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proyecto]    Script Date: 28/10/2021 16:31:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proyecto](
	[Id_proyecto] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [varchar](200) NOT NULL,
	[Nombre] [varchar](200) NOT NULL,
	[FechaInicio] [varchar](10) NOT NULL,
	[FechaTermino] [varchar](10) NOT NULL,
	[Descripcion] [varchar](200) NOT NULL,
	[Estado] [varchar](200) NOT NULL,
	[Id_metodologia] [int] NOT NULL,
	[Id_Usuario] [int] NOT NULL,
 CONSTRAINT [PK_PROYECTO] PRIMARY KEY CLUSTERED 
(
	[Id_proyecto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rol]    Script Date: 28/10/2021 16:31:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rol](
	[Id_rol] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
 CONSTRAINT [PK_ROL] PRIMARY KEY CLUSTERED 
(
	[Id_rol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Solicitud_Cambios]    Script Date: 28/10/2021 16:31:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Solicitud_Cambios](
	[Id_solicitud_cambios] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [varchar](100) NOT NULL,
	[Fecha] [varchar](255) NOT NULL,
	[Objetivo] [varchar](200) NOT NULL,
	[Descripcion] [varchar](200) NOT NULL,
	[Respuesta] [varchar](200) NOT NULL,
	[Estado] [varchar](200) NOT NULL,
	[Id_proyecto] [int] NOT NULL,
	[Id_miembro] [int] NOT NULL,
 CONSTRAINT [PK_SOLICITUD_CAMBIOS] PRIMARY KEY CLUSTERED 
(
	[Id_solicitud_cambios] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tarea_ECS]    Script Date: 28/10/2021 16:31:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tarea_ECS](
	[Id_tarea] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [varchar](200) NOT NULL,
	[Id_version] [int] NOT NULL,
	[Id_miembro] [int] NOT NULL,
	[FechaInicio] [varchar](255) NOT NULL,
	[FechaTermino] [varchar](255) NOT NULL,
	[Descripcion] [varchar](1000) NOT NULL,
	[Justificacion] [varchar](1000) NOT NULL,
	[PorcentajeAvance] [varchar](11) NOT NULL,
	[UrlGithub] [varchar](2000) NOT NULL,
 CONSTRAINT [PK_TAREA_ECS] PRIMARY KEY CLUSTERED 
(
	[Id_tarea] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tipo_Usuario]    Script Date: 28/10/2021 16:31:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tipo_Usuario](
	[Id_tipousuario] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](200) NOT NULL,
 CONSTRAINT [PK_TIPO_USUARIO] PRIMARY KEY CLUSTERED 
(
	[Id_tipousuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 28/10/2021 16:31:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[Id_usuario] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Apellido] [varchar](100) NOT NULL,
	[Correo] [varchar](100) NOT NULL,
	[Password] [varchar](100) NOT NULL,
	[Id_tipousuario] [int] NOT NULL,
 CONSTRAINT [PK_USUARIO] PRIMARY KEY CLUSTERED 
(
	[Id_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Version_ECS]    Script Date: 28/10/2021 16:31:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Version_ECS](
	[Id_version] [int] IDENTITY(1,1) NOT NULL,
	[Id_elementoconfiguracion] [int] NOT NULL,
	[Version] [varchar](200) NOT NULL,
	[FechaInicio] [varchar](255) NOT NULL,
	[FechaTermino] [varchar](255) NOT NULL,
	[Descripcion] [varchar](255) NOT NULL,
	[Id_miembro] [int] NOT NULL,
 CONSTRAINT [PK_VERSION_ECS] PRIMARY KEY CLUSTERED 
(
	[Id_version] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Elemento_Configuracion] ON 

INSERT [dbo].[Elemento_Configuracion] ([Id_elementoconfiguracion], [Codigo], [Nombre]) VALUES (1, N'PP', N'Plan de Proyecto')
INSERT [dbo].[Elemento_Configuracion] ([Id_elementoconfiguracion], [Codigo], [Nombre]) VALUES (2, N'PC', N'Plan de Calidad')
SET IDENTITY_INSERT [dbo].[Elemento_Configuracion] OFF
GO
SET IDENTITY_INSERT [dbo].[Fase] ON 

INSERT [dbo].[Fase] ([Id_fase], [Nombre], [Id_metodologia]) VALUES (1, N'INICIO', 1)
INSERT [dbo].[Fase] ([Id_fase], [Nombre], [Id_metodologia]) VALUES (2, N'ELABORACION', 1)
INSERT [dbo].[Fase] ([Id_fase], [Nombre], [Id_metodologia]) VALUES (3, N'CONSTRUCCION', 1)
INSERT [dbo].[Fase] ([Id_fase], [Nombre], [Id_metodologia]) VALUES (4, N'TRANSICION', 1)
SET IDENTITY_INSERT [dbo].[Fase] OFF
GO
SET IDENTITY_INSERT [dbo].[Metodologia] ON 

INSERT [dbo].[Metodologia] ([Id_metodologia], [Nombre]) VALUES (1, N'Metodología RUP')
INSERT [dbo].[Metodologia] ([Id_metodologia], [Nombre]) VALUES (2, N'Metodología Agil')
INSERT [dbo].[Metodologia] ([Id_metodologia], [Nombre]) VALUES (3, N'Metodología Cascada')
INSERT [dbo].[Metodologia] ([Id_metodologia], [Nombre]) VALUES (4, N'Metodología Scrum')
SET IDENTITY_INSERT [dbo].[Metodologia] OFF
GO
SET IDENTITY_INSERT [dbo].[Tipo_Usuario] ON 

INSERT [dbo].[Tipo_Usuario] ([Id_tipousuario], [Nombre]) VALUES (1, N'Administrador')
INSERT [dbo].[Tipo_Usuario] ([Id_tipousuario], [Nombre]) VALUES (2, N'Jefe de Proyecto')
INSERT [dbo].[Tipo_Usuario] ([Id_tipousuario], [Nombre]) VALUES (3, N'Analista')
INSERT [dbo].[Tipo_Usuario] ([Id_tipousuario], [Nombre]) VALUES (4, N'Programador')
INSERT [dbo].[Tipo_Usuario] ([Id_tipousuario], [Nombre]) VALUES (5, N'Disenador  UX')
SET IDENTITY_INSERT [dbo].[Tipo_Usuario] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([Id_usuario], [Nombre], [Apellido], [Correo], [Password], [Id_tipousuario]) VALUES (1, N'Yober DEMO', N'Catari Cabrerajkhjkhj', N'yobernain@gmail.com', N'1123456', 1)
INSERT [dbo].[Usuario] ([Id_usuario], [Nombre], [Apellido], [Correo], [Password], [Id_tipousuario]) VALUES (2, N'Posi YuriFSDFSD', N'Vargas Cusacani', N'posi@fmail.com', N'122321', 2)
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
ALTER TABLE [dbo].[Cronograma]  WITH CHECK ADD  CONSTRAINT [Cronograma_fk0] FOREIGN KEY([Id_proyecto])
REFERENCES [dbo].[Proyecto] ([Id_proyecto])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Cronograma] CHECK CONSTRAINT [Cronograma_fk0]
GO
ALTER TABLE [dbo].[Cronograma_elemento_configuracion]  WITH CHECK ADD  CONSTRAINT [Cronograma_elemento_configuracion_fk0] FOREIGN KEY([Id_cronograma_fase])
REFERENCES [dbo].[Cronograma_Fase] ([Id_cronograma_fase])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Cronograma_elemento_configuracion] CHECK CONSTRAINT [Cronograma_elemento_configuracion_fk0]
GO
ALTER TABLE [dbo].[Cronograma_Fase]  WITH CHECK ADD  CONSTRAINT [Cronograma_Fase_fk0] FOREIGN KEY([Id_cronograma])
REFERENCES [dbo].[Cronograma] ([Id_cronograma])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Cronograma_Fase] CHECK CONSTRAINT [Cronograma_Fase_fk0]
GO
ALTER TABLE [dbo].[Detalle_Informe]  WITH CHECK ADD  CONSTRAINT [Detalle_Informe_fk0] FOREIGN KEY([Id_informe_cambio])
REFERENCES [dbo].[Informe_Cambio] ([Id_informe_cambio])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Detalle_Informe] CHECK CONSTRAINT [Detalle_Informe_fk0]
GO
ALTER TABLE [dbo].[Fase]  WITH CHECK ADD  CONSTRAINT [Fase_fk0] FOREIGN KEY([Id_metodologia])
REFERENCES [dbo].[Metodologia] ([Id_metodologia])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Fase] CHECK CONSTRAINT [Fase_fk0]
GO
ALTER TABLE [dbo].[Informe_Cambio]  WITH CHECK ADD  CONSTRAINT [Informe_Cambio_fk0] FOREIGN KEY([Id_solicitud_cambios])
REFERENCES [dbo].[Solicitud_Cambios] ([Id_solicitud_cambios])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Informe_Cambio] CHECK CONSTRAINT [Informe_Cambio_fk0]
GO
ALTER TABLE [dbo].[Miembro_Proyecto]  WITH CHECK ADD  CONSTRAINT [Miembro_Proyecto_fk1] FOREIGN KEY([Id_rol])
REFERENCES [dbo].[Rol] ([Id_rol])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Miembro_Proyecto] CHECK CONSTRAINT [Miembro_Proyecto_fk1]
GO
ALTER TABLE [dbo].[Orden_Cambio]  WITH CHECK ADD  CONSTRAINT [Orden_Cambio_fk0] FOREIGN KEY([Id_solicitud_cambios])
REFERENCES [dbo].[Solicitud_Cambios] ([Id_solicitud_cambios])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Orden_Cambio] CHECK CONSTRAINT [Orden_Cambio_fk0]
GO
ALTER TABLE [dbo].[Orden_Cambio_Detalle]  WITH CHECK ADD  CONSTRAINT [Orden_Cambio_Detalle_fk0] FOREIGN KEY([Id_ordencambio])
REFERENCES [dbo].[Orden_Cambio] ([Id_ordencambio])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Orden_Cambio_Detalle] CHECK CONSTRAINT [Orden_Cambio_Detalle_fk0]
GO
ALTER TABLE [dbo].[Pantilla_elemento_configuracion]  WITH CHECK ADD  CONSTRAINT [Pantilla_elemento_configuracion_fk0] FOREIGN KEY([Id_fase])
REFERENCES [dbo].[Fase] ([Id_fase])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Pantilla_elemento_configuracion] CHECK CONSTRAINT [Pantilla_elemento_configuracion_fk0]
GO
ALTER TABLE [dbo].[Pantilla_elemento_configuracion]  WITH CHECK ADD  CONSTRAINT [Pantilla_elemento_configuracion_fk1] FOREIGN KEY([Id_elementoconfiguracion])
REFERENCES [dbo].[Elemento_Configuracion] ([Id_elementoconfiguracion])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Pantilla_elemento_configuracion] CHECK CONSTRAINT [Pantilla_elemento_configuracion_fk1]
GO
ALTER TABLE [dbo].[Proyecto]  WITH CHECK ADD  CONSTRAINT [Proyecto_fk0] FOREIGN KEY([Id_metodologia])
REFERENCES [dbo].[Metodologia] ([Id_metodologia])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Proyecto] CHECK CONSTRAINT [Proyecto_fk0]
GO
ALTER TABLE [dbo].[Proyecto]  WITH CHECK ADD  CONSTRAINT [Proyecto_fk1] FOREIGN KEY([Id_Usuario])
REFERENCES [dbo].[Usuario] ([Id_usuario])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Proyecto] CHECK CONSTRAINT [Proyecto_fk1]
GO
ALTER TABLE [dbo].[Solicitud_Cambios]  WITH CHECK ADD  CONSTRAINT [Solicitud_Cambios_fk0] FOREIGN KEY([Id_proyecto])
REFERENCES [dbo].[Proyecto] ([Id_proyecto])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Solicitud_Cambios] CHECK CONSTRAINT [Solicitud_Cambios_fk0]
GO
ALTER TABLE [dbo].[Solicitud_Cambios]  WITH CHECK ADD  CONSTRAINT [Solicitud_Cambios_fk1] FOREIGN KEY([Id_miembro])
REFERENCES [dbo].[Miembro_Proyecto] ([Id_miembro])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Solicitud_Cambios] CHECK CONSTRAINT [Solicitud_Cambios_fk1]
GO
ALTER TABLE [dbo].[Tarea_ECS]  WITH CHECK ADD  CONSTRAINT [Tarea_ECS_fk0] FOREIGN KEY([Id_version])
REFERENCES [dbo].[Version_ECS] ([Id_version])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Tarea_ECS] CHECK CONSTRAINT [Tarea_ECS_fk0]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [Usuario_fk0] FOREIGN KEY([Id_tipousuario])
REFERENCES [dbo].[Tipo_Usuario] ([Id_tipousuario])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [Usuario_fk0]
GO
ALTER TABLE [dbo].[Version_ECS]  WITH CHECK ADD  CONSTRAINT [Version_ECS_fk0] FOREIGN KEY([Id_elementoconfiguracion])
REFERENCES [dbo].[Elemento_Configuracion] ([Id_elementoconfiguracion])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Version_ECS] CHECK CONSTRAINT [Version_ECS_fk0]
GO
ALTER TABLE [dbo].[Version_ECS]  WITH CHECK ADD  CONSTRAINT [Version_ECS_fk1] FOREIGN KEY([Id_miembro])
REFERENCES [dbo].[Miembro_Proyecto] ([Id_miembro])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Version_ECS] CHECK CONSTRAINT [Version_ECS_fk1]
GO
