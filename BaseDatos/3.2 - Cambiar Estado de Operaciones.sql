use Ferreteria
GO

---Cambiar estado de facturas
CREATE procedure Cambiar_EstadoFactura
@IdFactura int
AS
IF exists (
           SELECT
		   *
		   FROM Factura WHERE IdFactura = @IdFactura and Estado = 'Facturado'
           )
BEGIN
UPDATE Factura SET
Estado = 'Entregado' WHERE IdFactura = @IdFactura
END
ELSE if exists (SELECT
		        *
		        FROM Factura WHERE IdFactura = @IdFactura and Estado = 'Entregado')
BEGIN
UPDATE Factura SET
Estado = 'Anulado' WHERE IdFactura = @IdFactura
END

CREATE procedure CambiarEstado_DevolucionVenta
@IdDevolucion int
AS
IF exists (
           SELECT
		   *
		   FROM DevolucionVenta WHERE IdDevolucion = @IdDevolucion and Estado = 'Aceptado'
           )
BEGIN
UPDATE DevolucionVenta SET
Estado = 'Entregado' WHERE IdDevolucion = @IdDevolucion
END
ELSE
BEGIN
UPDATE DevolucionVenta SET
Estado = 'Aceptado' WHERE IdDevolucion= @IdDevolucion
END

------------------------------------------------------------------------------------------------
CREATE procedure CambiarEstado_DevolucionCompra
@IdDevolucion int
AS
IF exists (
           SELECT
		   *
		   FROM DevolucionCompra WHERE IdDevolucion = @IdDevolucion and Estado = 'Aceptado'
           )
BEGIN
UPDATE DevolucionCompra SET
Estado = 'Recibido' WHERE IdDevolucion = @IdDevolucion
END
ELSE
BEGIN
UPDATE DevolucionCompra SET
Estado = 'Aceptado' WHERE IdDevolucion= @IdDevolucion
END