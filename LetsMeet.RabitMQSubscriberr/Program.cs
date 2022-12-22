

using LetsMeet.Abstractions.Models;
using LetsMeet.RabitMQSubscriber;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

//Here we specify the Rabbit MQ Server. we use rabbitmq docker image and use it
/*http://localhost:15672/#/queues*/

ConnectionFactory factory = new ConnectionFactory();
factory.UserName = "guest";
factory.Password = "guest";
factory.VirtualHost = "/";
factory.HostName = "localhost";
factory.Port = AmqpTcpEndpoint.UseDefaultPort;

//Create the RabbitMQ connection using connection factory details as i mentioned above

var connection = factory.CreateConnection();


//Here we create channel with session and model
using
var channel = connection.CreateModel();
//declare the queue after mentioning name and a few property related to that
channel.t("product", exclusive: false);
//Set Event object which listen message from chanel which is sent by producer
var consumer = new EventingBasicConsumer(channel);
consumer.Received += async (model, eventArgs) => {
    var body = eventArgs.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);
    //Console.WriteLine($"Product message received: {message}");

    Notifications notif = new Notifications();
    await notif.AddNotifications(new Notification() {NotificationType = message });
};
//read the message
channel.BasicConsume(queue: "product", autoAck: true, consumer: consumer);
Console.ReadKey();