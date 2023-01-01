using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;
using MudBlazor;
using Shared.Models;
using UTask.Client.Services.Contact;
using Task = Shared.Models.Task;
namespace UTask.Client.Pages
{
    public partial class Tasks
    {
        public IEnumerable<Task> AllTask { get; set; }

        [Inject]
        public ITaskService? _service { get; set; }

        [Inject]
        public IDialogService? DialogService { get; set; }  

        protected async override System.Threading.Tasks.Task OnInitializedAsync()
        {
            AllTask = await _service.GetAllTasksAsync();
        }

        public void AddTask()
        {
            DialogService.Show<AddTask>("AddTask");
        }
    }
}
