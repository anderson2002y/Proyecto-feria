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
('Activo'),
('Activo'),
('Activo'),
('Activo'),
('Activo'),
('Activo'),
('Activo'),

('Activo'),
('Activo'),
('Activo'),
('Activo'),
('Activo'),
('Activo'),
('Activo'),
('Activo'),
('Activo'),
('Activo')

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
('Fernando','Jose','Vegas','Bermudez','Bodega',8300,'58998876','josevegas@gmail.com','Residencial Santa Eduviges 2C al norte Casa A3','Activo'),
('Jimmy','Alexander','Soza','Ortiz','Administrador',20000,'78029756','developjaso@gmail.com','Praderas de sandino Casa H-9','Activo'),
('Jeison','José','Suarez','Jiménez','Administrador',20000,'57897800','jeisonsuarez@gmail.com','Barrio altagracia','Activo'),
('Anderson','David','Sánchez','Valecillo','Administrador',22000,'87670081','anderson804@gmail.com','Pali Belmonte 2c al lago y 2c al este','Activo')
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
--Producto: IdProducto, Nombre,Marca,Modelo,Peso,Contenido,Precio,U.D,U.O,U.R

INSERT INTO Producto VALUES
('Anticorrosivo industrial azul brillante','Modelo','Industrial',1,'Galón',793.3080,4,0,3,'Activo'),
('Anticorrosivo industrial gris brillante','Lanco','AC3438-4',1,'Galón',993.0011,4,0,2,'Activo'),
('Cemento fuerte','Holcim','',42.5,'Kilogramo',380,15,0,6,'Activo'),
('Máscara de protección para soldar','Pretul','26005',1,'Unidad',130,3,0,3,'Activo'),
('Candado pequeño 20 mm','Castor','',1,'Unidad','30',16,0,8,'Activo'),
('Cinta precaución','Acer','',1,'Unidad',172,5,0,2,'Activo'),

('Llave de Chorro 1/2 zinc','Metales Aleados','MET-011',1,'Unidad',136,2,0,2,'Activo'),
('LLave de Chorro 1/2 bronce','Metales Aleados','MET-010',1,'Unidad',146,5,0,2,'Activo'),
('Llave monomando p/lavamano mod.palencia','Metales Aleados','MET-027',1,'Unidad',475,5,0,2,'Activo'),

('Manguera abasto flexible p/regadera 150 cm acero inoxidable','Metales Aleados','MET-327',1,'Unidad',252,6,0,3,'Activo'),
('Palanca p/inodoro metal','Metales Aleados','BMR-W01',1,'Unidad',82,6,0,3,'Activo'),
('Tubo p/ducha 1/2"','Metales Aleados','BMR-T05',1,'Unidad',108,6,0,4,'Activo'),
('Manguera para lavadora 2 metros','Metales Aleados','BGR-H01',1,'Unidad',108,5,0,2,'Activo'),

--14
('Rejilla 2 pulgadas para baño','Metales Aleados','BMR-R02',1,'Unidad',79.5814,7,0,2,'Activo'),

--15
('Serrucho con mango de madera 18"','Trade Master','TM0201',1,'Unidad',215,6,0,1,'Activo'), --Costo 159.7764
('Cinta doble contacto extrafuerte 1" x yarda','3M','4873M082E',1,'Unidad',72.6593,7,0,2,'Activo'),--53.0810
('Cinta métrica con freno automático 7.5 metros','Trade Master','TM1018',1,'Unidad',302.0494,9,0,3,'Activo'),--251.7078

--18
('Rodillo pequeño para acabado fino de 6"','Foam Pro','87265648',1,'Unidad',276.8786,6,0,2,'Activo'),-- 251.707802

--19
('Pintura de aceite blanco brillante','Modelo', 'Arquitex',1,'Cubeta',3247.6788,1,0,1,'Activo'), --2952.4353
('Pintura de latex total blanco hueso mate','Lanco','Total',1,'Galón',2589.3999,1,0,1,'Activo'),--2232.2413
('LLave de chorro /pase 3/4"','Foset','CPVC',1,'Unidad',100,9,0,3,'Activo'),
('Bombilla fluorescente 6000 Hrs','Philips','12WE27656500K660LM',1,'Unidad',150,10,0,3,'Activo'),
('Extensión eléctrica 50 pies','Ace','126089434',1,'Unidad',742,4,0,1,'Activo'),

