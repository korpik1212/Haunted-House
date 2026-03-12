using System;
using System.Collections.Generic;
using UnityEngine;

public enum quoteType
{
    NOTSCARED,
    SCARED,
    VERYSCARED,
    REGULAR
}
public class TalkingHat : MonoBehaviour
{
    public List<QuoteManager> familyQuotes;

    public String getVeryScaredQuote(Human h)
    {
        String quote = "";
        foreach (QuoteManager q in familyQuotes)
        {
            if (q.human == h)
            {
                foreach (Quote q2 in q.quotes)
                {
                    if (q2.type == quoteType.VERYSCARED)
                    {
                        quote = q2.quote;
                    }
                }
            }
        }
        return quote;
    }

    public String getScaredQuote(Human h)
    {
        String quote = "";
        foreach (QuoteManager q in familyQuotes)
        {
            if (q.human == h)
            {
                foreach (Quote q2 in q.quotes)
                {
                    if (q2.type == quoteType.SCARED)
                    {
                        quote = q2.quote;
                    }
                }
            }
        }
        return quote;
    }

    public String getNotScaredQuote(Human h)
    {
        String quote = "";
        foreach (QuoteManager q in familyQuotes)
        {
            if (q.human == h)
            {
                foreach (Quote q2 in q.quotes)
                {
                    if (q2.type == quoteType.NOTSCARED)
                    {
                        quote = q2.quote;
                    }
                }
            }
        }
        return quote;
    }
    
    public String getRegularQuote(Human h)
    {
        String quote = "";
        foreach (QuoteManager q in familyQuotes)
        {
            if (q.human == h)
            {
                foreach (Quote q2 in q.quotes)
                {
                    if (q2.type == quoteType.REGULAR)
                    {
                        quote = q2.quote;
                    }
                }
            }
        }
        return quote;
    }
}
[Serializable]
public class QuoteManager
{
    public List<Quote> quotes;
    public Human human;
}
[Serializable]
public class Quote
{
    public String quote;
    public quoteType type;
}
