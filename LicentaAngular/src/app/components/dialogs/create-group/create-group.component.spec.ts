import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateGroupDialog } from './create-group.component';

describe('CreateGroupComponent', () => {
    let component: CreateGroupDialog;
    let fixture: ComponentFixture<CreateGroupDialog>;

    beforeEach(async () => {
        await TestBed.configureTestingModule({
            declarations: [CreateGroupDialog]
        })
            .compileComponents();
    });

    beforeEach(() => {
        fixture = TestBed.createComponent(CreateGroupDialog);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });

    it('should create', () => {
        expect(component).toBeTruthy();
    });
});
