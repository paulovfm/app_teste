import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EditarFuncionalidadeComponent } from './editar-funcionalidade.component';

describe('EditarFuncionalidadeComponent', () => {
  let component: EditarFuncionalidadeComponent;
  let fixture: ComponentFixture<EditarFuncionalidadeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EditarFuncionalidadeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EditarFuncionalidadeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
