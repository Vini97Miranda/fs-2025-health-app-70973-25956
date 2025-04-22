using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Connections;
using Microsoft.EntityFrameworkCore.Metadata;
using RabbitMQ.Client;

namespace DoctorAppointment.API.Services
{
    public class AppointmentCreatedPublisher
    {
        private readonly RabbitMQ.Client.IModel _channel;


        public AppointmentCreatedPublisher()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            var connection = factory.CreateConnection();
            _channel = connection.CreateModel();

            _channel.QueueDeclare(queue: "appointments",
                                  durable: false,
                                  exclusive: false,
                                  autoDelete: false,
                                  arguments: null);
        }

        public void Publish(object message)
        {
            var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message));

            _channel.BasicPublish(exchange: "",
                                  routingKey: "appointments",
                                  basicProperties: null,
                                  body: body);
        }
    }
}
