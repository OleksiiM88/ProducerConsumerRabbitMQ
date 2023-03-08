using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

var factory = new ConnectionFactory() { HostName = "localhost" };
using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

channel.QueueDeclare("TestMessage", false, false, false, null);

var consumer = new EventingBasicConsumer(channel);
consumer.Received += (model, ea) => { var body = ea.Body.Span; string message = Encoding.UTF8.GetString(body); Console.WriteLine($"Received message: {message}..."); };

channel.BasicConsume("TestMessage", true, consumer);

Console.WriteLine("Press enter to exit consumer...");
Console.ReadLine();