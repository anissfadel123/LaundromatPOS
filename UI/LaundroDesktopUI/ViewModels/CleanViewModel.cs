using LaundroDesktopUI.Commands;
using LaundroDesktopUI.Library.Api;
using LaundroDesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LaundroDesktopUI.ViewModels
{
    public class CleanViewModel : ViewModelBase
    {
        private ObservableCollection<WdfCardViewModel> _wdfList = new ObservableCollection<WdfCardViewModel>();
        private IWdfEndpoint _wdfEndpoint;

        public CleanViewModel(IWdfEndpoint wdfEndpoint)
        {
            _wdfEndpoint = wdfEndpoint;
        }

        public List<WdfCardViewModel> ToDoList
        {
            get { return _wdfList.Where(x => x.Status == WDFModel.ToDoStatus).ToList();}

        }

        public List<WdfCardViewModel> WashList
        {
            get { return _wdfList.Where(x => x.Status == WDFModel.WashStatus).ToList(); }

        }

        public List<WdfCardViewModel> DryList
        {
            get { return _wdfList.Where(x => x.Status == WDFModel.DryStatus).ToList(); }
        }

        public List<WdfCardViewModel> FoldList
        {
            get { return _wdfList.Where(x => x.Status == WDFModel.FoldStatus).ToList(); }

        }

        public List<WdfCardViewModel> CompletedTodayList
        {
            get { return _wdfList.Where(x => x.Status == WDFModel.CompletedTodayStatus).ToList(); }

        }
        public async Task LoadWdfAsync()
        {
            _wdfList = new ObservableCollection<WdfCardViewModel>();
            var wdf = await _wdfEndpoint.GetAll();
            foreach(var wash in wdf)
            {
                _wdfList.Add(new WdfCardViewModel(wash, _wdfEndpoint, this));
            }
            OnPropertyChanged(nameof(ToDoList));
            OnPropertyChanged(nameof(WashList));
            OnPropertyChanged(nameof(DryList));
            OnPropertyChanged(nameof(FoldList));
            OnPropertyChanged(nameof(CompletedTodayList));
        }
    }
}
