using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GenericAutoResizeListViewForm
{
    public class DefaultDynamicListView<T> : ListView, IListViewControls<T>
    {
        #region private Felder
        #region Customization
        private readonly bool _visualStylesEnabled;
        private int _maxWidth;
        private int _maxHeight;
        private readonly int _shownItems;
        private readonly HorizontalAlignment _columnAlignment;
        private readonly int? _staticColumnWidth;
        #endregion

        private bool lastSortedAscending = false;
        private string lastSortedKey;
#if !DEBUG
        private IListViewObjectContainer<T> m_InnerList;
#else
        private IListViewObjectContainer<T> _items;
        private static bool _infoShown;
        public IListViewObjectContainer<T> m_InnerList
        {
            get => _items;
            private set => _items = value;
        }
#endif
        public T[] SelectedValues => SelectedIndices.Cast<int>().ToList().Select(i => m_InnerList.Values[i]).ToArray();

        #endregion
        
        #region c'tor
        public DefaultDynamicListView(IListViewObjectContainer<T> items,
            bool visualStylesEnabled = false,
            int maxWidth = -1,
            int maxHeight = -1,
            int shownItems = 10,
            HorizontalAlignment alignment = HorizontalAlignment.Center,
            int? staticColumnWidth = null,
            bool multiSelect = false)
        {
            _visualStylesEnabled = visualStylesEnabled;
            _maxWidth = maxWidth;
            _maxHeight = maxHeight;
            _shownItems = shownItems;
            _staticColumnWidth = staticColumnWidth;
            _columnAlignment = alignment;
            m_InnerList = items ?? throw new ArgumentNullException(nameof(items));

            /* Text-Align des ersten Headers ist immer links, die Eigenschaft wird ignoriert.
             Man könnte mit unermesslichen Aufwand die ListView manuell zeichnen,
             wobei selbst im Win32-Control Workarounds für fehlerhafte Eventketten eingesetzt werden und es weitere Bugs gibt. 
             https://stackoverflow.com/questions/9066408/default-implementation-for-listview-ownerdraw*/

            View = View.Details;
            FullRowSelect = true;
            MultiSelect = multiSelect;
            HideSelection = false;
            
            Dock = DockStyle.Fill;
            AutoSize = true;

            ColumnClick += OnColumnClick;

            InitList();
        }
        #endregion

        #region private Methoden
        #region private GUI-Methoden
        private void OnColumnClick(object sender, ColumnClickEventArgs e)
        {
            SortColumnAndChildren(GetColumnDefinitions()[e.Column]);
        }
        #endregion

        private void InitList()
        {
            base.Items.Clear();
            Columns.Clear();

            foreach (var columnDefinition in GetColumnDefinitions())
            {
                var columnHeader = new ColumnHeader()
                {
                    Text = columnDefinition,
                    TextAlign = _columnAlignment,
                };

                if (_staticColumnWidth != null)
                    columnHeader.Width = (int) _staticColumnWidth;

                Columns.Add(columnHeader);
            }
        }

        private List<string> GetColumnDefinitions()
        {
            return m_InnerList.ColumnDefinition is { Count: > 0 } ? m_InnerList.ColumnDefinition : throw new ArgumentNullException("Columndefinitions sind null oder leer");
        }

        private void RefreshValues()
        {
            Items.Clear();

            foreach (var value in m_InnerList.Values)
            {
                var lvi = new ListViewItem(m_InnerList.ObjectColumnHandlings[m_InnerList.ColumnDefinition[0]].GetDescription(value));
                for (var i = 1; i < m_InnerList.ColumnDefinition.Count; i++)
                {
                    lvi.SubItems.Add(m_InnerList.ObjectColumnHandlings[m_InnerList.ColumnDefinition[i]].GetDescription(value));
                }

                Items.Add(lvi);
            }
        }

        #region Resize
        private void ResizeListViewInternal(out int extendPanelWidthBy)
        {
            // Breite anpassen
            ResizeListColumns();
            
            // Höhe anpassen
            ResizeListViewHeight(out extendPanelWidthBy);
            
            // Breite erneut anpassen, weil Scrollbalken fehlen könnte und weil es irgendwie besser funktioniert
            ResizeListColumns();
        }

        private void ResizeListViewHeight(out int extendPanelWidthBy)
        {
            extendPanelWidthBy = 0;
            const int scrollbarWidth = 16;
            var fontPadding = _visualStylesEnabled ? 4 : 1;
            var itemsCount = Items.Count > _shownItems ? _shownItems : Items.Count;
            var fontHeight = TextRenderer.MeasureText("|", Font).Height + fontPadding;

            var headerHeight = _visualStylesEnabled ? 28 : 18;
            var sonderOffset = _visualStylesEnabled
                ? new[] { 4 }[0]
                : new[] { 3, 7, 4 }[Math.Min(3, Items.Count) % 3];
            _maxHeight = _maxHeight is <= 0 or int.MaxValue ? int.MaxValue : _maxHeight;
            var height = Math.Min(itemsCount * fontHeight + headerHeight + sonderOffset, _maxHeight);

            _maxWidth = _maxWidth is <= 0 or int.MaxValue ? int.MaxValue : _maxWidth;
            var width = 5 + Columns.Cast<ColumnHeader>().Sum(column => column.Width);
            if (Items.Count > _shownItems)
            {
                Scrollable = true;
                extendPanelWidthBy = scrollbarWidth;
            }
            else
            {
                Scrollable = false;
            }
            width = Math.Min(width, _maxWidth);

            Size = MinimumSize = new Size(width, height);
        }

        private void ResizeListColumns()
        {
            for (var i = 0; i < Columns.Count; i++)
            {
                var oldWidth = Columns[i].Width;
                var column = Columns[i];

                column.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                // Ohne (vertikalen) Scrollbalken vergrößert sich die // mit AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize) gemessene Breite jedes mal um 1
                var tmpWidth1 = column.Width;
                if (oldWidth + 1 == tmpWidth1)
                    tmpWidth1 = oldWidth;

                column.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                var width2 = column.Width;

                column.Width = Math.Max(tmpWidth1, width2);
            }
        }
        #endregion
        #endregion

        #region Implementation of IListViewControls
        public void Init()
        {
            RefreshValues();
        }

        public void ResizeListView(out int extendPanelWidthBy)
        {
            ResizeListViewInternal(out extendPanelWidthBy);
        }

        public void AddItem(T item)
        {
            m_InnerList.Values.Add(item);
            RefreshValues();
        }

        public void RemoveItem(T o)
        {
            m_InnerList.Values.Remove(o);
            RefreshValues();
        }

        public void AutoResizeParent(Form form, Panel containingPanel)
        {
            form.AutoSize = containingPanel.AutoSize = true;
            ResizeListView(out var extendPanelWidthBy);
            containingPanel.Size = containingPanel.MinimumSize = new Size(this.MinimumSize.Width + extendPanelWidthBy, this.MinimumSize.Height);
            form.Size = Size.Empty; // triggert AutoSize
        }

        public void SortColumnAndChildren(string primaryColumnKey)
        {
            m_InnerList.Values = m_InnerList.Values.OrderBy(m_InnerList.ObjectColumnHandlings[primaryColumnKey].SortKey).ToList();

            if (primaryColumnKey != lastSortedKey)
                lastSortedAscending = false;

            if (lastSortedAscending)
                m_InnerList.Values.Reverse();

            lastSortedAscending = !lastSortedAscending;
            lastSortedKey = primaryColumnKey;

            RefreshValues();
        }

        public void ChangeDataset(IListViewObjectContainer<T> newItems)
        {
            m_InnerList = newItems;
            RefreshValues();
        }
        #endregion
    }
}