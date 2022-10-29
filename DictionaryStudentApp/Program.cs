namespace DictionaryStudentApp
{
    internal class Program
    {
        static IDictionary<int,Student> map = new Dictionary<int,Student>();
        static void Main(string[] args)
        {
            map.Add(1,new Student() { Id=1, Firstname="Alex", Lastname="Arg" });
            map.Add(2, new Student() { Id = 2, Firstname = "Geo", Lastname = "Theod" });
            map.Add(3, new Student() { Id = 3, Firstname = "Andreas", Lastname = "Argy" });

            map.Remove(1);

            map[2] = new Student() { Id = 2, Firstname = "Georgia", Lastname = "Theodorou" };

            

            if (map.ContainsKey(1))
            {
                Student studentOne = map[1];
            }

            Console.WriteLine("Size:" + map.Count);

            foreach (KeyValuePair<int,Student> kvp in map)
            {
                Console.WriteLine(kvp.Key + " " + kvp.Value);
            }

            foreach (Student student in map.Values)
            {
                Console.WriteLine(student);
            }

        }
    }
}