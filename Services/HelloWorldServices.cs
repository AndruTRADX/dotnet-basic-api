namespace apidotnet.Services;

// Create a simple service 
public class HelloWorldService : IHelloWorldService {
    public string GetHelloWorld()
    {
        return "Hello world";
    }
}

// Create an interface to use abstract types
public interface IHelloWorldService
{
    string GetHelloWorld();
}