namespace scrap_depot.Models;

public static class ScrapData
{
    public static List<Scrap> All { get; } = new()
    {
        new Scrap{Id = 1, Name = "Big Bolt", Description = "A large metal bolt.", Credits = 25, Weight = 19, Depositied = 0},
        new Scrap{Id = 2, Name = "Large Axel", Description = "A large geared axle made of metal.", Credits = 46, Weight = 16, Depositied = 0},
        new Scrap{Id = 3, Name = "Flask", Description = "A flat-bottomed round glass flask.", Credits = 31, Weight = 16, Depositied = 0},
        new Scrap{Id = 4, Name = "Stop Sign", Description = "A detached, octaganal sign reading 'STOP'", Credits = 36, Weight = 29, Depositied = 0},
        new Scrap{Id = 5, Name = "Rubber Ducky", Description = "A yellow rubber duck.", Credits = 61, Weight = 0, Depositied = 0},
    };
}