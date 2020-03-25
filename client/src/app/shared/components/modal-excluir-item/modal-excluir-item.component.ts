import { Component, OnInit, Input, Output, EventEmitter, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap';

@Component({
  selector: 'app-modal-excluir-item',
  templateUrl: './modal-excluir-item.component.html',
  styleUrls: ['./modal-excluir-item.component.scss']
})

export class ModalExcluirItemComponent implements OnInit {

  @Input() itemExcluir: any;
  @Input() nivelModal: number;

  @Output() confirmarExclusao = new EventEmitter();

  bsModalRef: BsModalRef;

  constructor(
    private modalService: BsModalService
  ) { }

  ngOnInit() {
  }

  openModal(template: TemplateRef<any>) {
    this.bsModalRef = this.modalService.show(template);
  }

  excluir(item: any) {
    this.confirmarExclusao.emit(item);
    if (this.nivelModal) {
      this.modalService.hide(this.nivelModal);
    } else {
      this.modalService.hide(1);
    }
  }

}

