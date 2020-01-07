
namespace MonopolyJR_text
{
  static class Constants
  {
    public const int PassGoBonues = 3; //Not sure these should be hardcoded like this
    public const int Tax = 2;
    public const int BathroomTax = 3;
    public const int TurnLimit = 100;
    public const int StartingMoney = 31;
    public const bool FindWinner = false;
    public const bool FindLoser = true; //these values are set because of xor used in GameInstance.Print
  }
}
