# Belatrix
Repositorio Temporal para la prueba SME de Belatrix

El proyecto es parte de la prueba SME. Consiste en una aplicación en consola para realizar 3 tipos distintos de loggeos. 
Los tipos de loggeos son:
  - Base De Datos
  - Loggeo en Consola
  - Loggeo en un archivo ".txt"

La aplicación se construyo usando la IDE de Visual Studio 2015. 
Se definio una arquitectura en capas para el manejo de las clases y entidades requeridas y se creo un proyecto de UnitTest para realizar las pruebas pertinentes al código(TDD). Para las pruebas se hizo uso de las librerias de Mock y para el diseño de la aplicación se usaron las clase de reflection para poder agregar o eliminar los plugins en momento de ejecución de manera dinamica.

Para probar la aplicación descargar(Clonar todo el repositorio), dentro del mismo encontraran los siguientes 3 archivos:
- Base de Datos.rar : En este archivo comprimido se encuentran los scripts y el backup de la base datos
- Belatrix.SimpleLogging.rar : En este archivo comprimido se encuentrar los ejecutables, assemblies y carpetas que usa la aplicación
- Belatrix.SimpleLogging.SME.rar : En este archivo comprimido se encuentra el código fuente.

Para probar la aplicación se deben realizar los siguientes pasos:

1. Descomprimir el archivo Base de Datos.rar y ejecutar los scripts de creación de base de datos "CreateDataBaseDBLogger.sql" , de tabla y procedimientos almacenados "ScriptCreateTableLoggerAndSP.sql" ó de lo contrario restaurar el backup "DBLogger.bak". Nota: El backup generado se realizo en la versión de SQL 2008 R2.

2. Descomprimir el archivo Belatrix.SimpleLogging.rar, ahi se encuentran los siguientes objetos:
- Folder de Assemblies: Contiene los assemblies(plugins) para realizar el loggeo de mensajes de la aplicación.
- Folder de Output: Es donde se va a generar el archivo .txt para el logeo en archivo en disco.
- Folder de Plugins: Es donde se van a colocar los assemblies/plugins que se encuentran en el folder Assemblies para realizar el loggeo en consola o base de datos o archivo en disco
- Belatrix.SimpleLogger.SME.App.exe: Ejecutable de la aplicación
- Belatrix.SimpleLogger.SME.App.exe.config: Archivo de configuración de la aplicación.
- Belatrix.SimpleLogger.SME.BE.dll,Belatrix.SimpleLogger.SME.Repository.dll,Belatrix.SimpleLogger.SME.Support.dll: DLL/Assemblies necesarios para el correcto funcionamiento de la aplicación.

3. Abrir el archivo Belatrix.SimpleLogger.SME.App.exe.config con notepad y modificar los siguientes valores:
Parametros de servidor SQL:
<add name="SqlConnectionString" connectionString="Server=MiServidor\CEREAL;Database=DBLogger;User Id=sa;Password=passwordsa;"/>
Parametros de fichero:
<add key="LogFileDirectory" value="E:\GitHubRepository\Belatrix\SimpleLogging\Output\"/>
Reemplazar el valor (value) por la ruta donde se encuentra la carpeta Output, en esa carpeta se va a generar el archivo de loggeo .txt

4. Colocar en la carpeta plugins el plugin(dll) correspondiente deacuerdo al tipo de loggeo que desea generar, Los plugins(dll) se encuentran dentro de la carpeta "Assemblies":
- Belatrix.SimpleLogger.SME.DL.dll: Permite el loggeo en base de datos
- Belatrix.SimpleLogger.SME.FileManager.dll: Permite el loggeo en un archivo fisico, el archivo se va a generar en la ruta indicada en 
el valor de la variable LogFileDirectory del archivo .config
- Belatrix.SimpleLogger.SME.LogEvent.dll: Permite el loggeo en consola.

5. Ejecutar la aplicación Belatrix.SimpleLogger.SME.App.exe

