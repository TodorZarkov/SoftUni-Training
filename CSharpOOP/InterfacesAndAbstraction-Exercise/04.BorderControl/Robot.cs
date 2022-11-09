
namespace _04.BorderControl
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Robot : IIdentifiable
    {
        private string id;
        private string model;


        public Robot(string model, string id)
        {
            Id = id;
            Model = model;
        }


        public string Id
        {
            get { return id; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("The id cannot be empty.");
                }
                id = value;
            }
        }

        public string Model
        {
            get { return model; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("The model cannot be empty.");
                }
                model = value;
            }
        }
    }
}
