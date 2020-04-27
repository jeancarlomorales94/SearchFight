# SearchFight
Application that queries search engines and compares how many results they return.

You can pass multiple parameters and quotation marks to allow searching for terms with spaces (e.g. searchfight.exe “c sharp”)

## How to use
```
C:\> SearchFight.Client.ConsoleApp.exe .net java
```
```
Loading results...
.net: Bing: 74400000 Google: 537000000
java: Bing: 79100000 Google: 7990000
Bing winner: java
Google winner: .net
Total Winner: .net

```

## Prerequisites
SearchFight implements **Google Custom Search JSON API** and **Bing Cognitive Services Search API**. You are going to need the following keys :
* Google API Key
* Google Search Engine ID
* Bing Cognitive Service API

[Get your Google API Key](https://developers.google.com/custom-search/v1/overview)

[Get your Bing API Key](https://azure.microsoft.com/en-us/try/cognitive-services/my-apis/?api=bing-web-search-api)

```
Google Custom Search JSON API has a limit of 100 search queries per day for free
```

```
Bing Cognitive Service API has a limit of 3 requests per second and 1000 requests per month
```

## Search Engines
SearchFight supports multiple search engines. You can add new ones but hey have to implement ISearchEngineService.
```
public interface ISearchEngineService
{
    string Name { get; }
    Task<long> GetTotalResultsAsync(string query);
}
```



