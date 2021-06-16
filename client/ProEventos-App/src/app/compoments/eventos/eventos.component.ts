import { Component, OnInit } from '@angular/core';
import { HttpClient }  from '@angular/common/http'

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.css']
})
export class EventosComponent implements OnInit {

  public eventos: any = [];
  public eventosFiltrados: any = [];
  widthImg: number = 80;
  marginImg: number = 2;
  mostrarImagem: boolean = true;
  private _filtroLista: string = "";

  public get filtroLista() {
    return this._filtroLista
  }
//seta a lista de eventos
  public set filtroLista(value: string) {
    this._filtroLista = value;
    this.eventosFiltrados = this.filtroLista ? this.filtraEventos(this.filtroLista) : this.eventos;
  }
 //Filtra a lista de eventos por tema ou local//
  filtraEventos(filtraPor: string): any {
    filtraPor = filtraPor.toLocaleLowerCase();
    return this.eventos.filter((event: { tema: string; local:string }) => event.tema.toLocaleLowerCase().indexOf(filtraPor) !== -1 ||
    event.local.toLocaleLowerCase().indexOf(filtraPor) !== -1
    )

  }

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.getEventos()
  }

  alterarImagem(){
    this.mostrarImagem = !this.mostrarImagem;
  }
public getEventos(): void {
  this.http.get('https://localhost:5001/api/eventos').subscribe(
    response => {
      this.eventos = response
      this.eventosFiltrados = this.eventos

    },
    error => console.log(error)
  );
  }
}
