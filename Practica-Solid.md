# Práctica de Refactorización SOLID

## Nombres de los integrantes

- Dohrian Miguel Peña Castro
- Enmanuel Molina Abreu

## Tema

Refactorización de los principios SOLID: SRP, OCP, LSP, ISP y DIP.

---

# Introducción

En esta práctica se analizan cinco ejemplos de código con problemas de diseño orientado a objetos. Cada ejemplo es refactorizado aplicando principios SOLID para mejorar la organización, mantenibilidad y escalabilidad del software.

Los principios trabajados son:

- SRP (Single Responsibility Principle)
- OCP (Open/Closed Principle)
- LSP (Liskov Substitution Principle)
- ISP (Interface Segregation Principle)
- DIP (Dependency Inversion Principle)

---

# Investigación y análisis

## ¿Qué significa SOLID?

SOLID es un conjunto de cinco principios de diseño de software orientado a objetos que ayudan a desarrollar aplicaciones más mantenibles, flexibles y escalables.

### S — Single Responsibility Principle
Una clase debe tener una única responsabilidad y una sola razón para cambiar.

### O — Open/Closed Principle
Las clases deben estar abiertas para extensión pero cerradas para modificación.

### L — Liskov Substitution Principle
Las clases derivadas deben poder sustituir a las clases base sin alterar el comportamiento esperado.

### I — Interface Segregation Principle
Las interfaces deben ser específicas y no obligar a implementar métodos innecesarios.

### D — Dependency Inversion Principle
Los módulos de alto nivel deben depender de abstracciones y no de implementaciones concretas.

---

## ¿Por qué SOLID es importante en la Programación Orientada a Objetos?

SOLID permite desarrollar software más organizado, flexible y fácil de mantener. Su aplicación reduce errores y facilita la incorporación de nuevas funcionalidades sin afectar el código existente.

### ¿Cómo ayuda SOLID a mantener proyectos grandes?
Permite dividir responsabilidades, reducir dependencias innecesarias y mejorar la organización general del sistema, facilitando el trabajo de múltiples desarrolladores.

### ¿Qué problemas aparecen cuando no se usan estos principios?
- Código difícil de entender
- Mayor cantidad de errores
- Dependencias excesivas
- Baja reutilización de código
- Dificultad para realizar pruebas
- Problemas para escalar el sistema

### Influencia de SOLID

| Área | Impacto |
|------|---------|
| **Mantenimiento** | Facilita corregir errores y realizar actualizaciones |
| **Reutilización** | Permite utilizar componentes en diferentes proyectos |
| **Escalabilidad** | Facilita agregar nuevas funcionalidades |
| **Pruebas** | Permite probar componentes de manera independiente |
| **Trabajo en equipo** | Mejora la organización y colaboración entre desarrolladores |

---

# Conceptos clave

| Concepto | Definición |
|----------|-----------|
| **Acoplamiento** | Nivel de dependencia que existe entre diferentes clases o módulos |
| **Cohesión** | Grado en que los elementos de una clase están relacionados para cumplir una única responsabilidad |
| **Refactorización** | Proceso de mejorar la estructura interna del código sin modificar su comportamiento externo |
| **Escalabilidad** | Capacidad de un sistema para crecer y soportar nuevas funcionalidades |
| **Mantenibilidad** | Facilidad con la que un sistema puede ser corregido, actualizado o mejorado |
| **Abstracción** | Representación de las características esenciales ocultando detalles innecesarios |
| **Dependencias** | Relaciones entre clases donde una necesita utilizar otra para funcionar |

---

# 💻 Parte 1 — Principio S: Single Responsibility Principle (SRP)

## ❌ Código "malo"

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

## 🔍 Problema
La clase `Reporte` tiene tres responsabilidades distintas: generar, guardar y enviar. Cualquier cambio en una de ellas puede afectar a las demás.

## ✅ Código refactorizado

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

**1. ¿Qué problema tenía el diseño original?**  
La clase concentraba múltiples responsabilidades en un solo lugar, dificultando el mantenimiento. Un cambio en el envío de correos, por ejemplo, obligaba a tocar la misma clase que generaba el reporte.

**2. ¿Qué ventajas aporta la refactorización?**  
Cada clase tiene una única razón para cambiar. Mejora la organización, la reutilización y la capacidad de probar cada componente de forma independiente.

**3. ¿Qué ocurriría si el sistema crece?**  
La clase original se volvería cada vez más compleja y difícil de mantener, acumulando lógica de negocios no relacionada entre sí.

---

# 💻 Parte 2 — Principio O: Open/Closed Principle (OCP)

## ❌ Código "malo"

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

## 🔍 Problema
Cada vez que aparece un nuevo tipo de cliente es necesario modificar la clase, violando OCP.

## ✅ Código refactorizado

```csharp
public interface IDescuento
{
    double Calcular(double monto);
}

public class DescuentoRegular : IDescuento
{
    public double Calcular(double monto) => monto * 0.05;
}

public class DescuentoVIP : IDescuento
{
    public double Calcular(double monto) => monto * 0.10;
}

public class DescuentoPremium : IDescuento
{
    public double Calcular(double monto) => monto * 0.15;
}
```