--24
('Martillo mango de madera 18 oz','Ace','100992781',1,'Unidad',293,9,0,2,'Activo'),
('Martillo mango de metal curvo 200 oz','Ace','100992772',1,'Unidad',415,5,0,1,'Activo'),
('Brocha de 3:','Modelo','Farbe artisan',1,'Unidad',200,8,0,2,'Activo'),
('Escoba c/palo 120 cm','Supertina','12687270',1,'Unidad',102,6,0,1,'Activo'),
('Mecate nylon en carrete 3/8"x300 pies blanco','Mibro','101162527',1,'Metro',85,4,0,1,'Activo')
GO

/*
	Precio de un producto:
	Precio = (Subtotal - Descuento) * (1 + Iva)
	Iva = (Precio * 0.85 - Precio * 0.85*d) * 0.15
*/

--IdProveedor,NoFactura,Fecha,Estado,Subtotal,Iva,Descuento,Total
INSERT INTO Compra VALUES
(1,'ABCD123','10-01-2019','Contado',661.09*4*0.85,0,661.09*4*0.15,661.09*4), --IdProducto=1,4
(1,'ABCD1234','13-01-2019','Contado',827.5009*6*0.85,0,827.5009*6*0.15,827.5009*6), --IdProducto=2,6
(1,'ACDC1342', '16-01-2019','Contado',108.3333*6*0.85,0,108.3333*6*0.15,108.3333*6),--IdProducto=4,6
(1,'ABCD1352', '25-01-2019','Contado',292.3077*20*0.85,(292.3077*20) * 0.85 * 0.05,(292.3077*20*0.85 - 292.3077*20*0.85*0.05) * 0.15, (292.3077*20*0.85 - 292.3077*20*0.85*0.05)*(1+0.15)),--IdProducto=3,20
(1,'FAG123','30-01-2019','Contado',(24 * 26 + 600 * 8) * 0.85, (24*26 + 600*8)*0.85*0.05,( (24*26 + 600*8)*0.85 - (24*26 + 600*8)*0.85*0.05) * 0.15, ( (24*26 + 600*8)*0.85 - (24*26 + 600*8)*0.85*0.05) * 1.15), --IdProducto= 5 y 1,24 y 8

--Producto 7,8 y 9
(2,'B-234','03-02-2019','Contado',(113.333333*5 + 120.6612*5 + 413.0435*5) * 0.85,0,(113.333333*5 + 120.6612*5 + 413.0435*5) * 0.15,113.333333*5 + 120.6612*5 + 413.0435*5),

--Producto  10
(2,'B-523','07-02-2019','Contado',210 * 5 *0.85,0,210*0.15*5,210*5),

--Producto 11,12,13
(2,'B-540','10-02-2019','Contado', (65.6 * 8 + 80 * 7 + 90 * 5 ) *0.85, 80 * 7 * 0.85 * 0.02,(65.6 * 8 + 90 * 5 ) *0.15 + (80 * 7 * 0.85 - 80*7*0.85*0.02) * 0.15,65.6 * 8 + (80*7*0.85 - 80*7*0.85*0.02) * (1+0.15) + 90 * 5 ),

(2,'B-555','12-02-2019','Contado', 58.9492 * 8 * 0.85,0,58.9492 * 8 * 0.15,58.9492 * 8),
(2,'B-599','15-02-2019','Contado',(159.7764*6 + 53.081 * 7 + 251.7078 * 9) * 0.85,0,(159.7764*6 + 53.081 * 7 + 251.7078 * 9) * 0.15,159.7764*6 + 53.081 * 7 + 251.7078 * 9),
(2,'ABC562','18-02-2019','Pagado',276.8786*6*0.85,0,276.8786*6*0.15,276.8786*6),
(1,'ABCD201','24-02-2019','Pagado', (2952.4353 * 3 + 2232.2413 * 3) * 0.85, (2952.4353 * 3 + 2232.2413 * 3) * 0.85 * 0.03, ((2952.4353 * 3 + 2232.2413 * 3) * 0.85 - (2952.4353 * 3 + 2232.2413 * 3) * 0.85 * 0.03)*0.15,((2952.4353 * 3 + 2232.2413 * 3) * 0.85 - (2952.4353 * 3 + 2232.2413 * 3) * 0.85 * 0.03)*1.15),

