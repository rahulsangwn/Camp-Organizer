import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CampEditComponent } from './camp-edit.component';

describe('CampEditComponent', () => {
  let component: CampEditComponent;
  let fixture: ComponentFixture<CampEditComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CampEditComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CampEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
