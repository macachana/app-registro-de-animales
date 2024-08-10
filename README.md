# app-registro-de-animales
registro de animales utilizando base de datos SQL de SQL management server studio, GUI de windows form y C#  
## base de datos utilizada en el proyecto a continuacion.
```
USE [Refugio]
GO
/****** Object:  Table [dbo].[Animales]    Script Date: 2/7/2024 21:06:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Animales](
	[nombre] [varchar](30) NOT NULL,
	[colorOjos] [varchar](30) NOT NULL,
	[edad] [int] NOT NULL,
	[peso] [float] NOT NULL,
	[sexo] [int] NOT NULL,
	[razaGatos] [int] NULL,
	[esDomestico] [bit] NULL,
	[comportamiento] [varchar](30) NULL,
	[raza] [varchar](30) NULL,
	[tamanio] [int] NULL,
	[subEspecie] [int] NULL,
	[habitat] [varchar](30) NULL
) ON [PRIMARY]
GO
INSERT [dbo].[Animales] ([nombre], [colorOjos], [edad], [peso], [sexo], [razaGatos], [esDomestico], [comportamiento], [raza], [tamanio], [subEspecie], [habitat]) VALUES (N'luna', N'verde', 36, 4.5, 0, 1, 1, N'jugueton y carismatico', NULL, NULL, NULL, NULL)
INSERT [dbo].[Animales] ([nombre], [colorOjos], [edad], [peso], [sexo], [razaGatos], [esDomestico], [comportamiento], [raza], [tamanio], [subEspecie], [habitat]) VALUES (N'oliver', N'azul', 24, 5, 1, 0, 1, N'tranquilo y perezoso', NULL, NULL, NULL, NULL)
INSERT [dbo].[Animales] ([nombre], [colorOjos], [edad], [peso], [sexo], [razaGatos], [esDomestico], [comportamiento], [raza], [tamanio], [subEspecie], [habitat]) VALUES (N'simba', N'miel', 48, 9.5, 1, 3, 0, N'protector y curiosa', NULL, NULL, NULL, NULL)
INSERT [dbo].[Animales] ([nombre], [colorOjos], [edad], [peso], [sexo], [razaGatos], [esDomestico], [comportamiento], [raza], [tamanio], [subEspecie], [habitat]) VALUES (N'bella', N'amarillo', 12, 3.2, 0, 7, 1, N'energetica', NULL, NULL, NULL, NULL)
INSERT [dbo].[Animales] ([nombre], [colorOjos], [edad], [peso], [sexo], [razaGatos], [esDomestico], [comportamiento], [raza], [tamanio], [subEspecie], [habitat]) VALUES (N'milo', N'verde', 36, 4, 1, 5, 1, N'activo', NULL, NULL, NULL, NULL)
INSERT [dbo].[Animales] ([nombre], [colorOjos], [edad], [peso], [sexo], [razaGatos], [esDomestico], [comportamiento], [raza], [tamanio], [subEspecie], [habitat]) VALUES (N'chloe', N'azul', 24, 3.5, 2, 3, 1, N'dulce y relajada', NULL, NULL, NULL, NULL)
INSERT [dbo].[Animales] ([nombre], [colorOjos], [edad], [peso], [sexo], [razaGatos], [esDomestico], [comportamiento], [raza], [tamanio], [subEspecie], [habitat]) VALUES (N'rocky', N'marron', 36, 15.5, 0, NULL, NULL, NULL, N'labrador retriever', 2, NULL, NULL)
INSERT [dbo].[Animales] ([nombre], [colorOjos], [edad], [peso], [sexo], [razaGatos], [esDomestico], [comportamiento], [raza], [tamanio], [subEspecie], [habitat]) VALUES (N'bella', N'azul', 24, 10.3, 1, NULL, NULL, NULL, N'husky siberiano', 2, NULL, NULL)
INSERT [dbo].[Animales] ([nombre], [colorOjos], [edad], [peso], [sexo], [razaGatos], [esDomestico], [comportamiento], [raza], [tamanio], [subEspecie], [habitat]) VALUES (N'Rocky', N'Marrón', 40, 15.5, 0, NULL, NULL, NULL, N'A', 2, NULL, NULL)
INSERT [dbo].[Animales] ([nombre], [colorOjos], [edad], [peso], [sexo], [razaGatos], [esDomestico], [comportamiento], [raza], [tamanio], [subEspecie], [habitat]) VALUES (N'lucy', N'miel', 12, 7.4, 1, NULL, NULL, NULL, N'beagle', 1, NULL, NULL)
INSERT [dbo].[Animales] ([nombre], [colorOjos], [edad], [peso], [sexo], [razaGatos], [esDomestico], [comportamiento], [raza], [tamanio], [subEspecie], [habitat]) VALUES (N'max', N'marron oscuro', 36, 20, 1, NULL, NULL, NULL, N'golden retriever', 2, NULL, NULL)
INSERT [dbo].[Animales] ([nombre], [colorOjos], [edad], [peso], [sexo], [razaGatos], [esDomestico], [comportamiento], [raza], [tamanio], [subEspecie], [habitat]) VALUES (N'daisy', N'verde', 24, 5.6, 1, NULL, NULL, NULL, N'poodle', 1, NULL, NULL)
INSERT [dbo].[Animales] ([nombre], [colorOjos], [edad], [peso], [sexo], [razaGatos], [esDomestico], [comportamiento], [raza], [tamanio], [subEspecie], [habitat]) VALUES (N'rajah', N'ambar', 36, 190, 1, NULL, NULL, NULL, NULL, NULL, 0, N'bosques y praderas')
INSERT [dbo].[Animales] ([nombre], [colorOjos], [edad], [peso], [sexo], [razaGatos], [esDomestico], [comportamiento], [raza], [tamanio], [subEspecie], [habitat]) VALUES (N'Sundar', N'Verde', 60, 250, 1, NULL, NULL, NULL, NULL, NULL, 10, N'Regiones deserticas')
INSERT [dbo].[Animales] ([nombre], [colorOjos], [edad], [peso], [sexo], [razaGatos], [esDomestico], [comportamiento], [raza], [tamanio], [subEspecie], [habitat]) VALUES (N'kumar', N'ambar', 48, 220, 1, NULL, NULL, NULL, NULL, NULL, 4, N'bosques del sureste')
INSERT [dbo].[Animales] ([nombre], [colorOjos], [edad], [peso], [sexo], [razaGatos], [esDomestico], [comportamiento], [raza], [tamanio], [subEspecie], [habitat]) VALUES (N'luna', N'ambar', 18, 130, 0, NULL, NULL, NULL, NULL, NULL, 3, N'bosques del sur')
INSERT [dbo].[Animales] ([nombre], [colorOjos], [edad], [peso], [sexo], [razaGatos], [esDomestico], [comportamiento], [raza], [tamanio], [subEspecie], [habitat]) VALUES (N'bertha', N'celeste', 45, 12.3, 0, NULL, NULL, NULL, N'san bernardo', 2, NULL, NULL)
INSERT [dbo].[Animales] ([nombre], [colorOjos], [edad], [peso], [sexo], [razaGatos], [esDomestico], [comportamiento], [raza], [tamanio], [subEspecie], [habitat]) VALUES (N'mia', N'azul', 45, 2.2, 0, 3, 1, N'comoda y serena', NULL, NULL, NULL, NULL)
INSERT [dbo].[Animales] ([nombre], [colorOjos], [edad], [peso], [sexo], [razaGatos], [esDomestico], [comportamiento], [raza], [tamanio], [subEspecie], [habitat]) VALUES (N'gem', N'azul', 34, 12.4, 0, 3, 1, N'divertida', NULL, NULL, NULL, NULL)
INSERT [dbo].[Animales] ([nombre], [colorOjos], [edad], [peso], [sexo], [razaGatos], [esDomestico], [comportamiento], [raza], [tamanio], [subEspecie], [habitat]) VALUES (N'Bella', N'Azul', 40, 10.3, 1, NULL, NULL, NULL, N'B', 2, NULL, NULL)
INSERT [dbo].[Animales] ([nombre], [colorOjos], [edad], [peso], [sexo], [razaGatos], [esDomestico], [comportamiento], [raza], [tamanio], [subEspecie], [habitat]) VALUES (N'maria', N'celeste', 24, 26, 1, 2, 1, N'tranquilo', NULL, NULL, NULL, NULL)
INSERT [dbo].[Animales] ([nombre], [colorOjos], [edad], [peso], [sexo], [razaGatos], [esDomestico], [comportamiento], [raza], [tamanio], [subEspecie], [habitat]) VALUES (N'Charlie', N'Negro', 40, 18.2, 0, NULL, NULL, NULL, N'C', 2, NULL, NULL)
INSERT [dbo].[Animales] ([nombre], [colorOjos], [edad], [peso], [sexo], [razaGatos], [esDomestico], [comportamiento], [raza], [tamanio], [subEspecie], [habitat]) VALUES (N'Charlie', N'Negro', 48, 18.2, 0, NULL, NULL, NULL, N'Pastor Alemán', 2, NULL, NULL)
INSERT [dbo].[Animales] ([nombre], [colorOjos], [edad], [peso], [sexo], [razaGatos], [esDomestico], [comportamiento], [raza], [tamanio], [subEspecie], [habitat]) VALUES (N'Max', N'Marrón', 36, 20, 0, NULL, NULL, NULL, N'Golden Retriever', 2, NULL, NULL)
INSERT [dbo].[Animales] ([nombre], [colorOjos], [edad], [peso], [sexo], [razaGatos], [esDomestico], [comportamiento], [raza], [tamanio], [subEspecie], [habitat]) VALUES (N'Cooper', N'Gris', 60, 30.2, 0, NULL, NULL, NULL, N'Rottweiler', 2, NULL, NULL)
INSERT [dbo].[Animales] ([nombre], [colorOjos], [edad], [peso], [sexo], [razaGatos], [esDomestico], [comportamiento], [raza], [tamanio], [subEspecie], [habitat]) VALUES (N'Molly', N'Ámbar', 36, 6.8, 1, NULL, NULL, NULL, N'Bulldog Francés', 1, NULL, NULL)
INSERT [dbo].[Animales] ([nombre], [colorOjos], [edad], [peso], [sexo], [razaGatos], [esDomestico], [comportamiento], [raza], [tamanio], [subEspecie], [habitat]) VALUES (N'Buddy', N'Verde', 48, 25, 0, NULL, NULL, NULL, N'Boxer', 2, NULL, NULL)
INSERT [dbo].[Animales] ([nombre], [colorOjos], [edad], [peso], [sexo], [razaGatos], [esDomestico], [comportamiento], [raza], [tamanio], [subEspecie], [habitat]) VALUES (N'Luna', N'Marrón', 24, 8.3, 1, NULL, NULL, NULL, N'Dachshund', 1, NULL, NULL)
INSERT [dbo].[Animales] ([nombre], [colorOjos], [edad], [peso], [sexo], [razaGatos], [esDomestico], [comportamiento], [raza], [tamanio], [subEspecie], [habitat]) VALUES (N'Simba', N'Ámbar', 4, 6, 1, 2, 1, N'Protector y curioso', NULL, NULL, NULL, NULL)
INSERT [dbo].[Animales] ([nombre], [colorOjos], [edad], [peso], [sexo], [razaGatos], [esDomestico], [comportamiento], [raza], [tamanio], [subEspecie], [habitat]) VALUES (N'Milo', N'Verde', 3, 4, 1, 4, 1, N'Activo y sociable', NULL, NULL, NULL, NULL)
INSERT [dbo].[Animales] ([nombre], [colorOjos], [edad], [peso], [sexo], [razaGatos], [esDomestico], [comportamiento], [raza], [tamanio], [subEspecie], [habitat]) VALUES (N'Max', N'Verde', 5, 5.5, 1, 5, 1, N'Curioso y juguetón', NULL, NULL, NULL, NULL)
INSERT [dbo].[Animales] ([nombre], [colorOjos], [edad], [peso], [sexo], [razaGatos], [esDomestico], [comportamiento], [raza], [tamanio], [subEspecie], [habitat]) VALUES (N'Daisy', N'Ámbar', 3, 4, 0, 9, 1, N'Independiente y tranquila', NULL, NULL, NULL, NULL)
INSERT [dbo].[Animales] ([nombre], [colorOjos], [edad], [peso], [sexo], [razaGatos], [esDomestico], [comportamiento], [raza], [tamanio], [subEspecie], [habitat]) VALUES (N'Leo', N'Amarillo', 4, 4.8, 1, 8, 1, N'Amigable y juguetón', NULL, NULL, NULL, NULL)
INSERT [dbo].[Animales] ([nombre], [colorOjos], [edad], [peso], [sexo], [razaGatos], [esDomestico], [comportamiento], [raza], [tamanio], [subEspecie], [habitat]) VALUES (N'Nala', N'Verde', 2, 3.7, 0, 1, 1, N'Curiosa y afectuosa', NULL, NULL, NULL, NULL)
INSERT [dbo].[Animales] ([nombre], [colorOjos], [edad], [peso], [sexo], [razaGatos], [esDomestico], [comportamiento], [raza], [tamanio], [subEspecie], [habitat]) VALUES (N'Rajah', N'Ambar', 36, 190, 1, NULL, NULL, NULL, NULL, NULL, 0, N'Bosques y praderas de la India')
INSERT [dbo].[Animales] ([nombre], [colorOjos], [edad], [peso], [sexo], [razaGatos], [esDomestico], [comportamiento], [raza], [tamanio], [subEspecie], [habitat]) VALUES (N'Maya', N'Ambar', 30, 160, 0, NULL, NULL, NULL, NULL, NULL, 9, N'Bosques tropicales de Malasia')
INSERT [dbo].[Animales] ([nombre], [colorOjos], [edad], [peso], [sexo], [razaGatos], [esDomestico], [comportamiento], [raza], [tamanio], [subEspecie], [habitat]) VALUES (N'Ravi', N'Verde', 42, 200, 1, NULL, NULL, NULL, NULL, NULL, 6, N'Isla de Java')
INSERT [dbo].[Animales] ([nombre], [colorOjos], [edad], [peso], [sexo], [razaGatos], [esDomestico], [comportamiento], [raza], [tamanio], [subEspecie], [habitat]) VALUES (N'Nina', N'Ambar', 15, 120, 0, NULL, NULL, NULL, NULL, NULL, 8, N'Isla de Bali')
INSERT [dbo].[Animales] ([nombre], [colorOjos], [edad], [peso], [sexo], [razaGatos], [esDomestico], [comportamiento], [raza], [tamanio], [subEspecie], [habitat]) VALUES (N'Tara', N'Verde', 54, 210, 0, NULL, NULL, NULL, NULL, NULL, 0, N'Bosques y praderas')
INSERT [dbo].[Animales] ([nombre], [colorOjos], [edad], [peso], [sexo], [razaGatos], [esDomestico], [comportamiento], [raza], [tamanio], [subEspecie], [habitat]) VALUES (N'Arjun', N'Ambar', 66, 230, 2, NULL, NULL, NULL, NULL, NULL, 7, N'Bosques de Siberia')
INSERT [dbo].[Animales] ([nombre], [colorOjos], [edad], [peso], [sexo], [razaGatos], [esDomestico], [comportamiento], [raza], [tamanio], [subEspecie], [habitat]) VALUES (N'maria', N'miel', 24, 23.8, 1, 2, 1, N'tranquila', NULL, NULL, NULL, NULL)
INSERT [dbo].[Animales] ([nombre], [colorOjos], [edad], [peso], [sexo], [razaGatos], [esDomestico], [comportamiento], [raza], [tamanio], [subEspecie], [habitat]) VALUES (N'Shira', N'Verde', 24, 150, 0, NULL, NULL, NULL, NULL, NULL, 7, N'Bosques de Siberia')
GO
```

