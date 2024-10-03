import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RepositoryGridComponent } from './repository-grid.component';

describe('RepositoryGridComponent', () => {
  let component: RepositoryGridComponent;
  let fixture: ComponentFixture<RepositoryGridComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [RepositoryGridComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RepositoryGridComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
