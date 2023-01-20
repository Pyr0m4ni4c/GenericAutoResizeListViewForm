using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;

namespace GenericAutoResizeListViewForm
{
    public sealed partial class DefaultListViewForm<T> : Form
    {
        #region private Member
        #endregion

        #region private Eigenschaften
        private IListViewControls<T> m_ListView;
        #endregion

        #region öffentliche Eigenschaften
        public T[] SelectedValues => m_ListView.SelectedValues;
        #endregion

        #region Konstruktor
        public DefaultListViewForm(IListViewControls<T> listView,
            MessageBoxButtons buttons,
            string mandatoryDescription,
            params string[] additionalDescriptions)
        {
            InitializeComponent();
            var fonti = new System.Drawing.Font("Arial", 15.75F);
            Font = new Font(fonti.FontFamily, Font.Size);

            #region Labels
            m_Panel_Header.Controls.Clear();
            m_Panel_Header.Controls.Add(new Label()
            {
                Text = mandatoryDescription,
                Font = fonti,
                Padding = new Padding(0, 3, 0, 0),
                Dock = DockStyle.Left,
                AutoSize = true,
            });
            foreach (var description in additionalDescriptions)
            {
                m_Panel_Header.Controls.Add(new Label()
                {
                    Text = description,
                    Font = fonti,
                    Padding = new Padding(0, 3, 0, 0),
                    Dock = DockStyle.Right,
                    AutoSize = true,
                });
            }
            #endregion

            #region Buttons
            m_Panel_Buttons.Controls.Clear();
            var showButtons = new List<Button>();

            switch (buttons)
            {
                case MessageBoxButtons.OK:
                    showButtons.Add(GetOkButton());
                    break;
                case MessageBoxButtons.OKCancel:
                    showButtons.Add(GetOkButton());
                    showButtons.Add(GetCancelButton());
                    break;
                case MessageBoxButtons.YesNo:
                    showButtons.Add(GetYesButton());
                    showButtons.Add(GetNoButton());
                    break;
                case MessageBoxButtons.RetryCancel:
                    showButtons.Add(GetRetryButton());
                    showButtons.Add(GetCancelButton());
                    break;
                case MessageBoxButtons.AbortRetryIgnore:
                    showButtons.Add(GetAbortButton());
                    showButtons.Add(GetRetryButton());
                    showButtons.Add(GetIgnoreButton());
                    break;
            }

            foreach (var button in showButtons)
            {
                m_Panel_Buttons.Controls.Add(button);
            }
            #endregion

            m_ListView = listView;
            m_Panel_ListView.Controls.Add((Control)listView);


#if !DEBUG
            m_Panel_TestButtons.Visible = false;
#else
            m_Panel_TestButtons.Visible = true;
            m_Button_Add.Click += m_Button_Add_Click;
            m_Button_Remove.Click += m_Button_Remove_Click;
            TopMost = true;
            StartPosition = FormStartPosition.CenterScreen;
#endif

            m_Panel.MinimumSize = m_Panel_Header.Size + m_Panel_Buttons.Size;

            if (listView is DefaultDynamicListView<T> listi)
                listi.Init();

            ResizeListView();
        }
        #endregion

        #region öffentliche Methoden
        #endregion

        #region private Methoden
        private void ResizeListView()
        {
            m_ListView.AutoResizeParent(this, m_Panel_ListView);
        }

        #region GetButtons
        private Button GetOkButton()
        {
            return new Button()
            {
                Text = "Ok",
                DialogResult = DialogResult.OK,
                Dock = DockStyle.Left,
            };
        }

        private Button GetCancelButton()
        {
            return new Button()
            {
                Text = "Abbrechen",
                DialogResult = DialogResult.Cancel,
                Dock = DockStyle.Right,
            };
        }

        private Button GetYesButton()
        {
            return new Button()
            {
                Text = "Ja",
                DialogResult = DialogResult.Yes,
                Dock = DockStyle.Left,
            };
        }

        private Button GetNoButton()
        {
            return new Button()
            {
                Text = "Nein",
                DialogResult = DialogResult.No,
                Dock = DockStyle.Right,
            };
        }

        private Button GetRetryButton()
        {
            return new Button()
            {
                Text = "Erneut\nVersuchen",
                DialogResult = DialogResult.Retry,
                Dock = DockStyle.Left,
            };
        }

        private Button GetAbortButton()
        {
            return new Button()
            {
                Text = "Abbrechen",
                DialogResult = DialogResult.Abort,
                Dock = DockStyle.Right,
            };
        }

        private Button GetIgnoreButton()
        {
            return new Button()
            {
                Text = "Ignorieren",
                DialogResult = DialogResult.Ignore,
                Dock = DockStyle.Right,
            };
        }
        #endregion
        #endregion

        #region private GUI-Events
#if DEBUG
        private void m_Button_Remove_Click(object sender, EventArgs e)
        {
            if (m_ListView is DefaultDynamicListView<T>)
            {
                var view = ((DefaultDynamicListView<T>)m_ListView);
                if (view.m_InnerList.ColumnDefinition.Count > 0)
                    m_ListView.RemoveItem(view.m_InnerList.Values[view.m_InnerList.Values.Count - 1]);
            }

            ResizeListView();
        }

        private void m_Button_Add_Click(object sender, EventArgs e)
        {
            var instance = Activator.CreateInstance<T>();

            m_ListView.AddItem(instance);

            ResizeListView();
        }
#endif
        #endregion
    }
}