using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReconstructItenary
{
    class Program
    {
        class Solution
        {
            Dictionary<string, List<string>> trips_;
            // ans (reversed)
            List<string> route_;

            List<string> FindItinerary(List<Tuple<string, string>> tickets)
            {
                route_.Clear();
                trips_.Clear();

                foreach (var item in tickets)
                {
                    trips_[item.Item1].Add(item.Item2);
                }
                

                foreach (var item in trips_)
                {
                    var dests = item.Value;
                    dests.Sort();
                }

                const string kStart = "JFK";

                visit(kStart);

                return route_;
            }

            // src -> {dst1, dest2, ..., destn}


            void visit(string src)
            {
                var dests = trips_[src];
                while (dests.Count != 0)
                {
                    // Get the smallest dest
                    var dest = dests.First();
                    // Remove the ticket
                    dests.RemoveAt(0);
                    // Visit dest
                    visit(dest);
                }
                // Add current node to the route
                route_.Add(src);
            }
    }
};

static void Main(string[] args)
        {
        }
    }
}
