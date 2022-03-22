using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMqEx.Domain.Markers;

namespace RabbitMqEx.Domain.Dtos.RabbitMq
{
    public class BasicPublishConfigurationDto : IRabbitMqSetting
    {
        /// <summary>
        /// برای ذخیره پیام های روی دیسک و حذف نشدن آنها
        /// </summary>
        public bool Persistent { get; set; } = false;
        public bool Mandatory { get; set; } = false;
    }
}
