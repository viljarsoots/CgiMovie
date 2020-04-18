﻿using SimpleMovie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleMovie.Repository
{
    public class MoviesListRepository
    {
        List<Movie> movies = new List<Movie>();
        List<Category> categories = new List<Category>();



        public void insertDummyData()
        {
            movies.Add(new Movie { id = 1, title = "The Shawshank Redemption", year = 1994, description = "Framed in the 1940s for the double murder of his wife and her lover, upstanding banker Andy Dufresne begins a new life at the Shawshank prison, where he puts his accounting skills to work for an amoral warden. During his long stretch in prison, Dufresne comes to be admired by the other inmates -- including an older prisoner named Red -- for his integrity and unquenchable sense of hope.", rating = "R", categoryId = { 1, 2 } });
            movies.Add(new Movie { id = 2, title = "The Godfather", year = 1972, description = "The story spans the years from 1945 to 1955 and chronicles the fictional Italian-American Corleone crime family. When organized crime family patriarch Vito Corleone barely survives an attempt on his life, his youngest son, Michael, steps in to take care of the would-be killers, launching a campaign of bloody revenge.", rating = "R", categoryId = { 1, 2 } });
            movies.Add(new Movie { id = 3, title = "The Godfather: Part II", year = 1974, description = "The continuing saga of the Corleone crime family tells the story of a young Vito Corleone growing up in Sicily and in 1910s New York; and follows Michael Corleone in the 1950s as he attempts to expand the family business into Las Vegas, Hollywood and Cuba", rating = "R", categoryId = { 1, 2 } });
            movies.Add(new Movie { id = 4, title = "The Dark Knight", year = 2008, description = "Batman raises the stakes in his war on crime. With the help of Lt. Jim Gordon and District Attorney Harvey Dent, Batman sets out to dismantle the remaining criminal organizations that plague the streets. The partnership proves to be effective, but they soon find themselves prey to a reign of chaos unleashed by a rising criminal mastermind known to the terrified citizens of Gotham as the Joker.", rating = "BG-13", categoryId = { 2, 3, 4, 5, 6, 7 } });
            movies.Add(new Movie { id = 5, title = "Schindler's List", year = 1993, description = "Told from the perspective of businessman Oskar Schindler who saved over a thousand Jewish lives from the Nazis while they worked as slaves in his factory. Schindler’s List is based on a true story, illustrated in black and white and controversially filmed in many original locations.", rating = "R", categoryId = { 1, 8, 9 } });
            movies.Add(new Movie { id = 6, title = "12 Angry Men", year = 1957, description = "12 Angry Men is the 1957 film debut for director Sidney Lumet. An interpretion from a Broadway show, this film is about 12 jurors who must decide whether an 18-year-old is guilty of killing his father.", rating = "G", categoryId = { 1, 10 } });
            movies.Add(new Movie { id = 7, title = "Pulp Fiction", year = 1994, description = " Pulp Fiction is a cult film by Director Quentin Tarantino with three interwoven plots with lots of violence, absurdity, and great music. The film is Tarantino’s most famous and the film that cemented his name and style in Hollywood.", rating = "R", categoryId = { 1, 2, 7, 11, } });
            movies.Add(new Movie { id = 8, title = "The Lord of the Rings: The Return of the King", year = 2003, description = "Aragorn is revealed as the heir to the ancient kings as he, Gandalf and the other members of the broken fellowship struggle to save Gondor from Sauron's forces. Meanwhile, Frodo and Sam bring the ring closer to the heart of Mordor, the dark lord's realm.", rating = "PG-13", categoryId = { 3 ,4 ,5 } });
            movies.Add(new Movie { id = 9, title = "The Good, the Bad and the Ugly", year = 1974, description = "A bounty hunting scam joins two men in an uneasy alliance against a third in a race to find a fortune in gold buried in a remote cemetery.This is the third Italian-Western film of a trilogy from director Sergio Leone who gives Western films a new (bloody) color.", rating = "R", categoryId = { 1, 3, 4, 12 } });
            movies.Add(new Movie { id = 10, title = "Fight Club", year = 1999, description = "A ticking-time-bomb insomniac and a slippery soap salesman channel primal male aggression into a shocking new form of therapy. Their concept catches on, with underground \"fight clubs\" forming in every town, until an eccentric gets in the way and ignites an out-of-control spiral toward oblivion.", rating = "R", categoryId = { 1, 2, 3, 7, 13 } });
            movies.Add(new Movie { id = 11, title = "The Lord of the Rings: The Fellowship of the Ring", year = 2001, description = "Young hobbit Frodo Baggins, after inheriting a mysterious ring from his uncle Bilbo, must leave his home in order to keep it from falling into the hands of its evil creator. Along the way, a fellowship is formed to protect the ringbearer and make sure that the ring arrives at its final destination: Mt. Doom, the only place where it can be destroyed.", rating = "BG-13", categoryId = { 1, 3, 4, 5, 6 } });
            movies.Add(new Movie { id = 12, title = "Star Wars: Episode V - The Empire Strikes Back", year = 1980, description = "The epic saga continues as Luke Skywalker, in hopes of defeating the evil Galactic Empire, learns the ways of the Jedi from aging master Yoda. But Darth Vader is more determined than ever to capture Luke. Meanwhile, rebel leader Princess Leia, cocky Han Solo, Chewbacca, and droids C-3PO and R2-D2 are thrown into various stages of capture, betrayal and despair.", rating = "BG", categoryId = { 3, 4, 5, 6, 14  } });
            movies.Add(new Movie { id = 13, title = "Forrest Gump", year = 1994, description = "A man with a low IQ has accomplished great things in his life and been present during significant historic events - in each case, far exceeding what anyone imagined he could do. Yet, despite all the things he has attained, his one true love eludes him. \"Forrest Gump\" is the story of a man who rose above his challenges, and who proved that determination, courage, and love are more important than ability.", rating = "BG-13", categoryId = { 1, 13, 15 } });
            movies.Add(new Movie { id = 14, title = "Inception", year = 2010, description = "Cobb, a skilled thief who commits corporate espionage by infiltrating the subconscious of his targets is offered a chance to regain his old life as payment for a task considered to be impossible: \"inception\", the implantation of another person's idea into a target's subconscious.", rating = "BG-13", categoryId = { 3, 4, 6, 7, 10 } });
            movies.Add(new Movie { id = 15, title = "The Lord of the Rings: The Two Towers", year = 2002, description = "Frodo and Sam are trekking to Mordor to destroy the One Ring of Power while Gimli, Legolas and Aragorn search for the orc-captured Merry and Pippin. All along, nefarious wizard Saruman awaits the Fellowship members at the Orthanc Tower in Isengard.", rating = "BG-13", categoryId = { 3, 4, 6, 7, 10 } });

            categories.Add(new Category { id = 1, name = "Drama" });
            categories.Add(new Category { id = 2, name = "Crime" });
            categories.Add(new Category { id = 3, name = "Action" });
            categories.Add(new Category { id = 4, name = "Adventure" });
            categories.Add(new Category { id = 5, name = "Fantacy" });
            categories.Add(new Category { id = 6, name = "Science Fiction" });
            categories.Add(new Category { id = 7, name = "Thriller" });
            categories.Add(new Category { id = 8, name = "History" });
            categories.Add(new Category { id = 9, name = "War" });
            categories.Add(new Category { id = 10, name = "Mystery" });
            categories.Add(new Category { id = 11, name = "Indie" });
            categories.Add(new Category { id = 12, name = "Western" });
            categories.Add(new Category { id = 13, name = "Comedy" });
            categories.Add(new Category { id = 14, name = "Family" });
            categories.Add(new Category { id = 15, name = "Romance" });

        }
    }
}