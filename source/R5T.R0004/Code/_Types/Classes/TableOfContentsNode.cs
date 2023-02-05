using System;
using System.Collections.Generic;


namespace R5T.R0004.Internal
{
    public class TableOfContentsNode
    {
        /// <summary>
        /// The "HowToSeeMetaTags" in &lt;a href="#HowToSeeMetaTags" &gt;...
        /// </summary>
        public string Identity { get; set; }
        
        /// <summary>
        /// The "How to see Meta tags" in &lt;a&gt;How to see meta tags&lt;/a&gt;
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Goes from 1 (h1) to 6 (h6).
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// Use the <see cref="AddChild(TableOfContentsNode)"/> method on a parent to automatically set the parent.
        /// </summary>
        public TableOfContentsNode Parent { get; private set; }

        public List<TableOfContentsNode> ChildNodes { get; } = new List<TableOfContentsNode>();


        public void AddChild(TableOfContentsNode node)
        {
            node.Parent = this;

            this.ChildNodes.Add(node);
        }
    }
}
