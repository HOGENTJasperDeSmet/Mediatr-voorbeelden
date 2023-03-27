using MediatR;

namespace WebApplication2;

//Streams
//Common use case ophalen van grote data
public class StreamTest : IStreamRequest<string> { }

public class StreamTestHandler : IStreamRequestHandler<StreamTest, string>
{
    public async IAsyncEnumerable<string> Handle(StreamTest request, CancellationToken cancellationToken)
    {
            using StreamReader reader = File.OpenText("test.txt");
            while (!reader.EndOfStream)
            {
                await Task.Delay(1000);
                yield return await reader.ReadLineAsync();
            }

        
    }
}
