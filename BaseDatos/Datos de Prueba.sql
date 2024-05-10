/*
	Datos semilla para operar en la base de datos

	Autor: Jimmy Soza
	Alias: Jaso
*/

USE Ferreteria
GO
INSERT INTO Proveedor VALUES
('J0310000001812','Sinsa','22770070','periodista@sinsa.com.ni',15300,'Activo'),
('J0131000002311','Fetesa Doit Center','22649191','grupoventasweb@fetesa.com.ni',9500,'Activo'),
('J0310000432342','Ferreteria Richardson','22493777','ventas2_ricsa@gruporichardson.com.ni',18200,'Activo')
GO
INSERT INTO Cliente VALUES
(1),
(2),
(3),
(4),
(5),
(6),
(7),

(8),
(9),
(10),
(11),
(12),
(13),
(14),
(15),
(16),
(17)

GO

INSERT INTO ClienteNatural VALUES
(1,'Cliente','','Genérico','','','',''),
(2,'Omar', 'Roslyn', 'Whittles', 'Silverstone', '71623588', 'omar@hotmail.com','Barrio Morazan I-2'),
(3,'Lucas', 'Sancho', 'Keilloh', 'Feetham', '71948002', 'lucas@gmail.com','Residencial San Andres Casa M9'),
(4,'Addi', 'Moore', 'Este', 'Caddock', '86831074', 'addi@gmail.com','Barrio Cuba frente colegio Gaspar'),
(5,'Byron', 'Winthrop', 'Davidek', 'Oldcroft', '84641160', 'byron@hotmail.com','Residencial Guayacanes casa M2')
GO

INSERT INTO ClienteJuridico VALUES
(6,'Ferreteria Jerusalén','J0310000005602','Carlos','Salmeron','Vegas','','22798203','jerusalen@gmail.com','Cruce de Reyes 2 cuadras al este'),
(7,'Starling Constructions','J0310000045671','Pedro','Jose','Suarez','','88610538','starlingservices@gmail.com','Zona 10. Ciudad Sandino. Cancha Deportiva, 1c. N. 1/2c. O'),
(8,'Servicios Industriales','J0310000005641','Guillermo','Mariano','Melendez','','83870667','gerenteservicios@gmail.com','Brasiles frente Hotel Hacienda San Pedro')

GO

INSERT INTO ClienteNatural VALUES
(9,'Cory','Alejandro','Cuadra','Gomez','58902921','coryale@yahoo.com','Las brisas 3c al lago'),
(10,'Camila','Alexandra','García','Rodriguez','89007564','alexgarcia@gmail.com','Residencial San Andres Casa A1'),
(11,'Juan','Carlos','Escobar','','76895044','juan435@gmail.com','De la Presa 3c al lago, 2 y media arriba'),
(12,'Ney','','Obando','Pérez','79009854','neyperez201@gmail.com','Rontonda cristo rey 2c al lago'),
(13,'Maria','José','Ramirez','Rodriguez','89897864','demyjose4@gmail.com','Residencial guayacanes casa M-2'),
(14,'Moises','Brandon','López','Soza','87070032','moisesbrandon@yahoo.com','Praderas de Sandino casa H-8')
GO

INSERT INTO ClienteJuridico VALUES 
(15,'Vulcanizadora Chavez','J0310008381234','Alberto','Hugo','Chávez','Rodriguez','22567806','chavez@gmail.com','Km 14 carretera nueva León'),
(16,'Miscelanea Silva','J0310009876344','Camila','Alejandra','Silva','Montes','88769500','silvigerencia@gmail.com','farallones urbanizacion Miscelánea Silvia, acceso principal 4E, 15 ves N'),
(17,'Morgan construcciones','J0310000008731','Mario','','Cabrera','Ortiz','22811321','construccionesmorgan@hotmail.com','Terminal Granada-Oriental 1c al lago y 2c abajo')
GO

INSERT INTO Empleado VALUES
('Carlos','Manuel','Salmerón','Vegas','Gerente General',25300,'89290291','carlosvegas@gmail.com','Bello amanecer','Activo'),
('Luis','Alexander','Soza','Sanchez','Vendedor',9300,'88990765','luisalex@gmail.com','Praderas de Sandino III Etapa Casa I4','Activo'),
('Juan','Pablo','Orestes','Rodriguez','Vendedor',9300,'78902921','pabloro@gmail.com','Alcaldia de Managua 3C al este','Activo'),
('Adriana','Maricela','Cabrera','Rosales','Contador General',15400,'89007680','cabreramari@gmail.com','Colegio Villa Soberana 2 C al este y 1 al norte','Activo'),
('Fernando','Jose','Vegas','Bermudez','Jefe de Bodega',8300,'58998876','josevegas@gmail.com','Residencial Santa Eduviges 2C al norte Casa A3','Activo'),
('Jimmy','Alexander','Soza','Ortiz','Jefe de Sistemas',20000,'78029756','developjaso@gmail.com','Praderas de sandino Casa H-9','Activo'),
('Jeison','José','Suarez','Jiménez','Ayudante de Sistemas',20000,'57897800','jeisonsuarez@gmail.com','Barrio altagracia','Activo'),
('Anderson','David','Sánchez','Valecillo','Ayudante de Sistemas',22000,'87670081','anderson804@gmail.com','Pali Belmonte 2c al lago y 2c al este','Activo')
GO

