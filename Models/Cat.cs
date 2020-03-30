using System;

namespace cat_api.Models
{
  public class Cat
  {
    public Cat()
    {
      id = Guid.NewGuid().ToString();

    }
    public Cat(string name, string hair, int age)
    {
      Name = name;
      Hair = hair;
      Age = age;
      id = Guid.NewGuid().ToString();
    }

    public string Name { get; set; }
    public string Hair { get; set; }
    public int Age { get; set; }
    public string id { get; }

  }
}