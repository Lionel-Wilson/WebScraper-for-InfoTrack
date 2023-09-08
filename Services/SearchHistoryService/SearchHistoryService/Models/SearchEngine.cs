using System;
using System.Collections.Generic;

namespace SearchHistoryService.Models;

public partial class SearchEngine
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string BaseUrl { get; set; } = null!;

    public string? RegexPattern { get; set; }

    public string? HeaderValue { get; set; }


}
