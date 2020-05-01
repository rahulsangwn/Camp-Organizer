import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CampBookComponent } from './camp-book.component';

describe('CampBookComponent', () => {
  let component: CampBookComponent;
  let fixture: ComponentFixture<CampBookComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CampBookComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CampBookComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
