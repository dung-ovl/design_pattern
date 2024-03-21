public interface Video
{
    void display();
}

public class RealVideo : Video
{

    private string _fileName;

    public RealVideo(string fileName)
    {
        _fileName = fileName;
        loadFromDisk(_fileName);
    }

    public void display()
    {
        Console.WriteLine("Displaying " + _fileName);
    }

    private void loadFromDisk(string fileName)
    {
        Console.WriteLine("Loading " + fileName);
    }
}

public class ProxyVideo : Video
{
    private RealVideo realVideo;
    private string fileName;

    public ProxyVideo(string fileName)
    {
        this.fileName = fileName;
    }
    public void display()
    {
        if (realVideo == null) // lazy loading
        {
            realVideo = new RealVideo(fileName);
        }
        realVideo.display();
    }
}


class Client
{
    static void Main(string[] args)
    {
        Video image = new ProxyVideo("Design Pattern.mp4");

        //video sẽ được load từ ổ đĩa
        image.display();
        Console.WriteLine("After loading first time\n");
        //video sẽ k tải lại từ ổ đĩa nữa
        image.display();
    }
}
