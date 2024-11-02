using ChessGame;

Console.OutputEncoding = System.Text.Encoding.Unicode;

Player.LoadPlayersList();

Console.WriteLine("Commands:");
Console.WriteLine("--> RJ <nome> (Criar Jogador)");
Console.WriteLine("--> LJ (Ver todos os Jogadores)");
Console.WriteLine("--> Start <Jogador 1> <Jogador 2>");
Console.WriteLine("--> Load (Load do Jogo anterior)");
Console.WriteLine("--> Exit (Saír do Jogo)");

Command();

void Command()
{
    string? command;

    do
    {
        do
        {
            Console.WriteLine("\nDigite o Comando:");
            command = Console.ReadLine();

        } while (command == null);

        var words = command.Split(' ');

        switch (words[0])
        {
            case "RJ":
                Player.RegisterPlayer(words[1]);
                break;

            case "LJ":
                Player.ShowAllPlayers();
                break;
            case "Start":
                Game game = new Game();
                game.StartGame(words[1], words[2]);
                break;
            case "Load":
                Game loadgame = new Game();
                //loadgame.LoadGame();
                break;
        }
    } while (command.ToUpper() != "EXIT");
}