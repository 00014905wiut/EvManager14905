import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { APIService } from '../../api.service';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})
export class DetailsComponent implements OnInit {

  event: any = {
    eventId: 0,
    name: "",
    createdAt: "",
    completedDate: "",
    eventRating: 0.0
  };

  constructor(private apiService: APIService, private activatedRoute: ActivatedRoute,private router: Router) { }

  ngOnInit(): void {
    this.apiService.getAllEvents().subscribe((result) => {
      this.event = result;
      console.log(result);
      debugger
    });
  }

  edit(id: number){
    this.router.navigateByUrl('edit/'+ id);
  }

  delete(id: number){
    this.router.navigateByUrl('delete/'+ id);

  }
  create(){
    this.router.navigateByUrl('create');

  }
}

