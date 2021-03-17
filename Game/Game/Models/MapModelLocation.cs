namespace Game.Models
{
    /// <summary>
    /// Represent the Map
    /// 
    /// The Cordinates
    /// What is at that location
    /// 
    /// </summary>
    public class MapModelLocation
    {
        // The X, which is R in Grid
        public int Row;

        // They Y, which is Column in Grid
        public int Column;

        // The Player, Character or Unknown for blank
        public PlayerInfoModel Player = new PlayerInfoModel();

        // If IsSelected, used for targeting
        public bool IsSelectedTarget = false;
    }
}