INSERT INTO Departamento VALUES
('Chinandega','Pacífico'),
('León','Pacífico'),
('Managua','Pacífico'),
('Carazo','Pacífico'),
('Rivas','Pacífico'),
('Masaya','Pacífico'),
('Granada','Pacífico'),
('Boaco','Central'),
('Chontales','Central'),
('Estelí','Central'),
('Jinotega','Central'),
('Río San Juan','Central'),
('Madriz','Central'),
('Matagalpa','Central'),
('Nueva Segovia','Central'),
('Región Autónoma Norte','Atlántico'),
('Región Autónoma Sur','Atlántico')
GO

INSERT INTO Municipio VALUES
(1,'El Viejo'),
(1,'El Realejo'),
(1,'Corinto'),
(1,'Chichigalpda'),
(1,'Posoltega'),
(1,'Chinandega'),
(1,'Villanueva'),
(1,'Somotillo'),
(1,'San Pedro del Norte'),
(1,'Santo Tomás del Norte'),
(1,'Puerto Morazán'),
(1,'San Francisco del Norte'),
(1,'Cinco Pinos'),

(2,'Quezalguaque'),
(2,'León'),
(2,'Nagarote'),
(2,'Telica'),
(2,'La Paz Centro'),
(2,'Larreynaga'),
(2,'El Jiracal'),
(2,'Santa Rosa del Peñón'),
(2,'El Sauce'),
(2,'Achuapa'),

(3,'Managua'),
(3,'Ciudad Sandino'),
(3,'Villa El Carmen'),
(3,'San Rafael del Sur'),
(3,'El Crucero'),
(3,'Mateare'),
(3,'Ticuantepe'),
(3,'Tipitapa'),
(3,'San Francisco Libre'),

(4,'Diriamaba'),
(4,'San Marcos'),
(4,'Jinotepe'),
(4,'La Conquista'),
(4,'Santa Teresa'),
(4,'El Rosario'),
(4,'Dolores'),
(4,'La Paz de Oriente'),

(5,'Tola'),
(5,'Belén'),
(5,'Potosí'),
(5,'San Juan del Sur'),
(5,'Rivas'),
(5,'Cárdenas'),
(5,'Altagracia'),
(5,'Buenos Aires'),
(5,'Moyogalpa'),
(5,'San Jorge'),

(6,'Masaya'),
(6,'Nindirí'),
(6,'Tisma'),
(6,'La Concepción'),
(6,'Masatepe'),
(6,'Nandasmo'),
(6,'Niquinohomo'),
(6,'Catarina'),
(6,'San Juan de Oriente'),

(7,'Granada'),
(7,'Nandaime'),
(7,'Diriomo'),
(7,'Diriá'),

(8,'Boaco'),
(8,'Camoapa'),
(8,'Santa Lucía'),
(8,'San José de los Remates'),
(8,'Teustepe'),
(8,'San Lorenzo'),

(9,'Comalapa'),
(9,'Cuapa'),
(9,'Juigalpa'),
(9,'Acoyapa'),
(9,'El Coral'),
(9,'Villa Sandino'),
(9,'San Pedro de Lóvago'),
(9,'Santo Tomás'),
(9,'La Libertad'),
(9,'Santo Domingo'),

(10,'Estelí'),
(10,'San Juan de Limay'),
(10,'La Trinidad'),
(10,'San Nicolás'),
(10,'Pueblo Nuevo'),
(10,'Condega'),

(11,'San Sebastián de Yalí'),
(11,'La Concordia'),
(11,'San Rafael del Norte'),
(11,'Jinotega'),
(11,'Santa María de Pantasma'),
(11,'El Cuá'),
(11,'Wiwilí de Jinotega'),
(11,'San José de Bocay'),

(12,'Morrito'),
(12,'El Almendro'),
(12,'San Miguelito'),
(12,'San Carlos'),
(12,'El Castillo'),
(12,'San Juan del Norte'),

(13,'San José de Cusmapa'),
(13,'Las Sabanas'),
(13,'San Lucas'),
(13,'Somoto'),
(13,'Yalagüina'),
(13,'Totogalpa'),
(13,'Palacagüina'),
(13,'Telpaneca'),
(13,'San Juan de Rio Coco'),

(14,'San Isídro'),
(14,'Ciudad Darío'),
(14,'Sébaco'),
(14,'Terrabona'),
(14,'Matagalpa'),
(14,'San Dionisio'),
(14,'San Ramón'),
(14,'Esquipulas'),
(14,'Muy Muy'),
(14,'El Tuma - La Dalia'),
(14,'Matiguás'),
(14,'Rancho Grande'),
(14,'Río Blanco'),

