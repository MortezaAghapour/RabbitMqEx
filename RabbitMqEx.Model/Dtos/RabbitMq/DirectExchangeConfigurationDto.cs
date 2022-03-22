using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMqEx.Domain.Markers;

namespace RabbitMqEx.Domain.Dtos.RabbitMq
{
    public class DirectExchangeConfigurationDto : IRabbitMqSetting
    {
        /// <summary>
        /// نام صف
        /// </summary>
        public string QueueName { get; set; }
    }
}
