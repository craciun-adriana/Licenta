import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DetailsGroupDialog } from './details-group.component';

describe('DetailsGroupComponent', () => {
  let component: DetailsGroupDialog;
  let fixture: ComponentFixture<DetailsGroupDialog>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [DetailsGroupDialog]
    })
      .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DetailsGroupDialog);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
