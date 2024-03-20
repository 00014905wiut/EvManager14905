import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class APIService {
  constructor(private http: HttpClient) { }

  getAllEvents() {
    return this.http.get<Event[]>('https://localhost:7062/api/Event');
  }

  getEventById(id: number) {
    return this.http.get<Event>(`https://localhost:7062/api/Event/${id}`);
  }

  createEvent(event: any) {
    return this.http.post<Event>('https://localhost:7062/api/Event', event);
  }

  updateEvent(event: any) {
    return this.http.put<Event>('https://localhost:7062/api/Event/' + event.eventId, event);
  }


  deleteEvent(id: number) {
    return this.http.delete(`https://localhost:7062/api/Event/${id}`);
  }
}
