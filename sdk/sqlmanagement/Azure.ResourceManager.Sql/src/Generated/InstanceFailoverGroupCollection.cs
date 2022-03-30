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

namespace Azure.ResourceManager.Sql
{
    /// <summary>
    /// A class representing a collection of <see cref="InstanceFailoverGroupResource" /> and their operations.
    /// Each <see cref="InstanceFailoverGroupResource" /> in the collection will belong to the same instance of <see cref="ResourceGroupResource" />.
    /// To get an <see cref="InstanceFailoverGroupCollection" /> instance call the GetInstanceFailoverGroups method from an instance of <see cref="ResourceGroupResource" />.
    /// </summary>
    public partial class InstanceFailoverGroupCollection : ArmCollection, IEnumerable<InstanceFailoverGroupResource>, IAsyncEnumerable<InstanceFailoverGroupResource>
    {
        private readonly ClientDiagnostics _instanceFailoverGroupClientDiagnostics;
        private readonly InstanceFailoverGroupsRestOperations _instanceFailoverGroupRestClient;
        private readonly string _locationName;

        /// <summary> Initializes a new instance of the <see cref="InstanceFailoverGroupCollection"/> class for mocking. </summary>
        protected InstanceFailoverGroupCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="InstanceFailoverGroupCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        /// <param name="locationName"> The name of the region where the resource is located. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="locationName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="locationName"/> is an empty string, and was expected to be non-empty. </exception>
        internal InstanceFailoverGroupCollection(ArmClient client, ResourceIdentifier id, string locationName) : base(client, id)
        {
            _locationName = locationName;
            _instanceFailoverGroupClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Sql", InstanceFailoverGroupResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(InstanceFailoverGroupResource.ResourceType, out string instanceFailoverGroupApiVersion);
            _instanceFailoverGroupRestClient = new InstanceFailoverGroupsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, instanceFailoverGroupApiVersion);
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
        /// Creates or updates a failover group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/locations/{locationName}/instanceFailoverGroups/{failoverGroupName}
        /// Operation Id: InstanceFailoverGroups_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="failoverGroupName"> The name of the failover group. </param>
        /// <param name="data"> The failover group parameters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="failoverGroupName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="failoverGroupName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<InstanceFailoverGroupResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string failoverGroupName, InstanceFailoverGroupData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(failoverGroupName, nameof(failoverGroupName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _instanceFailoverGroupClientDiagnostics.CreateScope("InstanceFailoverGroupCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _instanceFailoverGroupRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, _locationName, failoverGroupName, data, cancellationToken).ConfigureAwait(false);
                var operation = new SqlArmOperation<InstanceFailoverGroupResource>(new InstanceFailoverGroupOperationSource(Client), _instanceFailoverGroupClientDiagnostics, Pipeline, _instanceFailoverGroupRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, _locationName, failoverGroupName, data).Request, response, OperationFinalStateVia.Location);
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
        /// Creates or updates a failover group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/locations/{locationName}/instanceFailoverGroups/{failoverGroupName}
        /// Operation Id: InstanceFailoverGroups_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="failoverGroupName"> The name of the failover group. </param>
        /// <param name="data"> The failover group parameters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="failoverGroupName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="failoverGroupName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<InstanceFailoverGroupResource> CreateOrUpdate(WaitUntil waitUntil, string failoverGroupName, InstanceFailoverGroupData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(failoverGroupName, nameof(failoverGroupName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _instanceFailoverGroupClientDiagnostics.CreateScope("InstanceFailoverGroupCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _instanceFailoverGroupRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, _locationName, failoverGroupName, data, cancellationToken);
                var operation = new SqlArmOperation<InstanceFailoverGroupResource>(new InstanceFailoverGroupOperationSource(Client), _instanceFailoverGroupClientDiagnostics, Pipeline, _instanceFailoverGroupRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, _locationName, failoverGroupName, data).Request, response, OperationFinalStateVia.Location);
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
        /// Gets a failover group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/locations/{locationName}/instanceFailoverGroups/{failoverGroupName}
        /// Operation Id: InstanceFailoverGroups_Get
        /// </summary>
        /// <param name="failoverGroupName"> The name of the failover group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="failoverGroupName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="failoverGroupName"/> is null. </exception>
        public virtual async Task<Response<InstanceFailoverGroupResource>> GetAsync(string failoverGroupName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(failoverGroupName, nameof(failoverGroupName));

            using var scope = _instanceFailoverGroupClientDiagnostics.CreateScope("InstanceFailoverGroupCollection.Get");
            scope.Start();
            try
            {
                var response = await _instanceFailoverGroupRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, _locationName, failoverGroupName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new InstanceFailoverGroupResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a failover group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/locations/{locationName}/instanceFailoverGroups/{failoverGroupName}
        /// Operation Id: InstanceFailoverGroups_Get
        /// </summary>
        /// <param name="failoverGroupName"> The name of the failover group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="failoverGroupName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="failoverGroupName"/> is null. </exception>
        public virtual Response<InstanceFailoverGroupResource> Get(string failoverGroupName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(failoverGroupName, nameof(failoverGroupName));

            using var scope = _instanceFailoverGroupClientDiagnostics.CreateScope("InstanceFailoverGroupCollection.Get");
            scope.Start();
            try
            {
                var response = _instanceFailoverGroupRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, _locationName, failoverGroupName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new InstanceFailoverGroupResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Lists the failover groups in a location.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/locations/{locationName}/instanceFailoverGroups
        /// Operation Id: InstanceFailoverGroups_ListByLocation
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="InstanceFailoverGroupResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<InstanceFailoverGroupResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<InstanceFailoverGroupResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _instanceFailoverGroupClientDiagnostics.CreateScope("InstanceFailoverGroupCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _instanceFailoverGroupRestClient.ListByLocationAsync(Id.SubscriptionId, Id.ResourceGroupName, _locationName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new InstanceFailoverGroupResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<InstanceFailoverGroupResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _instanceFailoverGroupClientDiagnostics.CreateScope("InstanceFailoverGroupCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _instanceFailoverGroupRestClient.ListByLocationNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, _locationName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new InstanceFailoverGroupResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Lists the failover groups in a location.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/locations/{locationName}/instanceFailoverGroups
        /// Operation Id: InstanceFailoverGroups_ListByLocation
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="InstanceFailoverGroupResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<InstanceFailoverGroupResource> GetAll(CancellationToken cancellationToken = default)
        {
            Page<InstanceFailoverGroupResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _instanceFailoverGroupClientDiagnostics.CreateScope("InstanceFailoverGroupCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _instanceFailoverGroupRestClient.ListByLocation(Id.SubscriptionId, Id.ResourceGroupName, _locationName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new InstanceFailoverGroupResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<InstanceFailoverGroupResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _instanceFailoverGroupClientDiagnostics.CreateScope("InstanceFailoverGroupCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _instanceFailoverGroupRestClient.ListByLocationNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, _locationName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new InstanceFailoverGroupResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/locations/{locationName}/instanceFailoverGroups/{failoverGroupName}
        /// Operation Id: InstanceFailoverGroups_Get
        /// </summary>
        /// <param name="failoverGroupName"> The name of the failover group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="failoverGroupName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="failoverGroupName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string failoverGroupName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(failoverGroupName, nameof(failoverGroupName));

            using var scope = _instanceFailoverGroupClientDiagnostics.CreateScope("InstanceFailoverGroupCollection.Exists");
            scope.Start();
            try
            {
                var response = await _instanceFailoverGroupRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, _locationName, failoverGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/locations/{locationName}/instanceFailoverGroups/{failoverGroupName}
        /// Operation Id: InstanceFailoverGroups_Get
        /// </summary>
        /// <param name="failoverGroupName"> The name of the failover group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="failoverGroupName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="failoverGroupName"/> is null. </exception>
        public virtual Response<bool> Exists(string failoverGroupName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(failoverGroupName, nameof(failoverGroupName));

            using var scope = _instanceFailoverGroupClientDiagnostics.CreateScope("InstanceFailoverGroupCollection.Exists");
            scope.Start();
            try
            {
                var response = _instanceFailoverGroupRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, _locationName, failoverGroupName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<InstanceFailoverGroupResource> IEnumerable<InstanceFailoverGroupResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<InstanceFailoverGroupResource> IAsyncEnumerable<InstanceFailoverGroupResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
