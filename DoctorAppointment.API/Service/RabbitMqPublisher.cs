using Microsoft.AspNetCore.Connections;
using Microsoft.EntityFrameworkCore.Metadata;
using RabbitMQ.Client;
using System.Text;
using RabbitMQ.Client;


public class RabbitMqPublisher
{
    private readonly IConnection _connection;
    private readonly RabbitMQ.Client.IModel _channel;


    public RabbitMqPublisher()
    {
        var factory = new ConnectionFactory() { HostName = "localhost" };
        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();
    }

    public void Publish(string queueName, string message)
    {
        _channel.QueueDeclare(queue: queueName,
                              durable: false,
                              exclusive: false,
                              autoDelete: false,
                              arguments: null);

        var body = Encoding.UTF8.GetBytes(message);

        _channel.BasicPublish(exchange: "",
                              routingKey: queueName,
                              basicProperties: null,
                              body: body);
    }
}
