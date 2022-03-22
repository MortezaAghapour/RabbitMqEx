using RabbitMqEx.Domain.Markers;

namespace RabbitMqEx.Domain.Dtos.RabbitMq;

public class ExchangeDeclareConfigurationDto: IRabbitMqSetting
{
    /// <summary>
    /// اگر سرویس ربیت استاپ شود، صف از بین نخواهد رفت
    /// </summary>
    public bool Durable { get; set; } = false;

    /// <summary>
    /// وقتی کارش تموم شد، صف به صورت اتوماتیک حذف شود
    /// </summary>
    public bool AutoDelete { get; set; } = false;
    public IDictionary<string, object>? Arguments { get; set; } = null;

}