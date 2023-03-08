namespace MusicHub
{
    using System;
    using System.Text;
    using Castle.Core.Internal;
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

            //Console.WriteLine(ExportSongsAboveDuration(context, 4));

        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            StringBuilder sb = new StringBuilder();

            var albums = context.Albums
                .Where(a => a.ProducerId.HasValue && a.ProducerId.Value == producerId)
                .Select(a => new
                {
                    a.Name,
                    ReleaseDate = a.ReleaseDate.ToString("MM/dd/yyyy"),
                    ProducerName = a.Producer.Name,
                    Songs = a.Songs.Select(s => new
                    {
                        s.Name,
                        Price = s.Price.ToString("f2"),
                        WriterName = s.Writer.Name
                    })
                        .OrderByDescending(s => s.Name)
                        .ThenBy(s => s.WriterName)
                        .ToList(),
                    Price = a.Price,
                    StringPrice = a.Price.ToString("f2")
                })
                .ToArray()
                .OrderByDescending(a => a.Price);

            foreach (var a in albums)
            {
                sb
                    .AppendLine($"-AlbumName: {a.Name}")
                    .AppendLine($"-ReleaseDate: {a.ReleaseDate}")
                    .AppendLine($"-ProducerName: {a.ProducerName}")
                    .AppendLine($"-Songs:");
                int songNumber = 1;
                foreach (var s in a.Songs)
                {
                    sb
                        .AppendLine($"---{'#'}{songNumber}")
                        .AppendLine($"---SongName: {s.Name}")
                        .AppendLine($"---Price: {s.Price}")
                        .AppendLine($"---Writer: {s.WriterName}");
                    songNumber++;
                }
                sb.AppendLine($"-AlbumPrice: {a.StringPrice}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var songs = context.Songs
                .AsNoTracking()
                .Where(s => s.Duration > new TimeSpan(0, 0, duration))
                .OrderBy(s => s.Name)
                .ThenBy(s => s.Writer.Name)
                .Select(s => new
                {
                    s.Name,
                    PerformersFirstNames = s.SongPerformers.Select(p => p.Performer.FirstName),
                    PerformersLastNames = s.SongPerformers.Select(p => p.Performer.LastName),
                    WriterName = s.Writer.Name,
                    ProducerName = s.Album.Producer.Name,
                    s.Duration

                })
                .ToArray();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < songs.Length; i++)
            {
                sb.AppendLine($"-Song {"#"}{i + 1}");
                sb.AppendLine($"---SongName: {songs[i].Name}");
                sb.AppendLine($"---Writer: {songs[i].WriterName}");
                if (!songs[i].PerformersFirstNames.IsNullOrEmpty())
                {
                    string[] firstNames = songs[i].PerformersFirstNames.ToArray();
                    string[] lastNames = songs[i].PerformersLastNames.ToArray();
                    string[] names = new string[firstNames.Length];
                    for (int j = 0; j < firstNames.Length; j++)
                    {
                        names[j] = $"{firstNames[j]} {lastNames[j]}";
                    }
                    var performersNames = names.OrderBy(n => n);
                    foreach (var n in performersNames)
                    {
                        sb.AppendLine($"---Performer: {n}");
                    }
                }
                sb.AppendLine($"---AlbumProducer: {songs[i].ProducerName}");
                sb.AppendLine($"---Duration: {songs[i].Duration.ToString("c")}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
