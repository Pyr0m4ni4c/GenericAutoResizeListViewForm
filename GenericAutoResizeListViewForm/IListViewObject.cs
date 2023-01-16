using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GenericAutoResizeListViewForm
{
    public interface IListViewControls<T>
    {
        void ResizeListView(out int extendPanelWidthBy);
        void AddItem(T o);
        void RemoveItem(T o);
        void AutoResizeParent(Form form, Panel containingPanel);
        void SortColumnAndChildren(string primaryColumnKey);
        T[] SelectedValues { get; }
    }

    public interface IObjectColumnHandling<T>
    {
        Func<T, string> GetDescription { get; }
        Func<T, object> GetValue { get; }
        Func<T, object> SortKey { get; }
    }

    public interface IListViewObjectContainer<T>
    { 
        List<string> ColumnDefinition { get; }
        List<T> Values { get; set; }
        Dictionary<string, IObjectColumnHandling<T>> ObjectColumnHandlings { get; }
    }

    public class DefaultListViewObjectContainer<T> : IListViewObjectContainer<T>
    {
        public List<string> ColumnDefinition { get; set; }
        public List<T> Values { get; set; }
        public Dictionary<string, IObjectColumnHandling<T>> ObjectColumnHandlings { get; set; }
    }
}
