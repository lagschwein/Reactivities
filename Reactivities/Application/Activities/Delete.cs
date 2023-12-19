using MediatR;
using Persistence;

namespace Application.Activities
{
    public class Delete
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task Handle(Command request, CancellationToken cancellationToken)
            {
                // Presuming that this activity exists
                // If it doesn't returns null
                var activity = await _context.Activities.FindAsync(request.Id);
                _context.Remove(activity);

                await _context.SaveChangesAsync();
            }
        }

    }
}