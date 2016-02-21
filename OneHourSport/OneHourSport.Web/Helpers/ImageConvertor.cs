namespace OneHourSport.Web.Helpers
{
    using System.IO;
    using System.Linq;
    using System.Web;

    using OneHourSport.Models;
    
    public class ImageConvertor
    {
        public Picture ExtractPicture(HttpPostedFileBase postedFile)
        {
            Picture image = null;

            using (var memory = new MemoryStream())
            {
                postedFile.InputStream.CopyTo(memory);
                var content = memory.GetBuffer();

                image = new Picture
                {
                    Content = content,
                    FileExtension = postedFile.FileName.Split(new[] { '.' }).Last()
                };
            }

            return image;
        }
    }
}