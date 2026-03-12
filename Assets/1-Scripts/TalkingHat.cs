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
