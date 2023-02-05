using System;
using System.Linq;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

using R5T.T0132;


namespace R5T.R0004
{
    using R5T.R0004.Internal;


    [FunctionalityMarker]
    public partial interface ITableOfContentsNodeOperations : IFunctionalityMarker
    {
        public void RenderTableOfContents(
            RenderHandle renderHandle,
            TableOfContentsNodeTree nodeTree)
        {
            // Need to invoke update back in the render synchronization context.
            renderHandle.Dispatcher.InvokeAsync(
                () => renderHandle.Render(
                    builder => this.RenderTableOfContentsRenderFragment(
                        builder,
                        nodeTree)));
        }

        private void RenderTableOfContentsRenderFragment(
            RenderTreeBuilder builder,
            TableOfContentsNodeTree nodeTree)
        {
            var renderFragments = nodeTree.Nodes
                .Select(node => this.RenderTableOfContentsRenderFragment(node))
                .Now();

            builder.OpenComponent<TableOfContentsRoot>(0);
            builder.AddAttribute(1, nameof(TableOfContentsRoot.ChildRenderFragments), renderFragments);
            builder.CloseComponent();
        }

        private RenderFragment RenderTableOfContentsRenderFragment(
            TableOfContentsNode node)
        {
            var isLeaf = node.ChildNodes.None();
            if (isLeaf)
            {
                return builder =>
                {
                    builder.OpenComponent<TableOfContentsItemLeaf>(0);
                    builder.AddAttribute(1, nameof(TableOfContentsItemLeaf.Node), node);
                    builder.CloseComponent();
                };
            }
            else
            {
                return builder =>
                {
                    var childRenderFragments = node.ChildNodes
                        .Select(childNode => this.RenderTableOfContentsRenderFragment(
                            childNode))
                        .ToArray();

                    builder.OpenComponent<TableOfContentsItemBranch>(0);
                    builder.AddAttribute(1, nameof(TableOfContentsItemBranch.Node), node);
                    builder.AddAttribute(2, nameof(TableOfContentsItemBranch.ChildRenderFragments), childRenderFragments);
                    builder.CloseComponent();
                };
            }
        }
    }
}
