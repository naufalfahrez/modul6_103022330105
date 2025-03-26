using System;
using System.Diagnostics;
using System.Collections.Generic;

class SayaTubeVideo {
    private int id;
    private string title;
    private int playCount;

    public SayaTubeVideo(string title)
    {
        if (String.IsNullOrEmpty(title))
            throw new ArgumentNullException("Judul tidak boleh kosong");
        if (title.Length > 200)
            throw new ArgumentException("Judul tidak boleh lebih dari 200 karakter");
        Random random = new Random();
        this.id = random.Next(10000, 99999);
        this.title = title;
        this.playCount = 0;
    }

    public void IncreasePlayCount(int count)
    {
        if (count < 0)
            throw new ArgumentException("play count tidak boleh negatif!");
        if (count > 25000000)
            throw new ArgumentException("Maksimal penamabahan play count adalah  25.000.000");
        try
        {
            checked
            {
                playCount += count;
            }
        }
        catch (OverflowException)
        {
            Console.WriteLine("ERORR");
        }

    }

    public void PrintVideoDetails()
    {
        Console.WriteLine($"ID: {this.id}");
        Console.WriteLine($"Title: {this.title}");
        Console.WriteLine($"Play Count: {this.playCount}");
    }

    public int GetPlayCount()
    {
        return playCount;
    }

    public String GetTitle()
    {
        return title;
    }
}

class SayaTubeUser
{
    private int id;
    private List<SayaTubeVideo> uploadedVidoes;
    private String Username;

    public SayaTubeUser(String Username) {
        if (String.IsNullOrEmpty(Username))
            throw new ArgumentNullException("Username tidak boleh kosong!");
        if (Username.Length > 100)
           throw new ArgumentException("Username tidak boleh lebih dari 100 karakter");

        Random rand = new Random();
        this.id = rand.Next(10000, 99999);
        this.Username = Username;
        this.uploadedVidoes = new List<SayaTubeVideo>();
    }

    public int GetTotalVideoCount()
    {
        int totalPlayCount = 0;
        for(int i = 0; i < uploadedVidoes.Count; i++)
        {
            totalPlayCount += uploadedVidoes[i].GetPlayCount();
        }
        return totalPlayCount;
    }

    public void addVideo(SayaTubeVideo video)
    {
        if(video == null)
            throw new ArgumentNullException("video kosong");
        if (video.GetPlayCount() > int.MaxValue)
            throw new ArgumentException("play count melebihi batas");
        uploadedVidoes.Add(video);
    }

   public void PrintAllVideoPlaycount()
    {
        Console.WriteLine($"User{Username}");
        for (int i = 0; i < uploadedVidoes.Count; i++)
        {
            Console.WriteLine($"Video {i+1} judul: {uploadedVidoes[i].GetTitle}");
        }
        Console.WriteLine("");
    }
}

class Program
{
    static void Main()
    {
        try
        {
            SayaTubeUser user= new SayaTubeUser("Naufal");
            string[] filmTitles = { "interstellar", "the Dark Knight", "Joker", "Alien", "Avangers : end game", "Shark", "The nun", "Fast & forious", "Substance", "Parasite" };
            for (int i = 0; i < filmTitles.Length; i++)
            {
                SayaTubeVideo video = new SayaTubeVideo($"Review film {filmTitles[i]} oleh Naufal");
                user.addVideo(video);
            }
            user.PrintAllVideoPlaycount();
            try
            {
                Console.WriteLine("\nuji overflow play count");
                SayaTubeVideo testvideo = new SayaTubeVideo("video test overflow");
                for (int i = 0; i < 10; i++) {
                    testvideo.IncreasePlayCount(25000000);
                }
                testvideo.PrintVideoDetails();
            }
            catch (Exception e)
            {
                Console.WriteLine($"exception {e.Message}");
            }
            Console.WriteLine($"total jumlah play dari semua video: {user.GetTotalVideoCount}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"execption{e.Message}");
        }
    }
}