## Preguntas de análisis

**1. ¿Por qué el código original no es escalable?**  
Obliga a modificar la clase cada vez que aparece un nuevo tipo de descuento, incrementando el riesgo de introducir bugs en lógica ya funcional.

**2. ¿Cómo ayuda el polimorfismo?**  
Permite usar diferentes tipos de descuento a través de una misma interfaz, sin conocer la implementación concreta.

**3. ¿Qué ventaja ofrece OCP en proyectos grandes?**  
Permite agregar funcionalidades (nuevos tipos de descuento) creando nuevas clases, sin tocar el código existente.

---

# 💻 Parte 3 — Principio L: Liskov Substitution Principle (LSP)

## ❌ Código "malo"

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

## 🔍 Problema
`Pinguino` no puede sustituir a `Ave` sin lanzar una excepción, rompiendo el contrato de la clase base.

## ✅ Código refactorizado

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
    public void Moverse() => Console.WriteLine("El águila se mueve");
    public void Volar()   => Console.WriteLine("El águila vuela");
}

public class Pinguino : IAve
{
    public void Moverse() => Console.WriteLine("El pingüino camina y nada");
}
```

## Preguntas de análisis

**1. ¿Por qué el pingüino viola LSP?**  
Porque no puede sustituir correctamente a la clase base sin generar errores en tiempo de ejecución.

**2. ¿Qué riesgos genera esto?**  
Puede provocar excepciones inesperadas y comportamiento incorrecto al usar polimorfismo con la clase base.

**3. ¿Cómo mejorarías la jerarquía?**  
Separando los comportamientos mediante interfaces específicas (`IAve`, `IAveVoladora`), de modo que cada clase implemente solo lo que realmente puede hacer.

---

# 💻 Parte 4 — Principio I: Interface Segregation Principle (ISP)

> 📁 **Proyecto:** [`ISP.zip`](./ISP.zip)

## ❌ Código "malo"

```csharp
public interface ITrabajador
{
    void Trabajar();
    void Comer();
}

public class Robot : ITrabajador
{
    public void Trabajar()
    {
        Console.WriteLine("Trabajando...");
    }

    public void Comer()
    {
        throw new Exception("Los robots no comen");
    }
}
```

## 🔍 Problema
La interfaz obliga a implementar métodos innecesarios. `Robot` no puede comer, pero el contrato lo fuerza a implementar el método de todas formas, resultando en un `throw` como única salida.

## ✅ Código refactorizado

```csharp
// Interfaces segregadas
public interface ITrabajador
{
    void Trabajar();
}

public interface IComedor
{
    void Comer();
}

// El humano implementa AMBAS porque las necesita
public class Humano : ITrabajador, IComedor
{
    public void Trabajar() => Console.WriteLine("Humano trabajando...");
    public void Comer()    => Console.WriteLine("Humano comiendo...");
}

// El robot SOLO implementa lo que realmente puede hacer
public class Robot : ITrabajador
{
    public void Trabajar() => Console.WriteLine("Robot trabajando...");
}
```

### Estructura del proyecto ISP

```
ISP/
├── Interfaces/
│   ├── ITrabajador.cs
│   └── IComedor.cs
├── Clases/
│   ├── Humano.cs
│   └── Robot.cs
├── Program.cs
└── ISP.csproj
```

### Salida esperada

```
=== Interface Segregation Principle (ISP) ===

>> Todos los trabajadores trabajan:
Humano trabajando...
Robot trabajando...

>> Solo entidades que comen, implementan IComedor:
Humano comiendo...

>> Robot no tiene Comer() → sin throws, sin métodos vacíos.
   Compilador garantiza el contrato en tiempo de compilación.

=== Fin ISP ===
```

## Preguntas de análisis

**1. ¿Qué problema presenta la interfaz original?**  
Obliga a clases que no necesitan ciertos métodos a implementarlos de todas formas. `Robot` se ve forzado a implementar `Comer()` con un `throw`, lo que es un error de diseño disfrazado de excepción en tiempo de ejecución.

**2. ¿Cómo mejora ISP el diseño?**  
ISP divide interfaces grandes en contratos más pequeños y específicos. Cada clase implementa solo lo que realmente necesita, eliminando implementaciones vacías o con `throw`.

**3. ¿Qué ventajas ofrece dividir interfaces?**  
- **Menos acoplamiento**: los cambios en `IComedor` no afectan a `Robot`.  
- **Mayor legibilidad**: el contrato de cada clase es explícito desde su definición.  
- **Facilita pruebas**: se puede mockear solo la interfaz necesaria.  
- **Extensibilidad**: se pueden añadir nuevas interfaces (`IConductor`, `IDormilón`) sin romper código existente.

---

# 💻 Parte 5 — Principio D: Dependency Inversion Principle (DIP)

> 📁 **Proyecto:** [`DIP.zip`](./DIP.zip)

## ❌ Código "malo"

```csharp
public class MySQLDatabase
{
    public void Guardar()
    {
        Console.WriteLine("Guardando en MySQL");
    }
}