(1,'ABCD982','01-03-2019','Contado',(88.5839 * 9 + 126.0340 * 10) * 0.85,(88.5839 * 9 + 126.0340 * 10) * 0.85 * 0.02,((88.5839 * 9 + 126.0340 * 10) * 0.85 - (88.5839 * 9 + 126.0340 * 10) * 0.85 * 0.02)*0.15,((88.5839 * 9 + 126.0340 * 10) * 0.85 - (88.5839 * 9 + 126.0340 * 10) * 0.85 * 0.02)*1.15),
(1,'BBCD024','05-03-2019','Contado',675.1819 * 3 * 0.85,0,675.1819 * 3 * 0.15,675.1819 * 3),
(1,'BBCD029','9-03-2019','Contado',(254.9787 * 7 + 345.3330 * 5 + 161.3235 * 8) * 0.85,0,(254.9787 * 7 + 345.3330 * 5 + 161.3235 * 8) * 0.15,254.9787 * 7 + 345.3330 * 5 + 161.3235 * 8),
(1,'BBCH872','12-03-2019','Contado',(89.304056*6 + 64.0973*4)*0.85, 89.304056*6*0.85*0.01, (89.304056*6*0.85 - 89.304056*6*0.85*0.01)*0.15 + 64.0973*4*0.15, ((89.304056*6*0.85 - 89.304056*6*0.85*0.01) * 1.15 + 64.0973*4)),
(1,'CBDNS92','15-03-2019','Contado',(254.9787 * 6 + 675.1819*4)*0.85, 0,(254.9787 * 6 + 675.1819*4)*0.15,(254.9787 * 6 + 675.1819*4))

--IdProducto,IdCompra,Precio,Cantidad,Descuento,iva
--El precio de un producto de compra = Precio + iva
--Nota: El descuento se coloca antes del iva

--Precio = (PrecioSub - Descuento) + iva
INSERT INTO DetalleCompra VALUES
(1,1,661.09*0.85,4,0,661.09*0.15),
(2,2,827.5009*0.85,6,0,827.5009*0.15),
(4,3,108.3333*0.85,6,0,108.3333*0.15),
(3,4,292.3077*0.85,20,0.05, (292.3077*0.85 - 292.3077*0.85*0.05) * 0.15),
(5,5,24*0.85,26,0.05, (24*0.85-24*0.85*0.05)*0.15),
(1,5,600*0.85,8,0.05, (600*0.85-600*0.85*0.05)*0.15),
(7,6,113.333333*0.85,5,0,113.333333*0.15),
(8,6,120.6612*0.85,5,0,120.6612*0.15),
(9,6,413.0435*0.85,5,0,413.0435*0.15),
(10,7,210*0.85,5,0,210*0.15),
(11,8,65.6*0.85,8,0,65.6*0.15),
(12,8,80*0.85,7,0.02,(80*0.85-80*0.85*0.02)*0.15),
(13,8,90*0.85,5,0,90*0.15),
(14,9,58.9492*0.85,8,0,58.9492),
(15,10,159.7764*0.85,6,0,159.7764*0.15),
(16,10,53.081*0.85,7,0,53.081*0.15),
(17,10,251.7078*0.85,9,0,251.7078*0.15),
(18,11,276.8786*0.85,6,0,276.8786*0.15),
(19,12,2952.4353*0.85,3,0.03,(2952.4353*0.85 - 2952.4353*0.85*0.03)*0.15),
(20,12,2232.2413*0.85,3,0.03,(2232.2413*0.85 - 2232.2413*0.85*0.03)*0.15),
(21,13,88.5839*0.85,9,0.02,(88.5839*0.85 - 88.5839*0.85*0.02)*0.15),
(22,13,126.0340*0.85,10,0.02,(126.0340*0.85-126.0340*0.85*0.02)*0.15),
(23,14,675.1819*0.85,3,0,675.1819*0.15),
(24,15,254.9487*0.85,7,0,254.9487*0.15),
(25,15,345.333 * 0.85,5,0,345.333 * 0.15),
(26,15,161.3235*0.85,8,0,161.3235*0.15),
(27,16,89.304056*0.85,6,0.01, (89.304056*0.85 - 89.304056*0.85*0.01)*0.15),
(28,16,64.0973*0.85,4,0,64.0973*0.15),
(23,17,675.1819*0.85,4,0,675.1819*0.15),
(24,17,254.9787*0.85,6,0,254.9787*0.15)

