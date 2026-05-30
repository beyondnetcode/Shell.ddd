# BeyondNet.Ddd

<p>
  <strong>English</strong> | <a href="README.es.md">Español</a>
</p>

BeyondNet.Ddd is a library for implementing Domain-Driven Design (DDD) patterns in .NET 10. It provides a solid foundation for building complex business applications with clean, maintainable domain models.

## Features

- **Entity Base Class**: Full-featured entity implementation with tracking, validation, and business rules
- **Aggregate Root**: Specialized entity for aggregate roots with domain events support
- **Value Objects**: Immutable value objects with built-in validation (IdValueObject, AuditValueObject, etc.)
- **Business Rules**: Rule engine with `BrokenRulesManager` for domain validation
- **Property Change Tracking**: INotifyPropertyChanged implementation with change tracking
- **AutoMapper Integration**: Seamless mapping between DTOs and domain entities
- **MediatR Integration**: Built-in support for domain events via MediatR

## Architecture

The library is organized into modular packages:

```
BeyondNetCode.Shell.Ddd              # Core DDD (Entity, AggregateRoot, DomainEvents)
BeyondNetCode.Shell.Ddd.ValueObjects  # Value Objects and Validators
BeyondNetCode.Shell.Ddd.AutoMapper    # AutoMapper integration
```

## Installation

```bash
# Core library
dotnet add package BeyondNetCode.Shell.Ddd

# Value Objects
dotnet add package BeyondNetCode.Shell.Ddd.ValueObjects

# AutoMapper integration
dotnet add package BeyondNetCode.Shell.Ddd.AutoMapper
```

## Core Concepts

### Entity

```csharp
public class SampleEntityProps : IProps
{
    public SampleName Name { get; set; }
}

public class SampleEntity : Entity<SampleEntity, SampleEntityProps>
{
    public SampleEntity(SampleEntityProps props) : base(props)
    {
        // Entity initialization
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

### Business Rules

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

## Contributing

See [CONTRIBUTING.md](CONTRIBUTING.md) for GitFlow workflow and coding standards.

## Versioning

See [VERSIONING.md](VERSIONING.md) for SemVer strategy.

## License

MIT - See [LICENSE](LICENSE)

## Acknowledgments

See [DISCLAIMER.md](DISCLAIMER.md) for original code authorship.