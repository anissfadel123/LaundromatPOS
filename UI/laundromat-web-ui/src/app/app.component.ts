import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Laundromat POS';
  displayRegisterCustomerModal = false;

  closeRegisterCustomerModal(){
    this.displayRegisterCustomerModal = false;
  }

  openRegisterCustomerModal(){
    this.displayRegisterCustomerModal = true;
  }
}
