Use [GD1C2013]    /* Utilizamos una base de datos EXTERNA,la base a la cual se dirigiran las proximas consultas SQL en el proceso actual. */
Go 
/* Signo de finalizacion de lotes de sentencia*/

Create Schema DATACENTER AUTHORIZATION [gd]   /* Creamos un Schema nuevo(Modelo de Datos/contiene Tablas,Indices y demas estructuras de negocio) ; El usuario que poseera el schema (OWNER) sera: GD*/   
Go

/*------------------INICIO DE CREACION DE TABLAS--------------------*/

/*------------------------------------------------------------------*/
/*-----------------------CREAMOS TABLA FUNC-------------------------*/

CREATE TABLE DATACENTER.Funcionalidad
(func_id int IDENTITY (1,1) PRIMARY KEY NOT NULL,
func_nombre nvarchar(255) NOT NULL)
GO

/*------------------------------------------------------------------*/
/*------------------------CREAMOS TABLA ROL-------------------------*/

CREATE TABLE DATACENTER.Rol
(rol_id int IDENTITY (1,1) PRIMARY KEY NOT NULL,
rol_nombre nvarchar(255) NOT NULL,
rol_estado char NOT NULL)
GO

/*------------------------------------------------------------------*/
/*----------------CREAMOS TABLA FUNCXROL----------------------------*/

CREATE TABLE DATACENTER.FuncionalidadPorRol
(fxrol_rol_id int NOT NULL, 
fxrol_func_id int NOT NULL, 
fxrol_estado char NOT NULL,
FOREIGN KEY(fxrol_rol_id) references DATACENTER.Rol (rol_id),
FOREIGN KEY(fxrol_func_id) references DATACENTER.Funcionalidad (func_id),
PRIMARY KEY (fxrol_rol_id, fxrol_func_id)
)
GO


/*------------------------------------------------------------------*/
/*-----------------CREAMOS TABLA ADMINISTRADOR----------------------*/

CREATE TABLE DATACENTER.Administrador
(adm_username nvarchar(255) NOT NULL,
adm_password nvarchar(255) NOT NULL, --FALTA CIFRADO DE CLAVE
adm_cant_intentos int NOT NULL, 
adm_rol_id int NOT NULL, 
PRIMARY KEY (adm_username),
FOREIGN KEY (adm_rol_id) REFERENCES DATACENTER.Rol (rol_id))
GO

/*------------------------------------------------------------------*/
/*-----------------CREAMOS TABLA CLIENTE----------------------------*/

CREATE TABLE DATACENTER.Cliente
(cli_dni numeric(18,0) NOT NULL,
cli_rol_id int NOT NULL DEFAULT 2, --Los Clientes tienen ID_ROL = 2
cli_nombre nvarchar(255) NULL,
cli_apellido nvarchar(255) NULL,
cli_dir nvarchar(255) NULL,
cli_telefono nvarchar(255) NULL,
cli_mail nvarchar(255) NULL, 
cli_fecha_nac datetime NULL,
cli_puntos_acum int NULL,
cli_condicion char NULL,
cli_sexo char NULL,
FOREIGN KEY (cli_rol_id) REFERENCES DATACENTER.Rol (rol_id),
PRIMARY KEY (cli_dni))
GO

/*------------------------------------------------------------------*/
/*-------------------CREAMOS TABLA CANJE----------------------------*/

CREATE TABLE DATACENTER.Canje
(canj_id int IDENTITY (1,1) NOT NULL,
canj_cli_dni numeric (18,0) NOT NULL,
canj_prem_id int NOT NULL,
canj_fecha datetime NULL
PRIMARY KEY (canj_id),
FOREIGN KEY (canj_cli_dni) REFERENCES DATACENTER.Cliente (cli_dni)
)
GO

/*------------------------------------------------------------------*/
/*-----------------CREAMOS TABLA PREMIO-----------------------------*/

CREATE TABLE DATACENTER.Premio
(prem_id int IDENTITY (1,1) NOT NULL,
prem_nombre nvarchar(255) NULL,
prem_costo_puntos int NULL,
prem_stock int NULL,
PRIMARY KEY (prem_id)
)
GO

/*------------------------------------------------------------------*/
/*---------------CREAMOS TABLA PREMIOPORCANJE-----------------------*/

