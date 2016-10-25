using System;
using Xunit;

public class Program {
    public static void Main(){
        Console.ReadLine();
    }
}

interface IAutopilotable{
    bool hasAutopilot();
}

public class Vehicle
{
   public virtual string Type {get; set;}  //if prop to be inherited, virtual. 1
    public Vehicle(string make, string model)
    {
        Make = make;
        Model = model;
    }
 
    public string Make { get; set; }
    public string Model { get; set; }
    public virtual int NumOfGears { get; set; } = 4;
    public virtual int NumOfTires { get; set; } = 4;

    public override string ToString(){
        return $"This {Type} is a {Make} {Model}";
    }
}       
public class ElectricCar : Vehicle {
    public override string Type{get; set;} = "electric car"; //1
    public ElectricCar(string make = "", string model = "") : base(make, model){}  //calling base constructor
    public override int NumOfGears{get; set;} = 1;
        
}
public class Tesla : ElectricCar, IAutopilotable{
    public Tesla(string make = "", string model = "") : base(make, model){}
    public override string Type{get; set;} = "Tesla";

    public bool hasAutopilot(){ return true;}
    
}
public class Motorcycle : Vehicle{
    public Motorcycle(string make = "", string model = "") : base(make, model){}
    public override int NumOfTires{get; set;} = 2;
    public override string Type{get; set;} = "motorcycle";
}

public class Trike : Motorcycle, IAutopilotable{
    public Trike(string make = "", string model = "") : base(make, model){}
    public override string Type{get; set;} = "trike";

    public bool hasAutopilot(){ return true;}
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