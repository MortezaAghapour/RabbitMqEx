using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMqEx.Domain.Markers;

namespace RabbitMqEx.Domain.Dtos.RabbitMq
{
    public class BasicConsumeConfigurationDto : IRabbitMqSetting
    {
        
        public bool AutoAck { get; set; } = true;
        public bool NoLocal { get; set; } = false;
        public string ConsumerTag { get; set; }=string.Empty;
    }
}