CREATE TABLE DATACENTER.PremioPorCanje
(premxCanj_canj_id int NOT NULL,
premxCanj_prem_id int NOT NULL,
canj_cant_retirada int  NULL,
FOREIGN KEY (premxCanj_canj_id) REFERENCES DATACENTER.Canje (canj_id),
FOREIGN KEY (premxCanj_prem_id) REFERENCES DATACENTER.Premio (prem_id),
PRIMARY KEY (premxCanj_canj_id, premxCanj_prem_id)
)
GO

/*------------------------------------------------------------------*/
/*-----------------CREAMOS TABLA TIPO TARJETA-----------------------*/

CREATE TABLE DATACENTER.TipoTarjeta
(tipo_id int IDENTITY (1,1) NOT NULL PRIMARY KEY,
tipo_descripcion nvarchar(255) NULL,
tipo_cuotas char NULL
)
GO
/*------------------------------------------------------------------*/
/*-----------------CREAMOS TABLA SERVICIO---------------------------*/

CREATE TABLE DATACENTER.Servicio
(serv_id int IDENTITY (1,1) PRIMARY KEY NOT NULL ,
serv_tipo nvarchar(255) NULL,
serv_porc_adicional numeric (18,2) NULL
)
GO

/*------------------------------------------------------------------*/
/*---------------------CREAMOS TABLA CIUDAD-------------------------*/

CREATE TABLE DATACENTER.Ciudad
(ciu_nombre nvarchar(255) NOT NULL PRIMARY KEY)
GO

/*------------------------------------------------------------------*/
/*-----------------CREAMOS TABLA RECORRIDO--------------------------*/

CREATE TABLE DATACENTER.Recorrido
(reco_cod numeric(18,0) NOT NULL,
reco_serv_id int NOT NULL,
reco_origen nvarchar(255) NOT NULL,
reco_destino nvarchar(255) NOT NULL,
reco_precio_base_kg numeric(18,2) NULL,
reco_precio_base_pasaje numeric (18,2) NULL,
reco_estado CHAR NULL  -- ¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡OJO QUE ESTE CAMPO ES NUEVO!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
FOREIGN KEY (reco_serv_id) REFERENCES DATACENTER.Servicio (serv_id),
FOREIGN KEY (reco_origen) REFERENCES DATACENTER.Ciudad (ciu_nombre),
FOREIGN KEY (reco_destino) REFERENCES DATACENTER.Ciudad (ciu_nombre),
PRIMARY KEY (reco_cod)
)
GO

/*------------------------------------------------------------------*/
/*-----------------CREAMOS TABLA COMPRA-----------------------------*/

CREATE TABLE DATACENTER.Compra
(comp_id int IDENTITY (1,1) NOT NULL,
comp_comprador_dni numeric (18,0) NOT NULL,
comp_tipo_tarj_id int  NULL,
comp_reco_cod numeric(18,0) NOT NULL,
comp_cant_pasajes int NULL,
comp_cant_total_kg numeric (18,0) NULL, 
comp_costo_total numeric (18,2) NULL,
comp_fecha_compra datetime NULL,
comp_codigo_pas_paq numeric (18,0) NOT NULL, --COLUMNA AGREGADA TEMPORALMENTE PARA OPTIMIZAR LA MIGRACION
FOREIGN KEY (comp_comprador_dni) REFERENCES DATACENTER.Cliente (cli_dni),
FOREIGN KEY (comp_tipo_tarj_id) REFERENCES DATACENTER.TipoTarjeta (tipo_id),
FOREIGN KEY (comp_reco_cod) REFERENCES DATACENTER.Recorrido (reco_cod),
PRIMARY KEY (comp_id)
)
GO

/*------------------------------------------------------------------*/
/*-------------------CREAMOS TABLA MARCA----------------------------*/

CREATE TABLE DATACENTER.Marca
(marc_id int IDENTITY (1,1) NOT NULL PRIMARY KEY,
marc_nombre nvarchar(255) NULL
)
GO

/*------------------------------------------------------------------*/
/*-------------------CREAMOS TABLA MICRO----------------------------*/

