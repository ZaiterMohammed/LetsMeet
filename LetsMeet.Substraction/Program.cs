


////Here we specify the Rabbit MQ Server. we use rabbitmq docker image and use it
///*http://localhost:15672/#/queues*/

//using LetsMeet.Notifications;
//using LetsMeet.Substraction;
//using RabbitMQ.Client;
//using RabbitMQ.Client.Events;
//using System;
//using System.Configuration;
//using System.Text;

//string conString = Microsoft.Extensions.Configuration.ConfigurationExtensions.GetConnectionString(this.Configuration, "rabbitMq");
//ConnectionFactory factory = new ConnectionFactory();

////Create the RabbitMQ connection using connection factory details as i mentioned above
//var connection = factory.CreateConnection();


////Here we create channel with session and model

//var channel = connection.CreateModel();
////declare the queue after mentioning name and a few property related to that
//channel.QueueDeclare("product", exclusive: false);
////Set Event object which listen message from chanel which is sent by producer
//var consumer = new EventingBasicConsumer(channel);
//consumer.Received += async (model, eventArgs) =>
//{
//    var body = eventArgs.Body.ToArray();
//    var messageId = Encoding.UTF8.GetString(body);
//    //Console.WriteLine($"Product message received: {message}");

//    NotificationsStore notif = new NotificationsStore();
//    await notif.AddNotifications(new NotificationMessage() { Type = NotificationType.MunicipalityCreated ,Id = Guid.Parse(messageId)} );
//};
////read the message
//channel.BasicConsume(queue: "product", autoAck: true, consumer: consumer);


using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System;
using System.Text;
using LetsMeet.Notifications;
using LetsMeet.Store;

var factory = new ConnectionFactory() { HostName = "localhost" };
using (var connection = factory.CreateConnection())
using (var channel = connection.CreateModel())
{
    channel.ExchangeDeclare(exchange: "topic_logs", type: "topic");
    var queueName = channel.QueueDeclare().QueueName;

    if (args.Length < 1)
    {
        Console.Error.WriteLine("Usage: {0} [binding_key...]",
                                Environment.GetCommandLineArgs()[0]);
        Console.WriteLine(" Press [enter] to exit.");
        Console.ReadLine();
        Environment.ExitCode = 1;
        return;
    }

    foreach (var bindingKey in args)
    {
        channel.QueueBind(queue: queueName,
                          exchange: "topic_logs",
                          routingKey: bindingKey);
    }

    Console.WriteLine(" [*] Waiting for messages. To exit press CTRL+C");

    var consumer = new EventingBasicConsumer(channel);
    consumer.Received += async (model, ea) =>
    {
        var body = ea.Body.ToArray();
        var message = Encoding.UTF8.GetString(body);

        var listMessage = message.Split(" ");
        var messageType = listMessage[0];
        var messageId = Guid.Parse(listMessage[1]);

        var routingKey = ea.RoutingKey;

        NotificationStore notif = new NotificationStore();
        await notif.AddNotifications(Enum.Parse<NotificationType>(messageType), messageId);
    };
    channel.BasicConsume(queue: queueName,
                         autoAck: true,
                         consumer: consumer);

    Console.WriteLine(" Press [enter] to exit.");
    Console.ReadLine();
}
