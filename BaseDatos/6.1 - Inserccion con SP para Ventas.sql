/*
	Registro de Venta
	Nota: Presionar F5 y vas sobre
	Autor: Jimmy Soza
*/

USE Ferreteria
GO

EXEC Registrar_Venta 6,2
EXEC Registrar_DetVenta 17,3,0
EXEC Registrar_DetVenta 15,2,0
EXEC Registrar_DetVenta 1,1,0
EXEC Registrar_FacturaTemp '10/03/2019 9:47:00.000AM',0,'Entregado'

EXEC Registrar_Venta 7,2
EXEC Registrar_DetVenta 16,2,0
EXEC Registrar_FacturaTemp '17/03/2019 10:20:00.000AM',0,'Entregado'

EXEC Registrar_Venta 2,3
EXEC Registrar_DetVenta 15,1,0
EXEC Registrar_DetVenta 18,1,0
EXEC Registrar_FacturaTemp '19/03/2019 9:39:00.000AM',0,'Entregado'

EXEC Registrar_Venta 3,3
EXEC Registrar_DetVenta 14,1,0
EXEC Registrar_DetVenta 10,1,0
EXEC Registrar_DetVenta 8,2,0.01
EXEC Registrar_FacturaTemp '21/03/2019 1:32:00.000AM',0,'Entregado'

EXEC Registrar_Venta 5,2
EXEC Registrar_DetVenta 22,4,0
EXEC Registrar_FacturaTemp '24/03/2019 4:30:00.000AM',0,'Entregado'

EXEC Registrar_Venta 7,2
EXEC Registrar_DetVenta 23,2,.02
EXEC Registrar_DetVenta 3,3,0.02
EXEC Registrar_DetVenta 17,2,0.02
EXEC Registrar_FacturaTemp '29/03/2019 11:13:00.000AM',0,'Entregado'

EXEC Registrar_Venta 1,3
EXEC Registrar_DetVenta 10,1,0
EXEC Registrar_DetVenta 11,1,0
EXEC Registrar_DetVenta 21,2,0
EXEC Registrar_FacturaTemp '30/03/2019 2:13:00.000PM',0,'Entregado'

EXEC Registrar_Venta 1,3
EXEC Registrar_DetVenta 24,1,0
EXEC Registrar_DetVenta 26,2,0
EXEC Registrar_DetVenta 27,1,0
EXEC Registrar_FacturaTemp '16/04/2019 12:40:00.000PM',0,'Entregado' 

EXEC Registrar_Venta 6,2
EXEC Registrar_DetVenta 3,2,0
EXEC Registrar_DetVenta 30,2,0
EXEC Registrar_DetVenta 26,3,0
EXEC Registrar_FacturaTemp '20/04/2019 8:39:00.000AM',0,'Entregado'

EXEC Registrar_Venta 7,3
EXEC Registrar_DetVenta 32,4,0
EXEC Registrar_DetVenta 34,1,0
EXEC Registrar_DetVenta 26,2,0
EXEC Registrar_FacturaTemp '25/04/2019 8:20:00.000AM',0,'Entregado'

EXEC Registrar_Venta 4,3
EXEC Registrar_DetVenta 33,2,0
EXEC Registrar_DetVenta 35,10,0
EXEC Registrar_DetVenta 27,1,0
EXEC Registrar_FacturaTemp '27/04/2019 10:00:00.000AM',0,'Entregado'

EXEC Registrar_Venta 1,2
EXEC Registrar_DetVenta 5,3,0
EXEC Registrar_DetVenta 10,1,0
EXEC Registrar_DetVenta 22,2,0
EXEC Registrar_FacturaTemp '30/04/2022 1:30:00.000PM',0,'Entregado'

EXEC Registrar_Venta 7,3
EXEC Registrar_DetVenta 2,2,0
EXEC Registrar_DetVenta 31,1,0
EXEC Registrar_DetVenta 37,1,0
EXEC Registrar_DetVenta 38,2,0
EXEC Registrar_FacturaTemp '30/04/2022 3:33:00.000PM',0,'Entregado'

