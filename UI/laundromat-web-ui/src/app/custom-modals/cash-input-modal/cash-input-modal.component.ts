import { NumberSymbol } from '@angular/common';
import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-cash-input-modal',
  templateUrl: './cash-input-modal.component.html',
  styleUrls: ['./cash-input-modal.component.css']
})
export class CashInputModalComponent implements OnInit {

  constructor() { }
  @Input() isOpen = false;
  @Output() closeModalEvent = new EventEmitter();

  @Input() total: number = 0;

  cashAmount: string = "";

  ngOnInit(): void {
  }


  closeModal() {
    this.closeModalEvent.emit();
  }

  incrementAmount(num:number){
    if(this.cashAmount == ""){
      this.cashAmount = num.toString();
      return;
    }
    let amt = Number(this.cashAmount);
    amt += num;
    this.cashAmount = amt.toString();
  }

  cancatAmount(amt:string){

    if(amt=='.' && this.cashAmount.includes(".") || this.cashAmount.charAt(this.cashAmount.length-3)=='.'){
      return;
    }

    if(amt!='.' && this.cashAmount.length == 1 && this.cashAmount.charAt(0) == "0"){
      this.cashAmount = amt;
      return;
    }

    this.cashAmount += amt;
  }

  clearAmount(){
    this.cashAmount = "";
  }



}
