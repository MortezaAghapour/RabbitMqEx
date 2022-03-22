using RabbitMqEx.Domain.Markers;

namespace RabbitMqEx.Domain.Dtos.RabbitMq
{
    public class RabbitMqConnectionStringDto:IAppSetting
    {
        public RabbitMqConnectionStringDto()
        {
            
        }
        public RabbitMqConnectionStringDto(string userName, string password, string server,int port)
        {
            UserName = userName;
            Password = password;
            Server = server;
            Port= port;
        }

        public string UserName { get; set; }
        public string Password { get; set; }
        public string Server { get; set; }
        public int Port { get; set; }

    }
}
