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

        public CashInputViewModel()
        {
            IncrementAmtCommand = new IncrementAmountCommand(this);
            ClearCashAmtCommand = new ClearCashAmountCommand(this);
            InsertAmtCommand = new InsertAmountCommand(this);
        }

        public bool IsOpen 
        { 
            get => _isOpen; 
            set
            {
                _isOpen = value;
                OnPropertyChanged(nameof(IsOpen));
            }
        }
        public ICommand IncrementAmtCommand { get; }
        public ICommand InsertAmtCommand { get; }
        public ICommand ClearCashAmtCommand { get; }

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
