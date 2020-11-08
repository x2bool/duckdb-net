using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

namespace DuckDb
{
    /// <summary>
    /// TODO: implement connection string builder properly
    /// </summary>
    public class DuckDbConnectionStringBuilder : DbConnectionStringBuilder
    {
        public string File { get; set; }
        
        public string InMemory { get; set; }

        public override string ToString()
        {
            if (InMemory != null)
            {
                return $"InMemory={InMemory}";
            }

            if (File != null)
            {
                return $"File={File};";
            }

            return "";
        }

        public static DuckDbConnectionStringBuilder Parse(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                return new DuckDbConnectionStringBuilder();
            }
            
            var pairs = connectionString.Split(';').Select(param =>
            {
                var keyVal = param.Split('=');
                return (keyVal[0].ToLowerInvariant(), keyVal[1]);
            }).ToDictionary(pair => pair.Item1, pair => pair.Item2);
            
            var builder = new DuckDbConnectionStringBuilder();

            if (pairs.TryGetValue("inmemory", out var inMemory))
            {
                builder.InMemory = inMemory;
            }

            if (pairs.TryGetValue("file", out var file))
            {
                builder.File = file;
            }
            
            return builder;
        }
    }
}