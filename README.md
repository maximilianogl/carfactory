
# Ejercicio tecnico - Maximiliano Leveroni - Fabrica de autos

El presente proyecto es el resultado del ejercicio tecnico solicitado para por la empresa COTO para el puesto de desarrollador .NET.
El proyecto esta realizado en .NET 8, fue desarrollado usando ideas de Clean architecture, DDD, SOLID, utilizando patrones de diseño como inyeccion de depedencia, repository, Unit of work, singleton.




## Arquitectura
Se desarrollo siguiendo ideas simplificadas de conceptos de arquitectura limpia, DDD, y TDD. El proyecto esta organizado en capas:

- Domain: Capa que almacena todas las entidades de dominio del sistema.
- WebApi: Incluye los controllers para la interaccion. Documentacion con Swagger
- Services: Capaz donde se desarrollan los servicios con la logica necesaria para resolver los casos de uso. Utiliza libreria FluentValidator. Cada modelo de dominio tiene su servicio.
- Persistence: Capa para interactuar con el almacenamiento de datos. En este ejercicio no se usa un almacenamiento externo si no que los datos se guardan en memoria, mediante un singlenton y una clase que se encarga de armar un mock de los datos. Se utiliza patrones de unit of work y repository para centralizar la gestion de los almacenes por dominio.
-  UnitTest: Contiene las pruebas unitarias sobre los metodos que contienen la logica principal del dominio. Se utiliza xUnit para las pruebas.



## API Reference

#### Get all cars

```http
  GET /car
```


#### Get all distribution centers

```http
  GET /DistributionCenter
```

#### Create a new sale

```http
  POST /Sale
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `carId`      | `uuid` | **Required**. Id of car selled |
| `distributionCenterId`      | `uuid` | **Required**. Id of distribution center |
| `saleDate`      | `DateTime` | **Required**. Date and time of sale |


#### Get the total sales volume

```http
  GET /Sale/TotalSales
```
#### Get the sales volume by distribution center

```http
  GET /Sale/TotalSalesByDistributionCenter
```
#### Get the percentage of units of each model sold in each center out of the company's total sales.

```http
  GET /Sale/TotalSalesDetailPercentage

```

## Instalación

Para ejecutar en ambiente local se debe tener instalado la version 8 de .NET

### 1. Clonación de repositorio

Abre una terminal o línea de comandos y ejecuta:

```bash
git clone https://github.com/maximilianogl/carfactory
cd cd CarFactory\CarFactory
```
### 2. Restauración de dependencias y ejecución

```bash
dotnet restore
dotnet run
```
La aplicación comenzará a ejecutarse, y podrás acceder a ella en la dirección que se muestre en la salida del comando.
Agregar a la url /swagger cargara la documentación de la api y permitira realizar las pruebas.


## Visualización de tiempos de ejecución

Para poder ver los tiempos que demora cada ejecución se implemento miniprofiler. 
Para visualizarlo debe agregar a la ruta: /profiler/results. Ejemplo:
```bash
https://localhost:44314/profiler/results
```

## Requerimientos solicitados
Realizar los siguientes puntos usando como lenguaje .NET o NET CORE, no tiene límite de tiempo ni limitaciones de uso de frameworks.

1- Enviar la solución en un repo git (github o gitlab) con los commits con el detalle de lo que se está subiendo.

2- Crear uno o varios servicios rest que expongan la solución al problema planteado.

3- Comentar en código lo que se considere necesario para explicar cómo se hizo la solución.

4- Imprimir el tiempo de ejecución de cada método.

5- Mockear los datos

6- No es necesario realizar cruds de las entidades en la api

7- Se tiene en cuenta la profundidad de la solución brindada y profesionalidad de código.

8- NO REQUIERE FRONTEND

9- Agregar explicación de cómo deben usarse los servicios.

10- Es valorable la entrega de pruebas unitarias implementadas con xUnit.

 
Problema:
Una fábrica de automóviles produce 4 modelos de coches (sedan, suv, offroad, sport) cuyos precios de venta son: 8.000 u$s, 9.500 u$s, 12.500 u$s y 18.200 u$s. 
La empresa tiene 4 centros de distribución y venta. Se tiene una relación de datos correspondientes al tipo de vehículo vendido y punto de distribución en el que se produjo la venta del mismo.
El tipo “sport” incluye un impuesto extra del 7% que se debe adicionar al precio en la venta.

Realizar una api rest que contemple:

•            Insertar una venta

•            Obtener el volumen de ventas total.

•            Obtener el volumen de ventas por centro.

•            Obtener el porcentaje de unidades de cada modelo vendido en cada centro sobre el total de ventas de la empresa. 

## 🔗 Links

[![linkedin](https://img.shields.io/badge/linkedin-0A66C2?style=for-the-badge&logo=linkedin&logoColor=white)](https://www.linkedin.com/in/maximilianoleveroni/)


