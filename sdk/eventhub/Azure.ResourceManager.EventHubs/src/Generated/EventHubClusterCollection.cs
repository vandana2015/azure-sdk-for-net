// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.EventHubs
{
    /// <summary>
    /// A class representing a collection of <see cref="EventHubClusterResource" /> and their operations.
    /// Each <see cref="EventHubClusterResource" /> in the collection will belong to the same instance of <see cref="ResourceGroupResource" />.
    /// To get an <see cref="EventHubClusterCollection" /> instance call the GetEventHubClusters method from an instance of <see cref="ResourceGroupResource" />.
    /// </summary>
    public partial class EventHubClusterCollection : ArmCollection, IEnumerable<EventHubClusterResource>, IAsyncEnumerable<EventHubClusterResource>
    {
        private readonly ClientDiagnostics _eventHubClusterClientDiagnostics;
        private readonly EventHubClustersRestOperations _eventHubClusterRestClient;
        private readonly ClientDiagnostics _eventHubClusterClustersClientDiagnostics;
        private readonly ClustersRestOperations _eventHubClusterClustersRestClient;

        /// <summary> Initializes a new instance of the <see cref="EventHubClusterCollection"/> class for mocking. </summary>
        protected EventHubClusterCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="EventHubClusterCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal EventHubClusterCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _eventHubClusterClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.EventHubs", EventHubClusterResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(EventHubClusterResource.ResourceType, out string eventHubClusterApiVersion);
            _eventHubClusterRestClient = new EventHubClustersRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, eventHubClusterApiVersion);
            _eventHubClusterClustersClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.EventHubs", EventHubClusterResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(EventHubClusterResource.ResourceType, out string eventHubClusterClustersApiVersion);
            _eventHubClusterClustersRestClient = new ClustersRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, eventHubClusterClustersApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceGroupResource.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceGroupResource.ResourceType), nameof(id));
        }

        /// <summary>
        /// Creates or updates an instance of an Event Hubs Cluster.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/clusters/{clusterName}
        /// Operation Id: EventHubClusters_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="clusterName"> The name of the Event Hubs Cluster. </param>
        /// <param name="data"> Parameters for creating a eventhub cluster resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="clusterName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="clusterName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<EventHubClusterResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string clusterName, EventHubClusterData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(clusterName, nameof(clusterName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _eventHubClusterClientDiagnostics.CreateScope("EventHubClusterCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _eventHubClusterRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, clusterName, data, cancellationToken).ConfigureAwait(false);
                var operation = new EventHubsArmOperation<EventHubClusterResource>(new EventHubClusterOperationSource(Client), _eventHubClusterClientDiagnostics, Pipeline, _eventHubClusterRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, clusterName, data).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Creates or updates an instance of an Event Hubs Cluster.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/clusters/{clusterName}
        /// Operation Id: EventHubClusters_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="clusterName"> The name of the Event Hubs Cluster. </param>
        /// <param name="data"> Parameters for creating a eventhub cluster resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="clusterName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="clusterName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<EventHubClusterResource> CreateOrUpdate(WaitUntil waitUntil, string clusterName, EventHubClusterData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(clusterName, nameof(clusterName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _eventHubClusterClientDiagnostics.CreateScope("EventHubClusterCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _eventHubClusterRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, clusterName, data, cancellationToken);
                var operation = new EventHubsArmOperation<EventHubClusterResource>(new EventHubClusterOperationSource(Client), _eventHubClusterClientDiagnostics, Pipeline, _eventHubClusterRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, clusterName, data).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletion(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets the resource description of the specified Event Hubs Cluster.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/clusters/{clusterName}
        /// Operation Id: Clusters_Get
        /// </summary>
        /// <param name="clusterName"> The name of the Event Hubs Cluster. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="clusterName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="clusterName"/> is null. </exception>
        public virtual async Task<Response<EventHubClusterResource>> GetAsync(string clusterName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(clusterName, nameof(clusterName));

            using var scope = _eventHubClusterClustersClientDiagnostics.CreateScope("EventHubClusterCollection.Get");
            scope.Start();
            try
            {
                var response = await _eventHubClusterClustersRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, clusterName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new EventHubClusterResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets the resource description of the specified Event Hubs Cluster.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/clusters/{clusterName}
        /// Operation Id: Clusters_Get
        /// </summary>
        /// <param name="clusterName"> The name of the Event Hubs Cluster. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="clusterName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="clusterName"/> is null. </exception>
        public virtual Response<EventHubClusterResource> Get(string clusterName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(clusterName, nameof(clusterName));

            using var scope = _eventHubClusterClustersClientDiagnostics.CreateScope("EventHubClusterCollection.Get");
            scope.Start();
            try
            {
                var response = _eventHubClusterClustersRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, clusterName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new EventHubClusterResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Lists the available Event Hubs Clusters within an ARM resource group
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/clusters
        /// Operation Id: Clusters_ListByResourceGroup
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="EventHubClusterResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<EventHubClusterResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<EventHubClusterResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _eventHubClusterClustersClientDiagnostics.CreateScope("EventHubClusterCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _eventHubClusterClustersRestClient.ListByResourceGroupAsync(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new EventHubClusterResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<EventHubClusterResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _eventHubClusterClustersClientDiagnostics.CreateScope("EventHubClusterCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _eventHubClusterClustersRestClient.ListByResourceGroupNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new EventHubClusterResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Lists the available Event Hubs Clusters within an ARM resource group
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/clusters
        /// Operation Id: Clusters_ListByResourceGroup
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="EventHubClusterResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<EventHubClusterResource> GetAll(CancellationToken cancellationToken = default)
        {
            Page<EventHubClusterResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _eventHubClusterClustersClientDiagnostics.CreateScope("EventHubClusterCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _eventHubClusterClustersRestClient.ListByResourceGroup(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new EventHubClusterResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<EventHubClusterResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _eventHubClusterClustersClientDiagnostics.CreateScope("EventHubClusterCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _eventHubClusterClustersRestClient.ListByResourceGroupNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new EventHubClusterResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/clusters/{clusterName}
        /// Operation Id: Clusters_Get
        /// </summary>
        /// <param name="clusterName"> The name of the Event Hubs Cluster. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="clusterName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="clusterName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string clusterName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(clusterName, nameof(clusterName));

            using var scope = _eventHubClusterClustersClientDiagnostics.CreateScope("EventHubClusterCollection.Exists");
            scope.Start();
            try
            {
                var response = await _eventHubClusterClustersRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, clusterName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/clusters/{clusterName}
        /// Operation Id: Clusters_Get
        /// </summary>
        /// <param name="clusterName"> The name of the Event Hubs Cluster. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="clusterName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="clusterName"/> is null. </exception>
        public virtual Response<bool> Exists(string clusterName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(clusterName, nameof(clusterName));

            using var scope = _eventHubClusterClustersClientDiagnostics.CreateScope("EventHubClusterCollection.Exists");
            scope.Start();
            try
            {
                var response = _eventHubClusterClustersRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, clusterName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<EventHubClusterResource> IEnumerable<EventHubClusterResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<EventHubClusterResource> IAsyncEnumerable<EventHubClusterResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
