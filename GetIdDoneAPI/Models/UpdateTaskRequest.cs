using System.Xml.Linq;

namespace GetIdDoneAPI.Models
{
    public class UpdateTaskRequest
    {
        public string Name { get; set; }
        public bool Status { get; set; }

        public DateTime Edited { get; set; }

        public UpdateTaskRequest(string name, bool status)
        {
            Name = name;
            Status = status;
        }
    }

    
}
