[Route("/hello")]
[Route("/hello/{Name}")]
public class HelloRequest : IReturn<HelloResponse>
{
	public string Name { get; set; }
}

public class HelloResponse
{
	public string Response { get; set; }
}

public class HelloWorldService : Service
{
	public HelloResponse Get(HelloRequest request)
	{
		if (!string.IsNullOrEmpty(request.Name))
		{
			var response = string.Format("Hello {0}!", request.Name);
			return new HelloResponse { Response = response };
		}

		return new HelloResponse { Response = "Hello stranger!" };
	}
}

Require<ServiceStackPack>().StartHost("http://localhost:8080/");