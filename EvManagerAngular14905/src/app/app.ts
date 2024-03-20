export interface Event {
    eventId: number;
    name: string;
    createdAt: Date;
    completedDate?: Date;
    ratingID: number;
    eventRating: EventRating;
}

export interface EventRating {
    ratingId: number;
    rating: number;
    eventId: number;
}
