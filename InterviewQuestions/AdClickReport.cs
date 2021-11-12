using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp.InterviewQuestions
{
    public class AdClickReport
    {
        /*
          
                [
                    "122.121.0.1,2016-11-03 11:41:19,Buy wool coats for your pets",
                    "96.3.199.11,2016-10-15 20:18:31,2017 Pet Mittens",
                    "122.121.0.250,2016-11-01 06:13:13,The Best Hollywood Coats",
                    "82.1.106.8,2016-11-12 23:05:14,Buy wool coats for your pets",
                    "92.130.6.144,2017-01-01 03:18:55,Buy wool coats for your pets",
                    "122.121.0.155,2017-01-01 03:18:55,Buy wool coats for your pets",
                    "92.130.6.145,2017-01-01 03:18:55,2017 Pet Mittens",
            ]

        ,
        "92.130.6.145,2017 Pet Mittens"
         */
        public static void Tests()
        {
            var purchasedUserIds = new List<string>() { "3123122444", "234111110", "8321125440", "99911063" };
            var ad_clicks = new List<Tuple<string, string>>()
            {
                new Tuple<string, string>("122.121.0.155","Buy wool coats for your pets"),
                new Tuple<string, string>("122.121.0.156","Buy wool coats for your pets"),
                new Tuple<string, string>("92.130.6.145", "Pet Mittens"),
            };
            var allUserIps = new List<Tuple<string, string>>()
            {
                new Tuple<string, string>("2339985511","122.121.0.155"),
                new Tuple<string, string>("234111110","122.121.0.1"),
            };


            var userIdsWithProduct = new List<Tuple<string, string, string, bool>>();
            foreach (var adClick in ad_clicks)
            {
                var user = allUserIps.Where(x => x.Item2 == adClick.Item1).FirstOrDefault();
                var purchased = purchasedUserIds.Contains(user.Item1);
                userIdsWithProduct.Add(new Tuple<string, string, string, bool>(adClick.Item1, adClick.Item2, user.Item1, purchased));
            }

            var products = userIdsWithProduct.Select(x => x.Item2).Distinct();

        }
    }
}
