import { Component, OnDestroy, OnInit} from '@angular/core';
import { Subscription } from 'rxjs';
import { Wdf } from '../models/wdf.model';
import { WdfService } from '../services/wdf.service';

@Component({
  selector: 'app-clean',
  templateUrl: './clean.component.html',
  styleUrls: ['./clean.component.css']
})
export class CleanComponent implements OnInit, OnDestroy {
  WDFs : Wdf[] = [];
  subscriptions: Subscription[] =[];

  constructor(private _wdfService: WdfService) { }

  ngOnInit(): void {
    this.subscriptions.push(this._wdfService.wdfs$.subscribe(
      wdfs => {
        this.WDFs = wdfs;
      }
    ))
  }


  ngOnDestroy(): void {
    this.subscriptions.forEach(subs => { subs.unsubscribe(); });
  }

  onIncrementStatus(wdf: Wdf){
    this.subscriptions.push(this._wdfService.incrementStatus(wdf.id).subscribe());
    wdf.status += 1;
  }

  onDecrementStatus(wdf: Wdf){
    this.subscriptions.push(this._wdfService.decrementStatus(wdf.id).subscribe());
    wdf.status -= 1;
  }


}
