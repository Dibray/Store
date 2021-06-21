namespace Store.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool GetShowRequestId()
        {
            return !string.IsNullOrEmpty(RequestId);
        }
    }
}
