import { Component, OnInit } from '@angular/core';
import { ingatlanModel } from '../ingatlan.model';
import { IngatlanService } from '../ingatlan.service';
import { kategoriaModel } from '../kategoria.model';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-newad',
  templateUrl: './newad.component.html',
  styleUrls: ['./newad.component.scss']
})
export class NewadComponent implements OnInit {

  public kategoriak:kategoriaModel[] = [];
  public ingatlan:ingatlanModel = new ingatlanModel();


  constructor(private service : IngatlanService) {
    this.ingatlan.hirdetesDatuma = "2002.06.26";
    this.service.getKategoriak().subscribe((kategoriak) => {
      this.kategoriak = kategoriak;
    })

   }

  ngOnInit(): void {
  }

  submit() {
    this.service.insertIngatlan(this.ingatlan);
  }

}
