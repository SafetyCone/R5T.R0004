using System;

using Microsoft.AspNetCore.Components;


namespace R5T.R0004
{
    public class HeadingBase : ComponentBase
    {
        [Parameter]
        public string Value { get; set; }

        public string Identity
        {
            get
            {
                var identity = Instances.HtmlIdentityOperator.GetHeadingIdentity(this.Value);
                return identity;
            }
        }

        /// <summary>
        /// Default is true.
        /// </summary>
        [Parameter]
        public bool IncludeInTableOfContents { get; set; } = true;
    }
}
