using MediatR;

namespace WebApplication2;


//Request
internal class RequestTest : IRequest<Dier>
{
    public int id { get; set; }
}

internal class RequestTestHandler : IRequestHandler<RequestTest, Dier>
{
    public Dier[] dieren = new Dier[] { new Dier { id=1, Naam ="Schildpad",Icoon ="🐢", Aantal = 8},
        new Dier {id=2, Naam ="Koe",Icoon ="🐄", Aantal = 15},
        new Dier {id=3, Naam ="Luiaard",Icoon ="🦥", Aantal = 4},
        new Dier { id=4,Naam ="Konijn",Icoon ="🐇", Aantal = 22}};

    public Task<Dier> Handle(RequestTest request, CancellationToken cancellationToken)
    {
        return Task.FromResult(dieren.FirstOrDefault(x => x.id == request.id));
    }
}


internal record Dier()
{
    public int id { get; set; }
    public string Naam { get; set; }
    public string Icoon { get; set; }
    public int Aantal { get; set; }
}