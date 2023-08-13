using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Components;

using R5T.D0119;
using R5T.T0154;


namespace R5T.R0004.Internal
{
    [RazorComponentMarker]
    public class TableOfContentsContextEnd : IComponent
    {
        [Inject]
        public NotificationService NotificationService { get; set; }

        [Parameter]
        public string NotificationChannelName { get; set; }


        public void Attach(RenderHandle renderHandle)
        {
            // Do nothing.
        }

        public Task SetParametersAsync(ParameterView parameters)
        {
            parameters.SetParameterProperties(this);

            var channel = this.NotificationService.ChannelsByName[this.NotificationChannelName];

            channel.Notify();

            return Task.CompletedTask;
        }
    }
}
