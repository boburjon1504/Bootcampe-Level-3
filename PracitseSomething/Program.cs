using System.Threading.Channels;
using Bogus;
using PracitseSomething;

var myList = new MyList<User>();

var fake = new Faker<User>()
    .RuleFor(u => u.FirstName, fk => fk.Person.FirstName)
    .UseSeed(1);

var users = fake.Generate(100);




myList.AddRange(users);


var user = myList[10].FirstName;
Console.WriteLine(myList[user]);
