import { Injectable } from '@angular/core';
import { EventRating } from '../models/event-rating';

@Injectable({
  providedIn: 'root'
})
export class EventService {

  constructor() { }

  public getEventRatings(): EventRating[] {
    let eventRating = new EventRating();
    eventRating.ratingId = 1;
    eventRating.rating = 5;  
    return [eventRating]; 
  }
}
