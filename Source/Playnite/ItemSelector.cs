﻿using System;
using System.Collections.Generic;
using Playnite.ViewModels;
using Playnite.Windows;

namespace Playnite
{
    public static class ItemSelector
    {
        public static bool SelectSingle<TItem>(string header, string message, List<SelectableNamedObject<TItem>> items, out TItem selected)
        {
            var result = new SingleItemSelectionViewModel<TItem>(
                new SingleItemSelectionWindowFactory(),
                header,
                message).
                SelectItem(items, out TItem selectedItem);
            selected = selectedItem;
            return result;
        }

        public static bool SelectMultiple<TItem>(string header, string message, List<SelectableNamedObject<TItem>> items, out List<TItem> selected)
        {
            var result = new MultiItemSelectionViewModel<TItem>(
                new MultiItemSelectionWindowFactory(),
                header,
                message).
                SelectItem(items, out List<TItem> selectedItems);
            selected = selectedItems;
            return result;
        }
    }
}
