using CQRSAndMediatRDemo.Domain.SeedWork;
using CQRSAndMediatRDemo.Infrastructure.Data;
using CQRSAndMediatRDemo.Infrastructure.EntityConfiguration;
using CQRSAndMediatRDemo.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRSAndMediatRDemo.Infrastructure.Data
{
    public class DbContextClass : DbContext, IUnitOfWork
    {
        private readonly IMediator _mediator;
        public const string Default_schema = "dbo";

        public DbContextClass(DbContextOptions options, IMediator mediator) : base(options)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        
        public DbSet<StudentDetails> Students { get; set; }
        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            await _mediator.DispatchDomainEventsAsync(this);
            await base.SaveChangesAsync(cancellationToken);



            return true;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StudentDetailsEntityTypeConfiguration());
        }
    }
}