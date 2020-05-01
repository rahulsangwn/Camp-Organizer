import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CampItemComponent } from './camp-item.component';

describe('CampItemComponent', () => {
  let component: CampItemComponent;
  let fixture: ComponentFixture<CampItemComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CampItemComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CampItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
