namespace UniversityCompetition.Models.Subjects
{
    using System;
    using UniversityCompetition.Models.Contracts;

    public abstract class Subject : ISubject
    {
        private string name;

        protected Subject(int subjectId, string subjectName, double subjectRate)
        {
            Id = subjectId;
            Name = subjectName;
            Rate = subjectRate;
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

        public double Rate { get; private set; }
    }
}
