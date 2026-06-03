# Práctica de Refactorización SOLID

## Nombre

Dohrian Miguel Peña Castro

## Tema

Refactorización de los principios SOLID: SRP, OCP y LSP.

# Introducción

En esta práctica se analizarán tres ejemplos de código con problemas de diseño orientado a objetos. Cada ejemplo será refactorizado aplicando principios SOLID para mejorar la organización, mantenibilidad y escalabilidad del software.

Los principios trabajados son:

* SRP (Single Responsibility Principle)
* OCP (Open/Closed Principle)
* LSP (Liskov Substitution Principle)

# Investigación y análisis

## ¿Qué significa SOLID?

SOLID es un conjunto de cinco principios de diseño de software orientado a objetos que ayudan a desarrollar aplicaciones más mantenibles, flexibles y escalables.

### S - Single Responsibility Principle

Una clase debe tener una única responsabilidad y una sola razón para cambiar.

### O - Open/Closed Principle

Las clases deben estar abiertas para extensión pero cerradas para modificación.

### L - Liskov Substitution Principle

Las clases derivadas deben poder sustituir a las clases base sin alterar el comportamiento esperado.

### I - Interface Segregation Principle

Las interfaces deben ser específicas y no obligar a implementar métodos innecesarios.

### D - Dependency Inversion Principle

Los módulos de alto nivel deben depender de abstracciones y no de implementaciones concretas.

## ¿Por qué SOLID es importante en la Programación Orientada a Objetos?

SOLID permite desarrollar software más organizado, flexible y fácil de mantener. Su aplicación reduce errores y facilita la incorporación de nuevas funcionalidades sin afectar el código existente.

### ¿Cómo ayuda SOLID a mantener proyectos grandes?

Permite dividir responsabilidades, reducir dependencias innecesarias y mejorar la organización general del sistema, facilitando el trabajo de múltiples desarrolladores.

### ¿Qué problemas aparecen cuando no se usan estos principios?

* Código difícil de entender.
* Mayor cantidad de errores.
* Dependencias excesivas.
* Baja reutilización de código.
* Dificultad para realizar pruebas.
* Problemas para escalar el sistema.

### Influencia de SOLID

#### Mantenimiento

Facilita corregir errores y realizar actualizaciones.

#### Reutilización

Permite utilizar componentes en diferentes proyectos.

#### Escalabilidad

Facilita agregar nuevas funcionalidades.

#### Pruebas

Permite probar componentes de manera independiente.

#### Trabajo en equipo

Mejora la organización y colaboración entre desarrolladores.

# Conceptos clave

## Acoplamiento

Nivel de dependencia que existe entre diferentes clases o módulos de un sistema.

## Cohesión

Grado en que los elementos de una clase están relacionados entre sí para cumplir una única responsabilidad.

## Refactorización

Proceso de mejorar la estructura interna del código sin modificar su comportamiento externo.

## Escalabilidad

Capacidad de un sistema para crecer y soportar nuevas funcionalidades.

## Mantenibilidad

Facilidad con la que un sistema puede ser corregido, actualizado o mejorado.

## Abstracción

Representación de las características esenciales de un objeto ocultando detalles innecesarios.

## Dependencias

Relaciones entre clases o componentes donde uno necesita utilizar otro para funcionar.

# Parte 1 - SRP: Single Responsibility Principle

## Código malo

```csharp
public class Reporte
{
    public void GenerarReporte()
    {
        Console.WriteLine("Generando reporte...");
    }

    public void GuardarEnArchivo()
    {
        Console.WriteLine("Guardando archivo...");
    }

    public void EnviarPorCorreo()
    {
        Console.WriteLine("Enviando correo...");
    }
}
```

## Problema del código

La clase Reporte tiene varias responsabilidades: generar reportes, guardar archivos y enviar correos. Esto viola el principio de responsabilidad única.

## Código refactorizado

