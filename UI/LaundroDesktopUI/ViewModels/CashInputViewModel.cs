using LaundroDesktopUI.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LaundroDesktopUI.ViewModels
{
    public class CashInputViewModel : ViewModelBase, IModal
    {
        private string _cashAmount = "";
        private bool _isOpen = false;
        private NewSaleViewModel _newSaleVM;

        public CashInputViewModel(NewSaleViewModel newSaleVM)
        {
            IncrementAmtCommand = new IncrementAmountCommand(this);
            ClearCashAmtCommand = new ClearCashAmountCommand(this);
            InsertAmtCommand = new InsertAmountCommand(this);
            CloseCurrentOpenPrintReceiptModal = new CloseCurrent_OpenNewModalCommand<CashInputViewModel>(this);
            _newSaleVM = newSaleVM;
        }

        public bool IsOpen 
        { 
            get => _isOpen; 
            set
            {
                _isOpen = value;
                if (value)
                {
                    CashAmount = "";
                    OnPropertyChanged(nameof(Total));
                }
                OnPropertyChanged(nameof(IsOpen));
                
            }
        }
        public decimal Total => _newSaleVM.GrandTotal;
        public ICommand IncrementAmtCommand { get; }
        public ICommand InsertAmtCommand { get; }
        public ICommand ClearCashAmtCommand { get; }

        public ICommand CloseCurrentOpenPrintReceiptModal { get; }

        public string CashAmount
        {
            get => _cashAmount;
            set
            {
                _cashAmount = value;
                OnPropertyChanged(nameof(CashAmount));
            }
        }
        public void IncrementAmount(int num)
        {
            decimal cashAmtDec = 0M;
            if (CashAmount.Length != 0)
            {
                cashAmtDec = Decimal.Parse(CashAmount);
            }

            cashAmtDec += num;
            CashAmount = cashAmtDec.ToString();
        }

        public void ClearCashAmount()
        {
            CashAmount = "";
        }

        public void InsertAmount(char numChar)
        {
            if (numChar == '0' && CashAmount.Length == 0)
            {
                return;
            }
            if (Char.IsNumber(numChar))
            {
                if (CashAmount.Contains('.') && CashAmount.Length > 2 && CashAmount[CashAmount.Length - 3].Equals('.'))
                {
                    return;
                }
            }
            else if (numChar.Equals('.') && CashAmount.Contains('.'))
            {
                return;

            }
            CashAmount += numChar;
        }
    }
}
