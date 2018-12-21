namespace FlexRule.Samples
{
    public enum Gender
    {
        Male,
        Female
    }

    public class Person
    {
        public Person(string name, int age, Gender sex)
        {
            Name = name;
            Age = age;
            Sex = sex;
        }

        public bool Pregnant { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Gender Sex { get; set; }
    }
}
