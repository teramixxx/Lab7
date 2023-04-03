class Program
{
    static void Main(string[] args)
    {
        Hero hero = new Hero();
        hero.Shoot(); 
        GameHistory game = new GameHistory();

        game.History.Push(hero.SaveState()); 

        hero.Shoot(); 

        hero.RestoreState(game.History.Pop());

        hero.Shoot(); 

        Console.Read();
    }
}


class Hero
{
    private int patrons = 10;
    private int lives = 5; 

    public void Shoot()
    {
        if (patrons > 0)
        {
            patrons--;
            Console.WriteLine("Виконано пострiл. Залишилось {0} патронiв", patrons);
        }
        else
            Console.WriteLine("Патронiв бiльше нема");
    }
    public HeroMemento SaveState()
    {
        Console.WriteLine("Збереження гри. Параметри: {0} патронiв, {1} життiв", patrons, lives);
        return new HeroMemento(patrons, lives);
    }

    public void RestoreState(HeroMemento memento)
    {
        this.patrons = memento.Patrons;
        this.lives = memento.Lives;
        Console.WriteLine("Вiдновлення гри. Параметри: {0} патронiв, {1} життiв", patrons, lives);
    }
}

class HeroMemento
{
    public int Patrons { get; private set; }
    public int Lives { get; private set; }

    public HeroMemento(int patrons, int lives)
    {
        this.Patrons = patrons;
        this.Lives = lives;
    }
}

class GameHistory
{
    public Stack<HeroMemento> History { get; private set; }
    public GameHistory()
    {
        History = new Stack<HeroMemento>();
    }
}