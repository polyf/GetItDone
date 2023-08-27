using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace GetIdDoneAPI.Models
{
    public class TaskListViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Task> _tasks;

        public ObservableCollection<Task> Tasks
        {
            get { return _tasks; }
            set
            {
                _tasks = value;
                OnPropertyChanged(nameof(Tasks));
            }
        }

        public async Task<ObservableCollection<Task>> LoadTasksFromApiAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                string apiUrl = "https://localhost:7177/api/Tasks";
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    ObservableCollection<Task> tasks = JsonConvert.DeserializeObject<ObservableCollection<Task>>(json);
                    return tasks;
                }

                return null;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
