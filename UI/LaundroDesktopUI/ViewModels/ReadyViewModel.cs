using LaundroDesktopUI.Library.Api;
using LaundroDesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundroDesktopUI.ViewModels
{
    public class ReadyViewModel : ViewModelBase
    {
        private string _id;
        private string _name;
        private readonly IWdfEndpoint _wdfEndpoint;
        private ObservableCollection<WDFModel> _customerWDFs = new ObservableCollection<WDFModel>();

        public ReadyViewModel(IWdfEndpoint wdfEndpoint)
        {
            _wdfEndpoint = wdfEndpoint;
        }

        public ObservableCollection<WDFModel> CustomerWDFs
        {
            get => _customerWDFs;
            set
            {
                _customerWDFs = value;
                OnPropertyChanged(nameof(CustomerWDFs));
            }
        }
        public string ID
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged(nameof(ID));
            }
        }

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public int Orders => CustomerWDFs.Count;

        public int PaidOrders => CustomerWDFs.Sum(x => x.IsPaid ? 1 : 0);

        public int UnpaidOrders => CustomerWDFs.Sum(x => x.IsPaid ? 1 : 0);

        public decimal Value => CustomerWDFs.Sum(x => x.Total);

        public decimal AmountPaid => CustomerWDFs.Sum(x => x.IsPaid ? x.Total : 0M);

        public decimal AmountUnpaid => CustomerWDFs.Sum(x => !x.IsPaid ? x.Total : 0M);

        public async Task LoadWDFReadyListAsync()
        {
            IEnumerable<WDFModel> wdfs = await _wdfEndpoint.GetAll();
            wdfs = wdfs.Where(w => w.Status == WDFModel.CompletedTodayStatus && !w.IsPickedUp);
            ObservableCollection<WDFModel> result = new();
            foreach (WDFModel wdf in wdfs)
            {
                result.Add(wdf);
            }
            CustomerWDFs = result;
            OnPropertyChanged(nameof(Orders));
            OnPropertyChanged(nameof(PaidOrders));
            OnPropertyChanged(nameof(UnpaidOrders));
            OnPropertyChanged(nameof(Value));
            OnPropertyChanged(nameof(AmountPaid));
            OnPropertyChanged(nameof(AmountUnpaid));
        }

    }
}
