public class HelloRequest : IReturn<HelloResponse>
{
    public string Name { get; set; }
}

public class HelloResponse
{
    public string Response { get; set; }
}

public interface IGreeter
{
    string Greet(string name);
}

public class Greeter : IGreeter
{
    public string Greet(string name)
    {
        if (!string.IsNullOrEmpty(name))
        {
            return string.Format("Hello {0}!", request.Name);
        }

        return "Hello stranger!";
    }
}

public class HelloService : Service
{
    private IGreeter _greeter;

    public HelloService(IGreeter greeter)
    {
        _greeter = greeter;
    }

    public HelloResponse Get(HelloRequest request)
    {
        var greeting = _greeter.Greet(request.Name);
        return new HelloResponse { Response = greeting };
    }
}

Require<ServiceStackPack>().StartHost("http://localhost:8080/", host =>
{
    host.Routes.Add<HelloRequest>("/hello");	
    host.Routes.Add<HelloRequest>("/hello/{Name}");	

    host.Container.Register<IGreeter>(c => new Greeter());
});
