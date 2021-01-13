namespace WebApiTest.Models
{
    public class ResponseStatus
    {
        public int status { get; set; }
        public string msg { get; set; }
        public object data { get; set; }

        public ResponseStatus(int status, string msg, object data)
        {
            this.status = status;
            this.msg = msg;
            this.data = data;
        }
    }
}