CREATE TABLE DATACENTER.Micro
(mic_patente nvarchar(255) NOT NULL,
mic_marc_id int NOT NULL,
mic_serv_id int NOT NULL,
mic_cant_butacas int NULL,
mic_cant_kg_disponibles numeric (18,0) NULL,
mic_modelo nvarchar(255) NULL,
mic_nro int IDENTITY (1,1) NOT NULL,  
mic_fecha_alta datetime NULL,
mic_fecha_baja_def datetime NULL,
FOREIGN KEY (mic_marc_id) REFERENCES DATACENTER.Marca (marc_id),
FOREIGN KEY (mic_serv_id) REFERENCES DATACENTER.Servicio (serv_id),
PRIMARY KEY (mic_patente)
)
GO

/*------------------------------------------------------------------*/
/*----------------CREAMOS TABLA ESTADOMICRO-------------------------*/

CREATE TABLE DATACENTER.EstadoMicro
(est_id int IDENTITY (1,1) NOT NULL,
est_mic_patente nvarchar(255) NOT NULL,
est_fecha_fuera_serv datetime NULL,
est_fecha_reingreso datetime NULL,
FOREIGN KEY (est_mic_patente) REFERENCES DATACENTER.Micro (mic_patente),
PRIMARY KEY (est_id)
)
GO

/*------------------------------------------------------------------*/
/*-------------------CREAMOS TABLA BUTACA---------------------------*/

CREATE TABLE DATACENTER.Butaca
(but_nro numeric (18,0) NOT NULL,
but_mic_patente nvarchar(255) NOT NULL,
but_tipo nvarchar(255) NULL,
but_piso numeric (18,0) NULL,
FOREIGN KEY (but_mic_patente) REFERENCES DATACENTER.Micro (mic_patente),
PRIMARY KEY (but_nro, but_mic_patente)
)
GO

/*------------------------------------------------------------------*/
/*---------------------CREAMOS TABLA PASAJE-------------------------*/

CREATE TABLE DATACENTER.Pasaje
(pas_cod numeric(18,0) NOT NULL,
pas_nro_butaca numeric (18,0) NOT NULL,
pas_micro_patente nvarchar(255) NOT NULL,
pas_cli_dni numeric (18,0) NOT NULL,
pas_compra_id int NOT NULL,
pas_precio numeric(18,2) NULL,
FOREIGN KEY (pas_nro_butaca, pas_micro_patente) REFERENCES DATACENTER.Butaca (but_nro, but_mic_patente),
FOREIGN KEY (pas_cli_dni) REFERENCES DATACENTER.Cliente (cli_dni),
FOREIGN KEY (pas_compra_id) REFERENCES DATACENTER.Compra (comp_id),
PRIMARY KEY (pas_cod)
)
GO

/*------------------------------------------------------------------*/
/*---------------------CREAMOS TABLA PAQUETE-------------------------*/

CREATE TABLE DATACENTER.Paquete
(paq_cod numeric(18,0) NOT NULL,
paq_comp_id int NOT NULL,
paq_precio numeric (18,2) NULL,
paq_kg numeric (18,0)NULL,
FOREIGN KEY (paq_comp_id) REFERENCES DATACENTER.Compra (comp_id),
PRIMARY KEY (paq_cod)
)
GO

/*------------------------------------------------------------------*/
/*---------------------CREAMOS TABLA DEVOLUCION-------------------------*/

CREATE TABLE DATACENTER.Devolucion
(dev_id int IDENTITY (1,1) NOT NULL,
dev_comp_id int NOT NULL,
dev_pas_cod numeric(18,0) NULL,       --NULL POR QUE LA DEVOLUCION PUEDE TENER PAQ Y/O PASAJES
dev_paq_cod numeric(18,0) NULL,
dev_fecha datetime NULL,
dev_motivo nvarchar(255) NULL,
FOREIGN KEY (dev_comp_id) REFERENCES DATACENTER.Compra (comp_id),
FOREIGN KEY (dev_pas_cod) REFERENCES DATACENTER.Pasaje (pas_cod),
FOREIGN KEY (dev_paq_cod) REFERENCES DATACENTER.Paquete (paq_cod),
PRIMARY KEY (dev_id)
)
GO


/*------------------------------------------------------------------*/
/*---------------------CREAMOS TABLA VIAJE-------------------------*/

