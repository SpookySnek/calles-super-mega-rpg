﻿using System.Collections.ObjectModel;

namespace Engine.Models
{
    public class Player : LivingEntity
    {
        private string _characterClass;
        private int _experiencePoints;

        public string CharacterClass
        {
            get => _characterClass;
            set
            {
                _characterClass = value;
                OnPropertyChanged();
            }
        }
        public int ExperiencePoints
        {
            get => _experiencePoints;
            private set
            {
                _experiencePoints = value;
                OnPropertyChanged();
                SetLevelAndMaximumHitPoints();
            }
        }

        public ObservableCollection<QuestStatus> Quests { get; } = new ObservableCollection<QuestStatus>();

        public ObservableCollection<Recipe> Recipes { get; } = new ObservableCollection<Recipe>();

        public event EventHandler OnLeveledUp;

        public Player(string name, string characterClass, int experiencePoints,
            int maximumHitPoints, int currentHitPoints, int dexterity, int gold) :
            base(name, maximumHitPoints, currentHitPoints, dexterity, gold)
        {
            CharacterClass = characterClass;
            ExperiencePoints = experiencePoints;
        }

        public void AddExperience(int experiencePoints)
        {
            ExperiencePoints += experiencePoints;
        }

        public void LearnRecipe(Recipe recipe)
        {
            if (!Recipes.Any(r => r.ID == recipe.ID))
            {
                Recipes.Add(recipe);
            }
        }

        private void SetLevelAndMaximumHitPoints()
        {
            int originalLevel = Level;

            Level = (ExperiencePoints / 100) + 1;

            if (Level != originalLevel)
            {
                MaximumHitPoints = Level * 10;

                OnLeveledUp?.Invoke(this, System.EventArgs.Empty);
            }
        }
    }
}
