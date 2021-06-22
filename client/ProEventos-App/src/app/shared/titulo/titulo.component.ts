import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-titulo',
  templateUrl: './titulo.component.html',
  styleUrls: ['./titulo.component.css']
})
export class TituloComponent implements OnInit {
 @Input() titulo = {}as string;
 @Input() iconClass = 'fa fa-users';
 @Input() subTitulo = 'Desde 2021';
 @Input() botao_listar = false;


  constructor(private router: Router) { }

  ngOnInit(): void {
  }

  listar():void {
    this.router.navigate([`eventos/lista`]);
  }

}
