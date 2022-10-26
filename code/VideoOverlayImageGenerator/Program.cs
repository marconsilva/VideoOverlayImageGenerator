using System.Drawing;

// See https://aka.ms/new-console-template for more information

for(int i=1; i<6; i++)
{
    Console.WriteLine($"Generating Cover {i}!");

    Bitmap bmp = new Bitmap(1920, 1080);
    Graphics g = Graphics.FromImage(bmp);

    Image bruno_cover = Image.FromFile($"Bruno\\bruno_0{i}_cover.png");
    Image miguel_cover = Image.FromFile($"Miguel\\miguel_0{i}_cover.png");
    Image daniel_cover = Image.FromFile($"Daniel\\daniel_0{i}_cover.png");
    Image marco_cover = Image.FromFile($"Marco\\marco_0{i}_cover.png");

    bruno_cover = SmartImageResizer.ResizeImage(bruno_cover);
    miguel_cover = SmartImageResizer.ResizeImage(miguel_cover);
    daniel_cover = SmartImageResizer.ResizeImage(daniel_cover);
    marco_cover = SmartImageResizer.ResizeImage(marco_cover);

    g.Clear(Color.Transparent);
    g.DrawImage(bruno_cover, new Point(1920-bruno_cover.Size.Width,(1080/2)-bruno_cover.Size.Height-5));
    g.Flush();
    bmp.Save($"cover_{i}_1.png", System.Drawing.Imaging.ImageFormat.Png);


    g.DrawImage(daniel_cover, new Point((1920/2)-daniel_cover.Size.Width-5,1080-daniel_cover.Size.Height));
    g.Flush();
    bmp.Save($"cover_{i}_2.png", System.Drawing.Imaging.ImageFormat.Png);


    g.DrawImage(miguel_cover, new Point(1920-miguel_cover.Size.Width,1080-miguel_cover.Size.Height));
    g.Flush();
    bmp.Save($"cover_{i}_3.png", System.Drawing.Imaging.ImageFormat.Png);

    g.DrawImage(marco_cover, new Point((1920/2)-marco_cover.Size.Width-5,(1080/2)-marco_cover.Size.Height-5));
    g.Flush();
    bmp.Save($"cover_{i}_4.png", System.Drawing.Imaging.ImageFormat.Png);
}


public class SmartImageResizer
{

    private static int MAX_HEIGHT = 1080/4;
    private static int MAX_WIDGHT = 1920/8;

    public static Image ResizeImage(Image image)
    {
        double resizePercentage = 1;
        int newHeight, newWidth = 0;

        if(image.Size.Width > image.Size.Height) {
            //Horizontal Image
            resizePercentage = (double)MAX_WIDGHT/image.Size.Width;
            
        }
        else if(image.Size.Width == image.Size.Height) {
            //Square Image
            resizePercentage = (double)MAX_WIDGHT/image.Size.Width;
        }
        else {
            //Vertical Image
            resizePercentage = (double)MAX_HEIGHT/image.Size.Height;
        }

        newHeight = (int) (image.Size.Height*resizePercentage);
        newWidth = (int) (image.Size.Width*resizePercentage);

        return (new Bitmap(image, new Size(newWidth, newHeight)));
    }
}

