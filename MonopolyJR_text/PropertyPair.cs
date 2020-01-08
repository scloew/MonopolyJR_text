using System;
using System.Collections.Generic;
using System.Text;

namespace MonopolyJR_text
{
  class PropertyPair
  {
    private readonly MonopolyProperty PropertyOne;
    private readonly MonopolyProperty PropertyTwo;

    public PropertyPair(MonopolyProperty mp1, MonopolyProperty mp2)
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
