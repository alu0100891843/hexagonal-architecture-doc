@echo Levantamos los contenedores de docker con mongoDb
docker-compose -f ..\docker.compose.yml up -d
@echo Esperamos 10 segundos para que se levante el contenedor
timeout /t 10 /nobreak >nul
@echo Restauramos la base de datos
docker exec -i my-mongodb sh -c "mongorestore --archive --db GT-Motive" < dumps\db.dump
@echo Finalizado