EXEC Registrar_Venta 5,3
EXEC Registrar_DetVenta 1,3,0.05
EXEC Registrar_DetVenta 3,3,0.05
EXEC Registrar_DetVenta 40,1,0.05
EXEC Registrar_FacturaTemp '02/05/2019 8:29:00.000AM',50,'Entregado'
EXEC Registrar_Envio 25,'Del cruce de los Reyes 2 cuadras abajo'

EXEC Registrar_Venta 6,2
EXEC Registrar_DetVenta 42,3,0
EXEC Registrar_DetVenta 40,1,0
EXEC Registrar_DetVenta 36,1,0
EXEC Registrar_FacturaTemp'08/05/2019 10:23:00.000AM',0,'Entregado'

EXEC Registrar_Venta 7,3
EXEC Registrar_DetVenta 39,2,0
EXEC Registrar_DetVenta 32,2,0
EXEC Registrar_DetVenta 38,2,0
EXEC Registrar_DetVenta 20,2,0.08
EXEC Registrar_FacturaTemp '10/05/2019 2:20:00.000PM',0,'Entregado'

EXEC Registrar_Venta 1,2
EXEC Registrar_DetVenta 35,8,0
EXEC Registrar_DetVenta 24,1,0
EXEC Registrar_DetVenta 26,1,0
EXEC Registrar_FacturaTemp '12/05/2019 12:58:00.000PM',0,'Entregado'

EXEC Registrar_Venta 2,2
EXEC Registrar_DetVenta 23,1,0
EXEC Registrar_DetVenta 28,2,0
EXEC Registrar_FacturaTemp '14/05/2019 3:20:00.000PM',0,'Entregado'

EXEC Registrar_Venta 3,2
EXEC Registrar_DetVenta 4,2,0
EXEC Registrar_FacturaTemp '16/05/2019 1:39:00.000PM',0,'Entregado'

EXEC Registrar_Venta 4,3
EXEC Registrar_DetVenta 8,3,0
EXEC Registrar_DetVenta 15,1,0
EXEC Registrar_DetVenta 17,1,0
EXEC Registrar_FacturaTemp '18/05/2019 2:12:00.000PM',0,'Entregado'

EXEC Registrar_Venta 1,2
EXEC Registrar_DetVenta 18,2,0
EXEC Registrar_DetVenta 21,2,0
EXEC Registrar_FacturaTemp '20/05/2019 11:11:02.000AM',0,'Entregado'

EXEC Registrar_Venta 3,3
EXEC Registrar_DetVenta 27,2,0
EXEC Registrar_DetVenta 33,1,0
EXEC Registrar_DetVenta 35,10,0
EXEC Registrar_DetVenta 41,2,0
EXEC Registrar_FacturaTemp '24/05/2019 1:05:00.000PM',0,'Entregado'

EXEC Registrar_Venta 6,2
EXEC Registrar_DetVenta 34,1,0
EXEC Registrar_DetVenta 36,1,0
EXEC Registrar_DetVenta 43,4,0
EXEC Registrar_DetVenta 45,4,0
EXEC Registrar_FacturaTemp '27/05/2019 8:56:00.000PM',0,'Entregado'

EXEC Registrar_Venta 7,3
EXEC Registrar_DetVenta 6,3,0
EXEC Registrar_DetVenta 17,3,0
EXEC Registrar_DetVenta 1,2,0
EXEC Registrar_FacturaTemp '29/05/2019 10:29:00.000AM',0,'Entregado'

EXEC Registrar_Venta 10,3
EXEC Registrar_DetVenta 3,6,0.05
EXEC Registrar_DetVenta 4,2,0
EXEC Registrar_FacturaTemp '01/06/2019 7:03:00.000AM',0,'Entregado'

EXEC Registrar_Venta 8,2
EXEC Registrar_DetVenta 22,3,0
EXEC Registrar_DetVenta 23,2,0
EXEC Registrar_DetVenta 26,1,0
EXEC Registrar_FacturaTemp '03/06/2019 11:20:00.000AM',0,'Entregado'

EXEC Registrar_Venta 8,3
EXEC Registrar_DetVenta 3,6,0.05
EXEC Registrar_DetVenta 4,2,0
EXEC Registrar_FacturaTemp '06/06/2019 01:31:00.000PM',0,'Entregado'

