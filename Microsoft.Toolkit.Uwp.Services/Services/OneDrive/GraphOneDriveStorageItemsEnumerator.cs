﻿// ******************************************************************
// Copyright (c) Microsoft. All rights reserved.
// This code is licensed under the MIT License (MIT).
// THE CODE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
// INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
// IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM,
// DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,
// TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH
// THE CODE OR THE USE OR OTHER DEALINGS IN THE CODE.
// ******************************************************************

using System;
using System.Collections;
using System.Collections.Generic;

namespace Microsoft.Toolkit.Uwp.Services.OneDrive
{
    /// <summary>
    ///  Class OneDriveStorageItemsEnumerator
    /// </summary>
    public class GraphOneDriveStorageItemsEnumerator : IEnumerator<IOneDriveStorageItem>
    {
        private List<IOneDriveStorageItem> _items;
        private int position = -1;

        /// <summary>
        /// Initializes a new instance of the <see cref="GraphOneDriveStorageItemsEnumerator"/> class.
        /// <para>Permissions : Have full access to user files and files shared with user</para>
        /// </summary>
        /// <param name="items">Items's list to store in the collection</param>
        public GraphOneDriveStorageItemsEnumerator(List<IOneDriveStorageItem> items)
        {
            _items = items;
        }

        /// <summary>
        /// Gets the current OneDrive Item
        /// </summary>
        public IOneDriveStorageItem Current
        {
            get
            {
                return CurrentItem;
            }
        }

        /// <summary>
        /// Gets the current OneDrive Item
        /// </summary>
        object IEnumerator.Current
        {
            get
            {
                return CurrentItem;
            }
        }

        /// <summary>
        /// Gets the current OneDrive Item
        /// </summary>
        public IOneDriveStorageItem CurrentItem
        {
            get
            {
                try
                {
                    var currentItem = _items[position];
                    if (currentItem.IsFile() || currentItem.IsOneNote())
                    {
                        return new GraphOneDriveStorageFile(currentItem.Provider, currentItem.RequestBuilder, currentItem.OneDriveItem);
                    }

                    return new GraphOneDriveStorageFolder(currentItem.Provider, currentItem.RequestBuilder, currentItem.OneDriveItem);
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        /// <summary>
        /// Clear list of items
        /// </summary>
        public void Dispose()
        {
            _items.Clear();
        }

        /// <summary>
        /// Move to the nex position in the list
        /// </summary>
        /// <returns>Success of failure</returns>
        public bool MoveNext()
        {
            position++;
            return position < _items.Count;
        }

        /// <summary>
        /// Reset the item position in the list
        /// </summary>
        public void Reset()
        {
            position = -1;
        }
    }
}
