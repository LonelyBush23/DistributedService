namespace DistributedService.NotificationGateway.Core.Domain.Interfaces
{
    public interface IResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public int StatusCode { get; set; }

    }

}