CREATE TABLE DATACENTER.Viaje
(viaj_id int IDENTITY (1,1) NOT NULL,
viaj_mic_patente nvarchar(255) NOT NULL,
viaj_reco_cod numeric(18,0) NOT NULL,
viaj_fecha_salida datetime NULL,
viaj_fecha_lleg_estimada datetime NULL,
viaj_fecha_llegada datetime NULL,
FOREIGN KEY (viaj_mic_patente) REFERENCES DATACENTER.Micro (mic_patente), 
FOREIGN KEY (viaj_reco_cod) REFERENCES DATACENTER.Recorrido (reco_cod),
PRIMARY KEY (viaj_id)
)
GO

/*------------------------------------------------------------------*/
/*---------------------CREAMOS TABLA ARRIBO-------------------------*/

CREATE TABLE DATACENTER.Arribo
(arri_fecha_llegada datetime NOT NULL,   
arri_mic_patente nvarchar(255) NOT NULL,         --DATO INGRESADO EN LA TERMINAL DE LLEGADA NO ES FK
arri_viaj_id int NOT NULL,
arri_ciu_arribada nvarchar(255) NOT NULL, 
FOREIGN KEY (arri_viaj_id) REFERENCES DATACENTER.Viaje (viaj_id),          --SEGUN DER ES FK => CONSULTA TABLA VIAJE
PRIMARY KEY (arri_fecha_llegada, arri_mic_patente)
)
GO 

/* ---------------------PRUEBAS-------------------------- */

--AGREGAMOS FUNCIONALIDADES 
INSERT INTO DATACENTER.Funcionalidad(func_nombre) --no ponemos ID ya que se autoincrementa
VALUES ('Comprar')
GO

INSERT INTO DATACENTER.Funcionalidad(func_nombre) --no ponemos ID ya que se autoincrementa
VALUES ('ABM Recorrido')
GO

INSERT INTO DATACENTER.Funcionalidad(func_nombre) --no ponemos ID ya que se autoincrementa
VALUES ('ABM Micro')
GO

--AGREGAMOS ROLES

INSERT INTO DATACENTER.Rol(rol_nombre, rol_estado) --no ponemos ID ya que se autoincrementa
VALUES ('Administrador', 'H') --H HABILITADO D DESHABILITADO
GO

INSERT INTO DATACENTER.Rol(rol_nombre, rol_estado) --no ponemos ID ya que se autoincrementa
VALUES ('Cliente', 'H') --H HABILITADO D DESHABILITADO
GO

--ASOCIAMOS ROLES CON FUNCIONES

INSERT INTO DATACENTER.FuncionalidadPorRol(fxrol_rol_id,fxrol_func_id, fxrol_estado)
VALUES (1, 1, 'H') --H HABILITADO D DESHABILITADO
GO

INSERT INTO DATACENTER.FuncionalidadPorRol(fxrol_rol_id,fxrol_func_id, fxrol_estado)
VALUES (1, 2, 'H') --H HABILITADO D DESHABILITADO
GO

INSERT INTO DATACENTER.FuncionalidadPorRol(fxrol_rol_id,fxrol_func_id, fxrol_estado)
VALUES (1, 3, 'H') --H HABILITADO D DESHABILITADO
GO

INSERT INTO DATACENTER.FuncionalidadPorRol(fxrol_rol_id,fxrol_func_id, fxrol_estado)
VALUES (2, 1, 'H') --H HABILITADO D DESHABILITADO
GO



----INSERTAMOS ADMINISTRADORES 
INSERT INTO DATACENTER.Administrador(adm_username, adm_password, adm_cant_intentos, adm_rol_id)
VALUES ('frann96','e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7',0,1)

INSERT INTO DATACENTER.Administrador(adm_username, adm_password, adm_cant_intentos, adm_rol_id)
VALUES ('dieguito12','e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7',0,1)

INSERT INTO DATACENTER.Administrador(adm_username, adm_password, adm_cant_intentos, adm_rol_id)
VALUES ('maty32','e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7',0,1)

INSERT INTO DATACENTER.Administrador(adm_username, adm_password, adm_cant_intentos, adm_rol_id)
VALUES ('ani18','e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7',0,1)


--AGREGAMOS PREMIOS

INSERT INTO 
DATACENTER.Premio(prem_nombre, prem_costo_puntos, prem_stock)
VALUES ('Televisor Led 32', 100, 50)
GO

INSERT INTO 
DATACENTER.Premio(prem_nombre, prem_costo_puntos, prem_stock)
VALUES ('Notebook Lenovo G470', 150, 30)
GO

