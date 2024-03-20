import { EventRating } from './event-rating'

export class Event {
    eventId?: number;
    name = "";
    createdAt?:Date ;
    eventRating?: EventRating;
  }
