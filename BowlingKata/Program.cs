using static System.Console;

WriteLine("Hello World!");

var person = new Person("Firstname", "Lastname", "41");
WriteLine($"{person.Firstname} / {person.Lastname} / {person.age}");

var otherPerson = person with { Firstname = "Firstname2", age = "42" };
WriteLine($"{otherPerson.Firstname} / {otherPerson.Lastname} / {otherPerson.age}");

var (f, l, a) = person;
WriteLine($"{f} / {l} / {a}");

record Person(string Firstname, string Lastname, string age);

// data structure ==> Ref class
// record ==> immutable / value objects