namespace RPGd;
using ConsoleHelper;

public static class Combate
{
    static double Atacar(double atq, double def)
    {
        return atq - def;
    }
}