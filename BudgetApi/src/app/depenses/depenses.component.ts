import { Component, OnInit } from '@angular/core';
import { Depense } from '../depense';

@Component({
  selector: 'app-depenses',
  templateUrl: './depenses.component.html',
  styleUrls: ['./depenses.component.sass']
})
export class DepensesComponent implements OnInit {

  depense: Depense = {
    id: 1,
    montant: 50,
    category: "courses"
  }

  constructor() { }

  ngOnInit() {
  }

}
