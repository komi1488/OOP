using System;
using System.Collections.Generic;

namespace ZooLab {
  abstract class Animal {
    public string Name { get; set; }
    public int Age { get; set; }
    public string Habitat { get; set; }
    public string FoodType { get; set; }

    protected Animal(string name, int age, string habitat, string foodType) {
      Name = name;
      Age = age;
      Habitat = habitat;
      FoodType = foodType;
    }

    public virtual string GetInfo() {
      return $"Name: {Name}, Age: {Age}, Habitat: {Habitat}, Food Type: {FoodType}";
    }
  }

  class Mammal : Animal {
    public bool HasFur { get; set; }
    public Mammal(string name, int age, string habitat, string foodType, bool hasFur) : base(name, age, habitat, foodType) {

      HasFur = hasFur;
    }

    public override string GetInfo() {
      return base.GetInfo() + $", Type: Mammal, Has Fur: {(HasFur ? "Yes" : "No")}";
    }
  }

  class AnimalManager {
    private static AnimalManager instance;
    private List<Animal> animals = new List<Animal>();

    private AnimalManager() { }

    public static AnimalManager Instance {
      get {
        if (instance == null)
          instance = new AnimalManager();
        return instance;
      }
    }

    public void AddAnimal(Animal animal) {
      animals.Add(animal);
    }

    public void ShowAll() {
      int currentIndex;

      if (animals.Count == 0) {
        Console.WriteLine("Animal list is empty.");
        return;
      }

      currentIndex = 0;

      while (currentIndex < animals.Count) {
        Console.WriteLine($"{currentIndex + 1}. {animals[currentIndex].GetInfo()}");
        ++currentIndex;
      }
    }

    public void ShowByNumber(int userNumber) {
      int internalIndex;

      internalIndex = userNumber;

      if (internalIndex > 0 && internalIndex <= animals.Count) {
        Console.WriteLine(
          animals[internalIndex - 1].GetInfo());
      }
      else {
        Console.WriteLine("Invalid number.");
      }
    }

    public void ShowMenu() {
      string userChoice;
      int parsedNumber;

      while (true) {
        Console.WriteLine("\n=== MENU ===" + "\n1 - Show all animals" + "\n2 - Add new animal" + "\n3 - Show animal by number" + "\n0 - Exit\n");

        userChoice = Console.ReadLine();

        switch (userChoice) {
          case "1":
            ShowAll();
            break;

          case "2":
            CreateAnimal();
            break;

          case "3":
            Console.Write("Enter number: ");
            if (int.TryParse(Console.ReadLine(), out parsedNumber))
              ShowByNumber(parsedNumber);
            else
              Console.WriteLine("Invalid input.");
            break;

          case "0":
            return;

          default:
            Console.WriteLine("Wrong choice.");
            break;
        }
      }
    }

    private void CreateAnimal() {
      string name;
      int age;
      string habitat;
      string food;
      bool hasFur;

      Console.Write("Name: ");
      name = Console.ReadLine();

      Console.Write("Age: ");
      age = int.Parse(Console.ReadLine());

      Console.Write("Habitat: ");
      habitat = Console.ReadLine();

      Console.Write("Food Type: ");
      food = Console.ReadLine();

      Console.Write("Has fur (true/false): ");
      hasFur = bool.Parse(Console.ReadLine());

      AddAnimal(new Mammal(name, age, habitat, food, hasFur));
    }
  }

  class Program {
    static void Main() {
      AnimalManager.Instance.AddAnimal(
        new Mammal("Leo", 5, "Savanna", "Carnivore", true));

      AnimalManager.Instance.ShowMenu();
    }
  }
}