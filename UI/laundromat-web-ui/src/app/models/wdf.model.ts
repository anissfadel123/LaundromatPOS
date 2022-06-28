export class Wdf {
  static readonly toDoStatus = 0;
  static readonly washStatus = 1;
  static readonly dryStatus = 2;
  static readonly foldStatus = 3;
  static readonly completedStatus = 4;

  id = 0;
  firstName = "";
  lastName = "";
  customerId = 0;
  readyBy = new Date();
  total = 0.0;
  washMachine = "";
  dryMachine = "";
  status = 0;
  isPickedUp = false;
  isPaid = false;
  preferencs = "";
  bags = 1;

}
