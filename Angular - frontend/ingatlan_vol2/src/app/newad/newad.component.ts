import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-newad',
  templateUrl: './newad.component.html',
  styleUrls: ['./newad.component.scss']
})
export class NewadComponent implements OnInit {

  tipusok: any[] = [];
  errorMessage = ""
  model = {
      kategoriaId: 0,
      leiras: "",
      hirdetesDatuma: new Date().toISOString().substring(0, 10),
      tehermentes: true,
      kepUrl: ""
  }

  constructor(private http: HttpClient, private router: Router) { }

  ngOnInit(): void {
    this.http.get<any[]>('http://localhost:5000/api/kategoriak').subscribe({
      next: (data: any[]) => this.tipusok = data,
      error: (err) => this.errorMessage = err.message
    })
  }

  kuldes(): void {
    this.model.kategoriaId = Number(this.model.kategoriaId)
    this.http.post<any[]>('http://localhost:5000/api/ujingatlan', this.model).subscribe({
      next: () => this.router.navigate(['offers']),
      error: (err) => this.errorMessage = err.message
    })
  }

}
