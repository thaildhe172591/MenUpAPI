using System;
using System.Collections.Generic;

namespace SkinShopAPI.Models;

public partial class SkinAnalysis
{
    public int AnalysisId { get; set; }

    public int? UserId { get; set; }

    public DateTime? AnalysisDate { get; set; }

    public string? SkinType { get; set; }

    public int? BrightnessLevel { get; set; }

    public int? AcneLevel { get; set; }

    public int? TextureScore { get; set; }

    public int? PoresVisibility { get; set; }

    public int? DarkSpotsLevel { get; set; }

    public string? AnalysisResult { get; set; }

    public virtual User? User { get; set; }
}
