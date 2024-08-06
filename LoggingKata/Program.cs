using System;
using System.Linq;
using System.IO;
using System.Runtime.ExceptionServices;
using GeoCoordinatePortable;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            // Objective: Find the two Taco Bells that are the farthest apart from one another.
            // Some of the TODO's are done for you to get you started. 

            logger.LogInfo("Log initialized");

            // Use File.ReadAllLines(path) to grab all the lines from your csv file. 
            // Optional: Log an error if you get 0 lines and a warning if you get 1 line
            var lines = File.ReadAllLines(csvPath);

            // This will display the first item in your lines array
            logger.LogInfo($"Lines: {lines[0]}");

            // Create a new instance of your TacoParser class
            var parser = new TacoParser();

            // Use the Select LINQ method to parse every line in lines collection
            var locations = lines.Select(parser.Parse).ToArray();


            // Complete the Parse method in TacoParser class first and then START BELOW ----------

            // TODO: Create two `ITrackable` variables with initial values of `null`. 
            // These will be used to store your two Taco Bells that are the farthest from each other.

            ITrackable tacoBellT = null;
            ITrackable tacoBellA = null;
            

            // TODO: Create a `double` variable to store the distance

            double distance = 0;

            //For and if loops to get the long/lat distance between tacobells
            {
                for (int t = 0; t < locations.Length; t++)
                {
                    var corT = new GeoCoordinate(locations[t].Location.Latitude, locations[t].Location.Longitude);

                    for (int a = 0; a < locations.Length; a++)
                    {
                        var corA = new GeoCoordinate(locations[a].Location.Latitude, locations[a].Location.Longitude);

                        var corDistance = corT.GetDistanceTo(corA);

                        if (corDistance > distance)
                        {
                            distance = corDistance;
                            tacoBellT = locations[t];
                            tacoBellA = locations[a];
                        }

                    }
                }
            }
            Console.WriteLine($"The distance between {tacoBellT.Name} and {tacoBellA.Name} is {distance} meters, which is roughly {Math.Round(distance * 0.00062)} Miles.");
        }
    }
}
  
     



            
        
                        
            

  
        

            
        
