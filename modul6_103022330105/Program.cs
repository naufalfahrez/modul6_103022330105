using System;
using System.Diagnostics;

class SayaTubeVideo {
    pint id;
    string title;
    int playCount;

    public SayaTubeVideo(string title)
    {
        Random random = new Random();
        this.id = random.Next(10000, 99999);
        this.title = title;
        this.playCount = 0;
    }

    public void IncreasePlayCount(int count)
    {
        if (count > 0)
        {
            this.playCount += count;
        }
        else
        {
            Console.WriteLine("Jumlah play count harus lebih besar dari 0.");
        }
    }

    public void PrintVideoDetails()
    {
        Console.WriteLine($"ID: {this.id}");
        Console.WriteLine($"Title: {this.title}");
        Console.WriteLine($"Play Count: {this.playCount}");
    }

    int GetPlayCount()
    {
        return playCount;
    }

    String GetTitle()
    {
        return title;
    }
}

class SayaTubeUser
{
    int id;
    List<SayaTubeVideo> uploadedVidoes;
    String Username;

    public SayaTubeUser(String Username) {
        if (String.IsNullOrEmpty(Username))
        {
            throw new ArgumentException("Username tidak boleh kosong!");
        }
        Random rand = new Random();
        this.id = rand.Next(10000, 99999);
        this.Username = Username;
        this.uploadedVidoes = new List<SayaTubeVideo>;
    }

    int GetTotalVideoCount()
    {
        int totalPlayCount = 0;
        for(int i = 0; i < uploadedVidoes.Count; i++)
        {
            totalPlayCount += uploadedVidoes[i].GetPlayCount();
        }
        return totalPlayCount;
    }

    void addVideo(SayaTubeVideo uploadedVidoes)
    {
        if(Video == null)
        {
            throw new ArgumentNullException("video kosong");
        }
        uploadedVidoes.Add(video);
    }

   void PrintAllVideoPlaycount()
    {
        Console.WriteLine($"User{Username}");
        for (int i = 0; i < uploadedVidoes.Count; i++)
        {
            Console.WriteLine($"Video {i+1} judul: {uploadedVidoes{i+1}.GetTitle()}");
        }
        Console.WriteLine("");
    }
}