using System;
using Xunit;

public class Program {
    public static void Main(){
        Console.ReadLine();
    }
}

public class Vehicle
{
    public Vehicle(string make = "dodge", string model = "ram")
    {
        Make = make;
        Model = model;
    }
    public virtual string Name { get; set; }
    public string Make { get; set; } 
    public string Model { get; set; } 
    public virtual int NumOfGears { get; set; } = 4;
    public virtual int NumOfTires { get; set; } = 4;
    public override string ToString() {
        Console.WriteLine($"This {Name} is a {Make} {Model}");
    }
}

public class ElectricCar : Vehicle , IAutopilotable{
    public ElectricCar(string make = "dodge", string model = "ram") : base(make, model){}
    public override int NumOfGears {get; set;} = 1;
    public override string Name {get; set;} = "electric car";
}

public class Tesla : ElectricCar {
    public Tesla(string make = "dodge", string model = "ram") : base(make, model){}
    public override string Name {get; set;} = "tesla";
    //bool IAutopilotable..
    }

public class Motorcycle : Vehicle {
    public Motorcycle(string make = "dodge", string model = "ram") : base(make, model){}
    public override int NumOfTires {get; set;} = 2;
    public override string Name {get; set;} = "motorcycle";
}

public class Trike : Motorcycle {
    public Trike(string make = "dodge", string model = "ram") : base(make, model){}
    public override int NumOfTires {get; set; } = 3;
    public override int NumOfGears {get; set; } = 2;
}
public interface IAutopilotable {
    string Name { get; set; } 
    bool hasAutopilot{
        get {}
        set {}  
    }
}

public class InheritanceChallengeTests
{
    [Fact]
    public void Classes_Inherit()
    {
        Assert.True(new ElectricCar() is Vehicle);
        Assert.True(new Tesla() is ElectricCar);
        Assert.True(new Motorcycle() is Vehicle);
        Assert.True(new Trike() is Vehicle);
        Assert.True(new Trike() is Motorcycle);
    }

    [Fact]
    public void Vehicles_Describe_Themselves()
    {
        Assert.Equal("This electric car is a Nissan Leaf", new ElectricCar("Nissan", "Leaf").ToString());
        Assert.Equal("This motorcycle is a Honda CTX700N", new Motorcycle("Honda", "CTX700N").ToString());
        Assert.Equal("This trike is a Harley Davidson Freewheeler", new Trike("Harley Davidson", "Freewheeler").ToString());
    }


    [Fact]
    public void Correct_Number_Of_Gears()
    {
        Assert.Equal(1, new ElectricCar().NumOfGears);
        Assert.Equal(1, new Tesla().NumOfGears);
        Assert.Equal(4, new Motorcycle().NumOfGears);
        Assert.Equal(2, new Trike().NumOfGears);
    }

    [Fact]
    public void Correct_Number_Of_Tires()
    {
        Assert.Equal(4, new ElectricCar().NumOfTires);
        Assert.Equal(4, new Tesla().NumOfTires);
        Assert.Equal(2, new Motorcycle().NumOfTires);
        Assert.Equal(3, new Trike().NumOfTires);
    }

    [Fact]
    public void Self_Driving()
    {
        IAutopilotable c = new Tesla();
        IAutopilotable h = new Trike();
        Assert.True(c.hasAutopilot());
        Assert.False(c.hasAutopilot());
    }
}