using System.Security.Cryptography.X509Certificates;

namespace GetIdDoneAPI.Models
{
    public class Task
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public DateTime Created { get; set; }

        public DateTime Edited { get; set; }
    }
}
