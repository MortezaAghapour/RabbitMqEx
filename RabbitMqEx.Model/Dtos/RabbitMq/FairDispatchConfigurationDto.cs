using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMqEx.Domain.Markers;

namespace RabbitMqEx.Domain.Dtos.RabbitMq
{
    public class FairDispatchConfigurationDto : IRabbitMqSetting
    {
        /// <summary>
        /// اگر فعال باشد قابلیت Fair dispatch فعال میشود و قابلیت Round-robin غیر فعال خواهد شد
        /// </summary>
        public bool FairDispatchEnable { get; set; } = false;
        public bool Global { get; set; } = false;

        public ushort PrefetchCount { get; set; } = 1;
        public uint PrefetchSize{ get; set; } = 0;
    }
}
