using LaundroDesktopUI.Commands;
using LaundroDesktopUI.Services;
using LaundroDesktopUI.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LaundroDesktopUI.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;
        public RegisterCustomerViewModel RegisterCustomerVM { get; }
        public CashInputViewModel CashInputVM { get; }
        public CancelViewModel CancelVM { get; }
        public PaymentSelectionViewModal PaymentSelectionVM { get; }
        public EditItemViewModel EditItemVM { get; }
        public CleanViewModel CleanVM { get; }
        public ReadyViewModel ReadyVM { get; }
        public SideBarViewModel SideBarVM { get; }
        public SelectCustomerViewModel SelectCustomerVM { get; }
        public LoginViewModel LogInVM { get; }
        public CustomerProductViewModel selectedProductToEdit;
        public AddNewProductViewModel AddNewProductVM { get; }

        public PrintReceiptViewModel PrintReceiptVM { get; }



        public MainViewModel(NewSaleViewModel newSaleViewModel, CleanViewModel cleanViewModel,
            RegisterCustomerViewModel registerCustomerViewModel, CashInputViewModel cashInputVM,
            PaymentSelectionViewModal paymentSelectionVM, CancelViewModel cancelView, ReadyViewModel readyVM,
            NavigationStore navigationStore, NavigationService<NewSaleViewModel> newSaleViewNavigationService,
            NavigationService<CleanViewModel> cleanViewNavigationService, NavigationService<ReadyViewModel> readyViewNavigationService,
            SideBarViewModel sideBarView, SelectCustomerViewModel selectCustomerVM, LoginViewModel logInVM, 
            AddNewProductViewModel addNewProductVM, PrintReceiptViewModel printReceiptVM)
        {
            _navigationStore = navigationStore;
            navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;

            RegisterCustomerVM = registerCustomerViewModel;
            PaymentSelectionVM = paymentSelectionVM;
            CashInputVM = cashInputVM;
            CancelVM = cancelView;
            SideBarVM = sideBarView;
            LogInVM = logInVM;
            CleanVM = cleanViewModel;
            ReadyVM = readyVM;
            SelectCustomerVM = selectCustomerVM;
            AddNewProductVM = addNewProductVM;
            PrintReceiptVM = printReceiptVM;
            EditItemVM = new EditItemViewModel(this, newSaleViewModel);

            //Cash Register Section
            NewSaleCommand = new NavigateCommand<NewSaleViewModel>(newSaleViewNavigationService);
            CleanCommand = new NavigateCommand<CleanViewModel>(cleanViewNavigationService);
            ReadyCommand = new NavigateCommand<ReadyViewModel>(readyViewNavigationService);


            CloseCurrentOpenNewModal = new CloseCurrent_OpenNewModalCommand<PaymentSelectionViewModal>(PaymentSelectionVM);
            OpenEditProductModal = new OpenEditModalCommand(this);
            OpenOrCloseModal = new OpenOrCloseModalCommand();
        }

        public ICommand NewSaleCommand { get; }
        public ICommand CleanCommand { get; }
        public ICommand ReadyCommand { get; }
        public ICommand PickUpCommand { get; }

        public ICommand OpenEditProductModal { get; }
        public ICommand OpenOrCloseModal { get; }
        public ICommand CloseCurrentOpenNewModal { get; }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}