6. Ingresar el mensaje de log y luego ingresar el tipo de severidad del mensaje

7. La aplicación mostrara un mensaje dependiendo del tipo de loggeo que se eligío. Es decir dependiendo del tipo de plugin que se coloco en la carpeta de "Plugins"

8. Para elegir entre los diferentes tipos de Loggeo basta con agregar o quitar los plugins(.dll)  que se encuentran en la carpeta plugins. Esto se puede realizar sin necesidad de cerrar o reiniciar la aplicación.

Caso practico: 
Nota: Recordar que los plugins(dll) se encuentran en la carpeta Assemblies 

Coloco el plugin de logeo en base de datos "Belatrix.SimpleLogger.SME.DL.dll" en la carpeta "Plugins".

Ejecuto la aplicacion Belatrix.SimpleLogger.SME.App.exe

La aplicación muestra el mensaje "Please type the log message"

Escribimos los siguiente : Test:Message log into a Database

Presionamos enter

La aplicación muestra el mensaje "Type the number of the log type Severity: 1:TYPE_WARNING , 2:TYPE_SUCCESS,3: TYPE_ERROR"

Escribimos uno de los números indicados

Presionamos enter

La aplicación muestra el mensaje "The log message has been successfully saved on the DataBase";

Podemos verificar la información ingresada realizando un Select sobre la tabla Logger que se encuentra en la base de datos DBLogger

Presionamos enter

La aplicación nos muestra el mensaje "Do you want to continue? Yes (y) or No (n): "

Digitamos la letra "y" 

Vamos a la carpeta Plugin y eliminamos el plugin(dll) "Belatrix.SimpleLogger.SME.DL.dll" y agregamos el plugin para loggeo en archivo de 
texto "Belatrix.SimpleLogger.SME.FileManager.dll"

Escribimos los siguiente : Test:Message log into a File

Presionamos enter

La aplicación muestra el mensaje "Type the number of the log type Severity: 1:TYPE_WARNING , 2:TYPE_SUCCESS,3: TYPE_ERROR"

Escribimos uno de los números indicados

La aplicacion nos muestra el mensaje "The log message has been successfully saved on the File"

Vamos a la carpeta Output y buscamos el archivo .txt generado y lo abrimos para comprobar que se escribio el mensaje de log ingresado
[Date]: 24/10/2017 3:07:11 [Log Message]: Test: Log message into a File  [Log Severity]: success

Nota: El archivo generado tiene como nombre "LogFile[FechaActual(ddMMyyyy)].txt si el archivo no existe lo crea y si existe lo abre y va agregando los mensajes linea a linea.

La aplicación nos muestra el mensaje "Do you want to continue? Yes (y) or No (n): "

Digitamos la letra "y" 

Vamos a la carpeta Plugin y eliminamos el plugin(dll) "Belatrix.SimpleLogger.SME.FileManager.dll" y agregamos el plugin para loggeo en consola "Belatrix.SimpleLogger.SME.LogEvent.dll"

Escribimos los siguiente : Test:Message log display on the console o cualquier texto que desee ingresar.

Presionamos enter

La aplicación muestra el mensaje "Type the number of the log type Severity: 1:TYPE_WARNING , 2:TYPE_SUCCESS,3: TYPE_ERROR"

Escribimos uno de los números indicados

La aplicacion nos muestra el mensaje "Log Details: LogMessage = Test:Message log display on the console, LogSeverity = warning"

Presionamos enter

La aplicación nos muestra el mensaje "Do you want to continue? Yes (y) or No (n): "

Digitamos la letra "n"

Se cierra la aplicación

Si se desea continuar se puede igualmente seguir borrando y agregando los plugins(dll) que se encuentran en la carpeta "Assemblies" a la carpeta "Plugins" o se pueden agregar los 3 plugins y la aplicación realizar los 3 tipos de loggeo. 

  
