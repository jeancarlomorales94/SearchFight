using SearchFight.Domain;
using System.Collections;
using System.Collections.Generic;

namespace SearchFight.Test.Domain.Data
{
    public class TotalWinnerData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {"java", new List<SearchResult> {
                new SearchResult("Google",".net",1000),
                new SearchResult("Bing",".net",500),
                new SearchResult("Google","java",800),
                new SearchResult("Bing","java",1000),
            } };
            yield return new object[] {"java", new List<SearchResult> {
                new SearchResult("Google",".net",1000),
                new SearchResult("Bing",".net",500),
                new SearchResult("Google","java",1800),
                new SearchResult("Bing","java",1000),
            } };
            yield return new object[] {".net", new List<SearchResult> {
                new SearchResult("Google",".net",1000),
                new SearchResult("Bing",".net",1500),
                new SearchResult("Google","java",800),
                new SearchResult("Bing","java",1000),
            } };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
