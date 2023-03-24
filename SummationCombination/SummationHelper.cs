using System.Data;
using System.Text;

namespace SummationCombination
{
    internal class SummationHelper
    {

        private List<int> _Summables = new List<int>();

        public SummationHelper() { 
            _Summables.AddRange(new int[] { 1, 1, 3, 4, 8 } );
        }
        public string GetSumItems(int sumValue) { 
            
            List<int> items = new List<int>();

            bool isCombinationFound = false;
            do {

                //First find if the actual number is already in the array
                if (_Summables.Contains(sumValue))
                {
                    items.Add(sumValue);
                    isCombinationFound = true;
                }
                else {
                    //Process Combination
                    items = GenerateCombinations(sumValue);
                    isCombinationFound = true;
                }

                if (isCombinationFound)
                    break;
            }
            while (true);


            var arranged = (from i in items
                           orderby i ascending
                           select i).ToList();
            StringBuilder sb = new StringBuilder();

            for (int t = 0; t < arranged.Count; t++) {
                sb.Append(arranged[t].ToString());
                if (t != arranged.Count - 1)
                    sb.Append(", ");
            }
            return sb.ToString();
        }

        private List<int> GenerateCombinations(int sumValue)
        {

            var combinations = new List<int>();
            bool isMatchFound = false;
            
            /* Solution 1
            int nextIndex = 0;

            var descOrder = from i in _Summables
                                        orderby i descending
                            select i;
            

            //Get Closest number
            foreach (var n in descOrder) {
                if (n < sumValue)
                    break;
                nextIndex += 1;
            }
            int total = 0;
            bool isCombinationFound = false;
            int currentIndexOf = 0;
            while (!isCombinationFound) {

                foreach (var t in descOrder) {

                    //if (currentIndexOf != nextIndex) { 
                    //    
                    //}
                    combinations.Add(t);
                    currentIndexOf += 1;
                    total = 0;
                    foreach (var tt in combinations)
                    {
                        total += tt;
                        if (total == sumValue)
                        {
                            isCombinationFound = true;
                            break;
                        }
                    }
                    if (isCombinationFound)
                        break;
                }
            }*/

            /* Solution 2
            //List<int> savedIndeces = new List<int>();
            //bool isCombinationFound = false;
            //Random rand = new Random();
            //while (!isCombinationFound) {

            //    int index = rand.Next(_Summables.Count - 1);
            //    if (!savedIndeces.Contains(index)) { 
            //        savedIndeces.Add(index);
            //        combinations.Add(_Summables[index]);

            //        int total = 0;
            //        foreach (int i in combinations)
            //        {
            //            total += i;
            //            if (total == sumValue) {
            //                isCombinationFound = true;
            //                break;
            //            }

            //        }
            //    }

            //    if(savedIndeces.Count == _Summables.Count)
            //        savedIndeces.Clear();
            //}*/

            var lowestToHighest = (from i in _Summables
                                  orderby i ascending
                                  select i).ToList();

            int nearestLowestValueIndex = 0;
            for ( var i = 0;i < _Summables.Count; i++)
            {
                if (_Summables[i] < sumValue)
                    nearestLowestValueIndex = i;
                else
                    break;
            }

            List<int> savedIndeces = new List<int>();
            while (!isMatchFound) { 
                
               Random rand = new Random();

                while (true) {
                    int val = rand.Next(0, 5);
                    if (!savedIndeces.Contains(val)) { 
                        savedIndeces.Add(val); 
                    }
                    if (savedIndeces.Count == _Summables.Count - 1)
                        break; 
                }
                int total = 0;
                combinations.Clear();
                foreach (var index in savedIndeces) {
                    combinations.Add(_Summables[index]);
                    total += _Summables[index];
                    if(total == sumValue)
                    { isMatchFound = true; break; }     
                }
                savedIndeces.Clear();                
            }

            return combinations;

        }
    }


}
