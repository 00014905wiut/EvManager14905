import { Component } from '@angular/core';

import { APIService } from '../../api.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrl: './create.component.css',
})
export class CreateComponent {
  createFeature: any = {
    eventId: 0,
    name: '',
    createdAt: null,
    completedDate: null,
    ratingID: 0,
    eventRating:{
      ratingId: 0,
      rating: 0,
      eventId: 0,

    }
  };

  constructor(private apiService: APIService, private router: Router) {}

  ngOnInit(): void {}

  create() {
    this.apiService.createEvent(this.createFeature).subscribe((result) => {
      alert('Item Saved');
      this.router.navigateByUrl('details');
    });
  }
}
