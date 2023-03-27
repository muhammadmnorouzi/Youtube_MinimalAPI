namespace MinimalAPI;

public static class FakeDB
{
    private static List<Person> People = new List<Person>()
    {
        new Person(Id: 1 , Name: "Jack" , Age: 36),
        new Person(Id: 2 , Name: "Suzan" , Age: 51),
        new Person(Id: 3 , Name: "Jane" , Age: 13),
        new Person(Id: 4 , Name: "Tyler" , Age: 40),
    };

    public static Person? Get(int id) => People.FirstOrDefault(p => p.Id == id);
    public static IEnumerable<Person> GetPeople() => People;
    public static void Delete(int id) => People = People.Where(p => p.Id != id).ToList();

    public static Person? Update(Person person)
    {
        People = People.Select(p =>
            {
                if (p.Id == person.Id)
                {
                    p = p with { Name = person.Name, Age = person.Age };
                }
                return p;
            }).ToList();

        return person;
    }

    public static Person Add(Person person)
    {
        People.Add(person);

        return person;
    }
}