CREATE DATABASE ptcuentabanco
use ptcuentabanco

CREATE TABLE tarjeta( 
id_tarjeta INT NOT NULL PRIMARY KEY IDENTITY(1,1),
num_tarjeta  VARCHAR(16) NOT NULL,
nombre_cliente VARCHAR(100) NOT NULL,
apellido_cliente VARCHAR(100) NOT NULL,
saldo_inicial DECIMAL(10,2) NOT NULL,
limite_credito DECIMAL(10,2) NOT NULL,
);

--**tipo_transaccion int: 0= Cargo, 1 = Abono***
CREATE TABLE transacciones( 
id_transaccion INT NOT NULL PRIMARY KEY IDENTITY(1,1),
id_tarjeta INT NOT NULL,
fecha_transaccion DATE NOT NULL,
descripcion VARCHAR(100) NOT NULL,
monto DECIMAL(10,2) NOT NULL,
tipo_transaccion int NOT NULL,
num_autorizacion  VARCHAR(100) NOT NULL

);

ALTER TABLE transacciones ADD FOREIGN KEY(id_tarjeta) REFERENCES tarjeta(id_tarjeta)

SELECT * FROM tarjeta
SELECT * FROM transacciones

--*************** PROCEDIMIENTOS ALMACENADOS TARJETA**************--
--***SP INSERTAR TARJETA*****--
CREATE PROCEDURE sp_addTarjeta(
@num_tarjeta VARCHAR(16),
@nombre_cliente VARCHAR(100),
@apellido_cliente VARCHAR(100),
@saldo_inicial DECIMAL(10,2),
@limite_credito DECIMAL(10,2)

)
AS 
BEGIN

INSERT INTO tarjeta(num_tarjeta,nombre_cliente,apellido_cliente,saldo_inicial,limite_credito)
VALUES
(
@num_tarjeta,
@nombre_cliente,
@apellido_cliente,
@saldo_inicial,
@limite_credito

)
end

--***SP MODIFICAR TARJETA*****--
CREATE PROCEDURE sp_modificarTarjeta(
@id_tarjeta INT,
@num_tarjeta VARCHAR(16),
@nombre_cliente VARCHAR(100),
@apellido_cliente VARCHAR(100),
@saldo_inicial DECIMAL(10,2),
@limite_credito DECIMAL(10,2)

)
AS 
BEGIN

UPDATE tarjeta set
num_tarjeta = @num_tarjeta,
nombre_cliente = @nombre_cliente,
apellido_cliente = @apellido_cliente,
saldo_inicial = @saldo_inicial,
limite_credito = @limite_credito
WHERE id_tarjeta = @id_tarjeta

END

--***SP OBTENER TARJETA ESPECIFICA*****--
CREATE PROCEDURE sp_obtenerTarjeta(@id_tarjeta int)
AS 
BEGIN

SELECT * FROM tarjeta where id_tarjeta = @id_tarjeta
END

--***SP LISTAR TARJETA*****--
CREATE PROCEDURE sp_listarTarjeta
AS 
BEGIN

SELECT * FROM tarjeta
END

--***SP ELIMINAR TARJETA*****--
CREATE PROCEDURE sp_eliminarTarjeta(
@id_tarjeta int 
)
AS BEGIN 

DELETE FROM tarjeta WHERE id_tarjeta = @id_tarjeta
END

--*************** PROCEDIMIENTOS ALMACENADOS TRANSACCIONES**************--
--***SP INSERTAR TRANSACCION*****--
CREATE PROCEDURE sp_addTransaccion(
@id_tarjeta INT,
@fecha_transaccion DATE,
@descripcion VARCHAR(100),
@monto DECIMAL(10,2),
@tipo_transaccion int ,
@num_autorizacion  VARCHAR(100) 

)
AS 
BEGIN

INSERT INTO transacciones(id_tarjeta,fecha_transaccion,descripcion,monto,tipo_transaccion,num_autorizacion)
VALUES
(
@id_tarjeta,
@fecha_transaccion,
@descripcion,
@monto,
@tipo_transaccion,
@num_autorizacion  

)
end

--***SP MODIFICAR TRANSACCION*****--
CREATE PROCEDURE sp_modificarTransaccion(
@id_transaccion int, 
@id_tarjeta INT,
@fecha_transaccion DATE,
@descripcion VARCHAR(100),
@monto DECIMAL(10,2),
@tipo_transaccion int ,
@num_autorizacion  VARCHAR(100) 

)
AS 
BEGIN

UPDATE transacciones set
id_tarjeta = @id_tarjeta, 
fecha_transaccion = @fecha_transaccion, 
descripcion = @descripcion,
monto = @monto,
tipo_transaccion = @tipo_transaccion,
num_autorizacion = @num_autorizacion 
WHERE id_transaccion =@id_transaccion

END

--***SP OBTENER TRANSACCION ESPECIFICA*****--
CREATE PROCEDURE sp_obtenerTransaccion(@id_transaccion int)
AS 
BEGIN

SELECT * FROM transacciones where id_transaccion = @id_transaccion
END

--***SP LISTAR TRANSACCION*****--
CREATE PROCEDURE sp_listarTransaccion
AS 
BEGIN

SELECT * FROM transacciones
END

--***SP ELIMINAR TRANSACCION*****--
CREATE PROCEDURE sp_eliminarTransaccion(
@id_transaccion int 
)
AS BEGIN 

DELETE FROM transacciones WHERE id_transaccion = @id_transaccion
END
