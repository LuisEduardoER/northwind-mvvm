using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Northwind.Application.Model
{
    public class ModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged 
            = delegate {};

        public void RaisePropertyChanged(string propertyName)
        {
            VerifyPropertyName(propertyName);
            PropertyChanged(this, 
                new PropertyChangedEventArgs(propertyName));
        }

        [Conditional("Debug")]
        public void VerifyPropertyName(string propertyName)
        {
            if (TypeDescriptor.GetProperties(this)[propertyName] == null)
            {
                throw new InvalidOperationException(
                    "Unable to find property named: "
                    + propertyName);
            }

        }
    }
}
