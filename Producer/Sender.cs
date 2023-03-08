using RabbitMQ.Client;
using System.Text;

var factory = new ConnectionFactory() { HostName= "localhost" };
using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

channel.QueueDeclare("TestMessage", false, false, false, null);

string message = "This message will be posted to RabbitMQ server via producer!!!";
var body = Encoding.UTF8.GetBytes(message);

channel.BasicPublish(String.Empty, "TestMessage", null, body);
Console.WriteLine($"Sent message {message}...");

Console.WriteLine("Press enter to exit sender...");
Console.ReadLine();