public class UsuarioService
{
    private MySQLDatabase db = new MySQLDatabase();

    public void CrearUsuario()
    {
        db.Guardar();
    }
}
```

## 🔍 Problema
`UsuarioService` depende directamente de `MySQLDatabase`. Cambiar de base de datos implica modificar el servicio, violando tanto DIP como OCP.

## ✅ Código refactorizado

```csharp
// 1. Abstracción
public interface IDatabase
{
    void Guardar(string datos);
}

// 2. Implementaciones concretas
public class MySQLDatabase : IDatabase
{
    public void Guardar(string datos)
        => Console.WriteLine($"[MySQL] Guardando: {datos}");
}

public class PostgreSQLDatabase : IDatabase
{
    public void Guardar(string datos)
        => Console.WriteLine($"[PostgreSQL] Guardando: {datos}");
}

public class InMemoryDatabase : IDatabase  // para pruebas unitarias
{
    public void Guardar(string datos)
        => Console.WriteLine($"[InMemory] Guardando en memoria: {datos}");
}

// 3. Módulo de alto nivel depende de la ABSTRACCIÓN
public class UsuarioService
{
    private readonly IDatabase _db;

    public UsuarioService(IDatabase db)  // Inyección por constructor
    {
        _db = db;
    }

    public void CrearUsuario(string nombre)
    {
        _db.Guardar($"Usuario: {nombre}");
    }
}
```

### Estructura del proyecto DIP

```
DIP/
├── Abstracciones/
│   └── IDatabase.cs
├── Implementaciones/
│   ├── MySQLDatabase.cs
│   ├── PostgreSQLDatabase.cs
│   └── InMemoryDatabase.cs
├── Servicios/
│   └── UsuarioService.cs
├── Program.cs
└── DIP.csproj
```

### Salida esperada

```
=== Dependency Inversion Principle (DIP) ===

>> Usando MySQL:
Creando usuario 'Ana García'...
[MySQL] Guardando: Usuario: Ana García
Usuario creado correctamente.

>> Usando PostgreSQL:
Creando usuario 'Luis Pérez'...
[PostgreSQL] Guardando: Usuario: Luis Pérez
Usuario creado correctamente.

>> Usando InMemory (pruebas unitarias):
Creando usuario 'Carlos Test'...
[InMemory] Guardando en memoria: Usuario: Carlos Test
Usuario creado correctamente.

>> Registros en memoria:
   - Usuario: Carlos Test

=== Fin DIP ===
UsuarioService nunca fue modificado. Solo se cambió la implementación inyectada.
```

## Preguntas de análisis

**1. ¿Por qué el acoplamiento es un problema?**  
Cuando `UsuarioService` instancia `MySQLDatabase` con `new`, quedan soldados. Cambiar de base de datos obliga a modificar el servicio, lo que puede introducir errores en lógica que ya funcionaba.

**2. ¿Qué ventajas ofrece depender de abstracciones?**  
- El servicio no sabe ni le importa qué base de datos usa.  
- Se puede sustituir la implementación sin modificar código de negocio.  
- Agregar `MongoDatabase` solo requiere implementar `IDatabase`.

**3. ¿Cómo ayuda DIP en pruebas unitarias?**  
Permite inyectar una implementación falsa (`InMemoryDatabase`, un mock o stub) en lugar de una base de datos real. Las pruebas son **rápidas, aisladas y sin dependencias externas**.

---

# Reflexión final

**¿Cuál principio SOLID consideras más difícil?**  
El principio de Sustitución de Liskov (LSP) es el más complejo porque requiere diseñar correctamente las jerarquías de clases desde el inicio.

**¿Cuál crees que aporta más valor?**  
El principio de Responsabilidad Única (SRP) aporta gran valor porque mejora significativamente la organización y legibilidad del código.

**¿Cómo cambiaría tu manera de programar después de esta actividad?**  
Intentaríamos diseñar clases más pequeñas, especializadas y fáciles de mantener, pensando primero en los contratos antes que en las implementaciones.

**¿Qué diferencias notas entre un código rápido y un código bien diseñado?**  
Un código rápido puede funcionar inicialmente, pero suele ser difícil de mantener y escalar. Un código bien diseñado es más organizado, reutilizable y fácil de modificar, lo que ahorra tiempo a largo plazo.

---

## Resumen de principios

| Principio | Problema que resuelve | Herramienta clave |
|-----------|----------------------|-------------------|
| **SRP** | Clases con múltiples responsabilidades | Separar en clases especializadas |
| **OCP** | Modificar código existente al extender | Interfaces + polimorfismo |
| **LSP** | Subclases que rompen el contrato de la base | Jerarquías e interfaces bien diseñadas |
| **ISP** | Interfaces "gordas" con métodos innecesarios | Dividir en interfaces pequeñas |
| **DIP** | Acoplamiento a implementaciones concretas | Interfaces + Inyección de dependencias |
