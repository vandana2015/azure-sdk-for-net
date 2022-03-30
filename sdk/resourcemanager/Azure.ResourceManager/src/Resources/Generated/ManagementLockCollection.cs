// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;

namespace Azure.ResourceManager.Resources
{
    /// <summary>
    /// A class representing a collection of <see cref="ManagementLockResource" /> and their operations.
    /// Each <see cref="ManagementLockResource" /> in the collection will belong to the same instance of <see cref="ArmResource" />.
    /// To get a <see cref="ManagementLockCollection" /> instance call the GetManagementLocks method from an instance of <see cref="ArmResource" />.
    /// </summary>
    public partial class ManagementLockCollection : ArmCollection, IEnumerable<ManagementLockResource>, IAsyncEnumerable<ManagementLockResource>
    {
        private readonly ClientDiagnostics _managementLockClientDiagnostics;
        private readonly ManagementLocksRestOperations _managementLockRestClient;

        /// <summary> Initializes a new instance of the <see cref="ManagementLockCollection"/> class for mocking. </summary>
        protected ManagementLockCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="ManagementLockCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal ManagementLockCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _managementLockClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Resources", ManagementLockResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(ManagementLockResource.ResourceType, out string managementLockApiVersion);
            _managementLockRestClient = new ManagementLocksRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, managementLockApiVersion);
        }

        /// <summary>
        /// Create or update a management lock by scope.
        /// Request Path: /{scope}/providers/Microsoft.Authorization/locks/{lockName}
        /// Operation Id: ManagementLocks_CreateOrUpdateByScope
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="lockName"> The name of lock. </param>
        /// <param name="data"> Create or update management lock parameters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="lockName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="lockName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<ManagementLockResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string lockName, ManagementLockData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(lockName, nameof(lockName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _managementLockClientDiagnostics.CreateScope("ManagementLockCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _managementLockRestClient.CreateOrUpdateByScopeAsync(Id, lockName, data, cancellationToken).ConfigureAwait(false);
                var operation = new ResourcesArmOperation<ManagementLockResource>(Response.FromValue(new ManagementLockResource(Client, response), response.GetRawResponse()));
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
        /// Create or update a management lock by scope.
        /// Request Path: /{scope}/providers/Microsoft.Authorization/locks/{lockName}
        /// Operation Id: ManagementLocks_CreateOrUpdateByScope
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="lockName"> The name of lock. </param>
        /// <param name="data"> Create or update management lock parameters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="lockName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="lockName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<ManagementLockResource> CreateOrUpdate(WaitUntil waitUntil, string lockName, ManagementLockData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(lockName, nameof(lockName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _managementLockClientDiagnostics.CreateScope("ManagementLockCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _managementLockRestClient.CreateOrUpdateByScope(Id, lockName, data, cancellationToken);
                var operation = new ResourcesArmOperation<ManagementLockResource>(Response.FromValue(new ManagementLockResource(Client, response), response.GetRawResponse()));
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
        /// Get a management lock by scope.
        /// Request Path: /{scope}/providers/Microsoft.Authorization/locks/{lockName}
        /// Operation Id: ManagementLocks_GetByScope
        /// </summary>
        /// <param name="lockName"> The name of lock. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="lockName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="lockName"/> is null. </exception>
        public virtual async Task<Response<ManagementLockResource>> GetAsync(string lockName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(lockName, nameof(lockName));

            using var scope = _managementLockClientDiagnostics.CreateScope("ManagementLockCollection.Get");
            scope.Start();
            try
            {
                var response = await _managementLockRestClient.GetByScopeAsync(Id, lockName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ManagementLockResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get a management lock by scope.
        /// Request Path: /{scope}/providers/Microsoft.Authorization/locks/{lockName}
        /// Operation Id: ManagementLocks_GetByScope
        /// </summary>
        /// <param name="lockName"> The name of lock. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="lockName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="lockName"/> is null. </exception>
        public virtual Response<ManagementLockResource> Get(string lockName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(lockName, nameof(lockName));

            using var scope = _managementLockClientDiagnostics.CreateScope("ManagementLockCollection.Get");
            scope.Start();
            try
            {
                var response = _managementLockRestClient.GetByScope(Id, lockName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ManagementLockResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets all the management locks for a scope.
        /// Request Path: /{scope}/providers/Microsoft.Authorization/locks
        /// Operation Id: ManagementLocks_ListByScope
        /// </summary>
        /// <param name="filter"> The filter to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ManagementLockResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ManagementLockResource> GetAllAsync(string filter = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<ManagementLockResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _managementLockClientDiagnostics.CreateScope("ManagementLockCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _managementLockRestClient.ListByScopeAsync(Id, filter, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ManagementLockResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<ManagementLockResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _managementLockClientDiagnostics.CreateScope("ManagementLockCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _managementLockRestClient.ListByScopeNextPageAsync(nextLink, Id, filter, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ManagementLockResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Gets all the management locks for a scope.
        /// Request Path: /{scope}/providers/Microsoft.Authorization/locks
        /// Operation Id: ManagementLocks_ListByScope
        /// </summary>
        /// <param name="filter"> The filter to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ManagementLockResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ManagementLockResource> GetAll(string filter = null, CancellationToken cancellationToken = default)
        {
            Page<ManagementLockResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _managementLockClientDiagnostics.CreateScope("ManagementLockCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _managementLockRestClient.ListByScope(Id, filter, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ManagementLockResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<ManagementLockResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _managementLockClientDiagnostics.CreateScope("ManagementLockCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _managementLockRestClient.ListByScopeNextPage(nextLink, Id, filter, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ManagementLockResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Request Path: /{scope}/providers/Microsoft.Authorization/locks/{lockName}
        /// Operation Id: ManagementLocks_GetByScope
        /// </summary>
        /// <param name="lockName"> The name of lock. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="lockName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="lockName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string lockName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(lockName, nameof(lockName));

            using var scope = _managementLockClientDiagnostics.CreateScope("ManagementLockCollection.Exists");
            scope.Start();
            try
            {
                var response = await _managementLockRestClient.GetByScopeAsync(Id, lockName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /{scope}/providers/Microsoft.Authorization/locks/{lockName}
        /// Operation Id: ManagementLocks_GetByScope
        /// </summary>
        /// <param name="lockName"> The name of lock. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="lockName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="lockName"/> is null. </exception>
        public virtual Response<bool> Exists(string lockName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(lockName, nameof(lockName));

            using var scope = _managementLockClientDiagnostics.CreateScope("ManagementLockCollection.Exists");
            scope.Start();
            try
            {
                var response = _managementLockRestClient.GetByScope(Id, lockName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<ManagementLockResource> IEnumerable<ManagementLockResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<ManagementLockResource> IAsyncEnumerable<ManagementLockResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
