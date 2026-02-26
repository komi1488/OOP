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

  class Bird : Animal {
    public double WingSpan {  get; set; }

    public Bird(string name, int age, string habitat, string foodType, double wingSpan) : base(name, age, habitat, foodType) {
      WingSpan = wingSpan;
    }

    public override string GetInfo() {
      return base.GetInfo() + $", Type: Bird, Wing Span: {WingSpan} meters";
    }
  }

  class Fish : Animal {
    public string WaterType {  get; set; }

    public Fish(string name, int age, string habitat, string foodType, string waterType) : base(name, age, habitat, foodType) {
      WaterType = waterType;
    }

    public override string GetInfo() {
      return base.GetInfo() + $", Type: Fish, Water Type: {WaterType}";
    }
  }

  class Reptile : Animal {
    public bool IsVenomous {  get; set; }

    public Reptile(string name, int age, string habitat, string foodType, bool isVenomous) : base(name, age, habitat, foodType) {
      IsVenomous = isVenomous;
    }

    public override string GetInfo() {
      return base.GetInfo() + $", Type: Reptile, Venomous: {(IsVenomous ? "Yes" : "No")}";
    }
  }

  class Amphibian : Animal {
    public string SkinMoisture {  get; set; }

    public Amphibian(string name, int age, string habitat, string foodType, string skinMoisture) : base(name, age, habitat, foodType) {
      SkinMoisture = skinMoisture;
    }

    public override string GetInfo() {
      return base.GetInfo() + $", Type: Amphibian, Skin Moisture: {SkinMoisture}";
    }
  }

  class AnimalManager {
    private static AnimalManager instance;
    private List<Animal> animals = new List<Animal>();

    private AnimalManager() { }

    public static AnimalManager Instance {
      get {
        if (instance == null) { 
          instance = new AnimalManager();
        }

        return instance;
      }
    }

    public void AddAnimal(Animal animal) {
      animals.Add(animal);
    }

    public void ShowAllAnimals() {
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

    public void GetByNumber(int userNumber) {
      int internalIndex;

      internalIndex = userNumber;

      if (internalIndex > 0 && internalIndex <= animals.Count) {
        Console.WriteLine(animals[internalIndex - 1].GetInfo());
      } else {
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
            ShowAllAnimals();
            break;

          case "2":
            CreateAnimal();
            break;

          case "3":
            Console.Write("Enter number: ");
            if (int.TryParse(Console.ReadLine(), out parsedNumber)) { 
              GetByNumber(parsedNumber);
            } else { 
              Console.WriteLine("Invalid input.");
            }

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
      Console.WriteLine("Choose animal type:" + "\n1 - Mammal" + "\n2 - Bird" + "\n3 - Fish" + "\n4 - Reptile" + "\n5 - Amphibian\n");
    
      string typeChoice = Console.ReadLine();
    
      Console.Write("Name: ");
      string name = Console.ReadLine();
    
      Console.Write("Age: ");
      int age = int.Parse(Console.ReadLine());
    
      Console.Write("Habitat: ");
      string habitat = Console.ReadLine();
    
      Console.Write("Food Type: ");
      string foodType = Console.ReadLine();

      switch (typeChoice) {
        case "1": // Mammal
          Console.Write("Has fur (true/false): ");
          bool hasFur = bool.Parse(Console.ReadLine());
          AddAnimal(new Mammal(name, age, habitat, foodType, hasFur));
          Console.WriteLine("Mammal added successfully.");
          break;

        case "2": // Bird
          Console.Write("Wing span (meters): ");
          double wingSpan = double.Parse(Console.ReadLine());
          AddAnimal(new Bird(name, age, habitat, foodType, wingSpan));
          Console.WriteLine("Bird added successfully.");
          break;

        case "3": // Fish
          Console.Write("Water type (Freshwater/Saltwater): ");
          string waterType = Console.ReadLine();
          AddAnimal(new Fish(name, age, habitat, foodType, waterType));
          Console.WriteLine("Fish added successfully.");
          break;

        case "4": // Reptile
          Console.Write("Is venomous (true/false): ");
          bool isVenomous = bool.Parse(Console.ReadLine());
          AddAnimal(new Reptile(name, age, habitat, foodType, isVenomous));
          Console.WriteLine("Reptile added successfully.");
          break;

        case "5": // Amphibian
          Console.Write("Skin moisture: ");
          string skinMoisture = Console.ReadLine();
          AddAnimal(new Amphibian(name, age, habitat, foodType, skinMoisture));
          Console.WriteLine("Amphibian added successfully.");
          break;

        default:
          Console.WriteLine("Invalid animal type. Animal not added.");
          break;
      }
    }
  }
  class Program {

    static void Main() {
      AnimalManager.Instance.AddAnimal(new Mammal("Leo", 5, "Savanna", "Carnivore", true));
      AnimalManager.Instance.AddAnimal(new Bird("Red", 2, "Savanna", "Carnivore", 2.5));

      AnimalManager.Instance.ShowMenu();
    }
  }
} 
