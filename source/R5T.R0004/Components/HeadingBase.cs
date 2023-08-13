using System;

using Microsoft.AspNetCore.Components;

using R5T.T0154;


namespace R5T.R0004
{
    [RazorComponentMarker]
    public class HeadingBase : ComponentBase
    {
        /// <summary>
        /// Goes from 1 (h1) to 6 (h6).
        /// </summary>
        [Parameter]
        public int Level { get; set; }

        [Parameter]
        public string TableOfContentsText { get; set; }

        [Parameter]
        public string HeadingText { get; set; }

        [Parameter]
        public string Value { set
            {
                this.TableOfContentsText = value;
                this.HeadingText = value;
            }
        }

        public string Identity
        {
            get
            {
                var identity = Instances.HtmlIdentityOperator.GetHeadingIdentity(this.HeadingText);
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
