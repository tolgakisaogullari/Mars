using System.ComponentModel.DataAnnotations;

namespace Mars
{
    public enum Direction
    {
        [Display(Name = "West")]
        West = 0,

        [Display(Name = "North")]
        North = 90,

        [Display(Name = "East")]
        East = 180,

        [Display(Name = "South")]
        South = 270
    }
}