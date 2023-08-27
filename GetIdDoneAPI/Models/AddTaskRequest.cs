namespace GetIdDoneAPI.Models
{
    public class AddTaskRequest
    {
        public string Name { get; set; }
        public bool Status { get; set; }

        public AddTaskRequest(string name, bool status)
        {
            Name = name;
            Status = status;
        }
    }
}
