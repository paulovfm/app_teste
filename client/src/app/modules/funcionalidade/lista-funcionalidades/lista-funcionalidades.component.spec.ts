import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ListaFuncionalidadesComponent } from './lista-funcionalidades.component';

describe('ListaFuncionalidadesComponent', () => {
  let component: ListaFuncionalidadesComponent;
  let fixture: ComponentFixture<ListaFuncionalidadesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListaFuncionalidadesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListaFuncionalidadesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
