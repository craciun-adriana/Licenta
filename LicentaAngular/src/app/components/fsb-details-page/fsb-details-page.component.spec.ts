import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FsbDetailsPageComponent } from './fsb-details-page.component';

describe('FsbDetailsPageComponent', () => {
  let component: FsbDetailsPageComponent;
  let fixture: ComponentFixture<FsbDetailsPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FsbDetailsPageComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FsbDetailsPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
