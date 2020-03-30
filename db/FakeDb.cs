using System.Collections.Generic;
using cat_api.Models;

namespace cat_api.db
{
  public class FakeDb
  {
    public static List<Cat> Cats { get; set; } = new List<Cat>(){
          new Cat("cat", "hair", 5),
          new Cat("rockney", "green", 8),
    };
  }
}