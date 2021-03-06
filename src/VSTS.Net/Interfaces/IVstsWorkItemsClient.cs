﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VSTS.Net.Models.Request;
using VSTS.Net.Models.WorkItems;

namespace VSTS.Net.Interfaces
{
    public interface IVstsWorkItemsClient
    {
        /// <summary>
        /// Returns a single work item.
        /// </summary>
        /// <param name="workItemId">The work item id</param>
        /// <param name="asOf">AsOf UTC date time string</param>
        /// <param name="fields">List of requested fields</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Returns a single work item.</returns>
        Task<WorkItem> GetWorkItemAsync(int workItemId, DateTime? asOf = null, string[] fields = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Returns a list of work items.
        /// </summary>
        /// <param name="ids">The list of requested work item ids</param>
        /// <param name="asOf">AsOf UTC date time string. Defaul to UtcNow if not specified</param>
        /// <param name="fields">List of requested fields</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Returns a list of work items.</returns>
        Task<IEnumerable<WorkItem>> GetWorkItemsAsync(int[] ids, DateTime? asOf = null, string[] fields = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Creates a single work item.
        /// </summary>
        /// <param name="project">Project ID or project name</param>
        /// <param name="type">The work item type of the work item to create</param>
        /// <param name="item">Work item to create</param>
        /// <returns></returns>
        Task<WorkItem> CreateWorkItemAsync(string project, string type, WorkItem item, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Deletes the specified work item and sends it to the Recycle Bin, so that it can be restored back, if required. Optionally, if the destroy parameter has been set to true, it destroys the work item permanently.
        /// </summary>
        /// <param name="id">ID of the work item to be deleted</param>
        /// <param name="destroy">If set to true, the work item is deleted permanently</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<bool> DeleteWorkItemAsync(int id, bool destroy = false, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Updates a single work item.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<WorkItem> UpdateWorkItemAsync(UpdateWorkitemRequest request, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Executes a work item query
        /// </summary>
        /// <param name="query">Work item query to execute</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Returns <see cref="WorkItemsQueryResult"/></returns>
        Task<WorkItemsQueryResult> ExecuteQueryAsync(WorkItemsQuery query, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Executes a work item query
        /// </summary>
        /// <param name="query">Work item query to execute</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>List of work items</returns>
        Task<IEnumerable<WorkItem>> GetWorkItemsAsync(WorkItemsQuery query, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Retrieves the list of updates for workitem
        /// </summary>
        /// <param name="workitemId">ID of the workitem</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>List of work item updates</returns>
        Task<IEnumerable<WorkItemUpdate>> GetWorkItemUpdatesAsync(int workitemId, CancellationToken cancellationToken = default(CancellationToken));
    }
}
