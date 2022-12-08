using System.Security.Cryptography;

public static class Program{

public static void Main(string[] args){


var f1 = FactionCollection.Create();
var factions = FactionCol(f1).ToList();
Shuffle<Faction>(factions);

Console.WriteLine("Ready for some TI?");
Console.WriteLine("-------------------");

var nrOfPlayers = insertNumberOfPlayers();

while(nrOfPlayers <=1){
if(nrOfPlayers <= 1){
nrOfPlayers = insertNumberOfPlayers();
}else{
    break;
}
}

var playerMap = playerMapper(nrOfPlayers);
int p = 0;
foreach(var player in playerMap){

var temp = factions.GetRange(p,4);
p+=4;
player.Value.AddRange(temp);

Console.WriteLine(player.Key + "'s factions");
Console.WriteLine("-------------------------");

foreach(var fac in player.Value){
Console.WriteLine(fac.Name + " : " + fac.Style);
}
Console.WriteLine("-------------------------");

}

}


static int insertNumberOfPlayers(){

try{
    Console.WriteLine("Enter the number of players");
    var nrOfPlayers = int.Parse(Console.ReadLine()!);
    return nrOfPlayers;
}catch(Exception E){
    Console.WriteLine("Invalid input");
    return 0;
}

}

static Dictionary<string,List<Faction>> playerMapper(int nr){
    var players = new Dictionary<string,List<Faction>>();
    for(int i = 0; i < nr; i++){
        players.Add(insertPlayer(i), new List<Faction>());
    }
    return players;
}

static string insertPlayer(int playerNr){
    try{
    Console.WriteLine("Please enter player " + playerNr++ + "'s name");
    Console.WriteLine("-------------------------------------------");
    //can this be null?
    var playerName = Console.ReadLine();
    return playerName!;
}catch(Exception E){
    Console.WriteLine("Invalid input");
    return null!;
}
}

static IEnumerable<Faction> FactionCol(IEnumerable<Faction> wzCol)=> wzCol.ToList();
public static void Shuffle<T>(this IList<T> list)
{
    RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
    int n = list.Count;
    while (n > 1)
    {
        byte[] box = new byte[1];
        do provider.GetBytes(box);
        while (!(box[0] < n * (Byte.MaxValue / n)));
        int k = (box[0] % n);
        n--;
        T value = list[k];
        list[k] = list[n];
        list[n] = value;
    }
} 

}