GO

INSERT INTO CreditoPago VALUES
(11,'27-02-2019',276.8786*6),
(12,'03-03-2019',((2952.4353 * 3 + 2232.2413 * 3) * 0.85 - (2952.4353 * 3 + 2232.2413 * 3) * 0.85 * 0.03)*1.15 / 3),
(12,'10-03-2019',((2952.4353 * 3 + 2232.2413 * 3) * 0.85 - (2952.4353 * 3 + 2232.2413 * 3) * 0.85 * 0.03)*1.15 / 3),
(12,'17-03-2019',((2952.4353 * 3 + 2232.2413 * 3) * 0.85 - (2952.4353 * 3 + 2232.2413 * 3) * 0.85 * 0.03)*1.15 / 3)

INSERT INTO DevolucionCompra VALUES
(5,'31-01-2019',3,'Al abrir el empaque se rompio la cerradura','Recibido'),
(13,'12-02-2019',2,'Las mangueras venian con daños superficiales','Recibido'),
(13,'28/02/2019',1,'Avería interna en la llave al momento de su uso','Recibido')
GO
INSERT INTO Venta VALUES
(3,2),
(4,2),
(2,3),
(4,2),
(1,3),
(2,3),
(4,2),
(7,2),
(6,3),
(7,3)
GO
INSERT INTO DetalleVenta VALUES
(1,3,8,380,0),
(1,2,2,993.0011,0),

(2,3,8,380,0),

(3,7,2,136,0),
(3,10,1,252,0),

(4,5,2,30,0),

(5,4,3,130,0),

(6,12,1,108,0),
(6,11,2,82,0),

(7,7,3,146,0),
(7,10,1,252,0),
(7,14,1,79.5814,0),
(8,6,3,172,0),

(9,19,2,3247.6788,0.02),
(9,20,2,2589.3999,0.02),

(10,24,4,293,0),
(10,23,3,742,0)
GO
--Idventa,NoFactura,Fecha,Subtotal,CostoEnvio,Descuento,Total,Estado
INSERT INTO Factura VALUES
(1,1,'26/01/2019 9:30:35.000 AM',380*5 + 993.0011*2 ,0,0,380*8 + 993.0011*2,'Entregado'),
(2,2,'28/01/2019 8:30:32.000 AM',380*5,0,0,380*8,'Entregado'),
(3,3,'7/02/2019 2:15:00.000 PM',136*2 + 252*1,0,0,136*2 + 252*1,'Entregado'),
(4,4,'31/01/2019 8:46:32.000 AM',30 * 2,0,0, 30 * 2, 'Entregado'),
(5,5,'01/02/2019 10:26:10.000 AM',130 * 3, 0,0,130 * 3, 'Entregado'),
(6,6,'25/02/2019 1:25:12.000 PM',108 * 1 + 82 * 2 , 0, 0, 108 * 1 + 82 * 2,'Entregado'),
(7,7,'26/02/2019 3:28:12.000 PM', 146 * 3 + 79.5814 * 1 + 252 * 1, 0,0, 146 * 3 + 79.5814 * 1 + 252 * 1, 'Entregado'), --Llave de C 1/2 zinc, Manguera abasto,
(8,8,'28/02/2019 8:56:00.000 AM',172 * 3,20,0,172*3 + 20,'Entregado'),
(9,9,'02/03/2019 7:59:00.000 AM',3247.6788 * 2 + 2589.3999 * 2,40, (3247.6788 * 2 + 2589.3999 * 2) * 0.02, 3247.6788 * 2 + 2589.3999 * 2 - (3247.6788 * 2 + 2589.3999 * 2)*0.02 + 40,'Entregado'),
(10,10,'08/03/2019 10:23:00.000 AM',293*4 + 742*3,0,0,293*4 + 742*3,'Entregado')
GO

INSERT INTO Envio VALUES
(8,25,'Entrada de Ciudad Sandino 4c abajo, mano derecha'),
(9,25,'Alcanldia de Ciudad Sandino 3 cuadras arriba 1 al sur')

--IdFactura,IdProducto,Fecha,Monto,Cantidad,Observacion,Estado
INSERT INTO DevolucionVenta VALUES
(7,10,'27/02/2019',252,1,'Al momento de su uso, no salia el agua','Entregado')