using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create videos
        List<Video> videos = new List<Video>();

        Video video1 = new Video("C# Tutorial for Beginners", "Programming Master", 1200);
        Video video2 = new Video("Learn Python in 1 Hour", "Code Wizard", 3600);
        Video video3 = new Video("Web Development Fundamentals", "Web Dev Pro", 2400);
        Video video4 = new Video("Data Structures Explained", "Algorithms Expert", 1800);

        // Add comments to video1
        video1.AddComment(new Comment("John Doe", "Great tutorial! Very helpful for beginners."));
        video1.AddComment(new Comment("Jane Smith", "I finally understand classes, thank you!"));
        video1.AddComment(new Comment("Mike Johnson", "Clear and concise explanation."));

        // Add comments to video2
        video2.AddComment(new Comment("Sarah Wilson", "Python is so much easier after watching this."));
        video2.AddComment(new Comment("Tom Brown", "The examples were perfect for learning."));
        video2.AddComment(new Comment("Emily Davis", "Wish I found this video sooner!"));
        video2.AddComment(new Comment("Alex Lee", "Excellent pacing and content."));

        // Add comments to video3
        video3.AddComment(new Comment("Chris Taylor", "Web development made simple."));
        video3.AddComment(new Comment("Jessica Miller", "HTML and CSS basics well explained."));
        video3.AddComment(new Comment("David Anderson", "Perfect for absolute beginners."));

        // Add comments to video4
        video4.AddComment(new Comment("Amanda White", "Data structures finally make sense!"));
        video4.AddComment(new Comment("Robert Green", "Great visual explanations."));
        video4.AddComment(new Comment("Lisa Harris", "Helped me prepare for my interview."));
        video4.AddComment(new Comment("Kevin Martin", "Complex topics made easy to understand."));

        // Add videos to list
        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);
        videos.Add(video4);

        // Display all videos and their comments
        Console.WriteLine("YouTube Videos and Comments");
        Console.WriteLine("============================");
        Console.WriteLine();

        foreach (Video video in videos)
        {
            video.DisplayVideoInfo();
        }
    }
}