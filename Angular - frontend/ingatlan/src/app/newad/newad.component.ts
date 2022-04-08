import { Component, OnInit } from '@angular/core';
import { ingatlanModel } from '../ingatlan.model';
import { Router, RouterLink } from '@angular/router';
import { IngatlanService } from '../ingatlan.service';
import { kategoriaModel } from '../kategoria.model';

@Component({
  selector: 'app-newad',
  templateUrl: './newad.component.html',
  styleUrls: ['./newad.component.scss']
})
export class NewadComponent implements OnInit {

  public kategoriak:kategoriaModel[] = [];
  public ingatlan:ingatlanModel = new ingatlanModel();

  public error:string = "";


  constructor(private service : IngatlanService, private router:Router) { 
    this.ingatlan.hirdetesDatuma = new Date().toISOString().substring(0,10);
    this.service.getKategoriak().subscribe((kategoriak) => {
      this.kategoriak = kategoriak;
    })

   }

  ngOnInit(): void {
  }

  submit() {
    this.service.insertIngatlan(this.ingatlan).subscribe({
      next: (data) => {
        this.router.navigate(['/offers']);
      },
      error: (err) => {
        this.error = err.message;
      }
    });
  }

}
