USE DB_PRUEBA_TECNICA;
GO

-- ==========================================
-- SEED DE ROLES Y USUARIOS
-- ==========================================
INSERT INTO USUARIO (ID_ROL, NOMBRE_USUARIO, CONTRASENA_HASH, CORREO)
VALUES 
(
    1,
    'admin',
    HASHBYTES('SHA2_256', 'Admin123*'),
    'admin@tienda.com'
);
GO

-- ==========================================
-- SEED DE PRODUCTOS
-- ==========================================
--INSERT INTO PRODUCTO (CODIGO, NOMBRE, DESCRIPCION, PRECIO, STOCK)
--VALUES 
--('P001', 'CAMISA AZUL', 'Camisa de algod�n talla M', 25.50, 50),
--('P002', 'PANTAL�N NEGRO', 'Pantal�n formal', 35.00, 40),
--('P003', 'ZAPATOS CAF�', 'Zapatos de cuero', 55.00, 30);
--GO