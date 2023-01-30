namespace Engine.Models
{
    public class Monster : LivingEntity
    {
        public string ImageName { get; }
        public int RewardExperiencePoints { get; }
        public Monster(string name, string imageName,
            int maximumHitPoints, int currentHitPoints,
            int rewardExperiencePoints, int gold) :
            base(name, maximumHitPoints, currentHitPoints, gold)
        {
            ImageName = string.Format($"pack://application:,,,/Engine;component/Images/Monsters/{imageName}");
            RewardExperiencePoints = rewardExperiencePoints;
        }
    }
}
