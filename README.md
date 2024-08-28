# EmployeeManagement

Pasos para la ejecución correcta del proyecto: 
1: Crear la base de datos anexada en la carpeda Database.

2: Clonar el repositorio 

3: En el explorador de servidores, añadir una nueva conexión, llenar los datos correspondientes: Nombre del servidor, conexion con el servidor, tipo de autenticación, marcar la opción "Confiar en el certificado de servidor", en el nombre de la base de datos
seleccionar EmployeeDB.

4: En la carpeta models, click derecho, crear un elemento y seleccionar ADO.NET Entity Data Model
![image](https://github.com/user-attachments/assets/fb964e79-fa17-47b9-993d-86f10be767cb)

5: seleccionar EF Designer desde base de datos

6: en el apartado "¿Qué conexión de datos debe utilizar la aplicación para conectarse a la base de datos?,
seleccionar la conexión creada en el paso 3

7: Guardar configuración de conexion en Web.Config como:  EmployeeDBEntities.

8: Seleccionar la tabla Employee.

9: en el espacio de nombres del modelo usar: EmployeeDBModel

10: click finalizar.

11: Cersiorarse que se hayan creado las carpetas correspondientes:
![image](https://github.com/user-attachments/assets/6916643e-62e3-4f6b-ad4c-87e9837ae97b)

12: abrir el documento /Views/Employee/Index.cshtml  y ejecutar el programa