/*------------------------------------------------------------------*/
/*-----------------MIGRACION DE CLIENTES----------------------------*/

INSERT INTO DATACENTER.Cliente(cli_dni, cli_nombre, cli_apellido, cli_dir, cli_telefono, cli_mail, cli_fecha_Nac)
	SELECT DISTINCT cli_Dni, cli_Nombre, cli_Apellido, cli_Dir, cli_Telefono, cli_Mail, Cli_Fecha_Nac
	FROM gd_esquema.Maestra
GO

/*------------------------------------------------------------------*/
/*----------------MIGRACION DE SERVICIO-----------------------------*/

INSERT INTO DATACENTER.Servicio(serv_tipo, serv_porc_adicional)
	SELECT DISTINCT(Tipo_Servicio), ROUND(((Pasaje_Precio-Recorrido_Precio_BasePasaje)/Recorrido_Precio_BasePasaje)*100,0)
	FROM gd_esquema.Maestra
	WHERE Recorrido_Precio_BasePasaje <> 0
	ORDER BY 2
GO

/*------------------------------------------------------------------*/
/*----------------MIGRACION DE MARCA-----------------------------*/
INSERT INTO DATACENTER.Marca(marc_nombre)
	SELECT distinct Micro_Marca
	FROM gd_esquema.Maestra
go

/*------------------------------------------------------------------*/
/*----------------MIGRACION DE CIUDAD-------------------------------*/

INSERT INTO DATACENTER.Ciudad(ciu_nombre)
	SELECT DISTINCT Recorrido_Ciudad_Destino -- Vale esto xq ciudades_Destino son las mismas que ciudades_Origen
	FROM gd_esquema.Maestra
GO

/*------------------------------------------------------------------*/
/*----------------MIGRACION DE MICRO--------------------------------*/

			-- CREA LA VISTA NECESARIA PARA LA MIGRACION --
CREATE VIEW Micros_Migrados(Micro_Patente, Micro_Modelo, Micro_KG_Disponibles, Micro_Cant_Butacas, Micro_Marca, Micro_Tipo_Serv) AS
select distinct Micro_Patente, Micro_Modelo, Micro_KG_Disponibles, MAX(butaca_nro) as Micro_Cant_Butacas, Micro_Marca, Tipo_Servicio
from gd_esquema.Maestra
group by Micro_Patente, Micro_Modelo, Micro_KG_Disponibles, Micro_Marca, Tipo_Servicio
go

			-- AHORA SI REALIZAMOS LA MIGRACION EN BASE A LOS CAMPOS NECESARIOS --
insert into DATACENTER.Micro(mic_patente, mic_modelo, mic_cant_kg_disponibles, mic_cant_butacas, mic_marc_id, mic_serv_id)
select Micro_Patente, Micro_Modelo, Micro_KG_Disponibles, Micro_Cant_Butacas, marc_Id, serv_Id
from micros_migrados join DATACENTER.Marca on Micro_Marca = marc_nombre join DATACENTER.Servicio on Micro_Tipo_Serv = serv_tipo
go

/*------------------------------------------------------------------*/
/*----------------MIGRACION DE RECORRIDO-----------------------------*/

INSERT INTO DATACENTER.Recorrido(reco_cod, reco_serv_id, reco_origen, reco_destino, reco_precio_base_kg, reco_precio_base_pasaje)
	SELECT DISTINCT t1.Recorrido_Codigo, serv_Id, t1.Recorrido_Ciudad_Origen, t1.Recorrido_Ciudad_Destino, t1.Recorrido_Precio_BaseKG, t2.Recorrido_Precio_BasePasaje
	FROM gd_esquema.Maestra t1 join gd_esquema.Maestra t2 ON (t1.Recorrido_Codigo = t2.Recorrido_Codigo) join DATACENTER.Servicio on t1.Tipo_Servicio = serv_tipo
	WHERE (t1.Recorrido_Precio_BaseKG <> '0' and t2.Recorrido_Precio_BasePasaje <> '0') 
	ORDER BY 1
GO

/*------------------------------------------------------------------*/
/*----------------HABILITAMOS LOS RECORRIDOS-----------------------------*/
UPDATE DATACENTER.Recorrido
SET reco_estado = 'H'

