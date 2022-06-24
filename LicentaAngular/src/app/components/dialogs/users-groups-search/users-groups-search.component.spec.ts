import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UsersGroupsSearchDialog } from './users-groups-search.component';

describe('UsersGroupsSearchComponent', () => {
  let component: UsersGroupsSearchDialog;
  let fixture: ComponentFixture<UsersGroupsSearchDialog>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [UsersGroupsSearchDialog]
    })
      .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UsersGroupsSearchDialog);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
