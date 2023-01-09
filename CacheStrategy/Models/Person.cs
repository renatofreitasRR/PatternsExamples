namespace CacheStrategy.Models
{
    public class Person
    {
        public Person(string name)
        {
            this.Name = name;
            this.Id = Guid.NewGuid();
            this.BirthDate = DateTime.Now;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