EXEC Registrar_Venta 10,3
EXEC Registrar_DetVenta 25,3,0.05
EXEC Registrar_DetVenta 33,1,0
EXEC Registrar_DetVenta 10,2,0
EXEC Registrar_DetVenta 34,1,0.1
EXEC Registrar_FacturaTemp '10/06/2019 12:08:00.000PM',0,'Entregado'

EXEC Registrar_Venta 12,2
EXEC Registrar_DetVenta 5,3,0
EXEC Registrar_DetVenta 18,2,0
EXEC Registrar_DetVenta 19,2,0
EXEC Registrar_DetVenta 26,2,0
EXEC Registrar_FacturaTemp '14/06/2019 2:31:00.000PM',0,'Entregado'

EXEC Registrar_Venta 1,2
EXEC Registrar_DetVenta 4,2,0
EXEC Registrar_DetVenta 6,1,0
EXEC Registrar_FacturaTemp '15/06/2019 10:02:00.000AM',0,'Entregado'

EXEC Registrar_Venta 1,2
EXEC Registrar_DetVenta 15,2,0
EXEC Registrar_DetVenta 16,1,0
EXEC Registrar_FacturaTemp '15/06/2019 12:07:00.000PM',0,'Entregado'

EXEC Registrar_Venta 1,2
EXEC Registrar_DetVenta 11,2,0
EXEC Registrar_DetVenta 14,2,0
EXEC Registrar_FacturaTemp '19/06/2019 09:30:00.000AM',0,'Entregado'

EXEC Registrar_Venta 7,3
EXEC Registrar_DetVenta 1,3,0
EXEC Registrar_DetVenta 31,1,0
EXEC Registrar_DetVenta 37,2,0.05
EXEC Registrar_FacturaTemp '21/06/2019 03:30:00.000PM',0,'Entregado'

EXEC Registrar_Venta 1,3
EXEC Registrar_DetVenta 39,3,0
EXEC Registrar_FacturaTemp '21/06/2019 04:30:00.000PM',0,'Entregado'

EXEC Registrar_Venta 10,2
EXEC Registrar_DetVenta 40,1,0
EXEC Registrar_FacturaTemp '26/06/2019 03:30:00.000PM',0,'Entregado'

EXEC Registrar_Venta 12,2
EXEC Registrar_DetVenta 28,4,0
EXEC Registrar_DetVenta 3,4,0
EXEC Registrar_DetVenta 6,1,0
EXEC Registrar_FacturaTemp '29/06/2019 12:24:00.000PM',0,'Entregado'

EXEC Registrar_Venta 13,3
EXEC Registrar_DetVenta 36,1,0
EXEC Registrar_DetVenta 44,1,0
EXEC Registrar_FacturaTemp '01/07/2019 11:20:00.000PM',0,'Entregado'

EXEC Registrar_Venta 4,3
EXEC Registrar_DetVenta 1,2,0
EXEC Registrar_DetVenta 37,1,0.02
EXEC Registrar_DetVenta 41,2,0
EXEC Registrar_FacturaTemp '01/07/2019 11:20:00.000PM',0,'Entregado'

EXEC Registrar_Venta 3,3
EXEC Registrar_DetVenta 40,2,0.05
EXEC Registrar_DetVenta 6,3,0
EXEC Registrar_DetVenta 16,4,0
EXEC Registrar_DetVenta 45,3,0.03
EXEC Registrar_FacturaTemp '03/07/2019 9:20:00.000AM',120,'Entregado'
EXEC Registrar_Envio 51, 'Terminal de buses UCA-Masaya 2 c al lago'

EXEC Registrar_Venta 10,2
EXEC Registrar_DetVenta 24,2,0
EXEC Registrar_DetVenta 27,3,0
EXEC Registrar_DetVenta 16,4,0
EXEC Registrar_DetVenta 45,3,0.03
EXEC Registrar_FacturaTemp '05/07/2019 01:20:00.000pM',120,'Entregado'
EXEC Registrar_Envio 51, 'Terminal de buses UCA-Masaya 2 c al lago'

--------------------