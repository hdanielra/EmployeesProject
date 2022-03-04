namespace Employees.Entities.Responses
{
    public class DataResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public object? Data { get; set; }

        public DataResponse()
        {
            Status = "";
            Message = "";
        }
    }
}
    