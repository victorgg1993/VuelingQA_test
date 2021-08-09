Vueling QA testing final test
===

Examen final de vueling 2021 QA testing. El contenido fue dividido en tres bloques: Quiz, Front-end y Back-end.

El Quiz contiene las preguntas del test con su respectiva respuesta.

El front y back contienen los requisitos, herramientas, estructura y procedimiento para ser usados.

</br>

# Tabla de contenido
- [Quiz](#Quiz)
- [Front-end](#Front-end)
- [Back-end](#Back-end)

</br>
</br>
</br>

---
<img align="left" width="64px" src="./img/quiz.svg">
</br>

## <a name="Quiz">Quiz</a>
</br>

**1. ¿Cual de las siguientes respuestas es correcta dada la siguiente afirmación?: La búsqueda de elementos en Ranorex se puede realizar mediante....**

- Xpath.
</br>
</br>

**2. Gracias a SeleniumWebDriver podemos....**

- Ejecutar acciones a elementos como escribir texto, recoger atributos, etc.
</br>
</br>

**3. Los Test de Regresión validan....**

- El correcto funcionamiento del contenido nuevo que subimos a un entorno + el correcto funcionamiento del contenido que ya estaba en el entorno.
</br>
</br>

**4. En Jmeter que elemento se necesita para controlar la carga/tiempo de un thread group o una request....**

- Constant throughput timer.
</br>
</br>

**5. En Jmeter, para qué sirve el campo "Ramp-up" de un thread group?**

- Tiempo en segundos que tarda el test en tener el número máximo de users levantados.
</br>
</br>

**6. Un Test Case es...**

- Un conjunto de condiciones o variables que validan una caracteristica, aplicación o software.
</br>
</br>

**7. En Testlink podemos...**

- Escribir, editar, borrar y almacenar TestCases.
</br>
</br>

**8. En Cypress dentro de la carpeta WebPages incluiremos...**

- Los archivos CS de cada una de las páginas del flujo del test.

Notas: ( CS => JS o TS)
</br>
</br>

**9. Newman nos permite...**

- Nos permite ejecutar y probar una Colección Postman directamente desde la lí­nea de comandos.
</br>
</br>

**10. El Pre-Request Script en Postman nos permite...**

- B y C son correctas (Ejecutar todo aquello que queremos que se ejecute antes de una llamada) + (Realizar acciones previas, valores de variables, parámetros, encabezados y datos del script).
</br>
</br>
</br>
---

<img align="left" width="64px" src="./img/selenium.svg">
</br>

## <a name="Front-end">Front-end</a>
</br>

**Requisitos:**

- Entrar a https://m.vueling.com/
- Pulsar en la pestaña RoundTrip.
- Seleccionar station de ida Barcelona y station de vuelta Madrid.
- Seleccionar el vuelo de ida a +3 dias del día de hoy.
- Seleccionar el vuelo de vuelta a +5 dias del día de hoy.
- 1 Adulto.
- Pulsamos el botón Search.
- Sacaremos un listado en el formato que queráis de todos los vuelos Vueling para ese día así como su precio (ida y vuelta).
- Seleccionar un vuelo Vueling tanto en la ida como en la vuelta. (Si no encontramos un vuelo vueling, buscar al siguiente día que esté disponible volar con Vueling).
- Seleccionamos Tarifa Básica.
- Introducimos Nombre y Apellidos del adulto 1.

</br>

**Herramientas**
- Selenium
</br>

**Estructura**
- Front-end/Selenium/ = directorio principal
- Front-end/Selenium/Common = clase con métodos genéricos
- Front-end/Selenium/Configuration = variables usadas en los test
- Front-end/Selenium/Features = directorio donde se almacenan los archivos .feature (conexión de la parte de negocio con la de técnica/testing).


</br>

**Procedimiento:**
- Abrir el proyecto .sln
- Click derecho encima de Test_roundTrip.cs
- Elegir la opción "Run Tests"

</br>
</br>
</br>

---

<img align="left" width="64px" src="./img/postman.svg">
</br>

## <a name="Back-end">Back-end</a>
</br>
</br>


**Requisitos:**
- Acceder a la url: https://datos.madrid.es/portal/site/egob/menuitem.214413fe61bdd68a53318ba0a8a409a0/?vgnextoid=b07e0f7c5ff9e510VgnVCM1000008a4a900aRCRD&vgnextchannel=b07e0f7c5ff9e510VgnVCM1000008a4a900aRCRD&vgnextfmt=default

- En esta URL encontraremos un listado de APIs publicas, de las cuales iremos a Sedes. Oficinas de Correos.

- El objetivo de este ejercicio es realizar en postman las 2 llamadas que aparecen en Sedes. Oficinas de Correos.

- En la segunda llamada queremos validar que el id: 13802 Existe y que su nombre es Oficina de Correos. Sucursal 34. Calle San Magín así como el Codigo postal es 28026.

</br>

**Herramientas**
- Postman
- Newman
</br>

**Estructura**
- Documento environment: Donde se encuentran las variables de entorno.
- Documento collection: Donde se encuentran los test cases.
</br>

**Procedimiento:**
- Entrar en la carpeta Back-end
- Ejecutar:
```
npm run newman
```