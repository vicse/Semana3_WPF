use neptuno;

------------------------------
Ejemplo1
------------------------------

create procedure USP_FECHAFECHA
@FEC1 datetime,
@FEC2 datetime
as
select * from Pedidos where FechaPedido between @FEC1 and @FEC2 

create procedure USP_DETALLE
@IdPedido int
as
select * from detallesdepedidos where idpedido = @IdPedido

create procedure USP_TOTAL
@IdPedido int,
@Total money output
as
begin
select @Total = SUM(preciounidad*cantidad) - descuento from detallesdepedidos
where idpedido = @IdPedido
group by idpedido,descuento
end

DECLARE @Total Money
exec USP_TOTAL 10248, @TOTAL output
select @Total

------------------------------
Ejemplo3 

exec Usp_ListaClientes_Neptuno_SinFiltro

------------------------------