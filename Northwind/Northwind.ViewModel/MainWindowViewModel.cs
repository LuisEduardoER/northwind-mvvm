﻿using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;

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
                        += ControlPanelShowCustomerDetails;
                }
                return _controlPanel;
            }
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

        #region Command handlers

        void ControlPanelShowCustomerDetails(object sender,
        CustomerEventArgs e)
        {
            CustomerDetailsViewModel customerDetailsViewModel
                = Tools.Cast<CustomerDetailsViewModel>()
                      .FirstOrDefault(
                          detailsViewModel =>
                          detailsViewModel.Customer.CustomerID == e.CustomerID
                      ) ?? GetNewCustomerDetailsViewModel(e.CustomerID);
            SetCurrentTool(customerDetailsViewModel);
        }

        #endregion Command handlers

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

        private CustomerDetailsViewModel GetNewCustomerDetailsViewModel(string customerID)
        {
            CustomerDetailsViewModel customerDetailsViewModel
                = new CustomerDetailsViewModel(customerID);
            Tools.Add(customerDetailsViewModel);
            return customerDetailsViewModel;
        }

        #endregion Helpers
    }
}