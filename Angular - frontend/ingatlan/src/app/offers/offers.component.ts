import { Component, OnInit } from '@angular/core';
import { ingatlanModel } from '../ingatlan.model';
import { IngatlanService } from '../ingatlan.service';

@Component({
  selector: 'app-offers',
  templateUrl: './offers.component.html',
  styleUrls: ['./offers.component.scss']
})
export class OffersComponent implements OnInit {

  public ingatlanok:ingatlanModel[] = [

  ];

  constructor(private service: IngatlanService) { 
    this.service.getIngatlanok().subscribe((data) => {
      this.ingatlanok = data;
    })
  }

  ngOnInit(): void {
  }

}
