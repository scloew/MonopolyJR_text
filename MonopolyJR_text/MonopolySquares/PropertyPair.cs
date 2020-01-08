using System;
using System.Collections.Generic;
using System.Text;

namespace MonopolyJR_text
{
  class PropertyPair
  {
    private readonly PropertySquare PropertyOne;
    private readonly PropertySquare PropertyTwo;

    public PropertyPair(PropertySquare mp1, PropertySquare mp2)
    {
      PropertyOne = mp1;
      PropertyTwo = mp2;
    }

    public void CheckMonopoly()
    {
      if (PropertyOne.Owner == PropertyTwo.Owner)
      {
        PropertyOne.SetMonopoly();
        PropertyTwo.SetMonopoly();
        Console.WriteLine($"{PropertyOne.Name} and {PropertyTwo.Name} are " +
          $"now a monopoly belonging to {PropertyOne.Owner.Name}. The rents are doubled");
      }
    }
  }
}
