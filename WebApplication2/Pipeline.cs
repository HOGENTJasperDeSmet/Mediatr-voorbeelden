using MediatR;
//Pipeline enkel voor requesthandlers
//Common use case validatie / logging

//Standaard is er ook nog de pre processor en de postprocessor
public class Pipeline<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        //Voor de handler
        Console.WriteLine($"Handling {typeof(TRequest).Name}");
        var r = await next();
        //Na de handler
        Console.WriteLine($"Handled {typeof(TRequest).Name}");
        return r;
    }
}
