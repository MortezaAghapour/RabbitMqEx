using RabbitMQ.Client;
using RabbitMqEx.Domain.Dtos.RabbitMq;

namespace RabbitMqEx.Service.Common;

public class BaseRabbitMq : IBaseRabbitMq
{
    #region Fields

    private readonly RabbitMqConnectionStringDto _configuration;
    #endregion
    #region Constructors
    public BaseRabbitMq(RabbitMqConnectionStringDto configuration)
    {
        _configuration = configuration;
    }

    #endregion
    #region Methods
    public ConnectionFactory CreateConnectionFactory()
    {
        var connectionFactor = new ConnectionFactory();
        var uri = new Uri(
            $"{_configuration.UserName}:{_configuration.Password}@{_configuration.Server}:{_configuration.Port}");
        connectionFactor.Uri = uri;
        return  connectionFactor;
    }

    public IConnection CreateConnection()
    {
        var connectionFactory = CreateConnectionFactory();
        var connection= connectionFactory.CreateConnection();
        return connection;
    }

    public (IModel Channel, IConnection Connection) CreateChannel()
    {
        var connection = CreateConnection();
        var channel = connection.CreateModel();
        return (channel,connection);
    }

    #endregion

}