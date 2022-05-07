using LaundroDesktopUI.Commands;
using LaundroDesktopUI.Library.Api;
using LaundroDesktopUI.Library.Models;
using System;
using System.Windows.Input;

namespace LaundroDesktopUI.ViewModels
{
    public class WdfCardViewModel : ViewModelBase
    {
        private readonly WDFModel _wdfModel;
        public String CustomerName =>  $"{_wdfModel.FirstName} { _wdfModel.LastName }";
        public decimal Total => _wdfModel.Total;
        public DateTime ReadyBy => _wdfModel.ReadyBy;

        public WdfCardViewModel(WDFModel wdfModel, IWdfEndpoint wdfEndpoint, CleanViewModel cleanViewModel)
        {
            _wdfModel = wdfModel;
            IncrementStatusCommand = new IncrementWDFStatusCommand(wdfEndpoint, cleanViewModel);
            DecrementStatusCommand = new DecrementWDFStatusCommand(wdfEndpoint, this, cleanViewModel);
        }

        public int Id => _wdfModel.Id;
        public byte Status
        {
            get => _wdfModel.Status;
            set
            {
                _wdfModel.Status = value;
                OnPropertyChanged(nameof(Status));
            }
        }
        public ICommand IncrementStatusCommand { get; }
        public ICommand DecrementStatusCommand { get; }
    }
}
