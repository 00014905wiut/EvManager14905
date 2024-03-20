import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { APIService } from '../../api.service';

@Component({
  selector: 'app-delete',
  templateUrl: './delete.component.html',
  styleUrls: ['./delete.component.css']
})
export class DeleteComponent implements OnInit {

  event: any = {
    eventId: 0,
    name: "",
    createdAt: "",
    completedDate: "",
    eventRating: {
      ratingId: 0,
      rating: 0,
      eventId: 0
    }
  };

  constructor(private apiService: APIService, private activatedRoute: ActivatedRoute, private router: Router) { }

  ngOnInit(): void {
    this.apiService.getEventById(this.activatedRoute.snapshot.params["id"]).subscribe((result) => {
      this.event = result;
    });
  }

  cancel() {
    this.router.navigateByUrl("events");
  }

  delete() {
    if (confirm("Are you sure you want to delete this event?")) {
      this.apiService.deleteEvent(this.event.eventId).subscribe(() => {
        alert("Event deleted successfully");
        this.router.navigateByUrl("events");
      });
    }
  }

}


