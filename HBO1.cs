using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{

    /*
     1. in a BST find closet number 
     [1,2 3, 8, 10] n = 4 
     num =
    
    LRU cache 
    [1, 2,1, 3]
     

    public static bool evalExpression(string expr, Diction)
    {
        if (expr == null || expr.Length == 0)
        {
            return false;
        }

        if (expr.Length == 1)
        {
            return expr == "t";
        }
        else
        {
            var operator = expr[0];
            if (operator == '!') // !(t)
        {
                var subExpr = expr.Substring(2)
            subExpr = subExpr.Substring(0, subExpr.Length - 2);
                return !(evalExpression(subExpr));
            }else
            {
                // t 
                // f 
                // !(t),!(f))
                // |(!(t),!(f))
                // |(|(t,f),!(f)) => |(|(t,f),f),!(f), 
                // &(t,f)
                var subExpr = expr.Substring(2)
                subExpr = subExpr.Substring(0, subExpr.Length - 2);
                var index = subExpr.IndexOf(','));
                var operand1 = evalExpression(index.Substring(0, index));
                var operand2 = evalExpression(subExpr.Substring(index + 1));
                return operator == '&' ? operand1 && operand2 : operand1 || operand2;
            }
        }

    }



    Design a weather api.The API should allow users to search for weather forecasts based on location.Addditionally users should be able to search for past weather forecasts based on location.


  forcast "redmond" -> no of days - 7 days

  client: subsctionKey



  get:/GetWeather/citySuggestions? prefix ={ red..} : min char 3 
[
  {
   city,
   zipcodes:[


   ]
},
  {
    city, 
   zipcodes:[


   ]
  },
  {
    city, 
   zipcodes:[


   ]
  }
]

get: GetWeather / City /{ CityName}? days = { days } 0-7
[
 {
    city:redmond
    day:day1
    high:
    low:
    percipatationChace:
    OverCast:
    TTL:
 },
 {
city: redmond
 day:day2
 high:
    low:
percipatationChace:
OverCast:
TTL:
 }
....
]


historical API "redmond" -> 7 days 

Source 
: external sources 1
: external sources 1

1. highly changing data - frequency  1hr  
2. TTL -> 15 minutes 
3. RED..

Weather model 
{
    place:redmond
    day:
    high:
    low:
    percipatationChace:
    OverCast:
}

{
    source id,
    url
frequency
}


source model: 
{
    lat / long:
  Weather model:{ }
}

place
{
    placeId, 
  City

}



}
    */

    [1, 2, 3,1 ,5 ,2 ,3 ,4,5,6,6,7]
    
    top K 



    public class IDPool // 
    {
        PriorityQueue
        int index = 1;
        HashSet<int> free = new HashSet<int>();

        public int acquire()
        {
            return free.Count > 0 ? free : index++;
        }

        public void release(int id)
        {
            if (free.Contains(id))
            { 
                
            }
        }
    }
}
