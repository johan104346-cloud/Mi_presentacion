# MiPresentacion - Avalonia UI 11

Aplicacion de escritorio desarrollada en C# y Avalonia UI 11 que permite registrar los datos básicos de un usuario y mostrar una presentación personalizada interactiva mediante eventos de interfaz gráfica.

## Requisitos de Ejecución
Para ejecutar la aplicacion desde la terminal, clona este repositorio, navega a la carpeta del proyecto y ejecuta:

```bash
dotnet run
```

## Estructura y Controles Utilizados

- **`StackPanel`**: Control contenedor para organizar de manera vertical y horizontal los elementos de la interfaz.
- **`TextBlock`**: Utilizado para mostrar etiquetas fijas, títulos y el mensaje final de resultado/advertencia.
- **`TextBox` (`TxtNombre`, `TxtApellido`, `TxtEdad`)**: Cajas de texto para la entrada de datos del usuario.
- **`Button` (`BtnPresentarme`, `BtnCambiarSaludo`, `BtnLimpiar`)**: Botones para desencadenar la presentación, alternar formatos de texto y reiniciar el formulario.


##  Casos de Prueba Verificados

| Caso | Entrada | Resultado Esperado |
| :--- | :--- | :--- |
| 1 | Datos válidos (`Carlos`, `Pérez`, `20`) | Muestra la presentación personalizada en texto verde. |
| 2 | Nombre vacio | Muestra advertencia en rojo: *"El nombre no puede estar vacio"*. |
| 3 | Apellido vacio | Muestra advertencia en rojo: *"El apellido no puede estar vacío"*. |
| 4 | Edad con letras (`veinte`) | Muestra advertencia en rojo pidiendo un valor numerico. |
| 5 | Edad negativa o cero (`-5` o `0`) | Rechaza el valor e indica que debe ser positivo. |
| 6 | Presionar "Limpiar" | Borra los campos, restablece el mensaje y enfoca `TxtNombre`. |

## Pregunta de Reflexion

¿Cual es la funcion de `MainWindow.axaml` y `MainWindow.axaml.cs`, y como se relacionan mediante `x:Name` y los eventos `Click` para permitir que el usuario interactue con la aplicacion?

En Avalonia UI, la arquitectura se divide en dos capas esenciales:
1. **`MainWindow.axaml` (Capa de Presentacion)**: Su funcion es definir la estructura visual y distribucion de los elementos de la interfaz grafica mediante código declarativo XAML (estilos, margenes, tipos de controles).
2. **`MainWindow.axaml.cs` (Capa de Logica / Code-Behind)**: Su funcion es procesar las acciones del usuario, ejecutar validaciones de datos y modificar la informacion mostrada.

### Relación e Interaccion:
* **`x:Name`**: Actua como un identificador único que expone un elemento visual de XAML hacia la clase en C#. Por ejemplo, al asignar `x:Name="TxtNombre"` a un `TextBox`, el compilador genera un campo accesible desde `MainWindow.axaml.cs`, permitiéndonos leer (`TxtNombre.Text`) o modificar sus propiedades en tiempo de ejecucion.
* **Eventos `Click`**: Conectan las acciones físicas del usuario en la interfaz con la logica de C#. Al declarar `Click="BtnPresentarme_Click"` en un botón XAML, le indicamos al motor que cuando el usuario presione dicho boton, debe ejecutar automáticamente el metodo correspondiente en `MainWindow.axaml.cs`.

Gracias a la combinación de `x:Name` y los eventos, la aplicación deja de ser una imagen estatica para convertirse en un software interactivo capaz de responder y validar información en tiempo real.

