import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { Evento } from 'src/app/models/Evento';
import { EventoService } from 'src/app/services/evento.service';
import { BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.css']
})
export class EventosComponent implements OnInit {
   modalRef= {} as BsModalRef;
  public eventos: Evento[] = [];
  public eventosFiltrados: Evento[] = [];
  widthImg: number = 80;
  marginImg: number = 2;
  mostrarImagem: boolean = false;
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
  filtraEventos(filtraPor: string): Evento[] {
    filtraPor = filtraPor.toLocaleLowerCase();
    return this.eventos.filter((event: { tema: string; local:string }) => event.tema.toLocaleLowerCase().indexOf(filtraPor) !== -1 ||
    event.local.toLocaleLowerCase().indexOf(filtraPor) !== -1
    )

  }

  constructor(
    private eventoService: EventoService,
    private modalService: BsModalService,
    private toastr: ToastrService,
    ) { }

  public ngOnInit(): void {
    this.getEventos()
  }

  public alterarImagem(){
    this.mostrarImagem = !this.mostrarImagem;
  }
public getEventos(): void {
  this.eventoService.getEventos().subscribe(
    (_eventos: Evento[] ) => {
      this.eventos = _eventos
      this.eventosFiltrados = this.eventos
      console.log(_eventos)

    },
    error => console.log(error)
  );
  }
  openModal(template: TemplateRef<any>): void {
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }

  confirm(): void {
    this.modalRef.hide()

    this.toastr.success('Hello world!', 'Toastr fun!');
  }

  decline(): void {

    this.modalRef.hide()
    this.toastr.success('Hello world!', 'Toastr fun!');
  }

}

