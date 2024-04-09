namespace webapi_5b;

using Microsoft.EntityFrameworkCore;
using webapi_5b.Models;

public class AssignmentsContext : DbContext
{
  public DbSet<Category> Categories { get; set; }

  public DbSet<Assignment> Assignments { get; set; }

  public DbSet<User> Users { get; set; }

  public AssignmentsContext(DbContextOptions<AssignmentsContext> options) : base(options) { }

  public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
  {
    var now = DateTime.UtcNow;

    // Actualizar las propiedades CreatedAt y UpdatedAt antes de guardar
    foreach (var entry in ChangeTracker.Entries())
    {
      if (entry.Entity is BaseEntity baseEntity)
      {
        switch (entry.State)
        {
          case EntityState.Added:
            baseEntity.CreatedAt = now;
            goto case EntityState.Modified;

          case EntityState.Modified:
            baseEntity.UpdatedAt = now;
            break;
        }
      }
    }

    return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {

    // Category
    List<Category> categoriesInit = new List<Category>
    {
        new() { CategoryId = Guid.Parse("ea6202de-5314-4ce0-903b-94fa7c8ef5ed"), Name = "Trabajo", Description = "Tareas relacionadas con tu empleo, proyectos, reuniones, etc." },
        new() { CategoryId = Guid.Parse("1bbc3cae-8cea-48e1-9ba4-07ec45d981e0"), Name = "Estudios", Description = "Tareas relacionadas con la escuela, universidad, cursos, exámenes, etc." },
        new() { CategoryId = Guid.Parse("e530a381-1f4e-4f02-b04e-506e9e3ed818"), Name = "Hogar", Description = "Tareas domésticas como limpieza, compras, mantenimiento, etc." },
        new() { CategoryId = Guid.Parse("8e50a50e-7347-458d-9b14-87b47a19103d"), Name = "Salud", Description = "Tareas relacionadas con el ejercicio, la nutrición, las citas médicas, etc." },
        new() { CategoryId = Guid.Parse("6541e05c-69a6-4829-b037-86ddc19b1240"), Name = "Finanzas", Description = "Tareas relacionadas con el presupuesto, pagos, inversiones, etc." },
        new() { CategoryId = Guid.Parse("4d7d29b4-f1c8-44f5-882b-14f0d586392f"), Name = "Social", Description = "Tareas relacionadas con eventos, reuniones con amigos, actividades sociales, etc." },
        new() { CategoryId = Guid.Parse("06c65d54-2c86-40f7-ba8e-d0265486f1b5"), Name = "Personal", Description = "Tareas relacionadas con el autocuidado, el desarrollo personal, pasatiempos, etc." },
        new() { CategoryId = Guid.Parse("9d728f3a-903b-4ba1-88c3-9f171b84b5a6"), Name = "Viajes", Description = "Tareas relacionadas con la planificación de viajes, reservas, preparativos, etc." },
        new() { CategoryId = Guid.Parse("cb0ee61c-b0f3-439a-9315-3f2f589f71e0"), Name = "Proyectos personales", Description = "Tareas relacionadas con proyectos personales o pasatiempos específicos." },
        new() { CategoryId = Guid.Parse("c2643f9a-06fd-4cc8-a95a-44d63536aa3a"), Name = "Recordatorios", Description = "Tareas que son simplemente recordatorios generales sin una categoría específica." }
    };


    modelBuilder.Entity<Category>(category =>
    {
      category.ToTable("Category");
      category.HasKey(p => p.CategoryId);

      category.Property(p => p.Name).IsRequired();

      category.Property(p => p.Description).IsRequired(false);

      category.Property(p => p.CreatedAt).HasDefaultValueSql("now()");

      category.Property(p => p.UpdatedAt).HasDefaultValueSql("now()");

      category.HasData(categoriesInit);
    });

    // User
    List<User> usersInit = new List<User>
    {
        new() { UserId = Guid.Parse("956f8f95-d67a-4501-96c6-b362fada236d"), Name = "Usuario 5B", Username = "user5b", Password = "user5b" },
        new() { UserId = Guid.Parse("46c33b69-cccf-44cb-99f3-d74454f77dc1"), Name = "Christian Osorio", Username = "cosorio", Password = "cosorio" }
    };


    modelBuilder.Entity<User>(user =>
    {
      user.ToTable("User");
      user.HasKey(p => p.UserId);

      user.Property(p => p.Name).IsRequired();

      user.Property(p => p.Username).IsRequired();

      user.Property(p => p.Password).IsRequired();

      user.Property(p => p.CreatedAt).HasDefaultValueSql("now()");

      user.Property(p => p.UpdatedAt).HasDefaultValueSql("now()");

      user.HasData(usersInit);
    });

    // Assignment
    List<Assignment> assignmentsInit = new List<Assignment>
    {
        new() { AssignmentId = Guid.NewGuid(), Title = "Tarea 1", Description = "Descripción de la tarea 1", AssignmentPriority = Priority.High, CategoryId = categoriesInit[0].CategoryId, UserId = usersInit[0].UserId },
        new() { AssignmentId = Guid.NewGuid(), Title = "Tarea 2", Description = "Descripción de la tarea 2", AssignmentPriority = Priority.Half, CategoryId = categoriesInit[1].CategoryId, UserId = usersInit[1].UserId }
    };

    modelBuilder.Entity<Assignment>(assignment =>
    {
      assignment.ToTable("Assignment");
      assignment.HasKey(p => p.AssignmentId);

      assignment.HasOne(p => p.Category).WithMany(p => p.Assignments).HasForeignKey(p => p.CategoryId);
      assignment.HasOne(p => p.User).WithMany(p => p.Assignments).HasForeignKey(p => p.UserId);

      assignment.Property(p => p.Title).IsRequired();

      assignment.Property(p => p.Description).IsRequired(false);

      assignment.Property(p => p.AssignmentPriority);

      assignment.Property(p => p.CreatedAt).HasDefaultValueSql("now()");

      assignment.Property(p => p.UpdatedAt).HasDefaultValueSql("now()");

      assignment.HasData(assignmentsInit);

    });
  }
}