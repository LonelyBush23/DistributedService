namespace NotificationGateway.Core.Application.DTOs
{
    public class NotificationDto
    {
        public string Type { get; set; }   // Тип уведомления (email, sms, push)
        public string Recipient { get; set; }   // Получатель уведомления
        public string Message { get; set; }   // Сообщение
        public Dictionary<string, string> Metadata { get; set; }  // Дополнительные данные, например, приоритет
    }
}