/*------------------------------------------------------------------*/
/*----------------MIGRACION COMPRA-----------------------------*/

INSERT INTO DATACENTER.Compra(comp_cant_pasajes, comp_cant_total_kg, comp_reco_cod, comp_comprador_dni, comp_costo_total, comp_fecha_compra, comp_codigo_pas_paq)
SELECT 1 AS cant_pasajes, Paquete_KG AS cant_total_kg, Recorrido_Codigo, Cli_Dni AS comprador_Dni , Pasaje_Precio AS costo_total, Pasaje_FechaCompra AS fecha_compra, Pasaje_Codigo
FROM gd_esquema.Maestra
WHERE  Pasaje_Codigo<>0 --NOS REFERIMOS A PASAJES
UNION ALL --POR SI SE DA ALGUNA REPETICION ; "UNION" ME DEVUELVE LA UNION DE LAS CONSULTAS PERO SIN REPETICIONES (DISTINCT)
SELECT 0 AS cant_pasajes,Paquete_KG AS cant_total_kg, Recorrido_Codigo, Cli_Dni AS comprador_Dni , Paquete_Precio AS costo_total, Paquete_FechaCompra AS fecha_compra, Paquete_Codigo
FROM gd_esquema.Maestra
WHERE  Pasaje_Codigo=0 --NOS REFERIMOS A PAQUETE
GO 

/*------------------------------------------------------------------*/
/*---------------------MIGRACION BUTACA-----------------------------*/


INSERT INTO DATACENTER.Butaca(but_nro, but_mic_patente, but_tipo, but_piso) 
	SELECT DISTINCT  Butaca_Nro, Micro_Patente,  Butaca_Tipo, Butaca_Piso
	FROM gd_esquema.Maestra, DATACENTER.Micro
	WHERE Butaca_Tipo <> '0'  --PARA QUE NO REPITA LA BUTACA NRO 0 CUANDO ENVIAN ENCOMIENDAS
	ORDER BY Micro_Patente, Butaca_Nro
GO

/*------------------------------------------------------------------*/
/*-------------------MIGRACION DE VIAJE-----------------------------*/
INSERT INTO DATACENTER.Viaje(viaj_mic_patente, viaj_reco_cod, viaj_fecha_salida, viaj_fecha_lleg_estimada, viaj_fecha_llegada)
	SELECT DISTINCT Micro_Patente, Recorrido_Codigo, FechaSalida, Fecha_LLegada_Estimada, FechaLLegada
	FROM gd_esquema.Maestra
GO


/*------------------------------------------------------------------*/
/*----------------MIGRACION DE PASAJE-------------------------------*/
INSERT INTO DATACENTER.Pasaje(pas_cod, pas_nro_butaca, pas_micro_patente, pas_cli_dni, pas_compra_id, pas_precio)
	SELECT M.Pasaje_Codigo, M.Butaca_Nro, M.Micro_Patente, M.Cli_Dni, C.comp_Id, M.Pasaje_Precio 
 	FROM gd_esquema.Maestra M join DATACENTER.Compra C on M.Cli_Dni = C.comp_comprador_Dni AND  C.comp_cant_pasajes = 1 AND C.comp_Codigo_Pas_Paq = M.Pasaje_Codigo
 	ORDER BY  Pasaje_Codigo, Cli_Dni, C.comp_Id
GO

/*------------------------------------------------------------------*/
/*---------------------MIGRACION DE PAQUETE-------------------------*/

INSERT INTO DATACENTER.Paquete (paq_cod, paq_comp_id, paq_precio, paq_kg)
	SELECT comp_Codigo_Pas_Paq, comp_Id, comp_costo_Total, comp_cant_total_KG
	FROM DATACENTER.Compra
	WHERE comp_cant_total_KG <> 0
GO

--Eliminamos columna extra en COMPRA que fue utilizada para OPTIMIZAR la Migracion
ALTER TABLE DATACENTER.Compra
DROP COLUMN comp_codigo_pas_paq
GO

/*-------------------------------------------------------------------*/
/*-------------------------STORED PROCEDURE (FRANCO)--------------------------*/

CREATE PROCEDURE DATACENTER.update_cant_intentos_fallidos @adm_username nvarchar(255), @cant_intentos int
AS
BEGIN
	UPDATE DATACENTER.Administrador
	SET adm_cant_intentos = @cant_intentos
	WHERE adm_username = @adm_username
