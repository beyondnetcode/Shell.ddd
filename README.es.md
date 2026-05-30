# BeyondNet.Ddd

<p>
  <a href="README.en.md">English</a> | <strong>Español</strong>
</p>

BeyondNet.Ddd es una libreria para implementar patrones de Diseno Orientado al Dominio (DDD) en .NET 10. Proporciona una base solida para construir aplicaciones de negocio complejas con modelos de dominio limpios y mantenibles.

## Caracteristicas

- **Clase Entidad Base**: Implementacion de entidad completa con seguimiento, validacion y reglas de negocio
- **Aggregate Root**: Entidad especializada para agregados con soporte de eventos de dominio
- **Value Objects**: Objetos de valor inmutables con validacion incorporada (IdValueObject, AuditValueObject, etc.)
- **Reglas de Negocio**: Motor de reglas con `BrokenRulesManager` para validacion de dominio
- **Seguimiento de Cambios de Propiedades**: Implementacion de INotifyPropertyChanged con seguimiento de cambios
- **Integracion AutoMapper**: Mapeo fluido entre DTOs y entidades de dominio
- **Integracion MediatR**: Soporte incorporado para eventos de dominio via MediatR

## Arquitectura

La libreria esta organizada en paquetes modulares:

```
BeyondNetCode.Shell.Ddd              # DDD Core (Entity, AggregateRoot, DomainEvents)
BeyondNetCode.Shell.Ddd.ValueObjects  # Value Objects y Validators
BeyondNetCode.Shell.Ddd.AutoMapper    # Integracion AutoMapper
```

## Instalacion

```bash
# Libreria core
dotnet add package BeyondNetCode.Shell.Ddd

# Value Objects
dotnet add package BeyondNetCode.Shell.Ddd.ValueObjects

# Integracion AutoMapper
dotnet add package BeyondNetCode.Shell.Ddd.AutoMapper
```

## Conceptos Basicos

### Entidad

```csharp
public class SampleEntityProps : IProps
{
    public SampleName Name { get; set; }
}

public class SampleEntity : Entity<SampleEntity, SampleEntityProps>
{
    public SampleEntity(SampleEntityProps props) : base(props)
    {
        // Inicializacion de entidad
    }

    public static SampleEntity Create(string name)
    {
        var props = new SampleEntityProps { Name = new SampleName(name) };
        return new SampleEntity(props);
    }
}
```

### Aggregate Root

```csharp
public class SampleAggregateRoot : AggregateRoot<SampleAggregateRoot, SampleAggregateRootProps>
{
    public SampleAggregateRoot(SampleAggregateRootProps props) : base(props)
    {
        DomainEvents = new DomainEventsManager(this);
    }

    public void AddDomainEvent(DomainEvent domainEvent)
    {
        DomainEvents.Add(domainEvent);
    }
}
```

### Value Objects

```csharp
public class SampleName : ValueObject<SampleName>
{
    public string Value { get; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
```

### Reglas de Negocio

```csharp
public class SampleEntity : Entity<SampleEntity, SampleEntityProps>
{
    public override void AddValidators()
    {
        ValidatorRules.Add(new SampleEntityValidator());
    }
}
```

## Testing

```bash
dotnet test
```

## Contribuir

Ver [CONTRIBUTING.md](CONTRIBUTING.md) para el flujo de GitFlow y estandares de codificacion.

## Versionado

Ver [VERSIONING.md](VERSIONING.md) para estrategia de SemVer.

## Licencia

MIT - Ver [LICENSE](LICENSE)

## Reconocimientos

Ver [DISCLAIMER.md](DISCLAIMER.md) para atribucion de autoria del codigo original.