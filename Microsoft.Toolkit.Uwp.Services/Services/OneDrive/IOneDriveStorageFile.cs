﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.Networking.BackgroundTransfer;
using Windows.Storage;
using Windows.Storage.Streams;

namespace Microsoft.Toolkit.Uwp.Services.OneDrive
{
    public interface IOneDriveStorageFile : IOneDriveStorageItem
    {
        /// <summary>
        /// Opens a random-access stream over the specified file.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>When this method completes, it returns an IRandomAccessStream that contains the
        ///     requested random-access stream.</returns>
        Task<IRandomAccessStream> OpenAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Creates a background download for the current file
        /// </summary>
        /// <param name="destinationFile">A <see cref="StorageFile"/> to which content will be downloaded</param>
        /// <param name="completionGroup">The <see cref="BackgroundTransferCompletionGroup"/> to which should <see cref="BackgroundDownloader"/> reffer to</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request</param>
        /// <returns>The created <see cref="DownloadOperation"/></returns>
        Task<DownloadOperation> CreateBackgroundDownloadAsync(StorageFile destinationFile, BackgroundTransferCompletionGroup completionGroup = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Renames the current file.
        /// </summary>
        /// <param name="desiredName">The desired, new name for the current folder.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>When this method completes successfully, it returns an OneDriveStorageFile that represents the specified folder.</returns>
        Task<IOneDriveStorageFile> RenameAsync(string desiredName, CancellationToken cancellationToken = default(CancellationToken));
    }
}