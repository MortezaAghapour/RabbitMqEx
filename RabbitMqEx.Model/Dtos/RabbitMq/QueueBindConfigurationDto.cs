using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMqEx.Domain.Markers;

namespace RabbitMqEx.Domain.Dtos.RabbitMq
{
    public class QueueBindConfigurationDto:IRabbitMqSetting
    {
        public IDictionary<string, object>? Arguments { get; set; } = null;
    }
}
