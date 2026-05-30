<div align="center">
  <h1>BeyondNet.Ddd</h1>
  <p><strong>A Domain-Driven Design (DDD) library for .NET</strong></p>

  <p>
    <a href="README.en.md">🇬🇧 English</a> | <a href="README.es.md">🇪🇸 Español</a>
  </p>

  <p>
    <a href="https://www.nuget.org/profiles/BeyondNetCode">
      <img src="https://img.shields.io/badge/NuGet-BeyondNetCode-blue" alt="NuGet" />
    </a>
    <a href="https://github.com/beyondnetcode/Shell.ddd/actions">
      <img src="https://github.com/beyondnetcode/Shell.ddd/workflows/CI%20/%20CD/badge.svg" alt="Build" />
    </a>
  </p>
</div>

---

Welcome to **BeyondNet.Ddd**! A library for implementing Domain-Driven Design patterns in .NET with clean, maintainable code.

## Installation

### NuGet Packages

```bash
# Core DDD library
dotnet add package BeyondNetCode.Shell.Ddd

# Value Objects
dotnet add package BeyondNetCode.Shell.Ddd.ValueObjects

# AutoMapper integration
dotnet add package BeyondNetCode.Shell.Ddd.AutoMapper
```

### Packages Overview

| Package | Description | NuGet |
|---------|-------------|-------|
| `BeyondNetCode.Shell.Ddd` | Core DDD abstractions (Entity, AggregateRoot, DomainEvents, Rules) | [link](https://www.nuget.org/packages/BeyondNetCode.Shell.Ddd) |
| `BeyondNetCode.Shell.Ddd.ValueObjects` | Pre-built value objects (IdValueObject, AuditValueObject, Validators) | [link](https://www.nuget.org/packages/BeyondNetCode.Shell.Ddd.ValueObjects) |
| `BeyondNetCode.Shell.Ddd.AutoMapper` | AutoMapper integration for DDD entities | [link](https://www.nuget.org/packages/BeyondNetCode.Shell.Ddd.AutoMapper) |

## Features

- **Entity Base Class**: Full-featured entity implementation with tracking, validation, and business rules
- **Aggregate Root**: Specialized entity for aggregate roots with domain events support
- **Value Objects**: Immutable value objects with built-in validation
- **Business Rules**: Rule engine with `BrokenRulesManager` for domain validation
- **Property Change Tracking**: INotifyPropertyChanged implementation with change tracking
- **AutoMapper Integration**: Seamless mapping between DTOs and domain entities
- **MediatR Integration**: Built-in support for domain events via MediatR

## Quick Start

### Define an Entity

```csharp
public class SampleName : ValueObject<SampleName>
{
    public string Value { get; }

    public SampleName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentNullException(nameof(value));

        Value = value;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}

public class SampleEntityProps : IProps
{
    public SampleName Name { get; set; }
}

public class SampleEntity : Entity<SampleEntity, SampleEntityProps>
{
    public SampleEntity(SampleEntityProps props) : base(props)
    {
    }

    public static SampleEntity Create(string name)
    {
        var props = new SampleEntityProps { Name = new SampleName(name) };
        return new SampleEntity(props);
    }

    public override void AddValidators()
    {
        ValidatorRules.Add(new SampleNameValidator());
    }
}
```

### Define an Aggregate Root with Domain Events

```csharp
public class SampleCreatedDomainEvent : DomainEvent
{
    public Guid EntityId { get; }
    public string Name { get; }

    public SampleCreatedDomainEvent(Guid entityId, string name)
    {
        EntityId = entityId;
        Name = name;
    }
}

public class SampleAggregateRootProps : IProps
{
    public SampleName Name { get; set; }
}

public class SampleAggregateRoot : AggregateRoot<SampleAggregateRoot, SampleAggregateRootProps>
{
    public SampleAggregateRoot(SampleAggregateRootProps props) : base(props)
    {
    }

    public static SampleAggregateRoot Create(string name)
    {
        var props = new SampleAggregateRootProps { Name = new SampleName(name) };
        var entity = new SampleAggregateRoot(props);
        entity.DomainEvents.Add(new SampleCreatedDomainEvent(entity.Id.Value, name));
        return entity;
    }
}
```

### Use with AutoMapper

```csharp
// Configure AutoMapper
var config = new MapperConfiguration(cfg =>
{
    cfg.AddProfile<ParentRootProfile>();
});
var mapper = new Mapper(config);

// Map DTO to Entity
var dto = new SampleEntityDto { Id = "1", Name = "test" };
var props = mapper.Map<SampleEntityProps>(dto);
var entity = new SampleEntity(props);
```

## Documentation

For detailed documentation, see the language-specific README files:
- [English](README.en.md)
- [Español](README.es.md)

## Migration from Ums.Shell.Ddd

If you were using `Ums.Shell.Ddd`, update your NuGet references:

```bash
# Before (Ums.Shell.Ddd)
dotnet add package Ums.Shell.Ddd

# After (BeyondNetCode.Shell.Ddd)
dotnet add package BeyondNetCode.Shell.Ddd
```

Update namespaces in your code:
```csharp
// Before
using Ums.Shell.Ddd;

// After
using BeyondNetCode.Shell.Ddd;
```

## Contributing

See [CONTRIBUTING.md](CONTRIBUTING.md) for GitFlow workflow, commit conventions, and coding standards.

## Versioning

See [VERSIONING.md](VERSIONING.md) for SemVer strategy and release process.

## License

Licensed under the MIT License. See [LICENSE](LICENSE) for details.

## Acknowledgments

See [DISCLAIMER.md](DISCLAIMER.md) for original code authorship attribution.