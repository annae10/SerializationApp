using System;

public class Person
{
    public Int32 Id { get; set; }
    public Guid TransportId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public String[] CreditCardNumbers { get; set; }
    public int Age { get; set; }
    public String[] Phones { get; set; }
    public Int64 BirthDate { get; set; }
    public Double Salary { get; set; }
    public Boolean IsMarred { get; set; }
    public Gender Gender { get; set; }
    public Child[] Children { get; set; }
    public Person(int id, Guid transportId, string firstName, string lastName, string[] creditCardNumbers,
        int age, String[] phones, long birthDate, double salary, Boolean isMarred, Gender gender, Child[] children)
    {
        Id = Id;
        TransportId = transportId;
        FirstName = firstName;
        LastName = lastName;
        CreditCardNumbers = creditCardNumbers;
        Age = age;
        Phones = phones;
        BirthDate = birthDate;
        Salary = salary;
        IsMarred = isMarred;
        Gender = gender;
        Children = children;
    }
}
