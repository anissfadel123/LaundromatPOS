import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-add-new-product-modal',
  templateUrl: './add-new-product-modal.component.html',
  styleUrls: ['./add-new-product-modal.component.css']
})
export class AddNewProductModalComponent implements OnInit{
  @Input() isOpen = true;
  @Output() closeModalEvent = new EventEmitter();

  productForm = new FormGroup({
    productDescripton: new FormControl(''),
    price: new FormControl(''),
    barcode: new FormControl('')
  })

  constructor() { }

  ngOnInit(): void {
  }

  closeModal() {
    this.closeModalEvent.emit();
  }

}
