﻿namespace WebsiteMovies.Models
{
    public class MovieActor
    {
        public int ActorId { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public Actor Actor { get; set; }
    }
}
