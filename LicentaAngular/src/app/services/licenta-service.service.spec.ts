import { TestBed } from '@angular/core/testing';

import { LicentaService } from './licenta-service.service';

describe('LicentaService', () => {
    let service: LicentaService;

    beforeEach(() => {
        TestBed.configureTestingModule({});
        service = TestBed.inject(LicentaService);
    });

    it('should be created', () => {
        expect(service).toBeTruthy();
    });
});
