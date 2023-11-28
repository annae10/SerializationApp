using System.Text.Json;
using SerializeApp;

//1. Creating collection
List<Person> persons = new List<Person>();

JsonSerializerOptions options = new JsonSerializerOptions
{
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
};
const long max_date = -568080000; //01.01.1952 

    Random random = new Random();
    for (int i = 0; i < 10000; i++)
    {

        Guid transportId = Guid.NewGuid();

        int personName = random.Next(1, 10);
        FirstName name = (FirstName)Enum.GetValues(typeof(FirstName)).GetValue(personName);
        String firstName = name.ToString();

        int personSurname = random.Next(1, 10);
        LastName surname = (LastName)Enum.GetValues(typeof(LastName)).GetValue(personSurname);
        String lastName = surname.ToString();

        int countCards = random.Next(2, 5);
        String[] creditCardNumbers = new String[countCards];
        for (int j = 0; j < countCards; j++)
        {
            String numCard = "";
            for (int k = 0; k < 16; k++)
            {
                int numDigit = random.Next(0, 9);
                numCard += numDigit.ToString();
            }
            creditCardNumbers[j] = numCard;
        }

        int age = random.Next(20, 100);

        int[] CodeNumberPhone = { 910, 915, 916, 917, 967, 968, 969, 980, 
            983, 986, 929, 930, 931, 932, 936, 937, 958, 999, 900, 901 };
        int countPhones = random.Next(1, 5);
        String[] phones = new String[countPhones];
        for (int j = 0; j < countPhones; j++)
        {
            String numPhone = "+7";
            int numCodePhone = random.Next(0, 19);
            numPhone += CodeNumberPhone[numCodePhone].ToString();
            for (int k = 0; k < 7; k++)
            {
                int numDigit = random.Next(0, 9);
                numPhone += numDigit.ToString();
            }
            phones[j] = numPhone;
        }

        long birthDate = random.Next(-536457600, 1041379200); //from 1953 to 2003

        double salary = (Double)random.Next(30000, 100000);

        int is_marred = random.Next(0, 1);
        Boolean isMarred = (is_marred == 0 ? false : true);

        int gen = random.Next(1, 2);
        Enums gender = (Enums)Enum.GetValues(typeof(Enums)).GetValue(gen);

        int countChildrens1 = random.Next(1, 5);
        Child[] children = new Child[10];
        for (int j = 0; j < children.Length; j++)
        {
            if (j < countChildrens1)
            {

                int childName = random.Next(1, 10);
                FirstName child_name = (FirstName)Enum.GetValues(typeof(FirstName)).GetValue(childName);
                String childFirstName = child_name.ToString();

                int childSurName = random.Next(1, 10);
                LastName child_surname = (LastName)Enum.GetValues(typeof(LastName)).GetValue(childSurName);
                String childLastName = child_surname.ToString();

                long childBirthDate = random.Next(0, 1701043200); //from 1970 to 2023

                int genderChild = random.Next(1, 2);
                Enums genChild = (Enums)Enum.GetValues(typeof(Enums)).GetValue(genderChild);

                children[j] = new Child(j, childFirstName, childLastName, childBirthDate, genChild);
            }
            else { children[j] = new Child(j, "", "", max_date, Enums.Male); }
        }
        Person tom = new Person(i, transportId, firstName, lastName, creditCardNumbers, age, phones, birthDate, salary, isMarred, gender, children);
        persons.Add(tom);
    }


//2-3. Serialyzing to JSON format, writing result to file
using (FileStream fs = new FileStream("Persons.json", FileMode.OpenOrCreate))
{
    await JsonSerializer.SerializeAsync<List<Person>>(fs, persons, options);
}

//4. Clearing in the memory collection
    persons.Clear();
//5. Reading objects from file
using (FileStream fs = new FileStream("Persons.json", FileMode.OpenOrCreate))
{
    List<Person>? persons_des = await JsonSerializer.DeserializeAsync<List<Person>>(fs, options);
    int count_credit_cards = 0;
    int count_childs = 0;
    long age_childs = 0;
    foreach (var person in persons_des)
    {
        count_credit_cards += person.CreditCardNumbers.Length;
        foreach (var child in person.Children)
        {
            if (child.BirthDate != max_date)
            {
                count_childs++;
                age_childs += (child.BirthDate / 31536000);
            }
        }
    }

    //6. Displaying in console data
    Console.WriteLine($"Persons count: {persons_des.Count} ");
    Console.WriteLine($"Count credit cards: {count_credit_cards} ");
    Console.WriteLine($"Average value of child age: {age_childs / count_childs} ");
}
