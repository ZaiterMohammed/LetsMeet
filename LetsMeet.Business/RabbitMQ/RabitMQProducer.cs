using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Text;

namespace LetsMeet.WebApi.RabbitMQ
{
    public class RabitMQProducer : IRabitMQProducer
    { 
        public void SendProductMessage<T>(T message)
        {
            ////Here we specify the Rabbit MQ Server. we use rabbitmq docker image and use it
            //var factory = new ConnectionFactory
            //{
            //    HostName = "localhost"
            //};
            ////Create the RabbitMQ connection using connection factory details as i mentioned above
            //var connection = factory.CreateConnection();
            ////Here we create channel with session and model
            //using
            //var channel = connection.CreateModel();
            ////declare the queue after mentioning name and a few property related to that
            //channel.QueueDeclare("product", exclusive: false);
            ////Serialize the message
            //var json = JsonConvert.SerializeObject(message);
            //var body = Encoding.UTF8.GetBytes(json);
            ////put the data on to the product queue
            //channel.BasicPublish(exchange: "", routingKey: "product", body: body);

            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: "topic_logs",
                                        type: "topic");
                var routingKey = (message.Id.Length > 0) ? message : "anonymous.info";
                var bodyType = Encoding.UTF8.GetBytes(message.Id);
                var bodyId = Encoding.UTF8.GetBytes(message.Type);
                channel.BasicPublish(exchange: "topic_logs",
                                     routingKey: routingKey,
                                     basicProperties: null,
                                     body: bodyType +" "+ bodyId);
                Console.WriteLine(" [x] Sent '{0}':'{1}'", routingKey, message);
            }
        }
    }
}
