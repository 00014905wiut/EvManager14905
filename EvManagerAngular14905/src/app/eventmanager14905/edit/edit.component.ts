
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { APIService } from '../../api.service';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit {

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
    this.apiService.getEventById(this.activatedRoute.snapshot.params["id"]).subscribe((result: any) => {
      if(result){
        this.event.eventId = result.eventId;
        this.event.name = result.name;
        this.event.createdAt = result.createdAt;
        this.event.completedDate = result.completedDate;
        this.event.eventRating.rating = result.eventRating;
        this.event.eventRating.eventId = result.eventId;
      }
      // this.event = result;
    });
  }

  cancel(): void {
    this.router.navigateByUrl("events");
  }

  edit(): void {
    this.apiService.updateEvent(this.event).subscribe(() => {
      alert("Event updated successfully!");
      this.router.navigateByUrl("events");
    });
  }

}
