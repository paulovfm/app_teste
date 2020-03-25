import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { PageChangedEvent } from 'ngx-bootstrap';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.scss']
})

export class TableComponent implements OnInit {

  @Input() totalItems: string;
  @Input() centralizar = true;
  @Input() tamanhoMaximo = 5;
  @Input() isResponsive = false;
  @Input() tabelaComBorda = false;
  @Input() tabelaSm = false;
  @Input() tabelaStriped = false;
  @Input() tabelaHover = false;


  @Output() alterouPagina = new EventEmitter();

  alterouQuantidadePorPagina = new EventEmitter<PageChangedEvent>();

  itensPorPagina = 10;

  constructor() { }

  ngOnInit() { }

  alterarPagina(event: PageChangedEvent): void {
    event.itemsPerPage = this.itensPorPagina;
    this.alterouPagina.emit(event);
  }

}
