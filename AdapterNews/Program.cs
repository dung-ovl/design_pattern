using System;

// Inventory Service
class ManagerABC
{
    public News? GetMostLike(List<News> arrayNews)
    {
        double max = 0;
        int index = -1;
        for (int i = 0; i < arrayNews.Count; i++)
        {
            if (max < arrayNews[i].GetLikeIndex())
            {
                max = arrayNews[i].GetLikeIndex();
                index = i;
            }
        }
        if (index != 0)
            return arrayNews[index];
        return null;
    }
}

class News
{
    int like;
    int dislike;
    string type;
    DateTime postDate;

    public News(int like, int dislike, DateTime postDate)
    {
        this.like = like;
        this.dislike = dislike;
        this.postDate = postDate;
        type = "News";
    }

    public virtual double GetLikeIndex()
    {
        return (like - dislike) / ((like + dislike) * ((DateTime.Now - postDate).TotalDays));
    }

    public string GetType()
    {
        return type;
    }
}

class FbPost
{
    int like;
    int dislike;
    string type;
    DateTime postDate;
    int heart;
    int care;
    int haha;
    int wow;
    int sad;
    int angry;

    public FbPost(int like, int dislike, DateTime postDate, int heart, int care, int haha, int wow, int sad, int angry)
    {
        this.like = like;
        this.dislike = dislike;
        this.type = "FbPost";
        this.postDate = postDate;
        this.heart = heart;
        this.care = care;
        this.haha = haha;
        this.wow = wow;
        this.sad = sad;
        this.angry = angry;
    }

    public double GetLikeIndex()
    {
        return (like + heart * 2 + care*1.5 + haha*1.2 + wow - sad - angry * 3)/(like + heart + care + haha + wow + angry + sad) * (DateTime.Now - postDate).TotalDays * 1.2;
    }

    public string GetType()
    {
        return type;
    }

    public DateTime GetDate()
    {
        return postDate;
    }
}

class FbPostAdapter : News
{
    private FbPost fbPost;
    public FbPostAdapter(FbPost fbPost):base(0, 0, fbPost.GetDate())
    {
        this.fbPost = fbPost;
    }
    public override double GetLikeIndex()
    {
        return fbPost.GetLikeIndex();
    }
}


class Program
{
    static void Main(string[] args)
    {
        List<News> news = new List<News>();
        news.Add(new News(1, 2, new DateTime(2023, 5, 2)));
        news.Add(new News(2,3, new DateTime(2023, 6, 2)));

        FbPost fb = new FbPost(2, 3, new DateTime(2023, 7, 2), 3, 4, 5, 1, 2, 5);
        FbPost fb2 = new FbPost(2, 3, new DateTime(2023, 4, 2), 3, 4, 5, 4, 5, 5);

        FbPostAdapter fbPostAdapter = new FbPostAdapter(fb);
        news.Add(fbPostAdapter);

        FbPostAdapter fbPostAdapter1 = new FbPostAdapter(fb2);
        news.Add(fbPostAdapter1);

        ManagerABC managerABC = new ManagerABC();

        News? mostLike = managerABC.GetMostLike(news);
        if (mostLike != null)
            Console.WriteLine("The most like news is " + mostLike.GetType());
        Console.ReadKey();
    }
}
