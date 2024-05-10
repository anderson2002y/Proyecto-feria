/*
	Registro de compra semillas con funciones, triggers y SP

	Nota: Presionar F5 y dejar que inserte
	Autor: Jimmy Soza
*/
USE Ferreteria
GO

EXEC Insertar_Producto 'Pintura esmalte negro brillante estandar','Modelo','Fast Dry',1,'Cubeta',6957.0740,1 --5797.5617
EXEC Insertar_Producto 'Mortero nivelador capa gruesa','Drytec','',40,'Kilogramo',250,4 -- 207.7759
EXEC Insertar_Producto 'Sikadur 31 Adhesivo epóxico','Sika','',1,'Kilogramo',1500,2 -- 1170.3153
EXEC Insertar_Producto 'Cemento gris uso general','Cemex','',42.5,'Kilogramo',477,4 --414.8317
EXEC Insertar_Producto 'Limpiador para madera y laminados','Fila','',500,'Mililitro',662,3 --576.1552
EXEC Insertar_Producto 'Limpiador desengrasante','Fila','PS/87',1.32,'Galón',4500,2 --3600.97
EXEC Insertar_Producto 'Remache para ventana','','',1,'Unidad',1,6 --0.7202
EXEC Insertar_Producto 'Mortero acabado bco','Sur','MD-450',35.8,'Kilogramo',670,4 --516.7392
EXEC Insertar_Producto 'Carretilla para construcción naranja y negro','Truper','',1,'Unidad',3000,1 --2538.3238
EXEC Insertar_Producto 'Llanta solida negra para carretilla bulto','Truper','',1,'Unidad',424,4--360.0970
EXEC Insertar_Producto 'Plastico negro 48" alto calibre 1000','','',1,'Yarda',70,4 --68.0583
EXEC Insertar_Producto 'Escalera tijera de aluminio 4 pies 200 libras','Scala','M09',1,'Unidad',2300,1 --1976.5724
EXEC Insertar_Producto 'Guante de nitrillo talla "M"','Milwaukee','Corte nivel 1',1,'Unidad',200,4 --160
EXEC Insertar_Producto 'Cinta de señalización amarilla y negro 48mm X 33m','Truper','C923B',1,'Unidad',165,3--144.0388
EXEC Insertar_Producto 'Chaleco de seguridad verde en forma de "V"','Best Value','',1,'Unidad',180,5 --154.1215
EXEC Insertar_Producto 'Máscara rehusable 2 filtros negra','Pretul','23391',1,'Unidad',330,3 --273.3136
EXEC Insertar_Producto 'Cono de seguridad 18" plastico','Stanley','2883',1,'Unidad',470,5--406.1894

--TODO realizar compras
--Compra 18
EXEC Registrar_Compra 1,'Contado','CBDHS98','17-03-2019'
EXEC Registrar_DetCompra 5,8,0,25
EXEC Registrar_DetCompra 29,2,0,5797.5617
EXEC Registrar_DetCompra 30,8,0,207.7759
EXEC Registrar_DetCompra 31,4,0,1170.3153
 

EXEC Registrar_Compra 1,'Contado','CBMDN11','20-03-2019'
EXEC Registrar_DetCompra 32,10,0.02,414.8317
EXEC Registrar_DetCompra 33,6,0.02,576.1552


EXEC Registrar_Compra 1,'Contado','CMDBA11','25-03-2019'
EXEC Registrar_DetCompra 34,5,0,3600.97


EXEC Registrar_Compra 1,'Contado','CNDA092','30-03-2019'
EXEC Registrar_DetCompra 35,50,0,0.7202
exec Registrar_DetCompra 36,6,0.05,516.7392


EXEC Registrar_Compra 1,'Contado','CNDB293','01-04-2019'
EXEC Registrar_DetCompra 1,5,0.05,661.09
EXEC Registrar_DetCompra 4,8,0.05,108.3333
EXEC Registrar_DetCompra 19,2,0.05,2952.4353
EXEC Registrar_DetCompra 20,3,0.05,2232.2413


EXEC Registrar_Compra 2,'Contado','B-10234','02-04-2019'
EXEC Registrar_DetCompra 23,6,0.05,648.2222
EXEC Registrar_DetCompra 7,5,0.05,89.30
EXEC Registrar_DetCompra 8,5,0.05,95
EXEC Registrar_DetCompra 11,4,0.05,48.0877
EXEC Registrar_DetCompra 17,5,0.05,240.2362


EXEC Registrar_Compra 2,'Contado','B-10092','05-04-2019'
EXEC Registrar_DetCompra 37,3,0,2538.3238
EXEC Registrar_DetCompra 38,10,0,360.0970