(15,'Santa María'),
(15,'Macuelizo'),
(15,'Ocotal'),
(15,'Dipilto'),
(15,'Mozonte'),
(15,'Ciudad Antigua'),
(15,'San Fernando'),
(15,'El Jícaro'),
(15,'Jalapa'),
(15,'Quilalí'),
(15,'Murra'),
(15,'Jalapa'),
(15,'Wiwilí de Nueva Segovia'),

(16,'Waspán'),
(16,'Bonanza'),
(16,'Siuna'),
(16,'Waslala'),
(16,'Mulukukú'),
(16,'Rosita'),
(16,'Prinzapolka'),
(16,'Puerto Cabezas'),

(17,'Paiwas'),
(17,'El Ayote'),
(17,'La Cruz de Río Grande'),
(17,'El Tortuguero'),
(17,'Laguna de Perlas'),
(17,'El Rama'),
(17,'Kukra Hill'),
(17,'Muelle de los Bueyes'),
(17,'Nueva Guinea'),
(17,'Bluefields')
GO
--Producto: IdProducto, Nombre,Marca,Modelo,Peso,Contenido,Precio,U.D,U.R

INSERT INTO Producto VALUES
('Anticorrosivo industrial azul brillante','Modelo','Industrial',1,'Galón',793.3080,0,3,'Activo'),
('Anticorrosivo industrial gris brillante','Lanco','AC3438-4',1,'Galón',993.0011,0,2,'Activo'),
('Cemento fuerte','Holcim','',42.5,'Kilogramo',380,0,6,'Activo'),
('Máscara de protección para soldar','Pretul','26005',1,'Unidad',130,0,3,'Activo'),
('Candado pequeño 20 mm','Castor','',1,'Unidad','30',0,8,'Activo'),
('Cinta precaución','Acer','',1,'Unidad',172,5,2,'Activo'),

('Llave de Chorro 1/2 zinc','Metales Aleados','MET-011',1,'Unidad',136,0,2,'Activo'),
('LLave de Chorro 1/2 bronce','Metales Aleados','MET-010',1,'Unidad',146,0,2,'Activo'),
('Llave monomando p/lavamano mod.palencia','Metales Aleados','MET-027',1,'Unidad',475,0,2,'Activo'),

('Manguera abasto flexible p/regadera 150 cm acero inoxidable','Metales Aleados','MET-327',1,'Unidad',252,0,3,'Activo'),
('Palanca p/inodoro metal','Metales Aleados','BMR-W01',1,'Unidad',82,0,3,'Activo'),
('Tubo p/ducha 1/2"','Metales Aleados','BMR-T05',1,'Unidad',108,0,4,'Activo'),
('Manguera para lavadora 2 metros','Metales Aleados','BGR-H01',1,'Unidad',108,0,2,'Activo'),

--14
('Rejilla 2 pulgadas para baño','Metales Aleados','BMR-R02',1,'Unidad',79.5814,7,2,'Activo'),

--15
('Serrucho con mango de madera 18"','Trade Master','TM0201',1,'Unidad',215,6,1,'Activo'), --Costo 159.7764
('Cinta doble contacto extrafuerte 1" x yarda','3M','4873M082E',1,'Unidad',72.6593,7,2,'Activo'),--53.0810
('Cinta métrica con freno automático 7.5 metros','Trade Master','TM1018',1,'Unidad',302.0494,9,3,'Activo'),--251.7078

--18
('Rodillo pequeño para acabado fino de 6"','Foam Pro','87265648',1,'Unidad',276.8786,6,2,'Activo'),-- 251.707802

--19
('Pintura de aceite blanco brillante','Modelo', 'Arquitex',1,'Cubeta',3247.6788,1,1,'Activo'), --2952.4353
('Pintura de latex total blanco hueso mate','Lanco','Total',1,'Galón',2589.3999,1,1,'Activo'),--2232.2413
('LLave de chorro /pase 3/4"','Foset','CPVC',1,'Unidad',100,9,3,'Activo'),
('Bombilla fluorescente 6000 Hrs','Philips','12WE27656500K660LM',1,'Unidad',150,10,3,'Activo'),
('Extensión eléctrica 50 pies','Ace','126089434',1,'Unidad',742,4,1,'Activo'),

--24
('Martillo mango de madera 18 oz','Ace','100992781',1,'Unidad',293,9,2,'Activo'),
('Martillo mango de metal curvo 200 oz','Ace','100992772',1,'Unidad',415,5,1,'Activo'),
('Brocha de 3:','Modelo','Farbe artisan',1,'Unidad',200,8,2,'Activo'),
('Escoba c/palo 120 cm','Supertina','12687270',1,'Unidad',102,6,1,'Activo'),
('Mecate nylon en carrete 3/8"x300 pies blanco','Mibro','101162527',1,'Metro',85,4,1,'Activo')
GO

/*
	Precio de un producto:
	Precio = (Subtotal - Descuento) * (1 + Iva)
	Iva = (Precio * 0.85 - Precio * 0.85*d) * 0.15
*/

