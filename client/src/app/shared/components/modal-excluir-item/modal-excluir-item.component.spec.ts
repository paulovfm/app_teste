import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ModalExcluirItemComponent } from './modal-excluir-item.component';

describe('ModalExcluirItemComponent', () => {
  let component: ModalExcluirItemComponent;
  let fixture: ComponentFixture<ModalExcluirItemComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ModalExcluirItemComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ModalExcluirItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