EXEC Registrar_Compra 2,'Contado','B-11433','15-04-2019'
EXEC Registrar_DetCompra 39,10,0,68.0583
EXEC Registrar_DetCompra 40,3,0,1976.5724


exec Registrar_Compra 1,'Contado','CMBD012','28-04-2019'
EXEC Registrar_DetCompra 41,8,0,160
exec Registrar_DetCompra 42,8,0,144.0388


EXEC Registrar_Compra 1,'Contado','CMBP189','10-05-2019'
EXEC Registrar_DetCompra 43,9,0.04,154.1215
EXEC Registrar_DetCompra 44,7,0.05,273.3136


EXEC Registrar_Compra 1,'Crédito','CDPA02','15-05-2019'
EXEC Registrar_DetCompra 45,12,0.05,505
exec Registrar_PagoCredito 11,'22-05-2019',2000
EXEC Registrar_PagoCredito 11,'28-05-2019',1300


EXEC Registrar_Compra 1,'Contado','CBDPA21','01-06-2019'
EXEC Registrar_DetCompra 1,6,0.05,700
EXEC Registrar_DetCompra 2,6,0.05,910.05
EXEC Registrar_DetCompra 3,10,0.05,310
EXEC Registrar_DetCompra 22,8,0.05,89.6421


EXEC Registrar_Compra 2,'Contado','B-APCA2','02-06-2019'
EXEC Registrar_DetCompra 26,10,0.05,132.31
EXEC Registrar_DetCompra 27,6,0.05,68
EXEC Registrar_DetCompra 28,7,0.05,43.50
EXEC Registrar_DetCompra 33,6,0.05,515
EXEC Registrar_DetCompra 40,6,0.05,1793.0231


EXEC Registrar_Compra 1,'Contado','CBMNA02','05-06-2019'
EXEC Registrar_DetCompra 6,8,0,102.0831
EXEC Registrar_DetCompra 10,5,0,204.9312
EXEC Registrar_DetCompra 12,10,0,64.0921
EXEC Registrar_DetCompra 13,8,0,72.9831
EXEC Registrar_DetCompra 15,5,0,135.8291
EXEC Registrar_DetCompra 16,6,0,48.9213
EXEC Registrar_DetCompra 17,6,0,252.9876
EXEC Registrar_DetCompra 18,5,0,214.9312


--Cotizaciones de Fetesa
EXEC Insertar_Producto 'Alicate 5"','Smart Savers','314900',1,'Unidad',64,3 --51.133774
EXEC Insertar_Producto 'Alicate de electricista profesional 9"','Stanley','B4-52',1,'Unidad',1277,2 --1020.874995
EXEC Insertar_Producto 'Alicate punta larga pela cable Pro 6"','Stanley','84-053',1,'Unidad',225,3 --223.26014
EXEC Insertar_Producto 'Atornillador de tablaroca','Dewalt','',1,'Unidad',4300,3 --3887.607212
EXEC Insertar_Producto 'Cable pasa corriente 200 amp 10 awg 8 pies','Best Value','',1,'Unidad',427,4--384.583596
EXEC Insertar_Producto 'Caja de herramientas 12"','Aksi','111711',1,'Unidad',150,3 --134.316181
EXEC Insertar_Producto 'Caja de herramientas 19"','Aksi','111713',1,'Unidad',467,2--427.2332
EXEC Insertar_Producto 'Candado de hierro 38 mm plata','Fanal','FH38-S',1,'Unidad',90,4 --70
EXEC Insertar_Producto 'Cepillo de alambre 4 lineas','Best Value','',1,'Unidad',135,3 --110.189682
EXEC Insertar_Producto 'Cepillo de alambre 5 lineas','Best Value','',1,'Unidad',150,3 --115.10
EXEC Insertar_Producto 'Desarmador basic plano 1/4" x 4"','Stanley','',1,'Unidad',60,3 --46.092416
EXEC Insertar_Producto 'Destornillador estrella 1/4"x8"','Maxtool','300206',1,'Unidad', 60,3 --46.0924
EXEC Insertar_Producto 'Espátula de 2 1/2"','Best Value','',1,'Unidad',70,2 --57.975617
EXEC Insertar_Producto 'Espátula de 3"','Best Value','',1,'Unidad',80,2 --65.537654
EXEC Insertar_Producto 'Mazo de madera de goma','Stanley','',1,'Unidad', 185,3 -- 150
EXEC Insertar_Producto 'Medidor de distancia laser 30 metros','Stanley','77-138',1,'Unidad',7500,1 --6903.4196
EXEC Insertar_Producto 'Pala de aluminio clásico','Lmacasa','11425A12',1,'Unidad',1500,3 --1377.7713
EXEC Insertar_Producto 'Piocha con mango madera 5 lbs','Lmacasa','1070150',1,'Unidad',1015,2 --924.729096
EXEC Insertar_Producto 'Rastrillo de uso pesado 12 dientes','Lmacasa','196512',1,'Unidad',600,1 --540
EXEC Insertar_Producto 'Tijera cortar metal hojalatero 12"','Best Value','',1,'Unidad',600,4--540