END
GO


/*-------------------------------------------------------------------*/
/*-------------------------STORED PROCEDURE (MATI)--------------------------*/
CREATE PROCEDURE DATACENTER.insert_recorrido @cod numeric(18,0), @orig nvarchar(255), @dest nvarchar(255), @serv int, @pr_pas numeric(18,2), @pr_enco numeric(18,2)
AS
BEGIN
  DECLARE @est CHAR
  SET @est = 'H'
  INSERT INTO DATACENTER.Recorrido
  VALUES (@cod, @serv, @orig, @dest, @pr_pas, @pr_enco, @est)
END
GO

/*-------------------------------------------------------------------*/
/*-------------------------STORED PROCEDURE (MATI)--------------------------*/

CREATE PROCEDURE DATACENTER.update_recorrido @cod numeric(18,0), @orig nvarchar(255), @dest nvarchar(255), @serv int, @pr_pas numeric(18,2), @pr_enco numeric(18,2)
AS
BEGIN

  DECLARE @precio_pas NUMERIC(18,2),
          @precio_enco NUMERIC(18,2)

  UPDATE DATACENTER.Recorrido
  SET reco_origen = @orig, reco_destino = @dest, reco_serv_id = @serv
  WHERE reco_cod = @cod

  SELECT @precio_pas = reco_precio_base_pasaje, @precio_enco = reco_precio_base_kg
  FROM DATACENTER.Recorrido
  WHERE reco_cod = @cod
  
  IF @precio_pas <> @pr_pas
  UPDATE DATACENTER.Recorrido
  SET reco_precio_base_pasaje = @pr_pas
  WHERE reco_cod = @cod
  
  IF @precio_enco <> @pr_enco
  UPDATE DATACENTER.Recorrido
  SET reco_precio_base_kg = @pr_enco
  WHERE reco_cod = @cod
  
END
GO

/*-------------------------------------------------------------------*/
/*-------------------------STORED PROCEDURE (MATI)--------------------------*/
CREATE PROCEDURE DATACENTER.update_estado_reco @cod NUMERIC(18,0), @estado_reco CHAR
AS
BEGIN

  UPDATE DATACENTER.Recorrido
  SET reco_estado = @estado_reco
  WHERE reco_cod = @cod

END
GO

/*-------------------------------------------------------------------*/
/*-------------------------STORED PROCEDURE (MATI)--------------------------*/
CREATE PROCEDURE DATACENTER.insert_viaje @fecha_sal DATETIME, @fecha_lleg DATETIME, @cod_reco NUMERIC(18,0), @patente NVARCHAR (255)
AS
BEGIN

INSERT INTO DATACENTER.Viaje (viaj_mic_patente, viaj_reco_cod, viaj_fecha_salida, viaj_fecha_lleg_estimada)
VALUES (@patente, @cod_reco, @fecha_sal, @fecha_lleg)

END
GO

/*-------------------------------------------------------------------*/
/*-------------------------TRIGGER (MATI)--------------------------*/
CREATE TRIGGER DATACENTER.act_precio_reco
ON DATACENTER.Recorrido
AFTER UPDATE
AS
BEGIN

  DECLARE @cod NUMERIC (18,0)
  DECLARE @origen NVARCHAR(255)
  DECLARE @destino NVARCHAR (255)
  DECLARE @precio_pasa NUMERIC (18,2)
  DECLARE @precio_enco NUMERIC (18,2)

  SELECT @cod = reco_cod, @origen = reco_origen, @destino = reco_destino, @precio_pasa = reco_precio_base_pasaje, @precio_enco = reco_precio_base_kg
  FROM inserted

  IF UPDATE(reco_precio_base_pasaje)
  BEGIN
    UPDATE DATACENTER.Recorrido
    SET reco_precio_base_pasaje = @precio_pasa
    WHERE reco_origen = @origen AND reco_destino = @destino AND reco_cod <> @cod 
  END
  
  IF UPDATE(reco_precio_base_kg)
  BEGIN
    UPDATE DATACENTER.Recorrido
    SET reco_precio_base_kg = @precio_enco
    WHERE reco_origen = @origen AND reco_destino = @destino AND reco_cod <> @cod 
  END

END
GO