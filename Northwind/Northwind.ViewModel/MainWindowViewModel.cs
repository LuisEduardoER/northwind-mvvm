using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows.Data;
using Northwind.Application;
using Northwind.Interfaces;

namespace Northwind.ViewModel
{
    public class MainWindowViewModel : NamedViewModel
    {
        #region Properties

        private ControlPanelViewModel _controlPanel;

        public ControlPanelViewModel ControlPanel
        {
            get
            {
                if (_controlPanel == null)
                {
                    _controlPanel 
                        = new ControlPanelViewModel();
                    _controlPanel.ShowCustomerDetails 
                        += ControlPanel_ShowCustomerDetails;
                }
                return _controlPanel;
            }
        }

        void ControlPanel_ShowCustomerDetails(object sender, 
                CustomerEventArgs e)
        {
            CustomerDetailsViewModel customerDetailsViewModelBase
                = new CustomerDetailsViewModel(
                    ApplicationServices.Instance.NorthwindManager.GetCustomerByID(e.CustomerID),
                    ApplicationServices.Instance);
            Tools.Add(customerDetailsViewModelBase);
            SetCurrentTool(customerDetailsViewModelBase);
        }

        private ObservableCollection<ToolViewModel> _tools;
        public ObservableCollection<ToolViewModel> Tools
        {
            get
            {
                if (_tools == null)
                {
                    _tools = new ObservableCollection<ToolViewModel>();
                    _tools.CollectionChanged += OnToolsCollectionChanged;
                }
                return _tools;
            }
        }

        #endregion Properties

        #region ctor

        public MainWindowViewModel()
            : base(Strings.MainWindowDisplayName)
        {
        }

        #endregion ctor

        #region Event handlers

        void OnToolsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count != 0)
                foreach (ToolViewModel tool in e.NewItems)
                    tool.RequestClose += OnToolRequestClose;

            if (e.OldItems != null && e.OldItems.Count != 0)
                foreach (ToolViewModel tool in e.OldItems)
                    tool.RequestClose -= OnToolRequestClose;
        }

        void OnToolRequestClose(object sender, EventArgs e)
        {
            ToolViewModel tool = sender as ToolViewModel;
            Tools.Remove(tool);            
            tool.Dispose();
        }

        #endregion Event handlers

        #region Helpers

        private void SetCurrentTool(ToolViewModel currentTool)
        {
            ICollectionView collectionView = CollectionViewSource.GetDefaultView(Tools);
            if (collectionView != null)
            {
                if (collectionView.MoveCurrentTo(currentTool) != true)
                {
                    throw new InvalidOperationException("Could not find the current tool.");
                }
            }
        }

        #endregion Helpers
    }
}