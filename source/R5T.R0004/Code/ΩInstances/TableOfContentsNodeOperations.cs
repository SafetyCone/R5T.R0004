using System;


namespace R5T.R0004
{
    public class TableOfContentsNodeOperations : ITableOfContentsNodeOperations
    {
        #region Infrastructure

        public static ITableOfContentsNodeOperations Instance { get; } = new TableOfContentsNodeOperations();


        private TableOfContentsNodeOperations()
        {
        }

        #endregion
    }
}
