﻿using System.Collections.Generic;

namespace VSTS.Net.Models.Response.WorkItems
{
    public class HierarchicalWorkItemsQueryResult : WorkItemsQueryResult
    {
        /// <summary>
        /// A link between two work items.
        /// </summary>
        public IEnumerable<WorkItemLink> WorkItemRelations { get; set; }
    }
}