# RESUMEN Y EXPLICACION DE LA FUNCION DE LA APLICACION

## EXPLICACION DE APP
Esta app está diseñada para que sea más fácil registrar y organizar los animales rescatados. con funciones para agregar, modificar, eliminar, ordenar y saber qué animal es el más pesado y cuál es el más viejo, para así poder tener un buen control sobre todos los animales ingresados en este registro. Se puede utilizar para refugios,zoologicos,etc. 
## LOGIN O INGRESO DE USUARIO
al ingresar o inicializar la app nos encontramos con este ingreso de usuario, en donde dependiendo del perfil del usuario va a analizar los permisos habilitados para este.

![LoginVista](https://github.com/macachana/chanampa.macarena.PrimerParcial/assets/123892029/3598c566-32db-4c66-9875-d7ebbc525e5e)

una vez que se verificara la identidad de la persona que quiere loguearse aparecerá el siguiente mensaje:

![MensajeInicializacion](https://github.com/macachana/chanampa.macarena.PrimerParcial/assets/123892029/9bb71035-1aae-43c3-96c7-359141b94dfe)

dependiendo de lo que se elija, se va a inicializar con la base de datos establecida o con archivos establecidos.

## PAGINA PRINCIPAL
### en la pagina principal se pueden encontrar varias opciones, ya sea ingresar un animal, modificar o eliminar un animal ya ingresado, ordenar alguna de las tres listas de animales ya sea por nombre (ascendente o descendente) o por edad (ascendente o ascendente), tambien podemos conectar una base de datos e incluso ver el registro de usuarios. 

## ( PAGINA PRINCIPAL INICIALIZADA CON ARCHIVOS JSON )

![Principal_Inicializado_JSON](https://github.com/macachana/chanampa.macarena.PrimerParcial/assets/123892029/973c7e5a-c2e7-46c6-9c3d-0a6ee2fd5466)

## ( PAGINA PRINCIPAL INICIALIZADA CON BASE DE DATOS )

![Principal_Inicializado_BaseDatos](https://github.com/macachana/chanampa.macarena.PrimerParcial/assets/123892029/f24e8a3d-51d9-49d3-a429-323f3408d92a)

### REGISTRO DE USUARIOS

![RegistroUsuariosVista](https://github.com/macachana/chanampa.macarena.PrimerParcial/assets/123892029/fcb9674e-2add-4a43-a576-f0c73a76cc0b)
