import { Injectable } from '@angular/core';
import { Event } from '../models/event';
import { EventRating } from '../models/event-rating';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';


@Injectable({
  providedIn: 'root'
})
export class EventService {
  private url = "Event";

  constructor(private http: HttpClient) { }

  public getEvents(): Observable<Event[]> {
    return this.http.get<Event[]>(`${environment.apiUrl}/${this.url}`); 
  }
}
