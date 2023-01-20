using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GenericAutoResizeListViewForm
{
    internal static class Program
    {
        private class ExampleObject
        {
            private static Random r = new Random();
            public string m_Name { get; set; } = r.Next().ToString();
            public int m_IValue { get; set; } = r.Next();

            public override string ToString()
            {
                return $"{nameof(m_Name)}: {m_Name}, {nameof(m_IValue)}: {m_IValue}";
            }
        }

        private class ExampleColumnHandling : IObjectColumnHandling<ExampleObject>
        {
            public Func<ExampleObject, string> GetDescription { get; set; }
            public Func<ExampleObject, object> GetValue { get; set; }
            public Func<ExampleObject, object> SortKey { get; set; }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var enableVisualStyles = false;
            if (enableVisualStyles)
                Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var defaultListViewObjectContainer = new DefaultListViewObjectContainer<ExampleObject>();
            defaultListViewObjectContainer.ColumnDefinition = new List<string>() { "1", "2" };
            defaultListViewObjectContainer.Values = new List<ExampleObject>()
            {
                new ExampleObject() { m_IValue = 4, m_Name = "7" },
                new ExampleObject() { m_IValue = 3, m_Name = "8" },
                new ExampleObject() { m_IValue = 1, m_Name = "6" },
                new ExampleObject() { m_IValue = 2, m_Name = "5" },
            };
            defaultListViewObjectContainer.ObjectColumnHandlings =
                new Dictionary<string, IObjectColumnHandling<ExampleObject>>()
                {
                    { "1", new ExampleColumnHandling() { SortKey = o => o.m_Name, GetValue = o => o.m_Name, GetDescription = o => o.m_Name } },
                    { "2", new ExampleColumnHandling() { SortKey = o => o.m_IValue, GetValue = o => o.m_IValue, GetDescription = o => o.m_IValue.ToString() } },
                };

            var dlv = new DefaultDynamicListView<ExampleObject>(defaultListViewObjectContainer, visualStylesEnabled: enableVisualStyles, multiSelect: true);
            var form = new DefaultListViewForm<ExampleObject>(dlv, MessageBoxButtons.OKCancel, "Description", "1", "2");
            form.ShowDialog();
            if (form.SelectedValues.Length > 0)
                System.Diagnostics.Debug.WriteLine(string.Join("\r\n", form.SelectedValues.Select(o => o.ToString()).ToArray()));
        }
    }
}