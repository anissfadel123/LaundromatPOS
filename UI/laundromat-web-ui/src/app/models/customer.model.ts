export class Customer {
  id: number;
  firstName: string;
  lastName: string;
  email: string;
  phone: string;
  address: string;
  points: number;

  constructor(id:number = 0, firstName:string = "Guest", lastName:string = "",
  email:string = "", phone:string = "none", address:string = "", points:number = 0){
    this.id = id;
    this.firstName = firstName;
    this.lastName = lastName;
    this.email = email;
    this.phone = phone;
    this.address = address;
    this.points = points;
  }

  getName(): string {
    return this.firstName + " " + this.lastName;
  }

}
