namespace MusicHub
{
    using System;
    using System.Text;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;

    public class StartUp
    {
        public static void Main()
        {
            MusicHubDbContext context =
            new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            //Test your solutions here
            Console.WriteLine(ExportAlbumsInfo(context,9));
            
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            StringBuilder sb = new StringBuilder();

            var albums = context.Producers
                .Where(p => p.Id == producerId)
                .Select(p => p.Albums)
                .Single()
                .OrderByDescending(a => a.Price);

            foreach (var a  in albums)
            {
                sb.AppendLine($"-AlbumName: {a.Name}");
                sb.AppendLine($"-ReleaseDate: {a.ReleaseDate.ToString("MM/dd/yyyy")}");
                sb.AppendLine($"-ProducerName: {a.Producer?.Name}");
                sb.AppendLine($"-Songs:");
                var songs = a.Songs
                    .OrderByDescending(s => s.Name)
                    .ThenBy(s => s.Writer)
                    .ToArray();
                for (int i = 0; i < songs.Length; i++)
                {
                    sb.AppendLine($"---{'#'}{i+1}");
                    sb.AppendLine($"---SongName: {songs[i].Name}");
                    sb.AppendLine($"---Price: {songs[i].Price:f2}");
                    sb.AppendLine($"---Writer: {songs[i].Writer.Name}");
                }
                sb.AppendLine($"-AlbumPrice: {a.Price:f2}");
            }
            return sb.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            throw new NotImplementedException();
        }
    }
}