--SIMSA
EXEC Insertar_Producto 'Anticorrosivo rojo semibrillante intermedia','Sur','Corrostop',1,'Cuarto',240,5 --200
EXEC Insertar_Producto 'Anticorrosivo rojo semibrillante intermedia','Sur','Corrostop',1,'Galón',780,3 --679.5212
EXEC Insertar_Producto 'Anticorrosivo gris standar brillante','Modelo','Optima Anticorrosivo',1,'Cuarto',600,3 --521.9310
EXEC Insertar_Producto 'Anticorrosivo gris claro standar brillante','Modelo','Optima Anticorrosivo',1,'Galón',1200,3--1009.2716

EXEC Registrar_Compra 1,'Contado','CBMNA02','10-06-2019'
EXEC Registrar_DetCompra 8,3,0,130
EXEC Registrar_DetCompra 9,4,0,204.9312
EXEC Registrar_DetCompra 10,5,0.12,64.0921
EXEC Registrar_DetCompra 11,2,0,72.9831


EXEC Registrar_Compra 2,'Contado','C-KNA93','14-06-2019'
EXEC Registrar_DetCompra 46,8,0.1,50
EXEC Registrar_DetCompra 47,3,0.1,1130
EXEC Registrar_DetCompra 48,6,0.1,187.2


EXEC Registrar_Compra 2,'Contado','C-MNA02','20-06-2019'
EXEC Registrar_DetCompra 49,5,0.08,3500


EXEC Registrar_Compra 2,'Contado','D-DAD92','28-06-2019'
EXEC Registrar_DetCompra 50,5,0.9,400
EXEC Registrar_DetCompra 51,5,0.9,95
EXEC Registrar_DetCompra 52,5,0.9,415
EXEC Registrar_DetCompra 53,5,0.9,58.5
EXEC Registrar_DetCompra 54,5,0.9,67.2


EXEC Registrar_Compra 1,'Contado','LMAQE21','30-06-2019'
EXEC Registrar_DetCompra 55,5,0.2,97.4
EXEC Registrar_DetCompra 56,5,0,35
EXEC Registrar_DetCompra 57,5,0,30
EXEC Registrar_DetCompra 58,5,0.2,40
EXEC Registrar_DetCompra 59,5,0.2,59


EXEC Registrar_Compra 1,'Contado','MQAIW1Q','01-07-2019'
EXEC Registrar_DetCompra 3,10,0.05,330
EXEC Registrar_DetCompra 16,5,0.05,55
EXEC Registrar_DetCompra 19,2,0.05,2985


EXEC Registrar_Compra 1,'Contado','MQAQE21','04-07-2019'
EXEC Registrar_DetCompra 60,10,0.05,138


EXEC Registrar_Compra 2,'Contado','D-ADMS1','08-07-2019'
EXEC Registrar_DetCompra 61,3,0.20,7000


EXEC Registrar_Compra 2,'Contado','D-MDJQ5','15-07-2019'
EXEC Registrar_DetCompra 62,5,0.08,1280


EXEC Registrar_Compra 2,'Contado','D-JAWQ1','15-07-2019'
EXEC Registrar_DetCompra 63,5,0.08,1280


EXEC Registrar_Compra 1,'Contado','CKAMSO','19-07-2019'
EXEC Registrar_DetCompra 64,2,0,500.23
EXEC Registrar_DetCompra 65,6,0,460.10
EXEC Registrar_DetCompra 66,6,0,176.5


EXEC Registrar_Compra 3,'Contado','MQAOPQ','25-07-2019'
EXEC Registrar_DetCompra 37,2,0.15,2689
EXEC Registrar_DetCompra 45,6,0.05,402
EXEC Registrar_DetCompra 19,2,0.05,2985
EXEC Registrar_DetCompra 64,4,0,500
EXEC Registrar_DetCompra 3,10,0,300


EXEC Registrar_Compra 1,'Contado','DIAWSA','01-08-2019'
EXEC Registrar_DetCompra 67,5,0.15,678
EXEC Registrar_DetCompra 68,5,0.15,530
EXEC Registrar_DetCompra 69,5,0.15,890


EXEC Registrar_Compra 3,'Contado','DIAWSA','06-08-2019'
EXEC Registrar_DetCompra 29,1,0.15,6300
EXEC Registrar_DetCompra 36,5,0.20,525
EXEC Registrar_DetCompra 37,2,0.15,2489.031