```csharp
public class GeneradorReporte
{
    public void Generar()
    {
        Console.WriteLine("Generando reporte...");
    }
}

public class GuardadorArchivo
{
    public void Guardar()
    {
        Console.WriteLine("Guardando archivo...");
    }
}

public class EnviadorCorreo
{
    public void Enviar()
    {
        Console.WriteLine("Enviando correo...");
    }
}
```

## Preguntas de análisis

### ¿Qué problema tenía el diseño original?

La clase concentraba múltiples responsabilidades en un solo lugar, dificultando el mantenimiento.

### ¿Qué ventajas aporta la refactorización?

Mejora la organización, reutilización y mantenibilidad del código.

### ¿Qué ocurriría si el sistema crece?

La clase original se volvería cada vez más compleja y difícil de mantener.

# Parte 2 - OCP: Open/Closed Principle

## Código malo

```csharp
public class Descuento
{
    public double Calcular(string tipoCliente, double monto)
    {
        if (tipoCliente == "Regular")
            return monto * 0.05;

        if (tipoCliente == "VIP")
            return monto * 0.10;

        return 0;
    }
}
```

## Problema del código

Cada vez que aparece un nuevo tipo de cliente es necesario modificar la clase.

## Código refactorizado

```csharp
public interface IDescuento
{
    double Calcular(double monto);
}

public class DescuentoRegular : IDescuento
{
    public double Calcular(double monto)
    {
        return monto * 0.05;
    }
}

public class DescuentoVIP : IDescuento
{
    public double Calcular(double monto)
    {
        return monto * 0.10;
    }
}

public class DescuentoPremium : IDescuento
{
    public double Calcular(double monto)
    {
        return monto * 0.15;
    }
}
```

## Preguntas de análisis

### ¿Por qué este código no es escalable?

Porque obliga a modificar la clase cada vez que aparece un nuevo tipo de descuento.

### ¿Cómo ayuda el polimorfismo?

Permite utilizar diferentes tipos de descuentos mediante una misma interfaz.

### ¿Qué ventaja ofrece OCP en proyectos grandes?

Permite agregar funcionalidades sin modificar código existente.

# Parte 3 - LSP: Liskov Substitution Principle

## Código malo

```csharp
public class Ave
{
    public virtual void Volar()
    {
        Console.WriteLine("Volando...");
    }
}

public class Pinguino : Ave
{
    public override void Volar()
    {
        throw new Exception("Los pingüinos no vuelan");
    }
}
```

## Problema del código

El pingüino no puede cumplir correctamente el comportamiento esperado de la clase Ave.

## Código refactorizado

```csharp
public interface IAve
{
    void Moverse();
}

public interface IAveVoladora
{
    void Volar();
}

public class Aguila : IAve, IAveVoladora
{
    public void Moverse()
    {
        Console.WriteLine("El águila se mueve");
    }

    public void Volar()
    {
        Console.WriteLine("El águila vuela");
    }
}

public class Pinguino : IAve
{
    public void Moverse()
    {
        Console.WriteLine("El pingüino camina y nada");
    }
}
```

## Preguntas de análisis

### ¿Por qué el pingüino viola LSP?

Porque no puede sustituir correctamente a la clase base sin generar errores.

### ¿Qué riesgos genera esto?

Puede provocar excepciones y comportamientos inesperados.

### ¿Cómo mejorarías la jerarquía?

Separando los comportamientos mediante interfaces específicas para aves voladoras y no voladoras.

# Reflexión final

## ¿Cuál principio SOLID consideras más difícil?

Considero que el principio de Sustitución de Liskov es el más complejo porque requiere diseñar correctamente las jerarquías de clases.

## ¿Cuál crees que aporta más valor?

El principio de Responsabilidad Única aporta gran valor porque mejora significativamente la organización del código.

## ¿Cómo cambiaría tu manera de programar después de esta actividad?

Intentaría diseñar clases más pequeñas, especializadas y fáciles de mantener.

## ¿Qué diferencias notas entre un código rápido y un código bien diseñado?

Un código rápido puede funcionar inicialmente, pero suele ser difícil de mantener. Un código bien diseñado es más organizado, reutilizable, escalable y fácil de modificar.
