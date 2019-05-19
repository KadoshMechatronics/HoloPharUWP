using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using HoloPharUWP.Activation;
using HoloPharUWP.BackgroundTasks;
using HoloPharUWP.Helpers;

using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.Background;

namespace HoloPharUWP.Services
{
    internal class BackgroundTaskService : ActivationHandler<BackgroundActivatedEventArgs>
    {
        public static IEnumerable<BackgroundTask> BackgroundTasks => backgroundTasks.Value;

        private static readonly Lazy<IEnumerable<BackgroundTask>> backgroundTasks = 
            new Lazy<IEnumerable<BackgroundTask>>(() => CreateInstances());

        public void RegisterBackgroundTasks()
        {
            foreach (var task in BackgroundTasks)
            {
                task.Register();
            }
        }

        public static BackgroundTaskRegistration GetBackgroundTasksRegistration<T>() where T : BackgroundTask
        {
            if (!BackgroundTaskRegistration.AllTasks.Any(t => t.Value.Name == typeof(T).Name))
            {
                // This condition should not be met, if so it means the background task was not registered correctly.
                // Please check CreateInstances to see if the background task was properly added to the BackgroundTasks property.
                return null;
            }
            return (BackgroundTaskRegistration)BackgroundTaskRegistration.AllTasks.FirstOrDefault(t => t.Value.Name == typeof(T).Name).Value;
        }

        public void Start(IBackgroundTaskInstance taskInstance)
        {
            var task = BackgroundTasks.FirstOrDefault(b => b.Match(taskInstance?.Task?.Name));

            if (task == null)
            {
                // This condition should not be met, if so it means the background task to start was not found in the background tasks managed by this service. 
                // Please check CreateInstances to see if the background task was properly added to the BackgroundTasks property.
                return;
            }

            task.RunAsync(taskInstance).FireAndForget();
        }

        protected override async Task HandleInternalAsync(BackgroundActivatedEventArgs args)
        {
            Start(args.TaskInstance);

            await Task.CompletedTask;
        }

        private static IEnumerable<BackgroundTask> CreateInstances()
        {
            var backgroundTasks = new List<BackgroundTask>();

            backgroundTasks.Add(new BackgroundTaskDownload());
        
            return backgroundTasks;
        }
    }
}