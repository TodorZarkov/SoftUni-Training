namespace UniversityCompetition.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml.Linq;
    using UniversityCompetition.Models.Contracts;

    public class University : IUniversity
    {
        private string name;
        private string category;
        private int capacity;
        private ICollection<int> requiredSubjects;

        public University(int universityId, string universityName, string category, 
            int capacity, ICollection<int> requiredSubjects)
        {
            Id = universityId;
            Name = universityName;
            Category = category;
            Capacity = capacity;

            this.requiredSubjects = new List<int>(requiredSubjects);
        }

        public int Id { get; private set; }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }
                name = value;
            }
        }

        public string Category
        {
            get => category;
            private set
            {
                string[] categories = new string[] { "Technical", "Economical", "Humanity" };
                if (!categories.Any(c=>c==value))
                {
                    throw new ArgumentException($"University category {value} is not allowed in the application!");
                }
                category = value;
            }
        }

        public int Capacity
        {
            get => capacity;
            private set
            {
                if(value < 0)
                {
                    throw new ArgumentException("University capacity cannot be a negative value!");
                }
                capacity = value;
            }
        }

        public IReadOnlyCollection<int> RequiredSubjects => (IReadOnlyCollection<int>)requiredSubjects;
    }
}
