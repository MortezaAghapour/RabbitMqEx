
using RabbitMQ.Client;
namespace RabbitMqEx.Service.Common;

public interface IBaseRabbitMq
{
    ConnectionFactory CreateConnectionFactory();
    IConnection CreateConnection();
    (IModel Channel,IConnection Connection) CreateChannel();
}