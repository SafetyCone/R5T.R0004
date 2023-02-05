using System;
using System.Collections.Generic;


namespace R5T.R0004.Internal
{
    public class TableOfContentsNodeTree
    {
        private TableOfContentsNode PriorNode { get; set; }

        public List<TableOfContentsNode> Nodes { get; } = new List<TableOfContentsNode>();


        public void AddNode(TableOfContentsNode node)
        {
            var priorNode = this.PriorNode;

            this.PriorNode = node;

            if (priorNode is null)
            {
                this.Nodes.Add(node);

                return;
            }

            // Get the parent to which the child should be added.
            static TableOfContentsNode GetParentForChild(
                TableOfContentsNode priorNode,
                TableOfContentsNode node)
            {
                // If the node has a greater level than the prior node, add it as a child of the prior node.
                if (priorNode.Level < node.Level)
                {
                    return priorNode;
                }

                // If the node has a lower level than the prior node, move up the prior nodes parents until you find a higher level node (or null parent), then add as a child.
                if (priorNode.Level > node.Level)
                {
                    var parent = priorNode.Parent;
                    while ((parent?.Level ?? 0) >= node.Level)
                    {
                        parent = parent.Parent;
                    }

                    return parent;
                }

                // If the node has the same level as the prior node, add it as a child of the prior node's parent.
                return priorNode.Parent;
            }

            var parent = GetParentForChild(
                priorNode,
                node);

            // If the parent node is null, then the node is a new top-level node in the table of contents.
            if(parent is null)
            {
                this.Nodes.Add(node);
            }
            else
            {
                parent.AddChild(node);
            }
        }

        public void Reset()
        {
            this.PriorNode = null;
            this.Nodes.Clear();
        }
    }
}
