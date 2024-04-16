# Instrucciones para arrancar el proyecto

1. Ir a la carpeta `/tools` y ejecutar el script `up.sh` (simplemente hay que escribir en la terminal `up.sh`). 
        
       NOTA: Esto levantará dos contenedores de docker con las bases de datos necesarias para el proyecto, además de cargar un dump con algunos datos de prueba

2. Abrir el proyecto con Visual Studio y seleccionar el proyecto `GtMotive.Estimate.Microservice.Host` como proyecto de inicio
  
3. Darle al boton de play para arrancar el proyecto

       Se deberá abrir una ventana en el navegador que llevará a Swagger. En esta interfaz se pueden hacer pruebas de los endpoints del microservicio

# Consideraciones
- Para la creación de los elementos no es necesario pasar el id, ya que se generará automáticamente si no se pasa. No obstante, se le puede pasar, pero deberá tener formato [UUIDv4](https://www.uuidgenerator.net/version4) (ejemplo: `f47ac10b-58cc-4372-a567-0e02b2c3d479`)